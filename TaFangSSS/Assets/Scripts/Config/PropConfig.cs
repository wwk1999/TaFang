using System.Collections.Generic;
using UnityEngine;

namespace Config
{
    public enum 道具信息Type
    {
        None,
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
        道宝紫,
        道宝橙,
        道宝粉,
        道宝红,
        道宝彩,
        
        道纹紫,
        道纹橙,
        道纹粉,
        道纹红,
        道纹彩,
        
        法则橙,
        法则粉,
        法则红,
        法则彩,
        
        城墙紫,
        城墙橙,
        城墙粉,
        城墙红,
        城墙彩,
        
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
    public enum PropType
    {
        None,
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
        public static Sprite Get道具信息Sprite(道具信息Type Type)
{
    switch (Type)
    {
        case 道具信息Type.功德:
            return ResourcesConfig.功德;
        case 道具信息Type.头盔锻造石:
            return ResourcesConfig.头盔锻造石;
        case 道具信息Type.射手经验值:
            return ResourcesConfig.射手经验值;
        case 道具信息Type.戒指锻造石:
            return ResourcesConfig.戒指锻造石;
        case 道具信息Type.战士经验值:
            return ResourcesConfig.战士经验值;
        case 道具信息Type.护手锻造石:
            return ResourcesConfig.护手锻造石;
        case 道具信息Type.招募卷:
            return ResourcesConfig.招募卷;
        case 道具信息Type.控制经验值:
            return ResourcesConfig.控制经验值;
        case 道具信息Type.法师经验值:
            return ResourcesConfig.法师经验值;
        case 道具信息Type.洗练石:
            return ResourcesConfig.洗练石;
        case 道具信息Type.灵魂:
            return ResourcesConfig.灵魂;
        case 道具信息Type.衣服锻造石:
            return ResourcesConfig.衣服锻造石;
        case 道具信息Type.辅助经验值:
            return ResourcesConfig.辅助经验值;
        case 道具信息Type.鞋子锻造石:
            return ResourcesConfig.鞋子锻造石;
        case 道具信息Type.项链锻造石:
            return ResourcesConfig.项链锻造石;
        case 道具信息Type.高级招募卷:
            return ResourcesConfig.高级招募卷;
        case 道具信息Type.道宝紫:
        case 道具信息Type.道宝橙:
        case 道具信息Type.道宝粉:
        case 道具信息Type.道宝红:
        case 道具信息Type.道宝彩:
        case 道具信息Type.道纹紫:
        case 道具信息Type.道纹橙:
        case 道具信息Type.道纹粉:
        case 道具信息Type.道纹红:
        case 道具信息Type.道纹彩:
        case 道具信息Type.法则橙:
        case 道具信息Type.法则粉:
        case 道具信息Type.法则红:
        case 道具信息Type.法则彩:
        case 道具信息Type.城墙紫:
        case 道具信息Type.城墙橙:
        case 道具信息Type.城墙粉:
        case 道具信息Type.城墙红:
        case 道具信息Type.城墙彩:
            return ResourcesConfig.问号;
        default:
            return null;
    }
}
        public static Dictionary<道具信息Type, QualityType> 道具信息品质Dic = new Dictionary<道具信息Type, QualityType>()
        {
            { 道具信息Type.功德, QualityType.宇品 },
            { 道具信息Type.头盔锻造石, QualityType.地品 },
            { 道具信息Type.射手经验值, QualityType.地品 },
            { 道具信息Type.戒指锻造石, QualityType.地品 },
            { 道具信息Type.战士经验值, QualityType.地品 },
            { 道具信息Type.护手锻造石, QualityType.地品 },
            { 道具信息Type.招募卷, QualityType.地品 },
            { 道具信息Type.控制经验值, QualityType.地品 },
            { 道具信息Type.法师经验值, QualityType.地品 },
            { 道具信息Type.洗练石, QualityType.宇品 },
            { 道具信息Type.灵魂, QualityType.地品 },
            { 道具信息Type.衣服锻造石, QualityType.地品 },
            { 道具信息Type.辅助经验值, QualityType.地品 },
            { 道具信息Type.鞋子锻造石, QualityType.地品 },
            { 道具信息Type.项链锻造石, QualityType.地品 },
            { 道具信息Type.高级招募卷, QualityType.宇品 },
            { 道具信息Type.道宝紫, QualityType.天品 },
            { 道具信息Type.道宝橙, QualityType.宇品 },
            { 道具信息Type.道宝粉, QualityType.宙品 },
            { 道具信息Type.道宝红, QualityType.洪品 },
            { 道具信息Type.道宝彩, QualityType.荒品 },
            { 道具信息Type.道纹紫, QualityType.天品 },
            { 道具信息Type.道纹橙, QualityType.宇品 },
            { 道具信息Type.道纹粉, QualityType.宙品 },
            { 道具信息Type.道纹红,QualityType.洪品 },
            { 道具信息Type.道纹彩, QualityType.荒品 },
            { 道具信息Type.法则橙, QualityType.宇品},
            { 道具信息Type.法则粉, QualityType.宙品 },
            { 道具信息Type.法则红, QualityType.洪品 },
            { 道具信息Type.法则彩, QualityType.荒品 },
            { 道具信息Type.城墙紫, QualityType.天品 },
            { 道具信息Type.城墙橙, QualityType.宇品 },
            { 道具信息Type.城墙粉, QualityType.宙品 },
            { 道具信息Type.城墙红, QualityType.洪品 },
            { 道具信息Type.城墙彩, QualityType.荒品 },
        };
        
