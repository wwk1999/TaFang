#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 顶部 Tool 菜单：一键清除本机存档文件，便于开发测试时重置进度。
/// </summary>
public static class 清除存档工具
{
    private const string 主存档文件 = "TaFangStorePlaytest1.json";
    private const string 显示设置存档文件 = "TaFangStore.json";

    /// <summary>
    /// 项目内存档目录：Assets/存档/
    /// 用户只需把导出的存档（如 塔防刷刷刷存档_叶凡_20261127_160410.json）丢进该目录，
    /// 无需手动改名为 TaFangStorePlaytest1.json
    /// </summary>
    private static string 存档目录 => Path.Combine(Application.dataPath, "存档");

    /// <summary>
    /// 自动查找待替换的存档：优先使用标准命名的源存档，
    /// 否则在存档目录中挑选最新的导出存档（.json，排除显示设置存档）
    /// </summary>
    private static string 查找待替换存档()
    {
        if (!Directory.Exists(存档目录)) return null;

        string 标准路径 = Path.Combine(存档目录, 主存档文件);
        if (File.Exists(标准路径)) return 标准路径;

        string 最新存档 = null;
        foreach (string 文件 in Directory.GetFiles(存档目录, "*.json"))
        {
            if (Path.GetFileName(文件) == 显示设置存档文件) continue;
            if (最新存档 == null || File.GetLastWriteTime(文件) > File.GetLastWriteTime(最新存档))
            {
                最新存档 = 文件;
            }
        }
        return 最新存档;
    }

    [MenuItem("Tool/替换存档")]
    public static void 替换存档()
    {
        string 目标存档路径 = Path.Combine(Application.persistentDataPath, 主存档文件);
        string 源存档路径 = 查找待替换存档();

        if (源存档路径 == null)
        {
            EditorUtility.DisplayDialog(
                "替换存档",
                $"未在存档目录中找到可替换的存档文件。\n\n请把存档（如 塔防刷刷刷存档_xxx.json）放到:\n{存档目录}",
                "确定");
            return;
        }

        bool 确认 = EditorUtility.DisplayDialog(
            "替换存档确认",
            $"即将把下列存档自动改名为 {主存档文件} 并覆盖本机游戏存档，此操作不可恢复:\n\n" +
            $"源: {Path.GetFileName(源存档路径)}\n目标: {目标存档路径}",
            "替换存档", "取消");
        if (!确认) return;

        try
        {
            File.Copy(源存档路径, 目标存档路径, true);

            // 清理残留的临时文件与旧备份，避免主档异常时回退到替换前的旧进度
            string 临时文件 = 目标存档路径 + ".tmp";
            string 备份文件 = 目标存档路径 + ".bak";
            if (File.Exists(临时文件)) File.Delete(临时文件);
            if (File.Exists(备份文件)) File.Delete(备份文件);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"替换存档失败: {e.Message}");
            EditorUtility.DisplayDialog("替换存档", "替换存档失败:\n" + e.Message, "确定");
            return;
        }

        Debug.Log($"替换存档完成: {源存档路径} -> {目标存档路径}（已自动改名）");

        // 游戏运行中 StoreController 仍持有内存中的旧数据，自动保存会把旧数据写回去，
        // 导致替换无效。退出播放模式以保证替换生效。
        if (Application.isPlaying)
        {
            EditorApplication.isPlaying = false;
            Debug.Log("已退出播放模式以防止运行中的单例自动重新保存。");
        }
        else
        {
            EditorUtility.DisplayDialog("替换存档", "替换存档完成。", "确定");
        }
    }

    [MenuItem("Tool/清除存档")]
    public static void 清除存档()
    {
        string dir = Application.persistentDataPath;
        // 主档之外还要清 .bak 备份和 .tmp 临时文件：
        // 读档顺序是 主档 → .bak → 新档，只删主档的话下次启动会从 .bak 复活进度
        string[] 待删文件 = { 主存档文件, 主存档文件 + ".bak", 主存档文件 + ".tmp", 显示设置存档文件 };

        string 文件列表 = "";
        foreach (string 文件名 in 待删文件)
        {
            if (File.Exists(Path.Combine(dir, 文件名))) 文件列表 += "  • " + 文件名 + "\n";
        }

        if (文件列表 == "")
        {
            EditorUtility.DisplayDialog("清除存档", "未找到任何存档文件，无需清除。\n\n存档目录:\n" + dir, "确定");
            return;
        }

        bool 确认 = EditorUtility.DisplayDialog(
            "清除存档确认",
            "即将删除以下存档文件，此操作不可恢复:\n\n" + 文件列表 + "\n存档目录:\n" + dir,
            "清除存档", "取消");

        if (!确认) return;

        try
        {
            foreach (string 文件名 in 待删文件)
            {
                string 路径 = Path.Combine(dir, 文件名);
                if (File.Exists(路径)) File.Delete(路径);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"清除存档失败: {e.Message}");
            EditorUtility.DisplayDialog("清除存档", "清除存档失败:\n" + e.Message, "确定");
            return;
        }

        Debug.Log("存档清除完成。存档目录: " + dir);

        // 游戏运行中 PlayerData/StoreController 仍持有内存数据，StoreController 的自动保存
        // 会把旧数据重新写回磁盘，导致清除无效。退出播放模式以保证清除生效。
        if (Application.isPlaying)
        {
            EditorApplication.isPlaying = false;
            Debug.Log("已退出播放模式以防止运行中的单例自动重新保存。");
        }
        else
        {
            EditorUtility.DisplayDialog("清除存档", "存档清除完成。", "确定");
        }
    }
}
#endif
