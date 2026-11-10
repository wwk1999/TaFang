using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 丹药信息 : MonoBehaviour
{
    public TextMeshProUGUI name;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI 类型;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI 炼制等级;
    public TextMeshProUGUI 增加经验;
    public TextMeshProUGUI 需要时间;
    public TextMeshProUGUI 功效;
    public TextMeshProUGUI 灵药1;
    public TextMeshProUGUI 灵药2;
    public TextMeshProUGUI 灵药3;
    public TextMeshProUGUI 灵药4;
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public int 阶数 = 1;

    public void SetItem()
    {
        // 阶数决定材料品质和icon底色
        QualityType 材料品质 = 丹药Config.Get材料品质(阶数);
        丹药类型 丹药类型 = 丹药Config.丹药类型Dic[丹药Type];
        bool 是造化丹药 = 丹药类型 == 丹药类型.造化丹药;

        // 名称：类型 + 阶数
        name.text = $"{丹药Config.丹药名Dic[丹药Type]}·{阶数}阶";
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(材料品质);
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(材料品质);

        // 丹药icon按阶数取新图集（1阶=子图0，16阶=子图15）
        icon.sprite = ResourcesConfig.Get丹药icon(丹药Type, 阶数);

        类型.text = 丹药Config.丹药类型String[丹药类型];
        品质.text = "随机"; // 炼制完成后品质才随机确定
        功效.text = 丹药Config.Get丹药Desc(丹药Type, QualityType.黄品); // 默认按黄品显示功效说明

        // 炼制要求：按阶数查
        long 等级要求 = 丹药Config.Get炼丹等级要求(丹药Type, 阶数);
        float 经验 = 丹药Config.Get炼制经验(丹药Type, 阶数);
        float 时间秒 = 丹药Config.Get炼制时间(丹药Type, 阶数);
        炼制等级.text = $"Lv{等级要求}";
        增加经验.text = PlayerData.S.格式化数字(经验);
        需要时间.text = $"{时间秒 / 属性config.每年秒数:F2} 道年";

        // 材料显示
        if (是造化丹药)
        {
            // 造化丹药：显示灵植
            if (丹药Config.造化丹药灵植Dic.TryGetValue(材料品质, out var 灵植Types))
            {
                for (int i = 0; i < 4; i++)
                {
                    var 文本引用 = i switch { 0 => 灵药1, 1 => 灵药2, 2 => 灵药3, _ => 灵药4 };
                    if (i < 灵植Types.Count)
                        文本引用.text = $"{灵植园Config.灵植名[灵植Types[i]]} ×{丹药Config.Get单种材料数量(阶数)}";
                    else
                        文本引用.text = "";
                }
            }
            else
            {
                灵药1.text = 灵药2.text = 灵药3.text = 灵药4.text = "";
            }
        }
        else
        {
            // 普通丹药：显示灵药 + 品质 + 数量
            var 灵药list = 丹药Config.丹方Dic[丹药Type];
            for (int i = 0; i < 4; i++)
            {
                var 文本引用 = i switch { 0 => 灵药1, 1 => 灵药2, 2 => 灵药3, _ => 灵药4 };
                if (i < 灵药list.Count)
                    文本引用.text = $"{PropConfig.QualityNameDic[材料品质]}{丹药Config.灵药名Dic[灵药list[i]]} ×{丹药Config.Get单种材料数量(阶数)}";
                else
                    文本引用.text = "";
            }
        }
    }
}
