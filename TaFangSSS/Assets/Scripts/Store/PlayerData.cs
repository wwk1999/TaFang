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

    public Dictionary<LevelBigType, bool> LevelZhanKaiDic = new Dictionary<LevelBigType, bool>()
    {
        { LevelBigType.东胜神州 ,false },
        { LevelBigType.西牛贺洲 ,false },
        { LevelBigType.南瞻部洲 ,false },
        { LevelBigType.北俱芦洲 ,false },
    };
}
