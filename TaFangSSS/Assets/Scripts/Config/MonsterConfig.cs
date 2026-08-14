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
  
  //洞天秘境
  //筑基
  青木狼,
  铁背龟,
  荆棘猿,
  千年树精,

  // ==================== 金丹 · 赤焰谷 ====================
  熔岩蜥,
  火鸦,
  炎晶巨人,
  地火蛟,

  // ==================== 元婴 · 幽冥渊 ====================
  怨魂蝶,
  食骨鳄,
  无面鬼,
  九幽尸王,

  // ==================== 化神 · 裂天峡 ====================
  罡风鹫,
  裂空蝎,
  虚影兽,
  双首海蛇,

  // ==================== 合体 · 万象海 ====================
  幻鳞鱼,
  铁钳蟹,
  万象鲸,
  饕餮,

  // ==================== 大乘 · 天外天 ====================
  云纹兽,
  星光蝶,
  朱雀,
  白虎,

  // ==================== 天仙 · 瑶光仙境 ====================
  仙灵鹤,
  玉兔精,
  朱厌,
  应龙,
  

  // ==================== 玄仙 · 归墟海 ====================
  虚空兽,
  混沌兽,
  归墟古凤,
  归墟古龙,

  // ==================== 金仙 · 太初宫 ====================
  道纹甲虫,
  混沌蝠,
  梼杌,
  霸下,

  // ==================== 太乙金仙 · 混元界 ====================
  玄黄蜉蝣,
  剑齿虎,
  混元兽,
  道胎灵童,

  // ==================== 大罗金仙 · 无何有之乡 ====================
  青丘白狐,
  青丘黑狐,
  白泽,
  九尾狐,

  // ==================== 准圣 · 道海 ====================
  远古巨兽,
  法则之兽,
  凤凰,
  真龙,

  // ==================== 圣人/天道圣人 · 紫霄宫 ====================
  远古凶兽,
  远古大蛇,
  穷奇,
  麒麟,

  // ==================== 大道圣人 · 混沌海 ====================
  先天魔神,
  混沌巨兽,
  劫兽,
  混沌之眼,

  // ==================== 混元圣人 · 永恒之门 ====================
  归墟古兽,
  时空扭曲者,
  混沌古兽,
  永恒之门,
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

  public static Dictionary<JingJieType, List<MonsterTypeName>> 洞天MonsterDic =
    new Dictionary<JingJieType, List<MonsterTypeName>>()
    {
      {
        JingJieType.练气, new List<MonsterTypeName>()
        {
          MonsterTypeName.仙鹤, MonsterTypeName.灵芝童, MonsterTypeName.荆棘猿, MonsterTypeName.千年树精
        }
      },
      // 筑基 · 青木秘境
      {
        JingJieType.筑基, new List<MonsterTypeName>()
        {
          MonsterTypeName.青木狼, MonsterTypeName.铁背龟, MonsterTypeName.荆棘猿, MonsterTypeName.千年树精
        }
      },
      
      // 金丹 · 赤焰谷
      {
        JingJieType.金丹, new List<MonsterTypeName>()
        {
          MonsterTypeName.熔岩蜥, MonsterTypeName.火鸦, MonsterTypeName.炎晶巨人, MonsterTypeName.地火蛟
        }
      },

      // 元婴 · 幽冥渊
      {
        JingJieType.元婴, new List<MonsterTypeName>()
        {
          MonsterTypeName.怨魂蝶, MonsterTypeName.食骨鳄, MonsterTypeName.无面鬼, MonsterTypeName.九幽尸王
        }
      },

      // 化神 · 裂天峡
      {
        JingJieType.化神, new List<MonsterTypeName>()
        {
          MonsterTypeName.罡风鹫, MonsterTypeName.裂空蝎, MonsterTypeName.虚影兽, MonsterTypeName.双首海蛇
        }
      },

      // 合体 · 万象海
      {
        JingJieType.合体, new List<MonsterTypeName>()
        {
          MonsterTypeName.幻鳞鱼, MonsterTypeName.铁钳蟹, MonsterTypeName.万象鲸, MonsterTypeName.饕餮
        }
      },

      // 大乘 · 天外天
      {
        JingJieType.大乘, new List<MonsterTypeName>()
        {
          MonsterTypeName.云纹兽, MonsterTypeName.星光蝶, MonsterTypeName.朱雀, MonsterTypeName.白虎
        }
      },

      // 天仙 · 瑶光仙境
      {
        JingJieType.天仙, new List<MonsterTypeName>()
        {
          MonsterTypeName.仙灵鹤, MonsterTypeName.玉兔精, MonsterTypeName.朱厌, MonsterTypeName.应龙
        }
      },

      // 玄仙 · 归墟海
      {
        JingJieType.玄仙, new List<MonsterTypeName>()
        {
          MonsterTypeName.虚空兽, MonsterTypeName.混沌兽, MonsterTypeName.归墟古凤, MonsterTypeName.归墟古龙
        }
      },

      // 金仙 · 太初宫
      {
        JingJieType.金仙, new List<MonsterTypeName>()
        {
          MonsterTypeName.道纹甲虫, MonsterTypeName.混沌蝠, MonsterTypeName.梼杌, MonsterTypeName.霸下
        }
      },

      // 太乙金仙 · 混元界
      {
        JingJieType.太乙金仙, new List<MonsterTypeName>()
        {
          MonsterTypeName.玄黄蜉蝣, MonsterTypeName.剑齿虎, MonsterTypeName.混元兽, MonsterTypeName.道胎灵童
        }
      },

      // 大罗金仙 · 无何有之乡
      {
        JingJieType.大罗金仙, new List<MonsterTypeName>()
        {
          MonsterTypeName.青丘白狐, MonsterTypeName.青丘黑狐, MonsterTypeName.白泽, MonsterTypeName.九尾狐
        }
      },

      // 准圣 · 道海
      {
        JingJieType.准圣, new List<MonsterTypeName>()
        {
          MonsterTypeName.远古巨兽, MonsterTypeName.法则之兽, MonsterTypeName.凤凰, MonsterTypeName.真龙
        }
      },

      // 圣人/天道圣人 · 紫霄宫
      {
        JingJieType.圣人, new List<MonsterTypeName>()
        {
          MonsterTypeName.远古凶兽, MonsterTypeName.远古大蛇, MonsterTypeName.穷奇, MonsterTypeName.麒麟
        }
      },

      // 大道圣人 · 混沌海
      {
        JingJieType.大道圣人, new List<MonsterTypeName>()
        {
          MonsterTypeName.先天魔神, MonsterTypeName.混沌巨兽, MonsterTypeName.劫兽, MonsterTypeName.混沌之眼
        }
      },

      // 混元圣人 · 永恒之门
      {
        JingJieType.混元圣人, new List<MonsterTypeName>()
        {
          MonsterTypeName.归墟古兽, MonsterTypeName.时空扭曲者, MonsterTypeName.混沌古兽, MonsterTypeName.永恒之门
        }
      },
    };


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
    { MonsterTypeName.红孩儿, true },
    { MonsterTypeName.牛魔王, false },

    // 芭蕉洞
    { MonsterTypeName.芭蕉精, true },
    { MonsterTypeName.火焰童, true },
    { MonsterTypeName.铁扇侍女, true },
    { MonsterTypeName.铁扇公主, false },

    // 流沙河
    { MonsterTypeName.流沙精, true },
    { MonsterTypeName.水鬼, true },
    { MonsterTypeName.水蛇妖, true },
    { MonsterTypeName.沙和尚, true },

    // 小雷音寺
    { MonsterTypeName.假罗汉, false },
    { MonsterTypeName.假金刚, true },
    { MonsterTypeName.黄眉童子, false },
    { MonsterTypeName.黄眉老祖, false },

    // 狮驼岭
    { MonsterTypeName.青狮精手下, true },
    { MonsterTypeName.白象精手下, true },
    { MonsterTypeName.大鹏金翅雕, true },
    { MonsterTypeName.青狮精, true },

    // 冥府
    { MonsterTypeName.牛头, true },
    { MonsterTypeName.马面, false },
    { MonsterTypeName.判官, true },
    { MonsterTypeName.阎罗王, true },

    // ==================== 天庭篇（凌霄宝殿十大关） ====================
    // 南天门
    { MonsterTypeName.天兵, true },
    { MonsterTypeName.天将, true },
    { MonsterTypeName.守卫统领, false },
    { MonsterTypeName.巨灵王, true },

    // 瑶池仙境
    { MonsterTypeName.瑶池仙女, true },
    { MonsterTypeName.瑶池守卫, true },
    { MonsterTypeName.仙女首领, false },
    { MonsterTypeName.西王母, true },

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
    { MonsterTypeName.形色尊者, true },
    { MonsterTypeName.色界天主, true},

    // 无色天
    { MonsterTypeName.虚灵, false },
    { MonsterTypeName.空无影, false },
    { MonsterTypeName.太虚之魂, false },
    { MonsterTypeName.无色天祖, false },

    // 四梵天
    { MonsterTypeName.梵天守卫, true },
    { MonsterTypeName.净居天人, false },
    { MonsterTypeName.善现尊者, false },
    { MonsterTypeName.四梵天王, false },

    // 玉清境清微天
    { MonsterTypeName.清微仙童, true },
    { MonsterTypeName.玄光玉女, false },
    { MonsterTypeName.玉清道卫, true },
    { MonsterTypeName.魔元始天尊, false },

    // 上清境禹余天
    { MonsterTypeName.禹余灵官, false },
    { MonsterTypeName.紫霞仙鹤, false },
    { MonsterTypeName.上清剑侍, true },
    { MonsterTypeName.魔灵宝天尊, true },

    // 太清境大赤天
    { MonsterTypeName.大赤丹童,false },
    { MonsterTypeName.炉火精, false },
    { MonsterTypeName.太清护卫, false },
    { MonsterTypeName.魔老子, true},

    // 大罗天
    { MonsterTypeName.弥罗侍卫, true },
    { MonsterTypeName.弥罗宫卫, false },
    { MonsterTypeName.混元道兵,true },
    { MonsterTypeName.魔鸿钧, true },
    
    // 大罗天
    { MonsterTypeName.混沌蠕虫, false },
    { MonsterTypeName.虚空螯虫, false },
    { MonsterTypeName.虚空巨兽, true },
    { MonsterTypeName.混沌主宰, true },
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
  // ========== 原有部分（第1~11关）==========
  // 花果山 (第1关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 500, Attack = 12, Defense = 10, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.花果山, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 5000, Attack = 30, Defense = 25, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 水帘洞 (第2关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 70, Attack = 8, Defense = 7, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 700, Attack = 16, Defense = 14, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.水帘洞, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 7000, Attack = 40, Defense = 35, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 蓬莱仙岛 (第3关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 100, Attack = 12, Defense = 9, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 1000, Attack = 24, Defense = 18, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蓬莱仙岛, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 10000, Attack = 60, Defense = 45, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 五行山 (第4关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 140, Attack = 15, Defense = 11, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 1400, Attack = 30, Defense = 22, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.五行山, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 14000, Attack = 75, Defense = 55, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 傲来国 (第5关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 200, Attack = 21, Defense = 14, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 2000, Attack = 42, Defense = 28, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.傲来国, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 20000, Attack = 105, Defense = 70, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 高老庄 (第6关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 300, Attack = 30, Defense = 19, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 3000, Attack = 60, Defense = 38, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.高老庄, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 30000, Attack = 150, Defense = 95, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 女儿国 (第7关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 423, Attack = 40, Defense = 24, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 4230, Attack = 80, Defense = 48, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.女儿国, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 42300, Attack = 200, Defense = 120, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 小雷音寺 (第8关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 550, Attack = 55, Defense = 31, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 5500, Attack = 110, Defense = 62, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.小雷音寺, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 55000, Attack = 275, Defense = 155, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 平顶山 (第9关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 750, Attack = 75, Defense = 41, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 7500, Attack = 150, Defense = 82, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.平顶山, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 75000, Attack = 375, Defense = 205, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 火焰山 (第10关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 1060, Attack = 106, Defense = 53, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 10600, Attack = 212, Defense = 106, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.火焰山, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 106000, Attack = 530, Defense = 265, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 芭蕉洞 (第11关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 1379, Attack = 138, Defense = 69, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 13790, Attack = 276, Defense = 138, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.芭蕉洞, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 137900, Attack = 690, Defense = 345, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 流沙河 (第12关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 1931, Attack = 193, Defense = 97, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 19310, Attack = 386, Defense = 194, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.流沙河, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 193100, Attack = 965, Defense = 485, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 狮驼岭 (第13关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 2703, Attack = 270, Defense = 135, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 27030, Attack = 540, Defense = 270, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.狮驼岭, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 270300, Attack = 1350, Defense = 675, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 东海龙宫 (第14关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 3784, Attack = 378, Defense = 189, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 37840, Attack = 756, Defense = 378, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.东海龙宫, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 378400, Attack = 1890, Defense = 945, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 冥府 (第15关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.冥府, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 5298, Attack = 530, Defense = 265, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.冥府, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 52980, Attack = 1060, Defense = 530, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.冥府, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 529800, Attack = 2650, Defense = 1325, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // ==================== 天庭篇（第16~23关）====================

  // 南天门 (第16关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.南天门, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 7416, Attack = 742, Defense = 371, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.南天门, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 74160, Attack = 1484, Defense = 742, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.南天门, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 741600, Attack = 3710, Defense = 1855, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 瑶池仙境 (第17关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.瑶池仙境, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 10384, Attack = 1038, Defense = 519, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.瑶池仙境, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 103840, Attack = 2076, Defense = 1038, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.瑶池仙境, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 1038400, Attack = 5190, Defense = 2595, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 斩妖台 (第18关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.斩妖台, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 14537, Attack = 1454, Defense = 727, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.斩妖台, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 145370, Attack = 2908, Defense = 1454, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.斩妖台, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 1453700, Attack = 7270, Defense = 3635, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 御马监 (第19关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.御马监, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 20353, Attack = 2035, Defense = 1018, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.御马监, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 203530, Attack = 4070, Defense = 2036, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.御马监, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 2035300, Attack = 10175, Defense = 5090, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 蟠桃园 (第20关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蟠桃园, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 28494, Attack = 2849, Defense = 1425, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蟠桃园, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 284940, Attack = 5698, Defense = 2850, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.蟠桃园, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 2849400, Attack = 14245, Defense = 7125, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 兜率宫 (第21关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.兜率宫, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 39891, Attack = 3989, Defense = 1995, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.兜率宫, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 398910, Attack = 7978, Defense = 3990, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.兜率宫, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 3989100, Attack = 19945, Defense = 9975, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 紫微宫 (第22关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.紫微宫, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 55848, Attack = 5585, Defense = 2792, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.紫微宫, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 558480, Attack = 11170, Defense = 5584, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.紫微宫, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 5584800, Attack = 27925, Defense = 13960, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 昊天殿 (第23关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.昊天殿, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 78188, Attack = 7819, Defense = 3909, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.昊天殿, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 781880, Attack = 15638, Defense = 7818, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.昊天殿, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 7818800, Attack = 39095, Defense = 19545, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // ==================== 登天路 & 六重天/四重天/三清境/大罗天（第24~33关）====================

  // 登天路 (第24关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.登天路, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 109464, Attack = 10946, Defense = 5473, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.登天路, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 1094640, Attack = 21892, Defense = 10946, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.登天路, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 10946400, Attack = 54730, Defense = 27365, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 欲界天 (第25关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.欲界天, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 153250, Attack = 15325, Defense = 7662, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.欲界天, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 1532500, Attack = 30650, Defense = 15324, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.欲界天, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 15325000, Attack = 76625, Defense = 38310, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 色界天 (第26关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.色界天, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 214550, Attack = 21455, Defense = 10728, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.色界天, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 2145500, Attack = 42910, Defense = 21456, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.色界天, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 21455000, Attack = 107275, Defense = 53640, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 无色天 (第27关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.无色天, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 300370, Attack = 30037, Defense = 15018, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.无色天, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 3003700, Attack = 60074, Defense = 30036, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.无色天, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 30037000, Attack = 150185, Defense = 75090, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 四梵天 (第28关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.四梵天, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 420518, Attack = 42052, Defense = 21026, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.四梵天, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 4205180, Attack = 84104, Defense = 42052, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.四梵天, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 42051800, Attack = 210260, Defense = 105130, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 玉清境清微天 (第29关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.玉清境清微天, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 588725, Attack = 58873, Defense = 29436, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.玉清境清微天, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 5887250, Attack = 117746, Defense = 58872, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.玉清境清微天, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 58872500, Attack = 294365, Defense = 147180, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 上清境禹余天 (第30关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.上清境禹余天, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 824215, Attack = 82422, Defense = 41211, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.上清境禹余天, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 8242150, Attack = 164844, Defense = 82422, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.上清境禹余天, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 82421500, Attack = 412110, Defense = 206055, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 太清境大赤天 (第31关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.太清境大赤天, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 1153901, Attack = 115390, Defense = 57695, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.太清境大赤天, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 11539010, Attack = 230780, Defense = 115390, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.太清境大赤天, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 115390100, Attack = 576950, Defense = 288475, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 大罗天 (第32关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.大罗天, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 1615461, Attack = 161546, Defense = 80773, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.大罗天, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 16154610, Attack = 323092, Defense = 161546, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.大罗天, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 161546100, Attack = 807730, Defense = 403865, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },

  // 混沌虚空 (第33关)
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.混沌虚空, MonsterType = MonsterType.Normal },
    new MonsterAttribute() { Hp = 2261645, Attack = 226165, Defense = 113082, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.混沌虚空, MonsterType = MonsterType.Elite },
    new MonsterAttribute() { Hp = 22616450, Attack = 452330, Defense = 226164, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
  },
  {
    new 主线关卡怪物Item() { 主线关卡Type = 主线关卡Type.混沌虚空, MonsterType = MonsterType.Boss },
    new MonsterAttribute() { Hp = 226164500, Attack = 1130825, Defense = 565410, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
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
