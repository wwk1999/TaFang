using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 修复 CaoShu 材质预设:_MainTex 误指向方正字体 atlas,导致 TMP Material Preset 列表里选不到
/// TMP 规则:材质的 _MainTex 引用哪个字体资产的 atlas,就出现在哪个字体的预设列表
/// </summary>
public static class FixCaoShuMaterialPreset
{
    private const string FontFolder = "Assets/Art/Font";
    private const string CaoShuPath = "Assets/Art/Font/CaoShu SDF.asset";

    [MenuItem("Tools/修复CaoShu材质预设引用")]
    public static void Fix()
    {
        var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(CaoShuPath);
        if (font == null || font.atlasTextures == null || font.atlasTextures.Length == 0)
        {
            EditorUtility.DisplayDialog("错误", "CaoShu SDF 或其 atlas 贴图为空", "确定");
            return;
        }
        Texture2D atlas = font.atlasTextures[0];

        var mats = new List<Material>();
        foreach (var path in Directory.GetFiles(FontFolder, "*.mat", SearchOption.TopDirectoryOnly))
        {
            string p = path.Replace('\\', '/');
            var m = AssetDatabase.LoadAssetAtPath<Material>(p);
            if (m == null) continue;
            // 只处理名字带 CaoShu 的材质
            if (!m.name.Contains("CaoShu")) continue;
            mats.Add(m);
        }

        int fixedCount = 0;
        foreach (var m in mats)
        {
            bool isTMPShader = m.shader != null && m.shader.name.Contains("TextMeshPro");
            if (!isTMPShader)
            {
                Debug.LogWarning($"[跳过] {m.name} 的 shader 不是 TMP shader: {m.shader?.name}");
                continue;
            }

            var oldTex = m.mainTexture;
            m.SetTexture("_MainTex", atlas);
            EditorUtility.SetDirty(m);

            string oldName = oldTex != null
                ? (oldTex.name == atlas.name ? "已正确" : oldTex.name)
                : "空";
            Debug.Log($"<color=#4CFF8A>[修复] {m.name}: _MainTex {oldName} → {atlas.name}</color>");
            fixedCount++;
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        EditorUtility.DisplayDialog("完成",
            $"修复了 {fixedCount} 个材质的 atlas 引用。\n" +
            "现在选中 TMP 文本 → Font Asset 选 CaoShu SDF → Material Preset 圆点里就能看到「CaoShu SDF 标题」了。\n\n" +
            "提示:文件夹里有「标题」和「标题 1」两个重复材质,建议删掉一个。",
            "确定");
    }
}
