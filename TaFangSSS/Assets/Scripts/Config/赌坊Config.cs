using System;
using System.Collections.Generic;
using Config;
using UnityEngine;

public enum 赌坊Type
{
    None = 0,
    铜钱巷 = 1,
    骰子坊 = 2,
    聚宝斋 = 3,
    千金楼 = 4,
    灵石台 = 5,
    风云阁 = 6,
    万象庄 = 7,
    天机局 = 8,
    玲珑幻境 = 9,
    九幽赌窟 = 10,
    星河赌坊 = 11,
    轮回台 = 12,
}

public enum 赌坊道具Type
{
    None,
    随机看品质1,
    随机看品质2,
    随机看品质3,
    随机看品质4,
    随机看品质5,
    
    看仓库总格子数,
    白格子数量,
    绿格子数量,
    蓝格子数量,
    
    看最大藏品轮廓,
    藏品平均价值,
}

public class 道具配置
{
    public QualityType  QualityType;
    public float 价格;
    public string 名称;
}
public class 赌坊配置
{
    public string name;
    public float 行数;
    public float 首仓价格;
    public List<float> 概率=new List<float>();
}
public enum 藏品Type
{
    None,

    // ===== 1×1 =====
    青竹短匕,           // 白 1×1
    凡铁箭簇,           // 白 1×1
    苦竹笛,             // 白 1×1
    桐木简册,           // 白 1×1
    山涧石钵,           // 白 1×1
    粗麻灵袋,           // 白 1×1
    老藤酒瓢,           // 白 1×1
    寒溪卵石,           // 白 1×1
    土陶丹瓶,           // 白 1×1
    兽皮手札,           // 白 1×1
    凝露草,             // 绿 1×1
    青纹石佩,           // 绿 1×1
    松风笛,             // 绿 1×1
    赤铜灵镜,           // 绿 1×1
    云纹木簪,           // 绿 1×1
    灵狐尾羽,           // 绿 1×1
    清泉玉珠,           // 绿 1×1（珠）
    月华草根,           // 绿 1×1
    流霞石灯,           // 蓝 1×1
    幽泉玉佩,           // 蓝 1×1
    灵犀角,             // 蓝 1×1
    幽溟珠,             // 紫 1×1（珠）
    九幽罗幡,           // 橙 1×1
    定风珠,             // 粉 1×1（珠）
    二十四颗定海神珠,   // 粉 1×1（珠）
    鸿蒙珠,             // 彩 1×1（珠）
    赤霞珠,             // 粉 1×1（珠，新增）

    // ===== 1×2 =====
    灵鹿角屑,           // 绿 1×2
    引风幡残片,         // 绿 1×2
    玄铁短戈,           // 绿 1×2
    聚灵瓦炉,           // 绿 1×2
    沧澜舟桨,           // 蓝 1×2
    落霞琉璃瓶,         // 蓝 1×2
    玉荷盏,             // 蓝 1×2
    裂风枪,             // 紫 1×2
    碧游简册,           // 紫 1×2
    千丝缚仙索,         // 橙 1×2
    镇水神碑,           // 橙 1×2
    幽冥轮回简,         // 粉 1×2
    翠玉拂尘,           // 蓝 1×2（新增）
    幽夜灯,             // 紫 1×2（新增）

    // ===== 2×1 =====
    玄水玉璧,           // 蓝 2×1
    引星盘残片,         // 蓝 2×1
    青岚幡,             // 蓝 2×1
    吞灵玉蝉,           // 紫 2×1
    玄岳印,             // 紫 2×1
    惊雷钺,             // 橙 2×1
    玄黄玉圭,           // 橙 2×1
    素色云界旗,         // 粉 2×1
    离地焰光旗,         // 粉 2×1
    业火红莲,           // 红 2×1
    竹编鱼篓,           // 白 2×1（新增）
    灰陶酒坛,           // 白 2×1（新增）
    藤编提篮,           // 白 2×1（新增）

    // ===== 1×3 =====
    九叶凝芝,           // 紫 1×3
    撼山钺,             // 紫 1×3
    逐日离弓,           // 橙 1×3
    镇岳神印,           // 橙 1×3
    落宝金钱,           // 粉 1×3
    青莲宝色旗,         // 粉 1×3
    河图洛书,           // 红 1×3
    万道之源,           // 彩 1×3
    镇魔石碑,           // 橙 1×3（新增）
    山海玉简,           // 橙 1×3（新增）

    // ===== 3×1 =====
    焚天蒲团,           // 紫 3×1
    伏羲琴,             // 粉 3×1
    灭世黑莲,           // 红 3×1
    诸天庆云,           // 红 3×1
    六道轮回盘,         // 红 3×1
    轮回核心,           // 彩 3×1
    无始灵枢,           // 彩 3×1
    太虚本源,           // 彩 3×1
    白石镇纸,           // 白 3×1（新增）
    青玉卦签,           // 绿 3×1（新增）
    碧水砚台,           // 蓝 3×1（新增）
    紫纹符牌,           // 紫 3×1（新增）

