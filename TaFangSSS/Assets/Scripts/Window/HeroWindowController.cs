using System;
using Config;

public class HeroWindowController:XSingleton<HeroWindowController>
{
    [NonSerialized] public bool IsDrag = false;
    [NonSerialized] public bool IsJiaoHuan = false;
    [NonSerialized] public HeroType DragHero = HeroType.None;
    [NonSerialized] public int CurrentBianDui = 1;
   
}
