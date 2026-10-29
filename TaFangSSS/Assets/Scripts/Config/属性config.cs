using System;
using System.Collections.Generic;
using Config;

public class 英雄属性
{
     public float 真灵;//基础真灵
     public float 暴击率;
     public float 暴击伤害;
     public float 元素增幅;
     public float 职业增幅;
     public float 最终伤害;
     public float 冷却缩减;
     public float 效果范围;
     public float 普通怪增伤;
     public float 精英怪增伤;
     public float 首领怪增伤;
     public float 元素穿透;
     public float 寻宝速度增幅;
     public float 攻击距离;
     public float 普通攻击间隔;//多长时间攻击一次，不是神通
     public float 神通攻击间隔;//多长时间攻击一次，神通
}
public class 属性config
{
     /// <summary>
     /// 英雄属性字典：每次取值实时遍历全部英雄计算，保证始终为最新数值。
     /// </summary>
     public static Dictionary<HeroType, 英雄属性> 英雄属性字典 => Get英雄属性字典();
     public static float Get英雄暴击伤害增幅()
     {
          float value = 0;
          foreach (var item in HeroConfig.HeroQualityDic)
          {
               int xj = PlayerData.S.HeroDataDic[item.Key].Level;
               value+=Math.Max(HeroConfig.升星奖励Dic[item.Value] * (xj - 1),0);
          }

          foreach (var item in HeroConfig.HeroQualityDic)
          {
               if (item.Value >= QualityType.宇品)
               {
                    value += 法则config.法则升级奖励Dic[item.Value] * PlayerData.S.英雄法则等级Dic[item.Key];
               }
          }
          
          foreach (var item in HeroConfig.HeroQualityDic)
          {
               
               value += HeroConfig.神通升级奖励Dic[item.Value] * PlayerData.S.HeroDataDic[item.Key].神通等级;
          }

          return value ;
     }
    
     
     public class 装备属性
     { 
          public float 暴击率 => EquipConfig.装备附加属性数值Dic[附加属性Type.暴击率]();
          public float 最终伤害 => EquipConfig.装备附加属性数值Dic[附加属性Type.最终伤害]();
          
