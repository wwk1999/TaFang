using System.Collections.Generic;

namespace Config
{
    public class HeroData
    {
        public int Level;
        public int 元神;
    }

    public enum ZhiYeType
    {
        None,
        战士,
        射手,
        辅助,
        控制,
        法师,
    }

    public enum HeroType
    {
        None,
        丹童,
        青童,
        土地,
        河伯,
        瑶池仙女,
        精卫,
        石敢当,
        玄女,
        龟丞相,
        太白金星,
        孟婆,
        白素贞,
        多闻天王,
        增长天王,
        广目天王,
        持国天王,
        雷震子,
        月老,
        嫦娥,
        何仙姑,
        杨戬,
        妲己,
        牛魔王,
        哪吒,
        孙悟空,
        刑天,
        碧霄,
        琼霄,
        金灵圣母,
        羲和,
        常羲,
        后羿,
        云霄,
        女娲,
        接引,
        准提,
        老子,
        通天,
        元始
    }

    public class HeroExp
    {
        public int 元神;
        public int Exp;
    }

    public class HeroConfig
    {
        public static Dictionary<int, string> SuoTipDic = new Dictionary<int, string>()
        {
            { 2, "筑基解锁" },
            { 3, "金丹解锁" },
            { 4, "元婴解锁" },
            { 5, "化神解锁" },
        };
        
        public static Dictionary<int, HeroExp> HeroExpDic = new Dictionary<int, HeroExp>()
        {
            {0,new HeroExp(){元神 = 1,Exp = 10}},
            {1,new HeroExp(){元神 = 1,Exp = 10}},
            {2,new HeroExp(){元神 = 1,Exp = 15}},
            {3,new HeroExp(){元神 = 1,Exp = 20}},
            {4,new HeroExp(){元神 = 1,Exp = 25}},

            {5,new HeroExp(){元神 = 2,Exp = 30}},
            {6,new HeroExp(){元神 = 2,Exp = 35}},
            {7,new HeroExp(){元神 = 2,Exp = 40}},
            {8,new HeroExp(){元神 = 2,Exp = 45}},
            {9,new HeroExp(){元神 = 2,Exp = 50}},
            
            {10,new HeroExp(){元神 = 3,Exp = 60}},
            {11,new HeroExp(){元神 = 3,Exp = 70}},
            {12,new HeroExp(){元神 = 3,Exp = 80}},
            {13,new HeroExp(){元神 = 3,Exp = 90}},
            {14,new HeroExp(){元神 = 3,Exp = 100}},

            {15,new HeroExp(){元神 = 4,Exp = 120}},
            {16,new HeroExp(){元神 = 4,Exp = 140}},
            {17,new HeroExp(){元神 = 4,Exp = 160}},
            {18,new HeroExp(){元神 = 4,Exp = 180}},
            {19,new HeroExp(){元神 = 4,Exp = 200}},

            {20,new HeroExp(){元神 = 5,Exp = 220}},
            {21,new HeroExp(){元神 = 5,Exp = 240}},
            {22,new HeroExp(){元神 = 5,Exp = 260}},
            {23,new HeroExp(){元神 = 5,Exp = 280}},
            {24,new HeroExp(){元神 = 5,Exp = 300}},
            
            {25,new HeroExp(){元神 = 6,Exp = 350}},
            {26,new HeroExp(){元神 = 6,Exp = 400}},
            {27,new HeroExp(){元神 = 6,Exp = 450}},
            {28,new HeroExp(){元神 = 6,Exp = 500}},
            {29,new HeroExp(){元神 = 6,Exp = 500}},
        };
        public static Dictionary<HeroType, string> HeroNameDic = new Dictionary<HeroType, string>()
        {
            { HeroType.丹童, "丹童" },
            { HeroType.青童, "青童" },
            { HeroType.土地, "土地" },
            { HeroType.河伯, "河伯" },
            { HeroType.瑶池仙女, "瑶池仙女" },
            { HeroType.精卫, "精卫" },
            { HeroType.石敢当, "石敢当" },
            { HeroType.玄女, "玄女" },
            { HeroType.龟丞相, "龟丞相" },
            { HeroType.太白金星, "太白金星" },
            { HeroType.孟婆, "孟婆" },
            { HeroType.白素贞, "白素贞" },
            { HeroType.多闻天王, "多闻天王" },
            { HeroType.增长天王, "增长天王" },
            { HeroType.广目天王, "广目天王" },
            { HeroType.持国天王, "持国天王" },
            { HeroType.雷震子, "雷震子" },
            { HeroType.月老, "月老" },
            { HeroType.嫦娥, "嫦娥" },
            { HeroType.何仙姑, "何仙姑" },
            { HeroType.杨戬, "杨戬" },
            { HeroType.妲己, "妲己" },
            { HeroType.牛魔王, "牛魔王" },
            { HeroType.哪吒, "哪吒" },
            { HeroType.孙悟空, "孙悟空" },
            { HeroType.刑天, "刑天" },
            { HeroType.碧霄, "碧霄" },
            { HeroType.琼霄, "琼霄" },
            { HeroType.金灵圣母, "金灵圣母" },
            { HeroType.羲和, "羲和" },
            { HeroType.常羲, "常羲" },
            { HeroType.后羿, "后羿" },
            { HeroType.云霄, "云霄" },
            { HeroType.女娲, "女娲" },
            { HeroType.接引, "接引" },
            { HeroType.准提, "准提" },
            { HeroType.老子, "老子" },
            { HeroType.通天, "通天" },
            { HeroType.元始, "元始" },
        };

