using System.Collections.Generic;

namespace Config
{
    public class HeroData
    {
        public int Level;
        public int 元神;
    }

    public class HeroZhiYeYuanSu
    {
        public ZhiYeType zhiYeType;
        public YuanSuType yuanSuType;
    }

    public enum YuanSuType
    {
        None,
        冰,
        物理,
        火,
        黑暗,
        电
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
        土地,
        河伯,
        瑶池仙女,

        石敢当,
        玄女,
        龟丞相,
        太白金星,

        多闻天王,
        广目天王,
        雷震子,
        月老,

        嫦娥,
        杨戬,
        妲己,
        牛魔王,

        哪吒,
        孙悟空,
        碧霄,
        琼霄,

        羲和,
        常羲,
        后羿,
        云霄,
        女娲,
        老子,
        通天,
        元始,

        鸿钧,
        盘古
    }

    public class HeroExp
    {
        public int 元神;
        public int Exp;
    }

    public class HeroSkill
    {
        public List<攻击特效Type> 攻击特效List;
        public List<PengType> PengList;
    }

    public class HeroConfig
    {
        public static Dictionary<HeroType, float> HeroDamageDic = new Dictionary<HeroType, float>()
        {
            { HeroType.丹童, 50 },
            { HeroType.土地, 50 },
            { HeroType.河伯, 50 },
            { HeroType.瑶池仙女, 50 },
            { HeroType.石敢当, 50 },
            { HeroType.玄女, 50 },
            { HeroType.龟丞相, 50 },
            { HeroType.太白金星, 50 },
            { HeroType.多闻天王, 50 },
            { HeroType.广目天王, 50 },
            { HeroType.雷震子, 50 },
            { HeroType.月老, 50 },
            { HeroType.嫦娥, 50 },
            { HeroType.杨戬, 50 },
            { HeroType.妲己, 50 },
            { HeroType.牛魔王, 50 },
            { HeroType.哪吒, 50 },
            { HeroType.孙悟空, 50 },
            { HeroType.碧霄, 50 },
            { HeroType.琼霄, 50 },
            { HeroType.后羿, 50 },
            { HeroType.常羲, 50 },
            { HeroType.羲和, 50 },
            { HeroType.云霄, 50 },
            { HeroType.女娲, 50 },
            { HeroType.老子, 50 },
            { HeroType.元始, 50 },
            { HeroType.通天, 50 },
            { HeroType.鸿钧, 50 },
            { HeroType.盘古, 50 }
        };
        public static Dictionary<HeroType, HeroSkill> HeroSkillDic = new Dictionary<HeroType, HeroSkill>()
        {
            {
                HeroType.丹童, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.普通火魔法弹 },
                    PengList = new List<PengType>() { PengType.火虎魔法弹Peng }
                }
            },
            {
                HeroType.土地, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.黑暗魔法弹 },
                    PengList = new List<PengType>() { PengType.黑暗魔法弹Peng }
                }
            },
            
            {
                HeroType.河伯, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.冰刺 },
                    PengList = new List<PengType>() 
                }
            },
            
            {
                HeroType.瑶池仙女, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.瑶池冰辅助 },
                    PengList = new List<PengType>() 
                }
            },
            {
                HeroType.石敢当, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.石敢当锤子 },
                    PengList = new List<PengType>() 
                }
            },
            {
                HeroType.玄女, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.玄女技能 },
                    PengList = new List<PengType>() 
                }
            },
            {
                HeroType.龟丞相, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.龟丞相技能 },
                    PengList = new List<PengType>() 
                }
            },
            {
                HeroType.太白金星, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.电魔法弹 },
                    PengList = new List<PengType>() {PengType.电魔法弹Peng}
                }
            },
            {
                HeroType.多闻天王, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.黑暗花魔法弹 },
                    PengList = new List<PengType>() {PengType.黑暗花魔法弹Peng}
                }
            },
            {
                HeroType.雷震子, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.落雷 },
                    PengList = new List<PengType>() {}
                }
            },
            {
                HeroType.月老, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.火虎魔法弹 },
                    PengList = new List<PengType>() { PengType.火虎魔法弹Peng }
                }
            },
            {
                HeroType.嫦娥, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.嫦娥技能 },
                    PengList = new List<PengType>() {}
                }
            },
            {
                HeroType.杨戬, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.电龙魔法弹 },
                    PengList = new List<PengType>() { PengType.电龙魔法弹Peng }
                }
            },
            {
                HeroType.妲己, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.黑暗辅助 },
                    PengList = new List<PengType>() {}
                }
            },
            {
                HeroType.牛魔王, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.牛魔王技能 },
                    PengList = new List<PengType>() {}
                }
            },
            {
                HeroType.哪吒, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.喷火 },
                    PengList = new List<PengType>() {}
                }
            },
            {
                HeroType.孙悟空, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.孙悟空棒子 },
                    PengList = new List<PengType>() { PengType.火虎魔法弹Peng }
                }
            },
            {
                HeroType.碧霄, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.冰龙 },
                    PengList = new List<PengType>() {  }
                }
            },
            {
                HeroType.琼霄, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.黑暗符 },
                    PengList = new List<PengType>() {  }
                }
            },
            {
                HeroType.后羿, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.物理箭 },
                    PengList = new List<PengType>() { PengType.物理箭Peng }
                }
            },
        };

        public static Dictionary<ZhiYeType, float> 攻击范围Dic = new Dictionary<ZhiYeType, float>()
        {
            { ZhiYeType.战士, 7 },
            { ZhiYeType.法师, 10 },
            { ZhiYeType.辅助, 10 },
            { ZhiYeType.控制, 10 },
            { ZhiYeType.射手, 13 },

        };

        public static Dictionary<int, string> SuoTipDic = new Dictionary<int, string>()
        {
            { 2, "筑基解锁" },
            { 3, "金丹解锁" },
            { 4, "元婴解锁" },
            { 5, "化神解锁" },
        };

        public static Dictionary<int, HeroExp> HeroExpDic = new Dictionary<int, HeroExp>()
        {
            { 0, new HeroExp() { 元神 = 1, Exp = 10 } },
            { 1, new HeroExp() { 元神 = 1, Exp = 10 } },
            { 2, new HeroExp() { 元神 = 1, Exp = 15 } },
            { 3, new HeroExp() { 元神 = 1, Exp = 20 } },
            { 4, new HeroExp() { 元神 = 1, Exp = 25 } },

            { 5, new HeroExp() { 元神 = 2, Exp = 30 } },
            { 6, new HeroExp() { 元神 = 2, Exp = 35 } },
            { 7, new HeroExp() { 元神 = 2, Exp = 40 } },
            { 8, new HeroExp() { 元神 = 2, Exp = 45 } },
            { 9, new HeroExp() { 元神 = 2, Exp = 50 } },

            { 10, new HeroExp() { 元神 = 3, Exp = 60 } },
            { 11, new HeroExp() { 元神 = 3, Exp = 70 } },
            { 12, new HeroExp() { 元神 = 3, Exp = 80 } },
            { 13, new HeroExp() { 元神 = 3, Exp = 90 } },
            { 14, new HeroExp() { 元神 = 3, Exp = 100 } },

            { 15, new HeroExp() { 元神 = 4, Exp = 120 } },
            { 16, new HeroExp() { 元神 = 4, Exp = 140 } },
            { 17, new HeroExp() { 元神 = 4, Exp = 160 } },
            { 18, new HeroExp() { 元神 = 4, Exp = 180 } },
            { 19, new HeroExp() { 元神 = 4, Exp = 200 } },

            { 20, new HeroExp() { 元神 = 5, Exp = 220 } },
            { 21, new HeroExp() { 元神 = 5, Exp = 240 } },
            { 22, new HeroExp() { 元神 = 5, Exp = 260 } },
            { 23, new HeroExp() { 元神 = 5, Exp = 280 } },
            { 24, new HeroExp() { 元神 = 5, Exp = 300 } },

            { 25, new HeroExp() { 元神 = 6, Exp = 350 } },
            { 26, new HeroExp() { 元神 = 6, Exp = 400 } },
            { 27, new HeroExp() { 元神 = 6, Exp = 450 } },
            { 28, new HeroExp() { 元神 = 6, Exp = 500 } },
            { 29, new HeroExp() { 元神 = 6, Exp = 500 } },
        };

        public static Dictionary<HeroType, string> HeroNameDic = new Dictionary<HeroType, string>()
        {
            { HeroType.丹童, "丹童" },
            { HeroType.土地, "土地" },
            { HeroType.河伯, "河伯" },
            { HeroType.瑶池仙女, "瑶池仙女" },
            { HeroType.石敢当, "石敢当" },
            { HeroType.玄女, "玄女" },
            { HeroType.龟丞相, "龟丞相" },
            { HeroType.太白金星, "太白金星" },
            { HeroType.多闻天王, "多闻天王" },
            { HeroType.广目天王, "广目天王" },
            { HeroType.雷震子, "雷震子" },
            { HeroType.月老, "月老" },
            { HeroType.嫦娥, "嫦娥" },
            { HeroType.杨戬, "杨戬" },
            { HeroType.妲己, "妲己" },
            { HeroType.牛魔王, "牛魔王" },
            { HeroType.哪吒, "哪吒" },
            { HeroType.孙悟空, "孙悟空" },
            { HeroType.碧霄, "碧霄" },
            { HeroType.琼霄, "琼霄" },
            { HeroType.羲和, "羲和" },
            { HeroType.常羲, "常羲" },
            { HeroType.后羿, "后羿" },
            { HeroType.云霄, "云霄" },
            { HeroType.女娲, "女娲" },
            { HeroType.老子, "老子" },
            { HeroType.通天, "通天" },
            { HeroType.元始, "元始" },
            { HeroType.盘古, "盘古" },
            { HeroType.鸿钧, "鸿钧" },
        };

        public static Dictionary<HeroType, float> HeroAttackTimeDic = new Dictionary<HeroType, float>()
        {
            { HeroType.丹童, 1f },
            { HeroType.土地, 1 },
            { HeroType.河伯, 2 },
            { HeroType.瑶池仙女, 5 },
            { HeroType.石敢当, 1 },
            { HeroType.玄女, 1 },
            { HeroType.龟丞相, 1 },
            { HeroType.太白金星, 1 },
            { HeroType.多闻天王, 1 },
            { HeroType.广目天王, 1 },
            { HeroType.雷震子, 1 },
            { HeroType.月老, 1 },
            { HeroType.嫦娥, 1 },
            { HeroType.杨戬, 1 },
            { HeroType.妲己, 1 },
            { HeroType.牛魔王, 1 },
            { HeroType.哪吒, 1 },
            { HeroType.孙悟空, 3 },
            { HeroType.碧霄, 1 },
            { HeroType.琼霄, 1 },
            { HeroType.羲和, 1 },
            { HeroType.常羲, 1 },
            { HeroType.后羿, 1 },
            { HeroType.云霄, 1 },
            { HeroType.女娲, 1 },
            { HeroType.老子, 1 },
            { HeroType.通天, 1 },
            { HeroType.元始, 1 },
            { HeroType.盘古, 1 },
            { HeroType.鸿钧, 1 },

        };

        public static Dictionary<HeroType, PropType> HeroToPropDic = new Dictionary<HeroType, PropType>()
        {
            { HeroType.丹童, PropType.丹童元神 },
            { HeroType.土地, PropType.土地元神 },
            { HeroType.河伯, PropType.河伯元神 },
            { HeroType.瑶池仙女, PropType.瑶池仙女元神 },
            { HeroType.石敢当, PropType.石敢当元神 },
            { HeroType.玄女, PropType.玄女元神 },
            { HeroType.龟丞相, PropType.龟丞相元神 },
            { HeroType.太白金星, PropType.太白金星元神 },
            { HeroType.多闻天王, PropType.多闻天王元神 },
            { HeroType.广目天王, PropType.广目天王元神 },
            { HeroType.雷震子, PropType.雷震子元神 },
            { HeroType.月老, PropType.月老元神 },
            { HeroType.嫦娥, PropType.嫦娥元神 },
            { HeroType.杨戬, PropType.杨戬元神 },
            { HeroType.妲己, PropType.妲己元神 },
            { HeroType.牛魔王, PropType.牛魔王元神 },
            { HeroType.哪吒, PropType.哪吒元神 },
            { HeroType.孙悟空, PropType.孙悟空元神 },
            { HeroType.碧霄, PropType.碧霄元神 },
            { HeroType.琼霄, PropType.琼霄元神 },
            { HeroType.羲和, PropType.羲和元神 },
            { HeroType.常羲, PropType.常羲元神 },
            { HeroType.后羿, PropType.后羿元神 },
            { HeroType.云霄, PropType.云霄元神 },
            { HeroType.女娲, PropType.女娲元神 },
            { HeroType.老子, PropType.老子元神 },
            { HeroType.通天, PropType.通天元神 },
            { HeroType.元始, PropType.元始元神 },
            { HeroType.盘古, PropType.盘古元神 },
            { HeroType.鸿钧, PropType.鸿钧元神 },

        };

        public static Dictionary<HeroType, HeroZhiYeYuanSu> HeroZhiYeDic = new Dictionary<HeroType, HeroZhiYeYuanSu>()
        {
            { HeroType.丹童, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.射手, yuanSuType = YuanSuType.火 } },
            { HeroType.土地, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.控制, yuanSuType = YuanSuType.黑暗 } }, // 大地之力
            { HeroType.河伯, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.法师, yuanSuType = YuanSuType.冰 } }, // 水神
            { HeroType.瑶池仙女, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.辅助, yuanSuType = YuanSuType.冰 } }, // 瑶池之水

            { HeroType.石敢当, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.战士, yuanSuType = YuanSuType.物理 } },
            { HeroType.玄女, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.法师, yuanSuType = YuanSuType.电 } }, // 九天玄女，火
            { HeroType.龟丞相, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.控制, yuanSuType = YuanSuType.冰 } }, // 水族
            { HeroType.太白金星, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.射手, yuanSuType = YuanSuType.电 } }, // 金星属金

            { HeroType.多闻天王, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.射手, yuanSuType = YuanSuType.黑暗 } }, // 北方属水
            { HeroType.广目天王, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.战士, yuanSuType = YuanSuType.黑暗 } }, // 西方属风，归为电
            { HeroType.雷震子, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.法师, yuanSuType = YuanSuType.电 } }, // 雷
            { HeroType.月老, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.射手, yuanSuType = YuanSuType.火 } }, // 姻缘火

            { HeroType.嫦娥, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.法师, yuanSuType = YuanSuType.电 } }, // 月宫寒
            { HeroType.杨戬, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.射手, yuanSuType = YuanSuType.电 } }, // 武力
            { HeroType.妲己, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.辅助, yuanSuType = YuanSuType.黑暗 } }, // 狐妖
            { HeroType.牛魔王, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.战士, yuanSuType = YuanSuType.物理 } }, // 力量

            { HeroType.哪吒, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.战士, yuanSuType = YuanSuType.火 } }, // 风火轮
            { HeroType.孙悟空, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.战士, yuanSuType = YuanSuType.物理 } }, // 金箍棒
            { HeroType.碧霄, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.法师, yuanSuType = YuanSuType.冰 } }, // 三霄属水
            { HeroType.琼霄, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.控制, yuanSuType = YuanSuType.黑暗 } },

            { HeroType.后羿, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.射手, yuanSuType = YuanSuType.物理 } }, // 射日
            { HeroType.常羲, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.控制, yuanSuType = YuanSuType.冰 } }, // 月母
            { HeroType.羲和, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.辅助, yuanSuType = YuanSuType.火 } }, // 日母
            { HeroType.云霄, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.法师, yuanSuType = YuanSuType.冰 } }, // 三霄

            { HeroType.女娲, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.辅助, yuanSuType = YuanSuType.火 } }, // 炼石补天
            { HeroType.老子, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.法师, yuanSuType = YuanSuType.火 } }, // 炼丹
            { HeroType.元始, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.射手, yuanSuType = YuanSuType.黑暗 }}, // 盘古元神，力量
            { HeroType.通天, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.战士, yuanSuType = YuanSuType.黑暗 } }, 

            { HeroType.鸿钧, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.法师, yuanSuType = YuanSuType.电 } }, // 天道雷霆
            { HeroType.盘古, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.战士, yuanSuType = YuanSuType.物理 } } // 开天辟地，纯粹力量
        };

        public static Dictionary<QualityType, HashSet<HeroType>> QualityHeroDic =
            new Dictionary<QualityType, HashSet<HeroType>>()
            {
                {
                    QualityType.黄品,
                    new HashSet<HeroType>()
                        { HeroType.丹童, HeroType.土地, HeroType.河伯, HeroType.瑶池仙女 }
                },
                {
                    QualityType.玄品,
                    new HashSet<HeroType>()
                        { HeroType.石敢当, HeroType.玄女, HeroType.龟丞相, HeroType.太白金星 }
                },
                {
                    QualityType.地品,
                    new HashSet<HeroType>()
                        { HeroType.多闻天王, HeroType.广目天王, HeroType.雷震子, HeroType.月老 }
                },
                {
                    QualityType.天品,
                    new HashSet<HeroType>() { HeroType.嫦娥, HeroType.杨戬, HeroType.妲己, HeroType.牛魔王 }
                },
                {
                    QualityType.宇品,
                    new HashSet<HeroType>() { HeroType.哪吒, HeroType.孙悟空, HeroType.碧霄, HeroType.琼霄 }
                },
                {
                    QualityType.宙品,
                    new HashSet<HeroType>() { HeroType.羲和, HeroType.常羲, HeroType.后羿, HeroType.云霄 }
                },
                { QualityType.洪品, new HashSet<HeroType>() { HeroType.女娲, HeroType.老子, HeroType.通天, HeroType.元始 } },
                { QualityType.荒品, new HashSet<HeroType>() { HeroType.盘古, HeroType.鸿钧 } },
            };

        public static Dictionary<HeroType, string> HeroDescDic = new Dictionary<HeroType, string>()
        {
            // 白色（黄品）
            { HeroType.丹童, "太上老君座下丹童，掌炉火，识百草之性。" },
            { HeroType.土地, "一方社稷之灵，位卑而乐善，知地脉走向。" },
            { HeroType.河伯, "黄河水伯，冯夷得道，性温而司水。" },
            { HeroType.瑶池仙女, "昆仑瑶池之侍女，善歌舞，以仙乐娱宾。" },

            // 绿色（玄品）
            { HeroType.石敢当, "泰山灵石所化，刚直不阿，专克邪祟。" },
            { HeroType.玄女, "九天玄女之门徒，通符箓，善兵法战阵。" },
            { HeroType.龟丞相, "东海龙宫之老臣，万年灵龟，稳重多智。" },
            { HeroType.太白金星, "长庚星君，天庭重臣，性慈而善调解。" },

            // 蓝色（地品）
            { HeroType.多闻天王, "四大天王之一，持混元伞，镇守北洲。" },
            { HeroType.广目天王, "四大天王之一，缠赤龙，慧眼观三界。" },
            { HeroType.雷震子, "云中子之徒，食杏实生翼，性烈忠义。" },
            { HeroType.月老, "司姻缘之神，隐于月宫，喜牵红线。" },

            // 紫色（天品）
            { HeroType.嫦娥, "后羿之妻，服不死药，独居广寒。" },
            { HeroType.杨戬, "玉帝外甥，玉鼎真人徒，开天眼，心傲。" },
            { HeroType.妲己, "冀州苏护之女，狐妖附体，绝世妖妃。" },
            { HeroType.牛魔王, "积雷山平天大圣，力大无穷，惧内。" },

            // 橙色（宇品）
            { HeroType.哪吒, "陈塘关李靖之子，太乙之徒，叛逆重义。" },
            { HeroType.孙悟空, "花果山灵石所化，菩提之徒，齐天大圣。" },
            { HeroType.碧霄, "截教门人，赵公明之妹，性烈，姊妹情深。" },
            { HeroType.琼霄, "截教门人，与碧霄同修，善使金蛟剪。" },

            // 粉色（宙品）
            { HeroType.羲和, "帝俊之妻，太阳女神，驭日车巡天。" },
            { HeroType.常羲, "帝俊之妻，月亮女神，主十二月之阴晴。" },
            { HeroType.后羿, "尧时射日英雄，力能挽弓，思妻郁郁。" },
            { HeroType.云霄, "三霄之首，摆黄河阵，心善而护短。" },

            // 红色（洪品）
            { HeroType.女娲, "抟土造人，炼石补天，万物之母，圣德无疆。" },
            { HeroType.老子, "太上老君，三清之首，人教教主，无为而化。" },
            { HeroType.通天, "通天教主，截教教主，有教无类，率性而为。" },
            { HeroType.元始, "元始天尊，阐教教主，盘古元神，万法之源。" },
            // 彩色（荒品）
            { HeroType.盘古, "开天辟地，身化万物，创世元灵，功盖寰宇。" },
            { HeroType.鸿钧, "鸿钧道祖，天道化身，传道三清，万法归宗。" }

        };

        public static Dictionary<HeroType, QualityType> HeroQualityDic = new Dictionary<HeroType, QualityType>()
        {
            { HeroType.None, QualityType.None },

            // 白色 -> 黄
            { HeroType.丹童, QualityType.黄品 },
            { HeroType.土地, QualityType.黄品 },
            { HeroType.河伯, QualityType.黄品 },
            { HeroType.瑶池仙女, QualityType.黄品 },

            // 绿色 -> 玄
            { HeroType.石敢当, QualityType.玄品 },
            { HeroType.玄女, QualityType.玄品 },
            { HeroType.龟丞相, QualityType.玄品 },
            { HeroType.太白金星, QualityType.玄品 },

            // 蓝色 -> 地
            { HeroType.多闻天王, QualityType.地品 },
            { HeroType.广目天王, QualityType.地品 },
            { HeroType.雷震子, QualityType.地品 },
            { HeroType.月老, QualityType.地品 },

            // 紫色 -> 天
            { HeroType.嫦娥, QualityType.天品 },
            { HeroType.杨戬, QualityType.天品 },
            { HeroType.妲己, QualityType.天品 },
            { HeroType.牛魔王, QualityType.天品 },

            // 橙色 -> 宇
            { HeroType.哪吒, QualityType.宇品 },
            { HeroType.孙悟空, QualityType.宇品 },
            { HeroType.碧霄, QualityType.宇品 },
            { HeroType.琼霄, QualityType.宇品 },

            // 粉色 -> 宙
            { HeroType.羲和, QualityType.宙品 },
            { HeroType.常羲, QualityType.宙品 },
            { HeroType.后羿, QualityType.宙品 },
            { HeroType.云霄, QualityType.宙品 },

            // 红色 -> 洪
            { HeroType.女娲, QualityType.洪品 },
            { HeroType.老子, QualityType.洪品 },
            { HeroType.通天, QualityType.洪品 },
            { HeroType.元始, QualityType.洪品 },
            // 彩色 -> 荒
            { HeroType.盘古, QualityType.荒品 },
            { HeroType.鸿钧, QualityType.荒品 },

        };
    }
}