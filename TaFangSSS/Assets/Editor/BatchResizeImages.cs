using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 批量等比例缩小图片分辨率
/// 用途:降低图片像素数,减少包体大小
/// 菜单: Tools / 批量缩放图片分辨率
/// </summary>
public class BatchResizeImages : EditorWindow
{
    static readonly string[] ImageExts = { ".png", ".jpg", ".jpeg", ".tga", ".bmp" };

    string folderPath = "";
    float scale = 0.5f;          // 缩放比例 0.1~1.0
    bool overwriteSource = true;
    bool alignTo4 = true;        // 缩放后尺寸对齐到 4 的倍数
    string status = "请选择包含图片的文件夹";

    [MenuItem("Tools/批量缩放图片分辨率")]
    static void Open()
    {
        var win = GetWindow<BatchResizeImages>("批量缩放图片");
        win.minSize = new Vector2(520, 360);
    }

    void OnGUI()
    {
        GUILayout.Space(8);

        // 文件夹选择
        GUILayout.BeginHorizontal();
        GUILayout.Label("文件夹:", GUILayout.Width(50));
        folderPath = EditorGUILayout.TextField(folderPath);
        if (GUILayout.Button("浏览", GUILayout.Width(60)))
        {
            string p = EditorUtility.OpenFolderPanel("选择图片文件夹", "", "");
            if (!string.IsNullOrEmpty(p)) folderPath = p;
        }
        GUILayout.EndHorizontal();

        // 拖放
        var evt = Event.current;
        var dragRect = GUILayoutUtility.GetLastRect();
        if (evt.type == EventType.DragUpdated && dragRect.Contains(evt.mousePosition))
        {
            if (DragAndDrop.paths.Length > 0 && Directory.Exists(DragAndDrop.paths[0]))
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
        }
        else if (evt.type == EventType.DragPerform && dragRect.Contains(evt.mousePosition))
        {
            if (DragAndDrop.paths.Length > 0 && Directory.Exists(DragAndDrop.paths[0]))
            {
                folderPath = DragAndDrop.paths[0];
                DragAndDrop.AcceptDrag();
            }
        }

        GUILayout.Space(12);

        // 缩放比例
        GUILayout.Label($"缩放比例: {scale * 100:F0}%", EditorStyles.boldLabel);
        scale = EditorGUILayout.Slider(scale, 0.1f, 1f);

        // 快捷比例按钮
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("25%")) scale = 0.25f;
        if (GUILayout.Button("50%")) scale = 0.5f;
        if (GUILayout.Button("75%")) scale = 0.75f;
        if (GUILayout.Button("90%")) scale = 0.9f;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
        overwriteSource = EditorGUILayout.ToggleLeft("  覆盖原文件(否则输出 _resized 后缀)", overwriteSource);
        alignTo4 = EditorGUILayout.ToggleLeft("  缩放后尺寸对齐到 4 的倍数(推荐,便于 GPU 压缩)", alignTo4);

        GUILayout.Space(10);
        EditorGUILayout.HelpBox(
            "示例:1532×2048 缩小 50% → 766×1024 → 对齐4倍数 → 768×1024\n" +
            "缩小使用双线性插值,画面平滑。缩放后包体里的显存占用 = 原占用 × 比例²",
            MessageType.Info);

        GUILayout.Space(10);
        GUI.enabled = Directory.Exists(folderPath) && scale < 1f;
        if (GUILayout.Button("开始缩放", GUILayout.Height(36)))
        {
            ProcessAll();
        }
        GUI.enabled = true;

        GUILayout.Space(10);
        GUILayout.Label(status);
    }

    static int CeilTo4(int v) => Mathf.CeilToInt(v / 4f) * 4;

    void ProcessAll()
    {
        if (!Directory.Exists(folderPath)) { status = "文件夹不存在"; return; }

        var files = new List<string>();
        foreach (var ext in ImageExts)
            files.AddRange(Directory.GetFiles(folderPath, "*" + ext));
        files.Sort();

        if (files.Count == 0) { status = "文件夹内没有图片"; return; }

        int resized = 0, skipped = 0, fail = 0;
        Texture2D temp = null;

        for (int i = 0; i < files.Count; i++)
        {
            string file = files[i];
            EditorUtility.DisplayProgressBar("缩放中", $"{i + 1}/{files.Count} {Path.GetFileName(file)}",
                (float)(i + 1) / files.Count);

            try
            {
                byte[] data = File.ReadAllBytes(file);
                if (temp == null) temp = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                temp.LoadImage(data);

                int w = temp.width;
                int h = temp.height;

                int newW = Mathf.RoundToInt(w * scale);
                int newH = Mathf.RoundToInt(h * scale);

                // 至少 1 像素
                newW = Mathf.Max(1, newW);
                newH = Mathf.Max(1, newH);

                // 对齐 4 倍数
                if (alignTo4)
                {
                    newW = CeilTo4(newW);
                    newH = CeilTo4(newH);
                }

                // 尺寸没变就跳过
                if (newW == w && newH == h) { skipped++; continue; }

                // 用 RenderTexture 双线性缩放(质量好)
                var rt = RenderTexture.GetTemporary(newW, newH, 0, RenderTextureFormat.ARGB32);
                rt.filterMode = FilterMode.Bilinear;
                Graphics.Blit(temp, rt);

                var prev = RenderTexture.active;
                RenderTexture.active = rt;

                var result = new Texture2D(newW, newH, TextureFormat.RGBA32, false);
                result.ReadPixels(new Rect(0, 0, newW, newH), 0, 0);
                result.Apply();

                RenderTexture.active = prev;
                RenderTexture.ReleaseTemporary(rt);

                byte[] outData = result.EncodeToPNG();
                DestroyImmediate(result);

                string outPath = overwriteSource
                    ? file
                    : Path.Combine(Path.GetDirectoryName(file),
                        Path.GetFileNameWithoutExtension(file) + "_resized" + Path.GetExtension(file));

                File.WriteAllBytes(outPath, outData);
                resized++;
            }
            catch (Exception e)
            {
                fail++;
                Debug.LogWarning($"[BatchResizeImages] 失败: {file}  {e.Message}");
            }
        }

        EditorUtility.ClearProgressBar();

        if (resized > 0 && overwriteSource)
        {
            foreach (var f in files) AssetDatabase.ImportAsset(f);
        }

        status = $"完成! 缩放:{resized}  尺寸未变跳过:{skipped}  失败:{fail}";
        Debug.Log($"[BatchResizeImages] {status}");
        EditorUtility.DisplayDialog("缩放完成", status, "好的");
    }
}