        public static Dictionary<HeroType, PropType> HeroToPropDic = new Dictionary<HeroType, PropType>()
        {
            { HeroType.丹童, PropType.丹童元神 },
            { HeroType.青童, PropType.青童元神 },
            { HeroType.土地, PropType.土地元神 },
            { HeroType.河伯, PropType.河伯元神 },
            { HeroType.瑶池仙女, PropType.瑶池仙女元神 },
            { HeroType.精卫, PropType.精卫元神 },
            { HeroType.石敢当, PropType.石敢当元神 },
            { HeroType.玄女, PropType.玄女元神 },
            { HeroType.龟丞相, PropType.龟丞相元神 },
            { HeroType.太白金星, PropType.太白金星元神 },
            { HeroType.孟婆, PropType.孟婆元神 },
            { HeroType.白素贞, PropType.白素贞元神 },
            { HeroType.多闻天王, PropType.多闻天王元神 },
            { HeroType.增长天王, PropType.增长天王元神 },
            { HeroType.广目天王, PropType.广目天王元神 },
            { HeroType.持国天王, PropType.持国天王元神 },
            { HeroType.雷震子, PropType.雷震子元神 },
            { HeroType.月老, PropType.月老元神 },
            { HeroType.嫦娥, PropType.嫦娥元神 },
            { HeroType.何仙姑, PropType.何仙姑元神 },
            { HeroType.杨戬, PropType.杨戬元神 },
            { HeroType.妲己, PropType.妲己元神 },
            { HeroType.牛魔王, PropType.牛魔王元神 },
            { HeroType.哪吒, PropType.哪吒元神 },
            { HeroType.孙悟空, PropType.孙悟空元神 },
            { HeroType.刑天, PropType.刑天元神 },
            { HeroType.碧霄, PropType.碧霄元神 },
            { HeroType.琼霄, PropType.琼霄元神 },
            { HeroType.金灵圣母, PropType.金灵圣母元神 },
            { HeroType.羲和, PropType.羲和元神 },
            { HeroType.常羲, PropType.常羲元神 },
            { HeroType.后羿, PropType.后羿元神 },
            { HeroType.云霄, PropType.云霄元神 },
            { HeroType.女娲, PropType.女娲元神 },
            { HeroType.接引, PropType.接引元神 },
            { HeroType.准提, PropType.准提元神 },
            { HeroType.老子, PropType.老子元神 },
            { HeroType.通天, PropType.通天元神 },
            { HeroType.元始, PropType.元始元神 },
        };

