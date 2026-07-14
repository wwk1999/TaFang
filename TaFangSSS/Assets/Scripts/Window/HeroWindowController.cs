using System;
using Config;

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

    [NonSerialized] public 主线关卡Type 当前凌霄宝殿Type;
}