        public static Dictionary<道具信息Type, PropType> 道具信息ToPropType = new Dictionary<道具信息Type, PropType>()
        {
            { 道具信息Type.功德, PropType.功德 },
            { 道具信息Type.头盔锻造石, PropType.头盔锻造石 },
            { 道具信息Type.射手经验值, PropType.射手经验值 },
            { 道具信息Type.戒指锻造石, PropType.戒指锻造石 },
            { 道具信息Type.战士经验值, PropType.战士经验值 },
            { 道具信息Type.护手锻造石, PropType.护手锻造石 },
            { 道具信息Type.招募卷, PropType.招募卷 },
            { 道具信息Type.控制经验值, PropType.控制经验值 },
            { 道具信息Type.法师经验值, PropType.法师经验值 },
            { 道具信息Type.洗练石, PropType.洗练石 },
            { 道具信息Type.灵魂, PropType.灵魂 },
            { 道具信息Type.衣服锻造石, PropType.衣服锻造石 },
            { 道具信息Type.辅助经验值, PropType.辅助经验值 },
            { 道具信息Type.鞋子锻造石, PropType.鞋子锻造石 },
            { 道具信息Type.项链锻造石, PropType.项链锻造石 },
            { 道具信息Type.高级招募卷, PropType.高级招募卷 },
        };
        
        public static Dictionary<PropType, 道具信息Type> PropTypeTo道具信息 = new Dictionary<PropType, 道具信息Type>()
        {
            { PropType.功德, 道具信息Type.功德 },
            { PropType.头盔锻造石, 道具信息Type.头盔锻造石 },
            { PropType.射手经验值, 道具信息Type.射手经验值 },
            { PropType.戒指锻造石, 道具信息Type.戒指锻造石 },
            { PropType.战士经验值, 道具信息Type.战士经验值 },
            { PropType.护手锻造石, 道具信息Type.护手锻造石 },
            { PropType.招募卷, 道具信息Type.招募卷 },
            { PropType.控制经验值, 道具信息Type.控制经验值 },
            { PropType.法师经验值, 道具信息Type.法师经验值 },
            { PropType.洗练石, 道具信息Type.洗练石 },
            { PropType.灵魂, 道具信息Type.灵魂 },
            { PropType.衣服锻造石, 道具信息Type.衣服锻造石 },
            { PropType.辅助经验值, 道具信息Type.辅助经验值 },
            { PropType.鞋子锻造石, 道具信息Type.鞋子锻造石 },
            { PropType.项链锻造石, 道具信息Type.项链锻造石 },
            { PropType.高级招募卷, 道具信息Type.高级招募卷 },
            
            { PropType.力之法则, 道具信息Type.力之法则 },
            { PropType.禁之法则, 道具信息Type.禁之法则 },
            { PropType.鸿蒙法则, 道具信息Type.鸿蒙法则 },
            { PropType.冰之法则, 道具信息Type.冰之法则 },
            { PropType.剑之法则, 道具信息Type.剑之法则 },
            { PropType.原始法则, 道具信息Type.原始法则 },
            { PropType.斗之法则, 道具信息Type.斗之法则 },
            { PropType.日之法则, 道具信息Type.日之法则 },
            { PropType.月之法则, 道具信息Type.月之法则 },
            { PropType.火之法则, 道具信息Type.火之法则 },
            { PropType.箭之法则, 道具信息Type.箭之法则 },
            { PropType.诛仙法则, 道具信息Type.诛仙法则 },
            { PropType.造化法则, 道具信息Type.造化法则 },
            { PropType.道之法则, 道具信息Type.道之法则 },
        };

