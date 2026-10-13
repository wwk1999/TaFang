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
     public float minCount;
     public float maxCount;
 }

 public class 附加属性
 {
     public 附加属性Type 附加属性Type;
     public QualityType  QualityType;
     public float count;
     public bool IsSuo;
     public bool 无暇;
 }
 public enum 附加属性Type
 {
     None,
     最终伤害,
     装备基础属性增幅,
     射手伤害增幅,
     法师伤害增幅,
     控制伤害增幅,
     战士伤害增幅,
     普通怪伤害增幅,
     精英怪伤害增幅,
     首领伤害增幅,
     暴击率,
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
     public float count;
     public bool 无暇;
 }

 public class EquipConfig
 {
     

     public static string Get排序String(附加属性Type type)
     {
         switch (type)
         {
             case 附加属性Type.None:
                 return "无排序";
             case 附加属性Type.最终伤害:
                 return "按最终伤害排序";
             case 附加属性Type.装备基础属性增幅:
                 return "按装备增幅排序";
             case 附加属性Type.射手伤害增幅:
                 return "按射手增幅排序";
             case 附加属性Type.法师伤害增幅:
                 return "按法师增幅排序";
             case 附加属性Type.控制伤害增幅:
                 return "按控制增幅排序";
             case 附加属性Type.战士伤害增幅:
                 return "按战士增幅排序";
             case 附加属性Type.普通怪伤害增幅:
                 return "按普通怪增幅排序";
             case 附加属性Type.精英怪伤害增幅:
                 return "按精英怪增幅排序";
             case 附加属性Type.首领伤害增幅:
                 return "按首领增幅排序";
             case 附加属性Type.暴击率:
                 return "按暴击率排序";
             case 附加属性Type.物理伤害:
                 return "按物理伤害排序";
             case 附加属性Type.火焰伤害:
                 return "按火焰伤害排序";
             case 附加属性Type.冰霜伤害:
                 return "按冰霜伤害排序";
             case 附加属性Type.雷电伤害:
                 return "按雷电伤害排序";
             case 附加属性Type.黑暗伤害:
                 return "按黑暗伤害排序";
             case 附加属性Type.城墙血量:
                 return "按城墙血量排序";
             default:
                 return "未知排序";
         }
     }
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
         float 无暇random=Random.Range(0f, 100f);
         bool 无暇 = false;
         int random1=Random.Range(1, Enum.GetValues(typeof(附加属性Type)).Length);
         附加属性Type 附加属性Type = (附加属性Type)random1;
         float randomcount = Random.Range(附加属性数值Dic[附加属性Type][(int)(quality - 2)].minCount,
             附加属性数值Dic[附加属性Type][(int)(quality - 2)].maxCount);
         if (无暇random < 1f)
         {
             无暇 = true;
             randomcount = 附加属性数值Dic[附加属性Type][(int)(quality - 2)].maxCount;
         }
         return new 词条Item() { 附加属性Type = 附加属性Type, QualityType = quality,count=randomcount,无暇= 无暇};
     }
     public static Dictionary<QualityType, List<float>> 强化词条概率Dic = new Dictionary<QualityType, List<float>>()
     {
         { QualityType.玄品, new List<float>() { 100 } },
         { QualityType.地品, new List<float>() { 60,40 } },
         { QualityType.天品, new List<float>() { 30,50,20 } },
         { QualityType.宇品, new List<float>() { 0,55,25,20 } },
         { QualityType.宙品, new List<float>() { 0,0,55,30,15} },
         { QualityType.洪品, new List<float>() { 0,0,0,55,30,15} },
         { QualityType.荒品, new List<float>() { 0,0,0,45,20,25,10} },
     };

     public static 材料Item Get强化材料(int level)
     {
         材料Item 材料Item = new 材料Item();
         if (level <= 10)
         {
             材料Item.材料数量 = 2;
             材料Item.灵气数量 = 200;
         }else if (level <= 20)
         {
             材料Item.材料数量 = 5;
             材料Item.灵气数量 = 500;
         }
         else if (level <= 30)
         {
             材料Item.材料数量 = 20;
             材料Item.灵气数量 = 2000;
         }
         else if (level <= 40)
         {
             材料Item.材料数量 = 60;
             材料Item.灵气数量 = 10000;
         }
         else if (level <= 50)
         {
             材料Item.材料数量 = 120;
             材料Item.灵气数量 = 50000;
         }
         else if (level <= 60)
         {
             材料Item.材料数量 = 200;
             材料Item.灵气数量 = 200000;
         }
         else if (level <= 70)
         {
             材料Item.材料数量 = 300;
             材料Item.灵气数量 = 1000000;
         }else if (level <= 80)
         {
             材料Item.材料数量 = 500;
             材料Item.灵气数量 = 5000000;
         }
         else if (level <= 90)
         {
             材料Item.材料数量 = 800;
             材料Item.灵气数量 = 30000000;
         }
         else 
         {
             材料Item.材料数量 = 1200;
             材料Item.灵气数量 = 120000000;
         }

         return 材料Item;
     }
     public static Dictionary<QualityType, 材料Item> 强化材料Dic = new Dictionary<QualityType, 材料Item>()
     {
         { QualityType.黄品 ,new 材料Item(){材料数量 = 2,灵气数量=200}},
         { QualityType.玄品 ,new 材料Item(){材料数量 = 5,灵气数量=500}},
         { QualityType.地品 ,new 材料Item(){材料数量 = 20,灵气数量=2000}},
         { QualityType.天品 ,new 材料Item(){材料数量 = 60,灵气数量=10000}},
         { QualityType.宇品 ,new 材料Item(){材料数量 = 120,灵气数量=50000}},
         { QualityType.宙品 ,new 材料Item(){材料数量 = 200,灵气数量=200000}},
         { QualityType.洪品 ,new 材料Item(){材料数量 = 300,灵气数量=1000000}},
         { QualityType.荒品 ,new 材料Item(){材料数量 = 500,灵气数量=5000000}},

     };
     
     public static Dictionary<QualityType, 材料Item> 洗练材料Dic = new Dictionary<QualityType, 材料Item>()
     {
         { QualityType.黄品 ,new 材料Item(){材料数量 = 0,灵气数量=0}},
         { QualityType.玄品 ,new 材料Item(){材料数量 = 1,灵气数量=500}},
         { QualityType.地品 ,new 材料Item(){材料数量 = 2,灵气数量=1500}},
         { QualityType.天品 ,new 材料Item(){材料数量 = 3,灵气数量=3000}},
         { QualityType.宇品 ,new 材料Item(){材料数量 = 4,灵气数量=6000}},
         { QualityType.宙品 ,new 材料Item(){材料数量 = 5,灵气数量=10000}},
         { QualityType.洪品 ,new 材料Item(){材料数量 = 6,灵气数量=20000}},
         { QualityType.荒品 ,new 材料Item(){材料数量 = 7,灵气数量=50000}},

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
                 "至尊圣甲",    // 红
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
         { 附加属性Type.最终伤害, "最终伤害" },
         { 附加属性Type.装备基础属性增幅, "装备基础属性增幅" },
         { 附加属性Type.射手伤害增幅, "射手伤害增幅" },
         { 附加属性Type.法师伤害增幅, "法师伤害增幅" },
         { 附加属性Type.控制伤害增幅, "控制伤害增幅" },
         { 附加属性Type.战士伤害增幅, "战士伤害增幅" },
         { 附加属性Type.普通怪伤害增幅, "普通怪伤害增幅" },
         { 附加属性Type.精英怪伤害增幅, "精英怪伤害增幅" },
         { 附加属性Type.首领伤害增幅, "首领伤害增幅" },
         { 附加属性Type.暴击率, "暴击率" },
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

     public static float 装备每等级词条效果 = 2;
     public static float Get装备附加属性数值(附加属性Type type)
     {
         float count = 0;
         int 头盔无暇count = 0;
         int 护手无暇count = 0;
         int 衣服无暇count = 0;
         int 鞋子无暇count = 0;
         int 项链无暇count = 0;
         int 戒指无暇count = 0;
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.头盔])
         {
             if (item.无暇)
             {
                 头盔无暇count +=1;
             }
         }
         
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.衣服])
         {
             if (item.无暇)
             {
                 衣服无暇count +=1;
             }
         }
         
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.鞋子])
         {
             if (item.无暇)
             {
                 鞋子无暇count +=1;
             }
         }
         
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.戒指])
         {
             if (item.无暇)
             {
                 戒指无暇count +=1;
             }
         }
         
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.项链])
         {
             if (item.无暇)
             {
                 项链无暇count +=1;
             }
         }
         
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.护手])
         {
             if (item.无暇)
             {
                 护手无暇count +=1;
             }
         }
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.头盔])
         {
             if (item.附加属性Type == type)
             {
                 float value = item.count / 100f;
                 value *= (1f + PlayerData.S.EquipLevelDic[EquipType.头盔]*装备每等级词条效果 / 100f);
                 if (item.无暇)
                 {
                     value *= 2;
                 }
                 if (头盔无暇count >= 7)
                 {
                     value *= 2f;
                 }else if (头盔无暇count >= 5)
                 {
                     value *= 1.5f;
                 }else if (头盔无暇count >= 3)
                 {
                     value *= 1.2f;
                 }
                 count += value;
             }
         }
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.戒指])
         {
             if (item.附加属性Type == type)
             {
                 float value = item.count / 100f;
                 value *= (1f + PlayerData.S.EquipLevelDic[EquipType.戒指]*装备每等级词条效果 / 100f);
                 if (item.无暇)
                 {
                     value *= 2;
                 }
                 if (戒指无暇count >= 7)
                 {
                     value *= 2f;
                 }else if (戒指无暇count >= 5)
                 {
                     value *= 1.5f;
                 }else if (戒指无暇count >= 3)
                 {
                     value *= 1.2f;
                 }
                 count += value;
             }
         }
         
         
         
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.项链])
         {
             if (item.附加属性Type == type)
             {
                 float value = item.count / 100f;
                 value *= (1f + PlayerData.S.EquipLevelDic[EquipType.项链]*装备每等级词条效果 / 100f);
                 if (item.无暇)
                 {
                     value *= 2;
                 }
                 if (项链无暇count >= 7)
                 {
                     value *= 2f;
                 }else if (项链无暇count >= 5)
                 {
                     value *= 1.5f;
                 }else if (项链无暇count >= 3)
                 {
                     value *= 1.2f;
                 }
                 count += value;
             }
         }
         
         
         
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.鞋子])
         {
             if (item.附加属性Type == type)
             {
                 float value = item.count / 100f;
                 value *= (1f + PlayerData.S.EquipLevelDic[EquipType.鞋子]*装备每等级词条效果 / 100f);

                 if (item.无暇)
                 {
                     value *= 2;
                 }
                 if (鞋子无暇count >= 7)
                 {
                     value *= 2f;
                 }else if (鞋子无暇count >= 5)
                 {
                     value *= 1.5f;
                 }else if (鞋子无暇count >= 3)
                 {
                     value *= 1.2f;
                 }
                 count += value;
             }
         }
         
         
         
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.护手])
         {
             if (item.附加属性Type == type)
             {
                 float value = item.count / 100f;
                 value *= (1f + PlayerData.S.EquipLevelDic[EquipType.护手]*装备每等级词条效果 / 100f);

                 if (item.无暇)
                 {
                     value *= 2;
                 }
                 if (护手无暇count >= 7)
                 {
                     value *= 2f;
                 }else if (护手无暇count >= 5)
                 {
                     value *= 1.5f;
                 }else if (护手无暇count >= 3)
                 {
                     value *= 1.2f;
                 }
                 count += value;
             }
         }
         
         
         foreach (var item in PlayerData.S.装备附加属性Dic[EquipType.衣服])
         {
             if (item.附加属性Type == type)
             {
                 float value = item.count / 100f;
                 value *= (1f + PlayerData.S.EquipLevelDic[EquipType.衣服]*装备每等级词条效果 / 100f);

                 if (item.无暇)
                 {
                     value *= 2;
                 }
                 if (衣服无暇count >= 7)
                 {
                     value *= 2f;
                 }else if (衣服无暇count >= 5)
                 {
                     value *= 1.5f;
                 }else if (衣服无暇count >= 3)
                 {
                     value *= 1.2f;
                 }
                 count += value;
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
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 80f },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 80f,maxCount = 150f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 150f,maxCount = 300f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 300f,maxCount = 600f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 600,maxCount = 1500f},

             }
         },
         
         {
             附加属性Type.射手伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 80f },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 80f,maxCount = 150f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 150f,maxCount = 300f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 300f,maxCount = 600f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 600,maxCount = 1500f},
             }
         },
         
         {
             附加属性Type.战士伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 80f },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 80f,maxCount = 150f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 150f,maxCount = 300f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 300f,maxCount = 600f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 600,maxCount = 1500f},
             }
         },
         
         {
             附加属性Type.控制伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 80f },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 80f,maxCount = 150f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 150f,maxCount = 300f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 300f,maxCount = 600f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 600,maxCount = 1500f},
             }
         },
         
         {
             附加属性Type.法师伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 80f },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 80f,maxCount = 150f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 150f,maxCount = 300f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 300f,maxCount = 600f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 600,maxCount = 1500f},
             }
         },
         
         {
             附加属性Type.暴击率,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 5f,maxCount = 10f},
                 new 附加属性Item() { Type = QualityType.地品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 20f,maxCount = 35f },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 35f,maxCount = 60f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 60f,maxCount = 100f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 100f,maxCount = 150f },
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 150f,maxCount = 300f},
             }
         },

         
         {
             附加属性Type.普通怪伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 70 },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 70,maxCount = 120f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 120f,maxCount = 200f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 200f,maxCount = 500f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 500,maxCount = 1200f},
             }
         },
         
         {
             附加属性Type.最终伤害,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 70 },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 70,maxCount = 120f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 120f,maxCount = 200f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 200f,maxCount = 500f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 500,maxCount = 1200f},
             }
         },
         
         {
             附加属性Type.精英怪伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 70 },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 70,maxCount = 120f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 120f,maxCount = 200f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 200f,maxCount = 500f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 500,maxCount = 1200f},
             }
         },
         
         {
             附加属性Type.首领伤害增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 70 },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 70,maxCount = 120f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 120f,maxCount = 200f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 200f,maxCount = 500f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 500,maxCount = 1200f},
             }
         },
         
         {
             附加属性Type.物理伤害,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 80f },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 80f,maxCount = 150f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 150f,maxCount = 300f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 300f,maxCount = 600f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 600,maxCount = 1500f},
             }
         },
         
         {
             附加属性Type.火焰伤害,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 80f },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 80f,maxCount = 150f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 150f,maxCount = 300f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 300f,maxCount = 600f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 600,maxCount = 1500f},
             }
         },
         
         {
             附加属性Type.冰霜伤害,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 80f },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 80f,maxCount = 150f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 150f,maxCount = 300f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 300f,maxCount = 600f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 600,maxCount = 1500f},
             }
         },
         
         {
             附加属性Type.雷电伤害,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 80f },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 80f,maxCount = 150f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 150f,maxCount = 300f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 300f,maxCount = 600f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 600,maxCount = 1500f},
             }
         },
         
         {
             附加属性Type.黑暗伤害,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 80f },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 80f,maxCount = 150f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 150f,maxCount = 300f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 300f,maxCount = 600f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 600,maxCount = 1500f},
             }
         },
         
         {
             附加属性Type.城墙血量,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, minCount = 10f,maxCount = 20f },
                 new 附加属性Item() { Type = QualityType.地品, minCount = 20f,maxCount = 40f },
                 new 附加属性Item() { Type = QualityType.天品, minCount = 40f,maxCount = 80f },
                 new 附加属性Item() { Type = QualityType.宇品, minCount = 80f,maxCount = 150f },
                 new 附加属性Item() { Type = QualityType.宙品, minCount = 150f,maxCount = 300f },
                 new 附加属性Item() { Type = QualityType.洪品, minCount = 300f,maxCount = 600f},
                 new 附加属性Item() { Type = QualityType.荒品, minCount = 600,maxCount = 1500f},
             }
         },
         
     };


     public static int Get装备基础攻击力(int level)
     {
         if (level <= 100)
         {
             return 装备基础攻击1Dic[level];
         }
         else
         {
             return 装备基础攻击1Dic[100] + (level - 100) * 500;
         }
     }
     public static Dictionary<int, int> 装备基础攻击1Dic = new Dictionary<int, int>()
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
         {41, 120},
         {42, 130},
         {43, 140},
         {44, 150},
         {45, 160},
         {46, 170},
         {47, 180},
         {48, 190},
         {49, 200},
         {50, 210},
         {51, 230},
         {52, 250},
         {53, 270},
         {54, 290},
         {55, 310},
         {56, 330},
         {57, 350},
         {58, 370},
         {59, 390},
         {60, 410},
         {61, 450},
         {62, 490},
         {63, 530},
         {64, 570},
         {65, 610},
         {66, 650},
         {67, 690},
         {68, 730},
         {69, 770},
         {70, 810},
         {71, 900},
         {72, 1000},
         {73, 1100},
         {74, 1200},
         {75, 1300},
         {76, 1400},
         {77, 1500},
         {78, 1600},
         {79, 1700},
         {80, 1800},
         
         {81, 2000},
         {82, 2200},
         {83, 2400},
         {84, 2600},
         {85, 2800},
         {86, 3000},
         {87, 3200},
         {88, 3400},
         {89, 3600},
         {90, 3800},
         
         {91, 4300},
         {92, 4800},
         {93, 5300},
         {94, 5800},
         {95, 6300},
         {96, 6800},
         {97, 7300},
         {98, 7800},
         {99, 8300},
         {100, 8800},
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
