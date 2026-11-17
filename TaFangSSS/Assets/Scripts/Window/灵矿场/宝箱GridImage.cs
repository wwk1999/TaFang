using System;
using UnityEngine;

public class 宝箱GridImage : GridImageBase
{
    public 宝箱Grid 宝箱Grid;

    private bool shift=false;
    protected override string 默认弹窗路径
    {
        get { return "Prefabs/Window/灵矿场/宝箱信息弹窗"; }
    }

    protected override bool 可显示
    {
        get { return 宝箱Grid != null; }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            shift = true;
        }
        else
        {
            shift = false;
        }
    }

    protected override void 设置弹窗(GameObject 弹窗对象)
    {
        var 弹窗 = 弹窗对象.GetComponent<宝箱信息弹窗>();
        弹窗.宝箱品质 = 宝箱Grid.品质;
        弹窗.SetItem();
    }

    protected override void 右键点击()
    {
        if (宝箱Grid == null) return;
        if (!shift)
        {
            灵矿场Config.开宝箱(宝箱Grid.品质);
        }
        else
        {
            for (int i = 0; i < PlayerData.S.宝箱Dic[宝箱Grid.品质]; i++)
            {
                灵矿场Config.开宝箱(宝箱Grid.品质);
            }
        }
        ObserverModuleManager.S.SendEvent("刷新矿工背包");
    }
}
