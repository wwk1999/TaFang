using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreDefine : XSingleton<StoreController>
{
    public class StoreData
    {
        public PlayData Player = new PlayData();
    }

    public class PlayData
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

        public void CopyFromRuntime(PlayerData runtime)
        {
            Name = runtime.Name;
            JingJieType = runtime.JingJieType;
            Exp = runtime.Exp;
            LingQi = runtime.LingQi;
            GongDe = runtime.GongDe;
            LevelZhanKaiDic = runtime.LevelZhanKaiDic;
        }

        public void ApplyToRuntime(PlayerData runtime)
        {
            runtime.Name = Name;
            runtime.JingJieType = JingJieType;
            runtime.Exp = Exp;
            runtime.LingQi = LingQi;
            runtime.GongDe = GongDe;
            runtime.LevelZhanKaiDic = LevelZhanKaiDic;
        }
    }
}
