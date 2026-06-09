using System.Collections.Generic;
using UnityEngine;

public enum MonsterTypeName
{
    None,
    // 花果山
    猴精,
    山魈,
    马猴头领,
    通臂猿猴,
    // 水帘洞
    水虱精,
    蝙蝠精,
    铁背苍猿,
    水帘洞主,
    // 傲来国
    傲来民兵,
    猎户,
    傲来偏将,
    傲来国师,
    // 东海龙宫
    虾兵,
    蟹将,
    东海龙王,
    龟丞相,
    // 蓬莱仙岛
    仙鹤,
    灵芝童,
    蓬莱剑仙,
    蓬莱岛主,
    // 五行山
    山石精,
    土蝼,
    五行山神,
    压山符灵,
    // 高老庄
    野猪精,
    高才,
    高太公,
    猪刚鬣,
    // 平顶山
    莲花洞小妖,
    狐阿七,
    银角大王,
    金角大王,
    // 车迟国
    虎力弟子,
    鹿力弟子,
    羊力大仙,
    虎力大仙,
    // 女儿国
    女儿国兵,
    落胎泉守护,
    太师,
    女儿国国王,
    // 火焰山
    火焰精,
    赤蛇,
    火鸦,
    火焰山土地,
    // 盘丝洞
    小蜘蛛,
    毒蛾,
    蜘蛛精,
    百眼魔君,
    // 狮驼岭
    青狮精手下,
    白象精手下,
    大鹏金翅雕,
    青狮精,
    // 天竺国
    天竺舞女,
    月宫侍卫,
    素娥,
    玉兔精,
    // 小雷音寺
    假罗汉,
    假金刚,
    黄眉童子,
    黄眉老祖,
    // 流沙河
    流沙精,
    水鬼,
    水蛇妖,
    沙和尚,
    // 芭蕉洞
    芭蕉精,
    火焰童,
    铁扇侍女,
    铁扇公主,
    // 碧波潭
    奔波儿灞,
    灞波儿奔,
    万圣公主,
    九头虫
}

