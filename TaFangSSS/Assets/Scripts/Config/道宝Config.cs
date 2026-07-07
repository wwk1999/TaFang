using System.Collections.Generic;
using Config;

public enum 道宝Quality
{
    None,
    混沌至宝,
    功德至宝,
    先天至宝,
    先天灵宝,
    后天法宝,
}

public enum 道宝Type
{
    None,
    山河社稷图,
    七宝妙树,
    天书,
    地书,
    弑神枪,
    冥书,
    定海神珠,
    河图洛书,
    
    翻天印,
    紫金葫芦,
    金蛟剪,
    斩仙飞刀,
    五色神光,
    宝莲灯,
    落宝金钱,
    先天五方旗,
    
    混沌青莲,
    造化玉碟,
    混沌珠,
    开天斧,
    
    盘古幡,
    混沌钟,
    诛仙剑,
    戮仙剑,
    陷仙剑,
    绝仙剑,
    乾坤鼎,
    菩提妙树,
    
    玲珑塔,
    炼妖壶,
    女娲石,
    轩辕剑,
    玉净瓶,
    照妖镜,
    风火轮,
    如意金箍棒,
}
public class 道宝Config
{
    public static Dictionary<道宝Quality, string> 道宝QualityNameDic = new Dictionary<道宝Quality, string>()
    {
        { 道宝Quality.混沌至宝 ,"混沌至宝"},
        { 道宝Quality.先天至宝 ,"先天至宝"},
        { 道宝Quality.功德至宝 ,"功德至宝"},
        { 道宝Quality.先天灵宝 ,"先天灵宝"},
        { 道宝Quality.后天法宝 ,"后天法宝"},
    };
    public static Dictionary<道宝Quality, QualityType> 道宝QualityToQuality = new Dictionary<道宝Quality, QualityType>()
    {
        { 道宝Quality.混沌至宝 ,QualityType.荒品},
        { 道宝Quality.先天至宝 ,QualityType.洪品},
        { 道宝Quality.功德至宝 ,QualityType.宙品},
        { 道宝Quality.先天灵宝 ,QualityType.宇品},
        { 道宝Quality.后天法宝 ,QualityType.天品},
    };

