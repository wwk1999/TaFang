using System.Collections.Generic;
using UnityEngine;

namespace Config
{
    public enum PropType
    {
        None,
        破镜珠,
        全职业经验值,
        功德,
        头盔锻造石,
        射手经验值,
        戒指锻造石,
        战士经验值,
        护手锻造石,
        招募卷,
        控制经验值,
        法师经验值,
        洗练石,
        灵魂,
        衣服锻造石,
        辅助经验值,
        鞋子锻造石,
        项链锻造石,
        高级招募卷,

        //元神
        丹童元神,
        土地元神,
        河伯元神,
        瑶池仙女元神,
        
        石敢当元神,
        玄女元神,
        龟丞相元神,
        太白金星元神,
        
        多闻天王元神,
        广目天王元神,
        雷震子元神,
        月老元神,
        
        嫦娥元神,
        杨戬元神,
        妲己元神,
        牛魔王元神,
        
        哪吒元神,
        孙悟空元神,
        碧霄元神,
        琼霄元神,
        
        羲和元神,
        常羲元神,
        后羿元神,
        云霄元神,
        
        女娲元神,
        老子元神,
        通天元神,
        元始元神,
        
        盘古元神,
        鸿钧元神,
        
        
        //法则
        火之法则,
        斗之法则,
        冰之法则,
        禁之法则,
        剑之法则,
        日之法则,
        月之法则,
        箭之法则,
        造化法则,
        原始法则,
        诛仙法则,
        道之法则,
        鸿蒙法则,
        力之法则,
    }

    public enum QualityType
    {
        None,
        黄品,
        玄品,
        地品,
        天品,
        宇品,
        宙品,
        洪品,
        荒品,
    }

