using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using Random = UnityEngine.Random;

public enum 主线关卡Type
{
    None,
    花果山,
    水帘洞,
    蓬莱仙岛,
    五行山,
    傲来国,
    高老庄, 
    女儿国,
    小雷音寺,
    平顶山,
    火焰山, 
    芭蕉洞,
    流沙河,
    狮驼岭,
    东海龙宫,
    冥府,
}

public class LevelDiaoLuo
{
    public int maxCount;
    public int minCount;
    public PropType PropType;
}

public class SmallLevelInfo
{
    public int NormalMonsterCount;
    public float CreateNormalMonsterTime;
    public int EliteMonsterCount;
    public float CreateEliteMonsterTime;

}

public class 普通关卡胜利奖励
{
    public int 灵魂;
    public int 领主经验值;
    public int 射手经验值;
    public int 法师经验值;
    public int 战士经验值;
    public int 辅助经验值;
    public int 控制经验值;
    public int 衣服锻造石;
    public int 鞋子锻造石;
    public int 头盔锻造石;
    public int 项链锻造石;
    public int 戒指锻造石;
    public int 护手锻造石;
    public int 招募卷;

}

public class LevelConfig : MonoBehaviour
{
    public static 主线关卡Type  Current主线关卡Type=主线关卡Type.None;

