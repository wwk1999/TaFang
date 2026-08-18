 using System;
 using System.Collections.Generic;
 using Config;
 using Random = UnityEngine.Random;

 public enum EquipType
 {
  None,
  衣服,
  头盔,
  鞋子,
  护手,
  戒指,
  项链,
 }

 public class 附加属性Item
 {
     public QualityType Type;
     public int Count;
 }

 public class 附加属性
 {
     public 附加属性Type 附加属性Type;
     public QualityType  QualityType;
     public bool IsSuo;
 }
 public enum 附加属性Type
 {
     None,
     装备基础属性增幅,
     射手伤害增幅,
     法师伤害增幅,
     控制伤害增幅,
     战士伤害增幅,
     普通怪伤害增幅,
     精英怪伤害增幅,
     首领伤害增幅,
     暴击率,
     最终伤害,
     物理伤害,
     火焰伤害,
     冰霜伤害,
     雷电伤害,
     黑暗伤害,
     城墙血量,
 }

 public class 材料Item
 {
     public int 材料数量;
     public int 灵气数量;
 }

 public class 词条Item
 {
     public QualityType QualityType;
     public 附加属性Type 附加属性Type;
 }

 public class EquipConfig
 {
     public static 词条Item Get词条(QualityType qualityType)
     {
         List<float> list = 强化词条概率Dic[qualityType];
         float random=Random.Range(0f, 100f);
         float count = 0;
         int value = 0;
         foreach (var item in list)
         {
             count += item;
             if (random > count)
             {
                 value++;
             }
             else
             {
                 break;
             }
         }
         QualityType quality=(QualityType)(value+2);
         int random1=Random.Range(1, Enum.GetValues(typeof(附加属性Type)).Length);
         附加属性Type 附加属性Type = (附加属性Type)random1;
         return new 词条Item() { 附加属性Type = 附加属性Type, QualityType = quality };
     }
     public static Dictionary<QualityType, List<float>> 强化词条概率Dic = new Dictionary<QualityType, List<float>>()
     {
         { QualityType.玄品, new List<float>() { 100 } },
         { QualityType.地品, new List<float>() { 70,30 } },
         { QualityType.天品, new List<float>() { 50,30,20 } },
         { QualityType.宇品, new List<float>() { 30,30,25,15 } },
         { QualityType.宙品, new List<float>() { 10,30,30,20,10} },
         { QualityType.洪品, new List<float>() { 0,25,30,25,15,5} },
         { QualityType.荒品, new List<float>() { 0,20,25,25,20,7,3} },
     };
     public static Dictionary<QualityType, 材料Item> 强化材料Dic = new Dictionary<QualityType, 材料Item>()
     {
         { QualityType.黄品 ,new 材料Item(){材料数量 = 2,灵气数量=100}},
         { QualityType.玄品 ,new 材料Item(){材料数量 = 4,灵气数量=200}},
         { QualityType.地品 ,new 材料Item(){材料数量 = 10,灵气数量=500}},
         { QualityType.天品 ,new 材料Item(){材料数量 = 20,灵气数量=1000}},
         { QualityType.宇品 ,new 材料Item(){材料数量 = 50,灵气数量=2000}},
         { QualityType.宙品 ,new 材料Item(){材料数量 = 80,灵气数量=5000}},
         { QualityType.洪品 ,new 材料Item(){材料数量 = 120,灵气数量=10000}},
         { QualityType.荒品 ,new 材料Item(){材料数量 = 180,灵气数量=20000}},

     };
     
     public static Dictionary<QualityType, 材料Item> 洗练材料Dic = new Dictionary<QualityType, 材料Item>()
     {
         { QualityType.黄品 ,new 材料Item(){材料数量 = 0,灵气数量=0}},
         { QualityType.玄品 ,new 材料Item(){材料数量 = 1,灵气数量=200}},
         { QualityType.地品 ,new 材料Item(){材料数量 = 2,灵气数量=500}},
         { QualityType.天品 ,new 材料Item(){材料数量 = 3,灵气数量=1000}},
         { QualityType.宇品 ,new 材料Item(){材料数量 = 4,灵气数量=2000}},
         { QualityType.宙品 ,new 材料Item(){材料数量 = 5,灵气数量=5000}},
         { QualityType.洪品 ,new 材料Item(){材料数量 = 6,灵气数量=10000}},
         { QualityType.荒品 ,new 材料Item(){材料数量 = 7,灵气数量=20000}},

     };
     public static Dictionary<EquipType, List<string>> EquipNameDic = new Dictionary<EquipType, List<string>>()
     {
         {
             EquipType.衣服,
             new List<string>
             {
                 "凡尘衣",      // 白
                 "竹影甲",      // 绿
                 "沧浪袍",      // 蓝
                 "星陨袍",      // 紫
                 "烈阳战袍",    // 橙
                 "幻梦霓裳",    // 粉
                 "涅槃圣甲",    // 红
                 "混沌无极袍"   // 彩
             }
         },
         {
             EquipType.头盔,
             new List<string>
             {
                 "束发巾",      // 白
                 "木灵冠",      // 绿
                 "天澜冠",      // 蓝
                 "幽夜盔",      // 紫
                 "烈阳冠",      // 橙
                 "幻月盔",      // 粉
                 "焚天冠",      // 红
                 "太初玄天冠"   // 彩
             }
         },
         {
             EquipType.鞋子,
             new List<string>
             {
                 "踏云履",      // 白
                 "林风靴",      // 绿
                 "沧浪靴",      // 蓝
                 "星霄靴",      // 紫
                 "烈炎靴",      // 橙
                 "幻蝶靴",      // 粉
                 "业火靴",      // 红
                 "星辰逐风履"   // 彩
             }
         },
         {
             EquipType.护手,
             new List<string>
             {
                 "云袖",        // 白
                 "灵藤护臂",    // 绿
                 "霜钢护手",    // 蓝
                 "星晶护臂",    // 紫
                 "炎金护手",    // 橙
                 "幻玉护手",    // 粉
                 "血魔护手",    // 红
                 "混沌护天臂"   // 彩
             }
         },
         {
             EquipType.戒指,
             new List<string>
             {
                 "凡木戒",      // 白
                 "玄铜戒",      // 绿
                 "寒玉戒",      // 蓝
                 "星金戒",      // 紫
                 "烈阳戒",      // 橙
                 "幻晶戒",      // 粉
                 "业火戒",      // 红
                 "洪荒至尊戒"   // 彩
             }
         },
         {
             EquipType.项链,
             new List<string>
             {
                 "陨石链",      // 白
                 "灵石链",      // 绿
                 "冰晶链",      // 蓝
                 "星玉链",      // 紫
                 "火金链",      // 橙
                 "幻贝链",      // 粉
                 "炎龙链",      // 红
                 "混沌星云链"   // 彩
             }
         }
     };
     public static QualityType GetEquipQuality(EquipType type)
     {
         int level = PlayerData.S.EquipLevelDic[type];
         if (level <= 10)
         {
             return QualityType.黄品;
         }else if (level <= 20)
         {
             return QualityType.玄品;
         }
         else if (level <= 30)
         {
             return QualityType.地品;
         }
         else if (level <= 40)
         {
             return QualityType.天品;
         }
         else if (level <= 50)
         {
             return QualityType.宇品;
         }
         else if (level <= 60)
         {
             return QualityType.宙品;
         }
         else if (level <= 70)
         {
             return QualityType.洪品;
         }
         else
         {
             return QualityType.荒品;
         }
     }
     public static Dictionary<附加属性Type, string> 附加属性NameDic = new Dictionary<附加属性Type, string>()
     {
         { 附加属性Type.装备基础属性增幅, "装备基础属性增幅" },
         { 附加属性Type.射手伤害增幅, "射手伤害增幅" },
         { 附加属性Type.法师伤害增幅, "法师伤害增幅" },
         { 附加属性Type.控制伤害增幅, "控制伤害增幅" },
         { 附加属性Type.战士伤害增幅, "战士伤害增幅" },
         { 附加属性Type.普通怪伤害增幅, "普通怪伤害增幅" },
         { 附加属性Type.精英怪伤害增幅, "精英怪伤害增幅" },
         { 附加属性Type.首领伤害增幅, "首领伤害增幅" },
         { 附加属性Type.暴击率, "暴击率" },
         { 附加属性Type.最终伤害, "最终伤害" },
         { 附加属性Type.物理伤害, "物理伤害" },
         { 附加属性Type.火焰伤害, "火焰伤害" },
         { 附加属性Type.冰霜伤害, "冰霜伤害" },
         { 附加属性Type.雷电伤害, "雷电伤害" },
         { 附加属性Type.黑暗伤害, "黑暗伤害" },
         { 附加属性Type.城墙血量, "城墙血量" },
     };

     public static Dictionary<附加属性Type, Func<float>> 装备附加属性数值Dic = new Dictionary<附加属性Type, Func<float>>()
     {
         { 附加属性Type.装备基础属性增幅, () => Get装备附加属性数值(附加属性Type.装备基础属性增幅) },
         { 附加属性Type.射手伤害增幅, () => Get装备附加属性数值(附加属性Type.射手伤害增幅) },
         { 附加属性Type.法师伤害增幅, () => Get装备附加属性数值(附加属性Type.法师伤害增幅) },
         { 附加属性Type.控制伤害增幅, () => Get装备附加属性数值(附加属性Type.控制伤害增幅) },
         { 附加属性Type.战士伤害增幅, () => Get装备附加属性数值(附加属性Type.战士伤害增幅) },
         { 附加属性Type.普通怪伤害增幅, () => Get装备附加属性数值(附加属性Type.普通怪伤害增幅) },
         { 附加属性Type.精英怪伤害增幅, () => Get装备附加属性数值(附加属性Type.精英怪伤害增幅) },
         { 附加属性Type.首领伤害增幅, () => Get装备附加属性数值(附加属性Type.首领伤害增幅) },
         { 附加属性Type.暴击率, () => Get装备附加属性数值(附加属性Type.暴击率) },
         { 附加属性Type.最终伤害, () => Get装备附加属性数值(附加属性Type.最终伤害) },
         { 附加属性Type.物理伤害, () => Get装备附加属性数值(附加属性Type.物理伤害) },
         { 附加属性Type.火焰伤害, () => Get装备附加属性数值(附加属性Type.火焰伤害) },
         { 附加属性Type.冰霜伤害, () => Get装备附加属性数值(附加属性Type.冰霜伤害) },
         { 附加属性Type.雷电伤害, () => Get装备附加属性数值(附加属性Type.雷电伤害) },
         { 附加属性Type.黑暗伤害, () => Get装备附加属性数值(附加属性Type.黑暗伤害) },
         { 附加属性Type.城墙血量, () => Get装备附加属性数值(附加属性Type.城墙血量) },
     };

     public static float Get装备附加属性数值(附加属性Type type)
     {
         float count = 0;
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.头盔])
         {
             if (item.附加属性Type == type)
             {
                 QualityType qualityType=item.QualityType;
                 count += 附加属性数值Dic[item.附加属性Type][(int)(qualityType - 2)].Count/ 100f;
             }
         }
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.戒指])
         {
             if (item.附加属性Type == type)
             {
                 QualityType qualityType=item.QualityType;
                 count += 附加属性数值Dic[item.附加属性Type][(int)(qualityType - 2)].Count/ 100f;
             }
         }
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.项链])
         {
             if (item.附加属性Type == type)
             {
                 QualityType qualityType=item.QualityType;
                 count += 附加属性数值Dic[item.附加属性Type][(int)(qualityType - 2)].Count/ 100f;
             }
         }
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.鞋子])
         {
             if (item.附加属性Type == type)
             {
                 QualityType qualityType=item.QualityType;
                 count += 附加属性数值Dic[item.附加属性Type][(int)(qualityType - 2)].Count/ 100f;
             }
         }
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.衣服])
         {
             if (item.附加属性Type == type)
             {
                 QualityType qualityType=item.QualityType;
                 count += 附加属性数值Dic[item.附加属性Type][(int)(qualityType - 2)].Count/ 100f;
             }
         }
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.护手])
         {
             if (item.附加属性Type == type)
             {
                 QualityType qualityType=item.QualityType;
                 count += 附加属性数值Dic[item.附加属性Type][(int)(qualityType - 2)].Count/ 100f;
             }
         }

         return count;
     }
     public static Dictionary<附加属性Type, List<附加属性Item>> 附加属性数值Dic = new Dictionary<附加属性Type, List<附加属性Item>>()
     {
         {
             附加属性Type.装备基础属性增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.射手伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.战士伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.控制伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.法师伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.暴击率,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 8 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 20 },
             }
         },

         
         {
             附加属性Type.普通怪伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.最终伤害,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.精英怪伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.首领伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.物理伤害,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.火焰伤害,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.冰霜伤害,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.雷电伤害,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.黑暗伤害,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 2 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 4 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 6 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 30 },
             }
         },
         
         {
             附加属性Type.城墙血量,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 5 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 30 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 40 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 60 },
             }
         },
         
     };

     public static Dictionary<int, int> 装备基础攻击Dic = new Dictionary<int, int>()
     {
         {1, 1},
         {2, 2},
         {3, 3},
         {4, 4},
         {5, 5},
         {6, 6},
         {7, 7},
         {8, 8},
         {9, 9},
         {10, 10},
         {11, 12},
         {12, 14},
         {13, 16},
         {14, 18},
         {15, 20},
         {16, 22},
         {17, 24},
         {18, 26},
         {19, 28},
         {20, 30},
         {21, 33},
         {22, 36},
         {23, 39},
         {24, 42},
         {25, 45},
         {26, 48},
         {27, 51},
         {28, 54},
         {29, 57},
         {30, 60},
         {31, 65},
         {32, 70},
         {33, 75},
         {34, 80},
         {35, 85},
         {36, 90},
         {37, 95},
         {38, 100},
         {39, 105},
         {40, 110},
         {41, 118},
         {42, 126},
         {43, 134},
         {44, 142},
         {45, 150},
         {46, 158},
         {47, 166},
         {48, 174},
         {49, 182},
         {50, 190},
         {51, 202},
         {52, 214},
         {53, 226},
         {54, 238},
         {55, 250},
         {56, 262},
         {57, 274},
         {58, 286},
         {59, 298},
         {60, 310},
         {61, 328},
         {62, 346},
         {63, 364},
         {64, 382},
         {65, 400},
         {66, 418},
         {67, 436},
         {68, 454},
         {69, 472},
         {70, 490},
         {71, 520},
         {72, 550},
         {73, 580},
         {74, 610},
         {75, 640},
         {76, 670},
         {77, 700},
         {78, 730},
         {79, 760},
         {80, 790}
     };

     

     
     public static QualityType GetEquipQuality(int level)
     {
         if (level <= 10)
         {
             return QualityType.黄品;
         }
         else if (level <= 20)
         {
             return QualityType.玄品;
         }
         else if (level <= 30)
         {
             return QualityType.地品;
         }
         else if (level <= 40)
         {
             return QualityType.天品;
         }
         else if (level <= 50)
         {
             return QualityType.宇品;
         }
         else if (level <= 60)
         {
             return QualityType.宙品;
         }
         else if (level <= 70)
         {
             return QualityType.洪品;
         }
         else 
         {
             return QualityType.荒品;
         }

         return QualityType.None;
     }
 }
