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

public enum Monster特性Type
{
  None,
  普通怪,
  肉盾怪,
  高速怪,
  自爆怪,
  回复怪,
  远程怪,
}

public class 普通关卡怪物Item
{
  public 主线关卡Type 主线关卡Type { get; set; }
  public MonsterType MonsterType { get; set; }

  public override bool Equals(object obj)
  {
    if (obj == null || GetType() != obj.GetType())
      return false;
    普通关卡怪物Item other = (普通关卡怪物Item)obj;
    return 主线关卡Type == other.主线关卡Type && MonsterType == other.MonsterType;
  }

  public override int GetHashCode()
  {
    return (LevelSmallType: 主线关卡Type, MonsterType).GetHashCode();
  }
}

public class MonsterAttribute
{
    public float Hp;
    public float Attack;
    public float Defense;
    public float 物理抗性;
    public float 冰霜抗性;
    public float 火焰抗性;
    public float 黑暗抗性;
    public float 雷电抗性;

}

public class MonsterConfig : MonoBehaviour
{

  public static Dictionary<Monster特性Type, float> 怪物速度Dic = new Dictionary<Monster特性Type, float>()
  {
    { Monster特性Type.普通怪,1},
    { Monster特性Type.肉盾怪,1},
    { Monster特性Type.高速怪,1},
    { Monster特性Type.回复怪,1},
    { Monster特性Type.自爆怪,1},
    { Monster特性Type.远程怪,1},
  };

  public static Dictionary<MonsterTypeName, Monster特性Type> 怪物特性Dic = new Dictionary<MonsterTypeName, Monster特性Type>()
{
    // 花果山
    { MonsterTypeName.猴精, Monster特性Type.普通怪 },
    { MonsterTypeName.山魈, Monster特性Type.普通怪 },
    { MonsterTypeName.马猴头领, Monster特性Type.普通怪 },

    // 水帘洞
    { MonsterTypeName.水虱精, Monster特性Type.普通怪 },
    { MonsterTypeName.蝙蝠精, Monster特性Type.普通怪 },
    { MonsterTypeName.铁背苍猿, Monster特性Type.普通怪 },

    // 傲来国
    { MonsterTypeName.傲来民兵, Monster特性Type.普通怪 },
    { MonsterTypeName.猎户, Monster特性Type.普通怪 },
    { MonsterTypeName.傲来偏将, Monster特性Type.普通怪 },

    // 东海龙宫
    { MonsterTypeName.虾兵, Monster特性Type.普通怪 },
    { MonsterTypeName.蟹将, Monster特性Type.普通怪 },
    { MonsterTypeName.龟丞相, Monster特性Type.普通怪 },

    // 蓬莱仙岛
    { MonsterTypeName.仙鹤, Monster特性Type.普通怪 },
    { MonsterTypeName.灵芝童, Monster特性Type.普通怪 },
    { MonsterTypeName.蓬莱剑仙, Monster特性Type.普通怪 },

    // 五行山
    { MonsterTypeName.山石精, Monster特性Type.普通怪 },
    { MonsterTypeName.土蝼, Monster特性Type.普通怪 },
    { MonsterTypeName.五行山神, Monster特性Type.普通怪 },

    // 高老庄
    { MonsterTypeName.野猪精, Monster特性Type.普通怪 },
    { MonsterTypeName.高才, Monster特性Type.普通怪 },
    { MonsterTypeName.高太公, Monster特性Type.普通怪 },

    // 平顶山
    { MonsterTypeName.莲花洞小妖, Monster特性Type.普通怪 },
    { MonsterTypeName.狐阿七, Monster特性Type.普通怪 },
    { MonsterTypeName.银角大王, Monster特性Type.普通怪 },

    // 车迟国
    { MonsterTypeName.虎力弟子, Monster特性Type.普通怪 },
    { MonsterTypeName.鹿力弟子, Monster特性Type.普通怪 },
    { MonsterTypeName.羊力大仙, Monster特性Type.普通怪 },

    // 女儿国
    { MonsterTypeName.女儿国兵, Monster特性Type.普通怪 },
    { MonsterTypeName.落胎泉守护, Monster特性Type.普通怪 },
    { MonsterTypeName.太师, Monster特性Type.普通怪 },

    // 火焰山
    { MonsterTypeName.火焰精, Monster特性Type.普通怪 },
    { MonsterTypeName.赤蛇, Monster特性Type.普通怪 },
    { MonsterTypeName.火鸦, Monster特性Type.普通怪 },

    // 盘丝洞
    { MonsterTypeName.小蜘蛛, Monster特性Type.普通怪 },
    { MonsterTypeName.毒蛾, Monster特性Type.普通怪 },
    { MonsterTypeName.蜘蛛精, Monster特性Type.普通怪 },

    // 狮驼岭
    { MonsterTypeName.青狮精手下, Monster特性Type.普通怪 },
    { MonsterTypeName.白象精手下, Monster特性Type.普通怪 },
    { MonsterTypeName.大鹏金翅雕, Monster特性Type.普通怪 },

    // 天竺国
    { MonsterTypeName.天竺舞女, Monster特性Type.普通怪 },
    { MonsterTypeName.月宫侍卫, Monster特性Type.普通怪 },
    { MonsterTypeName.素娥, Monster特性Type.普通怪 },

    // 芭蕉洞
    { MonsterTypeName.芭蕉精, Monster特性Type.普通怪 },
    { MonsterTypeName.火焰童, Monster特性Type.普通怪 },
    { MonsterTypeName.铁扇侍女, Monster特性Type.普通怪 },

    // 流沙河
    { MonsterTypeName.流沙精, Monster特性Type.普通怪 },
    { MonsterTypeName.水鬼, Monster特性Type.普通怪 },
    { MonsterTypeName.水蛇妖, Monster特性Type.普通怪 },

    // 小雷音寺
    { MonsterTypeName.假罗汉, Monster特性Type.普通怪 },
    { MonsterTypeName.假金刚, Monster特性Type.普通怪 },
    { MonsterTypeName.黄眉童子, Monster特性Type.普通怪 }
};
  
