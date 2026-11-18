using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 当前佩戴宝物ItemImage :  GridImageBase
{
    public 当前佩戴宝物Item 当前佩戴宝物Item;

    protected override string 默认弹窗路径
    {
        get { return "Prefabs/Window/灵矿场/当前佩戴宝物信息弹窗"; }
    }

    protected override bool 可显示
    {
        get { return 当前佩戴宝物Item != null && PlayerData.S.当前宝物[当前佩戴宝物Item.index] != null; }
    }

    protected override void 设置弹窗(GameObject 弹窗对象)
    {
        var 弹窗 = 弹窗对象.GetComponent<当前佩戴宝物信息弹窗>();
        弹窗.宝物 = PlayerData.S.当前宝物[当前佩戴宝物Item.index];
        弹窗.SetItem();
    }

    protected override void 右键点击()
    {
        if (当前佩戴宝物Item == null || PlayerData.S.当前宝物[当前佩戴宝物Item.index] == null) return;
        宝物Type 宝物Type = PlayerData.S.当前宝物[当前佩戴宝物Item.index].宝物Type;
        QualityType qualityType=PlayerData.S.当前宝物[当前佩戴宝物Item.index].QualityType;
        PlayerData.S.当前宝物[当前佩戴宝物Item.index] = null;
        PlayerData.S.Set宝物数量(宝物Type, qualityType,PlayerData.S.Get宝物数量(宝物Type, qualityType)+1);
        ObserverModuleManager.S.SendEvent("当前佩戴宝物卸下");
    }
}
