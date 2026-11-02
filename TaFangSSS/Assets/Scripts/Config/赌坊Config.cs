using System;
using System.Collections.Generic;
using Config;
using UnityEngine;
using Random = UnityEngine.Random;

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
    public string 效果;
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
    撼山弓,             // 紫 1×3
    逐日离弓,           // 橙 1×3
    镇岳神印,           // 橙 1×3
    落宝金钱,           // 粉 1×3
    青莲斧,         // 粉 1×3
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
    混沌钟,             // 彩 3×3
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
    万灵归墟盏,         // 洪 2×5
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
    // ===== 1×1 (新增) =====
    旧麻囊, // 白 1×1
    粗陶小盏, // 白 1×1
    旧木药臼杵, // 白 1×1
    石纹牌, // 白 1×1
    草编蚱笼, // 白 1×1
    素麻拭尘巾, // 白 1×1
    苔心石, // 绿 1×1
    凝露灵芽, // 绿 1×1
    青藤缠脉腕, // 绿 1×1
    青木种, // 绿 1×1
    篁风短笛, // 绿 1×1
    山花酿蜜囊, // 绿 1×1
    青鳞片, // 绿 1×1
    盘根灵须, // 绿 1×1
    寒渊听潮螺, // 蓝 1×1
    清溟珠, // 蓝 1×1
    漱月寒石, // 蓝 1×1
    玄水引灵印, // 蓝 1×1
    冰魄粒, // 蓝 1×1
    幽潭青苔, // 蓝 1×1
    碧落涵波粒, // 蓝 1×1
    凝霜珠, // 蓝 1×1
    玉髓碎屑, // 蓝 1×1
    冥纹镇魂牌, // 紫 1×1
    幽篆囊, // 紫 1×1
    蚀月萤粉, // 紫 1×1
    雷髓蕴电节, // 紫 1×1
    紫微芯, // 紫 1×1
    玄昙幽花, // 紫 1×1
    劫灰锁魂壶, // 紫 1×1
    夜灯芯, // 紫 1×1
    熔星小铃, // 橙 1×1
    熔星焚云石, // 橙 1×1
    烈阳烬, // 橙 1×1
    曜金碎屑, // 橙 1×1
    金乌焚天羽, // 橙 1×1
    焚霄珠, // 橙 1×1
    赤霄朱砂, // 橙 1×1
    坠日玄金羽, // 橙 1×1
    霞绮贝, // 粉 1×1
    幻月流尘, // 粉 1×1
    烟霞映月贝, // 粉 1×1
    星墟砂, // 彩 1×1
    混沌灵石, // 彩 1×1
    归墟渡虚尘, // 彩 1×1
    // ===== 1×2 (新增) =====
    青竹竿, // 白 1×2
    木柄药铲, // 白 1×2
    粗布束灵带, // 白 1×2
    石纹棍, // 白 1×2
    麻布短绳, // 白 1×2
    木纹量灵尺, // 白 1×2
    石短砚, // 白 1×2
    陶制小瓶, // 白 1×2
    粗陶纳露盏, // 白 1×2
    藤心盾, // 绿 1×2
    青叶短笛, // 绿 1×2
    灵草安神囊, // 绿 1×2
    草云席, // 绿 1×2
    水纹短匕, // 蓝 1×2
    碧玉锁灵簪, // 蓝 1×2
    寒铁剑, // 蓝 1×2
    清心碧笛, // 蓝 1×2
    紫藤缚灵鞭, // 紫 1×2
    幽光杖, // 紫 1×2
    藏雷檀匣, // 紫 1×2
    震岳破云锤, // 橙 1×2
    流火矛, // 橙 1×2
    拂月霞扇, // 粉 1×2
    拭心霞光帕, // 粉 1×2
    // ===== 2×1 (新增) =====
    麻长巾, // 白 2×1
    木纹短案, // 白 2×1
    石臼碾药槽, // 白 2×1
    陶长瓶, // 白 2×1
    草云长席, // 白 2×1
    青藤采霞篮, // 绿 2×1
    蕴春匣, // 绿 2×1
    镇脉灵牌, // 绿 2×1
    青藤负山筐, // 绿 2×1
    收露袋, // 绿 2×1
    养魂木匣, // 绿 2×1
    碧水藏潮匣, // 蓝 2×1
    镇心牌, // 蓝 2×1
    封雷檀盒, // 紫 2×1
    雷纹引劫牌, // 紫 2×1
    锁幽牌, // 紫 2×1
    熔阳小匣, // 橙 2×1
    召焰焚霄幡, // 橙 2×1
    织梦帕, // 粉 2×1
    绕月霞带, // 粉 2×1
    焚天血魂枪, // 红 2×1
    敕令印, // 红 2×1
    镇魄血牌, // 红 2×1
    // ===== 1×3 (新增) =====
    白木牌, // 白 1×3
    麻布小幡_1x3, // 白 1×3
    粗麻遮天幡, // 白 1×3
    白石牌, // 白 1×3
    素麻小卷_1x3, // 白 1×3
    唤鹤青竹笛, // 绿 1×3
    缚妖鞭, // 绿 1×3
    绕月青笛, // 绿 1×3
    裂云翠竹笛, // 绿 1×3
    引潮箫, // 蓝 1×3
    量渊寒尺, // 蓝 1×3
    断流碧水尺, // 蓝 1×3
    藏海卷, // 蓝 1×3
    破罡紫戟, // 紫 1×3
    镇岳紫雷戟, // 紫 1×3
    斩日戈, // 橙 1×3
    裂空金戈, // 橙 1×3
    缚仙霞光绫, // 粉 1×3
    掩月帕, // 粉 1×3
    渡虚混沌梭, // 彩 1×3
    // ===== 3×1 (新增) =====
    粗木案, // 白 3×1
    素麻小巾, // 白 3×1
    白石映心屏, // 白 3×1
    麻布案, // 白 3×1
    青竹云席, // 绿 3×1
    青玉养灵案, // 绿 3×1
    青藤席, // 绿 3×1
    碧波小卷, // 蓝 3×1
    碧水凝寒席, // 蓝 3×1
    听潮案, // 蓝 3×1
    锁雷紫屏, // 紫 3×1
    遮月紫云帕, // 紫 3×1
    裂空屏, // 紫 3×1
    紫霄弓, // 橙 3×1
    穿云火金枪, // 橙 3×1
    烈焰弓, // 橙 3×1
    破灭枪, // 粉 3×1
    招鹤霞光弓, // 粉 3×1
    // ===== 2×2 (新增) =====
    粗布巾, // 白 2×2
    木纹方匣, // 白 2×2
    石纹镇基砖, // 白 2×2
    陶方瓶, // 白 2×2
    青石小砚, // 白 2×2
    麻布收灵袋, // 白 2×2
    木方盘, // 白 2×2
    粗陶小罐, // 白 2×2
    素麻眠云垫, // 白 2×2
    采月篮, // 绿 2×2
    养元草囊, // 绿 2×2
    木灵护道牌, // 绿 2×2
    藤编席, // 绿 2×2
    听风青席, // 绿 2×2
    蕴春灵木匣, // 绿 2×2
    凝露盒, // 绿 2×2
    锁灵青匣, // 绿 2×2
    研灵碧水砚, // 蓝 2×2
    镇海印, // 蓝 2×2
    照魂水镜, // 蓝 2×2
    映月碧波镜, // 蓝 2×2
    纳潮壶, // 蓝 2×2
    封幽檀盒, // 紫 2×2
    敕令雷纹牌, // 紫 2×2
    炼阳鼎, // 橙 2×2
    焚虚火炉, // 橙 2×2
    // ===== 3×3 (新增) =====
    麻布帐, // 白 3×3
    白石小屏, // 白 3×3
    素麻隐月帐, // 白 3×3
    白玉案, // 白 3×3
    素纱小帐, // 白 3×3
    白木听风屏, // 白 3×3
    铺云席, // 绿 3×3
    聚灵青案, // 绿 3×3
    养神翠竹案, // 绿 3×3
    听泉席, // 绿 3×3
    藏月藤帐, // 绿 3×3
    潮生碧海屏, // 蓝 3×3
    镇渊鼎, // 蓝 3×3
    映天碧屏, // 蓝 3×3
    纳灵寒水案, // 蓝 3×3
    熔霞鼎, // 橙 3×3
    烬空火炉, // 橙 3×3
    照界焚天镜, // 橙 3×3
    // ===== 2×4 (新增) =====
    粗木匣, // 白 2×4
    素绢小卷, // 白 2×4
    白石听泉案, // 白 2×4
    麻布匣, // 白 2×4
    白木小卷, // 白 2×4
    素麻静心案, // 白 2×4
    引凤箫, // 绿 2×4
    缠春藤卷, // 绿 2×4
    写云翠竹卷, // 绿 2×4
    承露案, // 绿 2×4
    刻月竹卷, // 绿 2×4
    织雨碧波绫, // 蓝 2×4
    漱玉琴, // 蓝 2×4
    鸣潮碧琴, // 蓝 2×4
    照心寒潭琴, // 蓝 2×4
    镇雷琴, // 紫 2×4
    召魂紫旗, // 紫 2×4
    裂云焚空号, // 橙 2×4
    坠星烬天旗, // 橙 2×4
    // ===== 4×2 (新增) =====
    白木匣, // 白 4×2
    麻布小幡_4x2, // 白 4×2
    白石镇海屏, // 白 4×2
    素麻屏, // 白 4×2
    粗木小屏, // 白 4×2
    白麻养灵案, // 白 4×2
    缚仙索, // 绿 4×2
    聚霞青案, // 绿 4×2
    缠云翠竹案, // 绿 4×2
    听月案, // 绿 4×2
    渡厄青索, // 绿 4×2
    织潮碧海绸, // 蓝 4×2
    凝月绸, // 蓝 4×2
    流云碧绸, // 蓝 4×2
    锁魂寒玉绸, // 蓝 4×2
    封雷屏, // 紫 4×2
    射月紫弓, // 紫 4×2
    破阵焚金弓, // 橙 4×2
    坠星焚天枪, // 橙 4×2
    // ===== 2×5 (新增) =====
    白石案, // 白 2×5
    麻布小卷, // 白 2×5
    素绢记尘卷, // 白 2×5
    白木卷, // 白 2×5
    素麻小卷_2x5, // 白 2×5
    白麻含露案, // 白 2×5
    写风卷, // 绿 2×5
    引鹤青琴, // 绿 2×5
    招云翠竹旗, // 绿 2×5
    缠月卷, // 绿 2×5
    养心青琴, // 绿 2×5
    清心碧水琴, // 蓝 2×5
    潮生琴, // 蓝 2×5
    藏月碧卷, // 蓝 2×5
    锁魂寒玉琴, // 蓝 2×5
    录劫卷, // 紫 2×5
    镇幽紫印, // 紫 2×5
    敕雷紫云印, // 紫 2×5
    烬天印, // 橙 2×5
    耀日火旗, // 橙 2×5
    // ===== 5×2 (新增) =====
    白石碑, // 白 5×2
    素麻小幡, // 白 5×2
    聚魂白石幡, // 白 5×2
    白麻碑, // 白 5×2
    养灵青碑, // 绿 5×2
    缚龙青藤戟, // 绿 5×2
    打神鞭, // 绿 5×2
    破云竹戟, // 绿 5×2
    断流碧水戟, // 蓝 5×2
    镇海戟, // 蓝 5×2
    缚潮寒鞭, // 蓝 5×2
    驭雷紫云鞭, // 紫 5×2
    镇幽幡, // 紫 5×2
    裂日金戟, // 橙 5×2
    烬空焚天幡, // 橙 5×2
    弑神枪, // 彩 5×2
    震岳火鞭, // 橙 5×2
    缚霞流光绫, // 粉 5×2
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
    /// <summary>藏品效果加成：仅粉（宙品）、红/彩（洪品）品质藏品有效果</summary>
    public 藏品效果 效果 = new 藏品效果();
    /// <summary>藏品价格：大于0时使用该值，否则按品质×面积自动生成唯一价格</summary>
    public float 价格;
    public float 同品质同尺寸出货概率;
}

