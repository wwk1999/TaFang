using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : XSingleton<PlayerData>
{
    public string Name="白辰";
    public JingJieType JingJieType=JingJieType.练气;
    public int Exp;
    public int LingQi;
    public int GongDe;
}
