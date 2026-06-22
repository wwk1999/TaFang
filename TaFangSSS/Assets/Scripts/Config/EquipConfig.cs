 using System.Collections.Generic;
 using Config;

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
 }
 public enum 附加属性Type
 {
     None,
     装备基础属性增幅,
     射手伤害增幅,
     法师伤害增幅,
     控制伤害增幅,
     战士伤害增幅,
     英雄攻击速度,
     普通怪伤害增幅,
     精英怪伤害增幅,
     首领伤害增幅,
     暴击率,
     暴击伤害,
     物理伤害,
     火焰伤害,
     冰霜伤害,
     雷电伤害,
     黑暗伤害,
     城墙血量,
     召唤物生命值,
 }

 public class EquipConfig
 {
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
         { 附加属性Type.英雄攻击速度, "英雄攻击速度" },
         { 附加属性Type.普通怪伤害增幅, "普通怪伤害增幅" },
         { 附加属性Type.精英怪伤害增幅, "精英怪伤害增幅" },
         { 附加属性Type.首领伤害增幅, "首领伤害增幅" },
         { 附加属性Type.暴击率, "暴击率" },
         { 附加属性Type.暴击伤害, "暴击伤害" },
         { 附加属性Type.物理伤害, "物理伤害" },
         { 附加属性Type.火焰伤害, "火焰伤害" },
         { 附加属性Type.冰霜伤害, "冰霜伤害" },
         { 附加属性Type.雷电伤害, "雷电伤害" },
         { 附加属性Type.黑暗伤害, "黑暗伤害" },
         { 附加属性Type.城墙血量, "城墙血量" },
         { 附加属性Type.召唤物生命值, "召唤物生命值" }
     };
     public static Dictionary<附加属性Type, List<附加属性Item>> 附加属性数值Dic = new Dictionary<附加属性Type, List<附加属性Item>>()
     {
         {
             附加属性Type.装备基础属性增幅,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 30 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 50 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 80 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 120 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 180 },
             }
         },
         
         {
             附加属性Type.射手伤害增幅,
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
         
         {
             附加属性Type.召唤物生命值,
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
         
         {
             附加属性Type.战士伤害增幅,
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
         
         {
             附加属性Type.控制伤害增幅,
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
         
         {
             附加属性Type.法师伤害增幅,
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
         
         {
             附加属性Type.英雄攻击速度,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 3 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 5 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 30 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 50 },
             }
         },
         
         {
             附加属性Type.暴击率,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 3 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 5 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 30 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 50 },
             }
         },

         
         {
             附加属性Type.普通怪伤害增幅,
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
         
         {
             附加属性Type.暴击伤害,
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
         
         {
             附加属性Type.精英怪伤害增幅,
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
         
         {
             附加属性Type.首领伤害增幅,
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
         
         {
             附加属性Type.物理伤害,
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
         
         {
             附加属性Type.火焰伤害,
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
         
         {
             附加属性Type.冰霜伤害,
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
         
         {
             附加属性Type.雷电伤害,
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
         
         {
             附加属性Type.黑暗伤害,
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
         
         {
             附加属性Type.城墙血量,
             new List<附加属性Item>()
             {
                 new 附加属性Item() { Type = QualityType.玄品, Count = 10 },
                 new 附加属性Item() { Type = QualityType.地品, Count = 15 },
                 new 附加属性Item() { Type = QualityType.天品, Count = 20 },
                 new 附加属性Item() { Type = QualityType.宇品, Count = 30 },
                 new 附加属性Item() { Type = QualityType.宙品, Count = 40 },
                 new 附加属性Item() { Type = QualityType.洪品, Count = 60 },
                 new 附加属性Item() { Type = QualityType.荒品, Count = 100 },
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
         if (level <= 20)
         {
             return QualityType.黄品;
         }
         else if (level <= 40)
         {
             return QualityType.玄品;
         }
         else if (level <= 60)
         {
             return QualityType.地品;
         }
         else if (level <= 80)
         {
             return QualityType.天品;
         }
         else if (level <= 100)
         {
             return QualityType.宇品;
         }
         else if (level <= 120)
         {
             return QualityType.宙品;
         }
         else if (level <= 140)
         {
             return QualityType.洪品;
         }
         else if (level <= 40)
         {
             return QualityType.荒品;
         }

         return QualityType.None;
     }
 }
