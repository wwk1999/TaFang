using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelSmallType
{
    None,
    花果山,
    水帘洞,
    傲来国,
    东海龙宫,
    蓬莱仙岛,
    五行山,
    高老庄,
    平顶山,
    车迟国,
    女儿国,
    火焰山,
    盘丝洞,
    狮驼岭,
    天竺国,
    小雷音寺,
    流沙河,
    芭蕉洞,
}

public enum LevelBigType
{
    None,
    东胜神州,
    南瞻部洲,
    西牛贺洲,
    北俱芦洲,
}
public class LevelConfig : MonoBehaviour
{
    public static Dictionary<LevelBigType, string> LevelBigNameDic = new Dictionary<LevelBigType, string>()
    {
        { LevelBigType.东胜神州, "东胜神州" },
        { LevelBigType.南瞻部洲, "南瞻部洲" },
        { LevelBigType.西牛贺洲, "西牛贺洲" },
        { LevelBigType.北俱芦洲, "北俱芦洲" },
    };

    public static Dictionary<LevelSmallType, string> LevelSmallNameDic = new Dictionary<LevelSmallType, string>()
    {
        { LevelSmallType.花果山, "花果山" },
        { LevelSmallType.水帘洞, "水帘洞" },
        { LevelSmallType.傲来国, "傲来国" },
        { LevelSmallType.东海龙宫, "东海龙宫" },
        { LevelSmallType.蓬莱仙岛, "蓬莱仙岛" },
        { LevelSmallType.五行山, "五行山" },
        { LevelSmallType.高老庄, "高老庄" },
        { LevelSmallType.平顶山, "平顶山" },
        { LevelSmallType.车迟国, "车迟国" },
        { LevelSmallType.女儿国, "女儿国" },
        { LevelSmallType.火焰山, "火焰山" },
        { LevelSmallType.盘丝洞, "盘丝洞" },
        { LevelSmallType.狮驼岭, "狮驼岭" },
        { LevelSmallType.天竺国, "天竺国" },
        { LevelSmallType.流沙河, "流沙河" },
        { LevelSmallType.芭蕉洞, "芭蕉洞" },
        { LevelSmallType.小雷音寺, "小雷音寺" },
    };
}
