using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class 体质信息弹窗 : MonoBehaviour
{
    public GameObject content;
    [NonSerialized] public 体质Type 体质Type;

    public void SetItem()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        var 体质info = Instantiate(Resources.Load("Prefabs/Window/体质/体质infoItem"), content.transform)
            .GetComponent<体质infoItem>();
        体质info.体质type = 体质Type;
        体质info.SetItem();

        var 体质属性 = 体质Config.体质属性Dic[体质Type];
        if (体质属性.火焰伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "火焰伤害增幅：";
            item.count = 体质属性.火焰伤害;
            item.SetItem();
        }

        if (体质属性.雷电伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "雷电伤害增幅：";
            item.count = 体质属性.雷电伤害;
            item.SetItem();
        }

        if (体质属性.冰霜伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "冰霜伤害增幅：";
            item.count = 体质属性.冰霜伤害;
            item.SetItem();
        }

        if (体质属性.物理伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "物理伤害增幅：";
            item.count = 体质属性.物理伤害;
            item.SetItem();
        }

        if (体质属性.黑暗伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "黑暗伤害增幅：";
            item.count = 体质属性.黑暗伤害;
            item.SetItem();
        }

        if (体质属性.战士伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "战士伤害增幅：";
            item.count = 体质属性.战士伤害;
            item.SetItem();
        }

        if (体质属性.射手伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "射手伤害增幅：";
            item.count = 体质属性.射手伤害;
            item.SetItem();
        }

        if (体质属性.法师伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "法师伤害增幅：";
            item.count = 体质属性.法师伤害;
            item.SetItem();
        }

        if (体质属性.控制伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "控制伤害增幅：";
            item.count = 体质属性.控制伤害;
            item.SetItem();
        }

        if (体质属性.辅助伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "辅助伤害增幅：";
            item.count = 体质属性.辅助伤害;
            item.SetItem();
        }

        if (体质属性.最终伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "最终伤害增幅：";
            item.count = 体质属性.最终伤害;
            item.SetItem();
        }

        if (体质属性.暴击伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "暴击伤害增幅：";
            item.count = 体质属性.暴击伤害;
            item.SetItem();
        }

        if (体质属性.攻击速度 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "攻击速度增幅：";
            item.count = 体质属性.攻击速度;
            item.SetItem();
        }

        if (体质属性.丹药效果 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "丹药效果增幅：";
            item.count = 体质属性.丹药效果;
            item.SetItem();
        }

        if (体质属性.炼丹速度 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "炼丹速度增幅：";
            item.count = 体质属性.炼丹速度;
            item.SetItem();
        }

        if (体质属性.炼丹经验加成 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "炼丹经验加成：";
            item.count = 体质属性.炼丹经验加成;
            item.SetItem();
        }

        if (体质属性.掉宝率 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "掉宝率加成：";
            item.count = 体质属性.掉宝率;
            item.SetItem();
        }

        if (体质属性.功法经验加成 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "功法经验加成：";
            item.count = 体质属性.功法经验加成;
            item.SetItem();
        }

        if (体质属性.紫霄宫传道次数加成 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "紫霄宫传道次数加成：";
            item.count = 体质属性.紫霄宫传道次数加成;
            item.SetItem();
        }

        if (体质属性.法器效果加成 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "法器效果加成：";
            item.count = 体质属性.法器效果加成;
            item.SetItem();
        }

        if (体质属性.轮回系数 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "轮回系数加成：";
            item.count = 体质属性.轮回系数;
            item.SetItem();
        }

        if (体质属性.轮回次数加伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "每轮回次数加伤害：";
            item.count = 体质属性.轮回次数加伤害;
            item.SetItem();
        }

        if (体质属性.每道年增加伤害 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "每道年增加伤害：";
            item.count = 体质属性.每道年增加伤害;
            item.SetItem();
        }

        if (体质属性.时间流速加成 != 0)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/体质/体质属性item"), content.transform)
                .GetComponent<体质属性item>();
            item.name = "时间流速加成：";
            item.count = 体质属性.时间流速加成;
            item.SetItem();
        }
    }
}
