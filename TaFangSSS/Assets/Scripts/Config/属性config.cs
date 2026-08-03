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

          return value / 100f;
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
          public float 英雄冷却缩减 => EquipConfig.装备附加属性数值Dic[附加属性Type.英雄冷却缩减]();
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

    public float 总攻击力=>Get境界攻击力()*(1f+_装备.装备总攻击力增幅)*(1f+_道纹.增加百分比攻击力);
    public float 战士增幅 => _装备.战士增幅 * _道纹.增加战士伤害*_道宝.战士增幅;
    public float 法师增幅 => _装备.法师增幅 * _道纹.增加法师伤害*_道宝.法师增幅;
    public float 射手增幅 => _装备.射手增幅 * _道纹.增加射手伤害*_道宝.射手增幅;
    public float 控制增幅 => _装备.控制增幅 * _道纹.增加控制伤害;
    public float 物理伤害增幅 => _装备.物理伤害增幅 * _道纹.增加物理伤害*_道宝.物理伤害增幅;
    public float 火焰伤害增幅 => _装备.火焰伤害增幅 * _道纹.增加火焰伤害*_道宝.火焰伤害增幅;
    public float 冰霜伤害增幅 => _装备.冰霜伤害增幅 * _道纹.增加冰霜伤害*_道宝.冰霜伤害增幅;
    public float 雷电伤害增幅 => _装备.雷电伤害增幅 * _道纹.增加雷电伤害*_道宝.雷电伤害增幅;
    public float 黑暗伤害增幅 => _装备.黑暗伤害增幅 * _道纹.增加黑暗伤害*_道宝.黑暗伤害增幅;
    public float 普通怪伤害增幅 => _装备.普通怪伤害增幅 * _道纹.增加小怪伤害;
    public float 精英怪伤害增幅 => _装备.精英怪伤害增幅 * _道纹.增加精英怪和首领伤害;
    public float 首领伤害增幅 => _装备.首领伤害增幅 * _道纹.增加精英怪和首领伤害;
    public float 城墙血量增幅 => _装备.城墙血量增幅*_道纹.城墙血量百分比; // 装备的是血量增幅
    public float 城墙低血增加伤害 => _道纹.城墙低血增加伤害;
    public float 击杀精英怪城墙回血 => _道纹.击杀精英怪城墙回血;
    public float 城墙免疫伤害 => _道纹.城墙免疫伤害;
    public float 城墙满血时加伤害 => _道纹.城墙满血时加伤害;
    public float 暴击率 => _道纹.英雄暴击率+_装备.暴击率+_道宝.暴击率;
    public float 法师暴击率 => _道纹.法师暴击率;
    public float 英雄冷却缩减 => _装备.英雄冷却缩减;
    public float 控制冷却缩减 => _道纹.控制冷却缩减;
    public float 伤害在范围内浮动 => _道纹.伤害在范围内浮动;
    public float 无视抗性 => _道纹.无视抗性;
    public float 战士对靠近城墙敌人伤害增高 => _道纹.战士对靠近城墙敌人伤害增高;
    public float 射手对远距离敌人伤害增高 => _道纹.射手对远距离敌人伤害增高;
    public float 辅助被辅助英雄伤害增幅 => _道纹.辅助被辅助英雄伤害增幅;
    public float 最终伤害增幅 => (1f+_装备.最终伤害)*(1f+_道宝.最终伤害);
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
          float 基础攻击 = JingJieConfig.JingJieAttributeDic[PlayerData.S.JingJieType];
          float 跟脚 = 1f;
          foreach (var item in PlayerData.S.突破Dic)
          {
               if (item.Value != 突破Type.None)
               {
                    跟脚 *= JingJieConfig.突破跟脚Dic[item.Value];
               }
          }

          return 基础攻击 * 跟脚;
     }
     public static float 基础境界攻击力=>Get境界攻击力();
     public static 领主总属性 总属性=new 领主总属性();
     public static float 领主攻击力 = 总属性.总攻击力;
     
     public static float 每年秒数 => JingJieConfig.每年秒数Dic[PlayerData.S.JingJieType];
}
