using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 批量图片裁剪工具
/// 1. 拖入/选择一个文件夹
/// 2. 自动用第一张图做样板
/// 3. 鼠标在样板上框选要保留的区域
/// 4. 一键把文件夹里所有同尺寸图片按此区域裁剪并覆盖原文件
/// 菜单: Tools / 批量图片裁剪工具
/// </summary>
public class BatchImageCropper : EditorWindow
{
    static readonly string[] ImageExts = { ".png", ".jpg", ".jpeg", ".tga", ".bmp" };

    string folderPath = "";
    string[] imageFiles;
    Texture2D sampleImage;
    int sampleW, sampleH;

    Rect cropRect;          // 图片实际像素坐标下的框选区域
    bool hasCropRect;
    bool selecting;
    Vector2 dragStart;      // 拖拽起点(屏幕坐标)

    Rect displayRect;       // 图片在窗口里的显示矩形(屏幕坐标)
    float displayScale;     // 显示缩放比 = 显示宽 / 实际宽

    string status = "请选择包含图片的文件夹";
    bool overwriteSource = true;

    [MenuItem("Tools/批量图片裁剪工具")]
    static void Open()
    {
        var win = GetWindow<BatchImageCropper>("批量图片裁剪");
        win.minSize = new Vector2(720, 640);
    }

