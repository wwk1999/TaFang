using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 打造item : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI counttext;
    [NonSerialized] public 法器Type 法器Type;
    [NonSerialized] public int count;
    [NonSerialized] public float 进度;
    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器Type]);
        icon.sprite = ResourcesConfig.Get法器Sprite(法器Type);
        counttext.text = count.ToString();
        icon.fillAmount = 进度 / 100f;
    }
}
