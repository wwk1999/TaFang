using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 赌坊商品item : MonoBehaviour, IPointerClickHandler
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;

    [NonSerialized] public 赌坊道具Type 道具Type;

    public void SetItem()
    {
        if (道具Type == 赌坊道具Type.None) return;

        道具配置 config = 赌坊Config.道具配置[道具Type];
        bg.sprite = ResourcesConfig.Get灵植背包格子(config.QualityType);
        name.text = config.名称;
        if (icon != null && 赌坊Config.道具图标索引.TryGetValue(道具Type, out int 图标索引))
        {
            icon.sprite = ResourcesConfig.Get赌坊道具Sprite(图标索引);
        }
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
        // 通知赌坊界面刷新道具背包与灵气显示
        ObserverModuleManager.S.SendEvent("赌坊道具购买完成");
        StoreController.S.SaveStoreData();
    }
}