    public class PropConfig : MonoBehaviour
    {

        
        public static Dictionary<QualityType, string> QualityNameDic = new Dictionary<QualityType, string>()
        {
            { QualityType.黄品, "黄品" },
            { QualityType.玄品, "玄品" },
            { QualityType.地品, "地品" },
            { QualityType.天品, "天品" },
            { QualityType.宇品, "宇品" },
            { QualityType.宙品, "宙品" },
            { QualityType.洪品, "洪品" },
            { QualityType.荒品, "荒品" }
        };
        public static Sprite GetPropSprite(PropType propType)
        {
            switch (propType)
            {
                // 基础道具
                case PropType.全职业经验值:
                    return ResourcesConfig.全职业经验值;
                case PropType.功德:
                    return ResourcesConfig.功德;
                case PropType.头盔锻造石:
                    return ResourcesConfig.头盔锻造石;
                case PropType.射手经验值:
                    return ResourcesConfig.射手经验值;
                case PropType.戒指锻造石:
                    return ResourcesConfig.戒指锻造石;
                case PropType.战士经验值:
                    return ResourcesConfig.战士经验值;
                case PropType.护手锻造石:
                    return ResourcesConfig.护手锻造石;
                case PropType.招募卷:
                    return ResourcesConfig.招募卷;
                case PropType.控制经验值:
                    return ResourcesConfig.控制经验值;
                case PropType.法师经验值:
                    return ResourcesConfig.法师经验值;
                case PropType.洗练石:
                    return ResourcesConfig.洗练石;
                case PropType.灵魂:
                    return ResourcesConfig.灵魂;
                case PropType.衣服锻造石:
                    return ResourcesConfig.衣服锻造石;
                case PropType.辅助经验值:
                    return ResourcesConfig.辅助经验值;
                case PropType.鞋子锻造石:
                    return ResourcesConfig.鞋子锻造石;
                case PropType.项链锻造石:
                    return ResourcesConfig.项链锻造石;
                case PropType.高级招募卷:
                    return ResourcesConfig.高级招募卷;

                // 白色品质元神 -> 对应人物 Sprite（白）
                case PropType.丹童元神:
                    return ResourcesConfig.DanTong;
               
                case PropType.土地元神:
                    return ResourcesConfig.TuDi;
                case PropType.河伯元神:
                    return ResourcesConfig.HeBo;
                case PropType.瑶池仙女元神:
                    return ResourcesConfig.YaoChiXianNv;
              

                // 绿色品质元神 -> 对应人物 Sprite（绿）
                case PropType.石敢当元神:
                    return ResourcesConfig.ShiGanDang;
                case PropType.玄女元神:
                    return ResourcesConfig.XuanNv;
                case PropType.龟丞相元神:
                    return ResourcesConfig.GuiChengXiang;
                case PropType.太白金星元神:
                    return ResourcesConfig.TaiBaiJinXing;
              

                // 蓝色品质元神 -> 对应人物 Sprite（蓝）
                case PropType.多闻天王元神:
                    return ResourcesConfig.DuoWenTianWang;
               
                case PropType.广目天王元神:
                    return ResourcesConfig.GuangMuTianWang;
               
                case PropType.雷震子元神:
                    return ResourcesConfig.LeiZhengZi;
                case PropType.月老元神:
                    return ResourcesConfig.YueLao;

                // 紫色品质元神 -> 对应人物 Sprite（紫）
                case PropType.嫦娥元神:
                    return ResourcesConfig.ChangE;
               
                case PropType.杨戬元神:
                    return ResourcesConfig.YangJian;
                case PropType.妲己元神:
                    return ResourcesConfig.DanJi;
                case PropType.牛魔王元神:
                    return ResourcesConfig.NiuMoWang;

                // 橙色品质元神 -> 对应人物 Sprite（橙）
                case PropType.哪吒元神:
                    return ResourcesConfig.NeZha;
                case PropType.孙悟空元神:
                    return ResourcesConfig.SunWuKong;
                
                case PropType.碧霄元神:
                    return ResourcesConfig.BiXiao;
                case PropType.琼霄元神:
                    return ResourcesConfig.QiongXiao;

                // 粉色品质元神 -> 对应人物 Sprite（粉）
               
                case PropType.羲和元神:
                    return ResourcesConfig.XiHe;
                case PropType.常羲元神:
                    return ResourcesConfig.ChangXi;
                case PropType.后羿元神:
                    return ResourcesConfig.HouYi;
                case PropType.云霄元神:
                    return ResourcesConfig.YunXiao;

                // 红色品质元神 -> 对应人物 Sprite（红）
                case PropType.女娲元神:
                    return ResourcesConfig.NvWa;
                // 彩色品质元神 -> 对应人物 Sprite（彩）
                case PropType.老子元神:
                    return ResourcesConfig.LaoZi;
                case PropType.通天元神:
                    return ResourcesConfig.TongTian;
                case PropType.元始元神:
                    return ResourcesConfig.YuanShi;
                case PropType.鸿钧元神:
                    return ResourcesConfig.鸿钧;
                case PropType.盘古元神:
                    return ResourcesConfig.盘古;

                case PropType.None:
                default:
                    return null;
            }
        }

