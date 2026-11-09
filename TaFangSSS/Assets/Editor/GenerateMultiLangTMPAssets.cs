using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

/// <summary>
/// 批量把「繁体中文 / 日文 / 韩文 / 泰文」字体生成为 TMP 动态 SDF 字体资产。
/// 生成方式与项目现有 GenerateTtfFolderTMPAssets 一致（Dynamic + MultiAtlas + SDFAA），
/// 对 CJK 大字符集是唯一可行方案：运行时按需把字形写入 atlas，不一次性烘焙全量字符。
///
/// 菜单：Tools/生成多语言字体TMP资产
/// 可重复执行：已存在的同名资产会被删除后重新生成，材质预设保留并重新接线 atlas。
///
/// 生成后：
/// - 每个语言文件夹下会得到 「{字体名} SDF.asset」 及其材质预设
/// - 在本地化管理器里按语言切换 TMP_Text.font 时，直接引用这些 asset 即可
/// </summary>
public static class GenerateMultiLangTMPAssets
{
    // 语言 -> 字体文件夹 的映射。新增语言只要在这里加一行即可。
    private static readonly (string LangName, string Folder)[] 语言文件夹 = new (string, string)[]
    {
        ("繁体中文", "Assets/Art/Font/繁体中文"),
        ("日文",     "Assets/Art/Font/日文"),
        ("韩文",     "Assets/Art/Font/韩文"),
        ("泰文",     "Assets/Art/Font/泰文"),
    };

    // 生成参数（与现有中文字体生成工具保持一致）
    private const int 采样点数 = 90;
    private const int AtlasPadding = 9;
    private const GlyphRenderMode 渲染模式 = GlyphRenderMode.SDFAA;
    private const int Atlas宽高 = 1024;

    [MenuItem("Tools/生成多语言字体TMP资产")]
    public static void 生成()
    {
        var 报告 = new List<string>();
        var 失败 = new List<string>();
        TMP_FontAsset 最后生成的 = null;

        foreach (var (langName, folder) in 语言文件夹)
        {
            if (!Directory.Exists(folder))
            {
                失败.Add($"[{langName}] 文件夹不存在: {folder}");
                continue;
            }

            var 字体文件 = Directory.GetFiles(folder, "*.*")
                .Select(p => p.Replace('\\', '/'))
                .Where(p =>
                {
                    string ext = Path.GetExtension(p).ToLowerInvariant();
                    return ext == ".ttf" || ext == ".otf";
                })
                .ToList();

            if (字体文件.Count == 0)
            {
                失败.Add($"[{langName}] 没有找到 ttf/otf 字体");
                continue;
            }

            foreach (var 路径 in 字体文件)
            {
                string 字体名 = Path.GetFileNameWithoutExtension(路径);
                string 资产名 = 字体名 + " SDF";
                string 资产路径 = $"{folder}/{资产名}.asset";

                Font font = AssetDatabase.LoadAssetAtPath<Font>(路径);
                if (font == null)
                {
                    失败.Add($"[{langName}] {字体名}: 源字体加载失败");
                    continue;
                }

                // 1. 已存在则删除后重建（避免残留 atlas/材质引用错乱）
                if (File.Exists(资产路径))
                {
                    AssetDatabase.DeleteAsset(资产路径);
                }

                // 2. 创建动态 SDF 字体资产
                //    Dynamic + MultiAtlas：CJK 字符量大，必须运行时按需填充字形
                TMP_FontAsset fontAsset = TMP_FontAsset.CreateFontAsset(
                    font,
                    samplingPointSize: 采样点数,
                    atlasPadding: AtlasPadding,
                    renderMode: 渲染模式,
                    atlasWidth: Atlas宽高,
                    atlasHeight: Atlas宽高,
                    atlasPopulationMode: AtlasPopulationMode.Dynamic,
                    enableMultiAtlasSupport: true);

                if (fontAsset == null)
                {
                    失败.Add($"[{langName}] {字体名}: CreateFontAsset 返回 null");
                    continue;
                }

                fontAsset.name = 资产名;

                // 3. 保存主资产
                AssetDatabase.CreateAsset(fontAsset, 资产路径);

                // 4. atlas 纹理与材质作为子资产保存（动态字体必须，否则引用丢失）
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

                报告.Add($"[{langName}] {字体名} -> {资产名}");
                最后生成的 = fontAsset;
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        if (报告.Count > 0)
        {
            Debug.Log("<color=#4CFF8A>[多语言字体] 生成完成：\n" + string.Join("\n", 报告) + "</color>");
            if (最后生成的 != null)
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = 最后生成的;
            }
        }
        if (失败.Count > 0)
        {
            Debug.LogError("[多语言字体] 以下项失败：\n" + string.Join("\n", 失败));
        }

        string 汇总 = 报告.Count > 0 ? string.Join("\n", 报告) : "没有成功项";
        if (失败.Count > 0) 汇总 += "\n\n失败：\n" + string.Join("\n", 失败);
        EditorUtility.DisplayDialog("多语言字体生成", 汇总, "确定");
    }
}