        public static Dictionary<HeroType, ZhiYeType> HeroZhiYeDic = new Dictionary<HeroType, ZhiYeType>()
        {
            { HeroType.丹童 ,ZhiYeType.射手},
            { HeroType.青童 ,ZhiYeType.战士},
            { HeroType.土地 ,ZhiYeType.控制},
            { HeroType.河伯 ,ZhiYeType.法师},
            { HeroType.瑶池仙女 ,ZhiYeType.辅助},
            { HeroType.精卫 ,ZhiYeType.法师},
            
            { HeroType.石敢当 ,ZhiYeType.战士},
            { HeroType.玄女 ,ZhiYeType.法师},
            { HeroType.龟丞相 ,ZhiYeType.控制},
            { HeroType.太白金星 ,ZhiYeType.射手},
            { HeroType.孟婆 ,ZhiYeType.辅助},
            { HeroType.白素贞 ,ZhiYeType.法师},
            
            { HeroType.增长天王 ,ZhiYeType.战士},
            { HeroType.多闻天王 ,ZhiYeType.射手},
            { HeroType.广目天王 ,ZhiYeType.战士},
            { HeroType.持国天王 ,ZhiYeType.控制},
            { HeroType.雷震子 ,ZhiYeType.法师},
            { HeroType.月老 ,ZhiYeType.射手},
            
            { HeroType.嫦娥 ,ZhiYeType.法师},
            { HeroType.何仙姑 ,ZhiYeType.辅助},
            { HeroType.杨戬 ,ZhiYeType.射手},
            { HeroType.妲己 ,ZhiYeType.法师},
            { HeroType.牛魔王 ,ZhiYeType.战士},
            
            { HeroType.哪吒 ,ZhiYeType.战士},
            { HeroType.孙悟空 ,ZhiYeType.战士},
            { HeroType.刑天 ,ZhiYeType.战士},
            { HeroType.碧霄 ,ZhiYeType.法师},
            { HeroType.琼霄 ,ZhiYeType.控制},
            
            { HeroType.金灵圣母 ,ZhiYeType.法师},
            { HeroType.后羿 ,ZhiYeType.射手},
            { HeroType.常羲 ,ZhiYeType.控制},
            { HeroType.羲和 ,ZhiYeType.辅助},
            { HeroType.云霄 ,ZhiYeType.法师},
            
            { HeroType.女娲 ,ZhiYeType.辅助},
            { HeroType.接引 ,ZhiYeType.战士},
            { HeroType.准提 ,ZhiYeType.控制},
            
            { HeroType.老子 ,ZhiYeType.法师},
            { HeroType.元始 ,ZhiYeType.射手},
            { HeroType.通天 ,ZhiYeType.战士},
        };
        
