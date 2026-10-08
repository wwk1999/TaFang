using TMPro;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 把"思源宋体Heavy SDF 数字"材质变成思源宋体Heavy 的合法 Material Preset：
/// 1. 改名为"思源宋体Heavy SDF - 数字"（TMP 靠"字体名 - 预设名"命名规则识别预设，
///    改完它会自动出现在所有用该字体的 TMP 文本的 Material Preset 下拉框里）
/// 2. _MainTex 指回本字体的图集（从别的字体复制来的材质，默认指着别人的图集）
/// 3. FaceColor 置白（黑色会让组件颜色永远不生效）
/// 注意：不改动字体资产的默认材质（内嵌材质保持原样，所有文本默认行为不变）。
/// </summary>
public class WireSourceHanSerifHeavyNumberMaterial
{
    private const string 字体路径 = "Assets/Art/Font/思源宋体Heavy SDF.asset";
    private const string 材质旧路径 = "Assets/Art/Font/思源宋体Heavy SDF 数字.mat";
    private const string 材质新路径 = "Assets/Art/Font/思源宋体Heavy SDF - 数字.mat";

    [MenuItem("Tools/思源宋体Heavy数字材质接线")]
    public static void 接线()
    {
        var fontAsset = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(字体路径);
        if (fontAsset == null)
        {
            EditorUtility.DisplayDialog("接线失败", $"字体没找到: {字体路径}", "确定");
            return;
        }

        // 材质可能还没改名，也可能已经改过（重复执行工具的情况）
        var mat = AssetDatabase.LoadAssetAtPath<Material>(材质旧路径)
                   ?? AssetDatabase.LoadAssetAtPath<Material>(材质新路径);
        if (mat == null)
        {
            EditorUtility.DisplayDialog("接线失败",
                $"材质没找到: {材质旧路径}", "确定");
            return;
        }

        // 1. 改成 TMP 预设的标准命名（RenameAsset 自动带着 .meta 改名，GUID 不变，引用不丢）
        if (mat.name != "思源宋体Heavy SDF - 数字")
        {
            var error = AssetDatabase.RenameAsset(材质旧路径, "思源宋体Heavy SDF - 数字");
            if (!string.IsNullOrEmpty(error))
            {
                EditorUtility.DisplayDialog("改名失败", error, "确定");
                return;
            }
        }

        // 2. 图集指回本字体（动态加字时光栅化进 atlasTextures[0]，材质立即可见）
        mat.SetTexture(ShaderUtilities.ID_MainTex, fontAsset.atlasTexture);

        // 3. Face Color 白色中性值：最终颜色 = 字形 × FaceColor × 组件颜色
        mat.SetColor(ShaderUtilities.ID_FaceColor, Color.white);

        EditorUtility.SetDirty(mat);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"接线完成: [{mat.name}] 已成为 [{fontAsset.name}] 的 Material Preset，" +
                  "去 TMP 文本的 Material Preset 下拉框里选它。默认材质未改动。");
    }
}
