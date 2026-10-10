using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

/// <summary>
/// 批量把 ttf 文件夹里的字体生成为 TMP 动态 SDF 字体资产，并为每个字体生成一个「数字」材质预设。
/// 参数与 CaoShu/思源宋体 生成工具一致：90px 采样 / padding 9 / SDFAA / 1024² / Dynamic + 多图集。
///
/// 可重复执行（换字体后直接再跑一次菜单即可）：
/// - ttf 内容/文件名没变 → 删旧字体资产重新生成（同 CaoShu 工具流程），材质保留并重新接线图集
/// - 新增 ttf → 按文件名各生成一套（资产名 = 文件名 + " SDF"）
/// - 移除了某个 ttf → 它的旧资产不自动清理，需要手动删除
///
/// 材质命名遵循 TMP 预设规则「字体名 SDF - 数字」，会自动出现在所有用该字体文本的
/// Material Preset 下拉框里；材质已存在时只重新接线 _MainTex，保留你手动调过的发光/描边参数。
/// </summary>
public static class GenerateTtfFolderTMPAssets
{
    private const string Ttf文件夹 = "Assets/Art/Font/ttf";
    private const string 预设名 = "数字";

    [MenuItem("Tools/生成ttf字体TMP资产")]
    public static void 生成()
    {
        if (!Directory.Exists(Ttf文件夹))
        {
            EditorUtility.DisplayDialog("错误", $"文件夹不存在:\n{Ttf文件夹}", "确定");
            return;
        }

        var 字体文件 = Directory.GetFiles(Ttf文件夹, "*.*")
            .Select(p => p.Replace('\\', '/'))
            .Where(p =>
            {
                string ext = Path.GetExtension(p).ToLowerInvariant();
                return ext == ".ttf" || ext == ".otf";
            })
            .ToList();

        if (字体文件.Count == 0)
        {
            EditorUtility.DisplayDialog("提示", $"ttf 文件夹里没有字体文件:\n{Ttf文件夹}", "确定");
            return;
        }

        var 报告 = new List<string>();
        var 失败 = new List<string>();
        TMP_FontAsset 最后生成的字体 = null;

        foreach (var 路径 in 字体文件)
        {
            string 字体名 = Path.GetFileNameWithoutExtension(路径);
            string 资产名 = 字体名 + " SDF";
            string 资产路径 = $"{Ttf文件夹}/{资产名}.asset";

            Font font = AssetDatabase.LoadAssetAtPath<Font>(路径);
            if (font == null)
            {
                失败.Add($"{字体名}: 源字体加载失败");
                continue;
            }

            // 1. 已存在则先删除（避免重复生成冲突，同 CaoShu 工具流程）
            if (File.Exists(资产路径))
            {
                AssetDatabase.DeleteAsset(资产路径);
            }

            // 2. 用 TMP 官方 API 创建动态 SDF 字体资产（动态模式：atlas 按需扩展，不用全量烘焙中文字形）
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
                失败.Add($"{字体名}: TMP_FontAsset.CreateFontAsset 返回 null");
                continue;
            }

            fontAsset.name = 资产名;

            // 3. 创建字体资产主文件
            AssetDatabase.CreateAsset(fontAsset, 资产路径);

            // 4. atlas 纹理和材质作为子资产保存（动态字体必须，否则材质/纹理引用丢失）
            if (fontAsset.atlasTextures != null)
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

            fontAsset.atlasPopulationMode = AtlasPopulationMode.Dynamic;
            EditorUtility.SetDirty(fontAsset);

            // 5. 材质预设：存在则复用（保留手动调过的发光/描边参数），只重新接线图集；
            //    不存在则从字体默认材质克隆一份（图集引用直接指向本次生成的 tmp 资产）
            string 材质名 = $"{资产名} - {预设名}";
            string 材质路径 = $"{Ttf文件夹}/{材质名}.mat";
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(材质路径);
            bool 新建材质 = false;
            if (mat == null)
            {
                mat = new Material(fontAsset.material) { name = 材质名 };
                AssetDatabase.CreateAsset(mat, 材质路径);
                新建材质 = true;
            }
            mat.SetTexture(ShaderUtilities.ID_MainTex, fontAsset.atlasTexture);
            mat.SetColor(ShaderUtilities.ID_FaceColor, Color.white);
            EditorUtility.SetDirty(mat);

            报告.Add($"[{字体名}] → {资产名}  +  {材质名}（{(新建材质 ? "新建" : "复用并重新接线")}）");
            最后生成的字体 = fontAsset;
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        if (报告.Count > 0)
        {
            Debug.Log("<color=#4CFF8A>[TMP] ttf 文件夹生成完成：\n" + string.Join("\n", 报告) + "</color>");
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = 最后生成的字体;
        }
        if (失败.Count > 0)
        {
            Debug.LogError("[TMP] 以下字体生成失败：\n" + string.Join("\n", 失败));
        }

        string 汇总 = 报告.Count > 0 ? string.Join("\n", 报告) : "没有成功项";
        if (失败.Count > 0) 汇总 += "\n\n失败：\n" + string.Join("\n", 失败);
        EditorUtility.DisplayDialog("完成", 汇总, "确定");
    }
}
