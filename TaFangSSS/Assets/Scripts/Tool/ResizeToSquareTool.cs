using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class ResizeToSquareTool : EditorWindow
{
    // 扩充区域背景色设为透明
    private static readonly Color TRANSPARENT = new Color(0, 0, 0, 0);

    [MenuItem("Tools/扩充图片比例到1：1（透明扩展）")]
    public static void ExpandToSquareTransparent()
    {
        string folderPath = EditorUtility.OpenFolderPanel("选择要处理的图片文件夹", Application.dataPath, "");
        if (string.IsNullOrEmpty(folderPath)) return;

        // 支持的图片格式
        string[] supportedExtensions = { ".png", ".jpg", ".jpeg", ".bmp", ".tga" };
        List<string> imageFiles = new List<string>();
        foreach (string ext in supportedExtensions)
        {
            string[] files = Directory.GetFiles(folderPath, "*" + ext, SearchOption.AllDirectories);
            imageFiles.AddRange(files);
        }

        if (imageFiles.Count == 0)
        {
            EditorUtility.DisplayDialog("提示", "未找到支持的图片文件", "确定");
            return;
        }

        string outputRoot = Path.Combine(folderPath, "Square_1to1_Transparent");
        if (!Directory.Exists(outputRoot))
            Directory.CreateDirectory(outputRoot);

        int total = imageFiles.Count;
        int processed = 0;
        bool cancel = false;

        foreach (string filePath in imageFiles)
        {
            string relativePath = GetRelativePath(folderPath, filePath);
            string outputPath = Path.Combine(outputRoot, relativePath);
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            cancel = EditorUtility.DisplayCancelableProgressBar("扩充图片比例（透明背景）",
                $"处理: {Path.GetFileName(filePath)} ({processed + 1}/{total})",
                (float)processed / total);
            if (cancel) break;

            ProcessImageToSquare(filePath, outputPath);
            processed++;
        }

        EditorUtility.ClearProgressBar();
        if (cancel)
            Debug.Log("已取消");
        else
        {
            EditorUtility.DisplayDialog("完成", $"成功处理 {processed} 张图片\n输出位置：{outputRoot}", "确定");
            AssetDatabase.Refresh();
        }
    }

    private static void ProcessImageToSquare(string inputPath, string outputPath)
    {
        byte[] fileData = File.ReadAllBytes(inputPath);
        Texture2D original = new Texture2D(2, 2);
        if (!original.LoadImage(fileData))
        {
            Debug.LogError($"无法加载图片: {inputPath}");
            return;
        }

        int w = original.width;
        int h = original.height;
        int newSize = Mathf.Max(w, h);

        // 使用 RGBA32 格式确保透明度支持
        Texture2D squared = new Texture2D(newSize, newSize, TextureFormat.RGBA32, false);

        // 全部填充透明像素
        Color[] clearColors = new Color[newSize * newSize];
        for (int i = 0; i < clearColors.Length; i++)
            clearColors[i] = TRANSPARENT;
        squared.SetPixels(clearColors);

        // 计算居中偏移
        int offsetX = (newSize - w) / 2;
        int offsetY = (newSize - h) / 2;

        // 复制原图像素（注意Y轴翻转问题）
        Color[] originalPixels = original.GetPixels();
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                int srcIdx = y * w + x;
                int dstX = offsetX + x;
                int dstY = offsetY + y;   // 直接使用 y，不需要翻转（因为纹理读取时默认Y=0是底部，但SetPixel内部会处理？）
                // 稳妥起见，使用 SetPixel 逐个设置
                squared.SetPixel(dstX, dstY, originalPixels[srcIdx]);
            }
        }
        squared.Apply();

        // 编码为 PNG 保留透明度
        byte[] pngData = squared.EncodeToPNG();
        File.WriteAllBytes(outputPath, pngData);

        // 清理临时纹理
        Object.DestroyImmediate(original);
        Object.DestroyImmediate(squared);
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