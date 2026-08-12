using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class ExpandToMultipleOf4Tool : EditorWindow
{
    private string selectedFolderPath = "";
    private Vector2 scrollPos;
    private List<string> previewFiles = new List<string>();
    private bool isProcessing = false;

    [MenuItem("Tools/扩充图片到4倍")]
    public static void ShowWindow()
    {
        var window = GetWindow<ExpandToMultipleOf4Tool>("图片扩充工具");
        window.minSize = new Vector2(450, 300);
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("图片扩充到4的倍数", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("将图片的宽高向上扩充到最近的4的倍数，原图像居中，扩充区域透明。");
        EditorGUILayout.Space(8);

        DrawDragDropArea();

        EditorGUILayout.Space(8);

        if (GUILayout.Button("选择文件夹", GUILayout.Height(28)))
        {
            string path = EditorUtility.OpenFolderPanel("选择要处理的图片文件夹", Application.dataPath, "");
            if (!string.IsNullOrEmpty(path))
            {
                selectedFolderPath = path;
                UpdatePreview();
            }
        }

        EditorGUILayout.Space(8);

        if (!string.IsNullOrEmpty(selectedFolderPath))
        {
            EditorGUILayout.LabelField($"当前文件夹: {selectedFolderPath}");
            EditorGUILayout.LabelField($"找到 {previewFiles.Count} 张图片");

            EditorGUILayout.Space(5);

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(100));
            for (int i = 0; i < previewFiles.Count && i < 20; i++)
            {
                EditorGUILayout.LabelField(Path.GetFileName(previewFiles[i]));
            }
            if (previewFiles.Count > 20)
                EditorGUILayout.LabelField($"... 还有 {previewFiles.Count - 20} 张");
            EditorGUILayout.EndScrollView();

            EditorGUILayout.Space(10);

            GUI.enabled = previewFiles.Count > 0 && !isProcessing;
            if (GUILayout.Button("开始处理", GUILayout.Height(32)))
            {
                ProcessFolder();
            }
            GUI.enabled = true;
        }
    }

    private void DrawDragDropArea()
    {
        Rect dropArea = GUILayoutUtility.GetRect(0, 50, GUILayout.ExpandWidth(true));
        var style = new GUIStyle(GUI.skin.box);
        style.alignment = TextAnchor.MiddleCenter;
        style.fontStyle = FontStyle.Italic;
        style.normal.textColor = Color.gray;

        GUI.Box(dropArea, "将文件夹拖拽到此处", style);

        Event ev = Event.current;
        if (ev.type == EventType.DragUpdated)
        {
            if (dropArea.Contains(ev.mousePosition))
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                ev.Use();
            }
        }
        else if (ev.type == EventType.DragPerform)
        {
            if (dropArea.Contains(ev.mousePosition))
            {
                DragAndDrop.AcceptDrag();
                foreach (var dragged in DragAndDrop.paths)
                {
                    if (Directory.Exists(dragged))
                    {
                        selectedFolderPath = dragged;
                        UpdatePreview();
                        break;
                    }
                }
                ev.Use();
            }
        }
    }

    private void UpdatePreview()
    {
        previewFiles.Clear();
        if (string.IsNullOrEmpty(selectedFolderPath)) return;

        string[] exts = { ".png", ".jpg", ".jpeg", ".bmp", ".tga" };
        foreach (var ext in exts)
        {
            string[] files = Directory.GetFiles(selectedFolderPath, "*" + ext, SearchOption.AllDirectories);
            previewFiles.AddRange(files);
        }
    }

    private void ProcessFolder()
    {
        if (previewFiles.Count == 0) return;

        if (!EditorUtility.DisplayDialog("确认替换",
            $"即将直接替换 {previewFiles.Count} 张原图文件，此操作不可撤销。\n\n建议先备份重要资源。\n\n是否继续？",
            "确认替换", "取消"))
        {
            return;
        }

        isProcessing = true;
        int total = previewFiles.Count;
        int processed = 0;
        int skipped = 0;
        bool cancel = false;

        try
        {
            foreach (string filePath in previewFiles)
            {
                cancel = EditorUtility.DisplayCancelableProgressBar("扩充图片到4的倍数（替换原图）",
                    $"处理: {Path.GetFileName(filePath)} ({processed + 1}/{total})",
                    (float)processed / total);

                if (cancel) break;

                if (ProcessImage(filePath))
                    processed++;
                else
                    skipped++;
            }
        }
        finally
        {
            EditorUtility.ClearProgressBar();
            isProcessing = false;
        }

        if (cancel)
            Debug.Log("已取消处理");
        else
        {
            string msg = $"成功替换 {processed} 张图片";
            if (skipped > 0)
                msg += $"\n跳过 {skipped} 张（已是4的倍数）";
            EditorUtility.DisplayDialog("完成", msg, "确定");
            AssetDatabase.Refresh();
        }
    }

    private static int RoundUpToMultipleOf4(int value)
    {
        if (value % 4 == 0) return value;
        return value + (4 - value % 4);
    }

    // 直接从 PNG 文件头读取真实尺寸（字节 16-23）
    // PNG 格式: [8字节签名][4字节长度][4字节"IHDR"][4字节宽][4字节高]...
    private static bool TryReadPngDimensions(string filePath, out int width, out int height)
    {
        width = 0;
        height = 0;
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                if (fs.Length < 24) return false;
                byte[] buf = new byte[24];
                fs.Read(buf, 0, 24);
                // 验证 PNG 签名: 89 50 4E 47 0D 0A 1A 0A
                if (buf[0] != 0x89 || buf[1] != 0x50 || buf[2] != 0x4E || buf[3] != 0x47) return false;
                // 宽度在字节 16-19（大端序），高度在 20-23
                width = (buf[16] << 24) | (buf[17] << 16) | (buf[18] << 8) | buf[19];
                height = (buf[20] << 24) | (buf[21] << 16) | (buf[22] << 8) | buf[23];
                return width > 0 && height > 0;
            }
        }
        catch { return false; }
    }

    private static bool ProcessImage(string filePath)
    {
        string ext = Path.GetExtension(filePath).ToLower();

        // 读取真实尺寸：PNG 从文件头读，其他格式用 Texture2D
        int trueW, trueH;
        bool isPng = (ext == ".png");
        if (isPng)
        {
            if (!TryReadPngDimensions(filePath, out trueW, out trueH))
            {
                Debug.LogWarning($"无法读取 PNG 尺寸，跳过: {filePath}");
                return false;
            }
        }
        else
        {
            // 非 PNG 用 Texture2D 读取尺寸
            byte[] previewData = File.ReadAllBytes(filePath);
            Texture2D preview = new Texture2D(2, 2);
            preview.LoadImage(previewData);
            trueW = preview.width;
            trueH = preview.height;
            Object.DestroyImmediate(preview);
        }

        int newW = RoundUpToMultipleOf4(trueW);
        int newH = RoundUpToMultipleOf4(trueH);

        Debug.Log($"[{Path.GetFileName(filePath)}] 真实尺寸: {trueW}x{trueH} → 目标: {newW}x{newH}");

        // 已经是4的倍数，跳过
        if (newW == trueW && newH == trueH)
            return false;

        // 用 Texture2D 加载像素数据
        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D original = new Texture2D(2, 2);
        if (!original.LoadImage(fileData))
        {
            Debug.LogError($"无法加载图片: {filePath}");
            Object.DestroyImmediate(original);
            return false;
        }

        // LoadImage 后的实际尺寸（可能被 Unity 调整过）
        int loadedW = original.width;
        int loadedH = original.height;

        // 使用真实尺寸计算偏移
        int offsetX = (newW - trueW) / 2;
        int offsetY = (newH - trueH) / 2;

        Texture2D expanded = new Texture2D(newW, newH, TextureFormat.RGBA32, false);

        // 填充透明背景
        Color[] clearColors = new Color[newW * newH];
        for (int i = 0; i < clearColors.Length; i++)
            clearColors[i] = new Color(0, 0, 0, 0);
        expanded.SetPixels(clearColors);

        // 复制原图像素到居中位置
        // 使用 loadedW/loadedH 读取像素（Texture2D 的实际尺寸）
        Color[] originalPixels = original.GetPixels();
        for (int y = 0; y < loadedH; y++)
        {
            for (int x = 0; x < loadedW; x++)
            {
                int srcIdx = y * loadedW + x;
                expanded.SetPixel(offsetX + x, offsetY + y, originalPixels[srcIdx]);
            }
        }
        expanded.Apply();

        // 保存为 PNG（覆盖原文件）
        byte[] pngData = expanded.EncodeToPNG();
        File.WriteAllBytes(filePath, pngData);

        Object.DestroyImmediate(original);
        Object.DestroyImmediate(expanded);
        return true;
    }
}