        public static Dictionary<PropType, HeroType> PropToHeroDic = new Dictionary<PropType, HeroType>()
        {
            { PropType.丹童元神, HeroType.丹童 },
            { PropType.土地元神, HeroType.土地 },
            { PropType.河伯元神, HeroType.河伯 },
            { PropType.瑶池仙女元神, HeroType.瑶池仙女 },
            { PropType.石敢当元神, HeroType.石敢当 },
            { PropType.玄女元神, HeroType.玄女 },
            { PropType.龟丞相元神, HeroType.龟丞相 },
            { PropType.太白金星元神, HeroType.太白金星 },
            { PropType.多闻天王元神, HeroType.多闻天王 },
            { PropType.广目天王元神, HeroType.广目天王 },
            { PropType.雷震子元神, HeroType.雷震子 },
            { PropType.月老元神, HeroType.月老 },
            { PropType.嫦娥元神, HeroType.嫦娥 },
            { PropType.杨戬元神, HeroType.杨戬 },
            { PropType.妲己元神, HeroType.妲己 },
            { PropType.牛魔王元神, HeroType.牛魔王 },
            { PropType.哪吒元神, HeroType.哪吒 },
            { PropType.孙悟空元神, HeroType.孙悟空 },
            { PropType.碧霄元神, HeroType.碧霄 },
            { PropType.琼霄元神, HeroType.琼霄 },
            { PropType.羲和元神, HeroType.羲和 },
            { PropType.常羲元神, HeroType.常羲 },
            { PropType.后羿元神, HeroType.后羿 },
            { PropType.云霄元神, HeroType.云霄 },
            { PropType.女娲元神, HeroType.女娲 },
            { PropType.老子元神, HeroType.老子 },
            { PropType.通天元神, HeroType.通天 },
            { PropType.元始元神, HeroType.元始 },
            { PropType.盘古元神, HeroType.盘古 },
            { PropType.鸿钧元神, HeroType.鸿钧 },

        };

        public static Dictionary<PropType, string> PropNameDic = new Dictionary<PropType, string>()
        {
            { PropType.None, "" },
            { PropType.破镜珠, "功德" },
            { PropType.全职业经验值, "全职业经验值" },
            { PropType.功德, "功德" },
            { PropType.头盔锻造石, "头盔锻造石" },
            { PropType.射手经验值, "射手经验值" },
            { PropType.戒指锻造石, "戒指锻造石" },
            { PropType.战士经验值, "战士经验值" },
            { PropType.护手锻造石, "护手锻造石" },
            { PropType.招募卷, "招募卷" },
            { PropType.控制经验值, "控制经验值" },
            { PropType.法师经验值, "法师经验值" },
            { PropType.洗练石, "洗练石" },
            { PropType.灵魂, "灵魂" },
            { PropType.衣服锻造石, "衣服锻造石" },
            { PropType.辅助经验值, "辅助经验值" },
            { PropType.鞋子锻造石, "鞋子锻造石" },
            { PropType.项链锻造石, "项链锻造石" },
            { PropType.高级招募卷, "高级招募卷" },
            { PropType.丹童元神, "丹童元神" },
            { PropType.土地元神, "土地元神" },
            { PropType.河伯元神, "河伯元神" },
            { PropType.瑶池仙女元神, "瑶池仙女元神" },
            { PropType.石敢当元神, "石敢当元神" },
            { PropType.玄女元神, "玄女元神" },
            { PropType.龟丞相元神, "龟丞相元神" }, // 注意枚举中为桂承相元神
            { PropType.太白金星元神, "太白金星元神" },
            { PropType.多闻天王元神, "多闻天王元神" },
            { PropType.广目天王元神, "广目天王元神" },
            { PropType.雷震子元神, "雷震子元神" },
            { PropType.月老元神, "月老元神" },
            { PropType.嫦娥元神, "嫦娥元神" },
            { PropType.杨戬元神, "杨戬元神" },
            { PropType.妲己元神, "妲己元神" },
            { PropType.牛魔王元神, "牛魔王元神" },
            { PropType.哪吒元神, "哪吒元神" },
            { PropType.孙悟空元神, "孙悟空元神" },
            { PropType.碧霄元神, "碧霄元神" },
            { PropType.琼霄元神, "琼霄元神" },
            { PropType.羲和元神, "羲和元神" },
            { PropType.常羲元神, "常羲元神" },
            { PropType.后羿元神, "后羿元神" },
            { PropType.云霄元神, "云霄元神" },
            { PropType.女娲元神, "女娲元神" },
            { PropType.老子元神, "老子元神" },
            { PropType.通天元神, "通天元神" },
            { PropType.元始元神, "元始元神" },
            { PropType.盘古元神, "盘古元神" },
            { PropType.鸿钧元神, "鸿钧元神" },

        };

