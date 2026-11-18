using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 宝箱GridImage : GridImageBase
{
    public 宝箱Grid 宝箱Grid;

    private static bool 正在一键开宝箱;
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
        if (正在一键开宝箱) return;

        if (!按下Shift)
        {
            开一个宝箱();
        }
        else
        {
            // 协程必须挂在弹窗上运行：刷新背包会销毁并重建格子，
            // 若挂在格子上，第一次刷新后协程就随 GameObject 销毁而中断
            var 弹窗 = GetComponentInParent<矿工背包弹窗>();
            if (弹窗 != null) 弹窗.StartCoroutine(一键开宝箱());
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
        正在一键开宝箱 = true;
        // 品质缓存为局部变量：格子销毁后不能再访问 宝箱Grid
        宝箱品质 品质 = 宝箱Grid.品质;
        int 数量 = PlayerData.S.Get宝箱数量(品质);

        // 一次性同步开完，按(名称,品质)聚合数量，同名同品质只弹一个Toast
        var 统计 = new Dictionary<(string 名称, QualityType 品质), int>();
        var 顺序 = new List<(string 名称, QualityType 品质)>();
        for (int i = 0; i < 数量; i++)
        {
            var r = 灵矿场Config.开宝箱(品质);
            if (string.IsNullOrEmpty(r.名称)) continue;
            var key = (r.名称, r.品质);
            if (!统计.ContainsKey(key)) 顺序.Add(key);
            统计.TryGetValue(key, out int c);
            统计[key] = c + 1;
        }
        ObserverModuleManager.S.SendEvent("刷新矿工背包");

        // 按获得顺序逐组弹Toast，组间小间隔避免同帧堆叠
        foreach (var key in 顺序)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", key.名称, key.品质, 统计[key]);
            yield return new WaitForSeconds(0.1f);
        }
        正在一键开宝箱 = false;
    }

    private void 弹Toast(string 名称, QualityType 品质)
    {
        if (string.IsNullOrEmpty(名称)) return;
        ObserverModuleManager.S.SendEvent("SendUIToast", 名称, 品质, 1);
    }
}
