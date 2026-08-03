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
    { MonsterTypeName.猴精, Monster特性Type.普通怪 },
    { MonsterTypeName.山魈, Monster特性Type.普通怪 },
    

    // 水帘洞
    { MonsterTypeName.水虱精, Monster特性Type.普通怪 },
    { MonsterTypeName.蝙蝠精, Monster特性Type.普通怪 },
   

    // 傲来国
    { MonsterTypeName.傲来民兵, Monster特性Type.普通怪 },
    { MonsterTypeName.猎户, Monster特性Type.普通怪 },
    { MonsterTypeName.傲来偏将, Monster特性Type.普通怪 },

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
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 500, Attack = 50, Defense = 10, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 1000, Attack = 100, Defense = 20, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 水帘洞 (第2关) - 1.3倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 70, Attack = 8, Defense = 7, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 650, Attack = 65, Defense = 14, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 1300, Attack = 130, Defense = 28, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 蓬莱仙岛 (第3关) - 1.3^2 = 1.69倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 100, Attack = 12, Defense = 9, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 845, Attack = 85, Defense = 18, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 1690, Attack = 170, Defense = 36, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 五行山 (第4关) - 1.3^3 ≈ 2.197倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 140, Attack = 15, Defense = 11, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1100, Attack = 110, Defense = 22, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 2200, Attack = 220, Defense = 44, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 傲来国 (第5关) - 1.3^4 ≈ 2.856倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 200, Attack = 21, Defense = 14, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1430, Attack = 145, Defense = 28, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 2860, Attack = 290, Defense = 56, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 高老庄 (第6关) - 1.3^5 ≈ 3.713倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 300, Attack = 30, Defense = 19, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1855, Attack = 185, Defense = 38, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 3710, Attack = 370, Defense = 76, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 女儿国 (第7关) - 1.3^6 ≈ 4.827倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 423, Attack = 40, Defense = 24, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 2415, Attack = 240, Defense = 48, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 4830, Attack = 480, Defense = 96, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 小雷音寺 (第8关) - 1.3^7 ≈ 6.275倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 550, Attack = 55, Defense = 31, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 3140, Attack = 315, Defense = 62, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 6280, Attack = 630, Defense = 124, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 平顶山 (第9关) - 1.3^8 ≈ 8.157倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 750, Attack = 75, Defense = 41, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 4080, Attack = 410, Defense = 82, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 8160, Attack = 820, Defense = 164, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 火焰山 (第10关) - 1.3^9 ≈ 10.604倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 1060, Attack = 106, Defense = 53, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 5300, Attack = 530, Defense = 106, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 10600, Attack = 1060, Defense = 212, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 芭蕉洞 (第11关) - 1.3^10 ≈ 13.786倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 1379, Attack = 138, Defense = 69, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 6895, Attack = 690, Defense = 138, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 13790, Attack = 1380, Defense = 276, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 流沙河 (第12关) - 1.3^11 ≈ 17.922倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 1792, Attack = 179, Defense = 90, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 8960, Attack = 895, Defense = 180, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 17920, Attack = 1790, Defense = 360, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 狮驼岭 (第13关) - 1.3^12 ≈ 23.298倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 2330, Attack = 233, Defense = 117, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 11650, Attack = 1165, Defense = 234, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 23300, Attack = 2330, Defense = 468, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 东海龙宫 (第14关) - 1.3^13 ≈ 30.288倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 3029, Attack = 303, Defense = 151, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 15145, Attack = 1515, Defense = 302, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 30290, Attack = 3030, Defense = 604, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // 冥府 (第15关) - 1.3^14 ≈ 39.374倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.冥府, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 3937, Attack = 394, Defense = 197, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.冥府, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 19685, Attack = 1970, Defense = 394, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.冥府, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 39370, Attack = 3940, Defense = 788, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0 ,雷电抗性 = 0} },

    // ==================== 天庭篇（凌霄宝殿十大关 · 第16~23关）====================

    // 南天门 (第16关) - 1.3^15 ≈ 51.186倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.南天门, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 5119, Attack = 512, Defense = 256, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.南天门, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 25595, Attack = 2560, Defense = 512, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.南天门, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 51190, Attack = 5120, Defense = 1024, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 瑶池仙境 (第17关) - 1.3^16 ≈ 66.542倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.瑶池仙境, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 6654, Attack = 665, Defense = 333, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.瑶池仙境, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 33270, Attack = 3325, Defense = 666, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.瑶池仙境, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 66540, Attack = 6650, Defense = 1332, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 斩妖台 (第18关) - 1.3^17 ≈ 86.504倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.斩妖台, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 8650, Attack = 865, Defense = 433, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.斩妖台, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 43250, Attack = 4325, Defense = 866, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.斩妖台, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 86500, Attack = 8650, Defense = 1732, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 御马监 (第19关) - 1.3^18 ≈ 112.455倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.御马监, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 11246, Attack = 1125, Defense = 562, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.御马监, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 56230, Attack = 5625, Defense = 1124, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.御马监, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 112460, Attack = 11250, Defense = 2248, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 蟠桃园 (第20关) - 1.3^19 ≈ 146.192倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蟠桃园, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 14619, Attack = 1462, Defense = 731, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蟠桃园, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 73095, Attack = 7310, Defense = 1462, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蟠桃园, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 146190, Attack = 14620, Defense = 2924, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 兜率宫 (第21关) - 1.3^20 ≈ 190.050倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.兜率宫, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 19005, Attack = 1901, Defense = 950, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.兜率宫, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 95025, Attack = 9505, Defense = 1900, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.兜率宫, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 190050, Attack = 19010, Defense = 3800, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 紫微宫 (第22关) - 1.3^21 ≈ 247.065倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.紫微宫, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 24707, Attack = 2471, Defense = 1235, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.紫微宫, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 123535, Attack = 12355, Defense = 2470, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.紫微宫, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 247070, Attack = 24710, Defense = 4940, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 昊天殿 (第23关) - 1.3^22 ≈ 321.184倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.昊天殿, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 32118, Attack = 3212, Defense = 1606, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.昊天殿, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 160590, Attack = 16060, Defense = 3212, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.昊天殿, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 321180, Attack = 32120, Defense = 6424, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // ==================== 登天路 & 六重天/四重天/三清境/大罗天（第24~32关）====================

    // 登天路 (第24关) - 1.3^23 ≈ 417.539倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.登天路, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 41754, Attack = 4175, Defense = 2088, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.登天路, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 208770, Attack = 20875, Defense = 4176, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.登天路, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 417540, Attack = 41750, Defense = 8352, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 欲界天 (第25关) - 1.3^24 ≈ 542.801倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.欲界天, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 54280, Attack = 5428, Defense = 2714, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.欲界天, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 271400, Attack = 27140, Defense = 5428, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.欲界天, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 542800, Attack = 54280, Defense = 10856, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 色界天 (第26关) - 1.3^25 ≈ 705.641倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.色界天, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 70564, Attack = 7056, Defense = 3528, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.色界天, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 352820, Attack = 35280, Defense = 7056, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.色界天, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 705640, Attack = 70560, Defense = 14112, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 无色天 (第27关) - 1.3^26 ≈ 917.333倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.无色天, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 91733, Attack = 9173, Defense = 4587, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.无色天, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 458665, Attack = 45865, Defense = 9174, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.无色天, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 917330, Attack = 91730, Defense = 18348, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 四梵天 (第28关) - 1.3^27 ≈ 1192.533倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.四梵天, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 119253, Attack = 11925, Defense = 5963, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.四梵天, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 596265, Attack = 59625, Defense = 11926, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.四梵天, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 1192530, Attack = 119250, Defense = 23852, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 玉清境清微天 (第29关) - 1.3^28 ≈ 1550.293倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.玉清境清微天, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 155029, Attack = 15503, Defense = 7751, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.玉清境清微天, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 775145, Attack = 77515, Defense = 15502, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.玉清境清微天, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 1550290, Attack = 155030, Defense = 31004, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 上清境禹余天 (第30关) - 1.3^29 ≈ 2015.381倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.上清境禹余天, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 201538, Attack = 20154, Defense = 10077, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.上清境禹余天, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1007690, Attack = 100770, Defense = 20154, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.上清境禹余天, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 2015380, Attack = 201540, Defense = 40308, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 太清境大赤天 (第31关) - 1.3^30 ≈ 2619.995倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.太清境大赤天, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 261999, Attack = 26200, Defense = 13100, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.太清境大赤天, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1309995, Attack = 131000, Defense = 26200, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.太清境大赤天, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 2619990, Attack = 262000, Defense = 52400, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },

    // 大罗天 (第32关 / 最终关) - 1.3^31 ≈ 3405.994倍
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.大罗天, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 340599, Attack = 34060, Defense = 17030, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.大罗天, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1702995, Attack = 170300, Defense = 34060, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.大罗天, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 3405990, Attack = 340600, Defense = 68120, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    
    
    // 混沌虚空
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.混沌虚空, MonsterType = MonsterType.Normal },
      new MonsterAttribute() { Hp = 340599, Attack = 34060, Defense = 17030, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.混沌虚空, MonsterType = MonsterType.Elite },
      new MonsterAttribute() { Hp = 1702995, Attack = 170300, Defense = 34060, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
    { new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.混沌虚空, MonsterType = MonsterType.Boss },
      new MonsterAttribute() { Hp = 3405990, Attack = 340600, Defense = 68120, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 } },
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
