using System.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class 法器材料分解弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI 获得粉尘;
    public TextMeshProUGUI 数量;

    public Slider 数量Slider;
    public Button 分解按钮;
    private int count=1;
    [NonSerialized] public PropType PropType;
    
    private void Start()
    {
        分解按钮.onClick.AddListener(() =>
        {
            PlayerData.S.PropListDic[PropType.法器粉尘] += 法器Config.法器材料分解粉尘Dic[PropConfig.PropQualityDic[PropType]] * count;
            PlayerData.S.PropListDic[PropType] -= count;
            ObserverModuleManager.S.SendEvent("SendUIToast","分解成功");
            ObserverModuleManager.S.SendEvent("刷新背包");

            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        数量Slider.maxValue = PlayerData.S.PropListDic[PropType];
        数量Slider.minValue = 1;
        数量.text = "1";
        数量Slider.onValueChanged.AddListener(OnSliderValueChanged);
        获得粉尘.text = (法器Config.法器材料分解粉尘Dic[PropConfig.PropQualityDic[PropType]]*count).ToString();
    }
    
    
    private void OnEnable()
    {
        获得粉尘.text = (法器Config.法器材料分解粉尘Dic[PropConfig.PropQualityDic[PropType]]*count).ToString();
        数量Slider.maxValue = PlayerData.S.PropListDic[PropType];
        数量Slider.minValue = 1;
        数量.text = "1";
    }

    void OnSliderValueChanged(float value)
    {
        if (PlayerData.S.PropListDic[PropType] == 1)
        {
            数量Slider.value=数量Slider.maxValue;
            return;
        }
        int newCount=(int)value;
        数量Slider.value=newCount;
        数量.text=newCount.ToString();
        count=newCount;
        获得粉尘.text=(newCount*法器Config.法器材料分解粉尘Dic[PropConfig.PropQualityDic[PropType]]).ToString();
    }
    public void SetItem()
    {
        数量.text = "1";
        float count = PlayerData.S.PropListDic[PropType];
        if (count > 1)
        {
            数量Slider.value = 数量Slider.minValue;
        }
        else
        {
            数量Slider.value = 数量Slider.maxValue;
        }
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(PropConfig.PropQualityDic[PropType]);
        icon.sprite = ResourcesConfig.Get法器材料Sprite(PropConfig.GetProp法器材料Type(PropType),PropConfig.PropQualityDic[PropType]);
        name.text = 法器Config.Get法器材料Name(PropConfig.GetProp法器材料Type(PropType),PropConfig.PropQualityDic[PropType]);
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(PropConfig.PropQualityDic[PropType]);
        品质.text = PropConfig.QualityNameDic[PropConfig.PropQualityDic[PropType]];
    }
}
