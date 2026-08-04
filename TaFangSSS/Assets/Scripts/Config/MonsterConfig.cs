using System.Collections.Generic;
using UnityEngine;

public enum MonsterTypeName
{
  None,
  // 花果山
  猴精,
  山魈,
  
  水虱精,
  蝙蝠精,
  
  傲来民兵,
  猎户,
  傲来偏将,
  傲来国师,
  // 东海龙宫
  虾兵,
  蟹将,
  龟丞相,       
  东海龙王,
  // 蓬莱仙岛
  仙鹤,
  灵芝童,
  蓬莱剑仙,
  //蓬莱岛主,
  // 五行山
  山石精,
  土蝼,
  五行山神,
  //压山符灵,
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
  // 芭蕉洞
  芭蕉精,
  火焰童,
  铁扇侍女,
  铁扇公主,
  // 流沙河
  流沙精,
  水鬼,
  水蛇妖,
  沙和尚,
  // 小雷音寺
  假罗汉,
  假金刚,
  黄眉童子,
  黄眉老祖,
  // 狮驼岭
  青狮精手下,
  白象精手下,
  大鹏金翅雕,
  青狮精,
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

  // ==================== 登天路 & 六重天/四重天/三清境/大罗天 ====================
  // 登天路
  登天石傀,
  罡风精,
  雷劫之灵,
  守天路神将,
  // 欲界天  
  欲念魅妖,
  幻音雀,
  贪欲魔,
  欲界天魔王,
  // 色界天
  色相天女,
  光音天众,
  形色尊者,
  色界天主,
  // 无色天
  虚灵,
  空无影,
  太虚之魂,
  无色天祖,
  // 四梵天
  梵天守卫,
  净居天人,
  善现尊者,
  四梵天王, 
  // 上清境禹余天
  禹余灵官,
  紫霞仙鹤,
  上清剑侍,
  魔灵宝天尊,
  // 玉清境清微天
  清微仙童,
  玄光玉女,
  玉清道卫,
  魔元始天尊,
  // 太清境大赤天
  大赤丹童,
  炉火精,
  太清护卫,
  魔老子,
  // 大罗天
  弥罗侍卫,
  弥罗宫卫,
  混元道兵,
  魔鸿钧,
  
  //混沌虚空
  混沌蠕虫,
  虚空螯虫,
  虚空巨兽,
  混沌主宰,
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

public class 主线关卡怪物Item
{
  public 主线关卡Type 主线关卡Type { get; set; }
  public MonsterType MonsterType { get; set; }

