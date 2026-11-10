using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 丹方信息弹窗 : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质; // 显示炼丹等级要求
    public TextMeshProUGUI desc;
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public int 阶数 = 1;

    public void SetItem()
    {
        QualityType 材料品质 = 丹药Config.Get材料品质(阶数);
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(材料品质);
        // 丹方icon：按阶数对应的材料品质取
        icon.sprite = ResourcesConfig.Get丹药icon(丹药Type, 材料品质);
        name.text = $"{丹药Config.丹方名Dic[丹药Type]}·{阶数}阶";
        品质.text = $"炼丹等级Lv{丹药Config.Get炼丹等级要求(丹药Type, 阶数)}";
        desc.text = 丹药Config.丹方DescDic[丹药Type];
    }
}