    public static Dictionary<主线关卡Type, SmallLevelInfo> LevelInfos = new Dictionary<主线关卡Type, SmallLevelInfo>()
{
    { 主线关卡Type.花果山, new SmallLevelInfo() { NormalMonsterCount = 10, CreateNormalMonsterTime = 1f, EliteMonsterCount = 1, CreateEliteMonsterTime = 5f } },
    { 主线关卡Type.水帘洞, new SmallLevelInfo() { NormalMonsterCount = 110, CreateNormalMonsterTime = 1f, EliteMonsterCount = 1, CreateEliteMonsterTime = 55f } },
    { 主线关卡Type.傲来国, new SmallLevelInfo() { NormalMonsterCount = 120, CreateNormalMonsterTime = 1f, EliteMonsterCount = 1, CreateEliteMonsterTime = 60f } },
    { 主线关卡Type.东海龙宫, new SmallLevelInfo() { NormalMonsterCount = 130, CreateNormalMonsterTime = 1f, EliteMonsterCount = 1, CreateEliteMonsterTime = 65f } },
    { 主线关卡Type.蓬莱仙岛, new SmallLevelInfo() { NormalMonsterCount = 140, CreateNormalMonsterTime = 0.9f, EliteMonsterCount = 2, CreateEliteMonsterTime = 70f } },
    { 主线关卡Type.五行山, new SmallLevelInfo() { NormalMonsterCount = 150, CreateNormalMonsterTime = 0.9f, EliteMonsterCount = 2, CreateEliteMonsterTime = 75f } },
    { 主线关卡Type.高老庄, new SmallLevelInfo() { NormalMonsterCount = 160, CreateNormalMonsterTime = 0.9f, EliteMonsterCount = 2, CreateEliteMonsterTime = 80f } },
    { 主线关卡Type.平顶山, new SmallLevelInfo() { NormalMonsterCount = 170, CreateNormalMonsterTime = 0.9f, EliteMonsterCount = 2, CreateEliteMonsterTime = 85f } },
    { 主线关卡Type.女儿国, new SmallLevelInfo() { NormalMonsterCount = 190, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 3, CreateEliteMonsterTime = 95f } },
    { 主线关卡Type.火焰山, new SmallLevelInfo() { NormalMonsterCount = 200, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 3, CreateEliteMonsterTime = 100f } },
    { 主线关卡Type.狮驼岭, new SmallLevelInfo() { NormalMonsterCount = 220, CreateNormalMonsterTime = 0.7f, EliteMonsterCount = 4, CreateEliteMonsterTime = 110f } },
    { 主线关卡Type.芭蕉洞, new SmallLevelInfo() { NormalMonsterCount = 240, CreateNormalMonsterTime = 0.7f, EliteMonsterCount = 4, CreateEliteMonsterTime = 120f } },
    { 主线关卡Type.流沙河, new SmallLevelInfo() { NormalMonsterCount = 250, CreateNormalMonsterTime = 0.7f, EliteMonsterCount = 4, CreateEliteMonsterTime = 125f } },
    { 主线关卡Type.小雷音寺, new SmallLevelInfo() { NormalMonsterCount = 260, CreateNormalMonsterTime = 0.7f, EliteMonsterCount = 4, CreateEliteMonsterTime = 130f } }
};
   public static Dictionary<主线关卡Type, List<MonsterTypeName>> LevelMonsterDic =
    new Dictionary<主线关卡Type, List<MonsterTypeName>>()
    {
        // 花果山
        { 主线关卡Type.花果山, new List<MonsterTypeName>() { 
            MonsterTypeName.猴精, MonsterTypeName.山魈, MonsterTypeName.马猴头领 } },
        // 水帘洞
        { 主线关卡Type.水帘洞, new List<MonsterTypeName>() { 
            MonsterTypeName.水虱精, MonsterTypeName.蝙蝠精, MonsterTypeName.铁背苍猿 } },
        // 傲来国
        { 主线关卡Type.傲来国, new List<MonsterTypeName>() { 
            MonsterTypeName.傲来民兵, MonsterTypeName.猎户, MonsterTypeName.傲来偏将 } },
        // 东海龙宫
        { 主线关卡Type.东海龙宫, new List<MonsterTypeName>() { 
            MonsterTypeName.虾兵, MonsterTypeName.蟹将, MonsterTypeName.龟丞相 } },
        // 蓬莱仙岛
        { 主线关卡Type.蓬莱仙岛, new List<MonsterTypeName>() { 
            MonsterTypeName.仙鹤, MonsterTypeName.灵芝童, MonsterTypeName.蓬莱剑仙 } },
        // 五行山
        { 主线关卡Type.五行山, new List<MonsterTypeName>() { 
            MonsterTypeName.山石精, MonsterTypeName.土蝼, MonsterTypeName.五行山神 } },
        // 高老庄
        { 主线关卡Type.高老庄, new List<MonsterTypeName>() { 
            MonsterTypeName.野猪精, MonsterTypeName.高才, MonsterTypeName.高太公 } },
        // 平顶山
        { 主线关卡Type.平顶山, new List<MonsterTypeName>() { 
            MonsterTypeName.莲花洞小妖, MonsterTypeName.狐阿七, MonsterTypeName.银角大王 } },
        // 女儿国
        { 主线关卡Type.女儿国, new List<MonsterTypeName>() { 
            MonsterTypeName.女儿国兵, MonsterTypeName.落胎泉守护, MonsterTypeName.太师 } },
        // 火焰山
        { 主线关卡Type.火焰山, new List<MonsterTypeName>() { 
            MonsterTypeName.火焰精, MonsterTypeName.赤蛇, MonsterTypeName.火鸦 } },
        // 狮驼岭
        { 主线关卡Type.狮驼岭, new List<MonsterTypeName>() { 
            MonsterTypeName.青狮精手下, MonsterTypeName.白象精手下, MonsterTypeName.大鹏金翅雕 } },
       // 芭蕉洞
        { 主线关卡Type.芭蕉洞, new List<MonsterTypeName>() { 
            MonsterTypeName.芭蕉精, MonsterTypeName.火焰童, MonsterTypeName.铁扇侍女 } },
        // 流沙河
        { 主线关卡Type.流沙河, new List<MonsterTypeName>() { 
            MonsterTypeName.流沙精, MonsterTypeName.水鬼, MonsterTypeName.水蛇妖 } },
        // 小雷音寺
        { 主线关卡Type.小雷音寺, new List<MonsterTypeName>() { 
            MonsterTypeName.假罗汉, MonsterTypeName.假金刚, MonsterTypeName.黄眉童子 } },
        // 小雷音寺
        { 主线关卡Type.冥府, new List<MonsterTypeName>() { 
            MonsterTypeName.假罗汉, MonsterTypeName.假金刚, MonsterTypeName.黄眉童子 } }
    };

