using UnityEngine;

public class 矿工装备背包itemImage : GridImageBase
{
    public 矿工装备Grid item;

    protected override string 默认弹窗路径
    {
        get { return "Prefabs/Window/灵矿场/装备信息弹窗"; }
    }

    protected override bool 可显示
    {
        get { return item != null && item.矿工装备 != null; }
    }

    protected override void 设置弹窗(GameObject 弹窗对象)
    {
        var 弹窗 = 弹窗对象.GetComponent<装备信息弹窗>();
        弹窗.矿工装备 = item.矿工装备;
        弹窗.SetItem();
    }

    protected override void 右键点击()
    {
        if (item == null || item.矿工装备 == null) return;
        ObserverModuleManager.S.SendEvent("矿工装备背包右键", item.矿工装备);
    }
}
