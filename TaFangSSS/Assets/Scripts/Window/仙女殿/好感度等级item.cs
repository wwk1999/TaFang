using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 好感度等级item : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI 等级Text;
    public TextMeshProUGUI 效果Text;

    [NonSerialized] public int 等级;
    [NonSerialized] public 仙子属性 属性;
    [NonSerialized] public bool 是否满足等级;

    public void SetItem()
    {
        icon.sprite = 是否满足等级 ? ResourcesConfig.标签亮 : ResourcesConfig.标签暗;

        string 描述 = string.Join("、", 阴阳殿Config.Get仙子属性描述(属性));
        if (效果Text != null)
        {
            等级Text.text = 等级 + "级";
            效果Text.text = 描述;
        }
        else
        {
            等级Text.text = 等级 + "级  " + 描述;
        }
    }
}