  public override bool Equals(object obj)
  {
    if (obj == null || GetType() != obj.GetType())
      return false;
    主线关卡怪物Item other = (主线关卡怪物Item)obj;
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
  
  public static Dictionary<MonsterTypeName, bool> 怪物翻转Dic = new Dictionary<MonsterTypeName, bool>()
{
    // 花果山
    { MonsterTypeName.猴精, false },
    { MonsterTypeName.山魈, true },
    

    // 水帘洞
    { MonsterTypeName.水虱精, false },
    { MonsterTypeName.蝙蝠精, true },
   

    // 傲来国
    { MonsterTypeName.傲来民兵, false },
    { MonsterTypeName.猎户, false },
    { MonsterTypeName.傲来偏将, true },
    { MonsterTypeName.傲来国师, true },

    // 东海龙宫
    { MonsterTypeName.虾兵, false },
    { MonsterTypeName.蟹将, false },
    { MonsterTypeName.龟丞相, true },
    { MonsterTypeName.东海龙王, true },

    // 蓬莱仙岛
    { MonsterTypeName.仙鹤, false },
    { MonsterTypeName.灵芝童,false },
    { MonsterTypeName.蓬莱剑仙, false },

    // 五行山
    { MonsterTypeName.山石精, true },
    { MonsterTypeName.土蝼, false },
    { MonsterTypeName.五行山神, false },

    // 高老庄
    { MonsterTypeName.野猪精, false },
    { MonsterTypeName.高才, false },
    { MonsterTypeName.高太公, false },
    { MonsterTypeName.猪刚鬣, false },

    // 平顶山
    { MonsterTypeName.莲花洞小妖, false },
    { MonsterTypeName.狐阿七, false },
    { MonsterTypeName.银角大王, false },
    { MonsterTypeName.金角大王, false },

    // 女儿国
    { MonsterTypeName.女儿国兵, true },
    { MonsterTypeName.女儿国将, true },
    { MonsterTypeName.女儿国太师, true },
    { MonsterTypeName.女儿国国王, true },

    // 火焰山
    { MonsterTypeName.火焰精, false },
    { MonsterTypeName.赤蛇, true },
    { MonsterTypeName.红孩儿, false },
    { MonsterTypeName.牛魔王, true },

    // 芭蕉洞
    { MonsterTypeName.芭蕉精, true },
    { MonsterTypeName.火焰童, true },
    { MonsterTypeName.铁扇侍女, false },
    { MonsterTypeName.铁扇公主, true },

    // 流沙河
    { MonsterTypeName.流沙精, true },
    { MonsterTypeName.水鬼, true },
    { MonsterTypeName.水蛇妖, false },
    { MonsterTypeName.沙和尚, false },

    // 小雷音寺
    { MonsterTypeName.假罗汉, false },
    { MonsterTypeName.假金刚, true },
    { MonsterTypeName.黄眉童子, false },
    { MonsterTypeName.黄眉老祖, true },

    // 狮驼岭
    { MonsterTypeName.青狮精手下, true },
    { MonsterTypeName.白象精手下, true },
    { MonsterTypeName.大鹏金翅雕, false },
    { MonsterTypeName.青狮精, false },

    // 冥府
    { MonsterTypeName.牛头, true },
    { MonsterTypeName.马面, false },
    { MonsterTypeName.判官, true },
    { MonsterTypeName.阎罗王, true },

    // ==================== 天庭篇（凌霄宝殿十大关） ====================
    // 南天门
    { MonsterTypeName.天兵, true },
    { MonsterTypeName.天将, true },
    { MonsterTypeName.守卫统领, true },
    { MonsterTypeName.巨灵王, false },

    // 瑶池仙境
    { MonsterTypeName.瑶池仙女, true },
    { MonsterTypeName.瑶池守卫, true },
    { MonsterTypeName.仙女首领, true },
    { MonsterTypeName.西王母, false },

    // 斩妖台
    { MonsterTypeName.执法天兵, true },
    { MonsterTypeName.执法天将, true },
    { MonsterTypeName.斩妖剑侍, false },
    { MonsterTypeName.天刑星君, false },

    // 御马监
    { MonsterTypeName.天马精, true },
    { MonsterTypeName.监丞侍卫, true },
    { MonsterTypeName.弼马温, true },
    { MonsterTypeName.天马星君, false },

    // 蟠桃园
    { MonsterTypeName.桃园力士, true },
    { MonsterTypeName.桃园仙女, true },
    { MonsterTypeName.蟠桃守卫, false },
    { MonsterTypeName.蟠桃树精, true },

    // 兜率宫
    { MonsterTypeName.炼丹道童, false },
    { MonsterTypeName.烧火道童, false },
    { MonsterTypeName.兜率宫侍卫, true },
    { MonsterTypeName.太上老君, true },

    // 紫微宫
    { MonsterTypeName.紫微星侍, true },
    { MonsterTypeName.天罡星卒, true },
    { MonsterTypeName.北极星君, true },
    { MonsterTypeName.紫微大帝, true },

    // 昊天殿
    { MonsterTypeName.镇殿守卫, true },
    { MonsterTypeName.镇殿天将, true },
    { MonsterTypeName.九龙神卫, true },
    { MonsterTypeName.玉皇大帝, false },

    // ==================== 登天路 & 六重天/四重天/三清境/大罗天 ====================
    // 登天路
    { MonsterTypeName.登天石傀, true },
    { MonsterTypeName.罡风精, false },
    { MonsterTypeName.雷劫之灵, true },
    { MonsterTypeName.守天路神将, false },

    // 欲界天
    { MonsterTypeName.欲念魅妖, false },
    { MonsterTypeName.幻音雀, false },
    { MonsterTypeName.贪欲魔, false },
    { MonsterTypeName.欲界天魔王, false },

    // 色界天
    { MonsterTypeName.色相天女, false },
    { MonsterTypeName.光音天众, true },
    { MonsterTypeName.形色尊者, false },
    { MonsterTypeName.色界天主, false},

    // 无色天
    { MonsterTypeName.虚灵, false },
    { MonsterTypeName.空无影, false },
    { MonsterTypeName.太虚之魂, false },
    { MonsterTypeName.无色天祖, false },

    // 四梵天
    { MonsterTypeName.梵天守卫, true },
    { MonsterTypeName.净居天人, false },
    { MonsterTypeName.善现尊者, true },
    { MonsterTypeName.四梵天王, true },

    // 玉清境清微天
    { MonsterTypeName.清微仙童, true },
    { MonsterTypeName.玄光玉女, false },
    { MonsterTypeName.玉清道卫, true },
    { MonsterTypeName.魔元始天尊, false },

    // 上清境禹余天
    { MonsterTypeName.禹余灵官, false },
    { MonsterTypeName.紫霞仙鹤, false },
    { MonsterTypeName.上清剑侍, false },
    { MonsterTypeName.魔灵宝天尊, false },

    // 太清境大赤天
    { MonsterTypeName.大赤丹童,false },
    { MonsterTypeName.炉火精, false },
    { MonsterTypeName.太清护卫, true },
    { MonsterTypeName.魔老子, false},

    // 大罗天
    { MonsterTypeName.弥罗侍卫, true },
    { MonsterTypeName.弥罗宫卫, false },
    { MonsterTypeName.混元道兵,false },
    { MonsterTypeName.魔鸿钧, false },
    
    // 大罗天
    { MonsterTypeName.混沌蠕虫, false },
    { MonsterTypeName.虚空螯虫, false },
    { MonsterTypeName.虚空巨兽, false },
    { MonsterTypeName.混沌主宰, false },
};
  

 public static Dictionary<MonsterTypeName, Monster特性Type> 怪物特性Dic = new Dictionary<MonsterTypeName, Monster特性Type>()
{
    // 花果山
    { MonsterTypeName.猴精, Monster特性Type.普通怪 },
    { MonsterTypeName.山魈, Monster特性Type.普通怪 },
    

    // 水帘洞
    { MonsterTypeName.水虱精, Monster特性Type.普通怪 },
    { MonsterTypeName.蝙蝠精, Monster特性Type.普通怪 },
   

    // 傲来国
    { MonsterTypeName.傲来民兵, Monster特性Type.普通怪 },
    { MonsterTypeName.猎户, Monster特性Type.普通怪 },
    { MonsterTypeName.傲来偏将, Monster特性Type.普通怪 },
    { MonsterTypeName.傲来国师, Monster特性Type.普通怪 },


    // 东海龙宫
    { MonsterTypeName.虾兵, Monster特性Type.普通怪 },
    { MonsterTypeName.蟹将, Monster特性Type.普通怪 },
    { MonsterTypeName.龟丞相, Monster特性Type.普通怪 },
    { MonsterTypeName.东海龙王, Monster特性Type.普通怪 },

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

    // 芭蕉洞
    { MonsterTypeName.芭蕉精, Monster特性Type.普通怪 },
    { MonsterTypeName.火焰童, Monster特性Type.普通怪 },
    { MonsterTypeName.铁扇侍女, Monster特性Type.普通怪 },
    { MonsterTypeName.铁扇公主, Monster特性Type.普通怪 },

    // 流沙河
    { MonsterTypeName.流沙精, Monster特性Type.普通怪 },
    { MonsterTypeName.水鬼, Monster特性Type.普通怪 },
    { MonsterTypeName.水蛇妖, Monster特性Type.普通怪 },
    { MonsterTypeName.沙和尚, Monster特性Type.普通怪 },

    // 小雷音寺
    { MonsterTypeName.假罗汉, Monster特性Type.普通怪 },
    { MonsterTypeName.假金刚, Monster特性Type.普通怪 },
    { MonsterTypeName.黄眉童子, Monster特性Type.普通怪 },
    { MonsterTypeName.黄眉老祖, Monster特性Type.普通怪 },

    // 狮驼岭
    { MonsterTypeName.青狮精手下, Monster特性Type.普通怪 },
    { MonsterTypeName.白象精手下, Monster特性Type.普通怪 },
    { MonsterTypeName.大鹏金翅雕, Monster特性Type.普通怪 },
    { MonsterTypeName.青狮精, Monster特性Type.普通怪 },

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

    // ==================== 登天路 & 六重天/四重天/三清境/大罗天 ====================
    // 登天路
    { MonsterTypeName.登天石傀, Monster特性Type.普通怪 },
    { MonsterTypeName.罡风精, Monster特性Type.普通怪 },
    { MonsterTypeName.雷劫之灵, Monster特性Type.普通怪 },
    { MonsterTypeName.守天路神将, Monster特性Type.普通怪 },

    // 欲界天
    { MonsterTypeName.欲念魅妖, Monster特性Type.普通怪 },
    { MonsterTypeName.幻音雀, Monster特性Type.普通怪 },
    { MonsterTypeName.贪欲魔, Monster特性Type.普通怪 },
    { MonsterTypeName.欲界天魔王, Monster特性Type.普通怪 },

    // 色界天
    { MonsterTypeName.色相天女, Monster特性Type.普通怪 },
    { MonsterTypeName.光音天众, Monster特性Type.普通怪 },
    { MonsterTypeName.形色尊者, Monster特性Type.普通怪 },
    { MonsterTypeName.色界天主, Monster特性Type.普通怪 },

    // 无色天
    { MonsterTypeName.虚灵, Monster特性Type.普通怪 },
    { MonsterTypeName.空无影, Monster特性Type.普通怪 },
    { MonsterTypeName.太虚之魂, Monster特性Type.普通怪 },
    { MonsterTypeName.无色天祖, Monster特性Type.普通怪 },

    // 四梵天
    { MonsterTypeName.梵天守卫, Monster特性Type.普通怪 },
    { MonsterTypeName.净居天人, Monster特性Type.普通怪 },
    { MonsterTypeName.善现尊者, Monster特性Type.普通怪 },
    { MonsterTypeName.四梵天王, Monster特性Type.普通怪 },

    // 玉清境清微天
    { MonsterTypeName.清微仙童, Monster特性Type.普通怪 },
    { MonsterTypeName.玄光玉女, Monster特性Type.普通怪 },
    { MonsterTypeName.玉清道卫, Monster特性Type.普通怪 },
    { MonsterTypeName.魔元始天尊, Monster特性Type.普通怪 },

    // 上清境禹余天
    { MonsterTypeName.禹余灵官, Monster特性Type.普通怪 },
    { MonsterTypeName.紫霞仙鹤, Monster特性Type.普通怪 },
    { MonsterTypeName.上清剑侍, Monster特性Type.普通怪 },
    { MonsterTypeName.魔灵宝天尊, Monster特性Type.普通怪 },

    // 太清境大赤天
    { MonsterTypeName.大赤丹童, Monster特性Type.普通怪 },
    { MonsterTypeName.炉火精, Monster特性Type.普通怪 },
    { MonsterTypeName.太清护卫, Monster特性Type.普通怪 },
    { MonsterTypeName.魔老子, Monster特性Type.普通怪 },

    // 大罗天
    { MonsterTypeName.弥罗侍卫, Monster特性Type.普通怪 },
    { MonsterTypeName.弥罗宫卫, Monster特性Type.普通怪 },
    { MonsterTypeName.混元道兵, Monster特性Type.普通怪 },
    { MonsterTypeName.魔鸿钧, Monster特性Type.普通怪 },
    
    // 大罗天
    { MonsterTypeName.混沌蠕虫, Monster特性Type.普通怪 },
    { MonsterTypeName.虚空螯虫, Monster特性Type.普通怪 },
    { MonsterTypeName.虚空巨兽, Monster特性Type.普通怪 },
    { MonsterTypeName.混沌主宰, Monster特性Type.普通怪 },
};

public static Dictionary<主线关卡怪物Item, MonsterAttribute> 主线关卡怪物属性Dic = new Dictionary<主线关卡怪物Item, MonsterAttribute>()
{
  // ========== 原有部分（第1~23关）==========
  // 花果山 (第1关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 500, Attack = 50, Defense = 10, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 1000, Attack = 100, Defense = 20, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 水帘洞 (第2关) - 1.3倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 70, Attack = 8, Defense = 7, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 650, Attack = 65, Defense = 14, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 1300, Attack = 130, Defense = 28, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 蓬莱仙岛 (第3关) - 1.3^2 = 1.69倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 100, Attack = 12, Defense = 9, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 845, Attack = 85, Defense = 18, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 1690, Attack = 170, Defense = 36, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 五行山 (第4关) - 1.3^3 ≈ 2.197倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 140, Attack = 15, Defense = 11, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 1100, Attack = 110, Defense = 22, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 2200, Attack = 220, Defense = 44, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 傲来国 (第5关) - 1.3^4 ≈ 2.856倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 200, Attack = 21, Defense = 14, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 1430, Attack = 145, Defense = 28, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 2860, Attack = 290, Defense = 56, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 高老庄 (第6关) - 1.3^5 ≈ 3.713倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 300, Attack = 30, Defense = 19, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 1855, Attack = 185, Defense = 38, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 3710, Attack = 370, Defense = 76, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 女儿国 (第7关) - 1.3^6 ≈ 4.827倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 423, Attack = 40, Defense = 24, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 2415, Attack = 240, Defense = 48, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 4830, Attack = 480, Defense = 96, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 小雷音寺 (第8关) - 1.3^7 ≈ 6.275倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 550, Attack = 55, Defense = 31, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 3140, Attack = 315, Defense = 62, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 6280, Attack = 630, Defense = 124, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 平顶山 (第9关) - 1.3^8 ≈ 8.157倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 750, Attack = 75, Defense = 41, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 4080, Attack = 410, Defense = 82, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 8160, Attack = 820, Defense = 164, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 火焰山 (第10关) - 1.3^9 ≈ 10.604倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 1060, Attack = 106, Defense = 53, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 5300, Attack = 530, Defense = 106, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 10600, Attack = 1060, Defense = 212, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 芭蕉洞 (第11关) - 保持不变
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 1379, Attack = 138, Defense = 69, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 6895, Attack = 690, Defense = 138, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 13790, Attack = 1380, Defense = 276, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 流沙河 (第12关) - 1.4^1 ≈ 1.4倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 1931, Attack = 193, Defense = 97, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 9655, Attack = 965, Defense = 194, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 19310, Attack = 1930, Defense = 388, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 狮驼岭 (第13关) - 1.4^2 ≈ 1.96倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 2703, Attack = 270, Defense = 135, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 13515, Attack = 1350, Defense = 270, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 27030, Attack = 2700, Defense = 540, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 东海龙宫 (第14关) - 1.4^3 ≈ 2.744倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 3784, Attack = 378, Defense = 189, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 18920, Attack = 1890, Defense = 378, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 37840, Attack = 3780, Defense = 756, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 冥府 (第15关) - 1.4^4 ≈ 3.842倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.冥府, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 5298, Attack = 530, Defense = 265, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.冥府, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 26490, Attack = 2650, Defense = 530, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.冥府, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 52980, Attack = 5300, Defense = 1060, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// ==================== 天庭篇（凌霄宝殿十大关 · 第16~23关）====================

// 南天门 (第16关) - 1.4^5 ≈ 5.378倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.南天门, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 7416, Attack = 742, Defense = 371, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.南天门, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 37080, Attack = 3710, Defense = 742, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.南天门, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 74160, Attack = 7420, Defense = 1484, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 瑶池仙境 (第17关) - 1.4^6 ≈ 7.530倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.瑶池仙境, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 10384, Attack = 1038, Defense = 519, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.瑶池仙境, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 51920, Attack = 5190, Defense = 1038, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.瑶池仙境, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 103840, Attack = 10380, Defense = 2076, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 斩妖台 (第18关) - 1.4^7 ≈ 10.542倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.斩妖台, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 14537, Attack = 1454, Defense = 727, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.斩妖台, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 72685, Attack = 7270, Defense = 1454, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.斩妖台, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 145370, Attack = 14540, Defense = 2908, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 御马监 (第19关) - 1.4^8 ≈ 14.759倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.御马监, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 20353, Attack = 2035, Defense = 1018, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.御马监, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 101765, Attack = 10175, Defense = 2036, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.御马监, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 203530, Attack = 20350, Defense = 4072, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 蟠桃园 (第20关) - 1.4^9 ≈ 20.663倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蟠桃园, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 28494, Attack = 2849, Defense = 1425, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蟠桃园, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 142470, Attack = 14245, Defense = 2850, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蟠桃园, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 284940, Attack = 28490, Defense = 5700, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 兜率宫 (第21关) - 1.4^10 ≈ 28.928倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.兜率宫, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 39891, Attack = 3989, Defense = 1995, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.兜率宫, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 199455, Attack = 19945, Defense = 3990, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.兜率宫, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 398910, Attack = 39890, Defense = 7980, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 紫微宫 (第22关) - 1.4^11 ≈ 40.499倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.紫微宫, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 55848, Attack = 5585, Defense = 2792, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.紫微宫, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 279240, Attack = 27925, Defense = 5584, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.紫微宫, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 558480, Attack = 55850, Defense = 11168, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 昊天殿 (第23关) - 1.4^12 ≈ 56.699倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.昊天殿, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 78188, Attack = 7819, Defense = 3909, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.昊天殿, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 390940, Attack = 39095, Defense = 7818, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.昊天殿, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 781880, Attack = 78190, Defense = 15636, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// ==================== 登天路 & 六重天/四重天/三清境/大罗天（第24~32关）====================

// 登天路 (第24关) - 1.4^13 ≈ 79.379倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.登天路, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 109464, Attack = 10946, Defense = 5473, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.登天路, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 547320, Attack = 54730, Defense = 10946, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.登天路, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 1094640, Attack = 109460, Defense = 21892, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 欲界天 (第25关) - 1.4^14 ≈ 111.131倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.欲界天, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 153250, Attack = 15325, Defense = 7662, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.欲界天, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 766250, Attack = 76625, Defense = 15324, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.欲界天, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 1532500, Attack = 153250, Defense = 30648, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 色界天 (第26关) - 1.4^15 ≈ 155.584倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.色界天, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 214550, Attack = 21455, Defense = 10728, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.色界天, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 1072750, Attack = 107275, Defense = 21456, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.色界天, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 2145500, Attack = 214550, Defense = 42912, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 无色天 (第27关) - 1.4^16 ≈ 217.817倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.无色天, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 300370, Attack = 30037, Defense = 15018, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.无色天, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 1501850, Attack = 150185, Defense = 30036, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.无色天, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 3003700, Attack = 300370, Defense = 60072, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 四梵天 (第28关) - 1.4^17 ≈ 304.944倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.四梵天, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 420518, Attack = 42052, Defense = 21026, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.四梵天, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 2102590, Attack = 210260, Defense = 42052, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.四梵天, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 4205180, Attack = 420520, Defense = 84104, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 玉清境清微天 (第29关) - 1.4^18 ≈ 426.922倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.玉清境清微天, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 588725, Attack = 58873, Defense = 29436, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.玉清境清微天, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 2943625, Attack = 294365, Defense = 58872, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.玉清境清微天, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 5887250, Attack = 588730, Defense = 117744, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 上清境禹余天 (第30关) - 1.4^19 ≈ 597.690倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.上清境禹余天, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 824215, Attack = 82422, Defense = 41211, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.上清境禹余天, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 4121075, Attack = 412110, Defense = 82422, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.上清境禹余天, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 8242150, Attack = 824220, Defense = 164844, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 太清境大赤天 (第31关) - 1.4^20 ≈ 836.766倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.太清境大赤天, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 1153901, Attack = 115390, Defense = 57695, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.太清境大赤天, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 5769505, Attack = 576950, Defense = 115390, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.太清境大赤天, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 11539010, Attack = 1153900, Defense = 230780, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 大罗天 (第32关 / 最终关) - 1.4^21 ≈ 1171.472倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.大罗天, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 1615461, Attack = 161546, Defense = 80773, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.大罗天, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 8077305, Attack = 807730, Defense = 161546, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.大罗天, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 16154610, Attack = 1615460, Defense = 323092, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

// 混沌虚空 - 1.4^22 ≈ 1640.061倍
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.混沌虚空, MonsterType = MonsterType.Normal },
    new MonsterAttribute()
      { Hp = 2261645, Attack = 226165, Defense = 113082, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.混沌虚空, MonsterType = MonsterType.Elite },
    new MonsterAttribute()
      { Hp = 11308225, Attack = 1130825, Defense = 226164, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.混沌虚空, MonsterType = MonsterType.Boss },
    new MonsterAttribute()
      { Hp = 22616450, Attack = 2261650, Defense = 452328, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
};
  public static Dictionary<MonsterTypeName, MonsterType> MonsterTypeDic =
        new Dictionary<MonsterTypeName, MonsterType>()
        {
            // 花果山
            { MonsterTypeName.猴精, MonsterType.Normal },
            { MonsterTypeName.山魈, MonsterType.Normal },
          

            // 水帘洞
            { MonsterTypeName.水虱精, MonsterType.Normal },
            { MonsterTypeName.蝙蝠精, MonsterType.Normal },
            

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

            // 五行山
            { MonsterTypeName.山石精, MonsterType.Normal },
            { MonsterTypeName.土蝼, MonsterType.Normal },
            { MonsterTypeName.五行山神, MonsterType.Elite },

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

            // 芭蕉洞
            { MonsterTypeName.芭蕉精, MonsterType.Normal },
            { MonsterTypeName.火焰童, MonsterType.Normal },
            { MonsterTypeName.铁扇侍女, MonsterType.Elite },
            { MonsterTypeName.铁扇公主, MonsterType.Boss },

            // 流沙河
            { MonsterTypeName.流沙精, MonsterType.Normal },
            { MonsterTypeName.水鬼, MonsterType.Normal },
            { MonsterTypeName.水蛇妖, MonsterType.Elite },
            { MonsterTypeName.沙和尚, MonsterType.Boss },

            // 小雷音寺
            { MonsterTypeName.假罗汉, MonsterType.Normal },
            { MonsterTypeName.假金刚, MonsterType.Normal },
            { MonsterTypeName.黄眉童子, MonsterType.Elite },
            { MonsterTypeName.黄眉老祖, MonsterType.Boss },

            // 狮驼岭
            { MonsterTypeName.青狮精手下, MonsterType.Normal },
            { MonsterTypeName.白象精手下, MonsterType.Normal },
            { MonsterTypeName.大鹏金翅雕, MonsterType.Elite },
            { MonsterTypeName.青狮精, MonsterType.Boss },

            // 冥府
            { MonsterTypeName.牛头, MonsterType.Normal },
            { MonsterTypeName.马面, MonsterType.Normal },
            { MonsterTypeName.判官, MonsterType.Elite },
            { MonsterTypeName.阎罗王, MonsterType.Boss },

            // ==================== 天庭篇（凌霄宝殿十大关 · 第16~23关）====================
            // 南天门
            { MonsterTypeName.天兵, MonsterType.Normal },
            { MonsterTypeName.天将, MonsterType.Normal },
            { MonsterTypeName.守卫统领, MonsterType.Elite },
            { MonsterTypeName.巨灵王, MonsterType.Boss },

            // 瑶池仙境
            { MonsterTypeName.瑶池仙女, MonsterType.Normal },
            { MonsterTypeName.瑶池守卫, MonsterType.Normal },
            { MonsterTypeName.仙女首领, MonsterType.Elite },
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
            { MonsterTypeName.蟠桃树精, MonsterType.Boss },

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

            // ==================== 登天路 & 六重天/四重天/三清境/大罗天（第24~32关）====================
            // 登天路
            { MonsterTypeName.登天石傀, MonsterType.Normal },
            { MonsterTypeName.罡风精, MonsterType.Normal },
            { MonsterTypeName.雷劫之灵, MonsterType.Elite },
            { MonsterTypeName.守天路神将, MonsterType.Boss },

            // 欲界天
            { MonsterTypeName.欲念魅妖, MonsterType.Normal },
            { MonsterTypeName.幻音雀, MonsterType.Normal },
            { MonsterTypeName.贪欲魔, MonsterType.Elite },
            { MonsterTypeName.欲界天魔王, MonsterType.Boss },

            // 色界天
            { MonsterTypeName.色相天女, MonsterType.Normal },
            { MonsterTypeName.光音天众, MonsterType.Normal },
            { MonsterTypeName.形色尊者, MonsterType.Elite },
            { MonsterTypeName.色界天主, MonsterType.Boss },

            // 无色天
            { MonsterTypeName.虚灵, MonsterType.Normal },
            { MonsterTypeName.空无影, MonsterType.Normal },
            { MonsterTypeName.太虚之魂, MonsterType.Elite },
            { MonsterTypeName.无色天祖, MonsterType.Boss },

            // 四梵天
            { MonsterTypeName.梵天守卫, MonsterType.Normal },
            { MonsterTypeName.净居天人, MonsterType.Normal },
            { MonsterTypeName.善现尊者, MonsterType.Elite },
            { MonsterTypeName.四梵天王, MonsterType.Boss },

            // 玉清境清微天
            { MonsterTypeName.清微仙童, MonsterType.Normal },
            { MonsterTypeName.玄光玉女, MonsterType.Normal },
            { MonsterTypeName.玉清道卫, MonsterType.Elite },
            { MonsterTypeName.魔元始天尊, MonsterType.Boss },

            // 上清境禹余天
            { MonsterTypeName.禹余灵官, MonsterType.Normal },
            { MonsterTypeName.紫霞仙鹤, MonsterType.Normal },
            { MonsterTypeName.上清剑侍, MonsterType.Elite },
            { MonsterTypeName.魔灵宝天尊, MonsterType.Boss },

            // 太清境大赤天
            { MonsterTypeName.大赤丹童, MonsterType.Normal },
            { MonsterTypeName.炉火精, MonsterType.Normal },
            { MonsterTypeName.太清护卫, MonsterType.Elite },
            { MonsterTypeName.魔老子, MonsterType.Boss },

            // 大罗天
            { MonsterTypeName.弥罗侍卫, MonsterType.Normal },
            { MonsterTypeName.弥罗宫卫, MonsterType.Normal },
            { MonsterTypeName.混元道兵, MonsterType.Elite },
            { MonsterTypeName.魔鸿钧, MonsterType.Boss },
            
            // 大罗天
            { MonsterTypeName.混沌蠕虫, MonsterType.Normal },
            { MonsterTypeName.虚空螯虫, MonsterType.Normal },
            { MonsterTypeName.虚空巨兽, MonsterType.Elite },
            { MonsterTypeName.混沌主宰, MonsterType.Boss },
        };
}
