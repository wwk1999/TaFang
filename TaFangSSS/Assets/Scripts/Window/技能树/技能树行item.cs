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
        箭头1.gameObject.SetActive(list[1].是否有前置&&list[1].技能Type!=技能Type.None);
        箭头2.gameObject.SetActive(list[2].是否有前置&&list[2].技能Type!=技能Type.None);
        箭头3.gameObject.SetActive(list[3].是否有前置&&list[3].技能Type!=技能Type.None);
        箭头4.gameObject.SetActive(list[4].是否有前置&&list[4].技能Type!=技能Type.None);
        箭头5.gameObject.SetActive(list[5].是否有前置&&list[5].技能Type!=技能Type.None);
        箭头6.gameObject.SetActive(list[6].是否有前置&&list[6].技能Type!=技能Type.None);
        箭头7.gameObject.SetActive(list[7].是否有前置&&list[7].技能Type!=技能Type.None);
        技能1.行 = 行;
        技能1.列 = 1;
        技能1.HeroType=HeroType;
        技能1.SetItem();
        
        技能2.行 = 行;
        技能2.列 = 2;
        技能2.HeroType=HeroType;
        技能2.SetItem();
        
        技能3.行 = 行;
        技能3.列 = 3;
        技能3.HeroType=HeroType;
        技能3.SetItem();
        
        技能4.行 = 行;
        技能4.列 = 4;
        技能4.HeroType=HeroType;
        技能4.SetItem();
        
        技能5.行 = 行;
        技能5.列 = 5;
        技能5.HeroType=HeroType;
        技能5.SetItem();
        
        技能6.行 = 行;
        技能6.列 = 6;
        技能6.HeroType=HeroType;
        技能6.SetItem();
        
        技能7.行 = 行;
        技能7.列 = 7;
        技能7.HeroType=HeroType;
        技能7.SetItem();
        
        技能8.行 = 行;
        技能8.列 = 8;
        技能8.HeroType=HeroType;
        技能8.SetItem();
        
    }

}
