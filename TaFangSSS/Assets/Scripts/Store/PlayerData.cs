using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class PlayerData : XSingleton<PlayerData>
{
    public string Name = "白辰";
    public JingJieType JingJieType = JingJieType.练气;
    public int Exp;
    public int LingQi;
    public int GongDe;
    public Dictionary<int, List<HeroType>> 出战英雄List = new Dictionary<int, List<HeroType>>()
    {
        { 0, new List<HeroType>()},
        { 1, new List<HeroType>()},
        { 2, new List<HeroType>()},
        { 3, new List<HeroType>()},
    };

    public Dictionary<HeroType, HeroData> HeroDataDic = new Dictionary<HeroType, HeroData>()
    {
        { HeroType.丹童, new HeroData() { Level = 1, 元神 = 0 } },
        { HeroType.青童, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.土地, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.河伯, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.瑶池仙女, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.精卫, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.石敢当, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.玄女, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.龟丞相, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.太白金星, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.孟婆, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.白素贞, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.多闻天王, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.增长天王, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.广目天王, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.持国天王, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.雷震子, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.月老, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.嫦娥, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.何仙姑, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.杨戬, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.妲己, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.牛魔王, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.哪吒, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.孙悟空, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.刑天, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.碧霄, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.琼霄, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.金灵圣母, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.羲和, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.常羲, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.后羿, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.云霄, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.女娲, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.接引, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.准提, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.老子, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.通天, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.元始, new HeroData() { Level = 0, 元神 = 0 } },
    };

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
        { LevelBigType.东胜神州, false },
        { LevelBigType.西牛贺洲, false },
        { LevelBigType.南瞻部洲, false },
        { LevelBigType.北俱芦洲, false },
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
