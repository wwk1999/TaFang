using UnityEditor;
using UnityEngine;
using System.IO;

/// <summary>
/// 编辑器工具：清除游戏存档
/// </summary>
public static class ClearSaveTool
{
    // 存档路径（与你的 SavePath 保持一致）
    private static string SavePath => Path.Combine(Application.persistentDataPath, "TaFangStoreShiWan1.json");

    [MenuItem("Tools/清除存档")]
    private static void ClearSave()
    {
        // 弹出确认对话框
        bool shouldDelete = EditorUtility.DisplayDialog(
            "清除存档",
            $"确定要删除存档吗？\n\n路径：{SavePath}\n\n此操作不可撤销。",
            "确认删除",
            "取消"
        );

        if (!shouldDelete)
            return;

        // 检查文件是否存在
        if (File.Exists(SavePath))
        {
            try
            {
                File.Delete(SavePath);
                Debug.Log($"✅ 存档已删除：{SavePath}");
                
                // 可选：显示一个提示对话框
                EditorUtility.DisplayDialog("清除存档", "存档已成功删除。", "好的");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"❌ 删除存档失败：{e.Message}");
                EditorUtility.DisplayDialog("清除存档", $"删除失败：{e.Message}", "确定");
            }
        }
        else
        {
            Debug.LogWarning($"⚠️ 存档不存在，无需删除：{SavePath}");
            EditorUtility.DisplayDialog("清除存档", "存档文件不存在，无需删除。", "确定");
        }
        
        // 刷新 Project 窗口（可选，让变动立即显示）
        AssetDatabase.Refresh();
    }
}