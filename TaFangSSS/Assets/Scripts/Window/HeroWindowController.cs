using System;
using Config;

public enum 当前显示关卡类型
{
    None,
    主线关卡,
    凌霄宝殿,
    三十三重天,
    混沌虚空,
    不周山,
    世界树,
    血海,
    通天塔,
}
public class HeroWindowController:XSingleton<HeroWindowController>
{
    //herowindow
    [NonSerialized] public bool IsDrag = false;
    [NonSerialized] public bool IsJiaoHuan = false;
    [NonSerialized] public HeroType DragHero = HeroType.None;
    [NonSerialized]public HeroItem 交换HeroItem;
    
    //道纹
    [NonSerialized]public bool 道纹IsDrag = false;
    [NonSerialized] public 道纹Type 道纹Type;
    [NonSerialized] public QualityType 道纹QualityType;

    [NonSerialized] public 当前显示关卡类型 当前显示关卡类型;
    [NonSerialized] public 主线关卡Type 当前主线关卡Type;
    [NonSerialized] public 主线关卡Type 当前凌霄宝殿Type;
    [NonSerialized] public 主线关卡Type 当前三十三重天Type;

    [NonSerialized] public int 显示混沌虚空层数 = 0; 

    //城墙
    [NonSerialized]public bool 城墙IsDrag = false;
    [NonSerialized] public 城墙道具Type 城墙道具Type;
    //通天塔
    [NonSerialized] public int 当前通天塔层数;
    [NonSerialized]public HeroType 通天塔当前选择派遣HeroType;
    [NonSerialized] public int 通天塔英雄派遣Index;
    
    //世界树
    [NonSerialized] public int 当前世界树层数;
    [NonSerialized]public HeroType 世界树当前选择派遣HeroType;
    [NonSerialized] public int 世界树英雄派遣Index;
    
    //血海
    [NonSerialized] public int 当前血海层数;
    [NonSerialized]public HeroType 血海当前选择派遣HeroType;
    [NonSerialized] public int 血海英雄派遣Index;
    
    //不周山
    [NonSerialized] public int 当前不周山层数;
    [NonSerialized]public HeroType 不周山当前选择派遣HeroType;
    [NonSerialized] public int 不周山英雄派遣Index;
}
