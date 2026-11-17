using UnityEngine;

public class 灵矿GridImage : GridImageBase
{
    public 灵矿Grid 灵矿Grid;

    protected override string 默认弹窗路径
    {
        get { return "Prefabs/Window/灵矿场/灵矿信息弹窗"; }
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
        ObserverModuleManager.S.SendEvent("灵矿Grid右键", 灵矿Grid.阶数值, 灵矿Grid.品质);
    }
}