          public float 装备总攻击力增幅 => Get装备攻击力增幅();
          public float 战士增幅 => 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.战士伤害增幅]() ;
          public float 射手增幅 => 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.射手伤害增幅]() ;
          public float 控制增幅 => 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.控制伤害增幅]() ;
          public float 法师增幅 => 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.法师伤害增幅]() ;
          public float 物理伤害增幅 => 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.物理伤害]() ;
          public float 火焰伤害增幅 => 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.火焰伤害]() ;
          public float 冰霜伤害增幅 => 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.冰霜伤害]() ;
          public float 雷电伤害增幅 => 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.雷电伤害]() ;
          public float 黑暗伤害增幅 => 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.黑暗伤害]() ;
          public float 普通怪伤害增幅 => 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.普通怪伤害增幅]() ;
          public float 精英怪伤害增幅 => 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.精英怪伤害增幅]() ;
          public float 首领伤害增幅 => 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.首领伤害增幅]() ;
          public float 城墙血量增幅 => 1f +EquipConfig.装备附加属性数值Dic[附加属性Type.城墙血量]();
     }
     
     public  static float Get神物数值(神物Type type)
     {
          // TryGetValue：老存档反序列化的字典可能缺少新版本新增的神物键，索引器会抛异常
          if (PlayerData.S.神物获得Dic.TryGetValue(type, out bool 已获得) && 已获得)
          {
               return 神物Config.神物数值Dic[type]/100f;
          }
          return 0;
     }
     
     public class 神物属性
     {
          public float 最终伤害 => Get神物数值(神物Type.最终伤害);
          public float 冷却缩减 => Get神物数值(神物Type.冷却缩减);
          public float 全元素增伤 => Get神物数值(神物Type.全元素增伤);
          public float 元素人人为我 => Get神物数值(神物Type.元素人人为我);
          public float 元素我为人人 => Get神物数值(神物Type.元素我为人人);
          public float 全职业增伤 => Get神物数值(神物Type.全职业增伤);
          public float 暴击爆伤 => Get神物数值(神物Type.暴击爆伤);
          public float 二次暴击 => Get神物数值(神物Type.二次暴击);
          public float 轮回次数加伤 => Get神物数值(神物Type.轮回次数加伤);
          public float 职业我为人人 => Get神物数值(神物Type.职业我为人人);
          public float 职业人人为我 => Get神物数值(神物Type.职业人人为我);
          public float 轮回系数 => Get神物数值(神物Type.轮回系数);
          public float 时间流速加快 => Get神物数值(神物Type.时间流速加快);

     }
     public class 道宝属性
     {
          public float 伤害减免 => 道宝Config.羁绊伤害减免/100f;
          public float 暴击率 => 道宝Config.羁绊暴击率/100f;
          public float 最终伤害 => 道宝Config.羁绊最终伤害/100f;
          
          public float 战士增幅 => 1f + 道宝Config.羁绊战士伤害增幅/100f;
          public float 射手增幅 => 1f + 道宝Config.羁绊射手伤害增幅/100f;
          public float 法师增幅 => 1f + 道宝Config.羁绊法师伤害增幅/100f;
          
          public float 物理伤害增幅 => 1f + 道宝Config.羁绊物理伤害增幅/100f;
          public float 火焰伤害增幅 => 1f + 道宝Config.羁绊火焰伤害增幅 /100f;
          public float 冰霜伤害增幅 => 1f + 道宝Config.羁绊冰霜伤害增幅/100f ;
          public float 雷电伤害增幅 => 1f + 道宝Config.羁绊雷电伤害增幅/100f ;
          public float 黑暗伤害增幅 => 1f + 道宝Config.羁绊黑暗伤害增幅/100f;
     }
     

     /// <summary>
     /// 灵植服用效果汇总：所有灵植叠加（普通次数×单次效果 + 变异次数×单次效果×变异倍数），
     /// 单位均为百分比（如 10 表示 +10%）。与其他模块的相同属性为独立乘区（相乘）。
     /// </summary>
     public class 灵植属性
     {
          private static float 汇总(Func<灵植效果, float> 取值)
          {
               float total = 0;
               foreach (var kv in 灵植园Config.灵植效果)
               {
                    float 单次 = 取值(kv.Value);
                    if (单次 == 0f) continue;
                    int 普通次数 = PlayerData.S.普通服用次数Dic != null && PlayerData.S.普通服用次数Dic.TryGetValue(kv.Key, out int c1) ? c1 : 0;
                    int 变异次数 = PlayerData.S.变异服用次数Dic != null && PlayerData.S.变异服用次数Dic.TryGetValue(kv.Key, out int c2) ? c2 : 0;
                    total += 单次 * (普通次数 + 变异次数 * 灵植园Config.变异倍数);
               }
               return total;
          }

          public float 城墙生命值 => 汇总(e => e.城墙生命值);
          public float 城墙防御 => 汇总(e => e.城墙防御);
          public float 暴击率 => 汇总(e => e.暴击率);
          public float 暴击伤害 => 汇总(e => e.暴击伤害);
          public float 最终伤害 => 汇总(e => e.最终伤害);
          public float 战士伤害 => 汇总(e => e.战士伤害);
          public float 射手伤害 => 汇总(e => e.射手伤害);
          public float 控制伤害 => 汇总(e => e.控制伤害);
          public float 法师伤害 => 汇总(e => e.法师伤害);
          public float 黑暗伤害 => 汇总(e => e.黑暗伤害);
          public float 火焰伤害 => 汇总(e => e.火焰伤害);
          public float 雷电伤害 => 汇总(e => e.雷电伤害);
          public float 物理伤害 => 汇总(e => e.物理伤害);
          public float 冰霜伤害 => 汇总(e => e.冰霜伤害);
          public float 职业伤害 => 汇总(e => e.职业伤害);
          public float 元素伤害 => 汇总(e => e.元素伤害);
          public float 掉宝率 => 汇总(e => e.掉宝率);
          public float 灵气增幅 => 汇总(e => e.灵气增幅);
          public float 功德增幅 => 汇总(e => e.功德增幅);
          public float 跟脚 => 汇总(e => e.跟脚);
          public float 真灵 => 汇总(e => e.真灵);
          public float 时间流速 => 汇总(e => e.时间流速);
          public float 修炼速度 => 汇总(e => e.修炼速度);
     }

     public static 灵植属性 灵植总属性 = new 灵植属性();


     public class 领主总属性
{
    // 创建装备属性和道宝属性的实例
    private 装备属性 _装备 = new 装备属性();
    private 道宝属性 _道宝 = new 道宝属性();
    private 神物属性 _神物 = new 神物属性();