        public static Dictionary<QualityType, HashSet<HeroType>> QualityHeroDic =
            new Dictionary<QualityType, HashSet<HeroType>>()
            {
                {
                    QualityType.黄品,
                    new HashSet<HeroType>()
                        { HeroType.丹童, HeroType.青童, HeroType.土地, HeroType.河伯, HeroType.瑶池仙女, HeroType.精卫 }
                },
                {
                    QualityType.玄品,
                    new HashSet<HeroType>()
                        { HeroType.石敢当, HeroType.玄女, HeroType.龟丞相, HeroType.太白金星, HeroType.孟婆, HeroType.白素贞 }
                },
                {
                    QualityType.地品,
                    new HashSet<HeroType>()
                        { HeroType.多闻天王, HeroType.增长天王, HeroType.广目天王, HeroType.持国天王, HeroType.雷震子, HeroType.月老 }
                },
                {
                    QualityType.天品,
                    new HashSet<HeroType>() { HeroType.嫦娥, HeroType.何仙姑, HeroType.杨戬, HeroType.妲己, HeroType.牛魔王 }
                },
                {
                    QualityType.宇品,
                    new HashSet<HeroType>() { HeroType.哪吒, HeroType.孙悟空, HeroType.刑天, HeroType.碧霄, HeroType.琼霄 }
                },
                {
                    QualityType.宙品,
                    new HashSet<HeroType>() { HeroType.金灵圣母, HeroType.羲和, HeroType.常羲, HeroType.后羿, HeroType.云霄 }
                },
                { QualityType.洪品, new HashSet<HeroType>() { HeroType.女娲, HeroType.接引, HeroType.准提 } },
                { QualityType.荒品, new HashSet<HeroType>() { HeroType.老子, HeroType.通天, HeroType.元始 } },
            };

        public static Dictionary<HeroType, string> HeroDescDic = new Dictionary<HeroType, string>()
        {
            // 白色（黄品）
            { HeroType.丹童, "太上老君座下丹童，掌炉火，识百草之性。" },
            { HeroType.青童, "西王母之青衣童，侍蟠桃，善采霞饮露。" },
            { HeroType.土地, "一方社稷之灵，位卑而乐善，知地脉走向。" },
            { HeroType.河伯, "黄河水伯，冯夷得道，性温而司水。" },
            { HeroType.瑶池仙女, "昆仑瑶池之侍女，善歌舞，以仙乐娱宾。" },
            { HeroType.精卫, "炎帝之女女娃所化，衔石填海，志坚不悔。" },

            // 绿色（玄品）
            { HeroType.石敢当, "泰山灵石所化，刚直不阿，专克邪祟。" },
            { HeroType.玄女, "九天玄女之门徒，通符箓，善兵法战阵。" },
            { HeroType.龟丞相, "东海龙宫之老臣，万年灵龟，稳重多智。" },
            { HeroType.太白金星, "长庚星君，天庭重臣，性慈而善调解。" },
            { HeroType.孟婆, "幽冥奈何桥之守者，掌忘川，饮之忘前尘。" },
            { HeroType.白素贞, "峨眉千年白蛇，慕红尘，为报恩而下凡。" },

            // 蓝色（地品）
            { HeroType.多闻天王, "四大天王之一，持混元伞，镇守北洲。" },
            { HeroType.增长天王, "四大天王之一，执青锋剑，掌南洲之卫。" },
            { HeroType.广目天王, "四大天王之一，缠赤龙，慧眼观三界。" },
            { HeroType.持国天王, "四大天王之一，抱琵琶，以音律护法。" },
            { HeroType.雷震子, "云中子之徒，食杏实生翼，性烈忠义。" },
            { HeroType.月老, "司姻缘之神，隐于月宫，喜牵红线。" },

            // 紫色（天品）
            { HeroType.嫦娥, "后羿之妻，服不死药，独居广寒。" },
            { HeroType.何仙姑, "八仙之女，得吕祖度化，乐善好施。" },
            { HeroType.杨戬, "玉帝外甥，玉鼎真人徒，开天眼，心傲。" },
            { HeroType.妲己, "冀州苏护之女，狐妖附体，绝世妖妃。" },
            { HeroType.牛魔王, "积雷山平天大圣，力大无穷，惧内。" },

            // 橙色（宇品）
            { HeroType.哪吒, "陈塘关李靖之子，太乙之徒，叛逆重义。" },
            { HeroType.孙悟空, "花果山灵石所化，菩提之徒，齐天大圣。" },
            { HeroType.刑天, "炎帝之臣，与黄帝争神，断首犹战。" },
            { HeroType.碧霄, "截教门人，赵公明之妹，性烈，姊妹情深。" },
            { HeroType.琼霄, "截教门人，与碧霄同修，善使金蛟剪。" },

            // 粉色（宙品）
            { HeroType.金灵圣母, "截教女仙之首，斗姆元君，忠义双全。" },
            { HeroType.羲和, "帝俊之妻，太阳女神，驭日车巡天。" },
            { HeroType.常羲, "帝俊之妻，月亮女神，主十二月之阴晴。" },
            { HeroType.后羿, "尧时射日英雄，力能挽弓，思妻郁郁。" },
            { HeroType.云霄, "三霄之首，摆黄河阵，心善而护短。" },

            // 红色（洪品）
            { HeroType.女娲, "抟土造人，炼石补天，万物之母，圣德无疆。" },
            { HeroType.接引, "西方教主，阿弥陀佛，发大愿，普度众生。" },
            { HeroType.准提, "西方二教主，菩提悟道，身披袈裟，法力无边。" },

            // 彩色（荒品）
            { HeroType.老子, "太上老君，三清之首，人教教主，无为而化。" },
            { HeroType.通天, "通天教主，截教教主，有教无类，率性而为。" },
            { HeroType.元始, "元始天尊，阐教教主，盘古元神，万法之源。" },
        };