   public static 普通关卡胜利奖励 Get胜利奖励()
   {
       HashSet<LevelDiaoLuo> list = LevelDiaoLuoDic[Current主线关卡Type];
       普通关卡胜利奖励 value = new 普通关卡胜利奖励();
       foreach (var item in list)
       {
           int random=Random.Range(item.minCount,item.maxCount+1);
           switch (item.PropType)
           {
               case PropType.灵魂:
                   value.灵魂 = random;
                   break;
               case PropType.领主经验值:
                   value.领主经验值 = random;
                   break;
               case PropType.射手经验值:
                   value.射手经验值 = random;
                   break;
               case PropType.法师经验值:
                   value.法师经验值 = random;
                   break;
               case PropType.控制经验值:
                   value.控制经验值 = random;
                   break;
               case PropType.战士经验值:
                   value.战士经验值 = random;
                   break;
               case PropType.辅助经验值:
                   value.辅助经验值 = random;
                   break;
               case PropType.衣服锻造石:
                   value.衣服锻造石 = random;
                   break;
               case PropType.头盔锻造石:
                   value.头盔锻造石 = random;
                   break;
               case PropType.鞋子锻造石:
                   value.鞋子锻造石 = random;
                   break;
               case PropType.护手锻造石:
                   value.护手锻造石 = random;
                   break;
               case PropType.戒指锻造石:
                   value.戒指锻造石 = random;
                   break;
               case PropType.项链锻造石:
                   value.项链锻造石 = random;
                   break;
               case PropType.招募卷:
                   value.招募卷 = random;
                   break;
           }
       }

       return value;
   }
    public static Dictionary<主线关卡Type, HashSet<LevelDiaoLuo>> LevelDiaoLuoDic =
        new Dictionary<主线关卡Type, HashSet<LevelDiaoLuo>>()
        {
            {
                主线关卡Type.花果山,
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
                主线关卡Type.水帘洞,
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
                主线关卡Type.傲来国,
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
                主线关卡Type.东海龙宫,
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
                主线关卡Type.蓬莱仙岛,
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
                主线关卡Type.五行山,
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
                主线关卡Type.高老庄,
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
                主线关卡Type.平顶山,
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
                主线关卡Type.女儿国,
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
                主线关卡Type.火焰山,
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
                主线关卡Type.狮驼岭,
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
                主线关卡Type.芭蕉洞,
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
                主线关卡Type.流沙河,
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
                主线关卡Type.小雷音寺,
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

   

    public static Dictionary<主线关卡Type, string> LevelSmallNameDic = new Dictionary<主线关卡Type, string>()
    {
        { 主线关卡Type.花果山, "花果山" },
        { 主线关卡Type.水帘洞, "水帘洞" },
        { 主线关卡Type.傲来国, "傲来国" },
        { 主线关卡Type.东海龙宫, "东海龙宫" },
        { 主线关卡Type.蓬莱仙岛, "蓬莱仙岛" },
        { 主线关卡Type.五行山, "五行山" },
        { 主线关卡Type.高老庄, "高老庄" },
        { 主线关卡Type.平顶山, "平顶山" },
        { 主线关卡Type.女儿国, "女儿国" },
        { 主线关卡Type.火焰山, "火焰山" },
        { 主线关卡Type.狮驼岭, "狮驼岭" },
        { 主线关卡Type.流沙河, "流沙河" },
        { 主线关卡Type.芭蕉洞, "芭蕉洞" },
        { 主线关卡Type.小雷音寺, "小雷音寺" },
        { 主线关卡Type.冥府, "冥府" },
    };
}
