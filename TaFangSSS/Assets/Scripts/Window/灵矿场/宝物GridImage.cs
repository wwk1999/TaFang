using UnityEngine;
using UnityEngine.EventSystems;

public class 宝物GridImage : GridImageBase
{
    public 宝物Grid 宝物Grid;

    protected override string 默认弹窗路径
    {
        get { return "Prefabs/Window/灵矿场/宝物信息弹窗"; }
    }

    protected override bool 可显示
    {
        get { return 宝物Grid != null && 宝物Grid.宝物 != null; }
    }

    protected override void 设置弹窗(GameObject 弹窗对象)
    {
        var 弹窗 = 弹窗对象.GetComponent<宝物信息弹窗>();
        弹窗.宝物 = 宝物Grid.宝物;
        弹窗.SetItem();
    }

    protected override void 右键点击()
    {
        if (宝物Grid == null || 宝物Grid.宝物 == null) return;
        ObserverModuleManager.S.SendEvent("宝物Grid右键", 宝物Grid.宝物);
    }
}
