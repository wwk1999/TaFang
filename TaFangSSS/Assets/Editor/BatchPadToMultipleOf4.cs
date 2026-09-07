using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 批量将图片尺寸扩充到 4 的倍数(向上取整)
/// 用途:让非 4 倍数尺寸的 PNG 能被 DXT/BC 等 GPU 压缩格式正确处理
/// 原图内容放在左上角,右侧/下方填充透明像素
/// 菜单: Tools / 批量图片尺寸补 4 倍数
/// </summary>
public class BatchPadToMultipleOf4 : EditorWindow
{
    static readonly string[] ImageExts = { ".png", ".jpg", ".jpeg", ".tga", ".bmp" };

    string folderPath = "";
    string status = "请选择包含图片的文件夹";
    bool overwriteSource = true;
    bool centerImage = false;

    [MenuItem("Tools/批量图片尺寸补4倍数")]
    static void Open()
    {
        var win = GetWindow<BatchPadToMultipleOf4>("批量补4倍数");
        win.minSize = new Vector2(520, 320);
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
            if (!string.IsNullOrEmpty(p)) { folderPath = p; }
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

        GUILayout.Space(10);
        overwriteSource = EditorGUILayout.ToggleLeft("  覆盖原文件(否则输出 _padded 后缀)", overwriteSource);
        centerImage = EditorGUILayout.ToggleLeft("  原图在新画布中居中(否则贴左上角)", centerImage);

        GUILayout.Space(10);
        EditorGUILayout.HelpBox(
            "规则:宽高向上取整到最近的 4 的倍数(如 1532×2048 → 1532×2048 不变; 1530×2047 → 1532×2048)。\n" +
            "新增的像素填充为透明色(RGBA 0,0,0,0)。",
            MessageType.Info);

        GUILayout.Space(10);
        GUI.enabled = Directory.Exists(folderPath);
        if (GUILayout.Button("开始处理", GUILayout.Height(36)))
        {
            ProcessAll();
        }
        GUI.enabled = true;

        GUILayout.Space(10);
        GUILayout.Label(status);
    }

    /// <summary>
    /// 向上取整到 4 的倍数
    /// </summary>
    static int CeilTo4(int v)
    {
        return Mathf.CeilToInt(v / 4f) * 4;
    }

    void ProcessAll()
    {
        if (!Directory.Exists(folderPath)) { status = "文件夹不存在"; return; }

        var files = new List<string>();
        foreach (var ext in ImageExts)
            files.AddRange(Directory.GetFiles(folderPath, "*" + ext));
        files.Sort();

        if (files.Count == 0) { status = "文件夹内没有图片"; return; }

        int padded = 0, skipped = 0, fail = 0;
        Texture2D temp = null;

        for (int i = 0; i < files.Count; i++)
        {
            string file = files[i];
            EditorUtility.DisplayProgressBar("处理中", $"{i + 1}/{files.Count} {Path.GetFileName(file)}",
                (float)(i + 1) / files.Count);

            try
            {
                byte[] data = File.ReadAllBytes(file);
                if (temp == null) temp = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                temp.LoadImage(data);

                int w = temp.width;
                int h = temp.height;
                int newW = CeilTo4(w);
                int newH = CeilTo4(h);

                // 已经是 4 的倍数,跳过
                if (newW == w && newH == h) { skipped++; continue; }

                // 原图像素
                Color[] src = temp.GetPixels();

                // 新画布默认透明
                var dst = new Texture2D(newW, newH, TextureFormat.RGBA32, false);
                Color[] dstPixels = new Color[newW * newH]; // 默认黑色,需要设为透明

                int offsetX = centerImage ? (newW - w) / 2 : 0;
                int offsetY = centerImage ? (newH - h) / 2 : 0;

                // 把原图写入新画布(Unity y 轴从下往上)
                for (int y = 0; y < h; y++)
                {
                    int srcRow = y * w;
                    int dstRow = (y + offsetY) * newW;
                    Array.Copy(src, srcRow, dstPixels, dstRow + offsetX, w);
                }
                dst.SetPixels(dstPixels);
                dst.Apply();

                byte[] outData = dst.EncodeToPNG();
                DestroyImmediate(dst);

                string outPath = overwriteSource
                    ? file
                    : Path.Combine(Path.GetDirectoryName(file),
                        Path.GetFileNameWithoutExtension(file) + "_padded" + Path.GetExtension(file));

                File.WriteAllBytes(outPath, outData);
                padded++;
            }
            catch (Exception e)
            {
                fail++;
                Debug.LogWarning($"[BatchPadToMultipleOf4] 失败: {file}  {e.Message}");
            }
        }

        EditorUtility.ClearProgressBar();

        // 覆盖源文件的话刷新 Unity
        if (padded > 0 && overwriteSource)
        {
            foreach (var f in files) AssetDatabase.ImportAsset(f);
        }

        status = $"完成! 扩充:{padded}  已是4倍数跳过:{skipped}  失败:{fail}";
        Debug.Log($"[BatchPadToMultipleOf4] {status}");
        EditorUtility.DisplayDialog("处理完成", status, "好的");
    }
}