    // ===== 2×2 =====
    碧霞丹炉,           // 蓝 2×2
    紫纹鼎,             // 蓝 2×2
    聚灵青葫,           // 蓝 2×2
    万载灵根,           // 紫 2×2
    云荒罗盘,           // 紫 2×2
    赤霞鼎,             // 紫 2×2
    焚天玄鼎,           // 橙 2×2
    碧霞仙钟,           // 橙 2×2
    混元金斗,           // 粉 2×2
    天衍盘,             // 粉 2×2
    老布背包,           // 白 2×2（新增）
    玄龟小盾,           // 绿 2×2（新增）
    霜月寒镜,           // 蓝 2×2（新增）
    苍龙鳞甲,           // 蓝 2×2（新增）
    焚天罗盘,           // 紫 2×2（新增）
    玄冥玉壶,           // 紫 2×2（新增）
    星陨铁,             // 紫 2×2（新增）
    紫云蒲扇,           // 紫 2×2（新增）

    // ===== 3×3 =====
    玄天宝鉴,           // 橙 3×3
    太极图,             // 红 3×3
    混沌钟,             // 红 3×3
    盘古幡,             // 红 3×3
    乾坤鼎,             // 红 3×3
    天外混沌鼎,         // 彩 3×3
    白玉蒲团,           // 白 3×3（新增）
    素纱灯罩,           // 白 3×3（新增）
    青木棋盘,           // 绿 3×3（新增）
    碧水瑶琴,           // 橙 3×3（新增）
    苍澜神鼎,           // 橙 3×3（新增）
    赤霄玉磬,           // 橙 3×3（新增）

    // ===== 2×4 =====
    山海图残卷,         // 橙 2×4
    流虹仙槎,           // 橙 2×4
    苍澜战鼓,           // 橙 2×4
    山河社稷图,         // 红 2×4
    诛仙四剑,           // 红 2×4
    七宝琉璃塔,         // 粉 2×4
    麻布长卷,           // 白 2×4（新增）
    竹节令牌,           // 白 2×4（新增）
    青藤长鞭,           // 绿 2×4（新增）
    寒潭玉尺,           // 蓝 2×4（新增）
    玄天战鼓,           // 橙 2×4（新增）

    // ===== 4×2 =====
    落星琉璃盏,         // 紫 4×2
    霜河玉璜,           // 紫 4×2
    金蛟剪,             // 粉 4×2
    混沌青莲,           // 彩 4×2
    开天斧,             // 彩 4×2
    粗木长案,           // 白 4×2（新增）
    石纹屏风,           // 白 4×2（新增）
    素麻挂毯,           // 白 4×2（新增）
    青竹长箫,           // 绿 4×2（新增）
    藤纹盾,             // 绿 4×2（新增）
    碧波长绫,           // 蓝 4×2（新增）

    // ===== 2×5 =====
    墨灵古琴,           // 蓝 2×5
    万灵归墟盏,         // 橙 2×5
    崆峒印,             // 粉 2×5
    量天尺,             // 红 2×5
    白木长匣,           // 白 2×5（新增）
    素绢画卷,           // 白 2×5（新增）
    青藤长索,           // 绿 2×5（新增）
    翠竹令旗,           // 绿 2×5（新增）
    木灵符牌,           // 绿 2×5（新增）
    紫檀长匣,           // 紫 2×5（新增）

    // ===== 5×2 =====
    灵龟玄甲,           // 蓝 5×2
    逐月弓,             // 紫 5×2
    灵犀玉,             // 粉 5×2
    造化玉牒,           // 彩 5×2
    白麻长幡,           // 白 5×2（新增）
    青木长戟,           // 绿 5×2（新增）
    藤甲披风,           // 绿 5×2（新增）
    碧海长绸,           // 蓝 5×2（新增）
    寒玉长笛,           // 蓝 5×2（新增）
    青墟灯,             // 紫 5×2（新增）
    紫电长鞭,           // 紫 5×2（新增）
    霞光长绫,           // 粉 5×2（新增）
}
public enum 藏品尺寸Type
{
    None,
    C1x1,
    C1x2,
    C2x1,
    C1x3,
    C3x1,
    C2x2,
    C3x3,
    C2x4,
    C4x2,
    C2x5,
    C5x2,
}

public class 藏品配置
{
    public string name;
    public string 介绍;
    public QualityType QualityType;
    public 藏品尺寸Type 藏品尺寸Type;
}

/// <summary>单个藏品的仓库存档：格子坐标、尺寸、类型与揭晓状态</summary>
[Serializable]
public class 赌坊藏品存档
{
    public int 格X;
    public int 格Y;
    public int 宽;
    public int 高;
    public 藏品Type 藏品Type;
    public bool 已揭示;
}

/// <summary>赌坊玩法整体存档</summary>
[Serializable]
public class 赌坊存档
{
    public 赌坊Type 当前赌坊Type = 赌坊Type.None;
    public int 轮数 = 1;
    public 赌坊道具Type 本轮已用道具 = 赌坊道具Type.None;
    public bool 已买下;
    public bool 已显示最大藏品轮廓;
    public List<赌坊藏品存档> 藏品列表 = new List<赌坊藏品存档>();
}