        public static Dictionary<HeroType, QualityType> HeroQualityDic = new Dictionary<HeroType, QualityType>()
        {
            { HeroType.None, QualityType.None },

            // 白色 -> 黄
            { HeroType.丹童, QualityType.黄品 },
            { HeroType.青童, QualityType.黄品 },
            { HeroType.土地, QualityType.黄品 },
            { HeroType.河伯, QualityType.黄品 },
            { HeroType.瑶池仙女, QualityType.黄品 },
            { HeroType.精卫, QualityType.黄品 },

            // 绿色 -> 玄
            { HeroType.石敢当, QualityType.玄品 },
            { HeroType.玄女, QualityType.玄品 },
            { HeroType.龟丞相, QualityType.玄品 },
            { HeroType.太白金星, QualityType.玄品 },
            { HeroType.孟婆, QualityType.玄品 },
            { HeroType.白素贞, QualityType.玄品 },

            // 蓝色 -> 地
            { HeroType.多闻天王, QualityType.地品 },
            { HeroType.增长天王, QualityType.地品 },
            { HeroType.广目天王, QualityType.地品 },
            { HeroType.持国天王, QualityType.地品 },
            { HeroType.雷震子, QualityType.地品 },
            { HeroType.月老, QualityType.地品 },

            // 紫色 -> 天
            { HeroType.嫦娥, QualityType.天品 },
            { HeroType.何仙姑, QualityType.天品 },
            { HeroType.杨戬, QualityType.天品 },
            { HeroType.妲己, QualityType.天品 },
            { HeroType.牛魔王, QualityType.天品 },

            // 橙色 -> 宇
            { HeroType.哪吒, QualityType.宇品 },
            { HeroType.孙悟空, QualityType.宇品 },
            { HeroType.刑天, QualityType.宇品 },
            { HeroType.碧霄, QualityType.宇品 },
            { HeroType.琼霄, QualityType.宇品 },

            // 粉色 -> 宙
            { HeroType.金灵圣母, QualityType.宙品 },
            { HeroType.羲和, QualityType.宙品 },
            { HeroType.常羲, QualityType.宙品 },
            { HeroType.后羿, QualityType.宙品 },
            { HeroType.云霄, QualityType.宙品 },

            // 红色 -> 洪
            { HeroType.女娲, QualityType.洪品 },
            { HeroType.接引, QualityType.洪品 },
            { HeroType.准提, QualityType.洪品 },

            // 彩色 -> 荒
            { HeroType.老子, QualityType.荒品 },
            { HeroType.通天, QualityType.荒品 },
            { HeroType.元始, QualityType.荒品 }
        };
    }
}