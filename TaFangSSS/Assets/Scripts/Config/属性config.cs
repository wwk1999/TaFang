using System;
using System.Collections.Generic;
using Config;

public class 属性config
{
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

          return value ;
     }
     public class 道纹属性
     {
          public float 增加百分比攻击力 =>  道纹config.Get道纹数值(道纹Type.增加百分比攻击力);
          public float 增加战士伤害 => 1f + 道纹config.Get道纹数值(道纹Type.增加战士伤害);
          public float 增加法师伤害 => 1f + 道纹config.Get道纹数值(道纹Type.增加法师伤害);
          public float 增加控制伤害 => 1f + 道纹config.Get道纹数值(道纹Type.增加控制伤害);
          public float 增加射手伤害 => 1f + 道纹config.Get道纹数值(道纹Type.增加射手伤害);
          public float 增加小怪伤害 => 1f + 道纹config.Get道纹数值(道纹Type.增加小怪伤害);
          public float 增加精英怪和首领伤害 => 1f + 道纹config.Get道纹数值(道纹Type.增加精英怪和首领伤害);
          public float 增加物理伤害 => 1f + 道纹config.Get道纹数值(道纹Type.增加物理伤害);
          public float 增加雷电伤害 => 1f + 道纹config.Get道纹数值(道纹Type.增加雷电伤害);
          public float 增加冰霜伤害 => 1f + 道纹config.Get道纹数值(道纹Type.增加冰霜伤害);
          public float 增加黑暗伤害 => 1f + 道纹config.Get道纹数值(道纹Type.增加黑暗伤害);
          public float 增加火焰伤害 => 1f + 道纹config.Get道纹数值(道纹Type.增加火焰伤害);
          public float 城墙低血增加伤害 => 1f + 道纹config.Get道纹数值(道纹Type.城墙低血增加伤害);
          public float 击杀精英怪城墙回血 => 道纹config.Get道纹数值(道纹Type.击杀精英怪城墙回血);
          public float 城墙血量百分比 => 1f + 道纹config.Get道纹数值(道纹Type.城墙血量百分比);
          public float 城墙免疫伤害 => 道纹config.Get道纹数值(道纹Type.城墙免疫伤害)*100;
          public float 城墙满血时加伤害 => 1f + 道纹config.Get道纹数值(道纹Type.城墙满血时加伤害);
          public float 英雄暴击率 => 道纹config.Get道纹数值(道纹Type.英雄暴击率);
          public float 伤害在范围内浮动 => 道纹config.Get道纹数值(道纹Type.伤害在范围内浮动);
          public float 无视抗性 => 道纹config.Get道纹数值(道纹Type.无视抗性);
          public float 战士对靠近城墙敌人伤害增高 => 1f + 道纹config.Get道纹数值(道纹Type.战士对靠近城墙敌人伤害增高);
          public float 射手对远距离敌人伤害增高 => 1f +道纹config.Get道纹数值(道纹Type.射手对远距离敌人伤害增高);
          public float 控制冷却缩减 => 道纹config.Get道纹数值(道纹Type.控制冷却缩减);
          public float 法师暴击率 => 道纹config.Get道纹数值(道纹Type.法师暴击率);
          public float 辅助被辅助英雄伤害增幅 => 1f + 道纹config.Get道纹数值(道纹Type.辅助被辅助英雄伤害增幅);
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
          if (PlayerData.S.神物获得Dic[type])
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
     

     public class 领主总属性
{
    // 创建装备属性和道纹属性的实例
    private 装备属性 _装备 = new 装备属性();
    private 道纹属性 _道纹 = new 道纹属性();
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
                         冰霜伤害 = 0;
                         break;
                    case YuanSuType.火:
                         物理伤害 += 火焰伤害;
                         雷电伤害 += 火焰伤害;
                         冰霜伤害 += 火焰伤害;
                         黑暗伤害 += 火焰伤害;
                         火焰伤害 = 0;
                         break;
                    case YuanSuType.电:
                         物理伤害 += 雷电伤害;
                         冰霜伤害 += 雷电伤害;
                         火焰伤害 += 雷电伤害;
                         黑暗伤害 += 雷电伤害;
                         雷电伤害 = 0;
                         break;
                    case YuanSuType.黑暗:
                         物理伤害 += 黑暗伤害;
                         雷电伤害 += 黑暗伤害;
                         火焰伤害 += 黑暗伤害;
                         冰霜伤害 += 黑暗伤害;
                         黑暗伤害 = 0;
                         break;
                    case YuanSuType.物理:
                         冰霜伤害 += 物理伤害;
                         雷电伤害 += 物理伤害;
                         火焰伤害 += 物理伤害;
                         黑暗伤害 += 物理伤害;
                         物理伤害 = 0;
                         break;
               }
          }

          if (_神物.元素我为人人 != 0)
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
                         战士伤害 = 0;
                         break;
                    case ZhiYeType.控制:
                         射手伤害 += 控制伤害;
                         辅助伤害 += 控制伤害;
                         战士伤害 += 控制伤害;
                         法师伤害 += 控制伤害;
                         控制伤害 = 0;
                         break;
                    case ZhiYeType.辅助:
                         射手伤害 += 辅助伤害;
                         战士伤害 += 辅助伤害;
                         控制伤害 += 辅助伤害;
                         法师伤害 += 辅助伤害;
                         辅助伤害 = 0;
                         break;
                    case ZhiYeType.法师:
                         射手伤害 += 法师伤害;
                         辅助伤害 += 法师伤害;
                         控制伤害 += 法师伤害;
                         战士伤害 += 法师伤害;
                         法师伤害 = 0;
                         break;
                    case ZhiYeType.射手:
                         战士伤害 += 射手伤害;
                         辅助伤害 += 射手伤害;
                         控制伤害 += 射手伤害;
                         法师伤害 += 射手伤害;
                         射手伤害 = 0;
                         break;
               }
          }

          if (_神物.元素我为人人 != 0)
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
    
    
    public float 暴击伤害 => 200 + Get英雄暴击伤害增幅()+_神物.暴击爆伤*100;
    public float 总攻击力=>Get境界攻击力()*(1f+_装备.装备总攻击力增幅)*(1f+_道纹.增加百分比攻击力);
    public float 二次暴击 => _神物.二次暴击;
    public float 轮回次数加伤 => _神物.轮回次数加伤;
    public float 轮回系数 => _神物.轮回系数;
    public float 时间流速加快 => _神物.时间流速加快+体质Config.当前体质总属性.时间流速加成/100f;

    private float 纯战士伤害增幅 => _装备.战士增幅 * _道纹.增加战士伤害*_道宝.战士增幅*(1+_神物.全职业增伤);
    private float 纯法师伤害增幅 => _装备.法师增幅 * _道纹.增加法师伤害*_道宝.法师增幅*(1+_神物.全职业增伤);
    private float 纯射手伤害增幅 => _装备.射手增幅 * _道纹.增加射手伤害*_道宝.射手增幅*(1+_神物.全职业增伤);
    private float 纯控制伤害增幅 => _装备.控制增幅 * _道纹.增加控制伤害*(1+_神物.全职业增伤);
    private float 纯辅助伤害增幅 => 1+_神物.全职业增伤;
    
    
    public float 战士增幅 => Get职业伤害增幅(ZhiYeType.战士);
    public float 法师增幅 => Get职业伤害增幅(ZhiYeType.法师);
    public float 射手增幅 => Get职业伤害增幅(ZhiYeType.射手);
    public float 控制增幅 => Get职业伤害增幅(ZhiYeType.控制);
    
    public float 辅助增幅 => Get职业伤害增幅(ZhiYeType.辅助);

    private float 纯物理伤害增幅 => _装备.物理伤害增幅 * _道纹.增加物理伤害*_道宝.物理伤害增幅*(1f+_神物.全元素增伤);
    private float 纯火焰伤害增幅 => _装备.火焰伤害增幅 * _道纹.增加火焰伤害*_道宝.火焰伤害增幅*(1f+_神物.全元素增伤);
    private float 纯冰霜伤害增幅 => _装备.冰霜伤害增幅 * _道纹.增加冰霜伤害*_道宝.冰霜伤害增幅*(1f+_神物.全元素增伤);
    private float 纯雷电伤害增幅 => _装备.雷电伤害增幅 * _道纹.增加雷电伤害*_道宝.雷电伤害增幅*(1f+_神物.全元素增伤);
    private float 纯黑暗伤害增幅 => _装备.黑暗伤害增幅 * _道纹.增加黑暗伤害*_道宝.黑暗伤害增幅*(1f+_神物.全元素增伤);
    public float 物理伤害增幅 => Get元素伤害增幅(YuanSuType.物理);//处理元素人人为我和我为人人
    public float 火焰伤害增幅 => Get元素伤害增幅(YuanSuType.火);
    public float 冰霜伤害增幅 => Get元素伤害增幅(YuanSuType.冰);
    public float 雷电伤害增幅 => Get元素伤害增幅(YuanSuType.电);
    public float 黑暗伤害增幅 => Get元素伤害增幅(YuanSuType.黑暗);
    public float 普通怪伤害增幅 => _装备.普通怪伤害增幅 * _道纹.增加小怪伤害;
    public float 精英怪伤害增幅 => _装备.精英怪伤害增幅 * _道纹.增加精英怪和首领伤害;
    public float 首领伤害增幅 => _装备.首领伤害增幅 * _道纹.增加精英怪和首领伤害;
    public float 城墙血量增幅 => _装备.城墙血量增幅*_道纹.城墙血量百分比; // 装备的是血量增幅
    public float 城墙低血增加伤害 => _道纹.城墙低血增加伤害;
    public float 击杀精英怪城墙回血 => _道纹.击杀精英怪城墙回血;
    public float 城墙免疫伤害 => _道纹.城墙免疫伤害;
    public float 城墙满血时加伤害 => _道纹.城墙满血时加伤害;
    public float 暴击率 => _道纹.英雄暴击率+_装备.暴击率+_道宝.暴击率+_神物.暴击爆伤;
    public float 法师暴击率 => _道纹.法师暴击率;
    public float 英雄冷却缩减 => 0+_神物.冷却缩减;
    public float 控制冷却缩减 => _道纹.控制冷却缩减;
    public float 伤害在范围内浮动 => _道纹.伤害在范围内浮动;
    public float 无视抗性 => _道纹.无视抗性;
    public float 战士对靠近城墙敌人伤害增高 => _道纹.战士对靠近城墙敌人伤害增高;
    public float 射手对远距离敌人伤害增高 => _道纹.射手对远距离敌人伤害增高;
    public float 辅助被辅助英雄伤害增幅 => _道纹.辅助被辅助英雄伤害增幅;
    public float 最终伤害增幅 => (1f+_装备.最终伤害)*(1f+_道宝.最终伤害)*(1f+_神物.最终伤害);
    public float 伤害减免 => 1-(1-_道宝.伤害减免/100f)*(1-城墙Config.伤害减免/100f);



    public float 三味真火无视抗性百分比 => 道纹config.Get道纹数值(道纹Type.三味真火无视抗性百分比);
    public float 孙悟空每秒增加伤害 => 道纹config.Get道纹数值(道纹Type.孙悟空每秒增加伤害);
    public float 碧霄冰龙再次释放概率 => 道纹config.Get道纹数值(道纹Type.碧霄冰龙有概率再次释放);
    public float 琼霄定身衰减减少 => 道纹config.Get道纹数值(道纹Type.琼霄定身衰减效果减少);
    public float 云霄最终伤害 => 1f + 道纹config.Get道纹数值(道纹Type.云霄最终伤害);
    public float 后羿距离增伤 => 道纹config.Get道纹数值(道纹Type.后羿距离越远伤害越高);
    public float 羲和灼烧伤害 => 1f + 道纹config.Get道纹数值(道纹Type.羲和灼烧伤害);
    public float 常曦冻结概率 => 道纹config.Get道纹数值(道纹Type.常曦有概率冻结敌人);
    public float 女娲辅助冷却缩减 => 道纹config.Get道纹数值(道纹Type.女娲增加被辅助冷却缩减);
    public float 通天暴击增伤 => 道纹config.Get道纹数值(道纹Type.通天每次暴击增加伤害);
    public float 老子体积增伤 => 道纹config.Get道纹数值(道纹Type.老子旋风体积越大伤害越高);
    public float 元始火种增加数量 => 道纹config.Get道纹数值(道纹Type.元始每次释放有概率增加火种数量);
    public float 鸿钧陨石增伤 => 道纹config.Get道纹数值(道纹Type.鸿钧每释放陨石增加伤害);
    public float 盘古击杀增伤 => 道纹config.Get道纹数值(道纹Type.盘古每击杀敌人增加伤害);
}

     public static float Get装备攻击力增幅()
     {
          float 装备属性增幅 = 1f + EquipConfig.装备附加属性数值Dic[附加属性Type.装备基础属性增幅]() ;
          float 装备基础属性 = 0;
          装备基础属性 += EquipConfig.装备基础攻击Dic[PlayerData.S.EquipLevelDic[EquipType.头盔]]/100f ;
          装备基础属性 += EquipConfig.装备基础攻击Dic[PlayerData.S.EquipLevelDic[EquipType.护手]]/100f ;
          装备基础属性 += EquipConfig.装备基础攻击Dic[PlayerData.S.EquipLevelDic[EquipType.戒指]]/100f ;
          装备基础属性 += EquipConfig.装备基础攻击Dic[PlayerData.S.EquipLevelDic[EquipType.鞋子]]/100f ;
          装备基础属性 += EquipConfig.装备基础攻击Dic[PlayerData.S.EquipLevelDic[EquipType.项链]]/100f ;
          装备基础属性 += EquipConfig.装备基础攻击Dic[PlayerData.S.EquipLevelDic[EquipType.戒指]]/100f ;
          return 装备基础属性 * 装备属性增幅;
     }

     public static float Get境界攻击力()
     {
          float 基础攻击 = JingJieConfig.JingJieAttributeDic[PlayerData.S.当前轮回境界];
          float 跟脚 = 1f;
          foreach (var item in PlayerData.S.当前轮回突破Dic)
          {
               if (item.Value != QualityType.None)
               {
                    跟脚 *= JingJieConfig.突破跟脚Dic[item.Value];
               }
          }

          return 基础攻击 * 跟脚;
     }
     public static float 基础境界攻击力=>Get境界攻击力();
     public static 领主总属性 总属性=new 领主总属性();
     public static float 显示修炼速度 => PlayerData.S.关卡修炼速度加成 + 道宝Config.Get道宝总修炼速度();
     public static float 丹药修炼速度 => Get丹药修炼速度();

     public static float 总修炼速度加成 => (1 + 显示修炼速度 / 100f) * (1f + 丹药修炼速度 / 100f);
     public static float 每年秒数 => Get每秒数();

     public static float 丹药掉宝率 => Get丹药掉宝率();
     
     public static float 总掉宝率 => (1f+丹药掉宝率/100f)*(1f+体质Config.当前体质总属性.掉宝率/100f);
     
     public static float Get丹药掉宝率()
     {
          float count = 0;
          for (int i = 1; i <= 8; i++)
          {
               if (PlayerData.S.Get辅助丹药Buff(丹药Type.掉宝率, (QualityType)i) > 0)
               {
                    count += 丹药Config.Get丹药值(丹药Type.掉宝率, (QualityType)i);
               }
          }
          return count*(1f+体质Config.当前体质总属性.丹药效果/100f);
     }
     public static float Get丹药修炼速度()
     {
          float count = 0;
          for (int i = 1; i <= 8; i++)
          {
               if (PlayerData.S.Get辅助丹药Buff(丹药Type.修炼速度, (QualityType)i) > 0)
               {
                    count += 丹药Config.Get丹药值(丹药Type.修炼速度, (QualityType)i);
               }
          }

          return count*(1f+体质Config.当前体质总属性.丹药效果/100f);
     }
     public static float Get每秒数()
     {
          float value=JingJieConfig.每年秒数Dic[PlayerData.S.历史最高境界];
          value /= (1f + 属性config.总属性.时间流速加快);
          return value;
     }
}
