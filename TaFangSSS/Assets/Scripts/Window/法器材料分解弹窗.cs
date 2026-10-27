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
            // 校验实际持有量，防止把材料扣成负数
            int 持有数量 = Mathf.FloorToInt(PlayerData.S.PropListDic[PropType]);
            if (持有数量 <= 0 || count > 持有数量)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","材料数量不足,无法分解");
                gameObject.SetActive(false);
                return;
            }
            PlayerData.S.PropListDic[PropType.法器粉尘] += 法器Config.法器材料分解粉尘Dic[PropConfig.GetProp阶数(PropType)] * count*(1f+道场Config.供奉总属性.增加法器分解粉尘/100f);
            PlayerData.S.PropListDic[PropType] -= count;
            ObserverModuleManager.S.SendEvent("SendUIToast","分解成功");
            ObserverModuleManager.S.SendEvent("刷新背包");

            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        // 先设minValue再设maxValue，并夹住下限为1，避免UGUI把maxValue强行抬到minValue导致0个材料也能分解
        float 持有 = PlayerData.S.PropListDic[PropType];
        数量Slider.minValue = 1;
        数量Slider.maxValue = Mathf.Max(1f, Mathf.Floor(持有));
        分解按钮.interactable = 持有 >= 1f;
        数量.text = "1";
        数量Slider.onValueChanged.AddListener(OnSliderValueChanged);
        获得粉尘.text = (法器Config.法器材料分解粉尘Dic[PropConfig.GetProp阶数(PropType)]*count*(1f+道场Config.供奉总属性.增加法器分解粉尘/100f)).ToString();
    }
    
    
    private void OnEnable()
    {
        获得粉尘.text = (法器Config.法器材料分解粉尘Dic[PropConfig.GetProp阶数(PropType)]*count*(1f+道场Config.供奉总属性.增加法器分解粉尘/100f)).ToString();
        // 先设minValue再设maxValue，并夹住下限为1，避免UGUI把maxValue强行抬到minValue导致0个材料也能分解
        float 持有 = PlayerData.S.PropListDic[PropType];
        数量Slider.minValue = 1;
        数量Slider.maxValue = Mathf.Max(1f, Mathf.Floor(持有));
        分解按钮.interactable = 持有 >= 1f;
        数量.text = "1";
        count = 1;
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
        获得粉尘.text=(newCount*法器Config.法器材料分解粉尘Dic[PropConfig.GetProp阶数(PropType)]*(1f+道场Config.供奉总属性.增加法器分解粉尘/100f)).ToString();
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
        var 阶数 = PropConfig.GetProp阶数(PropType);
        var 材料品质 = 法器Config.Get阶数对应品质(阶数);
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(材料品质);
        icon.sprite = ResourcesConfig.Get法器材料Sprite(PropConfig.GetProp法器材料Type(PropType), 阶数);
        name.text = 法器Config.Get法器材料Name(PropConfig.GetProp法器材料Type(PropType), 阶数);
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(材料品质);
        品质.text = 阶数 + "阶";
    }
}
