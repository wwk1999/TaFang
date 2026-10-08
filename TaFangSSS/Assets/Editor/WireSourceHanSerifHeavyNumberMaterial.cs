using TMPro;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 把"思源宋体Heavy SDF 数字"材质接成思源宋体Heavy 字体资产的默认材质。
/// 在 Unity 内存中操作再落盘，避免手改资产文件被编辑器内存态覆盖。
/// </summary>
public class WireSourceHanSerifHeavyNumberMaterial
{
    private const string 字体路径 = "Assets/Art/Font/思源宋体Heavy SDF.asset";
    private const string 材质路径 = "Assets/Art/Font/思源宋体Heavy SDF 数字.mat";

    [MenuItem("Tools/思源宋体Heavy数字材质接线")]
    public static void 接线()
    {
        var fontAsset = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(字体路径);
        var mat = AssetDatabase.LoadAssetAtPath<Material>(材质路径);

        if (fontAsset == null || mat == null)
        {
            EditorUtility.DisplayDialog("接线失败",
                $"字体或材质没找到。\n字体: {字体路径}\n材质: {材质路径}", "确定");
            return;
        }

        // 1. 数字材质的 _MainTex 指向字体自己的图集（复制来的材质原本指着别的字体的图集）
        mat.SetTexture(ShaderUtilities.ID_MainTex, fontAsset.atlasTexture);

        // 2. Face Color 设为白色中性值：最终颜色 = 字形 × FaceColor × 组件颜色，
        //    黑色 FaceColor 会让组件颜色永远不生效（只能黑）
        mat.SetColor(ShaderUtilities.ID_FaceColor, Color.white);

        // 3. 字体资产的默认材质换成数字材质，所有用这个字体的文本自动带这套风格
        fontAsset.material = mat;

        EditorUtility.SetDirty(mat);
        EditorUtility.SetDirty(fontAsset);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"接线完成: 字体[{fontAsset.name}] 默认材质 → [{mat.name}]，" +
                  $"图集已指向本字体，FaceColor 已置白。");
    }
}
