using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class 法器信息仙石 : MonoBehaviour
{
    public GameObject content;
    public TextMeshProUGUI 红1;
    public TextMeshProUGUI 绿1;
    public TextMeshProUGUI 蓝1;
    public TextMeshProUGUI 紫1;
    public TextMeshProUGUI 灰1;
    public TextMeshProUGUI 黄1;
    
    public TextMeshProUGUI 红2;
    public TextMeshProUGUI 绿2;
    public TextMeshProUGUI 蓝2;
    public TextMeshProUGUI 紫2;
    public TextMeshProUGUI 灰2;
    public TextMeshProUGUI 黄2;
    [NonSerialized] public 法器 法器;

    public void SetItem()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in 法器.仙石list)
        {
            var 仙石=Instantiate(Resources.Load("Prefabs/Window/孔item"), content.transform).GetComponent<孔item>();
            仙石.仙石 = item;
            仙石.SetItem();
        }
        红1.text = "";
        绿1.text = "";
        蓝1.text = "";
        紫1.text = "";
        灰1.text = "";
        黄1.text = "";
        
        红2.text = "";
        绿2.text = "";
        蓝2.text = "";
        紫2.text = "";
        灰2.text = "";
        黄2.text = "";
        bool 第一个显示 = false;
        for (int i = 1; i < Enum.GetValues(typeof(仙石Type)).Length; i++)
        {
            int 数量 = 仙石Config.Get法器仙石数量(法器, (仙石Type)i);
            if (数量 >= 8)
            {
                if (!第一个显示)
                {
                    第一个显示 = true;
                    switch ((仙石Type)i)
                    {
                        case 仙石Type.赤阳石:
                            红1.text = "赤阳石(8)";
                            break;
                        case 仙石Type.太虚石:
                            灰1.text = "太虚石(8)";
                            break;
                        case 仙石Type.清心玉:
                            绿1.text = "清心玉(8)";
                            break;
                        case 仙石Type.玄冥石:
                            紫1.text = "玄冥石(8)";
                            break;
                        case 仙石Type.玄灵晶:
                            蓝1.text = "玄灵晶(8)";
                            break;
                        case 仙石Type.天罡石:
                            黄1.text = "天罡石(8)";
                            break;
                    }
                }
                else
                {
                    switch ((仙石Type)i)
                    {
                        case 仙石Type.赤阳石:
                            红2.text = "赤阳石(8)";
                            break;
                        case 仙石Type.太虚石:
                            灰2.text = "太虚石(8)";
                            break;
                        case 仙石Type.清心玉:
                            绿2.text = "清心玉(8)";
                            break;
                        case 仙石Type.玄冥石:
                            紫2.text = "玄冥石(8)";
                            break;
                        case 仙石Type.玄灵晶:
                            蓝2.text = "玄灵晶(8)";
                            break;
                        case 仙石Type.天罡石:
                            黄2.text = "天罡石(8)";
                            break;
                    }
                }
            }
            else if (数量 >= 6)
            {
                if (!第一个显示)
                {
                    第一个显示 = true;
                    switch ((仙石Type)i)
                    {
                        case 仙石Type.赤阳石:
                            红1.text = "赤阳石(6)";
                            break;
                        case 仙石Type.太虚石:
                            灰1.text = "太虚石(6)";
                            break;
                        case 仙石Type.清心玉:
                            绿1.text = "清心玉(6)";
                            break;
                        case 仙石Type.玄冥石:
                            紫1.text = "玄冥石(6)";
                            break;
                        case 仙石Type.玄灵晶:
                            蓝1.text = "玄灵晶(6)";
                            break;
                        case 仙石Type.天罡石:
                            黄1.text = "天罡石(6)";
                            break;
                    }
                }
                else
                {
                    switch ((仙石Type)i)
                    {
                        case 仙石Type.赤阳石:
                            红2.text = "赤阳石(6)";
                            break;
                        case 仙石Type.太虚石:
                            灰2.text = "太虚石(6)";
                            break;
                        case 仙石Type.清心玉:
                            绿2.text = "清心玉(6)";
                            break;
                        case 仙石Type.玄冥石:
                            紫2.text = "玄冥石(6)";
                            break;
                        case 仙石Type.玄灵晶:
                            蓝2.text = "玄灵晶(6)";
                            break;
                        case 仙石Type.天罡石:
                            黄2.text = "天罡石(6)";
                            break;
                    }
                }
            }
            else if (数量 >= 4)
            {
                if (!第一个显示)
                {
                    第一个显示 = true;
                    switch ((仙石Type)i)
                    {
                        case 仙石Type.赤阳石:
                            红1.text = "赤阳石(4)";
                            break;
                        case 仙石Type.太虚石:
                            灰1.text = "太虚石(4)";
                            break;
                        case 仙石Type.清心玉:
                            绿1.text = "清心玉(4)";
                            break;
                        case 仙石Type.玄冥石:
                            紫1.text = "玄冥石(4)";
                            break;
                        case 仙石Type.玄灵晶:
                            蓝1.text = "玄灵晶(4)";
                            break;
                        case 仙石Type.天罡石:
                            黄1.text = "天罡石(4)";
                            break;
                    }
                }
                else
                {
                    switch ((仙石Type)i)
                    {
                        case 仙石Type.赤阳石:
                            红2.text = "赤阳石(4)";
                            break;
                        case 仙石Type.太虚石:
                            灰2.text = "太虚石(4)";
                            break;
                        case 仙石Type.清心玉:
                            绿2.text = "清心玉(4)";
                            break;
                        case 仙石Type.玄冥石:
                            紫2.text = "玄冥石(4)";
                            break;
                        case 仙石Type.玄灵晶:
                            蓝2.text = "玄灵晶(4)";
                            break;
                        case 仙石Type.天罡石:
                            黄2.text = "天罡石(4)";
                            break;
                    }
                }
            }
        }
    }
}
