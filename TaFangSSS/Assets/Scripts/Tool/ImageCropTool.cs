using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class ImageCropTool : EditorWindow
{
    private string selectedFolderPath = "";
    private Vector2 scrollPos;
    private List<string> previewFiles = new List<string>();
    private bool isProcessing = false;
    private int targetWidth = 512;
    private int targetHeight = 512;
    private bool autoEnlarge = false; // 原图比目标小的时候是否放大

    [MenuItem("Tools/图片裁剪")]
    public static void ShowWindow()
    {
        var window = GetWindow<ImageCropTool>("图片裁剪工具");
        window.minSize = new Vector2(450, 350);
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("图片裁剪（中心对称）", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("从中心向外对称裁剪，上下左右同时裁掉相同像素，替换原图。");
        EditorGUILayout.Space(8);

        DrawDragDropArea();

        EditorGUILayout.Space(8);

        if (GUILayout.Button("选择文件夹", GUILayout.Height(28)))
        {
            string path = EditorUtility.OpenFolderPanel("选择要裁剪的图片文件夹", Application.dataPath, "");
            if (!string.IsNullOrEmpty(path))
            {
                selectedFolderPath = path;
                UpdatePreview();
            }
        }

        EditorGUILayout.Space(8);
        EditorGUILayout.LabelField("裁剪设置", EditorStyles.boldLabel);
        targetWidth = EditorGUILayout.IntField("裁剪宽度", targetWidth);
        targetHeight = EditorGUILayout.IntField("裁剪高度", targetHeight);
        autoEnlarge = EditorGUILayout.Toggle("原图比目标小时放大", autoEnlarge);
        EditorGUILayout.Space(4);
        EditorGUILayout.HelpBox(
            "裁剪规则：从中心对称裁剪，四周去掉的像素相同。\n" +
            "原图小于目标尺寸时：" + (autoEnlarge ? "会先放大再裁剪" : "跳过不处理") + "。\n" +
            "原图宽/高比与目标宽/高比不一致时，按较小比例边为基准裁剪（另一边裁掉更多）。",
            MessageType.Info);

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

            GUI.enabled = previewFiles.Count > 0 && !isProcessing && targetWidth > 0 && targetHeight > 0;
            if (GUILayout.Button("开始裁剪并替换原图", GUILayout.Height(32)))
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
            $"即将从中心对称裁剪并替换 {previewFiles.Count} 张原图文件，此操作不可撤销。\n\n建议先备份重要资源。\n\n是否继续？",
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
                cancel = EditorUtility.DisplayCancelableProgressBar("图片裁剪（替换原图）",
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
            string msg = $"成功裁剪 {processed} 张图片";
            if (skipped > 0)
                msg += $"\n跳过 {skipped} 张（原图已是目标尺寸或尺寸不足）";
            EditorUtility.DisplayDialog("完成", msg, "确定");
            AssetDatabase.Refresh();
        }
    }

    private bool ProcessImage(string filePath)
    {
        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D original = new Texture2D(2, 2);
        if (!original.LoadImage(fileData))
        {
            Debug.LogError($"无法加载图片: {filePath}");
            Object.DestroyImmediate(original);
            return false;
        }

        int srcW = original.width;
        int srcH = original.height;
        int dstW = targetWidth;
        int dstH = targetHeight;

        // 原图比目标小
        if (srcW < dstW || srcH < dstH)
        {
            if (!autoEnlarge)
            {
                Debug.Log($"跳过（原图 {srcW}x{srcH} 小于目标 {dstW}x{dstH}）: {Path.GetFileName(filePath)}");
                Object.DestroyImmediate(original);
                return false;
            }
            // 等比放大到能覆盖目标尺寸
            float scaleW = (float)dstW / srcW;
            float scaleH = (float)dstH / srcH;
            float scale = Mathf.Max(scaleW, scaleH);
            int scaledW = Mathf.RoundToInt(srcW * scale);
            int scaledH = Mathf.RoundToInt(srcH * scale);

            // 用 RenderTexture 放大
            Texture2D enlarged = ScaleTexture(original, scaledW, scaledH);
            Object.DestroyImmediate(original);
            original = enlarged;
            srcW = scaledW;
            srcH = scaledH;
        }

        // 原图和目标尺寸一致
        if (srcW == dstW && srcH == dstH)
        {
            Debug.Log($"跳过（已是目标尺寸 {srcW}x{srcH}）: {Path.GetFileName(filePath)}");
            Object.DestroyImmediate(original);
            return false;
        }

        // 中心对称裁剪：计算裁剪起始位置
        // 上下左右去掉相同像素：top=bottom=(srcH-dstH)/2, left=right=(srcW-dstW)/2
        int startX = (srcW - dstW) / 2;
        int startY = (srcH - dstH) / 2;

        Texture2D cropped = new Texture2D(dstW, dstH, TextureFormat.RGBA32, false);
        Color[] srcPixels = original.GetPixels(startX, startY, dstW, dstH);
        cropped.SetPixels(srcPixels);
        cropped.Apply();

        // 保存为 PNG（覆盖原文件）
        byte[] pngData = cropped.EncodeToPNG();
        File.WriteAllBytes(filePath, pngData);

        Debug.Log($"[{Path.GetFileName(filePath)}] {srcW}x{srcH} → {dstW}x{dstH} (裁掉 left={startX}, right={srcW - dstW - startX}, bottom={startY}, top={srcH - dstH - startY})");

        Object.DestroyImmediate(original);
        Object.DestroyImmediate(cropped);
        return true;
    }

    private static Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
    {
        RenderTexture rt = RenderTexture.GetTemporary(targetWidth, targetHeight, 0, RenderTextureFormat.ARGB32);
        rt.filterMode = FilterMode.Bilinear;
        RenderTexture.active = rt;
        Graphics.Blit(source, rt);
        Texture2D result = new Texture2D(targetWidth, targetHeight, TextureFormat.RGBA32, false);
        result.ReadPixels(new Rect(0, 0, targetWidth, targetHeight), 0, 0);
        result.Apply();
        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(rt);
        return result;
    }
}
