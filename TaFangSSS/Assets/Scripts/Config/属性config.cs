using System.Collections.Generic;

public class 属性config
{
     public class 道纹属性
     {
          public float 增加百分比攻击力 => 1f + 道纹config.Get道纹数值(道纹Type.增加百分比攻击力);
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
          public float 城墙免疫伤害 => 道纹config.Get道纹数值(道纹Type.城墙免疫伤害);
          public float 城墙满血时加伤害 => 1f + 道纹config.Get道纹数值(道纹Type.城墙满血时加伤害);
          public float 英雄暴击率 => 道纹config.Get道纹数值(道纹Type.英雄暴击率);
          public float 伤害在范围内浮动 => 道纹config.Get道纹数值(道纹Type.伤害在范围内浮动);
          public float 无视抗性 => 道纹config.Get道纹数值(道纹Type.无视抗性);
          public float 战士对靠近城墙敌人伤害增高 => 1f + 道纹config.Get道纹数值(道纹Type.战士对靠近城墙敌人伤害增高);
          public float 射手连射概率 => 道纹config.Get道纹数值(道纹Type.射手连射概率);
          public float 控制冷却缩减 => 道纹config.Get道纹数值(道纹Type.控制冷却缩减);
          public float 法师暴击率 => 道纹config.Get道纹数值(道纹Type.法师暴击率);
          public float 辅助被辅助英雄伤害增幅 => 1f + 道纹config.Get道纹数值(道纹Type.辅助被辅助英雄伤害增幅);
     }
     public class 装备属性
     { 
          public float 英雄冷却缩减 => EquipConfig.装备附加属性数值Dic[附加属性Type.英雄冷却缩减]();
          public float 暴击率 => EquipConfig.装备附加属性数值Dic[附加属性Type.暴击率]();
          public float 最终伤害 => EquipConfig.装备附加属性数值Dic[附加属性Type.最终伤害]();
          
          public float 装备总攻击力 => Get装备攻击力增幅();
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

     public class 领主总属性
{
    // 创建装备属性和道纹属性的实例
    private 装备属性 _装备 = new 装备属性();
    private 道纹属性 _道纹 = new 道纹属性();

    public float 总攻击力=>Get境界攻击力()*(1f+_装备.装备总攻击力)*(1f+_道纹.增加百分比攻击力);
    public float 战士增幅 => _装备.战士增幅 * _道纹.增加战士伤害;
    public float 法师增幅 => _装备.法师增幅 * _道纹.增加法师伤害;
    public float 射手增幅 => _装备.射手增幅 * _道纹.增加射手伤害;
    public float 控制增幅 => _装备.控制增幅 * _道纹.增加控制伤害;
    public float 物理伤害增幅 => _装备.物理伤害增幅 * _道纹.增加物理伤害;
    public float 火焰伤害增幅 => _装备.火焰伤害增幅 * _道纹.增加火焰伤害;
    public float 冰霜伤害增幅 => _装备.冰霜伤害增幅 * _道纹.增加冰霜伤害;
    public float 雷电伤害增幅 => _装备.雷电伤害增幅 * _道纹.增加雷电伤害;
    public float 黑暗伤害增幅 => _装备.黑暗伤害增幅 * _道纹.增加黑暗伤害;
    public float 普通怪伤害增幅 => _装备.普通怪伤害增幅 * _道纹.增加小怪伤害;
    public float 精英怪伤害增幅 => _装备.精英怪伤害增幅 * _道纹.增加精英怪和首领伤害;
    public float 首领伤害增幅 => _装备.首领伤害增幅 * _道纹.增加精英怪和首领伤害;
    public float 城墙血量增幅 => _装备.城墙血量增幅*_道纹.城墙血量百分比; // 装备的是血量增幅
    public float 城墙低血增加伤害 => _道纹.城墙低血增加伤害;
    public float 击杀精英怪城墙回血 => _道纹.击杀精英怪城墙回血;
    public float 城墙免疫伤害 => _道纹.城墙免疫伤害;
    public float 城墙满血时加伤害 => _道纹.城墙满血时加伤害;
    public float 暴击率 => _道纹.英雄暴击率+_装备.暴击率;
    public float 法师暴击率 => _道纹.法师暴击率;
    public float 英雄冷却缩减 => _装备.英雄冷却缩减;
    public float 控制冷却缩减 => _道纹.控制冷却缩减;
    public float 伤害在范围内浮动 => _道纹.伤害在范围内浮动;
    public float 无视抗性 => _道纹.无视抗性;
    public float 战士对靠近城墙敌人伤害增高 => _道纹.战士对靠近城墙敌人伤害增高;
    public float 射手连射概率 => _道纹.射手连射概率;
    public float 辅助被辅助英雄伤害增幅 => _道纹.辅助被辅助英雄伤害增幅;
    public float 最终伤害 => _装备.最终伤害;
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

     public static Dictionary<JingJieType, int> 每年秒数Dic = new Dictionary<JingJieType, int>()
     {
          { JingJieType.练气,600},
          { JingJieType.筑基,550},
          { JingJieType.金丹,500},
          { JingJieType.元婴,450},
          { JingJieType.化神,400},
          { JingJieType.合体,350},
          { JingJieType.大乘,300},
          { JingJieType.天仙,250},
          { JingJieType.玄仙,220},
          { JingJieType.金仙,180},
          { JingJieType.太乙金仙,150},
          { JingJieType.大罗金仙,120},
          { JingJieType.准圣,100},
          { JingJieType.圣人,80},
          { JingJieType.天道圣人,60},
          { JingJieType.大道圣人,45},
          { JingJieType.混元圣人,30},
          { JingJieType.鸿蒙,15},
     };

     public static int 每年秒数 => 每年秒数Dic[PlayerData.S.JingJieType];
     
}
