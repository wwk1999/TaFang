using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 传道item : MonoBehaviour
{
    public Image bg;
    public TextMeshProUGUI name;
    public Image icon;
    public TextMeshProUGUI 功德count;
    public Button 传道Button;
    [NonSerialized]public QualityType qualityType;
    // 单次传道的次数上限：防止功德极大时一次传几亿次（循环卡死、功法数量int溢出）
    private const long 单次传道上限 = 10000;

    private void Start()
    {
        传道Button.onClick.AddListener(() =>
            {
                if (PlayerData.S.消耗传道次数)
                {
                    if (PlayerData.S.剩余传道次数 <= 0)
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToast", "传道次数不足");
                        return;
                    }
                    if (PlayerData.S.PropListDic[PropType.功德] < 功法Config.传道消耗Dic[qualityType])
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToast", "功德不足");
                        return;
                    }

                    long 传道次数 = 1;
                    if (PlayerData.S.传道所有)
                    {
                        传道次数 = (long)Math.Min(PlayerData.S.剩余传道次数,
                            PlayerData.S.PropListDic[PropType.功德] / 功法Config.传道消耗Dic[qualityType]);
                    }

                    StartCoroutine(传道(传道次数));
                    ObserverModuleManager.S.SendEvent("刷新主页面");
                    ObserverModuleManager.S.SendEvent("刷新传道界面");
                }
                else
                {
                    if (PlayerData.S.PropListDic[PropType.功德] < 功法Config.传道消耗Dic[qualityType]*3)
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToast", "功德不足");
                        return;
                    }
                    long 传道次数 = 1;
                    if (PlayerData.S.传道所有)
                    {
                        // 功德后期是 10^17+ 的大数，除出来的次数远超 int 范围：
                        // (int) 强转溢出会得到 int.MinValue（负数）→ 功法不发、功德几乎不动，
                        // 这就是"勾了传道所有却不消耗功德"的原因。必须用 long 承接
                        传道次数 = (long)(PlayerData.S.PropListDic[PropType.功德] / (功法Config.传道消耗Dic[qualityType]*3));
                        if (传道次数 > 单次传道上限)
                        {
                            传道次数 = 单次传道上限;
                            ObserverModuleManager.S.SendEvent("SendUIToast", "功德过多，本次最多传道" + 单次传道上限 + "次");
                        }
                    }
                    StartCoroutine(传道(传道次数));
                    ObserverModuleManager.S.SendEvent("刷新主页面");
                    ObserverModuleManager.S.SendEvent("刷新传道界面");
                }
            }
        );
    }

    IEnumerator 传道(long count)
    {
        Dictionary<功法Type, int> list = new Dictionary<功法Type, int>();
        for (int i = 0; i < count; i++)
        {
            功法Type type = 功法Config.传道(qualityType);
            if (list.ContainsKey(type))
            {
                list[type]++;
            }
            else
            {
                list[type] = 1;
            }
            PlayerData.S.功法数量Dic[type]++;
        }
        if (PlayerData.S.消耗传道次数)
        {
            PlayerData.S.剩余传道次数-=(int)count;   // 该分支 count ≤ 剩余传道次数，截断无损
            PlayerData.S.PropListDic[PropType.功德] -= 功法Config.传道消耗Dic[qualityType]*count;
        }
        else
        {
            PlayerData.S.PropListDic[PropType.功德] -= 功法Config.传道消耗Dic[qualityType]*3*count;
        }

        foreach (var item in list)
        {
            ZhiYeType zhiye = 功法Config.功法职业Dic[item.Key];
            ObserverModuleManager.S.SendEvent("SendUIToast",
                HeroConfig.Get职业Name(zhiye) + "·" + 功法Config.功法名Dic[item.Key], 功法Config.功法TypeQualityDic[item.Key], item.Value);
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void SetItem()
    {
        bg.sprite=ResourcesConfig.Get传道背景框(qualityType);
        name.text=PropConfig.QualityNameDic[qualityType]+"传道";
        name.colorGradientPreset=ResourcesConfig.Get品质TMP(qualityType);
        icon.sprite=ResourcesConfig.Get传道icon(qualityType);
        if (PlayerData.S.消耗传道次数)
        {
           功德count.text=功法Config.传道消耗Dic[qualityType].ToString(); 
        }
        else
        {
            功德count.text=(功法Config.传道消耗Dic[qualityType]*3).ToString(); 
        }
        传道Button.image.sprite=ResourcesConfig.Get传道按钮(qualityType);
       
    }
}
