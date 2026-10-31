using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 赌坊商品item : MonoBehaviour, IPointerClickHandler
{
    public Image bg;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;

    [NonSerialized] public 赌坊道具Type 道具Type;

    public void SetItem()
    {
        if (道具Type == 赌坊道具Type.None) return;

        道具配置 config = 赌坊Config.道具配置[道具Type];
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByPropType(config.QualityType);
        name.text = config.名称;
        count.text = PlayerData.S.格式化数字(config.价格);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right) return;
        if (道具Type == 赌坊道具Type.None) return;

        int 数量 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? 10 : 1;
        道具配置 config = 赌坊Config.道具配置[道具Type];
        float 总价 = config.价格 * 数量;

        if (PlayerData.S.PropListDic[PropType.灵魂] < 总价)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "灵气不足");
            return;
        }

        PlayerData.S.PropListDic[PropType.灵魂] -= 总价;
        PlayerData.S.赌坊道具Dic[道具Type] = PlayerData.S.赌坊道具Dic[道具Type] + 数量;
        ObserverModuleManager.S.SendEvent("SendUIToast", $"购买{config.名称}×{数量}");
        StoreController.S.SaveStoreData();
    }
}