    public static Dictionary<道宝Type, string> 道宝NameDic = new Dictionary<道宝Type, string>()
    {
        // ==================== 混沌至宝（4个）====================
        { 道宝Type.混沌青莲, "混沌青莲" },
        { 道宝Type.造化玉碟, "造化玉碟" },
        { 道宝Type.混沌珠, "混沌珠" },
        { 道宝Type.开天斧, "开天斧" },

        // ==================== 先天至宝（6个）====================
        { 道宝Type.盘古幡, "盘古幡" },
        { 道宝Type.混沌钟, "混沌钟" },
        { 道宝Type.诛仙剑, "诛仙剑" },
        { 道宝Type.戮仙剑, "戮仙剑" },
        { 道宝Type.陷仙剑, "陷仙剑" },
        { 道宝Type.绝仙剑, "绝仙剑" },

        // ==================== 功德至宝（8个）====================
        { 道宝Type.玲珑塔, "玲珑塔" },
        { 道宝Type.轩辕剑, "轩辕剑" },
        { 道宝Type.女娲石, "女娲石" },
        { 道宝Type.炼妖壶, "炼妖壶" },
        { 道宝Type.玉净瓶, "玉净瓶" },
        { 道宝Type.乾坤鼎, "乾坤鼎" },
        { 道宝Type.菩提妙树, "菩提妙树" },
        { 道宝Type.风火轮, "风火轮" },

        // ==================== 先天灵宝（8个）====================
        { 道宝Type.山河社稷图, "山河社稷图" },
        { 道宝Type.七宝妙树, "七宝妙树" },
        { 道宝Type.天书, "天书" },
        { 道宝Type.地书, "地书" },
        { 道宝Type.冥书, "冥书" },
        { 道宝Type.弑神枪, "弑神枪" },
        { 道宝Type.定海神珠, "定海神珠" },
        { 道宝Type.河图洛书, "河图洛书" },

        // ==================== 后天法宝（10个）====================
        { 道宝Type.翻天印, "翻天印" },
        { 道宝Type.紫金葫芦, "紫金葫芦" },
        { 道宝Type.金蛟剪, "金蛟剪" },
        { 道宝Type.斩仙飞刀, "斩仙飞刀" },
        { 道宝Type.五色神光, "五色神光" },
        { 道宝Type.宝莲灯, "宝莲灯" },
        { 道宝Type.落宝金钱, "落宝金钱" },
        { 道宝Type.先天五方旗, "先天五方旗" },
        { 道宝Type.照妖镜, "照妖镜" },
        { 道宝Type.如意金箍棒, "如意金箍棒" },
    };
    public static Dictionary<道宝Quality, List<道宝Type>> 道宝品质列表 = new Dictionary<道宝Quality, List<道宝Type>>()
    {
        // ==================== 混沌至宝（4个）====================
        {
            道宝Quality.混沌至宝, new List<道宝Type>()
            {
                道宝Type.混沌青莲,
                道宝Type.造化玉碟,
                道宝Type.混沌珠,
                道宝Type.开天斧,
            }
        },

        // ==================== 先天至宝（6个）====================
        {
            道宝Quality.先天至宝, new List<道宝Type>()
            {
                道宝Type.盘古幡,
                道宝Type.混沌钟,
                道宝Type.诛仙剑,
                道宝Type.戮仙剑,
                道宝Type.陷仙剑,
                道宝Type.绝仙剑,
            }
        },

        // ==================== 功德至宝（8个）====================
        {
            道宝Quality.功德至宝, new List<道宝Type>()
            {
                道宝Type.玲珑塔,
                道宝Type.轩辕剑,
                道宝Type.女娲石,
                道宝Type.炼妖壶,
                道宝Type.玉净瓶,
                道宝Type.乾坤鼎,
                道宝Type.菩提妙树,
                道宝Type.风火轮,
            }
        },

        // ==================== 先天灵宝（8个）====================
        {
            道宝Quality.先天灵宝, new List<道宝Type>()
            {
                道宝Type.山河社稷图,
                道宝Type.七宝妙树,
                道宝Type.天书,
                道宝Type.地书,
                道宝Type.冥书,
                道宝Type.弑神枪,
                道宝Type.定海神珠,
                道宝Type.河图洛书,
            }
        },

        // ==================== 后天法宝（10个）====================
        {
            道宝Quality.后天法宝, new List<道宝Type>()
            {
                道宝Type.翻天印,
                道宝Type.紫金葫芦,
                道宝Type.金蛟剪,
                道宝Type.斩仙飞刀,
                道宝Type.五色神光,
                道宝Type.宝莲灯,
                道宝Type.落宝金钱,
                道宝Type.先天五方旗,
                道宝Type.照妖镜,
                道宝Type.如意金箍棒,
            }
        },
    };
    public static Dictionary<道宝Type, 道宝Quality> 道宝品质Dic = new Dictionary<道宝Type, 道宝Quality>()
    {
        // ==================== 混沌至宝（4个）====================
        { 道宝Type.混沌青莲, 道宝Quality.混沌至宝 },
        { 道宝Type.造化玉碟, 道宝Quality.混沌至宝 },
        { 道宝Type.混沌珠,   道宝Quality.混沌至宝 },
        { 道宝Type.开天斧,   道宝Quality.混沌至宝 },

        // ==================== 先天至宝（6个）====================
        { 道宝Type.盘古幡,   道宝Quality.先天至宝 },
        { 道宝Type.混沌钟,   道宝Quality.先天至宝 },
        { 道宝Type.诛仙剑,   道宝Quality.先天至宝 },
        { 道宝Type.戮仙剑,   道宝Quality.先天至宝 },
        { 道宝Type.陷仙剑,   道宝Quality.先天至宝 },
        { 道宝Type.绝仙剑,   道宝Quality.先天至宝 },

        { 道宝Type.玲珑塔,   道宝Quality.功德至宝 },
        { 道宝Type.轩辕剑,   道宝Quality.功德至宝 },
        { 道宝Type.女娲石,   道宝Quality.功德至宝 },
        { 道宝Type.炼妖壶,   道宝Quality.功德至宝 },
        { 道宝Type.玉净瓶,   道宝Quality.功德至宝 },
        { 道宝Type.乾坤鼎,   道宝Quality.功德至宝 },   // 补天功德，归入功德至宝
        { 道宝Type.菩提妙树, 道宝Quality.功德至宝 },   // 准提证道，有功德加持
        { 道宝Type.风火轮,   道宝Quality.功德至宝 },   // 哪吒功绩所化

        { 道宝Type.山河社稷图, 道宝Quality.先天灵宝 },
        { 道宝Type.七宝妙树,   道宝Quality.先天灵宝 },
        { 道宝Type.天书,       道宝Quality.先天灵宝 },
        { 道宝Type.地书,       道宝Quality.先天灵宝 },
        { 道宝Type.冥书,       道宝Quality.先天灵宝 },
        { 道宝Type.弑神枪,     道宝Quality.先天灵宝 },
        { 道宝Type.定海神珠,   道宝Quality.先天灵宝 },
        { 道宝Type.河图洛书,   道宝Quality.先天灵宝 },

        { 道宝Type.翻天印,     道宝Quality.后天法宝 },
        { 道宝Type.紫金葫芦,   道宝Quality.后天法宝 },
        { 道宝Type.金蛟剪,     道宝Quality.后天法宝 },
        { 道宝Type.斩仙飞刀,   道宝Quality.后天法宝 },
        { 道宝Type.五色神光,   道宝Quality.后天法宝 },
        { 道宝Type.宝莲灯,     道宝Quality.后天法宝 },
        { 道宝Type.落宝金钱,   道宝Quality.后天法宝 },
        { 道宝Type.先天五方旗, 道宝Quality.后天法宝 },
        { 道宝Type.照妖镜,     道宝Quality.后天法宝 },
        { 道宝Type.如意金箍棒, 道宝Quality.后天法宝 },
    };
}
