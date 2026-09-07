using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 批量开启贴图 Crunch 压缩 + 可选调整 Max Size
/// 菜单: Tools / 批量贴图压缩
/// 适配 Unity 2022.3 LTS
/// </summary>
public static class TextureCrunchBatcher
{
    // 需要跳过的目录(第三方插件/模板资源)
    static readonly string[] SkipFolders =
    {
        "TextMesh Pro",
        "DOTween",
        "SuperScrollView",
        "Spine",
        "Spine Examples",
    };

    [MenuItem("Tools/批量贴图压缩/开启 Crunch(所有贴图)")]
    public static void EnableCrunchAll()
    {
        EnableCrunch(false, false, 2048);
    }

    [MenuItem("Tools/批量贴图压缩/开启 Crunch + MaxSize 2048")]
    public static void EnableCrunchMax2048()
    {
        EnableCrunch(true, false, 2048);
    }

    [MenuItem("Tools/批量贴图压缩/开启 Crunch + MaxSize 1024")]
    public static void EnableCrunchMax1024()
    {
        EnableCrunch(true, false, 1024);
    }

    [MenuItem("Tools/批量贴图压缩/开启 Crunch + MaxSize 512(谨慎)")]
    public static void EnableCrunchMax512()
    {
        EnableCrunch(true, false, 512);
    }

    [MenuItem("Tools/批量贴图压缩/关闭 Crunch(还原)")]
    public static void DisableCrunchAll()
    {
        EnableCrunch(false, true, 2048);
    }

    /// <summary>
    /// 核心逻辑:遍历所有 Texture,对每个平台开启/关闭 Crunch
    /// Unity 2022.3 兼容:用 TextureImporterSettings 设置 Default,
    /// 用 TextureImporterPlatformSettings.SetPlatformTextureSettings 设置各平台
    /// </summary>
    static void EnableCrunch(bool setMaxSize, bool disable, int maxSize)
    {
        var guids = AssetDatabase.FindAssets("t:Texture", new[] { "Assets" });
        int total = guids.Length;
        int changed = 0;
        int skipped = 0;
        float beforeMB = 0;

        try
        {
            for (int i = 0; i < total; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                var imp = AssetImporter.GetAtPath(path) as TextureImporter;
                if (imp == null) { skipped++; continue; }

                // 跳过第三方文件夹
                bool skip = false;
                foreach (var f in SkipFolders)
                {
                    if (path.Contains("/" + f + "/")) { skip = true; break; }
                }
                if (skip) { skipped++; continue; }

                beforeMB += new FileInfo(path).Length / 1024f / 1024f;

                bool modified = false;

                // === 处理 Default 平台(Unity 2022.3 用 TextureImporterSettings) ===
                var settings = new TextureImporterSettings();
                imp.ReadTextureSettings(settings);
                // Default 没有 crunchedCompression 字段,Crunch 只在具体平台上设
                // 但 Default 的 maxTextureSize 可以在这里改
                if (setMaxSize && settings.maxTextureSize > maxSize)
                {
                    settings.maxTextureSize = maxSize;
                    modified = true;
                }
                if (modified) imp.SetTextureSettings(settings);

                // === 处理各具体平台 ===
                // Unity 2022.3: GetPlatformTextureSettings 返回的是 struct copy,
                // 改完用 SetPlatformTextureSettings 写回去(无论 overridden 与否)
                string[] platforms = { "Standalone", "Android", "WebGL", "iPhone" };
                foreach (var platName in platforms)
                {
                    var plat = imp.GetPlatformTextureSettings(platName);

                    bool platMod = false;
                    // Max Size 同时作用于各平台
                    if (setMaxSize && plat.maxTextureSize > maxSize)
                    {
                        plat.maxTextureSize = maxSize;
                        platMod = true;
                    }
                    // Crunch:如果该平台尚未 override,先强制 override 再改
                    if (!plat.overridden)
                    {
                        plat.overridden = true;
                        platMod = true;
                    }
                    if (disable)
                    {
                        if (plat.crunchedCompression) { plat.crunchedCompression = false; platMod = true; }
                    }
                    else
                    {
                        if (!plat.crunchedCompression) { plat.crunchedCompression = true; platMod = true; }
                    }

                    if (platMod)
                    {
                        imp.SetPlatformTextureSettings(plat);
                        modified = true;
                    }
                }

                if (modified)
                {
                    imp.SaveAndReimport();
                    changed++;
                }

                EditorUtility.DisplayProgressBar(
                    disable ? "关闭 Crunch 压缩..." : "开启 Crunch 压缩...",
                    $"[{i + 1}/{total}] {Path.GetFileName(path)}",
                    (float)(i + 1) / total);
            }
        }
        finally
        {
            EditorUtility.ClearProgressBar();
        }

        AssetDatabase.Refresh();

        string action = disable ? "关闭" : "开启";
        string sizeInfo = setMaxSize ? $"(含 Max Size → {maxSize})" : "";
        Debug.Log($"[TextureCrunchBatcher] {action} Crunch 完成{sizeInfo}: " +
                  $"共 {total} 张,修改 {changed} 张,跳过 {skipped} 张");
        Debug.Log($"[TextureCrunchBatcher] 源文件总大小 ≈ {beforeMB:F1} MB, " +
                  $"预估 Crunch 后包体 ≈ {beforeMB * 0.35f:F1} MB(Crunch 约 35% 比率)");

        EditorUtility.DisplayDialog("批量贴图压缩",
            $"{action} Crunch 完成!\n\n" +
            $"共处理: {total} 张\n" +
            $"修改: {changed} 张\n" +
            $"跳过: {skipped} 张(第三方文件夹)\n\n" +
            $"源文件 ≈ {beforeMB:F0} MB → 预估包体 ≈ {beforeMB * 0.35f:F0} MB\n\n" +
            $"请等待 Unity 重新导入完成后再 Build。",
            "好的");
    }

    [MenuItem("Tools/批量贴图压缩/统计当前 Crunch 开启率")]
    public static void ReportCrunchStats()
    {
        var guids = AssetDatabase.FindAssets("t:Texture", new[] { "Assets" });
        int total = 0, crunchOn = 0, crunchOff = 0, skipped = 0;

        foreach (var g in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(g);
            var imp = AssetImporter.GetAtPath(path) as TextureImporter;
            if (imp == null) { skipped++; continue; }

            bool skip = false;
            foreach (var f in SkipFolders)
                if (path.Contains("/" + f + "/")) { skip = true; break; }
            if (skip) { skipped++; continue; }

            total++;
            // 只要任一具体平台开了 Crunch 就算开
            bool on = false;
            string[] platforms = { "Standalone", "Android", "WebGL", "iPhone" };
            foreach (var pn in platforms)
            {
                var p = imp.GetPlatformTextureSettings(pn);
                if (p.crunchedCompression) { on = true; break; }
            }
            if (on) crunchOn++; else crunchOff++;
        }

        float pct = total > 0 ? crunchOn * 100f / total : 0;
        string msg = $"贴图 Crunch 开启率:\n\n" +
                     $"总计: {total} 张\n" +
                     $"已开启: {crunchOn} 张 ({pct:F1}%)\n" +
                     $"未开启: {crunchOff} 张 ({100 - pct:F1}%)\n" +
                     $"跳过(第三方): {skipped} 张";

        Debug.Log($"[TextureCrunchBatcher] {msg}");
        EditorUtility.DisplayDialog("Crunch 统计", msg, "好的");
    }
}
