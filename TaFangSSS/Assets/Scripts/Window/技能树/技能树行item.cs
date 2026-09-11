using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;

public class 技能树行item : MonoBehaviour
{
    public 技能树item 技能1;
    public 技能树item 技能2;
    public 技能树item 技能3;
    public 技能树item 技能4;
    public 技能树item 技能5;
    public 技能树item 技能6;
    public 技能树item 技能7;
    public 技能树item 技能8;

    public GameObject 箭头1;
    public GameObject 箭头2;
    public GameObject 箭头3;
    public GameObject 箭头4;
    public GameObject 箭头5;
    public GameObject 箭头6;
    public GameObject 箭头7;

    public GameObject content;
    [NonSerialized]public HeroType HeroType;
    [NonSerialized] public int 行;

    public void SetItem()
    {
        var list=英雄技能树Config.英雄技能树Dic[HeroType][行-1];
        箭头1.gameObject.SetActive(list[1].是否有前置);
        箭头2.gameObject.SetActive(list[2].是否有前置);
        箭头3.gameObject.SetActive(list[3].是否有前置);
        箭头4.gameObject.SetActive(list[4].是否有前置);
        箭头5.gameObject.SetActive(list[5].是否有前置);
        箭头6.gameObject.SetActive(list[6].是否有前置);
        箭头7.gameObject.SetActive(list[7].是否有前置);
        var 技能item1 = Instantiate(Resources.Load("Prefabs/Window/技能树/技能树item"), content.transform)
            .GetComponent<技能树item>();
        技能item1.HeroType = HeroType;
        技能item1.行 = 行;
        技能item1.列 = 1;
        技能item1.SetItem();
        
        var 技能item2 = Instantiate(Resources.Load("Prefabs/Window/技能树/技能树item"), content.transform)
            .GetComponent<技能树item>();
        技能item2.HeroType = HeroType;
        技能item2.行 = 行;
        技能item2.列 = 2;
        技能item2.SetItem();
        
        var 技能item3 = Instantiate(Resources.Load("Prefabs/Window/技能树/技能树item"), content.transform)
            .GetComponent<技能树item>();
        技能item3.HeroType = HeroType;
        技能item3.行 = 行;
        技能item3.列 = 3;
        技能item3.SetItem();
        
        var 技能item4 = Instantiate(Resources.Load("Prefabs/Window/技能树/技能树item"), content.transform)
            .GetComponent<技能树item>();
        技能item4.HeroType = HeroType;
        技能item4.行 = 行;
        技能item4.列 = 4;
        技能item4.SetItem();
        
        var 技能item5 = Instantiate(Resources.Load("Prefabs/Window/技能树/技能树item"), content.transform)
            .GetComponent<技能树item>();
        技能item5.HeroType = HeroType;
        技能item5.行 = 行;
        技能item5.列 = 5;
        技能item5.SetItem();
        
        var 技能item6 = Instantiate(Resources.Load("Prefabs/Window/技能树/技能树item"), content.transform)
            .GetComponent<技能树item>();
        技能item6.HeroType = HeroType;
        技能item6.行 = 行;
        技能item6.列 = 6;
        技能item6.SetItem();
        
        var 技能item7 = Instantiate(Resources.Load("Prefabs/Window/技能树/技能树item"), content.transform)
            .GetComponent<技能树item>();
        技能item7.HeroType = HeroType;
        技能item7.行 = 行;
        技能item7.列 = 7;
        技能item7.SetItem();
        
        var 技能item8 = Instantiate(Resources.Load("Prefabs/Window/技能树/技能树item"), content.transform)
            .GetComponent<技能树item>();
        技能item8.HeroType = HeroType;
        技能item8.行 = 行;
        技能item8.列 = 8;
        技能item8.SetItem();
        
        
        
        
    }

}