  public static Dictionary<MonsterTypeName, 主线关卡Type> MonsterLevelDic =
    new Dictionary<MonsterTypeName, 主线关卡Type>()
    {
        // 花果山
        { MonsterTypeName.猴精, 主线关卡Type.花果山 },
        { MonsterTypeName.山魈, 主线关卡Type.花果山 },
        { MonsterTypeName.马猴头领, 主线关卡Type.花果山 },
        // 水帘洞
        { MonsterTypeName.水虱精, 主线关卡Type.水帘洞 },
        { MonsterTypeName.蝙蝠精, 主线关卡Type.水帘洞 },
        { MonsterTypeName.铁背苍猿, 主线关卡Type.水帘洞 },
        // 傲来国
        { MonsterTypeName.傲来民兵, 主线关卡Type.傲来国 },
        { MonsterTypeName.猎户, 主线关卡Type.傲来国 },
        { MonsterTypeName.傲来偏将, 主线关卡Type.傲来国 },
        // 东海龙宫
        { MonsterTypeName.虾兵, 主线关卡Type.东海龙宫 },
        { MonsterTypeName.蟹将, 主线关卡Type.东海龙宫 },
        { MonsterTypeName.龟丞相, 主线关卡Type.东海龙宫 },
        // 蓬莱仙岛
        { MonsterTypeName.仙鹤, 主线关卡Type.蓬莱仙岛 },
        { MonsterTypeName.灵芝童, 主线关卡Type.蓬莱仙岛 },
        { MonsterTypeName.蓬莱剑仙, 主线关卡Type.蓬莱仙岛 },
        // 五行山
        { MonsterTypeName.山石精, 主线关卡Type.五行山 },
        { MonsterTypeName.土蝼, 主线关卡Type.五行山 },
        { MonsterTypeName.五行山神, 主线关卡Type.五行山 },
        // 高老庄
        { MonsterTypeName.野猪精, 主线关卡Type.高老庄 },
        { MonsterTypeName.高才, 主线关卡Type.高老庄 },
        { MonsterTypeName.高太公, 主线关卡Type.高老庄 },
        // 平顶山
        { MonsterTypeName.莲花洞小妖, 主线关卡Type.平顶山 },
        { MonsterTypeName.狐阿七, 主线关卡Type.平顶山 },
        { MonsterTypeName.银角大王, 主线关卡Type.平顶山 },
      
        // 女儿国
        { MonsterTypeName.女儿国兵, 主线关卡Type.女儿国 },
        { MonsterTypeName.落胎泉守护, 主线关卡Type.女儿国 },
        { MonsterTypeName.太师, 主线关卡Type.女儿国 },
        // 火焰山
        { MonsterTypeName.火焰精, 主线关卡Type.火焰山 },
        { MonsterTypeName.赤蛇, 主线关卡Type.火焰山 },
        { MonsterTypeName.火鸦, 主线关卡Type.火焰山 },
       
        // 狮驼岭
        { MonsterTypeName.青狮精手下, 主线关卡Type.狮驼岭 },
        { MonsterTypeName.白象精手下, 主线关卡Type.狮驼岭 },
        { MonsterTypeName.大鹏金翅雕, 主线关卡Type.狮驼岭 },
        
        // 芭蕉洞
        { MonsterTypeName.芭蕉精, 主线关卡Type.芭蕉洞 },
        { MonsterTypeName.火焰童, 主线关卡Type.芭蕉洞 },
        { MonsterTypeName.铁扇侍女, 主线关卡Type.芭蕉洞 },
        // 流沙河
        { MonsterTypeName.流沙精, 主线关卡Type.流沙河 },
        { MonsterTypeName.水鬼, 主线关卡Type.流沙河 },
        { MonsterTypeName.水蛇妖, 主线关卡Type.流沙河 },
        // 小雷音寺
        { MonsterTypeName.假罗汉, 主线关卡Type.小雷音寺 },
        { MonsterTypeName.假金刚, 主线关卡Type.小雷音寺 },
        { MonsterTypeName.黄眉童子, 主线关卡Type.小雷音寺 }
    };
 public static Dictionary<普通关卡怪物Item, MonsterAttribute> 普通关卡怪物属性Dic = new Dictionary<普通关卡怪物Item, MonsterAttribute>()
{
    // 花果山
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 100, Attack = 10, Defense = 0, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1000, Attack = 125, Defense = 0, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },

    // 水帘洞
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 120, Attack = 12, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1200, Attack = 150, Defense = 10, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },

    // 傲来国
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 140, Attack = 14, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1400, Attack = 175, Defense = 10, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },

    // 东海龙宫
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 160, Attack = 16, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1600, Attack = 200, Defense = 10, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },

    // 蓬莱仙岛
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 200, Attack = 20, Defense = 10, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 2000, Attack = 250, Defense = 20, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },

    // 五行山
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 240, Attack = 24, Defense = 10, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 2400, Attack = 300, Defense = 20, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },

    // 高老庄
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 280, Attack = 28, Defense = 10, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 2800, Attack = 350, Defense = 20, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },

    // 平顶山
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 320, Attack = 32, Defense = 10, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 3200, Attack = 400, Defense = 20, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },

   
    // 女儿国
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 480, Attack = 48, Defense = 20, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 4800, Attack = 600, Defense = 40, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },

    // 火焰山
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 560, Attack = 56, Defense = 20, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 5600, Attack = 700, Defense = 40, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },

   
    // 狮驼岭
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 800, Attack = 80, Defense = 30, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 8000, Attack = 1000, Defense = 60, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },


    // 芭蕉洞
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 1200, Attack = 120, Defense = 30, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 12000, Attack = 1500, Defense = 60, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },

    // 流沙河
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 1400, Attack = 140, Defense = 30, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 14000, Attack = 1750, Defense = 60, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },

    // 小雷音寺
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 1600, Attack = 160, Defense = 30, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 16000, Attack = 2000, Defense = 60, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 } }
};
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
            { MonsterTypeName.龟丞相, MonsterType.Elite }, // 图片中出现的额外小怪

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