    public float Get元素伤害增幅(YuanSuType yuanSuType)
    {
         float 物理伤害 = 纯物理伤害增幅-1f;
         float 冰霜伤害 = 纯冰霜伤害增幅-1f;
         float 雷电伤害 = 纯雷电伤害增幅-1f;
         float 黑暗伤害 = 纯黑暗伤害增幅-1f;
         float 火焰伤害 = 纯火焰伤害增幅-1f;
         YuanSuType 最小元素 = YuanSuType.None;
         YuanSuType 最大元素 = YuanSuType.None;
          float min=float.MaxValue;
          float max=float.MinValue;
          if (物理伤害 <= 冰霜伤害 && 物理伤害 <= 火焰伤害 && 物理伤害 <= 黑暗伤害 && 物理伤害 <= 雷电伤害)
          {
               最小元素 = YuanSuType.物理;
               min = 物理伤害;
          }
          if (冰霜伤害 <= 物理伤害 && 冰霜伤害 <= 火焰伤害 && 冰霜伤害 <= 黑暗伤害 && 冰霜伤害 <= 雷电伤害)
          {
               最小元素 = YuanSuType.冰;
               min = 冰霜伤害;
          }
          if (火焰伤害 <= 冰霜伤害 && 火焰伤害 <= 物理伤害 && 火焰伤害 <= 黑暗伤害 && 火焰伤害 <= 雷电伤害)
          {
               最小元素 = YuanSuType.火;
               min = 火焰伤害;
          }
          if (黑暗伤害 <= 冰霜伤害 && 黑暗伤害 <= 火焰伤害 && 黑暗伤害 <= 物理伤害 && 黑暗伤害 <= 雷电伤害)
          {
               最小元素 = YuanSuType.黑暗;
               min = 黑暗伤害;
          }
          if (雷电伤害 <= 冰霜伤害 && 雷电伤害 <= 火焰伤害 && 雷电伤害 <= 黑暗伤害 && 雷电伤害 <= 物理伤害)
          {
               最小元素 = YuanSuType.电;
               min = 雷电伤害;
          }
          
          
          if (物理伤害 >= 冰霜伤害 && 物理伤害 >= 火焰伤害 && 物理伤害 >= 黑暗伤害 && 物理伤害 >= 雷电伤害)
          {
               最大元素 = YuanSuType.物理;
               max = 物理伤害;
          }
          if (冰霜伤害 >= 物理伤害 && 冰霜伤害 >= 火焰伤害 && 冰霜伤害 >= 黑暗伤害 && 冰霜伤害 >= 雷电伤害)
          {
               最大元素 = YuanSuType.冰;
               max = 冰霜伤害;
          }
          if (火焰伤害 >= 冰霜伤害 && 火焰伤害 >= 物理伤害 && 火焰伤害 >= 黑暗伤害 && 火焰伤害 >= 雷电伤害)
          {
               最大元素 = YuanSuType.火;
               max = 火焰伤害;
          }
          if (黑暗伤害 >= 冰霜伤害 && 黑暗伤害 >= 火焰伤害 && 黑暗伤害 >= 物理伤害 && 黑暗伤害 >= 雷电伤害)
          {
               最大元素 = YuanSuType.黑暗;
               max = 黑暗伤害;
          }
          if (雷电伤害 >= 冰霜伤害 && 雷电伤害 >= 火焰伤害 && 雷电伤害 >= 黑暗伤害 && 雷电伤害 >= 物理伤害)
          {
               最大元素 = YuanSuType.电;
               max = 雷电伤害;
          }

          if (_神物.元素我为人人!=0)
          {
               switch (最小元素)
               {
                    case YuanSuType.冰:
                         物理伤害 += 冰霜伤害;
                         雷电伤害 += 冰霜伤害;
                         火焰伤害 += 冰霜伤害;
                         黑暗伤害 += 冰霜伤害;
                         break;
                    case YuanSuType.火:
                         物理伤害 += 火焰伤害;
                         雷电伤害 += 火焰伤害;
                         冰霜伤害 += 火焰伤害;
                         黑暗伤害 += 火焰伤害;
                         break;
                    case YuanSuType.电:
                         物理伤害 += 雷电伤害;
                         冰霜伤害 += 雷电伤害;
                         火焰伤害 += 雷电伤害;
                         黑暗伤害 += 雷电伤害;
                         break;
                    case YuanSuType.黑暗:
                         物理伤害 += 黑暗伤害;
                         雷电伤害 += 黑暗伤害;
                         火焰伤害 += 黑暗伤害;
                         冰霜伤害 += 黑暗伤害;
                         break;
                    case YuanSuType.物理:
                         冰霜伤害 += 物理伤害;
                         雷电伤害 += 物理伤害;
                         火焰伤害 += 物理伤害;
                         黑暗伤害 += 物理伤害;
                         break;
               }
          }

          if (_神物.元素人人为我 != 0&&PlayerData.S.元素人人为我开关)
          {
               switch (最大元素)
               {
                    case YuanSuType.冰:
                         冰霜伤害 += 物理伤害 + 黑暗伤害 + 火焰伤害 + 雷电伤害;
                         物理伤害 = 0;
                         黑暗伤害 = 0;
                         火焰伤害 = 0;
                         雷电伤害 = 0;
                         break;
                    case YuanSuType.火:
                         火焰伤害 += 物理伤害 + 黑暗伤害 + 冰霜伤害 + 雷电伤害;
                         物理伤害 = 0;
                         黑暗伤害 = 0;
                         冰霜伤害 = 0;
                         雷电伤害 = 0;
                         break;
                    case YuanSuType.黑暗:
                         黑暗伤害 += 物理伤害 + 冰霜伤害 + 火焰伤害 + 雷电伤害;
                         物理伤害 = 0;
                         冰霜伤害 = 0;
                         火焰伤害 = 0;
                         雷电伤害 = 0;
                         break;
                    case YuanSuType.电:
                         雷电伤害 += 物理伤害 + 黑暗伤害 + 火焰伤害 + 冰霜伤害;
                         物理伤害 = 0;
                         黑暗伤害 = 0;
                         火焰伤害 = 0;
                         冰霜伤害 = 0;
                         break;
                    case YuanSuType.物理:
                         物理伤害 += 冰霜伤害 + 黑暗伤害 + 火焰伤害 + 雷电伤害;
                         冰霜伤害 = 0;
                         黑暗伤害 = 0;
                         火焰伤害 = 0;
                         雷电伤害 = 0;
                         break;
               }
          }

          switch (yuanSuType)
          {
               case YuanSuType.冰:
                    return 冰霜伤害+1f;
               case YuanSuType.火:
                    return 火焰伤害+1f;
               case YuanSuType.电:
                    return 雷电伤害+1f;
               case YuanSuType.黑暗:
                    return 黑暗伤害+1f;
               case YuanSuType.物理:
                    return 物理伤害+1f;
          }

          return 0;
    }
    
    
    
