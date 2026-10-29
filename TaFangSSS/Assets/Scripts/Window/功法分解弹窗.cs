using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 功法分解弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 职业;
    public TextMeshProUGUI 数量;
    public TextMeshProUGUI 获得经验;

    public Slider 数量Slider;
    public Button 分解按钮;
    private int count=1;

    [NonSerialized] public 功法Type 功法Type;

    private void Start()
    {
        分解按钮.onClick.AddListener(() =>
        {
            // 兜底校验：以点击瞬间的实时库存为准，不足则拦截，杜绝扣成负数
            int 当前数量 = PlayerData.S.功法数量Dic[功法Type];
            if (count <= 0 || count > 当前数量)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","功法数量不足");
                return;
            }
            PlayerData.S.PropListDic[PropType.功法经验] += 功法Config.Get功法分解经验(功法Config.功法TypeQualityDic[功法Type]) * count;
            PlayerData.S.功法数量Dic[功法Type] -= count;
            ObserverModuleManager.S.SendEvent("SendUIToast","分解成功");
            ObserverModuleManager.S.SendEvent("刷新背包");

            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        数量Slider.maxValue = PlayerData.S.功法数量Dic[功法Type];
        if (PlayerData.S.功法数量Dic[功法Type] <= 1)
        {
           数量Slider.minValue = 0; 
        }
        else
        {
            数量Slider.minValue = 1;
        }
        数量Slider.onValueChanged.AddListener(OnSliderValueChanged);
        获得经验.text=功法Config.Get功法分解经验(功法Config.功法TypeQualityDic[功法Type]).ToString();
    }

    
    private void OnEnable()
    {
        获得经验.text=功法Config.Get功法分解经验(功法Config.功法TypeQualityDic[功法Type]).ToString();
        数量Slider.maxValue = PlayerData.S.功法数量Dic[功法Type];
        if (PlayerData.S.功法数量Dic[功法Type] <= 1)
        {
            数量Slider.minValue = 0; 
        }
        else
        {
            数量Slider.minValue = 1;
        }
    }

    void OnSliderValueChanged(float value)
    {
        if (PlayerData.S.功法数量Dic[功法Type] == 1)
        {
            数量Slider.value=数量Slider.maxValue;
            // 只剩1本时分解数量固定为1，必须同步重置 count，
            // 否则会沿用上一次分解的残留数量（上次分解60本，这次1本也按60扣成负数）
            count = 1;
            数量.text = "1";
            return;
        }
        int newCount=(int)value;
        数量Slider.value=newCount;
        数量.text=newCount.ToString();
        count=newCount;
        获得经验.text=(newCount*功法Config.Get功法分解经验(功法Config.功法TypeQualityDic[功法Type])).ToString();
    }
    public void SetItem()
    {
        // 每次打开重置分解数量，防止沿用上一次会话的残留值
        count = 1;
        数量.text = "1";
        int 当前数量 = PlayerData.S.功法数量Dic[功法Type];
        if (当前数量 > 1)
        {
            数量Slider.value = 数量Slider.minValue;
        }
        else
        {
            数量Slider.value = 数量Slider.maxValue;
        }
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(功法Config.功法TypeQualityDic[功法Type]);
        icon.sprite = ResourcesConfig.Get功法Sprite(功法Type);
        name.text = 功法Config.功法名Dic[功法Type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(功法Config.功法TypeQualityDic[功法Type]);
        职业.text = 功法Config.功法职业Dic[功法Type].ToString();
    }
}