public enum MonsterType
{
    None,
    Normal,
    Elite,
    Boss
}
public class MonsterConfig: MonoBehaviour
{
  public static Dictionary<MonsterTypeName, MonsterType> MonsterTypeDic =
    new Dictionary<MonsterTypeName, MonsterType>()
    {
        // 花果山
        { MonsterTypeName.猴精, MonsterType.Normal },
        { MonsterTypeName.山魈, MonsterType.Normal },
        { MonsterTypeName.马猴头领, MonsterType.Elite },
        { MonsterTypeName.通臂猿猴, MonsterType.Boss },
        
        // 水帘洞
        { MonsterTypeName.水虱精, MonsterType.Normal },
        { MonsterTypeName.蝙蝠精, MonsterType.Normal },
        { MonsterTypeName.铁背苍猿, MonsterType.Elite },
        { MonsterTypeName.水帘洞主, MonsterType.Boss },
        
        // 傲来国
        { MonsterTypeName.傲来民兵, MonsterType.Normal },
        { MonsterTypeName.猎户, MonsterType.Normal },
        { MonsterTypeName.傲来偏将, MonsterType.Elite },
        { MonsterTypeName.傲来国师, MonsterType.Boss },
        
        // 东海龙宫
        { MonsterTypeName.虾兵, MonsterType.Normal },
        { MonsterTypeName.蟹将, MonsterType.Normal },
        { MonsterTypeName.东海龙王, MonsterType.Boss },
        { MonsterTypeName.龟丞相, MonsterType.Elite },  // 图片中出现的额外小怪
        
        // 蓬莱仙岛
        { MonsterTypeName.仙鹤, MonsterType.Normal },
        { MonsterTypeName.灵芝童, MonsterType.Normal },
        { MonsterTypeName.蓬莱剑仙, MonsterType.Elite },
        { MonsterTypeName.蓬莱岛主, MonsterType.Boss },
        
        // 五行山
        { MonsterTypeName.山石精, MonsterType.Normal },
        { MonsterTypeName.土蝼, MonsterType.Normal },
        { MonsterTypeName.五行山神, MonsterType.Elite },
        { MonsterTypeName.压山符灵, MonsterType.Boss },
        
        // 高老庄
        { MonsterTypeName.野猪精, MonsterType.Normal },
        { MonsterTypeName.高才, MonsterType.Normal },
        { MonsterTypeName.高太公, MonsterType.Elite },
        { MonsterTypeName.猪刚鬣, MonsterType.Boss },
        
        // 平顶山
        { MonsterTypeName.莲花洞小妖, MonsterType.Normal },
        { MonsterTypeName.狐阿七, MonsterType.Normal },
        { MonsterTypeName.银角大王, MonsterType.Elite },
        { MonsterTypeName.金角大王, MonsterType.Boss },
        
        // 车迟国
        { MonsterTypeName.虎力弟子, MonsterType.Normal },
        { MonsterTypeName.鹿力弟子, MonsterType.Normal },
        { MonsterTypeName.羊力大仙, MonsterType.Elite },
        { MonsterTypeName.虎力大仙, MonsterType.Boss },
        
        // 女儿国
        { MonsterTypeName.女儿国兵, MonsterType.Normal },
        { MonsterTypeName.落胎泉守护, MonsterType.Normal },
        { MonsterTypeName.太师, MonsterType.Elite },
        { MonsterTypeName.女儿国国王, MonsterType.Boss },
        
        // 火焰山
        { MonsterTypeName.火焰精, MonsterType.Normal },
        { MonsterTypeName.赤蛇, MonsterType.Normal },
        { MonsterTypeName.火鸦, MonsterType.Elite },
        { MonsterTypeName.火焰山土地, MonsterType.Boss },
        
        // 盘丝洞
        { MonsterTypeName.小蜘蛛, MonsterType.Normal },
        { MonsterTypeName.毒蛾, MonsterType.Normal },
        { MonsterTypeName.蜘蛛精, MonsterType.Elite },
        { MonsterTypeName.百眼魔君, MonsterType.Boss },
        
        // 狮驼岭
        { MonsterTypeName.青狮精手下, MonsterType.Normal },
        { MonsterTypeName.白象精手下, MonsterType.Normal },
        { MonsterTypeName.大鹏金翅雕, MonsterType.Elite },
        { MonsterTypeName.青狮精, MonsterType.Boss },
        
        // 天竺国
        { MonsterTypeName.天竺舞女, MonsterType.Normal },
        { MonsterTypeName.月宫侍卫, MonsterType.Normal },
        { MonsterTypeName.素娥, MonsterType.Elite },
        { MonsterTypeName.玉兔精, MonsterType.Boss },
        
        // 小雷音寺
        { MonsterTypeName.假罗汉, MonsterType.Normal },
        { MonsterTypeName.假金刚, MonsterType.Normal },
        { MonsterTypeName.黄眉童子, MonsterType.Elite },
        { MonsterTypeName.黄眉老祖, MonsterType.Boss },
        
        // 流沙河
        { MonsterTypeName.流沙精, MonsterType.Normal },
        { MonsterTypeName.水鬼, MonsterType.Normal },
        { MonsterTypeName.水蛇妖, MonsterType.Elite },
        { MonsterTypeName.沙和尚, MonsterType.Boss },
        
        // 芭蕉洞
        { MonsterTypeName.芭蕉精, MonsterType.Normal },
        { MonsterTypeName.火焰童, MonsterType.Normal },
        { MonsterTypeName.铁扇侍女, MonsterType.Elite },
        { MonsterTypeName.铁扇公主, MonsterType.Boss },
        
        // 碧波潭
        { MonsterTypeName.奔波儿灞, MonsterType.Normal },
        { MonsterTypeName.灞波儿奔, MonsterType.Normal },
        { MonsterTypeName.万圣公主, MonsterType.Elite },
        { MonsterTypeName.九头虫, MonsterType.Boss }
    };
}
