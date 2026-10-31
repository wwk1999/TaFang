using System.Collections.Generic;
using Config;

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

    // ===== 1×3 =====
    九叶凝芝,           // 紫 1×3
    撼山钺,             // 紫 1×3
    逐日离弓,           // 橙 1×3
    镇岳神印,           // 橙 1×3
    落宝金钱,           // 粉 1×3
    青莲宝色旗,         // 粉 1×3
    河图洛书,           // 红 1×3
    万道之源,           // 彩 1×3

    // ===== 3×1 =====
    焚天蒲团,           // 紫 3×1
    伏羲琴,             // 粉 3×1
    灭世黑莲,           // 红 3×1
    诸天庆云,           // 红 3×1
    六道轮回盘,         // 红 3×1
    轮回核心,           // 彩 3×1
    无始灵枢,           // 彩 3×1
    太虚本源,           // 彩 3×1

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

    // ===== 3×3 =====
    玄天宝鉴,           // 橙 3×3
    太极图,             // 红 3×3
    混沌钟,             // 红 3×3
    盘古幡,             // 红 3×3
    乾坤鼎,             // 红 3×3
    天外混沌鼎,         // 彩 3×3

    // ===== 2×4 =====
    山海图残卷,         // 橙 2×4
    流虹仙槎,           // 橙 2×4
    苍澜战鼓,           // 橙 2×4
    山河社稷图,         // 红 2×4
    诛仙四剑,           // 红 2×4
    七宝琉璃塔,         // 粉 2×4

    // ===== 4×2 =====
    落星琉璃盏,         // 紫 4×2
    霜河玉璜,           // 紫 4×2
    金蛟剪,             // 粉 4×2
    混沌青莲,           // 彩 4×2
    开天斧,             // 彩 4×2

    // ===== 2×5 =====
    墨灵古琴,           // 蓝 2×5
    万灵归墟盏,         // 橙 2×5
    崆峒印,             // 粉 2×5
    量天尺,             // 红 2×5

    // ===== 5×2 =====
    灵龟玄甲,           // 蓝 5×2
    逐月弓,             // 紫 5×2
    灵犀玉,             // 粉 5×2
    造化玉牒,           // 彩 5×2
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
                name = "二十四颗定海神珠", 介绍 = "二十四珠成一套，镇海定浪，水族避退。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x1
            }
        },

        {
            藏品Type.鸿蒙珠,
            new 藏品配置
            {
                name = "鸿蒙珠", 介绍 = "珠生七彩，内蕴一缕鸿蒙之气，可窥天地初开。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C1x1
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
    };
    
}
