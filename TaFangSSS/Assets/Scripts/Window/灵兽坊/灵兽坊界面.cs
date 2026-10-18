using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵兽坊界面 : MonoBehaviour
{
    public Button 灵兽Button;
    public Button 孵化Button;
    public TextMeshProUGUI 灵蛋count;
    public Button 减Button;
    public Button 加Button;
    public Slider Slider;
    public TextMeshProUGUI 砸蛋数量;
    public Button 砸蛋Button;
    public TextMeshProUGUI 每道年灵蛋数;
    public Button 性别;
    public Button 品级;
    public Button 血脉;
    public GameObject 性别下拉区域;
    public GameObject 品级下拉区域;
    public GameObject 血脉下拉区域;
    public Button 翻页加;
    public Button 翻页减;
    public TextMeshProUGUI 页数;
    public GameObject 灵兽背包;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品级Text;
    public TextMeshProUGUI 元素text;
    public TextMeshProUGUI 血脉Text;
    public TextMeshProUGUI 阶段;
    public TextMeshProUGUI 介绍;
    public TextMeshProUGUI 最终伤害当前;
    public TextMeshProUGUI 最终伤害最大;
    public Image 最终伤害Image;
    public GameObject 最终伤害无暇;
    public Button 最终伤害洗髓Button;

    public TextMeshProUGUI 暴击伤害当前;
    public TextMeshProUGUI 暴击伤害最大;
    public Image 暴击伤害Image;
    public GameObject 暴击伤害无暇;
    public Button 暴击伤害洗髓Button;
    
    public TextMeshProUGUI 元素伤害当前;
    public TextMeshProUGUI 元素伤害最大;
    public Image 元素伤害Image;
    public GameObject 元素伤害无暇;
    public Button 元素伤害洗髓Button;

    public Button 进化Button;

    private int 当前砸蛋数量 = 0;
    private int 背包页数 = 1;
    public 性别 性别筛选 = global::性别.None;
    public QualityType 品级筛选 = QualityType.None;
    public 血脉Type 血脉筛选 = 血脉Type.None;

    public void Show灵蛋信息()
    {
        灵蛋count.text = "X" + PlayerData.S.灵兽蛋数量;
        Slider.maxValue = PlayerData.S.灵兽蛋数量;
        Slider.value = 当前砸蛋数量;
        砸蛋数量.text=当前砸蛋数量.ToString();
        每道年灵蛋数.text = 道场Config.Get灵兽蛋速度().ToString();
    }

    public void Show灵兽背包()
    {
        foreach (Transform item in 灵兽背包.transform)
        {
            Destroy(item.gameObject);
        }
        
    }

}