    public float Get职业伤害增幅(ZhiYeType zhiYeType)
    {
         float 射手伤害 = 纯射手伤害增幅-1f;
         float 战士伤害 = 纯战士伤害增幅-1f;
         float 辅助伤害 = 纯辅助伤害增幅-1f;
         float 法师伤害 = 纯法师伤害增幅-1f;
         float 控制伤害 = 纯控制伤害增幅-1f;
         ZhiYeType 最小职业 = ZhiYeType.None;
         ZhiYeType 最大职业 = ZhiYeType.None;
          float min=float.MaxValue;
          float max=float.MinValue;
          if (射手伤害 <= 战士伤害 && 射手伤害 <= 控制伤害 && 射手伤害 <= 法师伤害 && 射手伤害 <= 辅助伤害)
          {
               最小职业 = ZhiYeType.射手;
               min = 射手伤害;
          }
          if (战士伤害 <= 射手伤害 && 战士伤害 <= 控制伤害 && 战士伤害 <= 法师伤害 && 战士伤害 <= 辅助伤害)
          {
               最小职业 = ZhiYeType.战士;
               min = 战士伤害;
          }
          if (控制伤害 <= 战士伤害 && 控制伤害 <= 射手伤害 && 控制伤害 <= 法师伤害 && 控制伤害 <= 辅助伤害)
          {
               最小职业 = ZhiYeType.控制;
               min = 控制伤害;
          }
          if (法师伤害 <= 战士伤害 && 法师伤害 <= 控制伤害 && 法师伤害 <= 射手伤害 && 法师伤害 <= 辅助伤害)
          {
               最小职业 = ZhiYeType.法师;
               min = 法师伤害;
          }
          if (辅助伤害 <= 战士伤害 && 辅助伤害 <= 控制伤害 && 辅助伤害 <= 法师伤害 && 辅助伤害 <= 射手伤害)
          {
               最小职业 = ZhiYeType.辅助;
               min = 辅助伤害;
          }
          
          
          if (射手伤害 >= 战士伤害 && 射手伤害 >= 控制伤害 && 射手伤害 >= 法师伤害 && 射手伤害 >= 辅助伤害)
          {
               最大职业 = ZhiYeType.射手;
               max = 射手伤害;
          }
          if (战士伤害 >= 射手伤害 && 战士伤害 >= 控制伤害 && 战士伤害 >= 法师伤害 && 战士伤害 >= 辅助伤害)
          {
               最大职业 = ZhiYeType.战士;
               max = 战士伤害;
          }
          if (控制伤害 >= 战士伤害 && 控制伤害 >= 射手伤害 && 控制伤害 >= 法师伤害 && 控制伤害 >= 辅助伤害)
          {
               最大职业 = ZhiYeType.控制;
               max = 控制伤害;
          }
          if (法师伤害 >= 战士伤害 && 法师伤害 >= 控制伤害 && 法师伤害 >= 射手伤害 && 法师伤害 >= 辅助伤害)
          {
               最大职业 = ZhiYeType.法师;
               max = 法师伤害;
          }
          if (辅助伤害 >= 战士伤害 && 辅助伤害 >= 控制伤害 && 辅助伤害 >= 法师伤害 && 辅助伤害 >= 射手伤害)
          {
               最大职业 = ZhiYeType.辅助;
               max = 辅助伤害;
          }

          if (_神物.职业我为人人!=0)
          {
               switch (最小职业)
               {
                    case ZhiYeType.战士:
                         射手伤害 += 战士伤害;
                         辅助伤害 += 战士伤害;
                         控制伤害 += 战士伤害;
                         法师伤害 += 战士伤害;
                         break;
                    case ZhiYeType.控制:
                         射手伤害 += 控制伤害;
                         辅助伤害 += 控制伤害;
                         战士伤害 += 控制伤害;
                         法师伤害 += 控制伤害;
                         break;
                    case ZhiYeType.辅助:
                         射手伤害 += 辅助伤害;
                         战士伤害 += 辅助伤害;
                         控制伤害 += 辅助伤害;
                         法师伤害 += 辅助伤害;
                         break;
                    case ZhiYeType.法师:
                         射手伤害 += 法师伤害;
                         辅助伤害 += 法师伤害;
                         控制伤害 += 法师伤害;
                         战士伤害 += 法师伤害;
                         break;
                    case ZhiYeType.射手:
                         战士伤害 += 射手伤害;
                         辅助伤害 += 射手伤害;
                         控制伤害 += 射手伤害;
                         法师伤害 += 射手伤害;
                         break;
               }
          }

          if (_神物.职业人人为我 != 0&&PlayerData.S.职业人人为我开关)
          {
               switch (最大职业)
               {
                    case ZhiYeType.战士:
                         战士伤害 += 射手伤害 + 法师伤害 + 控制伤害 + 辅助伤害;
                         射手伤害 = 0;
                         法师伤害 = 0;
                         控制伤害 = 0;
                         辅助伤害 = 0;
                         break;
                    case ZhiYeType.控制:
                         控制伤害 += 射手伤害 + 法师伤害 + 战士伤害 + 辅助伤害;
                         射手伤害 = 0;
                         法师伤害 = 0;
                         战士伤害 = 0;
                         辅助伤害 = 0;
                         break;
                    case ZhiYeType.法师:
                         法师伤害 += 射手伤害 + 战士伤害 + 控制伤害 + 辅助伤害;
                         射手伤害 = 0;
                         战士伤害 = 0;
                         控制伤害 = 0;
                         辅助伤害 = 0;
                         break;
                    case ZhiYeType.辅助:
                         辅助伤害 += 射手伤害 + 法师伤害 + 控制伤害 + 战士伤害;
                         射手伤害 = 0;
                         法师伤害 = 0;
                         控制伤害 = 0;
                         战士伤害 = 0;
                         break;
                    case ZhiYeType.射手:
                         射手伤害 += 战士伤害 + 法师伤害 + 控制伤害 + 辅助伤害;
                         战士伤害 = 0;
                         法师伤害 = 0;
                         控制伤害 = 0;
                         辅助伤害 = 0;
                         break;
               }
          }

          switch (zhiYeType)
          {
               case ZhiYeType.战士:
                    return 战士伤害+1f;
               case ZhiYeType.控制:
                    return 控制伤害+1f;
               case ZhiYeType.辅助:
                    return 辅助伤害+1f;
               case ZhiYeType.法师:
                    return 法师伤害+1f;
               case ZhiYeType.射手:
                    return 射手伤害+1f;
          }

          return 0;
    }
    
    
    public float 暴击伤害 => 200 *(1+_神物.暴击爆伤)*(1+体质Config.当前体质总属性.暴击伤害/100f) * (1+灵植总属性.暴击伤害/100f);
    public BigDouble 总攻击力=>Get境界攻击力()*(1f+_装备.装备总攻击力增幅);
    public float 二次暴击 => _神物.二次暴击;
    public float 轮回次数加伤 => (1+_神物.轮回次数加伤)*(1f+体质Config.当前体质总属性.轮回次数加伤害/100f)-1;
    public float 轮回系数 => (1+_神物.轮回系数)*(1f+体质Config.当前体质总属性.轮回系数/100f);
    public float 时间流速加快 => (1+_神物.时间流速加快)*(1+体质Config.当前体质总属性.时间流速加成/100f) *(1+ 灵植总属性.时间流速/100f)-1;

