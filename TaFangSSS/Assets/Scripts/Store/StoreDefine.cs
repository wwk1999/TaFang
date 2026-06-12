using System.Collections;
using System.Collections.Generic;
using Config;
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
        public Dictionary<PropType, int> PropCountDic = new Dictionary<PropType, int>()
        {
            { PropType.领主经验值, 0 },
            { PropType.全职业经验值, 0 },
            { PropType.功德, 0 },
            { PropType.头盔锻造石, 0 },
            { PropType.射手经验值, 0 },
            { PropType.戒指锻造石, 0 },
            { PropType.战士经验值, 0 },
            { PropType.护手锻造石, 0 },
            { PropType.招募卷, 0 },
            { PropType.控制经验值, 0 },
            { PropType.法师经验值, 0 },
            { PropType.洗练石, 0 },
            { PropType.灵魂, 0 },
            { PropType.衣服锻造石, 0 },
            { PropType.辅助经验值, 0 },
            { PropType.鞋子锻造石, 0 },
            { PropType.项链锻造石, 0 },
            { PropType.高级招募卷, 0 }
        };
        
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
            PropCountDic= runtime.PropCountDic;
        }

        public void ApplyToRuntime(PlayerData runtime)
        {
            runtime.Name = Name;
            runtime.JingJieType = JingJieType;
            runtime.Exp = Exp;
            runtime.LingQi = LingQi;
            runtime.GongDe = GongDe;
            runtime.LevelZhanKaiDic = LevelZhanKaiDic;
            runtime.PropCountDic = PropCountDic;
        }
    }
}