/// <summary>藏品效果加成字段，数值为百分比（如 5 表示 +5%）</summary>
public class 藏品效果
{
    //粉
    public float 最终伤害;//可重复
    //红
    public float 跟脚倍数;//可重复
    //彩
    public float 时间流速;
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
    /// <summary>生成仓库时使用的藏品配置版本，与当前版本不一致时重新开仓</summary>
    public int 配置版本;
    public List<赌坊藏品存档> 藏品列表 = new List<赌坊藏品存档>();
    /// <summary>使用信息类道具后得到的仓库信息记录，持久化展示在道具信息面板</summary>
    public List<string> 道具信息列表 = new List<string>();
}

public class 赌坊Config
{
    /// <summary>藏品配置版本：新增/调整藏品后递增，旧存档的仓库存档会自动重新开仓</summary>
    public const int 赌坊配置版本 = 4;

    public static Dictionary<赌坊Type, 赌坊配置> 赌坊配置 = new Dictionary<赌坊Type, 赌坊配置>()
    {
        {
            赌坊Type.铜钱巷 ,new 赌坊配置(){name = "青云赌坊",行数=5,首仓价格 = 30000,概率 = new List<float>(){7000,3000,0,0,0,0,0,0}}
        },
        {
            赌坊Type.骰子坊 ,new 赌坊配置(){name = "星落赌坊",行数=6,首仓价格 = 60000,概率 = new List<float>(){4000,5000,1000,0,0,0,0,0}}
        },
        {
            赌坊Type.聚宝斋 ,new 赌坊配置(){name = "聚宝赌坊",行数=7,首仓价格 = 120000,概率 = new List<float>(){2000,5000,3000,0,0,0,0,0}}
        },
        {
            赌坊Type.千金楼 ,new 赌坊配置(){name = "千金赌坊",行数=8,首仓价格 = 250000,概率 = new List<float>(){2000,3500,4000,500,0,0,0,0}}
        },
        {
            赌坊Type.灵石台 ,new 赌坊配置(){name = "灵石赌坊",行数=9,首仓价格 = 400000,概率 = new List<float>(){2000,2000,5000,1000,0,0,0,0}}
        },
        {
            赌坊Type.风云阁 ,new 赌坊配置(){name = "风云赌坊",行数=10,首仓价格 = 800000,概率 = new List<float>(){2000,2300,4000,1500,200,0,0,0}}
        },
        
        {
            赌坊Type.万象庄 ,new 赌坊配置(){name = "万象赌坊",行数=11,首仓价格 = 1500000,概率 = new List<float>(){1500,2000,4000,2000,500,0,0,0}}
        },
        
        {
            赌坊Type.天机局 ,new 赌坊配置(){name = "天机赌坊",行数=12,首仓价格 = 4000000,概率 = new List<float>(){1000,2000,3000,3000,950,50,0,0}}
        },
        
        {
            赌坊Type.玲珑幻境 ,new 赌坊配置(){name = "玲珑赌坊",行数=13,首仓价格 = 10000000,概率 = new List<float>(){500,1500,3000,3400,1370,230,0,0}}
        },
        
        {
            赌坊Type.九幽赌窟 ,new 赌坊配置(){name = "九幽赌坊",行数=14,首仓价格 = 42000000,概率 = new List<float>(){500,1000,2500,3700,1800,450,50,0}}
        },
        
        {
            赌坊Type.星河赌坊 ,new 赌坊配置(){name = "星河赌坊",行数=15,首仓价格 = 120000000,概率 = new List<float>(){500,1000,2000,3300,2200,800,200,0}}
        },
        
        {
            赌坊Type.轮回台 ,new 赌坊配置(){name = "轮回赌坊",行数=16,首仓价格 = 600000000,概率 = new List<float>(){500,500,2000,2500,2450,1540,500,10}}
        },
    };

    public static Dictionary<QualityType, List<藏品Type>> 品质藏品列表 = new Dictionary<QualityType, List<藏品Type>>()
    {
        // 黄品 (91)
        {
            QualityType.黄品,
            new List<藏品Type>
            {
                藏品Type.青竹短匕, 藏品Type.凡铁箭簇, 藏品Type.苦竹笛, 藏品Type.桐木简册,
                藏品Type.山涧石钵, 藏品Type.粗麻灵袋, 藏品Type.老藤酒瓢, 藏品Type.寒溪卵石,
                藏品Type.土陶丹瓶, 藏品Type.兽皮手札, 藏品Type.竹编鱼篓, 藏品Type.灰陶酒坛,
                藏品Type.藤编提篮, 藏品Type.白石镇纸, 藏品Type.老布背包, 藏品Type.白玉蒲团,
                藏品Type.素纱灯罩, 藏品Type.麻布长卷, 藏品Type.竹节令牌, 藏品Type.粗木长案,
                藏品Type.石纹屏风, 藏品Type.素麻挂毯, 藏品Type.白木长匣, 藏品Type.素绢画卷,
                藏品Type.白麻长幡, 藏品Type.旧麻囊, 藏品Type.粗陶小盏, 藏品Type.旧木药臼杵,
                藏品Type.石纹牌, 藏品Type.草编蚱笼, 藏品Type.素麻拭尘巾, 藏品Type.青竹竿,
                藏品Type.木柄药铲, 藏品Type.粗布束灵带, 藏品Type.石纹棍, 藏品Type.麻布短绳,
                藏品Type.木纹量灵尺, 藏品Type.石短砚, 藏品Type.陶制小瓶, 藏品Type.粗陶纳露盏,
                藏品Type.麻长巾, 藏品Type.木纹短案, 藏品Type.石臼碾药槽, 藏品Type.陶长瓶,
                藏品Type.草云长席, 藏品Type.白木牌, 藏品Type.麻布小幡_1x3, 藏品Type.粗麻遮天幡,
                藏品Type.白石牌, 藏品Type.素麻小卷_1x3, 藏品Type.粗木案, 藏品Type.素麻小巾,
                藏品Type.白石映心屏, 藏品Type.麻布案, 藏品Type.粗布巾, 藏品Type.木纹方匣,
                藏品Type.石纹镇基砖, 藏品Type.陶方瓶, 藏品Type.青石小砚, 藏品Type.麻布收灵袋,
                藏品Type.木方盘, 藏品Type.粗陶小罐, 藏品Type.素麻眠云垫, 藏品Type.麻布帐,
                藏品Type.白石小屏, 藏品Type.素麻隐月帐, 藏品Type.白玉案, 藏品Type.素纱小帐,
                藏品Type.白木听风屏, 藏品Type.粗木匣, 藏品Type.素绢小卷, 藏品Type.白石听泉案,
                藏品Type.麻布匣, 藏品Type.白木小卷, 藏品Type.素麻静心案, 藏品Type.白木匣,
                藏品Type.麻布小幡_4x2, 藏品Type.白石镇海屏, 藏品Type.素麻屏, 藏品Type.粗木小屏,
                藏品Type.白麻养灵案, 藏品Type.白石案, 藏品Type.麻布小卷, 藏品Type.素绢记尘卷,
                藏品Type.白木卷, 藏品Type.素麻小卷_2x5, 藏品Type.白麻含露案, 藏品Type.白石碑,
                藏品Type.素麻小幡, 藏品Type.聚魂白石幡, 藏品Type.白麻碑
            }
        },

        // 玄品 (80)
        {
            QualityType.玄品,
            new List<藏品Type>
            {
                藏品Type.凝露草, 藏品Type.青纹石佩, 藏品Type.松风笛, 藏品Type.赤铜灵镜,
                藏品Type.云纹木簪, 藏品Type.灵狐尾羽, 藏品Type.清泉玉珠, 藏品Type.月华草根,
                藏品Type.灵鹿角屑, 藏品Type.引风幡残片, 藏品Type.玄铁短戈, 藏品Type.聚灵瓦炉,
                藏品Type.青玉卦签, 藏品Type.玄龟小盾, 藏品Type.青木棋盘, 藏品Type.青藤长鞭,
                藏品Type.青竹长箫, 藏品Type.藤纹盾, 藏品Type.青藤长索, 藏品Type.翠竹令旗,
                藏品Type.木灵符牌, 藏品Type.青木长戟, 藏品Type.藤甲披风, 藏品Type.苔心石,
                藏品Type.凝露灵芽, 藏品Type.青藤缠脉腕, 藏品Type.青木种, 藏品Type.篁风短笛,
                藏品Type.山花酿蜜囊, 藏品Type.青鳞片, 藏品Type.盘根灵须, 藏品Type.藤心盾,
                藏品Type.青叶短笛, 藏品Type.灵草安神囊, 藏品Type.草云席, 藏品Type.青藤采霞篮,
                藏品Type.蕴春匣, 藏品Type.镇脉灵牌, 藏品Type.青藤负山筐, 藏品Type.收露袋,
                藏品Type.养魂木匣, 藏品Type.唤鹤青竹笛, 藏品Type.缚妖鞭, 藏品Type.绕月青笛,
                藏品Type.裂云翠竹笛, 藏品Type.青竹云席, 藏品Type.青玉养灵案, 藏品Type.青藤席,
                藏品Type.采月篮, 藏品Type.养元草囊, 藏品Type.木灵护道牌, 藏品Type.藤编席,
                藏品Type.听风青席, 藏品Type.蕴春灵木匣, 藏品Type.凝露盒, 藏品Type.锁灵青匣,
                藏品Type.铺云席, 藏品Type.聚灵青案, 藏品Type.养神翠竹案, 藏品Type.听泉席,
                藏品Type.藏月藤帐, 藏品Type.引凤箫, 藏品Type.缠春藤卷, 藏品Type.写云翠竹卷,
                藏品Type.承露案, 藏品Type.刻月竹卷, 藏品Type.缚仙索, 藏品Type.聚霞青案,
                藏品Type.缠云翠竹案, 藏品Type.听月案, 藏品Type.渡厄青索, 藏品Type.写风卷,
                藏品Type.引鹤青琴, 藏品Type.招云翠竹旗, 藏品Type.缠月卷, 藏品Type.养心青琴,
                藏品Type.养灵青碑, 藏品Type.缚龙青藤戟, 藏品Type.打神鞭, 藏品Type.破云竹戟
            }
        },

        // 地品 (68)
        {
            QualityType.地品,
            new List<藏品Type>
            {
                藏品Type.流霞石灯, 藏品Type.幽泉玉佩, 藏品Type.灵犀角, 藏品Type.沧澜舟桨,
                藏品Type.落霞琉璃瓶, 藏品Type.玉荷盏, 藏品Type.翠玉拂尘, 藏品Type.玄水玉璧,
                藏品Type.引星盘残片, 藏品Type.青岚幡, 藏品Type.碧水砚台, 藏品Type.碧霞丹炉,
                藏品Type.紫纹鼎, 藏品Type.聚灵青葫, 藏品Type.霜月寒镜, 藏品Type.苍龙鳞甲,
                藏品Type.寒潭玉尺, 藏品Type.碧波长绫, 藏品Type.墨灵古琴, 藏品Type.灵龟玄甲,
                藏品Type.碧海长绸, 藏品Type.寒玉长笛, 藏品Type.寒渊听潮螺, 藏品Type.清溟珠,
                藏品Type.漱月寒石, 藏品Type.玄水引灵印, 藏品Type.冰魄粒, 藏品Type.幽潭青苔,
                藏品Type.碧落涵波粒, 藏品Type.凝霜珠, 藏品Type.玉髓碎屑, 藏品Type.水纹短匕,
                藏品Type.碧玉锁灵簪, 藏品Type.寒铁剑, 藏品Type.清心碧笛, 藏品Type.碧水藏潮匣,
                藏品Type.镇心牌, 藏品Type.引潮箫, 藏品Type.量渊寒尺, 藏品Type.断流碧水尺,
                藏品Type.藏海卷, 藏品Type.碧波小卷, 藏品Type.碧水凝寒席, 藏品Type.听潮案,
                藏品Type.研灵碧水砚, 藏品Type.镇海印, 藏品Type.照魂水镜, 藏品Type.映月碧波镜,
                藏品Type.纳潮壶, 藏品Type.潮生碧海屏, 藏品Type.镇渊鼎, 藏品Type.映天碧屏,
                藏品Type.纳灵寒水案, 藏品Type.织雨碧波绫, 藏品Type.漱玉琴, 藏品Type.鸣潮碧琴,
                藏品Type.照心寒潭琴, 藏品Type.织潮碧海绸, 藏品Type.凝月绸, 藏品Type.流云碧绸,
                藏品Type.锁魂寒玉绸, 藏品Type.清心碧水琴, 藏品Type.潮生琴, 藏品Type.藏月碧卷,
                藏品Type.锁魂寒玉琴, 藏品Type.断流碧水戟, 藏品Type.镇海戟, 藏品Type.缚潮寒鞭
            }
        },

        // 天品 (53)
        {
            QualityType.天品,
            new List<藏品Type>
            {
                藏品Type.幽溟珠, 藏品Type.裂风枪, 藏品Type.碧游简册, 藏品Type.幽夜灯,
                藏品Type.吞灵玉蝉, 藏品Type.玄岳印, 藏品Type.九叶凝芝, 藏品Type.撼山弓,
                藏品Type.焚天蒲团, 藏品Type.紫纹符牌, 藏品Type.万载灵根, 藏品Type.云荒罗盘,
                藏品Type.赤霞鼎, 藏品Type.焚天罗盘, 藏品Type.玄冥玉壶, 藏品Type.星陨铁,
                藏品Type.紫云蒲扇, 藏品Type.落星琉璃盏, 藏品Type.霜河玉璜, 藏品Type.紫檀长匣,
                藏品Type.逐月弓, 藏品Type.青墟灯, 藏品Type.紫电长鞭, 藏品Type.冥纹镇魂牌,
                藏品Type.幽篆囊, 藏品Type.蚀月萤粉, 藏品Type.雷髓蕴电节, 藏品Type.紫微芯,
                藏品Type.玄昙幽花, 藏品Type.劫灰锁魂壶, 藏品Type.夜灯芯, 藏品Type.紫藤缚灵鞭,
                藏品Type.幽光杖, 藏品Type.藏雷檀匣, 藏品Type.封雷檀盒, 藏品Type.雷纹引劫牌,
                藏品Type.锁幽牌, 藏品Type.破罡紫戟, 藏品Type.镇岳紫雷戟, 藏品Type.锁雷紫屏,
                藏品Type.遮月紫云帕, 藏品Type.裂空屏, 藏品Type.封幽檀盒, 藏品Type.敕令雷纹牌,
                藏品Type.镇雷琴, 藏品Type.召魂紫旗, 藏品Type.封雷屏, 藏品Type.射月紫弓,
                藏品Type.录劫卷, 藏品Type.镇幽紫印, 藏品Type.敕雷紫云印, 藏品Type.驭雷紫云鞭,
                藏品Type.镇幽幡
            }
        },

        // 宇品 (49)
        {
            QualityType.宇品,
            new List<藏品Type>
            {
                藏品Type.九幽罗幡, 藏品Type.千丝缚仙索, 藏品Type.镇水神碑, 藏品Type.惊雷钺,
                藏品Type.玄黄玉圭, 藏品Type.逐日离弓, 藏品Type.镇岳神印, 藏品Type.镇魔石碑,
                藏品Type.山海玉简, 藏品Type.焚天玄鼎, 藏品Type.碧霞仙钟, 藏品Type.玄天宝鉴,
                藏品Type.碧水瑶琴, 藏品Type.苍澜神鼎, 藏品Type.赤霄玉磬, 藏品Type.山海图残卷,
                藏品Type.流虹仙槎, 藏品Type.苍澜战鼓, 藏品Type.玄天战鼓, 藏品Type.熔星小铃,
                藏品Type.熔星焚云石, 藏品Type.烈阳烬, 藏品Type.曜金碎屑, 藏品Type.金乌焚天羽,
                藏品Type.焚霄珠, 藏品Type.赤霄朱砂, 藏品Type.坠日玄金羽, 藏品Type.震岳破云锤,
                藏品Type.流火矛, 藏品Type.熔阳小匣, 藏品Type.召焰焚霄幡, 藏品Type.斩日戈,
                藏品Type.裂空金戈, 藏品Type.紫霄弓, 藏品Type.穿云火金枪, 藏品Type.烈焰弓,
                藏品Type.炼阳鼎, 藏品Type.焚虚火炉, 藏品Type.熔霞鼎, 藏品Type.烬空火炉,
                藏品Type.裂云焚空号, 藏品Type.坠星烬天旗, 藏品Type.破阵焚金弓, 藏品Type.坠星焚天枪,
                藏品Type.烬天印, 藏品Type.耀日火旗, 藏品Type.裂日金戟, 藏品Type.烬空焚天幡,
                藏品Type.震岳火鞭
            }
        },

        // 宙品 (27)
        {
            QualityType.宙品,
            new List<藏品Type>
            {
                藏品Type.定风珠, 藏品Type.二十四颗定海神珠, 藏品Type.赤霞珠, 藏品Type.幽冥轮回简,
                藏品Type.素色云界旗, 藏品Type.离地焰光旗, 藏品Type.落宝金钱, 藏品Type.青莲斧,
                藏品Type.伏羲琴, 藏品Type.混元金斗, 藏品Type.天衍盘, 藏品Type.七宝琉璃塔,
                藏品Type.金蛟剪, 藏品Type.崆峒印, 藏品Type.灵犀玉, 藏品Type.霞光长绫,
                藏品Type.霞绮贝, 藏品Type.幻月流尘, 藏品Type.烟霞映月贝, 藏品Type.拂月霞扇,
                藏品Type.拭心霞光帕, 藏品Type.织梦帕, 藏品Type.绕月霞带, 藏品Type.掩月帕,
                藏品Type.破灭枪, 藏品Type.招鹤霞光弓, 藏品Type.缚霞流光绫
            }
        },

        // 洪品 (16)
        {
            QualityType.洪品,
            new List<藏品Type>
            {
                藏品Type.业火红莲, 藏品Type.河图洛书, 藏品Type.灭世黑莲, 藏品Type.诸天庆云,
                藏品Type.六道轮回盘, 藏品Type.太极图, 藏品Type.盘古幡, 藏品Type.乾坤鼎,
                藏品Type.山河社稷图, 藏品Type.诛仙四剑, 藏品Type.万灵归墟盏, 藏品Type.量天尺,
                藏品Type.焚天血魂枪, 藏品Type.敕令印, 藏品Type.镇魄血牌, 藏品Type.缚仙霞光绫
            }
        },

        // 荒品 (16)
        {
            QualityType.荒品,
            new List<藏品Type>
            {
                藏品Type.鸿蒙珠, 藏品Type.万道之源, 藏品Type.轮回核心, 藏品Type.无始灵枢,
                藏品Type.太虚本源, 藏品Type.混沌钟, 藏品Type.天外混沌鼎, 藏品Type.混沌青莲,
                藏品Type.开天斧, 藏品Type.造化玉牒, 藏品Type.星墟砂, 藏品Type.混沌灵石,
                藏品Type.归墟渡虚尘, 藏品Type.渡虚混沌梭, 藏品Type.照界焚天镜, 藏品Type.弑神枪
            }
        },

    };

