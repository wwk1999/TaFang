using System;
using Config;
using UnityEngine;

public class 灵矿GridImage : GridImageBase
{
    public 灵矿Grid 灵矿Grid;
    private bool 按下Shift;
    protected override string 默认弹窗路径
    {
        get { return "Prefabs/Window/灵矿场/灵矿信息弹窗"; }
    }

    private void Update()
    {
        按下Shift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }

    protected override bool 可显示
    {
        get { return 灵矿Grid != null; }
    }

    protected override void 设置弹窗(GameObject 弹窗对象)
    {
        var 弹窗 = 弹窗对象.GetComponent<灵矿信息弹窗>();
        弹窗.阶数 = 灵矿Grid.阶数值;
        弹窗.品质Type = 灵矿Grid.品质;
        弹窗.SetItem();
    }

    protected override void 右键点击()
    {
        if (灵矿Grid == null) return;
        if (!按下Shift)
        {
             PlayerData.S.Set灵矿数量(灵矿Grid.阶数值, 灵矿Grid.品质, PlayerData.S.Get灵矿数量(灵矿Grid.阶数值, 灵矿Grid.品质)-1);
             PlayerData.S.PropListDic[PropType.灵石] += 灵矿场Config.Get灵矿价格(灵矿Grid.阶数值, 灵矿Grid.品质);
        }
        else
        {
            PlayerData.S.PropListDic[PropType.灵石] += 灵矿场Config.Get灵矿价格(灵矿Grid.阶数值, 灵矿Grid.品质)*PlayerData.S.Get灵矿数量(灵矿Grid.阶数值, 灵矿Grid.品质);
            PlayerData.S.Set灵矿数量(灵矿Grid.阶数值, 灵矿Grid.品质, 0);
        }
        ObserverModuleManager.S.SendEvent("刷新矿工背包");
        ObserverModuleManager.S.SendEvent("灵矿Grid右键", 灵矿Grid.阶数值, 灵矿Grid.品质);
    }
}
