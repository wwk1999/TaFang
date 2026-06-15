using System;
using System.Collections;
using System.Collections.Generic;
using Config;
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
    芭蕉洞,
    流沙河,
    小雷音寺,
}

public enum LevelBigType
{
    None,
    东胜神州,
    南瞻部洲,
    西牛贺洲,
    北俱芦洲,
}

public class LevelDiaoLuo
{
    public int maxCount;
    public int minCount;
    public PropType PropType;
}

public class LevelConfig : MonoBehaviour
{
   public static Dictionary<LevelSmallType, HashSet<MonsterTypeName>> LevelMonsterDic =
    new Dictionary<LevelSmallType, HashSet<MonsterTypeName>>()
    {
        // 花果山
        { LevelSmallType.花果山, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.猴精, MonsterTypeName.山魈, MonsterTypeName.马猴头领 } },
        // 水帘洞
        { LevelSmallType.水帘洞, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.水虱精, MonsterTypeName.蝙蝠精, MonsterTypeName.铁背苍猿 } },
        // 傲来国
        { LevelSmallType.傲来国, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.傲来民兵, MonsterTypeName.猎户, MonsterTypeName.傲来偏将 } },
        // 东海龙宫
        { LevelSmallType.东海龙宫, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.虾兵, MonsterTypeName.蟹将, MonsterTypeName.龟丞相 } },
        // 蓬莱仙岛
        { LevelSmallType.蓬莱仙岛, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.仙鹤, MonsterTypeName.灵芝童, MonsterTypeName.蓬莱剑仙 } },
        // 五行山
        { LevelSmallType.五行山, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.山石精, MonsterTypeName.土蝼, MonsterTypeName.五行山神 } },
        // 高老庄
        { LevelSmallType.高老庄, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.野猪精, MonsterTypeName.高才, MonsterTypeName.高太公 } },
        // 平顶山
        { LevelSmallType.平顶山, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.莲花洞小妖, MonsterTypeName.狐阿七, MonsterTypeName.银角大王 } },
        // 车迟国
        { LevelSmallType.车迟国, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.虎力弟子, MonsterTypeName.鹿力弟子, MonsterTypeName.羊力大仙 } },
        // 女儿国
        { LevelSmallType.女儿国, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.女儿国兵, MonsterTypeName.落胎泉守护, MonsterTypeName.太师 } },
        // 火焰山
        { LevelSmallType.火焰山, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.火焰精, MonsterTypeName.赤蛇, MonsterTypeName.火鸦 } },
        // 盘丝洞
        { LevelSmallType.盘丝洞, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.小蜘蛛, MonsterTypeName.毒蛾, MonsterTypeName.蜘蛛精 } },
        // 狮驼岭
        { LevelSmallType.狮驼岭, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.青狮精手下, MonsterTypeName.白象精手下, MonsterTypeName.大鹏金翅雕 } },
        // 天竺国
        { LevelSmallType.天竺国, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.天竺舞女, MonsterTypeName.月宫侍卫, MonsterTypeName.素娥 } },
        // 芭蕉洞
        { LevelSmallType.芭蕉洞, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.芭蕉精, MonsterTypeName.火焰童, MonsterTypeName.铁扇侍女 } },
        // 流沙河
        { LevelSmallType.流沙河, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.流沙精, MonsterTypeName.水鬼, MonsterTypeName.水蛇妖 } },
        // 小雷音寺
        { LevelSmallType.小雷音寺, new HashSet<MonsterTypeName>() { 
            MonsterTypeName.假罗汉, MonsterTypeName.假金刚, MonsterTypeName.黄眉童子 } }
    };
    public static Dictionary<LevelSmallType, HashSet<LevelDiaoLuo>> LevelDiaoLuoDic =
        new Dictionary<LevelSmallType, HashSet<LevelDiaoLuo>>()
        {
            {
                LevelSmallType.花果山,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 60, minCount = 50, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.水帘洞,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 70, minCount = 60, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.傲来国,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 80, minCount = 70, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.东海龙宫,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 150, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 150, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 150, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 150, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 150, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 150, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.蓬莱仙岛,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 250, minCount = 200, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 250, minCount = 200, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 250, minCount = 200, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 250, minCount = 200, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 250, minCount = 200, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 250, minCount = 200, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.五行山,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.高老庄,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 180, minCount = 150, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 350, minCount = 300, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 350, minCount = 300, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 350, minCount = 300, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 350, minCount = 300, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 350, minCount = 300, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 350, minCount = 300, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.平顶山,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 210, minCount = 180, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 400, minCount = 350, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 400, minCount = 350, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 400, minCount = 350, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 400, minCount = 350, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 400, minCount = 350, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 400, minCount = 350, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.车迟国,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 250, minCount = 210, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500, minCount = 400, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 500, minCount = 400, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 500, minCount = 400, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 500, minCount = 400, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 500, minCount = 400, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 500, minCount = 400, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.女儿国,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.火焰山,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 400, minCount = 350, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.盘丝洞,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500, minCount = 450, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 800, minCount = 700, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 800, minCount = 700, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 800, minCount = 700, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 800, minCount = 700, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 800, minCount = 700, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 800, minCount = 700, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.狮驼岭,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 900, minCount = 800, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 900, minCount = 800, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 900, minCount = 800, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 900, minCount = 800, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 900, minCount = 800, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 900, minCount = 800, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.天竺国,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 900, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 900, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 900, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 900, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 900, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 900, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.芭蕉洞,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 800, minCount = 700, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1200, minCount = 1000, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 1200, minCount = 1000, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 1200, minCount = 1000, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 1200, minCount = 1000, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 1200, minCount = 1000, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 1200, minCount = 1000, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.流沙河,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 900, minCount = 800, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1400, minCount = 1200, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 1400, minCount = 1200, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 1400, minCount = 1200, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 1400, minCount = 1200, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 1400, minCount = 1200, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 1400, minCount = 1200, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.招募卷 },
                }
            },
            
            {
                LevelSmallType.小雷音寺,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 900, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1600, minCount = 1400, PropType = PropType.领主经验值 },
                    new LevelDiaoLuo() { maxCount = 1600, minCount = 1400, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 1600, minCount = 1400, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 1600, minCount = 1400, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 1600, minCount = 1400, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 1600, minCount = 1400, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.招募卷 },
                }
            },
        };

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