        public static Dictionary<道具信息Type, string> 道具信息NameDic = new Dictionary<道具信息Type, string>()
        {
            { 道具信息Type.None, "无" },
            { 道具信息Type.功德, "功德" },
            { 道具信息Type.头盔锻造石, "头盔锻造石" },
            { 道具信息Type.射手经验值, "射手经验值" },
            { 道具信息Type.戒指锻造石, "戒指锻造石" },
            { 道具信息Type.战士经验值, "战士经验值" },
            { 道具信息Type.护手锻造石, "护手锻造石" },
            { 道具信息Type.招募卷, "招募卷" },
            { 道具信息Type.控制经验值, "控制经验值" },
            { 道具信息Type.法师经验值, "法师经验值" },
            { 道具信息Type.洗练石, "洗练石" },
            { 道具信息Type.灵魂, "灵气" },
            { 道具信息Type.衣服锻造石, "衣服锻造石" },
            { 道具信息Type.辅助经验值, "辅助经验值" },
            { 道具信息Type.鞋子锻造石, "鞋子锻造石" },
            { 道具信息Type.项链锻造石, "项链锻造石" },
            { 道具信息Type.高级招募卷, "高级招募卷" },
            { 道具信息Type.道宝紫, "天品道宝" },
            { 道具信息Type.道宝橙, "宇品道宝" },
            { 道具信息Type.道宝粉, "宙品道宝" },
            { 道具信息Type.道宝红, "洪品道宝" },
            { 道具信息Type.道宝彩, "荒品道宝" },
            { 道具信息Type.道纹紫, "天品道纹" },
            { 道具信息Type.道纹橙, "宇品道纹" },
            { 道具信息Type.道纹粉, "宙品道纹" },
            { 道具信息Type.道纹红, "洪品道纹" },
            { 道具信息Type.道纹彩, "荒品道纹" },
            { 道具信息Type.法则橙, "宇品法则" },
            { 道具信息Type.法则粉, "宙品法则" },
            { 道具信息Type.法则红, "洪品法则" },
            { 道具信息Type.法则彩, "荒品法则" },
            { 道具信息Type.城墙紫, "天品城墙法宝" },
            { 道具信息Type.城墙橙, "宇品城墙法宝" },
            { 道具信息Type.城墙粉, "宙品城墙法宝" },
            { 道具信息Type.城墙红, "洪品城墙法宝" },
            { 道具信息Type.城墙彩, "荒品城墙法宝" },
        };
        
