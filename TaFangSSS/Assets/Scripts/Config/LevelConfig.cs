using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using Random = UnityEngine.Random;

public enum 关卡类型
{
    None,
    主线关卡,
}
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
    public static 关卡类型 当前关卡类型 = 关卡类型.主线关卡;
    public static 主线关卡Type 当前主线关卡Type = 主线关卡Type.花果山;
    public static Dictionary<主线关卡Type, int> 主线关卡通关奖励Dic = new Dictionary<主线关卡Type, int>()
    {
        { 主线关卡Type.花果山, 5 },
        { 主线关卡Type.水帘洞, 5 },
        { 主线关卡Type.蓬莱仙岛, 10 },
        { 主线关卡Type.五行山, 10 },
        { 主线关卡Type.傲来国, 15 },
        { 主线关卡Type.高老庄, 15 },
        { 主线关卡Type.女儿国, 20 },
        { 主线关卡Type.小雷音寺, 20 },
        { 主线关卡Type.平顶山, 25 },
        { 主线关卡Type.火焰山, 25 },
        { 主线关卡Type.芭蕉洞, 30 },
        { 主线关卡Type.流沙河, 30 },
        { 主线关卡Type.狮驼岭, 35 },
        { 主线关卡Type.东海龙宫,35 },
        { 主线关卡Type.冥府, 35 },
    };
    public static Dictionary<主线关卡Type, JingJieType> 主线关卡境界Dic = new Dictionary<主线关卡Type, JingJieType>()
    {
        { 主线关卡Type.花果山, JingJieType.练气 },
        { 主线关卡Type.水帘洞, JingJieType.练气 },
        { 主线关卡Type.蓬莱仙岛, JingJieType.筑基 },
        { 主线关卡Type.五行山, JingJieType.筑基 },
        { 主线关卡Type.傲来国, JingJieType.金丹 },
        { 主线关卡Type.高老庄, JingJieType.金丹 },
        { 主线关卡Type.女儿国, JingJieType.元婴 },
        { 主线关卡Type.小雷音寺, JingJieType.元婴 },
        { 主线关卡Type.平顶山, JingJieType.化神 },
        { 主线关卡Type.火焰山, JingJieType.化神 },
        { 主线关卡Type.芭蕉洞, JingJieType.合体 },
        { 主线关卡Type.流沙河, JingJieType.合体 },
        { 主线关卡Type.狮驼岭, JingJieType.大乘 },
        { 主线关卡Type.东海龙宫,JingJieType.大乘 },
        { 主线关卡Type.冥府, JingJieType.大乘 },
    };
    public static Dictionary<主线关卡Type, string> 主线关卡介绍Dic = new Dictionary<主线关卡Type, string>()
    {
        { 主线关卡Type.花果山, "美猴王诞生之地，十洲之祖脉，三岛之来龙。群山叠翠，灵猴嬉戏，仙气缭绕，孕育天地灵根之处。" },
        { 主线关卡Type.水帘洞, "花果山福地，水帘洞洞天。飞瀑倒挂，隐有石室，乃齐天大圣昔日称王之所，内有石桌石椅，别有洞天。" },
        { 主线关卡Type.蓬莱仙岛, "东海三仙山之一，琼楼玉宇，遍地灵芝。岛上白鹤飞舞，仙雾弥漫，乃海外仙人聚居修行的清静圣地。" },
        { 主线关卡Type.五行山, "如来五指所化神山，分金木水火土五形。山下压有神猴，仅露头颅，山势险峻，上有镇压封印之贴。" },
        { 主线关卡Type.傲来国, "东胜神洲海外小国，花果山近邻。国中百姓以渔猎为生，市井喧嚣，常闻海上仙山奇闻异事。" },
        { 主线关卡Type.高老庄, "乌斯藏国富庶庄园，庄主高太公宅邸。良田千顷，屋舍俨然，因猪妖入赘一事而名扬四海。" },
        { 主线关卡Type.女儿国, "西梁女国，一国尽是红粉。城中街道繁华，女子当政，民风奇特，城外有子母河，饮者皆孕。" },
        { 主线关卡Type.小雷音寺, "黄眉怪幻化之小西天，庙宇巍峨，禅音阵阵，实则处处陷阱。内有金铙、人种袋等佛门法宝。" },
        { 主线关卡Type.平顶山, "山脉连绵，峰峦如削，山上松柏苍翠，山中藏有莲花洞。金角银角二妖据守此山，拦路索宝。" },
        { 主线关卡Type.火焰山, "八百里火焰，无春无秋，四季皆热。赤地千里，寸草不生，唯有铁扇公主之宝扇可灭此烈火。" },
        { 主线关卡Type.芭蕉洞, "翠云山深处幽洞，铁扇公主修炼洞府。洞前芭蕉茂密，洞内阴凉幽静，藏有先天至宝芭蕉扇。" },
        { 主线关卡Type.流沙河, "八百余里宽，鹅毛浮不起，芦花定底沉。弱水三千，汹涌澎湃，河中隐有妖魔兴风作浪。" },
        { 主线关卡Type.狮驼岭, "八百里狮驼岭，白骨嶙峋，妖气冲天。青狮、白象、大鹏三魔在此结盟，为西天路上最凶险之地。" },
        { 主线关卡Type.东海龙宫, "水晶宫中明珠闪烁，珊瑚成林。龙王敖广坐镇于此，藏有如意金箍棒定海神针，虾兵蟹将无数。" },
        { 主线关卡Type.冥府, "幽暗地界，阴风阵阵，鬼门关后便是幽冥地府。内有判官生死簿，十殿阎罗执掌生死轮回。" },
    };

    public static Dictionary<主线关卡Type, SmallLevelInfo> LevelInfos = new Dictionary<主线关卡Type, SmallLevelInfo>()
{
    { 主线关卡Type.花果山, new SmallLevelInfo() { NormalMonsterCount = 10, CreateNormalMonsterTime = 1f, EliteMonsterCount = 1} },
    { 主线关卡Type.水帘洞, new SmallLevelInfo() { NormalMonsterCount = 110, CreateNormalMonsterTime = 1f, EliteMonsterCount = 1 } },
    { 主线关卡Type.傲来国, new SmallLevelInfo() { NormalMonsterCount = 120, CreateNormalMonsterTime = 1f, EliteMonsterCount = 1} },
    { 主线关卡Type.东海龙宫, new SmallLevelInfo() { NormalMonsterCount = 130, CreateNormalMonsterTime = 1f, EliteMonsterCount = 1} },
    { 主线关卡Type.蓬莱仙岛, new SmallLevelInfo() { NormalMonsterCount = 140, CreateNormalMonsterTime = 0.9f, EliteMonsterCount = 2 } },
    { 主线关卡Type.五行山, new SmallLevelInfo() { NormalMonsterCount = 150, CreateNormalMonsterTime = 0.9f, EliteMonsterCount = 2 } },
    { 主线关卡Type.高老庄, new SmallLevelInfo() { NormalMonsterCount = 160, CreateNormalMonsterTime = 0.9f, EliteMonsterCount = 2 } },
    { 主线关卡Type.平顶山, new SmallLevelInfo() { NormalMonsterCount = 170, CreateNormalMonsterTime = 0.9f, EliteMonsterCount = 2 } },
    { 主线关卡Type.女儿国, new SmallLevelInfo() { NormalMonsterCount = 190, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 3 } },
    { 主线关卡Type.火焰山, new SmallLevelInfo() { NormalMonsterCount = 200, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 3} },
    { 主线关卡Type.狮驼岭, new SmallLevelInfo() { NormalMonsterCount = 220, CreateNormalMonsterTime = 0.7f, EliteMonsterCount = 4 } },
    { 主线关卡Type.芭蕉洞, new SmallLevelInfo() { NormalMonsterCount = 240, CreateNormalMonsterTime = 0.7f, EliteMonsterCount = 4 } },
    { 主线关卡Type.流沙河, new SmallLevelInfo() { NormalMonsterCount = 250, CreateNormalMonsterTime = 0.7f, EliteMonsterCount = 4 } },
    { 主线关卡Type.小雷音寺, new SmallLevelInfo() { NormalMonsterCount = 260, CreateNormalMonsterTime = 0.7f, EliteMonsterCount = 4 } }
};
   public static Dictionary<主线关卡Type, List<MonsterTypeName>> LevelMonsterDic =
    new Dictionary<主线关卡Type, List<MonsterTypeName>>()
    {
        // 花果山
        { 主线关卡Type.花果山, new List<MonsterTypeName>() { 
            MonsterTypeName.猴精, MonsterTypeName.山魈, MonsterTypeName.马猴头领, MonsterTypeName.通臂猿猴 } },
        // 水帘洞
        { 主线关卡Type.水帘洞, new List<MonsterTypeName>() { 
            MonsterTypeName.水虱精, MonsterTypeName.蝙蝠精, MonsterTypeName.铁背苍猿, MonsterTypeName.水帘洞主 } },
        // 傲来国
        { 主线关卡Type.傲来国, new List<MonsterTypeName>() { 
            MonsterTypeName.傲来民兵, MonsterTypeName.猎户, MonsterTypeName.傲来偏将, MonsterTypeName.傲来国师 } },
        // 东海龙宫
        { 主线关卡Type.东海龙宫, new List<MonsterTypeName>() { 
            MonsterTypeName.虾兵, MonsterTypeName.蟹将, MonsterTypeName.龟丞相, MonsterTypeName.东海龙王 } },
        // 蓬莱仙岛
        { 主线关卡Type.蓬莱仙岛, new List<MonsterTypeName>() { 
            MonsterTypeName.仙鹤, MonsterTypeName.灵芝童, MonsterTypeName.蓬莱剑仙, MonsterTypeName.蓬莱岛主 } },
        // 五行山
        { 主线关卡Type.五行山, new List<MonsterTypeName>() { 
            MonsterTypeName.山石精, MonsterTypeName.土蝼, MonsterTypeName.五行山神, MonsterTypeName.压山符灵 } },
        // 高老庄
        { 主线关卡Type.高老庄, new List<MonsterTypeName>() { 
            MonsterTypeName.野猪精, MonsterTypeName.高才, MonsterTypeName.高太公, MonsterTypeName.猪刚鬣 } },
        // 平顶山
        { 主线关卡Type.平顶山, new List<MonsterTypeName>() { 
            MonsterTypeName.莲花洞小妖, MonsterTypeName.狐阿七, MonsterTypeName.银角大王, MonsterTypeName.金角大王 } },
        // 女儿国
        { 主线关卡Type.女儿国, new List<MonsterTypeName>() { 
            MonsterTypeName.女儿国兵, MonsterTypeName.女儿国将, MonsterTypeName.女儿国太师, MonsterTypeName.女儿国国王 } },
        // 火焰山
        { 主线关卡Type.火焰山, new List<MonsterTypeName>() { 
            MonsterTypeName.火焰精, MonsterTypeName.赤蛇, MonsterTypeName.红孩儿, MonsterTypeName.牛魔王 } },
        // 芭蕉洞
        { 主线关卡Type.芭蕉洞, new List<MonsterTypeName>() { 
            MonsterTypeName.芭蕉精, MonsterTypeName.火焰童, MonsterTypeName.铁扇侍女, MonsterTypeName.铁扇公主 } },
        // 流沙河
        { 主线关卡Type.流沙河, new List<MonsterTypeName>() { 
            MonsterTypeName.流沙精, MonsterTypeName.水鬼, MonsterTypeName.水蛇妖, MonsterTypeName.沙和尚 } },
        // 小雷音寺
        { 主线关卡Type.小雷音寺, new List<MonsterTypeName>() { 
            MonsterTypeName.假罗汉, MonsterTypeName.假金刚, MonsterTypeName.黄眉童子, MonsterTypeName.黄眉老祖 } },
        // 狮驼岭
        { 主线关卡Type.狮驼岭, new List<MonsterTypeName>() { 
            MonsterTypeName.青狮精手下, MonsterTypeName.白象精手下, MonsterTypeName.大鹏金翅雕, MonsterTypeName.青狮精 } },
        // 冥府
        { 主线关卡Type.冥府, new List<MonsterTypeName>() { 
            MonsterTypeName.牛头, MonsterTypeName.马面, MonsterTypeName.判官, MonsterTypeName.阎罗王 } }
    };
   public static 普通关卡胜利奖励 Get胜利奖励()
   {
       HashSet<LevelDiaoLuo> list = LevelDiaoLuoDic[当前主线关卡Type];
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

   

    public static Dictionary<主线关卡Type, string> 主线关卡NameDic = new Dictionary<主线关卡Type, string>()
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
