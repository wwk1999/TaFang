using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 矿工装备背包itemImage111 : GridImageBase
{
    public 矿工装备背包item item;

    protected override string 默认弹窗路径
    {
        get { return "Prefabs/Window/灵矿场/装备对比信息弹窗"; }
    }

    protected override bool 可显示
    {
        get { return item != null && item.矿工装备 != null; }
    }

    protected override void 设置弹窗(GameObject 弹窗对象)
    {
        var 弹窗 = 弹窗对象.GetComponent<装备对比信息弹窗>();
        弹窗.选中矿工装备 = item.矿工装备;
        弹窗.当前矿工=HeroWindowController.S.矿工管理弹窗当前矿工;
        弹窗.SetItem();
    }
}
