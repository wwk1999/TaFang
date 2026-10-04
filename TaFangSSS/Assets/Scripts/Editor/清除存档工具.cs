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
    /// 项目内存档源文件：Assets/存档/TaFangStorePlaytest1.json
    /// </summary>
    private static string 源存档路径 => Path.Combine(Application.dataPath, "存档", 主存档文件);

    [MenuItem("Tool/替换存档")]
    public static void 替换存档()
    {
        string 目标存档路径 = Path.Combine(Application.persistentDataPath, 主存档文件);

        if (!File.Exists(源存档路径))
        {
            EditorUtility.DisplayDialog("替换存档", $"未找到源存档文件:\n\n{源存档路径}", "确定");
            return;
        }

        bool 确认 = EditorUtility.DisplayDialog(
            "替换存档确认",
            $"即将用项目内的存档覆盖本机游戏存档，此操作不可恢复:\n\n源: {源存档路径}\n目标: {目标存档路径}",
            "替换存档", "取消");
        if (!确认) return;

        try
        {
            File.Copy(源存档路径, 目标存档路径, true);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"替换存档失败: {e.Message}");
            EditorUtility.DisplayDialog("替换存档", "替换存档失败:\n" + e.Message, "确定");
            return;
        }

        Debug.Log($"替换存档完成: {源存档路径} -> {目标存档路径}");

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