        public static Dictionary<PropType, QualityType> PropQualityDic = new Dictionary<PropType, QualityType>()
        {
            { PropType.None, QualityType.None },
            { PropType.洗练石, QualityType.宇品 },
            { PropType.全职业经验值, QualityType.天品 },
            { PropType.破镜珠, QualityType.地品 },
            { PropType.射手经验值, QualityType.地品 },
            { PropType.战士经验值, QualityType.地品 },
            { PropType.辅助经验值, QualityType.地品 },
            { PropType.控制经验值, QualityType.地品 },
            { PropType.法师经验值, QualityType.地品 },
            { PropType.衣服锻造石, QualityType.地品 },
            { PropType.鞋子锻造石, QualityType.地品 },
            { PropType.头盔锻造石, QualityType.地品 },
            { PropType.护手锻造石, QualityType.地品 },
            { PropType.项链锻造石, QualityType.地品 },
            { PropType.戒指锻造石, QualityType.地品 },
            { PropType.招募卷, QualityType.地品 },
            { PropType.高级招募卷, QualityType.宇品 },
            { PropType.灵魂, QualityType.地品 },
            { PropType.功德, QualityType.宇品 },
            // 白色 -> 黄
            { PropType.丹童元神, QualityType.黄品 },
            { PropType.土地元神, QualityType.黄品 },
            { PropType.河伯元神, QualityType.黄品 },
            { PropType.瑶池仙女元神, QualityType.黄品 },

            // 绿色 -> 玄
            { PropType.石敢当元神, QualityType.玄品 },
            { PropType.玄女元神, QualityType.玄品 },
            { PropType.龟丞相元神, QualityType.玄品 },
            { PropType.太白金星元神, QualityType.玄品 },

            // 蓝色 -> 地
            { PropType.多闻天王元神, QualityType.地品 },
            { PropType.广目天王元神, QualityType.地品 },
            { PropType.雷震子元神, QualityType.地品 },
            { PropType.月老元神, QualityType.地品 },

            // 紫色 -> 天
            { PropType.嫦娥元神, QualityType.天品 },
            { PropType.杨戬元神, QualityType.天品 },
            { PropType.妲己元神, QualityType.天品 },
            { PropType.牛魔王元神, QualityType.天品 },

            // 橙色 -> 宇
            { PropType.哪吒元神, QualityType.宇品 },
            { PropType.孙悟空元神, QualityType.宇品 },
            { PropType.碧霄元神, QualityType.宇品 },
            { PropType.琼霄元神, QualityType.宇品 },

            // 粉色 -> 宙
            { PropType.羲和元神, QualityType.宙品 },
            { PropType.常羲元神, QualityType.宙品 },
            { PropType.后羿元神, QualityType.宙品 },
            { PropType.云霄元神, QualityType.宙品 },

            // 红色 -> 洪
            { PropType.女娲元神, QualityType.洪品 },
            { PropType.老子元神, QualityType.洪品 },
            { PropType.通天元神, QualityType.洪品 },
            { PropType.元始元神, QualityType.洪品 },
            // 彩色 -> 荒
            { PropType.鸿钧元神, QualityType.荒品 },
            { PropType.盘古元神, QualityType.荒品 },
            
            { PropType.火之法则, QualityType.宇品 },
            { PropType.斗之法则, QualityType.宇品 },
            { PropType.冰之法则, QualityType.宇品 },
            { PropType.禁之法则, QualityType.宇品 },
            
            { PropType.剑之法则, QualityType.宙品 },
            { PropType.日之法则, QualityType.宙品 },
            { PropType.月之法则, QualityType.宙品 },
            { PropType.箭之法则, QualityType.宙品 },
            
            { PropType.造化法则, QualityType.洪品 },
            { PropType.原始法则, QualityType.洪品 },
            { PropType.诛仙法则, QualityType.洪品 },
            { PropType.道之法则, QualityType.洪品 },
            
            { PropType.鸿蒙法则, QualityType.荒品 },
            { PropType.力之法则, QualityType.荒品 },
            
        };
    }
}