public class 赌坊Config
{
    public static Dictionary<赌坊Type, 赌坊配置> 赌坊配置 = new Dictionary<赌坊Type, 赌坊配置>()
    {
        {
            赌坊Type.铜钱巷 ,new 赌坊配置(){name = "青云赌坊",行数=5,首仓价格 = 1000,概率 = new List<float>(){7000,3000,0,0,0,0,0,0}}
        },
        {
            赌坊Type.骰子坊 ,new 赌坊配置(){name = "星落赌坊",行数=6,首仓价格 = 5000,概率 = new List<float>(){4000,5000,1000,0,0,0,0,0}}
        },
        {
            赌坊Type.聚宝斋 ,new 赌坊配置(){name = "聚宝赌坊",行数=7,首仓价格 = 20000,概率 = new List<float>(){2000,5000,3000,0,0,0,0,0}}
        },
        {
            赌坊Type.千金楼 ,new 赌坊配置(){name = "千金赌坊",行数=8,首仓价格 = 100000,概率 = new List<float>(){2000,3500,4000,500,0,0,0,0}}
        },
        {
            赌坊Type.灵石台 ,new 赌坊配置(){name = "灵石赌坊",行数=9,首仓价格 = 300000,概率 = new List<float>(){2000,2000,5000,1000,0,0,0,0}}
        },
        {
            赌坊Type.风云阁 ,new 赌坊配置(){name = "风云赌坊",行数=10,首仓价格 = 1000000,概率 = new List<float>(){2000,2300,4000,1500,200,0,0,0}}
        },
        
        {
            赌坊Type.万象庄 ,new 赌坊配置(){name = "万象赌坊",行数=11,首仓价格 = 3000000,概率 = new List<float>(){1500,2000,4000,2000,500,0,0,0}}
        },
        
        {
            赌坊Type.天机局 ,new 赌坊配置(){name = "天机赌坊",行数=12,首仓价格 = 10000000,概率 = new List<float>(){1000,2000,3000,3000,950,50,0,0}}
        },
        
        {
            赌坊Type.玲珑幻境 ,new 赌坊配置(){name = "玲珑赌坊",行数=13,首仓价格 = 30000000,概率 = new List<float>(){500,1500,3000,3500,1400,100,0,0}}
        },
        
        {
            赌坊Type.九幽赌窟 ,new 赌坊配置(){name = "九幽赌坊",行数=14,首仓价格 = 100000000,概率 = new List<float>(){500,1000,2500,4000,1800,190,10,0}}
        },
        
        {
            赌坊Type.星河赌坊 ,new 赌坊配置(){name = "星河赌坊",行数=15,首仓价格 = 300000000,概率 = new List<float>(){500,1000,2000,4000,2200,280,20,0}}
        },
        
        {
            赌坊Type.轮回台 ,new 赌坊配置(){name = "轮回赌坊",行数=16,首仓价格 = 1000000000,概率 = new List<float>(){500,500,2000,4000,2650,319,30,1}}
        },
    };

    public static Dictionary<int, float> 轮数价格倍数 = new Dictionary<int, float>()
    {
        {1,1},
        {2,1.25f},
        {3,1.5f},
        {4,2},
    };
    public static Dictionary<赌坊道具Type, int> 品质道具数量 = new Dictionary<赌坊道具Type, int>()
    {
        {赌坊道具Type.随机看品质1,1},
        {赌坊道具Type.随机看品质2,2},
        {赌坊道具Type.随机看品质3,3},
        {赌坊道具Type.随机看品质4,4},
        {赌坊道具Type.随机看品质5,5},
    };

    /// <summary>道具图标在「Sprite/赌坊icon/道具」切图中的序号（0 起，对应 道具_0~道具_15）</summary>
    public static Dictionary<赌坊道具Type, int> 道具图标索引 = new Dictionary<赌坊道具Type, int>()
    {
        { 赌坊道具Type.随机看品质1, 0 },
        { 赌坊道具Type.随机看品质2, 1 },
        { 赌坊道具Type.随机看品质3, 2 },
        { 赌坊道具Type.随机看品质4, 3 },
        { 赌坊道具Type.随机看品质5, 4 },
        { 赌坊道具Type.藏品平均价值, 5 },
        { 赌坊道具Type.看仓库总格子数, 6 },
        { 赌坊道具Type.白格子数量, 7 },
        { 赌坊道具Type.绿格子数量, 8 },
        { 赌坊道具Type.蓝格子数量, 9 },
        { 赌坊道具Type.看最大藏品轮廓, 10 },
    };

    public static Dictionary<赌坊道具Type, 道具配置> 道具配置 = new Dictionary<赌坊道具Type, 道具配置>()
    {
        // ===== 随机看品质 =====
        {
            赌坊道具Type.随机看品质1,
            new 道具配置 { QualityType = QualityType.黄品, 价格 = 1000, 名称 = "窥微镜" }
        },
        {
            赌坊道具Type.随机看品质2,
            new 道具配置 { QualityType = QualityType.玄品, 价格 = 5000, 名称 = "照影镜" }
        },
        {
            赌坊道具Type.随机看品质3,
            new 道具配置 { QualityType = QualityType.地品, 价格 = 20000, 名称 = "鉴真镜" }
        },
        {
            赌坊道具Type.随机看品质4,
            new 道具配置 { QualityType = QualityType.天品, 价格 = 100000, 名称 = "通玄镜" }
        },
        {
            赌坊道具Type.随机看品质5,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 1000000, 名称 = "观天镜" }
        },

        // ===== 随机看尺寸 =====
      
