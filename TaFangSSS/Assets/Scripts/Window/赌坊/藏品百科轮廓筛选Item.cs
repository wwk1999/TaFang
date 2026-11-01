using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>藏品百科轮廓（尺寸）筛选按钮：显示尺寸预览，点击切换选中</summary>
public class 藏品百科轮廓筛选Item : MonoBehaviour
{
    public Button btn;
    public Image gou;

    [NonSerialized] public 藏品尺寸Type 尺寸;
    private Action<藏品尺寸Type> 点击回调;

    public void SetItem(藏品尺寸Type size, Action<藏品尺寸Type> onClick)
    {
        尺寸 = size;
        点击回调 = onClick;

       
        if (btn != null)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => 点击回调?.Invoke(尺寸));
        }
    }

    public void SetSelected(bool selected)
    {
        if (gou != null) gou.gameObject.SetActive(selected);
    }
}
