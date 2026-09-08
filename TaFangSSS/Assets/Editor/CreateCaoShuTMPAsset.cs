using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

/// <summary>
/// 一键从 CaoShu.ttf 生成 TextMeshPro 动态 SDF 字体资产
/// </summary>
public static class CreateCaoShuTMPAsset
{
    private const string FontPath = "Assets/Art/Font/CaoShu.ttf";
    private const string OutputPath = "Assets/Art/Font/CaoShu SDF.asset";

    [MenuItem("Tools/生成CaoShu TMP字体资产")]
    public static void Create()
    {
        // 1. 加载源字体
        Font font = AssetDatabase.LoadAssetAtPath<Font>(FontPath);
        if (font == null)
        {
            EditorUtility.DisplayDialog("错误", $"找不到字体文件:\n{FontPath}", "确定");
            return;
        }

        // 2. 已存在则先删除(避免重复生成冲突)
        if (File.Exists(OutputPath))
        {
            AssetDatabase.DeleteAsset(OutputPath);
        }

        // 3. 用 TMP 官方 API 创建动态 SDF 字体资产
        //    动态模式:atlas 按需扩展,不用全量烘焙中文字形
        TMP_FontAsset fontAsset = TMP_FontAsset.CreateFontAsset(
            font,
            samplingPointSize: 90,
            atlasPadding: 9,
            renderMode: GlyphRenderMode.SDFAA,
            atlasWidth: 1024,
            atlasHeight: 1024,
            atlasPopulationMode: AtlasPopulationMode.Dynamic,
            enableMultiAtlasSupport: true);

        if (fontAsset == null)
        {
            EditorUtility.DisplayDialog("错误", "TMP_FontAsset.CreateFontAsset 返回 null", "确定");
            return;
        }

        fontAsset.name = "CaoShu SDF";

        // 4. 先创建字体资产主文件
        AssetDatabase.CreateAsset(fontAsset, OutputPath);

        // 5. 把 atlas 纹理和材质作为子资产保存(动态字体必须,否则材质/纹理引用丢失)
        if (fontAsset.atlasTextures != null && fontAsset.atlasTextures.Length > 0)
        {
            foreach (var tex in fontAsset.atlasTextures)
            {
                if (tex != null) AssetDatabase.AddObjectToAsset(tex, fontAsset);
            }
        }
        if (fontAsset.material != null)
        {
            AssetDatabase.AddObjectToAsset(fontAsset.material, fontAsset);
        }

        // 6. face info 里的源字体引用也要落盘
        fontAsset.atlasPopulationMode = AtlasPopulationMode.Dynamic;

        EditorUtility.SetDirty(fontAsset);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        // 7. 选中生成结果,方便查看
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = fontAsset;

        Debug.Log($"<color=#4CFF8A>[TMP] CaoShu SDF 字体资产生成成功: {OutputPath}</color>");
    }
}