    void OnGUI()
    {
        // ===== 顶部:文件夹选择 =====
        GUILayout.Space(6);
        GUILayout.BeginHorizontal();
        GUILayout.Label("文件夹:", GUILayout.Width(50));
        folderPath = EditorGUILayout.TextField(folderPath);
        if (GUILayout.Button("浏览", GUILayout.Width(60)))
        {
            string p = EditorUtility.OpenFolderPanel("选择图片文件夹", "", "");
            if (!string.IsNullOrEmpty(p)) { folderPath = p; LoadSample(); }
        }
        GUILayout.EndHorizontal();

        // 拖放支持
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
                LoadSample();
                DragAndDrop.AcceptDrag();
            }
        }

        GUILayout.Space(6);
        overwriteSource = EditorGUILayout.ToggleLeft("  裁剪后覆盖原文件(否则在原目录生成 _cropped 后缀新文件)", overwriteSource);

        if (sampleImage == null)
        {
            EditorGUILayout.HelpBox("请选择或拖入一个包含图片的文件夹", MessageType.Info);
            GUILayout.Label(status);
            return;
        }

        GUILayout.Label($"样板图: {Path.GetFileName(imageFiles[0])}  尺寸: {sampleW} x {sampleH}  共 {imageFiles.Length} 张图");

        // ===== 样板显示 + 框选 =====
        Rect imgArea = GUILayoutUtility.GetRect(0, position.height - 180);
        DrawSampleWithCrop(imgArea);

        // ===== 底部:裁剪信息 + 按钮 =====
        GUILayout.Space(8);
        if (hasCropRect)
        {
            GUILayout.Label($"框选区域(像素): x={cropRect.x:F0}  y={cropRect.y:F0}  w={cropRect.width:F0}  h={cropRect.height:F0}",
                EditorStyles.boldLabel);
        }
        else
        {
            GUILayout.Label("按住鼠标左键在样板图上拖动框选要保留的区域", EditorStyles.miniLabel);
        }

        GUILayout.Space(4);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("清除框选", GUILayout.Width(100)))
        {
            hasCropRect = false;
            cropRect = Rect.zero;
            Repaint();
        }
        GUI.enabled = hasCropRect && cropRect.width > 1 && cropRect.height > 1;
        if (GUILayout.Button("✂ 裁剪所有图片", GUILayout.Height(32)))
        {
            CropAll();
        }
        GUI.enabled = true;
        GUILayout.EndHorizontal();

        GUILayout.Label(status);
    }

    /// <summary>
    /// 加载文件夹第一张图作为样板
    /// </summary>
    void LoadSample()
    {
        hasCropRect = false;
        cropRect = Rect.zero;

        if (!Directory.Exists(folderPath))
        {
            status = "文件夹不存在";
            return;
        }

        var files = new List<string>();
        foreach (var ext in ImageExts)
            files.AddRange(Directory.GetFiles(folderPath, "*" + ext));
        files.Sort();

        if (files.Count == 0)
        {
            status = "文件夹内没有图片";
            sampleImage = null;
            return;
        }

        imageFiles = files.ToArray();

        try
        {
            byte[] data = File.ReadAllBytes(imageFiles[0]);
            sampleImage = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            if (sampleImage.LoadImage(data))
            {
                sampleW = sampleImage.width;
                sampleH = sampleImage.height;
                status = $"已加载 {imageFiles.Length} 张图(均应为 {sampleW}x{sampleH})";
            }
            else
            {
                status = "样板图加载失败";
                sampleImage = null;
            }
        }
        catch (Exception e)
        {
            status = "加载错误: " + e.Message;
            sampleImage = null;
        }

        Repaint();
    }

    /// <summary>
    /// 绘制样板图片并处理框选交互
    /// </summary>
    void DrawSampleWithCrop(Rect area)
    {
        // 背景
        EditorGUI.DrawRect(area, new Color(0.12f, 0.12f, 0.12f));

        // 居中缩放绘制图片
        float scale = Mathf.Min(area.width / sampleW, area.height / sampleH);
        displayScale = scale;
        float drawW = sampleW * scale;
        float drawH = sampleH * scale;
        displayRect = new Rect(
            area.x + (area.width - drawW) / 2,
            area.y + (area.height - drawH) / 2,
            drawW, drawH);

        GUI.DrawTexture(displayRect, sampleImage, ScaleMode.StretchToFill, false);

        // 处理鼠标框选
        var e = Event.current;
        Vector2 mp = e.mousePosition;

        if (e.type == EventType.MouseDown && e.button == 0 && displayRect.Contains(mp))
        {
            selecting = true;
            dragStart = mp;
            cropRect = new Rect(ScreenToImage(mp), Vector2.zero);
            hasCropRect = true;
            e.Use();
        }
        else if (e.type == EventType.MouseDrag && selecting)
        {
            Vector2 p = ScreenToImage(mp);
            cropRect = new Rect(
                Mathf.Min(cropRect.x, p.x),
                Mathf.Min(cropRect.y, p.y),
                Mathf.Abs(p.x - cropRect.x),
                Mathf.Abs(p.y - cropRect.y));
            Repaint();
        }
        else if (e.type == EventType.MouseUp && selecting)
        {
            selecting = false;
            // 限制在图片范围内
            cropRect.x = Mathf.Clamp(cropRect.x, 0, sampleW);
            cropRect.y = Mathf.Clamp(cropRect.y, 0, sampleH);
            cropRect.width = Mathf.Min(cropRect.width, sampleW - cropRect.x);
            cropRect.height = Mathf.Min(cropRect.height, sampleH - cropRect.y);
            Repaint();
        }

        // 绘制框选矩形(屏幕坐标)
        if (hasCropRect)
        {
            Rect screenRect = ImageToScreen(cropRect);
            // 半透明遮罩(图片区域除框选外)
            Handles.DrawSolidRectangleWithOutline(displayRect, new Color(0, 0, 0, 0.4f), Color.clear);
            Handles.DrawSolidRectangleWithOutline(screenRect, new Color(1, 1, 1, 0.05f), Color.white);
            // 四角小标
            DrawCornerMarks(screenRect);
        }
    }

    Vector2 ScreenToImage(Vector2 screenPos)
    {
        float x = (screenPos.x - displayRect.x) / displayScale;
        float y = (displayRect.yMax - screenPos.y) / displayScale; // Y 翻转
        x = Mathf.Clamp(x, 0, sampleW);
        y = Mathf.Clamp(y, 0, sampleH);
        return new Vector2(x, y);
    }

    Rect ImageToScreen(Rect imgRect)
    {
        float x = displayRect.x + imgRect.x * displayScale;
        float y = displayRect.yMax - (imgRect.y + imgRect.height) * displayScale;
        return new Rect(x, y, imgRect.width * displayScale, imgRect.height * displayScale);
    }

    void DrawCornerMarks(Rect r)
    {
        float s = 6;
        var c = Color.yellow;
        Handles.DrawLine(new Vector2(r.x, r.y), new Vector2(r.x + s, r.y), 2);
        Handles.DrawLine(new Vector2(r.x, r.y), new Vector2(r.x, r.y + s), 2);
        Handles.DrawLine(new Vector2(r.xMax, r.y), new Vector2(r.xMax - s, r.y), 2);
        Handles.DrawLine(new Vector2(r.xMax, r.y), new Vector2(r.xMax, r.y + s), 2);
        Handles.DrawLine(new Vector2(r.x, r.yMax), new Vector2(r.x + s, r.yMax), 2);
        Handles.DrawLine(new Vector2(r.x, r.yMax), new Vector2(r.x, r.yMax - s), 2);
        Handles.DrawLine(new Vector2(r.xMax, r.yMax), new Vector2(r.xMax - s, r.yMax), 2);
        Handles.DrawLine(new Vector2(r.xMax, r.yMax), new Vector2(r.xMax, r.yMax - s), 2);
    }

    /// <summary>
    /// 批量裁剪
    /// </summary>
    void CropAll()
    {
        int cx = Mathf.RoundToInt(cropRect.x);
        int cy = Mathf.RoundToInt(cropRect.y);
        int cw = Mathf.RoundToInt(cropRect.width);
        int ch = Mathf.RoundToInt(cropRect.height);

        int success = 0, fail = 0, skip = 0;
        Texture2D temp = null;

        for (int i = 0; i < imageFiles.Length; i++)
        {
            string file = imageFiles[i];
            EditorUtility.DisplayProgressBar("正在裁剪", $"{i + 1}/{imageFiles.Length} {Path.GetFileName(file)}",
                (float)(i + 1) / imageFiles.Length);

            try
            {
                byte[] data = File.ReadAllBytes(file);
                if (temp == null) temp = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                temp.LoadImage(data);

                if (temp.width != sampleW || temp.height != sampleH)
                {
                    skip++;
                    continue;
                }

                // 裁剪(注意 Texture2D 的 y 轴:0=底部)
                Color[] pixels = temp.GetPixels(cx, cy, cw, ch);
                var cropped = new Texture2D(cw, ch, TextureFormat.RGBA32, false);
                cropped.SetPixels(pixels);
                cropped.Apply();

                byte[] outData = cropped.EncodeToPNG();
                DestroyImmediate(cropped);

                string outPath = overwriteSource
                    ? file
                    : Path.Combine(Path.GetDirectoryName(file),
                        Path.GetFileNameWithoutExtension(file) + "_cropped" + Path.GetExtension(file));

                File.WriteAllBytes(outPath, outData);
                success++;
            }
            catch
            {
                fail++;
            }
        }

        EditorUtility.ClearProgressBar();

        // 通知 Unity 刷新
        if (success > 0 && overwriteSource)
        {
            // 强制重新导入被修改的图片
            foreach (var f in imageFiles)
                AssetDatabase.ImportAsset(f);
        }

        status = $"完成! 成功:{success}  失败:{fail}  跳过(尺寸不符):{skip}";
        Debug.Log($"[BatchImageCropper] {status}");
        EditorUtility.DisplayDialog("裁剪完成", status, "好的");
    }
}
