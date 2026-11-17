using System;
using System.Collections;
using Config;
using UnityEngine;

public class 宝箱GridImage : GridImageBase
{
    public 宝箱Grid 宝箱Grid;

    private bool 正在开宝箱;
    private bool 按下Shift;

    private void Update()
    {
        按下Shift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }

    protected override string 默认弹窗路径
    {
        get { return "Prefabs/Window/灵矿场/宝箱信息弹窗"; }
    }

    protected override bool 可显示
    {
        get { return 宝箱Grid != null; }
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
        if (正在开宝箱) return;

        if (!按下Shift)
        {
            开一个宝箱();
        }
        else
        {
            StartCoroutine(一键开宝箱());
        }
    }

    private void 开一个宝箱()
    {
        var r = 灵矿场Config.开宝箱(宝箱Grid.品质);
        弹Toast(r.名称, r.品质);
        ObserverModuleManager.S.SendEvent("刷新矿工背包");
    }

    private IEnumerator 一键开宝箱()
    {
        正在开宝箱 = true;
        // 先缓存总数，避免开宝箱过程中数量递减导致循环提前退出
        int 数量 = PlayerData.S.Get宝箱数量(宝箱Grid.品质);
        for (int i = 0; i < 数量; i++)
        {
            var r = 灵矿场Config.开宝箱(宝箱Grid.品质);
            弹Toast(r.名称, r.品质);
            ObserverModuleManager.S.SendEvent("刷新矿工背包");
            yield return new WaitForSeconds(0.1f);
        }
        正在开宝箱 = false;
    }

    private void 弹Toast(string 名称, QualityType 品质)
    {
        if (string.IsNullOrEmpty(名称)) return;
        ObserverModuleManager.S.SendEvent("SendUIToast", 名称, 品质, 1);
    }
}