        {
            赌坊道具Type.藏品平均价值,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 800000, 名称 = "丈虚尺" }
        },

        // ===== 仓库信息 =====
        {
            赌坊道具Type.看仓库总格子数,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 1000000, 名称 = "乾坤盘" }
        },
        {
            赌坊道具Type.白格子数量,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 1000000, 名称 = "白露签" }
        },
        {
            赌坊道具Type.绿格子数量,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 1000000, 名称 = "青岚签" }
        },
        {
            赌坊道具Type.蓝格子数量,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 1000000, 名称 = "沧澜签" }
        },
        {
            赌坊道具Type.看最大藏品轮廓,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 1000000, 名称 = "照世镜" }
        },
    };

    public static Dictionary<藏品Type, 藏品配置> 藏品配置 = new()
    {
        // ================= C1x1 =================
        {
            藏品Type.青竹短匕,
            new 藏品配置
            {
                name = "青竹短匕", 介绍 = "青竹削成，锋藏于朴，山野间常备的短匕。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1
            }
        },
        {
            藏品Type.凡铁箭簇,
            new 藏品配置 { name = "凡铁箭簇", 介绍 = "寻常铁簇，猎户所用，胜在轻便易得。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.苦竹笛,
            new 藏品配置 { name = "苦竹笛", 介绍 = "苦竹制笛，音色清苦，可静心定神。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.桐木简册,
            new 藏品配置 { name = "桐木简册", 介绍 = "桐木薄片串成，记有零散口诀与见闻。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.山涧石钵,
            new 藏品配置 { name = "山涧石钵", 介绍 = "山涧卵石凿成，盛灵泉而不散。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.粗麻灵袋,
            new 藏品配置 { name = "粗麻灵袋", 介绍 = "粗麻编织，容量不大，却耐磨耐用。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.老藤酒瓢,
            new 藏品配置 { name = "老藤酒瓢", 介绍 = "老藤剖制，久用带一缕酒香。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.寒溪卵石,
            new 藏品配置 { name = "寒溪卵石", 介绍 = "寒溪浸养多年，触手生凉。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.土陶丹瓶,
            new 藏品配置 { name = "土陶丹瓶", 介绍 = "土陶烧制，可封存低阶丹药。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.兽皮手札,
            new 藏品配置 { name = "兽皮手札", 介绍 = "兽皮裁成，记有山野见闻与粗浅法门。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },

        {
            藏品Type.凝露草,
            new 藏品配置 { name = "凝露草", 介绍 = "叶尖常凝晨露，可入低阶丹方。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.青纹石佩,
            new 藏品配置 { name = "青纹石佩", 介绍 = "石上青纹天然成阵，佩之可微聚灵气。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.松风笛,
            new 藏品配置 { name = "松风笛", 介绍 = "笛声如松风过岭，可驱散杂念。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.赤铜灵镜,
            new 藏品配置 { name = "赤铜灵镜", 介绍 = "赤铜铸镜，可照见浅层灵光。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.云纹木簪,
            new 藏品配置 { name = "云纹木簪", 介绍 = "云纹木簪，束发可清心明目。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.灵狐尾羽,
            new 藏品配置 { name = "灵狐尾羽", 介绍 = "灵狐尾羽，轻若无物，可制轻身符。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.清泉玉珠,
            new 藏品配置 { name = "清泉玉珠", 介绍 = "珠内清泉流转，可净心祛浊。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.月华草根,
            new 藏品配置 { name = "月华草根", 介绍 = "月华草之根，夜间泛淡淡银光。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },

        {
            藏品Type.流霞石灯,
            new 藏品配置 { name = "流霞石灯", 介绍 = "石灯内蕴流霞，夜间自明，可照幽微。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.幽泉玉佩,
            new 藏品配置 { name = "幽泉玉佩", 介绍 = "玉佩温润，贴肤可缓灵气躁动。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.灵犀角,
            new 藏品配置 { name = "灵犀角", 介绍 = "灵犀之角，可短时通感灵机。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },

        {
            藏品Type.幽溟珠,
            new 藏品配置 { name = "幽溟珠", 介绍 = "珠色幽紫，似藏溟海一角，深不可测。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },

        {
            藏品Type.九幽罗幡,
            new 藏品配置 { name = "九幽罗幡", 介绍 = "幡面绘九幽纹，展动可引阴属灵气。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },

        {
            藏品Type.定风珠,
            new 藏品配置
            {
                name = "定风珠", 介绍 = "珠光粉润，持之可定周身风息，风不能侵。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x1
            }
        },
        {
            藏品Type.二十四颗定海神珠,
            new 藏品配置
            {
                name = "定海神珠", 介绍 = "二十四珠成一套，镇海定浪，水族避退。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x1
            }
        },

        {
            藏品Type.鸿蒙珠,
            new 藏品配置
            {
                name = "鸿蒙珠", 介绍 = "珠生七彩，内蕴一缕鸿蒙之气，可窥天地初开。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C1x1
            }
        },

        {
            藏品Type.赤霞珠,
            new 藏品配置
            {
                name = "赤霞珠", 介绍 = "珠蕴赤霞，霞光流转，触之温润如朝日。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x1
            }
        },

        // ================= C1x2 =================
        {
            藏品Type.灵鹿角屑,
            new 藏品配置 { name = "灵鹿角屑", 介绍 = "灵鹿蜕角研磨成屑，可入丹。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.引风幡残片,
            new 藏品配置 { name = "引风幡残片", 介绍 = "残破幡布仍存引风之效。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.玄铁短戈,
            new 藏品配置 { name = "玄铁短戈", 介绍 = "玄铁打造，锋沉耐用，可破浅层护体。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.聚灵瓦炉,
            new 藏品配置 { name = "聚灵瓦炉", 介绍 = "瓦炉内刻聚灵纹，可慢聚灵气。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },

        {
            藏品Type.沧澜舟桨,
            new 藏品配置 { name = "沧澜舟桨", 介绍 = "沧澜舟旧桨，入水可御小浪。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.落霞琉璃瓶,
            new 藏品配置 { name = "落霞琉璃瓶", 介绍 = "琉璃瓶映落霞，可存灵液不散。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.玉荷盏,
            new 藏品配置 { name = "玉荷盏", 介绍 = "玉荷形盏，盛灵液而灵气不泄。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },

        {
            藏品Type.裂风枪,
            new 藏品配置 { name = "裂风枪", 介绍 = "枪出裂风，攻伐犀利，可破罡气。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.碧游简册,
            new 藏品配置
            {
                name = "碧游简册", 介绍 = "碧游一脉简册，载秘法残篇，字隐灵光。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x2
            }
        },

        {
            藏品Type.千丝缚仙索,
            new 藏品配置
            {
                name = "千丝缚仙索", 介绍 = "千丝绞成，可缚敌于无形，仙亦难脱。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x2
            }
        },
        {
            藏品Type.镇水神碑,
            new 藏品配置 { name = "镇水神碑", 介绍 = "刻镇水文，碑立水止，可压一方水患。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },

        {
            藏品Type.幽冥轮回简,
            new 藏品配置
            {
                name = "幽冥轮回简", 介绍 = "简上轮回纹隐现，涉幽冥之力，可扰生死。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x2
            }
        },
        {
            藏品Type.翠玉拂尘,
            new 藏品配置 { name = "翠玉拂尘", 介绍 = "翠玉为柄，拂尘轻扫，可净周身尘秽。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.幽夜灯,
            new 藏品配置 { name = "幽夜灯", 介绍 = "灯焰幽青，夜里自明，可照幽冥路径。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },

        // ================= C2x1 =================
        {
            藏品Type.玄水玉璧,
            new 藏品配置 { name = "玄水玉璧", 介绍 = "玉璧沁玄水之气，可调水属灵机。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.引星盘残片,
            new 藏品配置 { name = "引星盘残片", 介绍 = "引星盘残片，夜半可映星轨。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.青岚幡,
            new 藏品配置 { name = "青岚幡", 介绍 = "青岚幡展动，可招山岚迷雾。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },

        {
            藏品Type.吞灵玉蝉,
            new 藏品配置 { name = "吞灵玉蝉", 介绍 = "玉蝉可吞纳散逸灵气，悄然壮大己身。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.玄岳印,
            new 藏品配置 { name = "玄岳印", 介绍 = "印钮如山，落印可镇一方气机。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },

        {
            藏品Type.惊雷钺,
            new 藏品配置 { name = "惊雷钺", 介绍 = "钺落惊雷，雷属攻伐，可震散敌魄。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.玄黄玉圭,
            new 藏品配置 { name = "玄黄玉圭", 介绍 = "玄黄玉圭，可稳地脉之气，镇地无声。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },

        {
            藏品Type.素色云界旗,
            new 藏品配置 { name = "素色云界旗", 介绍 = "旗展云界，护身避尘，万法难沾。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.离地焰光旗,
            new 藏品配置
            {
                name = "离地焰光旗", 介绍 = "焰光旗离地腾焰，护体焚敌，焰不近身。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x1
            }
        },

        {
            藏品Type.业火红莲,
            new 藏品配置 { name = "业火红莲", 介绍 = "红莲燃业火，焚业不焚身，业尽莲开。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.竹编鱼篓,
            new 藏品配置 { name = "竹编鱼篓", 介绍 = "竹篾编成，鱼腥犹存，山溪渔家常备。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.灰陶酒坛,
            new 藏品配置 { name = "灰陶酒坛", 介绍 = "粗陶酒坛，泥封犹在，坛底残酒尚有余香。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.藤编提篮,
            new 藏品配置 { name = "藤编提篮", 介绍 = "藤条编篮，轻便结实，乡野采撷常携。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },

        // ================= C1x3 =================
        {
            藏品Type.九叶凝芝,
            new 藏品配置 { name = "九叶凝芝", 介绍 = "九叶凝芝，药力醇厚，可续将断之脉。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.撼山钺,
            new 藏品配置 { name = "撼山钺", 介绍 = "巨钺一击可撼山岳，山石为之崩。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },

        {
            藏品Type.逐日离弓,
            new 藏品配置 { name = "逐日离弓", 介绍 = "离火之弓，箭出逐日，所过皆焚。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.镇岳神印,
            new 藏品配置 { name = "镇岳神印", 介绍 = "神印落处，山岳为镇，万灵俯首。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },

        {
            藏品Type.落宝金钱,
            new 藏品配置 { name = "落宝金钱", 介绍 = "金钱一落，法宝失持，万宝皆坠。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.青莲宝色旗,
            new 藏品配置 { name = "青莲宝色旗", 介绍 = "青莲宝色旗，护体清心，诸邪不侵。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },

        {
            藏品Type.河图洛书,
            new 藏品配置 { name = "河图洛书", 介绍 = "河图洛书，推演天机，可窥过去未来。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.万道之源,
            new 藏品配置
            {
                name = "万道之源", 介绍 = "万道之源，诸法之始，得之可溯源归真。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C1x3
            }
        },
        {
            藏品Type.镇魔石碑,
            new 藏品配置 { name = "镇魔石碑", 介绍 = "碑刻镇魔古文，碑立而邪祟退避。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.山海玉简,
            new 藏品配置 { name = "山海玉简", 介绍 = "玉简载山海异志，简展而山海在目。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },

        // ================= C3x1 =================
        {
            藏品Type.焚天蒲团,
            new 藏品配置 { name = "焚天蒲团", 介绍 = "坐蒲团可引火属灵气，焚天煮海。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },

        {
            藏品Type.伏羲琴,
            new 藏品配置 { name = "伏羲琴", 介绍 = "伏羲琴，音可通神，一曲动天地。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },

        {
            藏品Type.灭世黑莲,
            new 藏品配置 { name = "灭世黑莲", 介绍 = "黑莲绽处，寂灭之意弥漫，万物归寂。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.诸天庆云,
            new 藏品配置 { name = "诸天庆云", 介绍 = "庆云覆顶，诸邪不侵，万法不沾其身。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.六道轮回盘,
            new 藏品配置
            {
                name = "六道轮回盘", 介绍 = "轮回盘转，六道生灭，生死皆在一念。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x1
            }
        },
        {
            藏品Type.轮回核心,
            new 藏品配置
            {
                name = "轮回核心", 介绍 = "轮回核心，蕴轮回本源，可定生死之序。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x1
            }
        },
        {
            藏品Type.无始灵枢,
            new 藏品配置 { name = "无始灵枢", 介绍 = "无始灵枢，枢机无始无终，可拨因果。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.太虚本源,
            new 藏品配置
            {
                name = "太虚本源", 介绍 = "太虚本源，虚空之根，可纳万象于虚无。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x1
            }
        },
        {
            藏品Type.白石镇纸,
            new 藏品配置 { name = "白石镇纸", 介绍 = "白石打磨而成，文房压纸，素净无纹。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.青玉卦签,
            new 藏品配置 { name = "青玉卦签", 介绍 = "青玉卦签六枚一套，摇之可问吉凶。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.碧水砚台,
            new 藏品配置 { name = "碧水砚台", 介绍 = "砚池如碧水，磨墨生凉，久用不干。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.紫纹符牌,
            new 藏品配置 { name = "紫纹符牌", 介绍 = "符牌紫纹密布，佩之可挡小鬼近身。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },

        // ================= C2x2 =================
        {
            藏品Type.碧霞丹炉,
            new 藏品配置 { name = "碧霞丹炉", 介绍 = "碧霞丹炉，稳火聚霞，炼丹不散。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.紫纹鼎,
            new 藏品配置 { name = "紫纹鼎", 介绍 = "紫纹鼎，可聚紫气，丹成而纹现。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.聚灵青葫,
            new 藏品配置 { name = "聚灵青葫", 介绍 = "青葫可聚灵储气，随身如带小洞天。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },

        {
            藏品Type.万载灵根,
            new 藏品配置 { name = "万载灵根", 介绍 = "万载灵根，灵性深厚，可续一脉灵机。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.云荒罗盘,
            new 藏品配置 { name = "云荒罗盘", 介绍 = "云荒罗盘，可辨灵脉方位，寻幽探秘。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.赤霞鼎,
            new 藏品配置 { name = "赤霞鼎", 介绍 = "赤霞鼎，火属炼丹之器，鼎成霞光不散。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },

        {
            藏品Type.焚天玄鼎,
            new 藏品配置 { name = "焚天玄鼎", 介绍 = "玄鼎蕴焚天之火，鼎启而天如焚。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.碧霞仙钟,
            new 藏品配置 { name = "碧霞仙钟", 介绍 = "仙钟一鸣，碧霞漫天，声可镇魂。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },

        {
            藏品Type.混元金斗,
            new 藏品配置 { name = "混元金斗", 介绍 = "混元金斗，可收摄万物，斗转乾坤。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.天衍盘,
            new 藏品配置 { name = "天衍盘", 介绍 = "天衍盘，推演天衍之数，可算大势。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.老布背包,
            new 藏品配置 { name = "老布背包", 介绍 = "旧布缝成，肩带补丁层叠，行山客常背。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.玄龟小盾,
            new 藏品配置 { name = "玄龟小盾", 介绍 = "龟甲小盾，纹理如玄，轻巧而耐击。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.霜月寒镜,
            new 藏品配置 { name = "霜月寒镜", 介绍 = "镜面凝霜，映月而寒，可照阴邪原形。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.苍龙鳞甲,
            new 藏品配置 { name = "苍龙鳞甲", 介绍 = "苍龙脱鳞编甲，坚韧异常，刀剑难入。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.焚天罗盘,
            new 藏品配置 { name = "焚天罗盘", 介绍 = "罗盘指针自燃，可引火属灵机，辨焚天之向。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.玄冥玉壶,
            new 藏品配置 { name = "玄冥玉壶", 介绍 = "玄冥玉壶，内藏寒泉，倾之不竭。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.星陨铁,
            new 藏品配置 { name = "星陨铁", 介绍 = "天外坠铁，星纹天生，锻器可成灵兵。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.紫云蒲扇,
            new 藏品配置 { name = "紫云蒲扇", 介绍 = "紫云蒲扇一摇，风云随心，暑气自消。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },

        // ================= C3x3 =================
        {
            藏品Type.玄天宝鉴,
            new 藏品配置 { name = "玄天宝鉴", 介绍 = "玄天宝鉴，照见虚实，可破万般幻象。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },

        {
            藏品Type.太极图,
            new 藏品配置 { name = "太极图", 介绍 = "太极图，阴阳流转，可定地水火风。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.混沌钟,
            new 藏品配置 { name = "混沌钟", 介绍 = "混沌钟，钟鸣定时空，一响镇诸天。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.盘古幡,
            new 藏品配置 { name = "盘古幡", 介绍 = "盘古幡，开天辟地之器，幡动混沌分。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.乾坤鼎,
            new 藏品配置 { name = "乾坤鼎", 介绍 = "乾坤鼎，炼化乾坤，可纳天地于一炉。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.天外混沌鼎,
            new 藏品配置
            {
                name = "天外混沌鼎", 介绍 = "天外混沌鼎，蕴混沌本源，鼎开天外。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x3
            }
        },
        {
            藏品Type.白玉蒲团,
            new 藏品配置 { name = "白玉蒲团", 介绍 = "白玉琢成蒲团，坐之温润，静心尚可。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.素纱灯罩,
            new 藏品配置 { name = "素纱灯罩", 介绍 = "素纱灯罩，纱薄透光，罩上灯火更柔。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.青木棋盘,
            new 藏品配置 { name = "青木棋盘", 介绍 = "青木棋盘，纵横十九道，棋落带动灵机。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.碧水瑶琴,
            new 藏品配置 { name = "碧水瑶琴", 介绍 = "瑶琴映碧水，弦动而水波随之。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.苍澜神鼎,
            new 藏品配置 { name = "苍澜神鼎", 介绍 = "神鼎苍澜纹绕，鼎启而浪声隐起。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.赤霄玉磬,
            new 藏品配置 { name = "赤霄玉磬", 介绍 = "赤霄玉磬，一击而赤光凌霄，声清而远。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },

        // ================= C2x4 =================
        {
            藏品Type.山海图残卷,
            new 藏品配置
            {
                name = "山海图残卷", 介绍 = "山海图残卷，可现山川虚影，藏山海一隅。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x4
            }
        },
        {
            藏品Type.流虹仙槎,
            new 藏品配置 { name = "流虹仙槎", 介绍 = "流虹仙槎，可渡星河，行于虚实之间。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.苍澜战鼓,
            new 藏品配置 { name = "苍澜战鼓", 介绍 = "苍澜战鼓，鼓动士气，一鼓可退万军。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },

        {
            藏品Type.山河社稷图,
            new 藏品配置
            {
                name = "山河社稷图", 介绍 = "山河社稷图，内藏山河，图展而界成。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C2x4
            }
        },
        {
            藏品Type.诛仙四剑,
            new 藏品配置 { name = "诛仙四剑", 介绍 = "诛仙四剑，杀伐至宝，剑立而仙神避。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },

        {
            藏品Type.七宝琉璃塔,
            new 藏品配置
            {
                name = "七宝琉璃塔", 介绍 = "七宝琉璃塔，可镇可护，塔光不染尘埃。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x4
            }
        },
        {
            藏品Type.麻布长卷,
            new 藏品配置 { name = "麻布长卷", 介绍 = "麻布卷轴，笔迹已淡，依稀可辨山川。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.竹节令牌,
            new 藏品配置 { name = "竹节令牌", 介绍 = "竹节削成令牌，节纹如令，山门传信之物。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.青藤长鞭,
            new 藏品配置 { name = "青藤长鞭", 介绍 = "青藤绞成长鞭，柔韧有力，挥之生风。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.寒潭玉尺,
            new 藏品配置 { name = "寒潭玉尺", 介绍 = "玉尺取自寒潭，触手冰冷，可量灵脉深浅。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.玄天战鼓,
            new 藏品配置 { name = "玄天战鼓", 介绍 = "战鼓鼓面玄纹，擂之而天云变色。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },

        // ================= C4x2 =================
        {
            藏品Type.落星琉璃盏,
            new 藏品配置
            {
                name = "落星琉璃盏", 介绍 = "落星琉璃盏，可引星辉，盏中似有星河。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C4x2
            }
        },
        {
            藏品Type.霜河玉璜,
            new 藏品配置
            {
                name = "霜河玉璜", 介绍 = "霜河玉璜，寒气凝而不散，触之如临霜河。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C4x2
            }
        },

        {
            藏品Type.金蛟剪,
            new 藏品配置 { name = "金蛟剪", 介绍 = "金蛟剪，剪断灵机，一剪而法宝俱折。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },

        {
            藏品Type.混沌青莲,
            new 藏品配置 { name = "混沌青莲", 介绍 = "混沌青莲，蕴混沌生机，莲开而界生。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.开天斧,
            new 藏品配置 { name = "开天斧", 介绍 = "开天斧，一斧开天，斧落而混沌判。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.粗木长案,
            new 藏品配置 { name = "粗木长案", 介绍 = "粗木长案，木纹粗犷，可陈器物列卷。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.石纹屏风,
            new 藏品配置 { name = "石纹屏风", 介绍 = "石纹屏风，纹路天然如画，隔风挡尘。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.素麻挂毯,
            new 藏品配置 { name = "素麻挂毯", 介绍 = "素麻挂毯，织纹朴素，悬于堂中增静气。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.青竹长箫,
            new 藏品配置 { name = "青竹长箫", 介绍 = "青竹长箫，音色清越，吹之如临竹涧。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.藤纹盾,
            new 藏品配置 { name = "藤纹盾", 介绍 = "藤纹盾以藤缠木骨，轻而挡重击。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.碧波长绫,
            new 藏品配置 { name = "碧波长绫", 介绍 = "碧波长绫，轻若流水，缠敌则难脱。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },

        // ================= C2x5 =================
        {
            藏品Type.墨灵古琴,
            new 藏品配置 { name = "墨灵古琴", 介绍 = "墨灵古琴，音可通幽，弦动而幽冥应。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },

        {
            藏品Type.万灵归墟盏,
            new 藏品配置
            {
                name = "万灵归墟盏", 介绍 = "万灵归墟盏，可纳万灵，盏倾而归墟。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x5
            }
        },

        {
            藏品Type.崆峒印,
            new 藏品配置 { name = "崆峒印", 介绍 = "崆峒印，镇印一方，印落而山河定。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },

        {
            藏品Type.量天尺,
            new 藏品配置 { name = "量天尺", 介绍 = "量天尺，可量天地之距，尺出而界分明。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.白木长匣,
            new 藏品配置 { name = "白木长匣", 介绍 = "白木长匣，素面无饰，可藏长剑卷轴。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.素绢画卷,
            new 藏品配置 { name = "素绢画卷", 介绍 = "素绢画卷，绢面素净，静待丹青落笔。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.青藤长索,
            new 藏品配置 { name = "青藤长索", 介绍 = "青藤长索，柔韧耐磨，攀崖渡涧皆可。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.翠竹令旗,
            new 藏品配置 { name = "翠竹令旗", 介绍 = "翠竹为杆，令旗一展，可传号令。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.木灵符牌,
            new 藏品配置 { name = "木灵符牌", 介绍 = "木灵符牌，刻草木纹，佩之可亲草木灵。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.紫檀长匣,
            new 藏品配置 { name = "紫檀长匣", 介绍 = "紫檀长匣，木香沉静，内藏之物必非凡品。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },

        // ================= C5x2 =================
        {
            藏品Type.灵龟玄甲,
            new 藏品配置
            {
                name = "灵龟玄甲", 介绍 = "灵龟玄甲，防御浑厚，甲在而身如磐石。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C5x2
            }
        },

        {
            藏品Type.逐月弓,
            new 藏品配置 { name = "逐月弓", 介绍 = "逐月弓，箭逐月华，弦响而月影随箭。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },

        {
            藏品Type.灵犀玉,
            new 藏品配置 { name = "灵犀玉", 介绍 = "灵犀玉，通感灵犀，玉动而知彼心。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },

        {
            藏品Type.造化玉牒,
            new 藏品配置
            {
                name = "造化玉牒", 介绍 = "造化玉牒，载造化之秘，牒开而天机现。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C5x2
            }
        },
        {
            藏品Type.白麻长幡,
            new 藏品配置 { name = "白麻长幡", 介绍 = "白麻长幡，幡面素白，祭仪招魂常用。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.青木长戟,
            new 藏品配置 { name = "青木长戟", 介绍 = "青木长戟，杆直如松，戟锋可挑阵前。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.藤甲披风,
            new 藏品配置 { name = "藤甲披风", 介绍 = "藤甲披风，藤片编缀，轻而透风。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.碧海长绸,
            new 藏品配置 { name = "碧海长绸", 介绍 = "碧海长绸，绸色如海，展动若浪起。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.寒玉长笛,
            new 藏品配置 { name = "寒玉长笛", 介绍 = "寒玉长笛，笛身生寒，吹之音冷透骨。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.青墟灯,
            new 藏品配置 { name = "青墟灯", 介绍 = "青墟灯，灯焰青幽，可照上古废墟。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.紫电长鞭,
            new 藏品配置 { name = "紫电长鞭", 介绍 = "紫电长鞭，鞭梢带紫电，挥之如雷随。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.霞光长绫,
            new 藏品配置 { name = "霞光长绫", 介绍 = "霞光长绫，绫映霞彩，舞动如霞绕身。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
    };

    /// <summary>藏品价格表：每个藏品单独一条价格</summary>
    public static Dictionary<藏品Type, float> 藏品价格Dic = 生成藏品价格表();

    private static Dictionary<藏品Type, float> 生成藏品价格表()
    {
        // 1×1 基础价，按品质递进（索引对应 QualityType）
        float[] 品质基价 = { 0, 100, 500, 3000, 20000, 150000, 1000000, 10000000, 10000000 };
        Dictionary<藏品Type, float> 表 = new Dictionary<藏品Type, float>();
        foreach (KeyValuePair<藏品Type, 藏品配置> kv in 藏品配置)
        {
            Vector2Int 尺寸 = Get藏品尺寸(kv.Value.藏品尺寸Type);
            int 面积 = Mathf.Max(1, 尺寸.x * 尺寸.y);
            int 品质 = Mathf.Clamp((int)kv.Value.QualityType, 0, 品质基价.Length - 1);
            表[kv.Key] = 品质基价[品质] * 面积;
        }
        return 表;
    }

    /// <summary>藏品尺寸类型转宽高（单位：格）</summary>
    public static Vector2Int Get藏品尺寸(藏品尺寸Type type)
    {
        switch (type)
        {
            case 藏品尺寸Type.C1x2: return new Vector2Int(1, 2);
            case 藏品尺寸Type.C2x1: return new Vector2Int(2, 1);
            case 藏品尺寸Type.C1x3: return new Vector2Int(1, 3);
            case 藏品尺寸Type.C3x1: return new Vector2Int(3, 1);
            case 藏品尺寸Type.C2x2: return new Vector2Int(2, 2);
            case 藏品尺寸Type.C3x3: return new Vector2Int(3, 3);
            case 藏品尺寸Type.C2x4: return new Vector2Int(2, 4);
            case 藏品尺寸Type.C4x2: return new Vector2Int(4, 2);
            case 藏品尺寸Type.C2x5: return new Vector2Int(2, 5);
            case 藏品尺寸Type.C5x2: return new Vector2Int(5, 2);
            case 藏品尺寸Type.C1x1:
            default: return new Vector2Int(1, 1);
        }
    }
}
