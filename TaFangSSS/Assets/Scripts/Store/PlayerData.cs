using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class PlayerData : XSingleton<PlayerData>
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

    public Dictionary<LevelBigType, bool> LevelBigJieSuoDic = new Dictionary<LevelBigType, bool>()
    {
        { LevelBigType.东胜神州, true },
        { LevelBigType.西牛贺洲, false },
        { LevelBigType.南瞻部洲, false },
        { LevelBigType.北俱芦洲, false },
    };

    public Dictionary<LevelSmallType, bool> LevelSmallJieSuoDic = new Dictionary<LevelSmallType, bool>()
    {
        { LevelSmallType.花果山, true },
        { LevelSmallType.水帘洞, false },
        { LevelSmallType.傲来国, false },
        { LevelSmallType.东海龙宫, false },
        { LevelSmallType.蓬莱仙岛, false },
        { LevelSmallType.五行山, false },
        { LevelSmallType.高老庄, false },
        { LevelSmallType.平顶山, false },
        { LevelSmallType.车迟国, false },
        { LevelSmallType.女儿国, false },
        { LevelSmallType.火焰山, false },
        { LevelSmallType.盘丝洞, false },
        { LevelSmallType.狮驼岭, false },
        { LevelSmallType.天竺国, false },
        { LevelSmallType.小雷音寺, false },
        { LevelSmallType.流沙河, false },
        { LevelSmallType.芭蕉洞, false },
    };
}
