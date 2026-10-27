using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 打造item : MonoBehaviour,IPointerClickHandler
{
    public Image bg;
    public Image icon;
    public Image mask;
    public TextMeshProUGUI counttext;
    [NonSerialized] public 法器Type 法器Type;
    [NonSerialized] public int 阶数 = 1;
    [NonSerialized] public int count;
    [NonSerialized] public float 进度;
    [NonSerialized] public int index;
    public void SetItem()
    {
        mask.sprite=ResourcesConfig.Get法器Sprite(法器Type, 阶数);
        // 队列中品质尚未确定，背景框统一按阶数对应的品质档位显示
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.Get阶数对应品质(阶数));
        icon.sprite = ResourcesConfig.Get法器Sprite(法器Type, 阶数);
        counttext.text = count.ToString();
        icon.fillAmount = 进度 / 100f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // 取消排队时，按该队列剩余数量返还加入时已扣除的打造材料
            if (count > 0)
            {
                List<PropType> 材料 = 法器Config.Get打造法器材料(法器Type, 阶数);
                foreach (var propType in 材料)
                {
                    PlayerData.S.PropListDic[propType] += count;
                }
            }
            PlayerData.S.打造List.RemoveAt(index);
            // 刷新整个打造面板，同步剩余材料与可打造数量
            ObserverModuleManager.S.SendEvent("刷新法器打造Panel");
        }
    }
}