    public static float Get藏品总最终伤害加成()
    {
        float 总值 = 0;
        foreach (KeyValuePair<藏品Type, int> kv in PlayerData.S.藏品仓库Dic)
        {
            if (kv.Value <= 0) continue;
            if (!藏品配置.TryGetValue(kv.Key, out 藏品配置 config)) continue;
            总值 += config.效果.最终伤害 * kv.Value;
        }
        return 总值;
    }
    public static float Get藏品总跟脚倍数加成()
    {
        float 总值 = 0;
        foreach (KeyValuePair<藏品Type, int> kv in PlayerData.S.藏品仓库Dic)
        {
            if (kv.Value <= 0) continue;
            if (!藏品配置.TryGetValue(kv.Key, out 藏品配置 config)) continue;
            总值 += config.效果.跟脚倍数 * kv.Value;
        }
        return 总值;
    }
    public static float Get藏品总时间流速加成()
    {
        float 总值 = 0;
        foreach (KeyValuePair<藏品Type, int> kv in PlayerData.S.藏品仓库Dic)
        {
            if (kv.Value <= 0) continue;
            if (!藏品配置.TryGetValue(kv.Key, out 藏品配置 config)) continue;
            总值 += config.效果.时间流速 * kv.Value;
        }
        return 总值;
    }
    public static Dictionary<int, float> 轮数价格倍数 = new Dictionary<int, float>()
    {
        {1,1},
        {2,1.1f},
        {3,1.2f},
        {4,1.3f},
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
            new 道具配置 { QualityType = QualityType.黄品, 价格 = 100, 名称 = "窥微镜",效果 = "随机看一件藏品的品质"}
        },
        {
            赌坊道具Type.随机看品质2,
            new 道具配置 { QualityType = QualityType.玄品, 价格 = 500, 名称 = "照影镜" ,效果 = "随机看二件藏品的品质"}
        },
        {
            赌坊道具Type.随机看品质3,
            new 道具配置 { QualityType = QualityType.地品, 价格 = 2000, 名称 = "鉴真镜" ,效果 = "随机看三件藏品的品质"}
        },
        {
            赌坊道具Type.随机看品质4,
            new 道具配置 { QualityType = QualityType.天品, 价格 = 10000, 名称 = "通玄镜" ,效果 = "随机看四件藏品的品质"}
        },
        {
            赌坊道具Type.随机看品质5,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 100000, 名称 = "观天镜" ,效果 = "随机看五件藏品的品质"}
        },

        // ===== 随机看尺寸 =====
      
        {
            赌坊道具Type.藏品平均价值,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 80000, 名称 = "丈虚尺" ,效果 = "查看所有藏品的平均价值"}
        },

        // ===== 仓库信息 =====
        {
            赌坊道具Type.看仓库总格子数,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 100000, 名称 = "乾坤盘" ,效果 = "查看仓库总藏品数"}
        },
        {
            赌坊道具Type.白格子数量,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 100000, 名称 = "白露签" ,效果 = "查看仓库白色藏品总格子数"}
        },
        {
            赌坊道具Type.绿格子数量,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 100000, 名称 = "青岚签" ,效果 = "查看仓库绿色藏品总格子数"}
        },
        {
            赌坊道具Type.蓝格子数量,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 100000, 名称 = "沧澜签" ,效果 = "查看仓库蓝色藏品总格子数"}
        },
        {
            赌坊道具Type.看最大藏品轮廓,
            new 道具配置 { QualityType = QualityType.宇品, 价格 = 100000, 名称 = "照世镜" ,效果 ="查看最大藏品轮廓"}
        },
    };

    /// <summary>各赌坊的道具价格倍率：道具价格 = 道具基础价格 × 倍率（铜钱巷为基准 1）</summary>
    public static Dictionary<赌坊Type, float> 道具价格倍率 = new Dictionary<赌坊Type, float>()
    {
        { 赌坊Type.铜钱巷, 1 },
        { 赌坊Type.骰子坊, 2f },
        { 赌坊Type.聚宝斋, 4f },
        { 赌坊Type.千金楼, 8 },
        { 赌坊Type.灵石台, 15 },
        { 赌坊Type.风云阁, 30 },
        { 赌坊Type.万象庄, 50 },
        { 赌坊Type.天机局, 100 },
        { 赌坊Type.玲珑幻境, 150 },
        { 赌坊Type.九幽赌窟, 200 },
        { 赌坊Type.星河赌坊, 300 },
        { 赌坊Type.轮回台, 500 },
    };

    /// <summary>取某赌坊中指定道具的实际价格</summary>
    public static float Get道具价格(赌坊Type 赌坊, 赌坊道具Type 道具)
    {
        if (!道具配置.TryGetValue(道具, out 道具配置 config)) return 0;

        道具价格倍率.TryGetValue(赌坊, out float 倍率);
        if (倍率 <= 0) 倍率 = 1;
        return config.价格 * 倍率;
    }

    /// <summary>普通藏品配置：黄/玄/地/天/宇品</summary>
    public static Dictionary<藏品Type, 藏品配置> 普通藏品配置 = new Dictionary<藏品Type, 藏品配置>()
    {
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
            藏品Type.翠玉拂尘,
            new 藏品配置 { name = "翠玉拂尘", 介绍 = "翠玉为柄，拂尘轻扫，可净周身尘秽。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.幽夜灯,
            new 藏品配置 { name = "幽夜灯", 介绍 = "灯焰幽青，夜里自明，可照幽冥路径。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
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
        {
            藏品Type.九叶凝芝,
            new 藏品配置 { name = "九叶凝芝", 介绍 = "九叶凝芝，药力醇厚，可续将断之脉。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.撼山弓,
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
            藏品Type.镇魔石碑,
            new 藏品配置 { name = "镇魔石碑", 介绍 = "碑刻镇魔古文，碑立而邪祟退避。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.山海玉简,
            new 藏品配置 { name = "山海玉简", 介绍 = "玉简载山海异志，简展而山海在目。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.焚天蒲团,
            new 藏品配置 { name = "焚天蒲团", 介绍 = "坐蒲团可引火属灵气，焚天煮海。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
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
        {
            藏品Type.玄天宝鉴,
            new 藏品配置 { name = "玄天宝鉴", 介绍 = "玄天宝鉴，照见虚实，可破万般幻象。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
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
        {
            藏品Type.墨灵古琴,
            new 藏品配置 { name = "墨灵古琴", 介绍 = "墨灵古琴，音可通幽，弦动而幽冥应。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
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
            藏品Type.旧麻囊,
            new 藏品配置 { name = "旧麻囊", 介绍 = "旧麻织成，囊口微松，可纳些零碎灵物。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.粗陶小盏,
            new 藏品配置 { name = "粗陶小盏", 介绍 = "粗陶小盏，质朴无华，盛露不渗。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.旧木药臼杵,
            new 藏品配置 { name = "旧木药臼杵", 介绍 = "旧木臼杵，久捣诸药，暗含药香。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.石纹牌,
            new 藏品配置 { name = "石纹牌", 介绍 = "石牌天然带纹，可作记数镇纸之用。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.草编蚱笼,
            new 藏品配置 { name = "草编蚱笼", 介绍 = "草编小笼，通透轻便，可蓄灵虫。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.素麻拭尘巾,
            new 藏品配置 { name = "素麻拭尘巾", 介绍 = "素麻方巾，轻拭可去器物尘秽。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.苔心石,
            new 藏品配置 { name = "苔心石", 介绍 = "石心生苔，绿意凝灵，久佩可清心。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.凝露灵芽,
            new 藏品配置 { name = "凝露灵芽", 介绍 = "灵芽常凝晨露，芽尖泛点点清光。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.青藤缠脉腕,
            new 藏品配置 { name = "青藤缠脉腕", 介绍 = "青藤编环，缠于腕上，可助血脉通畅。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.青木种,
            new 藏品配置 { name = "青木种", 介绍 = "青木灵种，蕴一点生机，入土可萌。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.篁风短笛,
            new 藏品配置 { name = "篁风短笛", 介绍 = "短笛声似篁风，可清心驱乏。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.山花酿蜜囊,
            new 藏品配置 { name = "山花酿蜜囊", 介绍 = "山花之蜜酿成，甘甜凝灵，可缓疲劳。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.青鳞片,
            new 藏品配置 { name = "青鳞片", 介绍 = "青鳞一片，隐有水属灵气流转。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.盘根灵须,
            new 藏品配置 { name = "盘根灵须", 介绍 = "灵株盘根之须，可入丹引灵。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.寒渊听潮螺,
            new 藏品配置 { name = "寒渊听潮螺", 介绍 = "海螺置于耳畔，可闻寒渊潮声，宁神静气。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.清溟珠,
            new 藏品配置 { name = "清溟珠", 介绍 = "珠蕴清溟水气，触手清凉，可安神魂。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.漱月寒石,
            new 藏品配置 { name = "漱月寒石", 介绍 = "石经月漱，寒而不冽，可镇燥热。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.玄水引灵印,
            new 藏品配置 { name = "玄水引灵印", 介绍 = "印蕴玄水，盖印可引一泓灵泉。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.冰魄粒,
            new 藏品配置 { name = "冰魄粒", 介绍 = "冰魄凝粒，寒光内蕴，久藏不化。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.幽潭青苔,
            new 藏品配置 { name = "幽潭青苔", 介绍 = "幽潭苔藓，阴凉含灵，可入水属丹方。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.碧落涵波粒,
            new 藏品配置 { name = "碧落涵波粒", 介绍 = "粒内涵碧波，轻晃似有潮声。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.凝霜珠,
            new 藏品配置 { name = "凝霜珠", 介绍 = "凝霜成珠，触之微寒，可镇心火。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.玉髓碎屑,
            new 藏品配置 { name = "玉髓碎屑", 介绍 = "玉髓崩散成屑，犹存一缕精纯灵气。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.冥纹镇魂牌,
            new 藏品配置 { name = "冥纹镇魂牌", 介绍 = "牌刻冥纹，可镇魂安神，驱散阴祟。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.幽篆囊,
            new 藏品配置 { name = "幽篆囊", 介绍 = "囊收幽篆符文，暗含封禁之力。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.蚀月萤粉,
            new 藏品配置 { name = "蚀月萤粉", 介绍 = "萤粉蚀月之光，可隐身形，入夜生辉。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.雷髓蕴电节,
            new 藏品配置 { name = "雷髓蕴电节", 介绍 = "雷髓凝聚成节，内蕴暴烈雷电。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.紫微芯,
            new 藏品配置 { name = "紫微芯", 介绍 = "紫微星力凝芯，可引星辰灵机。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.玄昙幽花,
            new 藏品配置 { name = "玄昙幽花", 介绍 = "玄昙一现，幽香凝魂，可度神游。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.劫灰锁魂壶,
            new 藏品配置 { name = "劫灰锁魂壶", 介绍 = "壶纳劫灰，可锁困飘散魂魄。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.夜灯芯,
            new 藏品配置 { name = "夜灯芯", 介绍 = "夜灯之芯，燃之幽冥自明，照彻长夜。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.熔星小铃,
            new 藏品配置 { name = "熔星小铃", 介绍 = "铃携熔星火意，摇动可惊邪魅。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.熔星焚云石,
            new 藏品配置 { name = "熔星焚云石", 介绍 = "陨石焚云而存，内蕴滔天火气。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.烈阳烬,
            new 藏品配置 { name = "烈阳烬", 介绍 = "烈阳燃尽之烬，犹存焚世热度。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.曜金碎屑,
            new 藏品配置 { name = "曜金碎屑", 介绍 = "曜金崩碎成屑，金气煌煌，可铸神兵。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.金乌焚天羽,
            new 藏品配置 { name = "金乌焚天羽", 介绍 = "金乌坠羽，焚天一羽，火属至宝。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.焚霄珠,
            new 藏品配置 { name = "焚霄珠", 介绍 = "珠含焚霄之火，可破阴寒壁垒。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.赤霄朱砂,
            new 藏品配置 { name = "赤霄朱砂", 介绍 = "赤霄朱砂，可书神符，镇邪定神。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.坠日玄金羽,
            new 藏品配置 { name = "坠日玄金羽", 介绍 = "玄金羽自坠日而留，金火交融，品相非凡。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x1 }
        },
        {
            藏品Type.青竹竿,
            new 藏品配置 { name = "青竹竿", 介绍 = "青竹长竿，轻韧趁手，可作探路之用。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.木柄药铲,
            new 藏品配置 { name = "木柄药铲", 介绍 = "木柄药铲，刃厚耐磨，采药趁手。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.粗布束灵带,
            new 藏品配置 { name = "粗布束灵带", 介绍 = "粗布长带，束物可微敛灵气。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.石纹棍,
            new 藏品配置 { name = "石纹棍", 介绍 = "石纹长棍，质地沉重，可作防身。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.麻布短绳,
            new 藏品配置 { name = "麻布短绳", 介绍 = "麻布短绳，结实耐用，可捆系杂物。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.木纹量灵尺,
            new 藏品配置 { name = "木纹量灵尺", 介绍 = "木尺刻纹，可量灵材长短，亦作镇纸。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.石短砚,
            new 藏品配置 { name = "石短砚", 介绍 = "石制短砚，发墨尚可，可研朱砂。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.陶制小瓶,
            new 藏品配置 { name = "陶制小瓶", 介绍 = "陶制小瓶，可封存丹药灵露。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.粗陶纳露盏,
            new 藏品配置 { name = "粗陶纳露盏", 介绍 = "粗陶盏口宽浅，晨可纳露，聚而不散。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.藤心盾,
            new 藏品配置 { name = "藤心盾", 介绍 = "藤心编织成盾，轻韧可挡，可御小术。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.青叶短笛,
            new 藏品配置 { name = "青叶短笛", 介绍 = "青叶卷笛，音色清越，可召鸟雀。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.灵草安神囊,
            new 藏品配置 { name = "灵草安神囊", 介绍 = "灵草枕囊，放置榻侧，可安神助眠。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.草云席,
            new 藏品配置 { name = "草云席", 介绍 = "灵草编席，卧之如卧草云，可缓疲乏。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.水纹短匕,
            new 藏品配置 { name = "水纹短匕", 介绍 = "匕身起水纹，锋利藏寒，可破物剪金。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.碧玉锁灵簪,
            new 藏品配置 { name = "碧玉锁灵簪", 介绍 = "碧玉簪成，插簪可锁周身灵气，稳而不散。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.寒铁剑,
            new 藏品配置 { name = "寒铁剑", 介绍 = "寒铁成剑，剑出带霜，可冻敌于无形。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.清心碧笛,
            new 藏品配置 { name = "清心碧笛", 介绍 = "碧笛清鸣，可清心定魄，驱散纷扰。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.紫藤缚灵鞭,
            new 藏品配置 { name = "紫藤缚灵鞭", 介绍 = "紫藤编鞭，抽动可缚魂困灵。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.幽光杖,
            new 藏品配置 { name = "幽光杖", 介绍 = "杖头幽光，照处阴灵现形。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.藏雷檀匣,
            new 藏品配置 { name = "藏雷檀匣", 介绍 = "檀匣藏雷，开匣雷音震耳，可慑敌胆。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.震岳破云锤,
            new 藏品配置 { name = "震岳破云锤", 介绍 = "锤落震岳，可破云裂石，力拔山河。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.流火矛,
            new 藏品配置 { name = "流火矛", 介绍 = "矛尖流火，掷之烈焰横空，焚尽来敌。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x2 }
        },
        {
            藏品Type.麻长巾,
            new 藏品配置 { name = "麻长巾", 介绍 = "麻制长巾，可束发拭汗，朴素耐用。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.木纹短案,
            new 藏品配置 { name = "木纹短案", 介绍 = "木纹短案，平直稳固，可置物供奉。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.石臼碾药槽,
            new 藏品配置 { name = "石臼碾药槽", 介绍 = "石臼槽深，碾药成粉，药香暗留。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.陶长瓶,
            new 藏品配置 { name = "陶长瓶", 介绍 = "陶制长瓶，颈细体长，可存灵露多时。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.草云长席,
            new 藏品配置 { name = "草云长席", 介绍 = "长席编织，铺展如云，可坐卧静修。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.青藤采霞篮,
            new 藏品配置 { name = "青藤采霞篮", 介绍 = "青藤编篮，可采朝霞灵露，盛而不溢。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.蕴春匣,
            new 藏品配置 { name = "蕴春匣", 介绍 = "匣藏一缕春意，开匣暖意盈室。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.镇脉灵牌,
            new 藏品配置 { name = "镇脉灵牌", 介绍 = "灵牌镇脉，立之可稳一方地气。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.青藤负山筐,
            new 藏品配置 { name = "青藤负山筐", 介绍 = "青藤负筐，坚韧负重，可背山野灵材。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.收露袋,
            new 藏品配置 { name = "收露袋", 介绍 = "收露袋成，晨收诸草灵露，尽纳其中。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.养魂木匣,
            new 藏品配置 { name = "养魂木匣", 介绍 = "木匣养魂，可温养残魂，渐复清明。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.碧水藏潮匣,
            new 藏品配置 { name = "碧水藏潮匣", 介绍 = "匣藏碧水，开阖间潮声隐隐，可蓄水势。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.镇心牌,
            new 藏品配置 { name = "镇心牌", 介绍 = "牌悬胸前，可镇妄念，心若止水。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.封雷檀盒,
            new 藏品配置 { name = "封雷檀盒", 介绍 = "檀盒封雷，藏雷不泄，用时方显天威。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.雷纹引劫牌,
            new 藏品配置 { name = "雷纹引劫牌", 介绍 = "雷纹为引，可引来天劫雷力，攻伐无俦。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.锁幽牌,
            new 藏品配置 { name = "锁幽牌", 介绍 = "牌刻锁幽纹，可镇封幽冥鬼魅。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.熔阳小匣,
            new 藏品配置 { name = "熔阳小匣", 介绍 = "小匣藏熔阳火种，开匣可化一片火海。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.召焰焚霄幡,
            new 藏品配置 { name = "召焰焚霄幡", 介绍 = "幡动召焰，焚霄之火可吞苍穹。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x1 }
        },
        {
            藏品Type.白木牌,
            new 藏品配置 { name = "白木牌", 介绍 = "白木削牌，上可题字，作标记之用。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.麻布小幡_1x3,
            new 藏品配置 { name = "麻布小幡", 介绍 = "麻布小幡，随风轻展，可作引路标识。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.粗麻遮天幡,
            new 藏品配置 { name = "粗麻遮天幡", 介绍 = "粗麻长幡，展开可遮一方烈日。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.白石牌,
            new 藏品配置 { name = "白石牌", 介绍 = "白石磨牌，光洁温润，可镌刻铭文。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.素麻小卷_1x3,
            new 藏品配置 { name = "素麻小卷", 介绍 = "素麻小卷，卷收零散符纸与札记。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.唤鹤青竹笛,
            new 藏品配置 { name = "唤鹤青竹笛", 介绍 = "青竹长笛，吹之可唤仙鹤，闻声来聚。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.缚妖鞭,
            new 藏品配置 { name = "缚妖鞭", 介绍 = "长鞭缚妖，鞭出如蛇，可捆妖锁怪。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.绕月青笛,
            new 藏品配置 { name = "绕月青笛", 介绍 = "青笛音绕月华，可引月灵入耳。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.裂云翠竹笛,
            new 藏品配置 { name = "裂云翠竹笛", 介绍 = "翠竹为笛，笛声裂云，穿霄直上。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.引潮箫,
            new 藏品配置 { name = "引潮箫", 介绍 = "箫声引潮，可令江河倒流而归。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.量渊寒尺,
            new 藏品配置 { name = "量渊寒尺", 介绍 = "寒尺量渊，可测水深，亦作寒攻。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.断流碧水尺,
            new 藏品配置 { name = "断流碧水尺", 介绍 = "碧尺挥下可断流，截水成墙。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.藏海卷,
            new 藏品配置 { name = "藏海卷", 介绍 = "卷藏海图，展之可纳百川，藏海于袖。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.破罡紫戟,
            new 藏品配置 { name = "破罡紫戟", 介绍 = "紫戟破罡，可洞穿护体罡气。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.镇岳紫雷戟,
            new 藏品配置 { name = "镇岳紫雷戟", 介绍 = "紫雷附戟，镇岳之威，可裂地崩山。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.斩日戈,
            new 藏品配置 { name = "斩日戈", 介绍 = "戈锋斩日，可裂苍穹，破灭骄阳。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.裂空金戈,
            new 藏品配置 { name = "裂空金戈", 介绍 = "金戈裂空，挥之可撕空间裂隙。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C1x3 }
        },
        {
            藏品Type.粗木案,
            new 藏品配置 { name = "粗木案", 介绍 = "粗木长案，稳厚实用，可置物研墨。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.素麻小巾,
            new 藏品配置 { name = "素麻小巾", 介绍 = "素麻小巾，方寸之间，可拭可裹。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.白石映心屏,
            new 藏品配置 { name = "白石映心屏", 介绍 = "白石为屏，可映己心，反观自省。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.麻布案,
            new 藏品配置 { name = "麻布案", 介绍 = "麻布铺案，素净整齐，可衬灵物。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.青竹云席,
            new 藏品配置 { name = "青竹云席", 介绍 = "青竹编席，卧之若腾云，可静心养气。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.青玉养灵案,
            new 藏品配置 { name = "青玉养灵案", 介绍 = "青玉制案，可温养灵材，久放不腐。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.青藤席,
            new 藏品配置 { name = "青藤席", 介绍 = "青藤编席，清凉透气，可驱暑疲。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.碧波小卷,
            new 藏品配置 { name = "碧波小卷", 介绍 = "碧波成卷，展卷如见沧海，可蓄水灵。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.碧水凝寒席,
            new 藏品配置 { name = "碧水凝寒席", 介绍 = "碧水凝寒成席，卧之可清退心火。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.听潮案,
            new 藏品配置 { name = "听潮案", 介绍 = "案置窗畔，静听可闻潮汐之音，宁神。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.锁雷紫屏,
            new 藏品配置 { name = "锁雷紫屏", 介绍 = "紫屏锁雷，可挡雷劫之下，护己周全。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.遮月紫云帕,
            new 藏品配置 { name = "遮月紫云帕", 介绍 = "紫云帕遮月，可蔽天光，隐遁遁形。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.裂空屏,
            new 藏品配置 { name = "裂空屏", 介绍 = "屏立裂空，可当空间之刃，劈开敌阵。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.紫霄弓,
            new 藏品配置 { name = "紫霄弓", 介绍 = "", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.穿云火金枪,
            new 藏品配置 { name = "穿云火金梭", 介绍 = "火金成梭，穿云破雾，瞬息千里。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.烈焰弓,
            new 藏品配置 { name = "烈焰弓", 介绍 = "弓着烈焰，可羽箭索敌，可御火焚敌。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C3x1 }
        },
        {
            藏品Type.粗布巾,
            new 藏品配置 { name = "粗布巾", 介绍 = "粗布方巾，可裹物拭汗，朴实耐用。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.木纹方匣,
            new 藏品配置 { name = "木纹方匣", 介绍 = "木纹方匣，四四方正，可收纳零散。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.石纹镇基砖,
            new 藏品配置 { name = "石纹镇基砖", 介绍 = "石纹砖成，镇基压梁，稳重如山。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.陶方瓶,
            new 藏品配置 { name = "陶方瓶", 介绍 = "陶制方瓶，方正古朴，可存灵液。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.青石小砚,
            new 藏品配置 { name = "青石小砚", 介绍 = "青石小砚，发墨细润，可研朱写符。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.麻布收灵袋,
            new 藏品配置 { name = "麻布收灵袋", 介绍 = "麻布收袋，口可束紧，专收零散灵物。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.木方盘,
            new 藏品配置 { name = "木方盘", 介绍 = "木制方盘，可盛灵果灵石，摆放整齐。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.粗陶小罐,
            new 藏品配置 { name = "粗陶小罐", 介绍 = "粗陶小罐，圆口鼓腹，可腌储灵材。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.素麻眠云垫,
            new 藏品配置 { name = "素麻眠云垫", 介绍 = "素麻软垫，卧之如眠云端，可助安睡。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.采月篮,
            new 藏品配置 { name = "采月篮", 介绍 = "竹篮采月，可纳月华灵露，夜采朝收。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.养元草囊,
            new 藏品配置 { name = "养元草囊", 介绍 = "草囊养元，贴身可缓元气亏损。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.木灵护道牌,
            new 藏品配置 { name = "木灵护道牌", 介绍 = "木灵为牌，护道随行，可挡邪祟。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.藤编席,
            new 藏品配置 { name = "藤编席", 介绍 = "藤编方席，透气凉爽，可坐可卧。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.听风青席,
            new 藏品配置 { name = "听风青席", 介绍 = "青席听风，卧之可闻风言，静察四方。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.蕴春灵木匣,
            new 藏品配置 { name = "蕴春灵木匣", 介绍 = "灵木为匣，内蕴春光，可保鲜灵植。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.凝露盒,
            new 藏品配置 { name = "凝露盒", 介绍 = "盒凝晨露，可存露化水，久而不竭。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.锁灵青匣,
            new 藏品配置 { name = "锁灵青匣", 介绍 = "青匣锁灵，可将灵物封存，精华不泄。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.研灵碧水砚,
            new 藏品配置 { name = "研灵碧水砚", 介绍 = "碧水为砚，研墨化灵，可书水符。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.镇海印,
            new 藏品配置 { name = "镇海印", 介绍 = "印镇沧海，盖下可平风浪，定海安澜。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.照魂水镜,
            new 藏品配置 { name = "照魂水镜", 介绍 = "水镜照魂，可映人心真伪，洞察幽微。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.映月碧波镜,
            new 藏品配置 { name = "映月碧波镜", 介绍 = "碧波镜映月，可借月光照彻暗处。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.纳潮壶,
            new 藏品配置 { name = "纳潮壶", 介绍 = "壶纳潮汐，可蓄水势，倾倒成潮。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.封幽檀盒,
            new 藏品配置 { name = "封幽檀盒", 介绍 = "檀盒封幽，可锁困幽冥厉鬼，压而不散。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.敕令雷纹牌,
            new 藏品配置 { name = "敕令雷纹牌", 介绍 = "雷纹牌刻敕令，可召天雷，镇伏邪魔。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.炼阳鼎,
            new 藏品配置 { name = "炼阳鼎", 介绍 = "鼎炼大阳，可熔炼万物，淬阳神火。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.焚虚火炉,
            new 藏品配置 { name = "焚虚火炉", 介绍 = "火炉焚虚，可炼虚化实，焚尽幻妄。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x2 }
        },
        {
            藏品Type.麻布帐,
            new 藏品配置 { name = "麻布帐", 介绍 = "麻布撑帐，可遮风挡雨，安身小憩。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.白石小屏,
            new 藏品配置 { name = "白石小屏", 介绍 = "白石为屏，素雅遮挡，可隔内外。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.素麻隐月帐,
            new 藏品配置 { name = "素麻隐月帐", 介绍 = "素麻帐隐月，可遮天光，静心安眠。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.白玉案,
            new 藏品配置 { name = "白玉案", 介绍 = "白玉长案，光润清凉，可陈设供奉。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.素纱小帐,
            new 藏品配置 { name = "素纱小帐", 介绍 = "素纱小帐，轻透如雾，可阻蚊虫。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.白木听风屏,
            new 藏品配置 { name = "白木听风屏", 介绍 = "白木屏风，置之风口，可听风辨向。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.铺云席,
            new 藏品配置 { name = "铺云席", 介绍 = "席铺如云，卧之可享云端清凉。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.聚灵青案,
            new 藏品配置 { name = "聚灵青案", 介绍 = "青案聚灵，可汇四方灵气，助修行。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.养神翠竹案,
            new 藏品配置 { name = "养神翠竹案", 介绍 = "翠竹为案，可养神静气，缓思虑。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.听泉席,
            new 藏品配置 { name = "听泉席", 介绍 = "席置泉畔，听泉入眠，可清心除燥。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.藏月藤帐,
            new 藏品配置 { name = "藏月藤帐", 介绍 = "藤帐藏月，夜卧可见月光如纱。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.潮生碧海屏,
            new 藏品配置 { name = "潮生碧海屏", 介绍 = "屏上潮生，如临碧海，可纳水灵。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.镇渊鼎,
            new 藏品配置 { name = "镇渊鼎", 介绍 = "鼎镇深渊，可封压水下凶灵。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.映天碧屏,
            new 藏品配置 { name = "映天碧屏", 介绍 = "碧屏映天，可倒映苍穹，察天机。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.纳灵寒水案,
            new 藏品配置 { name = "纳灵寒水案", 介绍 = "寒水为案，可纳灵化寒，静镇心火。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.熔霞鼎,
            new 藏品配置 { name = "熔霞鼎", 介绍 = "鼎熔霞光，可炼霞为宝，化虚为实。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.烬空火炉,
            new 藏品配置 { name = "烬空火炉", 介绍 = "火炉烬空，可焚尽虚空，炼化万有。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C3x3 }
        },
        {
            藏品Type.粗木匣,
            new 藏品配置 { name = "粗木匣", 介绍 = "粗木长匣，可收画卷简册，防潮防蛀。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.素绢小卷,
            new 藏品配置 { name = "素绢小卷", 介绍 = "素绢长卷，可书可绘，洁净素雅。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.白石听泉案,
            new 藏品配置 { name = "白石听泉案", 介绍 = "白石案置泉边，静听水声，可澄心。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.麻布匣,
            new 藏品配置 { name = "麻布匣", 介绍 = "麻布裱匣，朴素可靠，可存易损之物。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.白木小卷,
            new 藏品配置 { name = "白木小卷", 介绍 = "白木裁卷，薄而韧，可作书简。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.素麻静心案,
            new 藏品配置 { name = "素麻静心案", 介绍 = "素麻铺案，静坐其上，可宁神定心。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.引凤箫,
            new 藏品配置 { name = "引凤箫", 介绍 = "箫声引凤，可召神凰，闻曲来朝。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.缠春藤卷,
            new 藏品配置 { name = "缠春藤卷", 介绍 = "藤蔓缠卷，取春意成卷，可疗旧伤。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.写云翠竹卷,
            new 藏品配置 { name = "写云翠竹卷", 介绍 = "翠竹成卷，可写云书，记山川图志。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.承露案,
            new 藏品配置 { name = "承露案", 介绍 = "案承天露，晨收灵露，可入丹酿。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.刻月竹卷,
            new 藏品配置 { name = "刻月竹卷", 介绍 = "竹卷刻月，可录月相变化，藏天机。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.织雨碧波绫,
            new 藏品配置 { name = "织雨碧波绫", 介绍 = "碧波织绫，可化雨成丝，柔中带韧。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.漱玉琴,
            new 藏品配置 { name = "漱玉琴", 介绍 = "琴声如漱玉，清越泠泠，可涤心神。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.鸣潮碧琴,
            new 藏品配置 { name = "鸣潮碧琴", 介绍 = "碧琴鸣潮，可引潮汐，鼓动水势。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.照心寒潭琴,
            new 藏品配置 { name = "照心寒潭琴", 介绍 = "寒潭为琴，照心明澈，可自省入定。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.镇雷琴,
            new 藏品配置 { name = "镇雷琴", 介绍 = "琴音镇雷，可压雷劫，稳我方寸。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.召魂紫旗,
            new 藏品配置 { name = "召魂紫旗", 介绍 = "紫旗召魂，可唤游魂，听令听差。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.裂云焚空号,
            new 藏品配置 { name = "裂云焚空号", 介绍 = "号角裂云，吹之可焚空裂地，震退万军。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.坠星烬天旗,
            new 藏品配置 { name = "坠星烬天旗", 介绍 = "烬天旗引坠星，可召天火，焚尽战场。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x4 }
        },
        {
            藏品Type.白木匣,
            new 藏品配置 { name = "白木匣", 介绍 = "白木宽匣，可纳较阔之物，防潮耐放。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.麻布小幡_4x2,
            new 藏品配置 { name = "麻布小幡", 介绍 = "麻布小幡，随风招展，可作引路标识。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.白石镇海屏,
            new 藏品配置 { name = "白石镇海屏", 介绍 = "白石屏镇海，可平风浪，稳一方水。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.素麻屏,
            new 藏品配置 { name = "素麻屏", 介绍 = "素麻为屏，素净遮挡，可隔席间。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.粗木小屏,
            new 藏品配置 { name = "粗木小屏", 介绍 = "粗木小屏，厚重稳固，可挡风沙。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.白麻养灵案,
            new 藏品配置 { name = "白麻养灵案", 介绍 = "白麻铺案，可养灵植，温而不燥。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.缚仙索,
            new 藏品配置 { name = "缚仙索", 介绍 = "长索缚仙，可捆仙困神，柔韧难断。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.聚霞青案,
            new 藏品配置 { name = "聚霞青案", 介绍 = "青案聚霞，可收云霞灵气，色凝而蕴。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.缠云翠竹案,
            new 藏品配置 { name = "缠云翠竹案", 介绍 = "翠竹为案，可缠云绕雾，聚而不散。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.听月案,
            new 藏品配置 { name = "听月案", 介绍 = "案置月下，静听可闻月语，悟道静心。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.渡厄青索,
            new 藏品配置 { name = "渡厄青索", 介绍 = "青索渡厄，可渡己渡人，脱困解厄。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.织潮碧海绸,
            new 藏品配置 { name = "织潮碧海绸", 介绍 = "碧海织绸，可化潮为绸，柔浪护体。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.凝月绸,
            new 藏品配置 { name = "凝月绸", 介绍 = "绸凝月华，可敛月光，化柔化刚。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.流云碧绸,
            new 藏品配置 { name = "流云碧绸", 介绍 = "碧绸流云，可御风而行，飘然若仙。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.锁魂寒玉绸,
            new 藏品配置 { name = "锁魂寒玉绸", 介绍 = "寒玉织绸，可锁魂困灵，冷冽镇邪。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.封雷屏,
            new 藏品配置 { name = "封雷屏", 介绍 = "屏封雷光，可挡雷劫，护一方安稳。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.射月紫弓,
            new 藏品配置 { name = "射月紫弓", 介绍 = "紫弓射月，箭可穿云，裂月破空。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.破阵焚金弓,
            new 藏品配置 { name = "破阵焚金戟", 介绍 = "金戟破阵，可焚阵破围，攻无不克。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.坠星焚天枪,
            new 藏品配置 { name = "坠星焚天弓", 介绍 = "焚天弓引坠星，箭落如陨，焚尽敌寇。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C4x2 }
        },
        {
            藏品Type.白石案,
            new 藏品配置 { name = "白石案", 介绍 = "白石长案，光润朴素，可陈设灵物。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.麻布小卷,
            new 藏品配置 { name = "麻布小卷", 介绍 = "麻布长卷，卷收杂物，朴实耐用。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.素绢记尘卷,
            new 藏品配置 { name = "素绢记尘卷", 介绍 = "素绢记尘，录岁月见闻，可藏旧事。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.白木卷,
            new 藏品配置 { name = "白木卷", 介绍 = "白木为卷，可刻简录事，质轻易携。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.素麻小卷_2x5,
            new 藏品配置 { name = "素麻小卷", 介绍 = "素麻小卷，卷收零散符纸札记。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.白麻含露案,
            new 藏品配置 { name = "白麻含露案", 介绍 = "白麻案含露，晨起纳露，可润灵植。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.写风卷,
            new 藏品配置 { name = "写风卷", 介绍 = "竹卷写风，可录风势，观天候变。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.引鹤青琴,
            new 藏品配置 { name = "引鹤青琴", 介绍 = "青琴引鹤，抚之可唤仙鹤来朝。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.招云翠竹旗,
            new 藏品配置 { name = "招云翠竹旗", 介绍 = "翠竹旗招云，可召云布雨，聚水润物。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.缠月卷,
            new 藏品配置 { name = "缠月卷", 介绍 = "卷缠月光，可敛月华，化阴为柔。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.养心青琴,
            new 藏品配置 { name = "养心青琴", 介绍 = "青琴养心，抚之可静心宁神，祛躁。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.清心碧水琴,
            new 藏品配置 { name = "清心碧水琴", 介绍 = "碧水琴清心，可涤尘念，明心见性。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.潮生琴,
            new 藏品配置 { name = "潮生琴", 介绍 = "琴声潮生，可引海潮，鼓荡水灵。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.藏月碧卷,
            new 藏品配置 { name = "藏月碧卷", 介绍 = "碧卷藏月，可封月光，隐遁行迹。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.锁魂寒玉琴,
            new 藏品配置 { name = "锁魂寒玉琴", 介绍 = "寒玉琴锁魂，可困幽魂，冷冽镇邪。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.录劫卷,
            new 藏品配置 { name = "录劫卷", 介绍 = "卷录劫数，可窥天劫踪迹，未雨绸缪。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.镇幽紫印,
            new 藏品配置 { name = "镇幽紫印", 介绍 = "紫印镇幽，盖之可封幽冥，驱邪慑鬼。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.敕雷紫云印,
            new 藏品配置 { name = "敕雷紫云印", 介绍 = "紫云印敕雷，可召雷镇魔，天威赫赫。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.烬天印,
            new 藏品配置 { name = "烬天印", 介绍 = "印盖烬天，可焚尽苍穹，万法成灰。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.耀日火旗,
            new 藏品配置 { name = "耀日火旗", 介绍 = "火旗耀日，展开可召烈日，焚原燎野。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C2x5 }
        },
        {
            藏品Type.白石碑,
            new 藏品配置 { name = "白石碑", 介绍 = "白石立碑，可镌刻铭文，铭记功业。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.素麻小幡,
            new 藏品配置 { name = "素麻小幡", 介绍 = "素麻小幡，随风轻展，可作标识。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.聚魂白石幡,
            new 藏品配置 { name = "聚魂白石幡", 介绍 = "白石幡聚魂，可召集游魂，安顿亡灵。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.白麻碑,
            new 藏品配置 { name = "白麻碑", 介绍 = "白麻为碑，素净庄重，可祭先贤。", QualityType = QualityType.黄品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.养灵青碑,
            new 藏品配置 { name = "养灵青碑", 介绍 = "青碑养灵，可温养灵物，护其精纯。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.缚龙青藤戟,
            new 藏品配置 { name = "缚龙青藤戟", 介绍 = "青藤缠戟，可缚龙降蛟，威震山河。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.打神鞭,
            new 藏品配置 { name = "打神鞭", 介绍 = "长鞭打神，可鞭挞仙神，威不可挡。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.破云竹戟,
            new 藏品配置 { name = "破云竹戟", 介绍 = "竹戟破云，可穿云破雾，直取敌首。", QualityType = QualityType.玄品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.断流碧水戟,
            new 藏品配置 { name = "断流碧水戟", 介绍 = "碧水戟断流，可截水成墙，御敌于外。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.镇海戟,
            new 藏品配置 { name = "镇海戟", 介绍 = "戟镇沧海，可定风波，安一方水。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.缚潮寒鞭,
            new 藏品配置 { name = "缚潮寒鞭", 介绍 = "寒鞭缚潮，可驭潮汐，化水为兵。", QualityType = QualityType.地品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.驭雷紫云鞭,
            new 藏品配置 { name = "驭雷紫云鞭", 介绍 = "紫云鞭驭雷，可驱雷驭电，天威加身。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.镇幽幡,
            new 藏品配置 { name = "镇幽幡", 介绍 = "幡镇幽冥，可压鬼魅，镇邪安魂。", QualityType = QualityType.天品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.裂日金戟,
            new 藏品配置 { name = "裂日金戟", 介绍 = "金戟裂日，可劈开骄阳，碎日焚天。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.烬空焚天幡,
            new 藏品配置 { name = "烬空焚天幡", 介绍 = "焚天幡烬空，可焚尽虚空，化万有为灰。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
        {
            藏品Type.震岳火鞭,
            new 藏品配置 { name = "震岳火鞭", 介绍 = "火鞭震岳，可震裂山岳，鞭出火海。", QualityType = QualityType.宇品, 藏品尺寸Type = 藏品尺寸Type.C5x2 }
        },
    };

    /// <summary>宙品藏品配置</summary>
    public static Dictionary<藏品Type, 藏品配置> 宙品藏品配置 = new Dictionary<藏品Type, 藏品配置>()
    {
        {
            藏品Type.定风珠,
            new 藏品配置
            {
                name = "定风珠", 介绍 = "珠光粉润，持之可定周身风息，风不能侵。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x1,
                效果 = new 藏品效果 { 最终伤害 = 10 },
                价格 = 2000000,
                同品质同尺寸出货概率 = 25,
            }
        },
        {
            藏品Type.二十四颗定海神珠,
            new 藏品配置
            {
                name = "定海神珠", 介绍 = "二十四珠成一套，镇海定浪，水族避退。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x1,
                效果 = new 藏品效果 { 最终伤害 = 50 },
                价格 = 10000000,同品质同尺寸出货概率 = 5
            }
        },
        {
            藏品Type.赤霞珠,
            new 藏品配置
            {
                name = "赤霞珠", 介绍 = "珠蕴赤霞，霞光流转，触之温润如朝日。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x1,
                效果 = new 藏品效果 { 最终伤害 = 15 },
                价格 = 2500000,
                同品质同尺寸出货概率 = 15
            }
        },
        {
            藏品Type.霞绮贝,
            new 藏品配置 { name = "霞绮贝", 介绍 = "贝面霞纹绮丽，内含一缕霓霞灵气。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x1, 效果 = new 藏品效果 { 最终伤害 = 5 }, 价格 = 1000000 ,同品质同尺寸出货概率 = 15}
        },
        {
            藏品Type.幻月流尘,
            new 藏品配置 { name = "幻月流尘", 介绍 = "幻月洒落流尘，可迷幻心神，如梦似真。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x1, 效果 = new 藏品效果 { 最终伤害 = 8 }, 价格 = 1500000 ,同品质同尺寸出货概率 = 15}
        },
        {
            藏品Type.烟霞映月贝,
            new 藏品配置 { name = "烟霞映月贝", 介绍 = "贝上烟霞映月，流光溢彩，蕴幻道之机。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x1, 效果 = new 藏品效果 { 最终伤害 = 10 }, 价格 = 2000000,同品质同尺寸出货概率 = 25}
        },
        {
            藏品Type.幽冥轮回简,
            new 藏品配置
            {
                name = "幽冥轮回简", 介绍 = "简上轮回纹隐现，涉幽冥之力，可扰生死。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x2,
                效果 = new 藏品效果 { 最终伤害 = 20 },
                价格 = 3000000,同品质同尺寸出货概率 = 30
            }
        },
        {
            藏品Type.拂月霞扇,
            new 藏品配置 { name = "拂月霞扇", 介绍 = "霞扇轻拂，可揽月华霞气，攻守由心。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x2, 效果 = new 藏品效果 { 最终伤害 = 10 }, 价格 = 2000000 ,同品质同尺寸出货概率 = 30}
        },
        {
            藏品Type.拭心霞光帕,
            new 藏品配置 { name = "拭心霞光帕", 介绍 = "霞光帕过处，可拭心尘，明心见性。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x2, 效果 = new 藏品效果 { 最终伤害 = 15 }, 价格 = 3000000 ,同品质同尺寸出货概率 = 40}
        },
        {
            藏品Type.素色云界旗,
            new 藏品配置 { name = "素色云界旗", 介绍 = "旗展云界，护身避尘，万法难沾。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x1, 效果 = new 藏品效果 { 最终伤害 = 25 }, 价格 = 4000000 ,同品质同尺寸出货概率 = 25}
        },
        {
            藏品Type.离地焰光旗,
            new 藏品配置
            {
                name = "离地焰光旗", 介绍 = "焰光旗离地腾焰，护体焚敌，焰不近身。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x1,
                效果 = new 藏品效果 { 最终伤害 = 20 },
                价格 = 3500000,同品质同尺寸出货概率 = 50
            }
        },
        {
            藏品Type.织梦帕,
            new 藏品配置 { name = "织梦帕", 介绍 = "帕织梦境，覆面可入他人之梦，迷惑心神。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x1, 效果 = new 藏品效果 { 最终伤害 = 8 }, 价格 = 1500000 ,同品质同尺寸出货概率 = 20}
        },
        {
            藏品Type.绕月霞带,
            new 藏品配置 { name = "绕月霞带", 介绍 = "霞带绕月，可借月华之力，庇护己身。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x1, 效果 = new 藏品效果 { 最终伤害 = 250 }, 价格 = 50000000 ,同品质同尺寸出货概率 = 5}
        },
        {
            藏品Type.落宝金钱,
            new 藏品配置 { name = "落宝金钱", 介绍 = "金钱一落，法宝失持，万宝皆坠。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x3, 效果 = new 藏品效果 { 最终伤害 = 30 }, 价格 = 5000000 ,同品质同尺寸出货概率 = 50}
        },
        {
            藏品Type.青莲斧,
            new 藏品配置 { name = "青莲斧", 介绍 = "斧名青莲，可斩混沌，直破万法。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x3, 效果 = new 藏品效果 { 最终伤害 = 40 }, 价格 = 8000000 ,同品质同尺寸出货概率 = 30}
        },
        {
            藏品Type.掩月帕,
            new 藏品配置 { name = "掩月帕", 介绍 = "帕掩明月，可遮天机，隐遁行踪。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C1x3, 效果 = new 藏品效果 { 最终伤害 = 10 }, 价格 = 2000000 ,同品质同尺寸出货概率 = 20}
        },
        {
            藏品Type.伏羲琴,
            new 藏品配置 { name = "伏羲琴", 介绍 = "伏羲琴，音可通神，一曲动天地。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C3x1, 效果 = new 藏品效果 { 最终伤害 = 35 }, 价格 = 6000000 ,同品质同尺寸出货概率 = 35}
        },
        {
            藏品Type.破灭枪,
            new 藏品配置 { name = "破灭枪", 介绍 = "一枪定魂，一枪破灭，可灭众神。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C3x1, 效果 = new 藏品效果 { 最终伤害 = 25 }, 价格 = 5000000 ,同品质同尺寸出货概率 = 50}
        },
        {
            藏品Type.招鹤霞光弓,
            new 藏品配置 { name = "招鹤霞光旗", 介绍 = "霞弓招展，可唤霞光仙鹤，闻讯来援。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C3x1, 效果 = new 藏品效果 { 最终伤害 = 100 }, 价格 = 20000000 ,同品质同尺寸出货概率 = 15}
        },
        {
            藏品Type.混元金斗,
            new 藏品配置 { name = "混元金斗", 介绍 = "混元金斗，可收摄万物，斗转乾坤。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x2, 效果 = new 藏品效果 { 最终伤害 = 40 }, 价格 = 8000000 ,同品质同尺寸出货概率 = 30}
        },
        {
            藏品Type.天衍盘,
            new 藏品配置 { name = "天衍盘", 介绍 = "天衍盘，推演天衍之数，可算大势。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x2, 效果 = new 藏品效果 { 最终伤害 = 10 }, 价格 = 2000000 ,同品质同尺寸出货概率 = 70}
        },
        {
            藏品Type.七宝琉璃塔,
            new 藏品配置
            {
                name = "七宝琉璃塔", 介绍 = "七宝琉璃塔，可镇可护，塔光不染尘埃。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x4,
                效果 = new 藏品效果 { 最终伤害 = 150 },
                价格 = 30000000
            }
        },
        {
            藏品Type.金蛟剪,
            new 藏品配置 { name = "金蛟剪", 介绍 = "金蛟剪，剪断灵机，一剪而法宝俱折。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C4x2, 效果 = new 藏品效果 { 最终伤害 = 150 }, 价格 = 15000000 }
        },
        {
            藏品Type.崆峒印,
            new 藏品配置 { name = "崆峒印", 介绍 = "崆峒印，镇印一方，印落而山河定。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C2x5, 效果 = new 藏品效果 { 最终伤害 = 50 }, 价格 = 10000000 }
        },
        {
            藏品Type.灵犀玉,
            new 藏品配置 { name = "灵犀玉", 介绍 = "灵犀玉，通感灵犀，玉动而知彼心。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C5x2, 效果 = new 藏品效果 { 最终伤害 = 25 }, 价格 = 5000000 ,同品质同尺寸出货概率 = 47}
        },
        {
            藏品Type.霞光长绫,
            new 藏品配置 { name = "霞光长绫", 介绍 = "霞光长绫，绫映霞彩，舞动如霞绕身。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C5x2, 效果 = new 藏品效果 { 最终伤害 = 250 }, 价格 = 50000000 ,同品质同尺寸出货概率 = 3}
        },
        {
            藏品Type.缚霞流光绫,
            new 藏品配置 { name = "缚霞流光绫", 介绍 = "流光化绫，可缚霞困仙，柔美而威力无穷。", QualityType = QualityType.宙品, 藏品尺寸Type = 藏品尺寸Type.C5x2, 效果 = new 藏品效果 { 最终伤害 = 15 }, 价格 = 3000000 ,同品质同尺寸出货概率 = 50}
        },
    };

    /// <summary>洪品藏品配置</summary>
    public static Dictionary<藏品Type, 藏品配置> 洪品藏品配置 = new Dictionary<藏品Type, 藏品配置>()
    {
        {
            藏品Type.业火红莲,
            new 藏品配置 { name = "业火红莲", 介绍 = "红莲燃业火，焚业不焚身，业尽莲开。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C2x1, 效果 = new 藏品效果 { 跟脚倍数 = 100 }, 价格 = 400000000 ,同品质同尺寸出货概率 = 5}
        },
        {
            藏品Type.焚天血魂枪,
            new 藏品配置 { name = "焚天血魂枪", 介绍 = "血魂铸枪，枪出焚天，可刺穿乾坤。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C2x1, 效果 = new 藏品效果 { 跟脚倍数 = 10 }, 价格 = 40000000 ,同品质同尺寸出货概率 = 50}
        },
        {
            藏品Type.敕令印,
            new 藏品配置 { name = "敕令印", 介绍 = "印承天敕，盖印如奉天命，万邪辟易。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C2x1, 效果 = new 藏品效果 { 跟脚倍数 = 20 }, 价格 = 80000000 ,同品质同尺寸出货概率 = 20}
        },
        {
            藏品Type.镇魄血牌,
            new 藏品配置 { name = "镇魄血牌", 介绍 = "血牌镇魄，可压冤魂厉魄，稳安亡灵。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C2x1, 效果 = new 藏品效果 { 跟脚倍数 = 5 }, 价格 = 20000000 ,同品质同尺寸出货概率 = 25}
        },
        {
            藏品Type.河图洛书,
            new 藏品配置 { name = "河图洛书", 介绍 = "河图洛书，推演天机，可窥过去未来。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C1x3, 效果 = new 藏品效果 { 跟脚倍数 = 3 }, 价格 = 15000000 ,同品质同尺寸出货概率 = 70}
        },
        {
            藏品Type.缚仙霞光绫,
            new 藏品配置 { name = "缚仙霞光绫", 介绍 = "霞光化绫，可缚仙困神，柔中带刚。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C1x3, 效果 = new 藏品效果 { 跟脚倍数 = 15 }, 价格 = 60000000 ,同品质同尺寸出货概率 = 30}
        },
        {
            藏品Type.灭世黑莲,
            new 藏品配置 { name = "灭世黑莲", 介绍 = "黑莲绽处，寂灭之意弥漫，万物归寂。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x1, 效果 = new 藏品效果 { 跟脚倍数 = 10 }, 价格 = 60000000 ,同品质同尺寸出货概率 = 30}
        },
        {
            藏品Type.诸天庆云,
            new 藏品配置 { name = "诸天庆云", 介绍 = "庆云覆顶，诸邪不侵，万法不沾其身。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x1, 效果 = new 藏品效果 { 跟脚倍数 = 8 }, 价格 = 30000000 ,同品质同尺寸出货概率 = 60}
        },
        {
            藏品Type.六道轮回盘,
            new 藏品配置
            {
                name = "六道轮回盘", 介绍 = "轮回盘转，六道生灭，生死皆在一念。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x1,
                效果 = new 藏品效果 { 跟脚倍数 = 25 },
                价格 = 100000000
                ,同品质同尺寸出货概率 = 10
            }
        },
        {
            藏品Type.山河社稷图,
            new 藏品配置
            {
                name = "山河社稷图", 介绍 = "山河社稷图，内藏山河，图展而界成。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C2x4,
                效果 = new 藏品效果 { 跟脚倍数 = 25 },
                价格 = 100000000,同品质同尺寸出货概率 = 95
            }
        },
        {
            藏品Type.诛仙四剑,
            new 藏品配置 { name = "诛仙四剑", 介绍 = "诛仙四剑，杀伐至宝，剑立而仙神避。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C2x4, 效果 = new 藏品效果 { 跟脚倍数 = 500 }, 价格 = 2000000000 ,同品质同尺寸出货概率 = 5}
        },
        {
            藏品Type.太极图,
            new 藏品配置 { name = "太极图", 介绍 = "太极图，阴阳流转，可定地水火风。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x3, 效果 = new 藏品效果 { 跟脚倍数 = 75 }, 价格 = 300000000 ,同品质同尺寸出货概率 = 50}
        },
        {
            藏品Type.盘古幡,
            new 藏品配置 { name = "盘古幡", 介绍 = "盘古幡，开天辟地之器，幡动混沌分。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x3, 效果 = new 藏品效果 { 跟脚倍数 = 750 }, 价格 = 3000000000 ,同品质同尺寸出货概率 = 5}
        },
        {
            藏品Type.乾坤鼎,
            new 藏品配置 { name = "乾坤鼎", 介绍 = "乾坤鼎，炼化乾坤，可纳天地于一炉。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C3x3, 效果 = new 藏品效果 { 跟脚倍数 = 50 }, 价格 = 200000000 ,同品质同尺寸出货概率 = 45}
        },
        {
            藏品Type.万灵归墟盏,
            new 藏品配置
            {
                name = "万灵归墟盏", 介绍 = "万灵归墟盏，可纳万灵，盏倾而归墟。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C2x5,
                效果 = new 藏品效果 { 跟脚倍数 = 25 },
                价格 = 100000000,同品质同尺寸出货概率 = 80
            }
        },
        {
            藏品Type.量天尺,
            new 藏品配置 { name = "量天尺", 介绍 = "量天尺，可量天地之距，尺出而界分明。", QualityType = QualityType.洪品, 藏品尺寸Type = 藏品尺寸Type.C2x5, 效果 = new 藏品效果 { 跟脚倍数 = 250 }, 价格 = 1000000000 ,同品质同尺寸出货概率 = 20}
        },
    };

    /// <summary>荒品藏品配置</summary>
    public static Dictionary<藏品Type, 藏品配置> 荒品藏品配置 = new Dictionary<藏品Type, 藏品配置>()
    {
        {
            藏品Type.鸿蒙珠,
            new 藏品配置
            {
                name = "鸿蒙珠", 介绍 = "珠生七彩，内蕴一缕鸿蒙之气，可窥天地初开。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C1x1,
                效果 = new 藏品效果 { 时间流速 = 200 },
                价格 = (float)1e11,同品质同尺寸出货概率 = 1
            }
        },
        {
            藏品Type.星墟砂,
            new 藏品配置 { name = "星墟砂", 介绍 = "星墟崩塌之砂，一粒可纳一界残光。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C1x1, 效果 = new 藏品效果 { 时间流速 = 2 }, 价格 = (float)1e9 ,同品质同尺寸出货概率 = 49}
        },
        {
            藏品Type.混沌灵石,
            new 藏品配置 { name = "混沌灵石", 介绍 = "混沌初开遗石，内含鸿蒙祖气。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C1x1, 效果 = new 藏品效果 { 时间流速 = 1 }, 价格 = (float)3e8 ,同品质同尺寸出货概率 = 40}
        },
        {
            藏品Type.归墟渡虚尘,
            new 藏品配置 { name = "归墟渡虚尘", 介绍 = "归墟渡虚之尘，可渡虚实边界，妙用无穷。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C1x1, 效果 = new 藏品效果 { 时间流速 = 10 }, 价格 = (float)5e9 ,同品质同尺寸出货概率 = 10}
        },
        {
            藏品Type.万道之源,
            new 藏品配置
            {
                name = "万道之源", 介绍 = "万道之源，诸法之始，得之可溯源归真。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C1x3,
                效果 = new 藏品效果 { 时间流速 = 20 },
                价格 = 10000000000,同品质同尺寸出货概率 = 20
            }
        },
        {
            藏品Type.渡虚混沌梭,
            new 藏品配置 { name = "渡虚混沌梭", 介绍 = "混沌之梭，可渡虚空乱流，穿梭各界。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C1x3, 效果 = new 藏品效果 { 时间流速 = 2 }, 价格 = 2000000000 ,同品质同尺寸出货概率 = 80}
        },
        {
            藏品Type.轮回核心,
            new 藏品配置
            {
                name = "轮回核心", 介绍 = "轮回核心，蕴轮回本源，可定生死之序。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C3x1,
                效果 = new 藏品效果 { 时间流速 = 3 },
                价格 = 1500000000,同品质同尺寸出货概率 = 50
            }
        },
        {
            藏品Type.无始灵枢,
            new 藏品配置 { name = "无始灵枢", 介绍 = "无始灵枢，枢机无始无终，可拨因果。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C3x1, 效果 = new 藏品效果 { 时间流速 = 12 }, 价格 = 6000000000 ,同品质同尺寸出货概率 = 40}
        },
        {
            藏品Type.太虚本源,
            new 藏品配置
            {
                name = "太虚本源", 介绍 = "太虚本源，虚空之根，可纳万象于虚无。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C3x1,
                效果 = new 藏品效果 { 时间流速 = 60 },
                价格 = 30000000000,同品质同尺寸出货概率 = 10
            }
        },
        {
            藏品Type.混沌青莲,
            new 藏品配置 { name = "混沌青莲", 介绍 = "混沌青莲，蕴混沌生机，莲开而界生。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C4x2, 效果 = new 藏品效果 { 时间流速 = 80 }, 价格 = 40000000000 ,同品质同尺寸出货概率 = 20}
        },
        {
            藏品Type.开天斧,
            new 藏品配置 { name = "开天斧", 介绍 = "开天斧，一斧开天，斧落而混沌判。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C4x2, 效果 = new 藏品效果 { 时间流速 = 8 }, 价格 = 4000000000 ,同品质同尺寸出货概率 = 80}
        },
        {
            藏品Type.混沌钟,
            new 藏品配置 { name = "混沌钟", 介绍 = "混沌钟，钟鸣定时空，一响镇诸天。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C3x3, 效果 = new 藏品效果 { 时间流速 = 100 }, 价格 = 50000000000 ,同品质同尺寸出货概率 = 15}
        },
        {
            藏品Type.天外混沌鼎,
            new 藏品配置
            {
                name = "天外混沌鼎", 介绍 = "天外混沌鼎，蕴混沌本源，鼎开天外。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C3x3,
                效果 = new 藏品效果 { 时间流速 = 10 },
                价格 = 5000000000,同品质同尺寸出货概率 = 35
            }
        },
        {
            藏品Type.照界焚天镜,
            new 藏品配置 { name = "照界焚天镜", 介绍 = "焚天镜照界，可映世人因果，焚邪烛正。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C3x3, 效果 = new 藏品效果 { 时间流速 = 20 }, 价格 = 10000000000 ,同品质同尺寸出货概率 = 50}
        },
        {
            藏品Type.造化玉牒,
            new 藏品配置
            {
                name = "造化玉牒", 介绍 = "造化玉牒，载造化之秘，牒开而天机现。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C5x2,
                效果 = new 藏品效果 { 时间流速 = 160 },
                价格 = 80000000000,同品质同尺寸出货概率 = 10
            }
        },
        {
            藏品Type.弑神枪,
            new 藏品配置 { name = "弑神枪", 介绍 = "魔祖罗喉的武器，枪名弑神，可破万法。", QualityType = QualityType.荒品, 藏品尺寸Type = 藏品尺寸Type.C5x2, 效果 = new 藏品效果 { 时间流速 = 16 }, 价格 = 8000000000 ,同品质同尺寸出货概率 = 90}
        },
    };

    /// <summary>全部藏品配置：由普通/宙品/洪品/荒品四个配置合并而成，供全局查询使用</summary>
    public static Dictionary<藏品Type, 藏品配置> 藏品配置 = 合并藏品配置();

    private static Dictionary<藏品Type, 藏品配置> 合并藏品配置()
    {
        Dictionary<藏品Type, 藏品配置> 表 = new Dictionary<藏品Type, 藏品配置>();
        foreach (KeyValuePair<藏品Type, 藏品配置> kv in 普通藏品配置) 表[kv.Key] = kv.Value;
        foreach (KeyValuePair<藏品Type, 藏品配置> kv in 宙品藏品配置) 表[kv.Key] = kv.Value;
        foreach (KeyValuePair<藏品Type, 藏品配置> kv in 洪品藏品配置) 表[kv.Key] = kv.Value;
        foreach (KeyValuePair<藏品Type, 藏品配置> kv in 荒品藏品配置) 表[kv.Key] = kv.Value;
        return 表;
    }

    /// <summary>藏品价格表：每个藏品单独一条价格</summary>
    public static Dictionary<藏品Type, float> 藏品价格Dic = 生成藏品价格表();

    private static Dictionary<藏品Type, float> 生成藏品价格表()
    {
        // 1×1 基础价，按品质递进（索引对应 QualityType）
        float[] 品质基价 = { 0, 100, 500, 3000, 20000, 150000, 1000000, 10000000, 10000000 };
        Dictionary<藏品Type, float> 表 = new Dictionary<藏品Type, float>();
        foreach (KeyValuePair<藏品Type, 藏品配置> kv in 藏品配置)
        {
            // 配置里显式指定了价格则优先使用
            if (kv.Value.价格 > 0)
            {
                表[kv.Key] = kv.Value.价格;
                continue;
            }

            Vector2Int 尺寸 = Get藏品尺寸(kv.Value.藏品尺寸Type);
            int 面积 = Mathf.Max(1, 尺寸.x * 尺寸.y);
            int 品质 = Mathf.Clamp((int)kv.Value.QualityType, 0, 品质基价.Length - 1);
            // 基础价 × 面积，再叠加藏品枚举序号的小偏移，保证每个藏品价格唯一
            表[kv.Key] = 品质基价[品质] * 面积 + (int)kv.Key * 7;
        }
        return 表;
    }

    /// <summary>出货权重缓存：概率>0 用配置值；概率=0 时若该品质该尺寸仅此一件记 100（唯一必出），
    /// 整组均未配置则组内均分 100（各尺寸总权重仍为 100）；组内已有配置件则 0 视为不出货</summary>
    private static Dictionary<藏品Type, float> 出货权重Dic;

    private static float Get出货权重(藏品Type type)
    {
        if (出货权重Dic == null)
        {
            出货权重Dic = new Dictionary<藏品Type, float>();
            foreach (KeyValuePair<藏品Type, 藏品配置> kv in 藏品配置)
            {
                藏品配置 c = kv.Value;
                if (c.同品质同尺寸出货概率 > 0)
                {
                    出货权重Dic[kv.Key] = c.同品质同尺寸出货概率;
                    continue;
                }

                // 概率=0：统计同品质同尺寸的藏品数量与已配置数量
                int 同组数 = 0;
                int 已配置数 = 0;
                foreach (KeyValuePair<藏品Type, 藏品配置> other in 藏品配置)
                {
                    if (other.Value.QualityType != c.QualityType || other.Value.藏品尺寸Type != c.藏品尺寸Type) continue;
                    同组数++;
                    if (other.Value.同品质同尺寸出货概率 > 0) 已配置数++;
                }
                出货权重Dic[kv.Key] = 同组数 <= 1 ? 100f : (已配置数 == 0 ? 100f / 同组数 : 0f);
            }
        }

        float 权重;
        return 出货权重Dic.TryGetValue(type, out 权重) ? 权重 : 0f;
    }

    /// <summary>宙品及以上品质抽藏品：在候选内按 同品质同尺寸出货概率 加权抽取。
    /// 概率=0 且该尺寸仅此一件时权重 100（直接出它）；各尺寸概率总和均为 100 时，等效于先等概率选尺寸、再在尺寸内按概率抽藏品。</summary>
    public static 藏品Type 按出货概率抽藏品(List<藏品Type> 候选)
    {
        if (候选 == null || 候选.Count == 0) return 藏品Type.None;
        if (候选.Count == 1) return 候选[0];

        float 总权重 = 0;
        foreach (藏品Type type in 候选) 总权重 += Get出货权重(type);
        if (总权重 <= 0) return 候选[Random.Range(0, 候选.Count)];

        float r = Random.Range(0f, 总权重);
        foreach (藏品Type type in 候选)
        {
            r -= Get出货权重(type);
            if (r <= 0) return type;
        }
        return 候选[候选.Count - 1];
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