    // 灵植为独立乘区；灵植"职业伤害"分别加到 战士/射手/控制/法师 4 种职业上；体质全局乘算
    private float 纯战士伤害增幅 => _装备.战士增幅 *(1+_神物.全职业增伤)*(1f+体质Config.当前体质总属性.战士伤害/100f)*(1f+灵植总属性.战士伤害/100f)*(1f+灵植总属性.职业伤害/100f);
    private float 纯法师伤害增幅 => _装备.法师增幅 *_道宝.法师增幅*(1+_神物.全职业增伤)*(1f+体质Config.当前体质总属性.法师伤害/100f)*(1f+灵植总属性.法师伤害/100f)*(1f+灵植总属性.职业伤害/100f);
    private float 纯射手伤害增幅 => _装备.射手增幅 *_道宝.射手增幅*(1+_神物.全职业增伤)*(1f+体质Config.当前体质总属性.射手伤害/100f)*(1f+灵植总属性.射手伤害/100f)*(1f+灵植总属性.职业伤害/100f);
    private float 纯控制伤害增幅 => _装备.控制增幅 *(1+_神物.全职业增伤)*(1f+体质Config.当前体质总属性.控制伤害/100f)*(1f+灵植总属性.控制伤害/100f)*(1f+灵植总属性.职业伤害/100f);
    private float 纯辅助伤害增幅 => (1+_神物.全职业增伤)*(1f+体质Config.当前体质总属性.辅助伤害/100f);
    
    
    public float 战士增幅 => Get职业伤害增幅(ZhiYeType.战士);
    public float 法师增幅 => Get职业伤害增幅(ZhiYeType.法师);
    public float 射手增幅 => Get职业伤害增幅(ZhiYeType.射手);
    public float 控制增幅 => Get职业伤害增幅(ZhiYeType.控制);
    
    public float 辅助增幅 => Get职业伤害增幅(ZhiYeType.辅助);

