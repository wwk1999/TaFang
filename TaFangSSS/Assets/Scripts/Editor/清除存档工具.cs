#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 顶部 Tool 菜单：一键清除本机存档文件，便于开发测试时重置进度。
/// </summary>
public static class 清除存档工具
{
    private const string 主存档文件 = "TaFangStoreShiWan1.json";
    private const string 显示设置存档文件 = "TaFangStore.json";

    [MenuItem("Tool/清除存档")]
    public static void 清除存档()
    {
        string dir = Application.persistentDataPath;
        string 主存档路径 = Path.Combine(dir, 主存档文件);
        string 显示设置路径 = Path.Combine(dir, 显示设置存档文件);

        bool 主存档存在 = File.Exists(主存档路径);
        bool 显示设置存在 = File.Exists(显示设置路径);

        if (!主存档存在 && !显示设置存在)
        {
            EditorUtility.DisplayDialog("清除存档", "未找到任何存档文件，无需清除。\n\n存档目录:\n" + dir, "确定");
            return;
        }

        string 文件列表 = "";
        if (主存档存在) 文件列表 += "  • " + 主存档文件 + "\n";
        if (显示设置存在) 文件列表 += "  • " + 显示设置存档文件 + "\n";

        bool 确认 = EditorUtility.DisplayDialog(
            "清除存档确认",
            "即将删除以下存档文件，此操作不可恢复:\n\n" + 文件列表 + "\n存档目录:\n" + dir,
            "清除存档", "取消");

        if (!确认) return;

        try
        {
            if (主存档存在) File.Delete(主存档路径);
            if (显示设置存在) File.Delete(显示设置路径);
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
