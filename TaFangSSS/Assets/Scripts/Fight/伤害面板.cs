using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 伤害item
{
    public HeroType heroType;
    public float damage;
    public float 比例;
}
public class 伤害面板 : MonoBehaviour
{
    public Button 展开按钮;
    public Button 折叠按钮;
    public Animator animator;
    public GameObject Content;
    private List<伤害面板item> 英雄伤害List=new List<伤害面板item>();

    public void Init伤害面板(object[] obj)
    {
        List<HeroType>  heroTypes = new List<HeroType>();
        heroTypes=(List<HeroType>)obj[0];
        foreach (Transform item in Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (HeroType heroType in heroTypes)
        {
            var item = Instantiate(Resources.Load("Prefabs/Fight/伤害item"), Content.transform).GetComponent<伤害面板item>();
            item.heroType = heroType;
            item.比例 = 0;
            item.damage = 0;
            item.SetItem();
            英雄伤害List.Add(item);
        }
    }

    public void 刷新伤害面板(object[] obj)
    {
        List<伤害item>  heroTypes = new List<伤害item>();
        heroTypes=(List<伤害item>)obj[0];
        foreach (var item in heroTypes)
        {
            foreach (var 英雄item in 英雄伤害List)
            {
                if (英雄item.heroType == item.heroType)
                {
                    英雄item.damage=item.damage;
                    英雄item.比例=item.比例;
                    英雄item.SetItem();
                    break;
                }
            }
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("Init伤害面板",Init伤害面板);
        ObserverModuleManager.S.UnRegisterEvent("刷新伤害面板",刷新伤害面板);
    }

    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("Init伤害面板",Init伤害面板);
        ObserverModuleManager.S.RegisterEvent("刷新伤害面板",刷新伤害面板);

        展开按钮.onClick.AddListener(() =>
        {
            animator.Play("伤害面版",0,0);
        });
        折叠按钮.onClick.AddListener(() =>
        {
            animator.Play("伤害面板折叠",0,0);
        });
    }
}