    // 灵植为独立乘区；灵植"元素伤害"分别加到 物理/火焰/冰霜/雷电/黑暗 5 种元素上；体质全局乘算
    private float 纯物理伤害增幅 => _装备.物理伤害增幅 *_道宝.物理伤害增幅*(1f+_神物.全元素增伤)*(1f+体质Config.当前体质总属性.物理伤害/100f)*(1f+灵植总属性.物理伤害/100f)*(1f+灵植总属性.元素伤害/100f);
    private float 纯火焰伤害增幅 => _装备.火焰伤害增幅 *_道宝.火焰伤害增幅*(1f+_神物.全元素增伤)*(1f+体质Config.当前体质总属性.火焰伤害/100f)*(1f+灵植总属性.火焰伤害/100f)*(1f+灵植总属性.元素伤害/100f);
    private float 纯冰霜伤害增幅 => _装备.冰霜伤害增幅 *_道宝.冰霜伤害增幅*(1f+_神物.全元素增伤)*(1f+体质Config.当前体质总属性.冰霜伤害/100f)*(1f+灵植总属性.冰霜伤害/100f)*(1f+灵植总属性.元素伤害/100f);
    private float 纯雷电伤害增幅 => _装备.雷电伤害增幅 *_道宝.雷电伤害增幅*(1f+_神物.全元素增伤)*(1f+体质Config.当前体质总属性.雷电伤害/100f)*(1f+灵植总属性.雷电伤害/100f)*(1f+灵植总属性.元素伤害/100f);
    private float 纯黑暗伤害增幅 => _装备.黑暗伤害增幅 *_道宝.黑暗伤害增幅*(1f+_神物.全元素增伤)*(1f+体质Config.当前体质总属性.黑暗伤害/100f)*(1f+灵植总属性.黑暗伤害/100f)*(1f+灵植总属性.元素伤害/100f);
    public float 物理伤害增幅 => Get元素伤害增幅(YuanSuType.物理);//处理元素人人为我和我为人人
    public float 火焰伤害增幅 => Get元素伤害增幅(YuanSuType.火);
    public float 冰霜伤害增幅 => Get元素伤害增幅(YuanSuType.冰);
    public float 雷电伤害增幅 => Get元素伤害增幅(YuanSuType.电);
    public float 黑暗伤害增幅 => Get元素伤害增幅(YuanSuType.黑暗);
    public float 普通怪伤害增幅 => _装备.普通怪伤害增幅 ;
    public float 精英怪伤害增幅 => _装备.精英怪伤害增幅 ;
    public float 首领伤害增幅 => _装备.首领伤害增幅 ;
    public float 城墙血量增幅 => _装备.城墙血量增幅*(1f+灵植总属性.城墙生命值/100f); // 装备的是血量增幅
    public float 暴击率 => _装备.暴击率+_道宝.暴击率+灵植总属性.暴击率/100f+_神物.暴击爆伤;
    public float 英雄冷却缩减 => 0+_神物.冷却缩减;
    public float 最终伤害增幅 => (1f+_装备.最终伤害)*(1f+_道宝.最终伤害)*(1f+_神物.最终伤害)*(1f+体质Config.当前体质总属性.最终伤害/100f)*(1f+灵植总属性.最终伤害/100f)*(1f+Get众仙总增幅()/100f);
    public float 伤害减免 => 1-(1-_道宝.伤害减免)*(1-城墙Config.伤害减免/100f);

