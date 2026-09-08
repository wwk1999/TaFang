using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 批量把 TMP 文本字体替换为 CaoShu SDF
/// 关键:fontAsset 和 sharedMaterial 必须同时替换,否则材质仍指向旧字体 atlas 导致不显示
/// </summary>
public class ReplaceFontToCaoShu : EditorWindow
{
    private const string CaoShuPath = "Assets/Art/Font/CaoShu SDF.asset";
    private DefaultAsset targetFolder;
    private bool includeInactive = true;
    private Vector2 scroll;
    private readonly List<string> logs = new List<string>();

    [MenuItem("Tools/批量替换字体为CaoShu")]
    static void Open() => GetWindow<ReplaceFontToCaoShu>("字体替换为CaoShu");

    private void OnGUI()
    {
        EditorGUILayout.HelpBox(
            "TMP 换字体必须同时替换 Font Asset 和 Material Preset。\n" +
            "本工具会把范围内所有 TextMeshProUGUI 的两个字段一起换成 CaoShu SDF。",
            MessageType.Info);

        targetFolder = (DefaultAsset)EditorGUILayout.ObjectField(
            "Prefab文件夹(留空=用下方按钮)", targetFolder, typeof(DefaultAsset), false);
        includeInactive = EditorGUILayout.Toggle("包含未激活对象", includeInactive);

        EditorGUILayout.Space(8);

        using (new EditorGUI.DisabledScope(targetFolder == null))
        {
            if (GUILayout.Button("① 替换指定文件夹内所有 Prefab", GUILayout.Height(32)))
            {
                ReplaceInFolder();
            }
        }

        if (GUILayout.Button("② 替换当前场景所有 TMP 文本", GUILayout.Height(32)))
        {
            ReplaceInScene();
        }

        if (GUILayout.Button("③ 替换当前 Hierarchy 选中对象(含子物体)", GUILayout.Height(32)))
        {
            ReplaceInSelection();
        }

        EditorGUILayout.Space(8);
        EditorGUILayout.LabelField("日志:", EditorStyles.boldLabel);
        scroll = EditorGUILayout.BeginScrollView(scroll);
        foreach (var l in logs) EditorGUILayout.LabelField(l);
        EditorGUILayout.EndScrollView();
    }

    private TMP_FontAsset LoadCaoShu()
    {
        var fa = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(CaoShuPath);
        if (fa == null) Debug.LogError($"找不到 {CaoShuPath}");
        return fa;
    }

    private int ApplyToTexts(TMP_FontAsset cao, GameObject root, string where)
    {
        var texts = root.GetComponentsInChildren<TextMeshProUGUI>(includeInactive);
        int n = 0;
        foreach (var t in texts)
        {
            // 字体 + 材质必须一起换:材质的 _MainTex 必须指向 CaoShu 的 atlas
            Undo.RecordObject(t, "ReplaceFont");
            t.font = cao;
            t.fontSharedMaterial = cao.material;
            EditorUtility.SetDirty(t);
            n++;
        }
        logs.Insert(0, $"[{where}] 替换 {n} 个 TMP 文本");
        return n;
    }

    private void ReplaceInFolder()
    {
        var cao = LoadCaoShu();
        if (cao == null) return;

        string folder = AssetDatabase.GetAssetPath(targetFolder);
        var prefabs = Directory.GetFiles(folder, "*.prefab", SearchOption.AllDirectories);
        int total = 0;
        try
        {
            for (int i = 0; i < prefabs.Length; i++)
            {
                string path = prefabs[i].Replace('\\', '/');
                EditorUtility.DisplayProgressBar("替换字体", path, (float)i / prefabs.Length);

                var root = PrefabUtility.LoadPrefabContents(path);
                int n = ApplyToTexts(cao, root, Path.GetFileName(path));
                if (n > 0)
                {
                    PrefabUtility.SaveAsPrefabAsset(root, path);
                    total += n;
                }
                PrefabUtility.UnloadPrefabContents(root);
            }
        }
        finally
        {
            EditorUtility.ClearProgressBar();
        }
        AssetDatabase.SaveAssets();
        Debug.Log($"<color=#4CFF8A>CaoShu 字体替换完成,共 {total} 个文本</color>");
        logs.Insert(0, $"===== 完成,共 {total} 个 =====");
    }

    private void ReplaceInScene()
    {
        var cao = LoadCaoShu();
        if (cao == null) return;

        var scene = SceneManager.GetActiveScene();
        int total = 0;
        foreach (var root in scene.GetRootGameObjects())
        {
            total += ApplyToTexts(cao, root, scene.name);
        }
        Debug.Log($"<color=#4CFF8A>当前场景替换 {total} 个文本(记得保存场景)</color>");
        logs.Insert(0, $"===== 场景替换 {total} 个,请 Ctrl+S 保存场景 =====");
    }

    private void ReplaceInSelection()
    {
        var cao = LoadCaoShu();
        if (cao == null) return;

        int total = 0;
        foreach (var go in Selection.gameObjects)
        {
            // 选中 prefab 资源文件时直接加载内容处理
            string assetPath = AssetDatabase.GetAssetPath(go);
            if (!string.IsNullOrEmpty(assetPath) && assetPath.EndsWith(".prefab"))
            {
                var root = PrefabUtility.LoadPrefabContents(assetPath);
                int n = ApplyToTexts(cao, root, go.name);
                PrefabUtility.SaveAsPrefabAsset(root, assetPath);
                PrefabUtility.UnloadPrefabContents(root);
                total += n;
            }
            else
            {
                total += ApplyToTexts(cao, go, go.name);
            }
        }
        AssetDatabase.SaveAssets();
        Debug.Log($"<color=#4CFF8A>选中对象替换 {total} 个文本</color>");
        logs.Insert(0, $"===== 选中替换 {total} 个 =====");
    }
}
