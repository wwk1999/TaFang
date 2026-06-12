using System.Collections.Generic;

namespace Config
{
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
    public class HeroConfig
    {
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
        public static Dictionary<HeroType, PropType> HeroYuanShenDic = new Dictionary<HeroType, PropType>()
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

        public static Dictionary<QualityType, HashSet<HeroType>> QualityHeroDic =
            new Dictionary<QualityType, HashSet<HeroType>>()
            {
                { QualityType.黄, new HashSet<HeroType>() { HeroType.丹童, HeroType.青童, HeroType.土地, HeroType.河伯, HeroType.瑶池仙女, HeroType.精卫 } },
                { QualityType.玄, new HashSet<HeroType>() { HeroType.石敢当, HeroType.玄女, HeroType.龟丞相, HeroType.太白金星, HeroType.孟婆, HeroType.白素贞 } },
                { QualityType.地, new HashSet<HeroType>() { HeroType.多闻天王, HeroType.增长天王, HeroType.广目天王, HeroType.持国天王, HeroType.雷震子, HeroType.月老 } },
                { QualityType.天, new HashSet<HeroType>() { HeroType.嫦娥, HeroType.何仙姑, HeroType.杨戬, HeroType.妲己, HeroType.牛魔王 } },
                { QualityType.宇, new HashSet<HeroType>() { HeroType.哪吒, HeroType.孙悟空, HeroType.刑天, HeroType.碧霄, HeroType.琼霄 } },
                { QualityType.宙, new HashSet<HeroType>() { HeroType.金灵圣母, HeroType.羲和, HeroType.常羲, HeroType.后羿, HeroType.云霄 } },
                { QualityType.洪, new HashSet<HeroType>() { HeroType.女娲, HeroType.接引, HeroType.准提 } },
                { QualityType.荒, new HashSet<HeroType>() { HeroType.老子, HeroType.通天, HeroType.元始 } },
            };
        public static Dictionary<HeroType, QualityType> HeroQualityDic = new Dictionary<HeroType, QualityType>()
        {
            { HeroType.None, QualityType.None },

            // 白色 -> 黄
            { HeroType.丹童, QualityType.黄 },
            { HeroType.青童, QualityType.黄 },
            { HeroType.土地, QualityType.黄 },
            { HeroType.河伯, QualityType.黄 },
            { HeroType.瑶池仙女, QualityType.黄 },
            { HeroType.精卫, QualityType.黄 },

            // 绿色 -> 玄
            { HeroType.石敢当, QualityType.玄 },
            { HeroType.玄女, QualityType.玄 },
            { HeroType.龟丞相, QualityType.玄 },
            { HeroType.太白金星, QualityType.玄 },
            { HeroType.孟婆, QualityType.玄 },
            { HeroType.白素贞, QualityType.玄 },

            // 蓝色 -> 地
            { HeroType.多闻天王, QualityType.地 },
            { HeroType.增长天王, QualityType.地 },
            { HeroType.广目天王, QualityType.地 },
            { HeroType.持国天王, QualityType.地 },
            { HeroType.雷震子, QualityType.地 },
            { HeroType.月老, QualityType.地 },

            // 紫色 -> 天
            { HeroType.嫦娥, QualityType.天 },
            { HeroType.何仙姑, QualityType.天 },
            { HeroType.杨戬, QualityType.天 },
            { HeroType.妲己, QualityType.天 },
            { HeroType.牛魔王, QualityType.天 },

            // 橙色 -> 宇
            { HeroType.哪吒, QualityType.宇 },
            { HeroType.孙悟空, QualityType.宇 },
            { HeroType.刑天, QualityType.宇 },
            { HeroType.碧霄, QualityType.宇 },
            { HeroType.琼霄, QualityType.宇 },

            // 粉色 -> 宙
            { HeroType.金灵圣母, QualityType.宙 },
            { HeroType.羲和, QualityType.宙 },
            { HeroType.常羲, QualityType.宙 },
            { HeroType.后羿, QualityType.宙 },
            { HeroType.云霄, QualityType.宙 },

            // 红色 -> 洪
            { HeroType.女娲, QualityType.洪 },
            { HeroType.接引, QualityType.洪 },
            { HeroType.准提, QualityType.洪 },

            // 彩色 -> 荒
            { HeroType.老子, QualityType.荒 },
            { HeroType.通天, QualityType.荒 },
            { HeroType.元始, QualityType.荒 }
        };
    }
}