    public float 神通最大值 => 150;
    public float 神通能量恢复速度 => 2;
}

     public static float Get装备攻击力增幅()
     {
          float 装备属性增幅 = 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.装备基础属性增幅]() ;
          float 装备基础属性 = 0;
          装备基础属性 += EquipConfig.Get装备基础攻击力(PlayerData.S.EquipLevelDic[EquipType.头盔])/100f ;
          装备基础属性 += EquipConfig.Get装备基础攻击力(PlayerData.S.EquipLevelDic[EquipType.护手])/100f ;
          装备基础属性 += EquipConfig.Get装备基础攻击力(PlayerData.S.EquipLevelDic[EquipType.戒指])/100f ;
          装备基础属性 += EquipConfig.Get装备基础攻击力(PlayerData.S.EquipLevelDic[EquipType.鞋子])/100f ;
          装备基础属性 += EquipConfig.Get装备基础攻击力(PlayerData.S.EquipLevelDic[EquipType.项链])/100f ;
          装备基础属性 += EquipConfig.Get装备基础攻击力(PlayerData.S.EquipLevelDic[EquipType.衣服])/100f ;
          return 装备基础属性 * 装备属性增幅;
     }

     public static BigDouble Get境界攻击力()
     {
          BigDouble 基础攻击 = JingJieConfig.JingJieAttributeDic[PlayerData.S.当前轮回境界];

          return 基础攻击 * JingJieConfig.Get跟脚();
     }

     /// <summary>
     /// 众仙：全英雄技能树「增加所有英雄伤害」求和，所有英雄共享，归入全局最终伤害乘区。
     /// </summary>
     public static float Get众仙总增幅()
     {
          float value = 0;
          foreach (var item in HeroConfig.HeroQualityDic)
          {
               value += 英雄技能树Config.Get英雄技能树属性(item.Key).增加所有英雄伤害;
          }
          return value;
     }
     public static BigDouble 基础境界攻击力=>Get境界攻击力();
     public static 领主总属性 总属性=new 领主总属性();

     /// <summary>
     /// 实时计算指定英雄合成后的最终属性（全局共享部分 × 英雄专属部分）。
     /// 全部增幅字段为百分比数（50 表示 +50%）；真灵为基础值。
     /// </summary>
     public static 英雄属性 Get英雄属性(HeroType heroType)
     {
          var heroData = PlayerData.S.HeroDataDic[heroType];
          var 职业元素 = HeroConfig.HeroZhiYeDic[heroType];
          var 法器 = 法器Config.Get英雄法器属性(heroType);
          var 技能树 = 英雄技能树Config.Get英雄技能树属性(heroType);
          var 根基丹药 = 丹药Config.Get英雄根基丹药属性(heroType);
          var 体质 = 体质Config.当前体质总属性;
          var 灵兽 = heroData.灵兽;
          bool 有灵兽 = 灵兽 != null;

          var 结果 = new 英雄属性();
          结果.真灵 = HeroConfig.英雄基础真灵[HeroConfig.HeroQualityDic[heroType]];

          // 暴击率：全局(分数×100) + 法器 + 技能树（加和）
          结果.暴击率 = 总属性.暴击率 * 100f + 法器.暴击率 + 技能树.暴击率;

          // 暴击伤害：总属性已含神物+体质+灵植乘区，再乘英雄专属乘区
          float 暴击伤害 = 总属性.暴击伤害
               * (1f + 法器.暴击伤害 / 100f)
               * (1f + 技能树.暴击伤害 / 100f)
               * (1f + 根基丹药.暴击伤害 / 100f);
          if (职业元素.zhiYeType == ZhiYeType.法师 && heroData.功法Type != 功法Type.None)
          {
               暴击伤害 *= 1f + 功法Config.功法基础属性Dic[heroData.功法Type].count / 100f;
          }
          if (有灵兽)
          {
               暴击伤害 *= 1f + 灵兽坊Config.Get灵兽暴击伤害总增幅(灵兽) / 100f;
          }
          结果.暴击伤害 = 暴击伤害;

          // 元素增幅：总属性已含体质/装备/道宝/神物/灵植，再乘英雄专属（法器/技能树/根基丹药）
          float 法器元素 = 0, 技能树元素 = 0, 丹药元素 = 0, 法器穿透 = 0;
          switch (职业元素.yuanSuType)
          {
               case YuanSuType.物理:
                    法器元素 = 法器.物理伤害; 技能树元素 = 技能树.物理伤害; 丹药元素 = 根基丹药.物理伤害; 法器穿透 = 法器.物理穿透;
                    break;
               case YuanSuType.火:
                    法器元素 = 法器.火焰伤害; 技能树元素 = 技能树.火焰伤害; 丹药元素 = 根基丹药.火焰伤害; 法器穿透 = 法器.火焰穿透;
                    break;
               case YuanSuType.冰:
                    法器元素 = 法器.冰霜伤害; 技能树元素 = 技能树.冰霜伤害; 丹药元素 = 根基丹药.冰霜伤害; 法器穿透 = 法器.冰霜穿透;
                    break;
               case YuanSuType.电:
                    法器元素 = 法器.雷电伤害; 技能树元素 = 技能树.雷电伤害; 丹药元素 = 根基丹药.雷电伤害; 法器穿透 = 法器.雷电穿透;
                    break;
               case YuanSuType.黑暗:
                    法器元素 = 法器.黑暗伤害; 技能树元素 = 技能树.黑暗伤害; 丹药元素 = 根基丹药.黑暗伤害; 法器穿透 = 法器.黑暗穿透;
                    break;
          }
          float 元素倍率 = 总属性.Get元素伤害增幅(职业元素.yuanSuType)
               * (1f + 法器元素 / 100f)
               * (1f + 技能树元素 / 100f)
               * (1f + 丹药元素 / 100f);
          if (有灵兽)
          {
               元素倍率 *= 1f + 灵兽坊Config.Get灵兽元素伤害总增幅(灵兽) / 100f;
          }
          结果.元素增幅 = (元素倍率 - 1f) * 100f;
          结果.元素穿透 = 法器穿透;

          // 职业增幅：总属性已含体质/装备/道宝/神物/灵植（底层纯职业乘区已加体质）
          结果.职业增幅 = (总属性.Get职业伤害增幅(职业元素.zhiYeType) - 1f) * 100f;

          // 最终伤害：总属性已含神物/体质/灵植/众仙，再乘英雄专属
          float 最终倍率 = 总属性.最终伤害增幅
               * (1f + 法器.最终伤害 / 100f)
               * (1f + 技能树.英雄伤害 / 100f)
               * (1f + 根基丹药.最终伤害 / 100f);
          if (heroData.功法Type != 功法Type.None)
          {
               float 每重奖励 = 功法Config.功法升级最终伤害奖励Dic[功法Config.功法TypeQualityDic[heroData.功法Type]];
               float 功法伤害加成 = heroData.功法等级 * 每重奖励 / 100f
                    * (1f + 体质.功法每层效果 / 100f)
                    * (1f + 功法Config.Get功法星级总增幅(heroData.功法星级) / 100f);
               最终倍率 *= 1f + 功法伤害加成;
          }
          if (有灵兽)
          {
               最终倍率 *= 1f + 灵兽坊Config.Get灵兽最终伤害总增幅(灵兽) / 100f;
          }
          结果.最终伤害 = (最终倍率 - 1f) * 100f;

          // 冷却缩减：神物(分数×100) + 技能树技能冷却缩减 + 射手系功法冷却缩减（加和）
          float 冷却 = 总属性.英雄冷却缩减 * 100f + 技能树.技能冷却缩减;
          if (heroData.功法Type != 功法Type.None
               && 功法Config.功法基础属性Dic[heroData.功法Type].功法属性Type == 功法属性Type.冷却缩减)
          {
               冷却 += 功法Config.功法基础属性Dic[heroData.功法Type].count;
          }
          结果.冷却缩减 = 冷却;

          结果.效果范围 = 技能树.效果范围;

          // 三怪增伤：全局(装备倍率) × 法器 × 技能树
          结果.普通怪增伤 = (总属性.普通怪伤害增幅 * (1f + 法器.普通怪增伤 / 100f) * (1f + 技能树.普通怪增伤 / 100f) - 1f) * 100f;
          结果.精英怪增伤 = (总属性.精英怪伤害增幅 * (1f + 法器.精英怪增伤 / 100f) * (1f + 技能树.精英怪增伤 / 100f) - 1f) * 100f;
          结果.首领怪增伤 = (总属性.首领伤害增幅 * (1f + 法器.首领怪增伤 / 100f) * (1f + 技能树.首领怪增伤 / 100f) - 1f) * 100f;

          // 攻击距离：职业基础范围 + 战士系功法附加（与 人物item.SetItem 口径一致）
          float 攻击距离 = HeroConfig.攻击范围Dic[职业元素.zhiYeType];
          if (职业元素.zhiYeType == ZhiYeType.战士 && heroData.功法Type != 功法Type.None)
          {
               攻击距离 += 功法Config.功法基础属性Dic[heroData.功法Type].count;
          }
          结果.攻击距离 = 攻击距离;

          // 普通攻击间隔：基础Cd ÷ 技能树冷却 ÷ 体质攻速 ÷ 全局冷却 ÷ 射手系功法（不含战斗内随机浮动与女娲电辅助）
          float 普通攻击间隔 = 英雄星级属性.Get英雄Cd(heroType);
          普通攻击间隔 /= (1f + 技能树.技能冷却缩减 / 100f);
          普通攻击间隔 /= (1f + 体质.攻击速度 / 100f);
          普通攻击间隔 /= (1f + 总属性.英雄冷却缩减);
          if (职业元素.zhiYeType == ZhiYeType.射手 && heroData.功法Type != 功法Type.None)
          {
               普通攻击间隔 /= (1f + 功法Config.功法基础属性Dic[heroData.功法Type].count / 100f);
          }
          结果.普通攻击间隔 = 普通攻击间隔;

          // 神通攻击间隔：神通基础Cd ÷ (1 - 技能树神通冷却缩减/100)
          结果.神通攻击间隔 = HeroConfig.英雄神通配置Dic[heroType].cd / (1f - 技能树.神通冷却时间 / 100f);

          结果.寻宝速度增幅 = 技能树.寻宝速度;
          return 结果;
     }

     private static Dictionary<HeroType, 英雄属性> Get英雄属性字典()
     {
          var dic = new Dictionary<HeroType, 英雄属性>();
          foreach (var item in HeroConfig.HeroQualityDic)
          {
               dic[item.Key] = Get英雄属性(item.Key);
          }
          return dic;
     }
     public static float 显示修炼速度 => ((1f+PlayerData.S.关卡修炼速度加成/100f) * (1f+道宝Config.Get道宝总修炼速度()/100f)-1)*100f;
     public static float 丹药修炼速度 => Get丹药修炼速度();

     public static float 总修炼速度加成 => (1 + 显示修炼速度/100f) * (1f + 丹药修炼速度 / 100f)*体质Config.体质修炼速度Dic[体质Config.体质品质Dic[PlayerData.S.当前体质]]*(1f+灵植总属性.修炼速度/100f);
     public static float 每年秒数 => Get每秒数();

     public static float 丹药掉宝率 => Get丹药掉宝率();

     public static float 总掉宝率 => Get总掉宝率();

     public static float Get总掉宝率()
     {
          float value=(1f+丹药掉宝率/100f)*(1f+体质Config.当前体质总属性.掉宝率/100f)*(1f+灵植总属性.掉宝率/100f);
          if (PlayerData.S.是否加入愿望单)
          {
               value *= 1.2f;
          }
          value *= (1f + (PlayerData.S.混沌虚空最大层数 - 1) / 100f);
          return value;
     }
     public static float Get丹药掉宝率()
     {
          float count = 0;
          for (int i = 1; i <= 8; i++)
          {
               for (int j = 1; j <= PlayerData.Get丹药最高阶段((QualityType)i); j++)
               {
                    if (PlayerData.S.Get辅助丹药Buff(丹药Type.掉宝率, (QualityType)i, j) > 0)
                    {
                         count += 丹药Config.Get丹药值(丹药Type.掉宝率, (QualityType)i, j);
                    }
               }
          }
          return count*(1f+体质Config.当前体质总属性.丹药效果/100f);
     }

     // 灵气增幅：混沌虚空层数 + 灵植服用效果（各处灵魂/灵气获取按 1+灵气增幅 结算）
     public static float 灵气增幅 => ((PlayerData.S.混沌虚空最大层数 - 1) / 100f+1) * (1+灵植总属性.灵气增幅/100f)-1;
     public static float Get丹药修炼速度()
     {
          float count = 0;
          for (int i = 1; i <= 8; i++)
          {
               for (int j = 1; j <= PlayerData.Get丹药最高阶段((QualityType)i); j++)
               {
                    if (PlayerData.S.Get辅助丹药Buff(丹药Type.修炼速度, (QualityType)i, j) > 0)
                    {
                         count += 丹药Config.Get丹药值(丹药Type.修炼速度, (QualityType)i, j);
                    }
               }
          }

          return count*(1f+体质Config.当前体质总属性.丹药效果/100f);
     }
     public static float Get每秒数()
     {
          float value=JingJieConfig.每年秒数Dic[PlayerData.S.历史最高境界];
          value /= (1f + 总属性.时间流速加快);
          return value;
     }
}
