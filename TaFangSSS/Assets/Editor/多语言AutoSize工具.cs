using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 批量把预制体里所有 TMP 文本设为自动字号：
/// 最小值 12，最大值 = 当前字号。
///
/// 菜单：
///   Tools/多语言/储物袋相关-字号自适应
///   Tools/多语言/全项目-字号自适应
///
/// 说明：运行时 多语言Text 组件也会兜底开启自动字号，
/// 这个工具的作用是把设置持久化到预制体，编辑器里预览也能立即看到效果。
/// </summary>
public static class 多语言AutoSize工具
{
    private const float 最小字号 = 12f;

    private static readonly string[] 储物袋相关 =
    {
        "Assets/Resources/Prefabs/Window/储物袋界面.prefab",
        "Assets/Resources/Prefabs/Window/设置界面.prefab",
        "Assets/Resources/Prefabs/Window/ToastItem.prefab",
        "Assets/Resources/Prefabs/Window/BagGrid.prefab",
        "Assets/Resources/Prefabs/Window/功法Grid.prefab",
        "Assets/Resources/Prefabs/Window/灵物Grid.prefab",
        "Assets/Resources/Prefabs/Window/法器Grid.prefab",
        "Assets/Resources/Prefabs/Window/仙石Grid.prefab",
        "Assets/Resources/Prefabs/Window/装备item.prefab",
        "Assets/Resources/Prefabs/Window/强化弹窗.prefab",
        "Assets/Resources/Prefabs/Window/强化装备item.prefab",
        "Assets/Resources/Prefabs/Window/背包Grid信息弹窗.prefab",
        "Assets/Resources/Prefabs/Window/炼丹界面/丹药Grid.prefab",
        "Assets/Resources/Prefabs/Window/炼丹界面/灵药Grid.prefab",
        "Assets/Resources/Prefabs/Window/炼丹界面/丹方Grid.prefab",
        "Assets/Resources/Prefabs/Window/符文之地/符文Grid.prefab",
        "Assets/Resources/Prefabs/Window/远古遗迹/神物Grid.prefab",
    };

    [MenuItem("Tools/多语言/储物袋相关-字号自适应")]
    private static void 处理储物袋()
    {
        处理(储物袋相关);
    }

    [MenuItem("Tools/多语言/全项目-字号自适应")]
    private static void 处理全项目()
    {
        var guids = AssetDatabase.FindAssets("t:Prefab", new[] { "Assets/Resources/Prefabs" });
        var paths = new List<string>(guids.Length);
        foreach (var guid in guids) paths.Add(AssetDatabase.GUIDToAssetPath(guid));
        处理(paths.ToArray());
    }

    private static void 处理(string[] paths)
    {
        int 预制体数 = 0;
        int 文本数 = 0;
        try
        {
            for (int i = 0; i < paths.Length; i++)
            {
                string path = paths[i];
                if (AssetDatabase.LoadAssetAtPath<GameObject>(path) == null) continue;

                EditorUtility.DisplayProgressBar("多语言字号自适应", path, (float)i / paths.Length);

                GameObject root = PrefabUtility.LoadPrefabContents(path);
                bool 有修改 = false;
                foreach (var 文本 in root.GetComponentsInChildren<TMP_Text>(true))
                {
                    var so = new SerializedObject(文本);
                    var 自动 = so.FindProperty("m_enableAutoSizing");
                    var 最小 = so.FindProperty("m_fontSizeMin");
                    var 最大 = so.FindProperty("m_fontSizeMax");
                    var 字号 = so.FindProperty("m_fontSize");
                    if (自动 == null || 最小 == null || 最大 == null || 字号 == null) continue;

                    float 当前字号 = 字号.floatValue;
                    if (当前字号 < 1f)
                    {
                        var 基础字号 = so.FindProperty("m_fontSizeBase");
                        if (基础字号 != null && 基础字号.floatValue >= 1f) 当前字号 = 基础字号.floatValue;
                        else 当前字号 = 36f;
                    }

                    最大.floatValue = Mathf.Max(最小字号, 当前字号);
                    最小.floatValue = 最小字号;
                    自动.boolValue = true;
                    so.ApplyModifiedPropertiesWithoutUndo();

                    文本数++;
                    有修改 = true;
                }

                if (有修改)
                {
                    PrefabUtility.SaveAsPrefabAsset(root, path);
                    预制体数++;
                }
                PrefabUtility.UnloadPrefabContents(root);
            }
        }
        finally
        {
            EditorUtility.ClearProgressBar();
            AssetDatabase.SaveAssets();
        }

        Debug.Log($"<color=#4CFF8A>[多语言字号] 完成：{预制体数} 个预制体，{文本数} 个 TMP 文本已设为自动字号（最小12）。</color>");
        EditorUtility.DisplayDialog("多语言字号自适应",
            $"完成\n预制体：{预制体数}\nTMP 文本：{文本数}\n\n最小字号 12，最大值=原字号", "确定");
    }
}
