using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
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

        isProcessing = true;
        string outputRoot = Path.Combine(selectedFolderPath, "Expanded_MultipleOf4");
        if (!Directory.Exists(outputRoot))
            Directory.CreateDirectory(outputRoot);

        int total = previewFiles.Count;
        int processed = 0;
        bool cancel = false;

        try
        {
            foreach (string filePath in previewFiles)
            {
                string relativePath = GetRelativePath(selectedFolderPath, filePath);
                string outputPath = Path.Combine(outputRoot, relativePath);
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!Directory.Exists(outputDir))
                    Directory.CreateDirectory(outputDir);

                cancel = EditorUtility.DisplayCancelableProgressBar("扩充图片到4的倍数",
                    $"处理: {Path.GetFileName(filePath)} ({processed + 1}/{total})",
                    (float)processed / total);

                if (cancel) break;

                ProcessImage(filePath, outputPath);
                processed++;
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
            EditorUtility.DisplayDialog("完成", $"成功处理 {processed} 张图片\n输出位置：{outputRoot}", "确定");
            AssetDatabase.Refresh();
        }
    }

    private static int RoundUpToMultipleOf4(int value)
    {
        if (value % 4 == 0) return value;
        return value + (4 - value % 4);
    }

    private static void ProcessImage(string inputPath, string outputPath)
    {
        byte[] fileData = File.ReadAllBytes(inputPath);
        Texture2D original = new Texture2D(2, 2);
        if (!original.LoadImage(fileData))
        {
            Debug.LogError($"无法加载图片: {inputPath}");
            Object.DestroyImmediate(original);
            return;
        }

        int w = original.width;
        int h = original.height;
        int newW = RoundUpToMultipleOf4(w);
        int newH = RoundUpToMultipleOf4(h);

        // 如果已经是4的倍数，直接复制
        if (newW == w && newH == h)
        {
            File.Copy(inputPath, outputPath, true);
            Object.DestroyImmediate(original);
            return;
        }

        Texture2D expanded = new Texture2D(newW, newH, TextureFormat.RGBA32, false);

        // 填充透明背景
        Color[] clearColors = new Color[newW * newH];
        for (int i = 0; i < clearColors.Length; i++)
            clearColors[i] = new Color(0, 0, 0, 0);
        expanded.SetPixels(clearColors);

        // 居中放置原图
        int offsetX = (newW - w) / 2;
        int offsetY = (newH - h) / 2;

        Color[] originalPixels = original.GetPixels();
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                int srcIdx = y * w + x;
                expanded.SetPixel(offsetX + x, offsetY + y, originalPixels[srcIdx]);
            }
        }
        expanded.Apply();

        byte[] pngData = expanded.EncodeToPNG();
        File.WriteAllBytes(outputPath, pngData);

        Object.DestroyImmediate(original);
        Object.DestroyImmediate(expanded);
    }

    private static string GetRelativePath(string basePath, string fullPath)
    {
        if (!basePath.EndsWith(Path.DirectorySeparatorChar.ToString()))
            basePath += Path.DirectorySeparatorChar;
        if (fullPath.StartsWith(basePath))
            return fullPath.Substring(basePath.Length);
        else
            return Path.GetFileName(fullPath);
    }
}
