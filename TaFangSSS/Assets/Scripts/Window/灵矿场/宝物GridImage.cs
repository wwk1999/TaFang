using UnityEngine;
using UnityEngine.EventSystems;

public class 宝物GridImage : GridImageBase
{
    public 宝物Grid 宝物Grid;
    private bool 按下Shift;

    private void Update()
    {
        按下Shift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }
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
        if (按下Shift)
        {
            PlayerData.S.宝物碎片 += 灵矿场Config.Get宝物碎片(宝物Grid.宝物.QualityType) *
                                 PlayerData.S.Get宝物数量(宝物Grid.宝物.宝物Type, 宝物Grid.宝物.QualityType);
            PlayerData.S.Set宝物数量(宝物Grid.宝物.宝物Type,宝物Grid.宝物.QualityType, 0);
        }
        else
        {
            PlayerData.S.宝物碎片 += 灵矿场Config.Get宝物碎片(宝物Grid.宝物.QualityType);
            PlayerData.S.Set宝物数量(宝物Grid.宝物.宝物Type,宝物Grid.宝物.QualityType, PlayerData.S.Get宝物数量(宝物Grid.宝物.宝物Type, 宝物Grid.宝物.QualityType)-1);
        }
        ObserverModuleManager.S.SendEvent("宝物分解");
        ObserverModuleManager.S.SendEvent("SendUIToast","分解成功");
    }
}