        public static Dictionary<道具信息Type, string> 道具信息InfoDic = new Dictionary<道具信息Type, string>()
        {
            { 道具信息Type.None, "无" },
            { 道具信息Type.功德, "突破境界时不可或缺的核心材料" },
            { 道具信息Type.头盔锻造石, "用于升级头盔装备的必备锻造材料" },
            { 道具信息Type.射手经验值, "提升射手英雄星级等级的关键材料" },
            { 道具信息Type.戒指锻造石, "用于升级戒指装备的必备锻造材料" },
            { 道具信息Type.战士经验值, "提升战士英雄星级等级的关键材料" },
            { 道具信息Type.护手锻造石, "用于升级护手装备的必备锻造材料" },
            { 道具信息Type.招募卷, "用于招募普通英雄的必备消耗品" },
            { 道具信息Type.控制经验值, "提升控制英雄星级等级的关键材料" },
            { 道具信息Type.法师经验值, "提升法师英雄星级等级的关键材料" },
            { 道具信息Type.洗练石, "用于洗练重置装备附加词条的核心材料" },
            { 道具信息Type.灵魂, "洪荒世界中流通的通用货币" },
            { 道具信息Type.衣服锻造石, "用于升级衣服装备的必备锻造材料" },
            { 道具信息Type.辅助经验值, "提升辅助英雄星级等级的关键材料" },
            { 道具信息Type.鞋子锻造石, "用于升级鞋子装备的必备锻造材料" },
            { 道具信息Type.项链锻造石, "用于升级项链装备的必备锻造材料" },
            { 道具信息Type.高级招募卷, "用于招募高级稀有英雄的珍贵消耗品" },
            { 道具信息Type.道宝紫, "随机获得一件天品品质的道宝" },
            { 道具信息Type.道宝橙, "随机获得一件宇品品质的道宝" },
            { 道具信息Type.道宝粉, "随机获得一件宙品品质的道宝" },
            { 道具信息Type.道宝红, "随机获得一件洪品品质的道宝" },
            { 道具信息Type.道宝彩, "随机获得一件荒品品质的道宝" },
            { 道具信息Type.道纹紫, "随机获得一件天品品质的道纹" },
            { 道具信息Type.道纹橙, "随机获得一件宇品品质的道纹" },
            { 道具信息Type.道纹粉, "随机获得一件宙品品质的道纹" },
            { 道具信息Type.道纹红, "随机获得一件洪品品质的道纹" },
            { 道具信息Type.道纹彩, "随机获得一件荒品品质的道纹" },
            { 道具信息Type.法则橙, "随机获得一件宇品品质的法则" },
            { 道具信息Type.法则粉, "随机获得一件宙品品质的法则" },
            { 道具信息Type.法则红, "随机获得一件洪品品质的法则" },
            { 道具信息Type.法则彩, "随机获得一件荒品品质的法则" },
            { 道具信息Type.城墙紫, "随机获得一件天品品质的城墙法宝" },
            { 道具信息Type.城墙橙, "随机获得一件宇品品质的城墙法宝" },
            { 道具信息Type.城墙粉, "随机获得一件宙品品质的城墙法宝" },
            { 道具信息Type.城墙红, "随机获得一件洪品品质的城墙法宝" },
            { 道具信息Type.城墙彩, "随机获得一件荒品品质的城墙法宝" },
            
            { 道具信息Type.力之法则, "提升盘古法则等级的关键材料" },
            { 道具信息Type.禁之法则, "提升琼霄法则等级的关键材料" },
            { 道具信息Type.鸿蒙法则, "提升鸿钧法则等级的关键材料" },
            { 道具信息Type.冰之法则, "提升碧霄法则等级的关键材料" },
            { 道具信息Type.剑之法则, "提升云霄法则等级的关键材料" },
            { 道具信息Type.原始法则, "提升原始法则等级的关键材料"},
            { 道具信息Type.日之法则, "提升羲和法则等级的关键材料" },
            { 道具信息Type.月之法则, "提升常羲法则等级的关键材料" },
            { 道具信息Type.火之法则, "提升哪吒法则等级的关键材料" },
            { 道具信息Type.箭之法则, "提升后羿法则等级的关键材料" },
            { 道具信息Type.道之法则, "提升老子法则等级的关键材料" },
            { 道具信息Type.斗之法则, "提升孙悟空法则等级的关键材料" },
            { 道具信息Type.诛仙法则, "提升通天法则等级的关键材料" },
            { 道具信息Type.造化法则, "提升女娲法则等级的关键材料" },

        };

        
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

            { PropType.鸿蒙法则, "鸿蒙法则" },
            { PropType.力之法则, "力之法则" },
            { PropType.冰之法则, "冰之法则" },
            { PropType.剑之法则, "剑之法则" },
            { PropType.原始法则, "原始法则" },
            { PropType.斗之法则, "斗之法则" },
            { PropType.日之法则, "日之法则" },
            { PropType.月之法则, "月之法则" },
            { PropType.火之法则, "火之法则" },
            { PropType.禁之法则, "禁之法则" },
            { PropType.箭之法则, "箭之法则" },
            { PropType.诛仙法则, "诛仙法则" },
            { PropType.造化法则, "造化法则" },
            { PropType.道之法则, "道之法则" },
        };

        public static Dictionary<PropType, QualityType> PropQualityDic = new Dictionary<PropType, QualityType>()
        {
            { PropType.None, QualityType.None },
            { PropType.洗练石, QualityType.宇品 },
            { PropType.全职业经验值, QualityType.天品 },
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