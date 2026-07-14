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
  // 女儿国
  女儿国兵,
  女儿国将,
  女儿国太师,
  女儿国国王,
  // 火焰山
  火焰精,
  赤蛇,
  红孩儿,
  牛魔王,
  // 狮驼岭
  青狮精手下,
  白象精手下,
  大鹏金翅雕,
  青狮精,
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
  // 冥府
  牛头,
  马面,
  判官,
  阎罗王,

  // ==================== 天庭篇（凌霄宝殿十大关） ====================
  // 南天门
  天兵,
  天将,
  守卫统领,
  巨灵王,
  // 瑶池仙境
  瑶池仙女,
  瑶池守卫,
  仙女首领,
  西王母,
  // 斩妖台
  执法天兵,
  执法天将,
  斩妖剑侍,
  天刑星君,
  // 御马监
  天马精,
  监丞侍卫,
  弼马温,
  天马星君,
  // 蟠桃园
  桃园力士,
  桃园仙女,
  蟠桃守卫,
  蟠桃树精,
  // 兜率宫
  炼丹道童,
  烧火道童,
  兜率宫侍卫,
  太上老君,
  // 紫微宫
  紫微星侍,
  天罡星卒,
  北极星君,
  紫微大帝,
  // 昊天殿
  镇殿守卫,
  镇殿天将,
  九龙神卫,
  玉皇大帝,
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
    { MonsterTypeName.通臂猿猴, Monster特性Type.普通怪 },

    // 水帘洞
    { MonsterTypeName.水虱精, Monster特性Type.普通怪 },
    { MonsterTypeName.蝙蝠精, Monster特性Type.普通怪 },
    { MonsterTypeName.铁背苍猿, Monster特性Type.普通怪 },
    { MonsterTypeName.水帘洞主, Monster特性Type.普通怪 },

    // 傲来国
    { MonsterTypeName.傲来民兵, Monster特性Type.普通怪 },
    { MonsterTypeName.猎户, Monster特性Type.普通怪 },
    { MonsterTypeName.傲来偏将, Monster特性Type.普通怪 },
    { MonsterTypeName.傲来国师, Monster特性Type.普通怪 },

    // 东海龙宫
    { MonsterTypeName.虾兵, Monster特性Type.普通怪 },
    { MonsterTypeName.蟹将, Monster特性Type.普通怪 },
    { MonsterTypeName.东海龙王, Monster特性Type.普通怪 },
    { MonsterTypeName.龟丞相, Monster特性Type.普通怪 },

    // 蓬莱仙岛
    { MonsterTypeName.仙鹤, Monster特性Type.普通怪 },
    { MonsterTypeName.灵芝童, Monster特性Type.普通怪 },
    { MonsterTypeName.蓬莱剑仙, Monster特性Type.普通怪 },
    { MonsterTypeName.蓬莱岛主, Monster特性Type.普通怪 },

    // 五行山
    { MonsterTypeName.山石精, Monster特性Type.普通怪 },
    { MonsterTypeName.土蝼, Monster特性Type.普通怪 },
    { MonsterTypeName.五行山神, Monster特性Type.普通怪 },
    { MonsterTypeName.压山符灵, Monster特性Type.普通怪 },

    // 高老庄
    { MonsterTypeName.野猪精, Monster特性Type.普通怪 },
    { MonsterTypeName.高才, Monster特性Type.普通怪 },
    { MonsterTypeName.高太公, Monster特性Type.普通怪 },
    { MonsterTypeName.猪刚鬣, Monster特性Type.普通怪 },

    // 平顶山
    { MonsterTypeName.莲花洞小妖, Monster特性Type.普通怪 },
    { MonsterTypeName.狐阿七, Monster特性Type.普通怪 },
    { MonsterTypeName.银角大王, Monster特性Type.普通怪 },
    { MonsterTypeName.金角大王, Monster特性Type.普通怪 },

    // 女儿国
    { MonsterTypeName.女儿国兵, Monster特性Type.普通怪 },
    { MonsterTypeName.女儿国将, Monster特性Type.普通怪 },
    { MonsterTypeName.女儿国太师, Monster特性Type.普通怪 },
    { MonsterTypeName.女儿国国王, Monster特性Type.普通怪 },

    // 火焰山
    { MonsterTypeName.火焰精, Monster特性Type.普通怪 },
    { MonsterTypeName.赤蛇, Monster特性Type.普通怪 },
    { MonsterTypeName.红孩儿, Monster特性Type.普通怪 },
    { MonsterTypeName.牛魔王, Monster特性Type.普通怪 },

    // 狮驼岭
    { MonsterTypeName.青狮精手下, Monster特性Type.普通怪 },
    { MonsterTypeName.白象精手下, Monster特性Type.普通怪 },
    { MonsterTypeName.大鹏金翅雕, Monster特性Type.普通怪 },
    { MonsterTypeName.青狮精, Monster特性Type.普通怪 },

    // 小雷音寺
    { MonsterTypeName.假罗汉, Monster特性Type.普通怪 },
    { MonsterTypeName.假金刚, Monster特性Type.普通怪 },
    { MonsterTypeName.黄眉童子, Monster特性Type.普通怪 },
    { MonsterTypeName.黄眉老祖, Monster特性Type.普通怪 },

    // 流沙河
    { MonsterTypeName.流沙精, Monster特性Type.普通怪 },
    { MonsterTypeName.水鬼, Monster特性Type.普通怪 },
    { MonsterTypeName.水蛇妖, Monster特性Type.普通怪 },
    { MonsterTypeName.沙和尚, Monster特性Type.普通怪 },

    // 芭蕉洞
    { MonsterTypeName.芭蕉精, Monster特性Type.普通怪 },
    { MonsterTypeName.火焰童, Monster特性Type.普通怪 },
    { MonsterTypeName.铁扇侍女, Monster特性Type.普通怪 },
    { MonsterTypeName.铁扇公主, Monster特性Type.普通怪 },

    // 冥府
    { MonsterTypeName.牛头, Monster特性Type.普通怪 },
    { MonsterTypeName.马面, Monster特性Type.普通怪 },
    { MonsterTypeName.判官, Monster特性Type.普通怪 },
    { MonsterTypeName.阎罗王, Monster特性Type.普通怪 },

    // ==================== 天庭篇（凌霄宝殿十大关） ====================
    // 南天门
    { MonsterTypeName.天兵, Monster特性Type.普通怪 },
    { MonsterTypeName.天将, Monster特性Type.普通怪 },
    { MonsterTypeName.守卫统领, Monster特性Type.普通怪 },
    { MonsterTypeName.巨灵王, Monster特性Type.普通怪 },

    // 瑶池仙境
    { MonsterTypeName.瑶池仙女, Monster特性Type.普通怪 },
    { MonsterTypeName.瑶池守卫, Monster特性Type.普通怪 },
    { MonsterTypeName.仙女首领, Monster特性Type.普通怪 },
    { MonsterTypeName.西王母, Monster特性Type.普通怪 },

    // 斩妖台
    { MonsterTypeName.执法天兵, Monster特性Type.普通怪 },
    { MonsterTypeName.执法天将, Monster特性Type.普通怪 },
    { MonsterTypeName.斩妖剑侍, Monster特性Type.普通怪 },
    { MonsterTypeName.天刑星君, Monster特性Type.普通怪 },

    // 御马监
    { MonsterTypeName.天马精, Monster特性Type.普通怪 },
    { MonsterTypeName.监丞侍卫, Monster特性Type.普通怪 },
    { MonsterTypeName.弼马温, Monster特性Type.普通怪 },
    { MonsterTypeName.天马星君, Monster特性Type.普通怪 },

    // 蟠桃园
    { MonsterTypeName.桃园力士, Monster特性Type.普通怪 },
    { MonsterTypeName.桃园仙女, Monster特性Type.普通怪 },
    { MonsterTypeName.蟠桃守卫, Monster特性Type.普通怪 },
    { MonsterTypeName.蟠桃树精, Monster特性Type.普通怪 },

    // 兜率宫
    { MonsterTypeName.炼丹道童, Monster特性Type.普通怪 },
    { MonsterTypeName.烧火道童, Monster特性Type.普通怪 },
    { MonsterTypeName.兜率宫侍卫, Monster特性Type.普通怪 },
    { MonsterTypeName.太上老君, Monster特性Type.普通怪 },

    // 紫微宫
    { MonsterTypeName.紫微星侍, Monster特性Type.普通怪 },
    { MonsterTypeName.天罡星卒, Monster特性Type.普通怪 },
    { MonsterTypeName.北极星君, Monster特性Type.普通怪 },
    { MonsterTypeName.紫微大帝, Monster特性Type.普通怪 },

    // 昊天殿
    { MonsterTypeName.镇殿守卫, Monster特性Type.普通怪 },
    { MonsterTypeName.镇殿天将, Monster特性Type.普通怪 },
    { MonsterTypeName.九龙神卫, Monster特性Type.普通怪 },
    { MonsterTypeName.玉皇大帝, Monster特性Type.普通怪 },
};
  
 public static Dictionary<普通关卡怪物Item, MonsterAttribute> 普通关卡怪物属性Dic = new Dictionary<普通关卡怪物Item, MonsterAttribute>()
{
    // ========== 原有部分（第1~15关）==========
    // 花果山 (第1关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 100, Attack = 10, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 500, Attack = 50, Defense = 10, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 1000, Attack = 100, Defense = 20, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 水帘洞 (第2关) - 1.3倍
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 130, Attack = 13, Defense = 7, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 650, Attack = 65, Defense = 14, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 1300, Attack = 130, Defense = 28, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 蓬莱仙岛 (第3关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 169, Attack = 17, Defense = 9, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 845, Attack = 85, Defense = 18, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 1690, Attack = 170, Defense = 36, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 五行山 (第4关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 220, Attack = 22, Defense = 11, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1100, Attack = 110, Defense = 22, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 2200, Attack = 220, Defense = 44, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 傲来国 (第5关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 286, Attack = 29, Defense = 14, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1430, Attack = 145, Defense = 28, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 2860, Attack = 290, Defense = 56, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 高老庄 (第6关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 372, Attack = 37, Defense = 18, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1860, Attack = 185, Defense = 36, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 3720, Attack = 370, Defense = 72, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 女儿国 (第7关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 484, Attack = 48, Defense = 24, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 2420, Attack = 240, Defense = 48, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 4840, Attack = 480, Defense = 96, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 小雷音寺 (第8关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 629, Attack = 63, Defense = 31, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 3145, Attack = 315, Defense = 62, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 6290, Attack = 630, Defense = 124, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 平顶山 (第9关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 818, Attack = 82, Defense = 41, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 4090, Attack = 410, Defense = 82, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 8180, Attack = 820, Defense = 164, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 火焰山 (第10关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 1063, Attack = 106, Defense = 53, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 5315, Attack = 530, Defense = 106, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 10630, Attack = 1060, Defense = 212, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 芭蕉洞 (第11关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 1382, Attack = 138, Defense = 69, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 6910, Attack = 690, Defense = 138, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 13820, Attack = 1380, Defense = 276, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 流沙河 (第12关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 1797, Attack = 180, Defense = 90, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 8985, Attack = 900, Defense = 180, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 17970, Attack = 1800, Defense = 360, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 狮驼岭 (第13关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 2336, Attack = 234, Defense = 117, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 11680, Attack = 1170, Defense = 234, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 23360, Attack = 2340, Defense = 468, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 东海龙宫 (第14关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 3037, Attack = 304, Defense = 152, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 15185, Attack = 1520, Defense = 304, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 30370, Attack = 3040, Defense = 608, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 冥府 (第15关)
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.冥府, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 3948, Attack = 395, Defense = 198, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.冥府, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 19740, Attack = 1975, Defense = 396, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.冥府, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 39480, Attack = 3950, Defense = 792, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },


    // ==================== 天庭篇（凌霄宝殿十大关 · 第16~23关）====================

    // 南天门 (第16关) - 花果山基础 × 1.3^15 ≈ 154.3倍
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.南天门, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 15430, Attack = 1543, Defense = 772, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.南天门, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 77150, Attack = 7715, Defense = 1544, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.南天门, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 154300, Attack = 15430, Defense = 3088, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 瑶池仙境 (第17关) - 花果山基础 × 1.3^16 ≈ 200.6倍
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.瑶池仙境, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 20060, Attack = 2006, Defense = 1003, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.瑶池仙境, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 100300, Attack = 10030, Defense = 2006, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.瑶池仙境, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 200600, Attack = 20060, Defense = 4012, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 斩妖台 (第18关) - 花果山基础 × 1.3^17 ≈ 260.8倍
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.斩妖台, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 26080, Attack = 2608, Defense = 1304, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.斩妖台, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 130400, Attack = 13040, Defense = 2608, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.斩妖台, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 260800, Attack = 26080, Defense = 5216, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 御马监 (第19关) - 花果山基础 × 1.3^18 ≈ 339.0倍
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.御马监, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 33900, Attack = 3390, Defense = 1695, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.御马监, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 169500, Attack = 16950, Defense = 3390, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.御马监, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 339000, Attack = 33900, Defense = 6780, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 蟠桃园 (第20关) - 花果山基础 × 1.3^19 ≈ 440.7倍
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.蟠桃园, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 44070, Attack = 4407, Defense = 2204, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.蟠桃园, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 220350, Attack = 22035, Defense = 4408, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.蟠桃园, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 440700, Attack = 44070, Defense = 8816, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 兜率宫 (第21关) - 花果山基础 × 1.3^20 ≈ 572.9倍
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.兜率宫, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 57290, Attack = 5729, Defense = 2865, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.兜率宫, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 286450, Attack = 28645, Defense = 5730, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.兜率宫, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 572900, Attack = 57290, Defense = 11460, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 紫微宫 (第22关) - 花果山基础 × 1.3^21 ≈ 744.8倍
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.紫微宫, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 74480, Attack = 7448, Defense = 3724, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.紫微宫, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 372400, Attack = 37240, Defense = 7448, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.紫微宫, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 744800, Attack = 74480, Defense = 14896, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 昊天殿 (第23关 / 最终关) - 花果山基础 × 1.3^22 ≈ 968.2倍
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.昊天殿, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 96820, Attack = 9682, Defense = 4841, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.昊天殿, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 484100, Attack = 48410, Defense = 9682, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 普通关卡怪物Item() { 主线关卡Type = 主线关卡Type.昊天殿, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 968200, Attack = 96820, Defense = 19364, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
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
            { MonsterTypeName.龟丞相, MonsterType.Elite },
            { MonsterTypeName.东海龙王, MonsterType.Boss },

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

            // 女儿国
            { MonsterTypeName.女儿国兵, MonsterType.Normal },
            { MonsterTypeName.女儿国将, MonsterType.Normal },
            { MonsterTypeName.女儿国太师, MonsterType.Elite },
            { MonsterTypeName.女儿国国王, MonsterType.Boss },

            // 火焰山
            { MonsterTypeName.火焰精, MonsterType.Normal },
            { MonsterTypeName.赤蛇, MonsterType.Normal },
            { MonsterTypeName.红孩儿, MonsterType.Elite },
            { MonsterTypeName.牛魔王, MonsterType.Boss },

            // 狮驼岭
            { MonsterTypeName.青狮精手下, MonsterType.Normal },
            { MonsterTypeName.白象精手下, MonsterType.Normal },
            { MonsterTypeName.大鹏金翅雕, MonsterType.Elite },
            { MonsterTypeName.青狮精, MonsterType.Boss },

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

            // 冥府
            { MonsterTypeName.牛头, MonsterType.Normal },
            { MonsterTypeName.马面, MonsterType.Normal },
            { MonsterTypeName.判官, MonsterType.Elite },
            { MonsterTypeName.阎罗王, MonsterType.Boss },

            // ==================== 天庭篇（凌霄宝殿十大关） ====================
            // 南天门
            { MonsterTypeName.天兵, MonsterType.Normal },
            { MonsterTypeName.天将, MonsterType.Normal },
            { MonsterTypeName.守卫统领, MonsterType.Elite },
            { MonsterTypeName.巨灵王, MonsterType.Boss },

            // 瑶池仙境
            { MonsterTypeName.瑶池守卫, MonsterType.Normal },
            { MonsterTypeName.瑶池仙女, MonsterType.Normal },
            { MonsterTypeName.仙女首领, MonsterType.Elite },  // 已在狮驼岭出现，这里复用但作为精英
            { MonsterTypeName.西王母, MonsterType.Boss },

            // 斩妖台
            { MonsterTypeName.执法天兵, MonsterType.Normal },
            { MonsterTypeName.执法天将, MonsterType.Normal },
            { MonsterTypeName.斩妖剑侍, MonsterType.Elite },
            { MonsterTypeName.天刑星君, MonsterType.Boss },

            // 御马监
            { MonsterTypeName.天马精, MonsterType.Normal },
            { MonsterTypeName.监丞侍卫, MonsterType.Normal },
            { MonsterTypeName.弼马温, MonsterType.Elite },
            { MonsterTypeName.天马星君, MonsterType.Boss },

            // 蟠桃园
            { MonsterTypeName.桃园力士, MonsterType.Normal },
            { MonsterTypeName.桃园仙女, MonsterType.Normal },
            { MonsterTypeName.蟠桃守卫, MonsterType.Elite },
            { MonsterTypeName.蟠桃树精, MonsterType.Boss },  // 复用，但蟠桃园是西王母的地盘，合理

            // 兜率宫
            { MonsterTypeName.炼丹道童, MonsterType.Normal },
            { MonsterTypeName.烧火道童, MonsterType.Normal },
            { MonsterTypeName.兜率宫侍卫, MonsterType.Elite },
            { MonsterTypeName.太上老君, MonsterType.Boss },

            // 紫微宫
            { MonsterTypeName.紫微星侍, MonsterType.Normal },
            { MonsterTypeName.天罡星卒, MonsterType.Normal },
            { MonsterTypeName.北极星君, MonsterType.Elite },
            { MonsterTypeName.紫微大帝, MonsterType.Boss },

            // 昊天殿
            { MonsterTypeName.镇殿守卫, MonsterType.Normal },
            { MonsterTypeName.镇殿天将, MonsterType.Normal },
            { MonsterTypeName.九龙神卫, MonsterType.Elite },
            { MonsterTypeName.玉皇大帝, MonsterType.Boss },
        };
}
