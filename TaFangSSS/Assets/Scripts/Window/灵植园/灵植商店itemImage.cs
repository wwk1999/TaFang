using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class 灵植商店itemImage : MonoBehaviour,IPointerClickHandler
{
    public 灵植商店item 灵植商店item;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right) return;
        if (灵植商店item == null) return;

        float 价格;
        if (灵植商店item.灵植Type != 灵植Type.None)
        {
            价格 = 灵植园Config.灵植价格Dic[灵植商店item.灵植Type];
        }
        else if (灵植商店item.肥料Type != 肥料Type.None)
        {
            价格 = 灵植园Config.Get肥料价格(灵植商店item.肥料Type, 灵植商店item.quality);
        }
        else
        {
            return;
        }

        // 按住 Shift 一次购买 10 个，否则 1 个
        int 数量 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? 10 : 1;
        float 总价 = 价格 * 数量;
        if (PlayerData.S.青石 < 总价)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "青石不足");
            return;
        }

        PlayerData.S.青石 -= 总价;
        ObserverModuleManager.S.SendEvent("Set青石");

        if (灵植商店item.灵植Type != 灵植Type.None)
        {
            PlayerData.S.种子Dic[灵植商店item.灵植Type] += 数量;
        }
        else
        {
            var 肥料数量 = PlayerData.S.Get肥料数量(灵植商店item.肥料Type, 灵植商店item.quality);
            PlayerData.S.Set肥料数量(灵植商店item.肥料Type, 灵植商店item.quality, 肥料数量 + 数量);
        }

        ObserverModuleManager.S.SendEvent("SendUIToast", "购买成功");
    }
}
