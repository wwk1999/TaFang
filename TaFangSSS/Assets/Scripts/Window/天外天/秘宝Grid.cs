using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 秘宝Grid : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public Image 价格icon;
    public TextMeshProUGUI value;
    [NonSerialized] public 秘宝地点 秘宝地点;
    [NonSerialized] public 秘宝Type 秘宝Type;
    [NonSerialized] public int 等级;

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(天外天Config.Get秘宝品质(等级, 秘宝Type));
        icon.sprite = ResourcesConfig.Get秘宝Sprite(秘宝地点, 秘宝Type, 等级);
        name.text = 天外天Config.Get秘宝名(秘宝地点, 秘宝Type);
        价格icon.sprite = ResourcesConfig.Get气运icon(秘宝地点);
        value.text = PlayerData.S.格式化数字(天外天Config.Get秘宝价格(等级, 秘宝Type));
    }

    private void Start()
    {
        bg.onClick.AddListener(() =>
        {
            float value = 天外天Config.Get秘宝价格(等级, 秘宝Type);
            switch (秘宝地点)
            {
                case 秘宝地点.须弥宫:
                    if (PlayerData.S.PropListDic[PropType.须弥气运] < value)
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToast","须弥气运不足");
                        return;
                    }
                    PlayerData.S.PropListDic[PropType.须弥气运] -= value;
                    break;
            }
        });
    }
}
