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
        
        法则橙,
        法则粉,
        法则红,
        法则彩,
        
        城墙紫,
        城墙橙,
        城墙粉,
        城墙红,
        城墙彩,
        
        灵药白,
        灵药绿,
        灵药蓝,
        灵药紫,
        灵药橙,
        灵药粉,
        灵药红,
        灵药彩,
        
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
        功法经验,
        法器粉尘,
        仙石精华,
        
        矿石,
        玄铁,
        玉髓,
        
        石1, 石2, 石3, 石4, 石5, 石6, 石7, 石8, 石9, 石10, 石11, 石12, 石13, 石14, 石15, 石16,
        铁1, 铁2, 铁3, 铁4, 铁5, 铁6, 铁7, 铁8, 铁9, 铁10, 铁11, 铁12, 铁13, 铁14, 铁15, 铁16,
        羽1, 羽2, 羽3, 羽4, 羽5, 羽6, 羽7, 羽8, 羽9, 羽10, 羽11, 羽12, 羽13, 羽14, 羽15, 羽16,
        砂1, 砂2, 砂3, 砂4, 砂5, 砂6, 砂7, 砂8, 砂9, 砂10, 砂11, 砂12, 砂13, 砂14, 砂15, 砂16,
        
        轮回石,
        血晶,
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
        功法经验,
        
        法器粉尘,
        仙石精华,
        
        矿石,
        玄铁,
        玉髓,
        
        石1, 石2, 石3, 石4, 石5, 石6, 石7, 石8, 石9, 石10, 石11, 石12, 石13, 石14, 石15, 石16,
        铁1, 铁2, 铁3, 铁4, 铁5, 铁6, 铁7, 铁8, 铁9, 铁10, 铁11, 铁12, 铁13, 铁14, 铁15, 铁16,
        羽1, 羽2, 羽3, 羽4, 羽5, 羽6, 羽7, 羽8, 羽9, 羽10, 羽11, 羽12, 羽13, 羽14, 羽15, 羽16,
        砂1, 砂2, 砂3, 砂4, 砂5, 砂6, 砂7, 砂8, 砂9, 砂10, 砂11, 砂12, 砂13, 砂14, 砂15, 砂16,
        
        轮回石,
        血晶,
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
        public static 法器材料Type GetProp法器材料Type(PropType Type)
        {
            string name = Type.ToString();
            if (name.StartsWith("石")) return 法器材料Type.石;
            if (name.StartsWith("铁")) return 法器材料Type.铁;
            if (name.StartsWith("羽")) return 法器材料Type.羽;
            if (name.StartsWith("砂")) return 法器材料Type.砂;
            return 法器材料Type.None;
        }
        public static bool Prop是否为法器材料(PropType propType)
        {
            string name = propType.ToString();
            return name.StartsWith("石") || name.StartsWith("铁") || name.StartsWith("羽") || name.StartsWith("砂");
        }

        /// <summary>
        /// 从PropType名字解析阶数（如"石16" → 16）
        /// </summary>
        public static int GetProp阶数(PropType propType)
        {
            string name = propType.ToString();
            for (int i = name.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(name[i])) continue;
                if (i == name.Length - 1) return 0;
                return int.Parse(name.Substring(i + 1));
            }
            return 0;
        }

        /// <summary>
        /// 从道具信息Type名字解析阶数
        /// </summary>
        public static int Get道具信息阶数(道具信息Type type)
        {
            string name = type.ToString();
            for (int i = name.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(name[i])) continue;
                if (i == name.Length - 1) return 0;
                return int.Parse(name.Substring(i + 1));
            }
            return 0;
        }
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
        case 道具信息Type.功法经验:
            return ResourcesConfig.功法经验;
        case 道具信息Type.仙石精华:
            return ResourcesConfig.仙石精华;
        case 道具信息Type.法器粉尘:
            return ResourcesConfig.法器粉尘;
        case 道具信息Type.矿石:
            return ResourcesConfig.矿石;
        case 道具信息Type.玄铁:
            return ResourcesConfig.玄铁;
        case 道具信息Type.玉髓:
            return ResourcesConfig.玉髓;
        case 道具信息Type.石1:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 1);
        case 道具信息Type.石2:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 2);
        case 道具信息Type.石3:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 3);
        case 道具信息Type.石4:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 4);
        case 道具信息Type.石5:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 5);
        case 道具信息Type.石6:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 6);
        case 道具信息Type.石7:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 7);
        case 道具信息Type.石8:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 8);
        case 道具信息Type.石9:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 9);
        case 道具信息Type.石10:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 10);
        case 道具信息Type.石11:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 11);
        case 道具信息Type.石12:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 12);
        case 道具信息Type.石13:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 13);
        case 道具信息Type.石14:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 14);
        case 道具信息Type.石15:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 15);
        case 道具信息Type.石16:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 16);

        case 道具信息Type.铁1:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 1);
        case 道具信息Type.铁2:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 2);
        case 道具信息Type.铁3:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 3);
        case 道具信息Type.铁4:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 4);
        case 道具信息Type.铁5:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 5);
        case 道具信息Type.铁6:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 6);
        case 道具信息Type.铁7:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 7);
        case 道具信息Type.铁8:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 8);
        case 道具信息Type.铁9:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 9);
        case 道具信息Type.铁10:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 10);
        case 道具信息Type.铁11:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 11);
        case 道具信息Type.铁12:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 12);
        case 道具信息Type.铁13:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 13);
        case 道具信息Type.铁14:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 14);
        case 道具信息Type.铁15:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 15);
        case 道具信息Type.铁16:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 16);

        case 道具信息Type.羽1:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 1);
        case 道具信息Type.羽2:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 2);
        case 道具信息Type.羽3:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 3);
        case 道具信息Type.羽4:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 4);
        case 道具信息Type.羽5:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 5);
        case 道具信息Type.羽6:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 6);
        case 道具信息Type.羽7:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 7);
        case 道具信息Type.羽8:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 8);
        case 道具信息Type.羽9:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 9);
        case 道具信息Type.羽10:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 10);
        case 道具信息Type.羽11:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 11);
        case 道具信息Type.羽12:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 12);
        case 道具信息Type.羽13:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 13);
        case 道具信息Type.羽14:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 14);
        case 道具信息Type.羽15:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 15);
        case 道具信息Type.羽16:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 16);

        case 道具信息Type.砂1:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 1);
        case 道具信息Type.砂2:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 2);
        case 道具信息Type.砂3:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 3);
        case 道具信息Type.砂4:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 4);
        case 道具信息Type.砂5:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 5);
        case 道具信息Type.砂6:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 6);
        case 道具信息Type.砂7:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 7);
        case 道具信息Type.砂8:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 8);
        case 道具信息Type.砂9:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 9);
        case 道具信息Type.砂10:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 10);
        case 道具信息Type.砂11:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 11);
        case 道具信息Type.砂12:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 12);
        case 道具信息Type.砂13:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 13);
        case 道具信息Type.砂14:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 14);
        case 道具信息Type.砂15:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 15);
        case 道具信息Type.砂16:
            return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 16);

        case 道具信息Type.轮回石:
            return ResourcesConfig.轮回石;
        case 道具信息Type.血晶:
            return ResourcesConfig.血晶;
        case 道具信息Type.道宝紫:
        case 道具信息Type.道宝橙:
        case 道具信息Type.道宝粉:
        case 道具信息Type.道宝红:
        case 道具信息Type.道宝彩:
        case 道具信息Type.灵药白:
        case 道具信息Type.灵药绿:
        case 道具信息Type.灵药蓝:
        case 道具信息Type.灵药紫:
        case 道具信息Type.灵药橙:
        case 道具信息Type.灵药粉:
        case 道具信息Type.灵药红:
        case 道具信息Type.灵药彩:
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
            return ResourcesConfig.问号;
    }
}
        public static Dictionary<道具信息Type, QualityType> 道具信息品质Dic = new Dictionary<道具信息Type, QualityType>()
        {
            { 道具信息Type.功法经验, QualityType.地品 },
            { 道具信息Type.法器粉尘, QualityType.地品 },
            { 道具信息Type.仙石精华, QualityType.地品 },
            { 道具信息Type.矿石, QualityType.地品 },
            { 道具信息Type.玄铁, QualityType.地品 },
            { 道具信息Type.玉髓, QualityType.地品 },
            // 法器材料不再按品质分，而是按阶数分，品质Dic中不再包含材料项
            // 道具信息Type.石1~石16、铁1~铁16、羽1~羽16、砂1~砂16 均不在此字典中
            { 道具信息Type.轮回石, QualityType.地品 },
            { 道具信息Type.血晶, QualityType.地品 },
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
            { 道具信息Type.灵药白, QualityType.黄品 },
            { 道具信息Type.灵药绿, QualityType.玄品 },
            { 道具信息Type.灵药蓝, QualityType.地品 },
            { 道具信息Type.灵药紫,QualityType.天品 },
            { 道具信息Type.灵药橙, QualityType.宇品 },
            { 道具信息Type.灵药粉, QualityType.宙品 },
            { 道具信息Type.灵药红, QualityType.洪品 },
            { 道具信息Type.灵药彩, QualityType.荒品 },

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
            { 道具信息Type.None, PropType.None },

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
            { 道具信息Type.功法经验, PropType.功法经验 },
            { 道具信息Type.法器粉尘, PropType.法器粉尘 },
            { 道具信息Type.仙石精华, PropType.仙石精华 },
            { 道具信息Type.矿石, PropType.矿石 },
            { 道具信息Type.玄铁, PropType.玄铁 },
            { 道具信息Type.玉髓, PropType.玉髓 },
            
            // 法器材料 (石/铁/羽/砂 × 阶数1~16)，共64条
            { 道具信息Type.石1, PropType.石1 },
            { 道具信息Type.石2, PropType.石2 },
            { 道具信息Type.石3, PropType.石3 },
            { 道具信息Type.石4, PropType.石4 },
            { 道具信息Type.石5, PropType.石5 },
            { 道具信息Type.石6, PropType.石6 },
            { 道具信息Type.石7, PropType.石7 },
            { 道具信息Type.石8, PropType.石8 },
            { 道具信息Type.石9, PropType.石9 },
            { 道具信息Type.石10, PropType.石10 },
            { 道具信息Type.石11, PropType.石11 },
            { 道具信息Type.石12, PropType.石12 },
            { 道具信息Type.石13, PropType.石13 },
            { 道具信息Type.石14, PropType.石14 },
            { 道具信息Type.石15, PropType.石15 },
            { 道具信息Type.石16, PropType.石16 },
            { 道具信息Type.铁1, PropType.铁1 },
            { 道具信息Type.铁2, PropType.铁2 },
            { 道具信息Type.铁3, PropType.铁3 },
            { 道具信息Type.铁4, PropType.铁4 },
            { 道具信息Type.铁5, PropType.铁5 },
            { 道具信息Type.铁6, PropType.铁6 },
            { 道具信息Type.铁7, PropType.铁7 },
            { 道具信息Type.铁8, PropType.铁8 },
            { 道具信息Type.铁9, PropType.铁9 },
            { 道具信息Type.铁10, PropType.铁10 },
            { 道具信息Type.铁11, PropType.铁11 },
            { 道具信息Type.铁12, PropType.铁12 },
            { 道具信息Type.铁13, PropType.铁13 },
            { 道具信息Type.铁14, PropType.铁14 },
            { 道具信息Type.铁15, PropType.铁15 },
            { 道具信息Type.铁16, PropType.铁16 },
            { 道具信息Type.羽1, PropType.羽1 },
            { 道具信息Type.羽2, PropType.羽2 },
            { 道具信息Type.羽3, PropType.羽3 },
            { 道具信息Type.羽4, PropType.羽4 },
            { 道具信息Type.羽5, PropType.羽5 },
            { 道具信息Type.羽6, PropType.羽6 },
            { 道具信息Type.羽7, PropType.羽7 },
            { 道具信息Type.羽8, PropType.羽8 },
            { 道具信息Type.羽9, PropType.羽9 },
            { 道具信息Type.羽10, PropType.羽10 },
            { 道具信息Type.羽11, PropType.羽11 },
            { 道具信息Type.羽12, PropType.羽12 },
            { 道具信息Type.羽13, PropType.羽13 },
            { 道具信息Type.羽14, PropType.羽14 },
            { 道具信息Type.羽15, PropType.羽15 },
            { 道具信息Type.羽16, PropType.羽16 },
            { 道具信息Type.砂1, PropType.砂1 },
            { 道具信息Type.砂2, PropType.砂2 },
            { 道具信息Type.砂3, PropType.砂3 },
            { 道具信息Type.砂4, PropType.砂4 },
            { 道具信息Type.砂5, PropType.砂5 },
            { 道具信息Type.砂6, PropType.砂6 },
            { 道具信息Type.砂7, PropType.砂7 },
            { 道具信息Type.砂8, PropType.砂8 },
            { 道具信息Type.砂9, PropType.砂9 },
            { 道具信息Type.砂10, PropType.砂10 },
            { 道具信息Type.砂11, PropType.砂11 },
            { 道具信息Type.砂12, PropType.砂12 },
            { 道具信息Type.砂13, PropType.砂13 },
            { 道具信息Type.砂14, PropType.砂14 },
            { 道具信息Type.砂15, PropType.砂15 },
            { 道具信息Type.砂16, PropType.砂16 },
            { 道具信息Type.轮回石, PropType.轮回石 },
            { 道具信息Type.血晶, PropType.血晶 },
        };
        
        public static Dictionary<PropType, 道具信息Type> PropTypeTo道具信息 = new Dictionary<PropType, 道具信息Type>()
        {
            { PropType.None, 道具信息Type.None },

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
            { PropType.功法经验, 道具信息Type.功法经验 },
            { PropType.法器粉尘, 道具信息Type.法器粉尘 },
            { PropType.仙石精华, 道具信息Type.仙石精华 },
            { PropType.矿石, 道具信息Type.矿石 },
            { PropType.玄铁, 道具信息Type.玄铁 },
            { PropType.玉髓, 道具信息Type.玉髓 },
            
            // 法器材料 (石/铁/羽/砂 × 阶数1~16)，共64条
            { PropType.石1, 道具信息Type.石1 },
            { PropType.石2, 道具信息Type.石2 },
            { PropType.石3, 道具信息Type.石3 },
            { PropType.石4, 道具信息Type.石4 },
            { PropType.石5, 道具信息Type.石5 },
            { PropType.石6, 道具信息Type.石6 },
            { PropType.石7, 道具信息Type.石7 },
            { PropType.石8, 道具信息Type.石8 },
            { PropType.石9, 道具信息Type.石9 },
            { PropType.石10, 道具信息Type.石10 },
            { PropType.石11, 道具信息Type.石11 },
            { PropType.石12, 道具信息Type.石12 },
            { PropType.石13, 道具信息Type.石13 },
            { PropType.石14, 道具信息Type.石14 },
            { PropType.石15, 道具信息Type.石15 },
            { PropType.石16, 道具信息Type.石16 },
            { PropType.铁1, 道具信息Type.铁1 },
            { PropType.铁2, 道具信息Type.铁2 },
            { PropType.铁3, 道具信息Type.铁3 },
            { PropType.铁4, 道具信息Type.铁4 },
            { PropType.铁5, 道具信息Type.铁5 },
            { PropType.铁6, 道具信息Type.铁6 },
            { PropType.铁7, 道具信息Type.铁7 },
            { PropType.铁8, 道具信息Type.铁8 },
            { PropType.铁9, 道具信息Type.铁9 },
            { PropType.铁10, 道具信息Type.铁10 },
            { PropType.铁11, 道具信息Type.铁11 },
            { PropType.铁12, 道具信息Type.铁12 },
            { PropType.铁13, 道具信息Type.铁13 },
            { PropType.铁14, 道具信息Type.铁14 },
            { PropType.铁15, 道具信息Type.铁15 },
            { PropType.铁16, 道具信息Type.铁16 },
            { PropType.羽1, 道具信息Type.羽1 },
            { PropType.羽2, 道具信息Type.羽2 },
            { PropType.羽3, 道具信息Type.羽3 },
            { PropType.羽4, 道具信息Type.羽4 },
            { PropType.羽5, 道具信息Type.羽5 },
            { PropType.羽6, 道具信息Type.羽6 },
            { PropType.羽7, 道具信息Type.羽7 },
            { PropType.羽8, 道具信息Type.羽8 },
            { PropType.羽9, 道具信息Type.羽9 },
            { PropType.羽10, 道具信息Type.羽10 },
            { PropType.羽11, 道具信息Type.羽11 },
            { PropType.羽12, 道具信息Type.羽12 },
            { PropType.羽13, 道具信息Type.羽13 },
            { PropType.羽14, 道具信息Type.羽14 },
            { PropType.羽15, 道具信息Type.羽15 },
            { PropType.羽16, 道具信息Type.羽16 },
            { PropType.砂1, 道具信息Type.砂1 },
            { PropType.砂2, 道具信息Type.砂2 },
            { PropType.砂3, 道具信息Type.砂3 },
            { PropType.砂4, 道具信息Type.砂4 },
            { PropType.砂5, 道具信息Type.砂5 },
            { PropType.砂6, 道具信息Type.砂6 },
            { PropType.砂7, 道具信息Type.砂7 },
            { PropType.砂8, 道具信息Type.砂8 },
            { PropType.砂9, 道具信息Type.砂9 },
            { PropType.砂10, 道具信息Type.砂10 },
            { PropType.砂11, 道具信息Type.砂11 },
            { PropType.砂12, 道具信息Type.砂12 },
            { PropType.砂13, 道具信息Type.砂13 },
            { PropType.砂14, 道具信息Type.砂14 },
            { PropType.砂15, 道具信息Type.砂15 },
            { PropType.砂16, 道具信息Type.砂16 },
            { PropType.轮回石, 道具信息Type.轮回石 },
            { PropType.血晶, 道具信息Type.血晶 },
        };

        public static Dictionary<道具信息Type, string> 道具信息NameDic = new Dictionary<道具信息Type, string>()
        {
            { 道具信息Type.None, "无" },
            { 道具信息Type.功法经验, "功法经验" },
            { 道具信息Type.仙石精华, "仙石精华" },
            { 道具信息Type.矿石, "矿石" },
            { 道具信息Type.玄铁, "玄铁" },
            { 道具信息Type.玉髓, "玉髓" },
            // 法器材料名字 (石1~石16, 铁1~铁16, 羽1~羽16, 砂1~砂16)
            // 通过 法器Config.Get法器材料Name(法器材料Type type, int 阶数) 动态获取，不再在此字典中硬编码
            { 道具信息Type.轮回石, "轮回石" },
            { 道具信息Type.血晶, "血晶" },
            { 道具信息Type.法器粉尘, "法器粉尘" },
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
            { 道具信息Type.灵药白, "黄品灵药" },
            { 道具信息Type.灵药绿, "玄品灵药" },
            { 道具信息Type.灵药蓝, "地品灵药" },
            { 道具信息Type.灵药紫, "天品灵药" },
            { 道具信息Type.灵药橙, "宇品灵药" },
            { 道具信息Type.灵药粉, "宙品灵药" },
            { 道具信息Type.灵药红, "洪品灵药" },
            { 道具信息Type.灵药彩, "荒品灵药" },

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
            { 道具信息Type.功德, "突破境界时不可或缺的核心材料,在领主府升级功德碑可以加速生成" },
            { 道具信息Type.头盔锻造石, "用于升级头盔装备的必备锻造材料,主线关卡掉落" },
            { 道具信息Type.射手经验值, "提升射手英雄星级等级的关键材料,主线关卡掉落" },
            { 道具信息Type.戒指锻造石, "用于升级戒指装备的必备锻造材料,主线关卡掉落" },
            { 道具信息Type.战士经验值, "提升战士英雄星级等级的关键材料,主线关卡掉落" },
            { 道具信息Type.护手锻造石, "用于升级护手装备的必备锻造材料,主线关卡掉落" },
            { 道具信息Type.招募卷, "用于招募普通英雄的必备消耗品,主线关卡掉落" },
            { 道具信息Type.控制经验值, "提升控制英雄星级等级的关键材料,主线关卡掉落" },
            { 道具信息Type.法师经验值, "提升法师英雄星级等级的关键材料,主线关卡掉落" },
            { 道具信息Type.洗练石, "用于洗练重置装备附加词条的核心材料,主线关卡掉落" },
            { 道具信息Type.灵魂, "洪荒世界中流通的通用货币" },
            { 道具信息Type.衣服锻造石, "用于升级衣服装备的必备锻造材料,主线关卡掉落" },
            { 道具信息Type.辅助经验值, "提升辅助英雄星级等级的关键材料,主线关卡掉落" },
            { 道具信息Type.鞋子锻造石, "用于升级鞋子装备的必备锻造材料,主线关卡掉落" },
            { 道具信息Type.项链锻造石, "用于升级项链装备的必备锻造材料,主线关卡掉落" },
            { 道具信息Type.高级招募卷, "用于招募高级稀有英雄的珍贵消耗品,所有关卡掉落,基础10%掉率" },
            { 道具信息Type.道宝紫, "随机获得一件天品品质的道宝,在道宝界面查看" },
            { 道具信息Type.道宝橙, "随机获得一件宇品品质的道宝,在道宝界面查看" },
            { 道具信息Type.道宝粉, "随机获得一件宙品品质的道宝,在道宝界面查看" },
            { 道具信息Type.道宝红, "随机获得一件洪品品质的道宝,在道宝界面查看" },
            { 道具信息Type.道宝彩, "随机获得一件荒品品质的道宝,在道宝界面查看" },
            { 道具信息Type.灵药白, "随机获得一件黄品品质的灵药,炼制丹药所需" },
            { 道具信息Type.灵药绿, "随机获得一件玄品品质的灵药,炼制丹药所需" },
            { 道具信息Type.灵药蓝, "随机获得一件地品品质的灵药,炼制丹药所需" },
            { 道具信息Type.灵药紫, "随机获得一件天品品质的灵药,炼制丹药所需" },
            { 道具信息Type.灵药橙, "随机获得一件宇品品质的灵药,炼制丹药所需" },
            { 道具信息Type.灵药粉, "随机获得一件宙品品质的灵药,炼制丹药所需" },
            { 道具信息Type.灵药红, "随机获得一件洪品品质的灵药,炼制丹药所需" },
            { 道具信息Type.灵药彩, "随机获得一件荒品品质的灵药,炼制丹药所需" },
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
            { 道具信息Type.功法经验, "提升英雄功法等级的关键材料" },
            { 道具信息Type.法器粉尘, "洗练法器词条的关键材料,分解法器获得" },
            { 道具信息Type.仙石精华, "重铸仙石的关键材料,分解仙石获得" },
            { 道具信息Type.矿石, "升级道场建筑的关键材料" },
            { 道具信息Type.玄铁, "升级道场建筑的关键材料" },
            { 道具信息Type.玉髓, "升级道场建筑的关键材料" },

            // 法器材料描述 (石1~石16, 铁1~铁16, 羽1~羽16, 砂1~砂16)
            // 通过 法器Config.Get法器材料Info() 动态获取，不再在此字典中硬编码

            { 道具信息Type.轮回石, "轮回转世的关键材料,主线,符文,神物关卡掉落,三十三重天50层掉落2,200层3,500层4,1000层5," },
            { 道具信息Type.血晶, "灵兽洗髓和进化的关键材料,分解灵兽获得" },
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
                case PropType.功法经验:
                    return ResourcesConfig.功法经验;
                case PropType.仙石精华:
                    return ResourcesConfig.仙石精华;
                case PropType.矿石:
                    return ResourcesConfig.矿石;
                case PropType.玄铁:
                    return ResourcesConfig.玄铁;
                case PropType.玉髓:
                    return ResourcesConfig.玉髓;
                
                case PropType.石1:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 1);
                case PropType.石2:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 2);
                case PropType.石3:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 3);
                case PropType.石4:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 4);
                case PropType.石5:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 5);
                case PropType.石6:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 6);
                case PropType.石7:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 7);
                case PropType.石8:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 8);
                case PropType.石9:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 9);
                case PropType.石10:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 10);
                case PropType.石11:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 11);
                case PropType.石12:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 12);
                case PropType.石13:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 13);
                case PropType.石14:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 14);
                case PropType.石15:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 15);
                case PropType.石16:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.石, 16);

                case PropType.铁1:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 1);
                case PropType.铁2:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 2);
                case PropType.铁3:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 3);
                case PropType.铁4:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 4);
                case PropType.铁5:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 5);
                case PropType.铁6:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 6);
                case PropType.铁7:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 7);
                case PropType.铁8:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 8);
                case PropType.铁9:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 9);
                case PropType.铁10:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 10);
                case PropType.铁11:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 11);
                case PropType.铁12:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 12);
                case PropType.铁13:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 13);
                case PropType.铁14:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 14);
                case PropType.铁15:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 15);
                case PropType.铁16:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.铁, 16);

                case PropType.羽1:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 1);
                case PropType.羽2:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 2);
                case PropType.羽3:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 3);
                case PropType.羽4:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 4);
                case PropType.羽5:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 5);
                case PropType.羽6:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 6);
                case PropType.羽7:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 7);
                case PropType.羽8:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 8);
                case PropType.羽9:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 9);
                case PropType.羽10:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 10);
                case PropType.羽11:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 11);
                case PropType.羽12:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 12);
                case PropType.羽13:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 13);
                case PropType.羽14:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 14);
                case PropType.羽15:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 15);
                case PropType.羽16:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.羽, 16);

                case PropType.砂1:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 1);
                case PropType.砂2:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 2);
                case PropType.砂3:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 3);
                case PropType.砂4:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 4);
                case PropType.砂5:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 5);
                case PropType.砂6:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 6);
                case PropType.砂7:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 7);
                case PropType.砂8:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 8);
                case PropType.砂9:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 9);
                case PropType.砂10:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 10);
                case PropType.砂11:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 11);
                case PropType.砂12:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 12);
                case PropType.砂13:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 13);
                case PropType.砂14:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 14);
                case PropType.砂15:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 15);
                case PropType.砂16:
                    return ResourcesConfig.Get法器材料Sprite(法器材料Type.砂, 16);

                case PropType.轮回石:
                    return ResourcesConfig.轮回石;
                case PropType.血晶:
                    return ResourcesConfig.血晶;
                case PropType.法器粉尘:
                    return ResourcesConfig.法器粉尘;
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
                    return ResourcesConfig.丹童平台;
               
                case PropType.土地元神:
                    return ResourcesConfig.土地平台;
                case PropType.河伯元神:
                    return ResourcesConfig.河伯平台;
                case PropType.瑶池仙女元神:
                    return ResourcesConfig.瑶池仙女平台;
              

                // 绿色品质元神 -> 对应人物 Sprite（绿）
                case PropType.石敢当元神:
                    return ResourcesConfig.石敢当平台;
                case PropType.玄女元神:
                    return ResourcesConfig.玄女平台;
                case PropType.龟丞相元神:
                    return ResourcesConfig.龟丞相平台;
                case PropType.太白金星元神:
                    return ResourcesConfig.太白金星平台;
              

                // 蓝色品质元神 -> 对应人物 Sprite（蓝）
                case PropType.多闻天王元神:
                    return ResourcesConfig.多闻天王平台;
               
                case PropType.广目天王元神:
                    return ResourcesConfig.广目天王平台;
               
                case PropType.雷震子元神:
                    return ResourcesConfig.雷震子平台;
                case PropType.月老元神:
                    return ResourcesConfig.月老平台;

                // 紫色品质元神 -> 对应人物 Sprite（紫）
                case PropType.嫦娥元神:
                    return ResourcesConfig.嫦娥平台;
               
                case PropType.杨戬元神:
                    return ResourcesConfig.杨戬平台;
                case PropType.妲己元神:
                    return ResourcesConfig.妲己平台;
                case PropType.牛魔王元神:
                    return ResourcesConfig.牛魔王平台;

                // 橙色品质元神 -> 对应人物 Sprite（橙）
                case PropType.哪吒元神:
                    return ResourcesConfig.哪吒平台;
                case PropType.孙悟空元神:
                    return ResourcesConfig.孙悟空平台;
                
                case PropType.碧霄元神:
                    return ResourcesConfig.碧霄平台;
                case PropType.琼霄元神:
                    return ResourcesConfig.琼霄平台;

                // 粉色品质元神 -> 对应人物 Sprite（粉）
               
                case PropType.羲和元神:
                    return ResourcesConfig.羲和平台;
                case PropType.常羲元神:
                    return ResourcesConfig.常羲平台;
                case PropType.后羿元神:
                    return ResourcesConfig.后羿平台;
                case PropType.云霄元神:
                    return ResourcesConfig.云霄平台;

                // 红色品质元神 -> 对应人物 Sprite（红）
                case PropType.女娲元神:
                    return ResourcesConfig.女娲平台;
                // 彩色品质元神 -> 对应人物 Sprite（彩）
                case PropType.老子元神:
                    return ResourcesConfig.老子平台;
                case PropType.通天元神:
                    return ResourcesConfig.通天平台;
                case PropType.元始元神:
                    return ResourcesConfig.元始平台;
                case PropType.鸿钧元神:
                    return ResourcesConfig.鸿钧平台;
                case PropType.盘古元神:
                    return ResourcesConfig.盘古平台;

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
            { PropType.功法经验, "功法经验" },
            { PropType.法器粉尘, "法器粉尘" },
            { PropType.仙石精华, "仙石精华" },
            { PropType.矿石, "矿石" },
            { PropType.玄铁, "玄铁" },
            { PropType.玉髓, "玉髓" },

            // 法器材料名字 (石1~石16, 铁1~铁16, 羽1~羽16, 砂1~砂16)
            // 通过 法器Config.Get法器材料Name(法器材料Type type, int 阶数) 动态获取，不再在此字典中硬编码

            { PropType.轮回石, "轮回石" },
            { PropType.血晶, "血晶" },
        };

        public static Dictionary<PropType, QualityType> PropQualityDic = new Dictionary<PropType, QualityType>()
        {
            { PropType.None, QualityType.None },
            { PropType.功法经验, QualityType.地品 },
            { PropType.仙石精华, QualityType.地品 },
            { PropType.矿石, QualityType.地品 },
            { PropType.玄铁, QualityType.地品 },
            { PropType.玉髓, QualityType.地品 },
            { PropType.轮回石, QualityType.地品 },
            { PropType.血晶, QualityType.地品 },

            // 法器材料品质 (石1~石16, 铁1~铁16, 羽1~羽16, 砂1~砂16)
            // 法器材料不再按品质分，而是按阶数分，PropQualityDic中不再包含材料项

            { PropType.法器粉尘, QualityType.地品 },
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