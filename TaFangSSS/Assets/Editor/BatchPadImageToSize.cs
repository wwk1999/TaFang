using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 批量将图片扩充到指定尺寸,原图居中,四周用透明像素填充
/// 用途:把不同尺寸的散图统一成同一规格(如全部 1024×1024),便于做图集/Spine/粒子贴图
/// 菜单: Tools / 批量图片扩充到指定尺寸
/// </summary>
public class BatchPadImageToSize : EditorWindow
{
    static readonly string[] ImageExts = { ".png", ".jpg", ".jpeg", ".tga", ".bmp" };

    string folderPath = "";
    int targetW = 1024;
    int targetH = 1024;
    bool overwriteSource = true;
    string status = "请选择包含图片的文件夹";

    [MenuItem("Tools/批量图片扩充到指定尺寸")]
    static void Open()
    {
        var win = GetWindow<BatchPadImageToSize>("批量扩充图片尺寸");
        win.minSize = new Vector2(520, 340);
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

        // 拖放文件夹
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

        // 目标尺寸
        GUILayout.Label("目标尺寸(像素):", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        GUILayout.Label("宽", GUILayout.Width(30));
        targetW = EditorGUILayout.IntField(targetW);
        GUILayout.Label("高", GUILayout.Width(30));
        targetH = EditorGUILayout.IntField(targetH);
        GUILayout.EndHorizontal();

        // 常用尺寸快捷按钮
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("256×256")) { targetW = 256; targetH = 256; }
        if (GUILayout.Button("512×512")) { targetW = 512; targetH = 512; }
        if (GUILayout.Button("1024×1024")) { targetW = 1024; targetH = 1024; }
        if (GUILayout.Button("2048×2048")) { targetW = 2048; targetH = 2048; }
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
        overwriteSource = EditorGUILayout.ToggleLeft("  覆盖原文件(否则输出 _padded 后缀)", overwriteSource);

        GUILayout.Space(10);
        EditorGUILayout.HelpBox(
            "规则:原图在新画布中居中,四周填充透明像素(RGBA 0,0,0,0)。\n" +
            "宽/高与目标一致的图片跳过;宽或高超过目标尺寸的图片不会缩放,直接跳过并警告。\n" +
            "透明通道仅 PNG 可保存,建议对 PNG 贴图使用。",
            MessageType.Info);

        GUILayout.Space(10);
        GUI.enabled = Directory.Exists(folderPath) && targetW > 0 && targetH > 0;
        if (GUILayout.Button("开始处理", GUILayout.Height(36)))
        {
            ProcessAll();
        }
        GUI.enabled = true;

        GUILayout.Space(10);
        GUILayout.Label(status);
    }

    void ProcessAll()
    {
        if (!Directory.Exists(folderPath)) { status = "文件夹不存在"; return; }

        var files = new List<string>();
        foreach (var ext in ImageExts)
            files.AddRange(Directory.GetFiles(folderPath, "*" + ext));
        files.Sort();

        if (files.Count == 0) { status = "文件夹内没有图片"; return; }

        int padded = 0, skipped = 0, tooBig = 0, fail = 0;
        Texture2D temp = null;
        var changedFiles = new List<string>();

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

                // 已经是目标尺寸,跳过
                if (w == targetW && h == targetH) { skipped++; continue; }

                // 超过目标尺寸:不缩放,跳过
                if (w > targetW || h > targetH)
                {
                    tooBig++;
                    Debug.LogWarning($"[BatchPadImageToSize] 超过目标尺寸,跳过: {Path.GetFileName(file)}  原图 {w}×{h} > 目标 {targetW}×{targetH}");
                    continue;
                }

                // 原图像素
                Color[] src = temp.GetPixels();

                // 新画布,默认透明黑,原图居中(差值为奇数时多出的 1px 落在右/上边)
                var dst = new Texture2D(targetW, targetH, TextureFormat.RGBA32, false);
                Color[] dstPixels = new Color[targetW * targetH];

                int offsetX = (targetW - w) / 2;
                int offsetY = (targetH - h) / 2;

                // 把原图写入新画布(Unity y 轴从下往上)
                for (int y = 0; y < h; y++)
                {
                    int srcRow = y * w;
                    int dstRow = (y + offsetY) * targetW;
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
                if (overwriteSource) changedFiles.Add(file);
                padded++;
            }
            catch (Exception e)
            {
                fail++;
                Debug.LogWarning($"[BatchPadImageToSize] 失败: {file}  {e.Message}");
            }
        }

        if (temp != null) DestroyImmediate(temp);
        EditorUtility.ClearProgressBar();

        // 覆盖源文件的话刷新 Unity
        if (changedFiles.Count > 0)
        {
            foreach (var f in changedFiles) AssetDatabase.ImportAsset(f);
        }

        status = $"完成! 扩充:{padded}  已是目标尺寸跳过:{skipped}  超过尺寸跳过:{tooBig}  失败:{fail}";
        Debug.Log($"[BatchPadImageToSize] {status}");
        EditorUtility.DisplayDialog("处理完成", status, "好的");
    }
}
