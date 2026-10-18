using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 批量将图片扩充到 1:1 正方形,原图居中,四周用透明像素填充,覆盖原文件
/// 用途:把长宽比不一致的散图统一成方形(边长 = max(宽,高),不缩放原图)
/// 菜单: Tools / 批量图片扩充到1:1方形
/// </summary>
public class BatchPadImageToSquare : EditorWindow
{
    static readonly string[] ImageExts = { ".png", ".jpg", ".jpeg", ".tga", ".bmp" };

    string folderPath = "";
    string status = "拖入或选择包含图片的文件夹";

    [MenuItem("Tools/批量图片扩充到1:1方形")]
    static void Open()
    {
        var win = GetWindow<BatchPadImageToSquare>("批量扩充到1:1");
        win.minSize = new Vector2(520, 260);
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

        EditorGUILayout.HelpBox(
            "规则:边长取原图宽高中的较大者,原图在方形画布中居中,不缩放;\n" +
            "四周差值用透明像素(RGBA 0,0,0,0)填充,直接覆盖原文件,名字不变。\n" +
            "已是正方形的图片自动跳过。透明通道仅 PNG 可保存,建议对 PNG 贴图使用。",
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

                // 已是正方形,跳过
                if (w == h) { skipped++; continue; }

                int size = Mathf.Max(w, h);

                // 原图像素
                Color[] src = temp.GetPixels();

                // 方形画布,默认即透明黑(RGBA 0,0,0,0),原图居中
                var dst = new Texture2D(size, size, TextureFormat.RGBA32, false);
                Color[] dstPixels = new Color[size * size];

                int offsetX = (size - w) / 2;
                int offsetY = (size - h) / 2;

                // 把原图逐行写入新画布(Unity y 轴从下往上)
                for (int y = 0; y < h; y++)
                {
                    Array.Copy(src, y * w, dstPixels, (y + offsetY) * size + offsetX, w);
                }
                dst.SetPixels(dstPixels);
                dst.Apply();

                byte[] outData = dst.EncodeToPNG();
                DestroyImmediate(dst);

                File.WriteAllBytes(file, outData);
                changedFiles.Add(file);
                padded++;
            }
            catch (Exception e)
            {
                fail++;
                Debug.LogWarning($"[BatchPadImageToSquare] 失败: {file}  {e.Message}");
            }
        }

        if (temp != null) DestroyImmediate(temp);
        EditorUtility.ClearProgressBar();

        // 覆盖源文件的话刷新 Unity
        if (changedFiles.Count > 0)
        {
            foreach (var f in changedFiles) AssetDatabase.ImportAsset(f);
        }

        status = $"完成! 扩充:{padded}  已是方形跳过:{skipped}  失败:{fail}";
        EditorUtility.DisplayDialog("处理完成", status, "好的");
    }
}
