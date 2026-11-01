using TMPro;
using UnityEngine;

/// <summary>赌坊道具信息条目：展示使用信息类道具后得到的仓库信息</summary>
public class 道具信息Item : MonoBehaviour
{
    public TextMeshProUGUI content;

    public void SetItem(string text)
    {
        if (content != null) content.text = text;
    }
}
