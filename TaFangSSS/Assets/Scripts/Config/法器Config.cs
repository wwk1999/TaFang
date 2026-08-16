using System;
using System.Collections.Generic;
using Config;
using Random = UnityEngine.Random;

public enum 法器Type
{
    None,

    // ============== 1. 战士 ==============
    战士武器白,
    战士武器绿,
    战士武器蓝,
    战士武器紫,
    战士武器橙,
    战士武器粉,
    战士武器红,
    战士武器彩,

    战士头盔白,
    战士头盔绿,
    战士头盔蓝,
    战士头盔紫,
    战士头盔橙,
    战士头盔粉,
    战士头盔红,
    战士头盔彩,

    战士衣服白,
    战士衣服绿,
    战士衣服蓝,
    战士衣服紫,
    战士衣服橙,
    战士衣服粉,
    战士衣服红,
    战士衣服彩,

    战士鞋子白,
    战士鞋子绿,
    战士鞋子蓝,
    战士鞋子紫,
    战士鞋子橙,
    战士鞋子粉,
    战士鞋子红,
    战士鞋子彩,

    // ============== 2. 控制 ==============
    控制武器白,
    控制武器绿,
    控制武器蓝,
    控制武器紫,
    控制武器橙,
    控制武器粉,
    控制武器红,
    控制武器彩,

    控制头盔白,
    控制头盔绿,
    控制头盔蓝,
    控制头盔紫,
    控制头盔橙,
    控制头盔粉,
    控制头盔红,
    控制头盔彩,

    控制衣服白,
    控制衣服绿,
    控制衣服蓝,
    控制衣服紫,
    控制衣服橙,
    控制衣服粉,
    控制衣服红,
    控制衣服彩,

    控制鞋子白,
    控制鞋子绿,
    控制鞋子蓝,
    控制鞋子紫,
    控制鞋子橙,
    控制鞋子粉,
    控制鞋子红,
    控制鞋子彩,

    // ============== 3. 辅助 ==============
    辅助武器白,
    辅助武器绿,
    辅助武器蓝,
    辅助武器紫,
    辅助武器橙,
    辅助武器粉,
    辅助武器红,
    辅助武器彩,

    辅助头盔白,
    辅助头盔绿,
    辅助头盔蓝,
    辅助头盔紫,
    辅助头盔橙,
    辅助头盔粉,
    辅助头盔红,
    辅助头盔彩,

    辅助衣服白,
    辅助衣服绿,
    辅助衣服蓝,
    辅助衣服紫,
    辅助衣服橙,
    辅助衣服粉,
    辅助衣服红,
    辅助衣服彩,

    辅助鞋子白,
    辅助鞋子绿,
    辅助鞋子蓝,
    辅助鞋子紫,
    辅助鞋子橙,
    辅助鞋子粉,
    辅助鞋子红,
    辅助鞋子彩,

    // ============== 4. 射手 ==============
    射手武器白,
    射手武器绿,
    射手武器蓝,
    射手武器紫,
    射手武器橙,
    射手武器粉,
    射手武器红,
    射手武器彩,

    射手头盔白,
    射手头盔绿,
    射手头盔蓝,
    射手头盔紫,
    射手头盔橙,
    射手头盔粉,
    射手头盔红,
    射手头盔彩,

    射手衣服白,
    射手衣服绿,
    射手衣服蓝,
    射手衣服紫,
    射手衣服橙,
    射手衣服粉,
    射手衣服红,
    射手衣服彩,

    射手鞋子白,
    射手鞋子绿,
    射手鞋子蓝,
    射手鞋子紫,
    射手鞋子橙,
    射手鞋子粉,
    射手鞋子红,
    射手鞋子彩,

    // ============== 5. 法师 ==============
    法师武器白,
    法师武器绿,
    法师武器蓝,
    法师武器紫,
    法师武器橙,
    法师武器粉,
    法师武器红,
    法师武器彩,

    法师头盔白,
    法师头盔绿,
    法师头盔蓝,
    法师头盔紫,
    法师头盔橙,
    法师头盔粉,
    法师头盔红,
    法师头盔彩,

    法师衣服白,
    法师衣服绿,
    法师衣服蓝,
    法师衣服紫,
    法师衣服橙,
    法师衣服粉,
    法师衣服红,
    法师衣服彩,

    法师鞋子白,
    法师鞋子绿,
    法师鞋子蓝,
    法师鞋子紫,
    法师鞋子橙,
    法师鞋子粉,
    法师鞋子红,
    法师鞋子彩,
}
public class 法器附加属性品质type
{
    public 法器附加属性Type 法器附加属性Type { get;set; }
    public QualityType QualityType { get; set; }
    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        法器附加属性品质type other = (法器附加属性品质type)obj;
        return 法器附加属性Type == other.法器附加属性Type && QualityType == other.QualityType;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + 法器附加属性Type.GetHashCode();
            hash = hash * 31 + QualityType.GetHashCode();
            return hash;
        }
    }
}
public enum 法器附加属性Type
{
    None,
    暴击率,
    暴击伤害,
    火焰伤害,
    雷电伤害,
    黑暗伤害,
    冰霜伤害,
    物理伤害,
    最终伤害,
    普通怪增伤,
    精英怪增伤,
    首领怪增伤,
    火焰穿透,
    雷电穿透,
    物理穿透,
    冰霜穿透,
    黑暗穿透,
    //宝石效果,
}

public class 法器附加属性值
{
    public 法器附加属性Type 法器附加属性Type;
    public float count;
}

public class 法器
{
    public 法器Type 法器Type;
    public List<法器附加属性值> list=new List<法器附加属性值>();
    public int 孔个数;
    //public list
}
public class 法器Config
{
    public static Dictionary<法器Type, string> 法器名Dic = new Dictionary<法器Type, string>()
    {
        // ==================================================================================
        // 【1. 战士】近战破甲 (图2重盔, 图5战甲, 图11巨剑, 图4战靴)
        // ==================================================================================
        { 法器Type.战士武器白, "百锻精铁剑" },
        { 法器Type.战士武器绿, "青木惊蛰刃" },
        { 法器Type.战士武器蓝, "寒渊玄铁戟" },
        { 法器Type.战士武器紫, "紫电裂空锤" },
        { 法器Type.战士武器橙, "金乌离火刀" },
        { 法器Type.战士武器粉, "飞花落影剑" },
        { 法器Type.战士武器红, "血煞修罗斩" },
        { 法器Type.战士武器彩, "混沌开天斧钺" },

        { 法器Type.战士头盔白, "玄钢铁面" },
        { 法器Type.战士头盔绿, "苍木灵角盔" },
        { 法器Type.战士头盔蓝, "北海冰翼盔" },
        { 法器Type.战士头盔紫, "紫曜魔龙盔" },
        { 法器Type.战士头盔橙, "炎狮赤金盔" },
        { 法器Type.战士头盔粉, "粉晶红鸾盔" },
        { 法器Type.战士头盔红, "血饮修罗盔" },
        { 法器Type.战士头盔彩, "混沌太初神盔" },

        { 法器Type.战士衣服白, "百炼铁鳞甲" },
        { 法器Type.战士衣服绿, "青灵木叶甲" },
        { 法器Type.战士衣服蓝, "极寒冰魄甲" },
        { 法器Type.战士衣服紫, "紫渊魔甲" },
        { 法器Type.战士衣服橙, "赤金狮王甲" },
        { 法器Type.战士衣服粉, "粉钻罗刹甲" },
        { 法器Type.战士衣服红, "煞神冥血甲" },
        { 法器Type.战士衣服彩, "混沌五行玄甲" },

        { 法器Type.战士鞋子白, "流风战靴" },
        { 法器Type.战士鞋子绿, "踏林莽靴" },
        { 法器Type.战士鞋子蓝, "沧溟飞鱼靴" },
        { 法器Type.战士鞋子紫, "暗影虚空靴" },
        { 法器Type.战士鞋子橙, "赤焰追风靴" },
        { 法器Type.战士鞋子粉, "落樱踏月靴" },
        { 法器Type.战士鞋子红, "修罗血蹄" },
        { 法器Type.战士鞋子彩, "踏破乾坤靴" },

        // ==================================================================================
        // 【2. 控制】诅咒/封印 (图10兜帽, 图9/13法袍, 图7法器, 图8布靴)
        // ==================================================================================
        { 法器Type.控制武器白, "定魂铜铃" },
        { 法器Type.控制武器绿, "幽水青莲蓬" },
        { 法器Type.控制武器蓝, "玄冰镇魔葫芦" },
        { 法器Type.控制武器紫, "紫曜照妖玄镜" },
        { 法器Type.控制武器橙, "大日焚天轮" },
        { 法器Type.控制武器粉, "红绡幻雨伞" },
        { 法器Type.控制武器红, "血契亡灵诏书" },
        { 法器Type.控制武器彩, "鸿蒙造化玉轮" },

        { 法器Type.控制头盔白, "凝霜兜帽" },
        { 法器Type.控制头盔绿, "林间隐者兜帽" },
        { 法器Type.控制头盔蓝, "怒潮幽魂兜帽" },
        { 法器Type.控制头盔紫, "噬魂幻影兜帽" },
        { 法器Type.控制头盔橙, "赤阳炎魔兜帽" },
        { 法器Type.控制头盔粉, "织梦仙子兜帽" },
        { 法器Type.控制头盔红, "血影修罗兜帽" },
        { 法器Type.控制头盔彩, "万象虚空兜帽" },

        { 法器Type.控制衣服白, "寒霜符文袍" },
        { 法器Type.控制衣服绿, "青木灵法袍" },
        { 法器Type.控制衣服蓝, "沧澜水法袍" },
        { 法器Type.控制衣服紫, "紫气东来袍" },
        { 法器Type.控制衣服橙, "大日烈阳袍" },
        { 法器Type.控制衣服粉, "粉荷幻影袍" },
        { 法器Type.控制衣服红, "修罗血煞袍" },
        { 法器Type.控制衣服彩, "混沌法则法袍" },

        { 法器Type.控制鞋子白, "踏云布靴" },
        { 法器Type.控制鞋子绿, "青蔓灵靴" },
        { 法器Type.控制鞋子蓝, "沧浪云靴" },
        { 法器Type.控制鞋子紫, "紫气玄光靴" },
        { 法器Type.控制鞋子橙, "耀日金乌靴" },
        { 法器Type.控制鞋子粉, "粉蝶飞花靴" },
        { 法器Type.控制鞋子红, "幽冥血影靴" },
        { 法器Type.控制鞋子彩, "大道无形靴" },

        // ==================================================================================
        // 【3. 辅助】治疗/护盾 (图7法器, 图1羽衣, 图17高靴, 图6法冠)
        // ==================================================================================
        { 法器Type.辅助武器白, "清心玉玲珑" },
        { 法器Type.辅助武器绿, "翠玉生机蓬" },
        { 法器Type.辅助武器蓝, "北海净水瓶" },
        { 法器Type.辅助武器紫, "紫霞灵犀镜" },
        { 法器Type.辅助武器橙, "轮回镇魂轮" },
        { 法器Type.辅助武器粉, "九曲罗伞" },
        { 法器Type.辅助武器红, "赦令万灵诏" },
        { 法器Type.辅助武器彩, "万法归一玄轮" },

        { 法器Type.辅助头盔白, "白羽流云冠" },
        { 法器Type.辅助头盔绿, "青木长生冠" },
        { 法器Type.辅助头盔蓝, "玄水寒星冠" },
        { 法器Type.辅助头盔紫, "紫极幽昙冠" },
        { 法器Type.辅助头盔橙, "大日真阳冠" },
        { 法器Type.辅助头盔粉, "落霞飞花冠" },
        { 法器Type.辅助头盔红, "业火涅槃冠" },
        { 法器Type.辅助头盔彩, "鸿蒙造物冠" },

        { 法器Type.辅助衣服白, "灵霜羽衣" },
        { 法器Type.辅助衣服绿, "翠羽霓裳" },
        { 法器Type.辅助衣服蓝, "冰魄仙衣" },
        { 法器Type.辅助衣服紫, "紫雷圣衣" },
        { 法器Type.辅助衣服橙, "金乌仙裳" },
        { 法器Type.辅助衣服粉, "落英桃花衣" },
        { 法器Type.辅助衣服红, "血凤天衣" },
        { 法器Type.辅助衣服彩, "五行混沌仙衣" },

        { 法器Type.辅助鞋子白, "白玉灵履" },
        { 法器Type.辅助鞋子绿, "青萝仙履" },
        { 法器Type.辅助鞋子蓝, "冰晶琉璃履" },
        { 法器Type.辅助鞋子紫, "紫魅幻光履" },
        { 法器Type.辅助鞋子橙, "金焰凤尾履" },
        { 法器Type.辅助鞋子粉, "粉蝶水晶履" },
        { 法器Type.辅助鞋子红, "血凤赤足履" },
        { 法器Type.辅助鞋子彩, "千幻太虚仙履" },

        // ==================================================================================
        // 【4. 射手】远程/敏捷 (图16弓箭, 图15翼盔, 图4/12轻靴)
        // ==================================================================================
        { 法器Type.射手武器白, "银丝风羽弓" },
        { 法器Type.射手武器绿, "青藤绞杀弓" },
        { 法器Type.射手武器蓝, "冰魄穿心弓" },
        { 法器Type.射手武器紫, "暗夜诛神弓" },
        { 法器Type.射手武器橙, "金乌射日弓" },
        { 法器Type.射手武器粉, "落樱幻影弓" },
        { 法器Type.射手武器红, "真龙噬魂弓" },
        { 法器Type.射手武器彩, "九曜神光弓" },

        { 法器Type.射手头盔白, "翎羽翼盔" },
        { 法器Type.射手头盔绿, "翠翼疾风盔" },
        { 法器Type.射手头盔蓝, "踏浪海灵盔" },
        { 法器Type.射手头盔紫, "幽冥暗夜盔" },
        { 法器Type.射手头盔橙, "烈日赤金盔" },
        { 法器Type.射手头盔粉, "飞花灵雀盔" },
        { 法器Type.射手头盔红, "炎龙赤霄盔" },
        { 法器Type.射手头盔彩, "宙极星辰盔" },

        { 法器Type.射手衣服白, "轻羽皮甲" },
        { 法器Type.射手衣服绿, "翠林软甲" },
        { 法器Type.射手衣服蓝, "冰鳞内甲" },
        { 法器Type.射手衣服紫, "暗影迷踪甲" },
        { 法器Type.射手衣服橙, "烈阳炎甲" },
        { 法器Type.射手衣服粉, "桃心彩甲" },
        { 法器Type.射手衣服红, "赤血龙鳞甲" },
        { 法器Type.射手衣服彩, "星罗万象甲" },

        { 法器Type.射手鞋子白, "风羽轻靴" },
        { 法器Type.射手鞋子绿, "踏草飞靴" },
        { 法器Type.射手鞋子蓝, "踏浪无痕靴" },
        { 法器Type.射手鞋子紫, "追夜疾风靴" },
        { 法器Type.射手鞋子橙, "炽火流星靴" },
        { 法器Type.射手鞋子粉, "飞花逐月靴" },
        { 法器Type.射手鞋子红, "赤血追魂靴" },
        { 法器Type.射手鞋子彩, "踏星追光靴" },

        // ==================================================================================
        // 【5. 法师】法系爆发 (图3法杖, 图6法冠, 图13法袍, 图8/17法靴)
        // ==================================================================================
        { 法器Type.法师武器白, "流云陨铁杖" },
        { 法器Type.法师武器绿, "青木灵蕴杖" },
        { 法器Type.法师武器蓝, "冰魄玄晶杖" },
        { 法器Type.法师武器紫, "紫曜虚空杖" },
        { 法器Type.法师武器橙, "南明离火杖" },
        { 法器Type.法师武器粉, "粉玉怜花杖" },
        { 法器Type.法师武器红, "血饮修罗杖" },
        { 法器Type.法师武器彩, "混沌五行珠杖" },

        { 法器Type.法师头盔白, "白雾冠" },
        { 法器Type.法师头盔绿, "木叶冠" },
        { 法器Type.法师头盔蓝, "冰雪寒冠" },
        { 法器Type.法师头盔紫, "紫雾幻灵冠" },
        { 法器Type.法师头盔橙, "金乌烈焰冠" },
        { 法器Type.法师头盔粉, "霞绡桃花冠" },
        { 法器Type.法师头盔红, "业火涅槃冠" },
        { 法器Type.法师头盔彩, "星河曜日冠" },

        { 法器Type.法师衣服白, "清虚道袍" },
        { 法器Type.法师衣服绿, "碧波灵袍" },
        { 法器Type.法师衣服蓝, "沧澜水袖" },
        { 法器Type.法师衣服紫, "玄冥幽光袍" },
        { 法器Type.法师衣服橙, "离火绛仙袍" },
        { 法器Type.法师衣服粉, "桃夭霓裳" },
        { 法器Type.法师衣服红, "修罗血袍" },
        { 法器Type.法师衣服彩, "太极八卦混元袍" },

        { 法器Type.法师鞋子白, "素云法靴" },
        { 法器Type.法师鞋子绿, "青蔓法靴" },
        { 法器Type.法师鞋子蓝, "沧澜灵靴" },
        { 法器Type.法师鞋子紫, "紫玄法靴" },
        { 法器Type.法师鞋子橙, "赤阳踏火靴" },
        { 法器Type.法师鞋子粉, "粉荷踏波靴" },
        { 法器Type.法师鞋子红, "血煞冥靴" },
        { 法器Type.法师鞋子彩, "混沌神行靴" },
    };
    
    public static Dictionary<QualityType, List<法器Type>> 法器品质列表Dic = new Dictionary<QualityType, List<法器Type>>()
{
    // ==================== 1. 黄品 (对应原先的 白色) ====================
    {
        QualityType.黄品, new List<法器Type>()
        {
            法器Type.战士武器白, 法器Type.战士头盔白, 法器Type.战士衣服白, 法器Type.战士鞋子白,
            法器Type.控制武器白, 法器Type.控制头盔白, 法器Type.控制衣服白, 法器Type.控制鞋子白,
            法器Type.辅助武器白, 法器Type.辅助头盔白, 法器Type.辅助衣服白, 法器Type.辅助鞋子白,
            法器Type.射手武器白, 法器Type.射手头盔白, 法器Type.射手衣服白, 法器Type.射手鞋子白,
            法器Type.法师武器白, 法器Type.法师头盔白, 法器Type.法师衣服白, 法器Type.法师鞋子白
        }
    },

    // ==================== 2. 玄品 (对应原先的 绿色) ====================
    {
        QualityType.玄品, new List<法器Type>()
        {
            法器Type.战士武器绿, 法器Type.战士头盔绿, 法器Type.战士衣服绿, 法器Type.战士鞋子绿,
            法器Type.控制武器绿, 法器Type.控制头盔绿, 法器Type.控制衣服绿, 法器Type.控制鞋子绿,
            法器Type.辅助武器绿, 法器Type.辅助头盔绿, 法器Type.辅助衣服绿, 法器Type.辅助鞋子绿,
            法器Type.射手武器绿, 法器Type.射手头盔绿, 法器Type.射手衣服绿, 法器Type.射手鞋子绿,
            法器Type.法师武器绿, 法器Type.法师头盔绿, 法器Type.法师衣服绿, 法器Type.法师鞋子绿
        }
    },

    // ==================== 3. 地品 (对应原先的 蓝色) ====================
    {
        QualityType.地品, new List<法器Type>()
        {
            法器Type.战士武器蓝, 法器Type.战士头盔蓝, 法器Type.战士衣服蓝, 法器Type.战士鞋子蓝,
            法器Type.控制武器蓝, 法器Type.控制头盔蓝, 法器Type.控制衣服蓝, 法器Type.控制鞋子蓝,
            法器Type.辅助武器蓝, 法器Type.辅助头盔蓝, 法器Type.辅助衣服蓝, 法器Type.辅助鞋子蓝,
            法器Type.射手武器蓝, 法器Type.射手头盔蓝, 法器Type.射手衣服蓝, 法器Type.射手鞋子蓝,
            法器Type.法师武器蓝, 法器Type.法师头盔蓝, 法器Type.法师衣服蓝, 法器Type.法师鞋子蓝
        }
    },

    // ==================== 4. 天品 (对应原先的 紫色) ====================
    {
        QualityType.天品, new List<法器Type>()
        {
            法器Type.战士武器紫, 法器Type.战士头盔紫, 法器Type.战士衣服紫, 法器Type.战士鞋子紫,
            法器Type.控制武器紫, 法器Type.控制头盔紫, 法器Type.控制衣服紫, 法器Type.控制鞋子紫,
            法器Type.辅助武器紫, 法器Type.辅助头盔紫, 法器Type.辅助衣服紫, 法器Type.辅助鞋子紫,
            法器Type.射手武器紫, 法器Type.射手头盔紫, 法器Type.射手衣服紫, 法器Type.射手鞋子紫,
            法器Type.法师武器紫, 法器Type.法师头盔紫, 法器Type.法师衣服紫, 法器Type.法师鞋子紫
        }
    },

    // ==================== 5. 宇品 (对应原先的 橙色) ====================
    {
        QualityType.宇品, new List<法器Type>()
        {
            法器Type.战士武器橙, 法器Type.战士头盔橙, 法器Type.战士衣服橙, 法器Type.战士鞋子橙,
            法器Type.控制武器橙, 法器Type.控制头盔橙, 法器Type.控制衣服橙, 法器Type.控制鞋子橙,
            法器Type.辅助武器橙, 法器Type.辅助头盔橙, 法器Type.辅助衣服橙, 法器Type.辅助鞋子橙,
            法器Type.射手武器橙, 法器Type.射手头盔橙, 法器Type.射手衣服橙, 法器Type.射手鞋子橙,
            法器Type.法师武器橙, 法器Type.法师头盔橙, 法器Type.法师衣服橙, 法器Type.法师鞋子橙
        }
    },

    // ==================== 6. 宙品 (对应原先的 粉色) ====================
    {
        QualityType.宙品, new List<法器Type>()
        {
            法器Type.战士武器粉, 法器Type.战士头盔粉, 法器Type.战士衣服粉, 法器Type.战士鞋子粉,
            法器Type.控制武器粉, 法器Type.控制头盔粉, 法器Type.控制衣服粉, 法器Type.控制鞋子粉,
            法器Type.辅助武器粉, 法器Type.辅助头盔粉, 法器Type.辅助衣服粉, 法器Type.辅助鞋子粉,
            法器Type.射手武器粉, 法器Type.射手头盔粉, 法器Type.射手衣服粉, 法器Type.射手鞋子粉,
            法器Type.法师武器粉, 法器Type.法师头盔粉, 法器Type.法师衣服粉, 法器Type.法师鞋子粉
        }
    },

    // ==================== 7. 洪品 (对应原先的 红色) ====================
    {
        QualityType.洪品, new List<法器Type>()
        {
            法器Type.战士武器红, 法器Type.战士头盔红, 法器Type.战士衣服红, 法器Type.战士鞋子红,
            法器Type.控制武器红, 法器Type.控制头盔红, 法器Type.控制衣服红, 法器Type.控制鞋子红,
            法器Type.辅助武器红, 法器Type.辅助头盔红, 法器Type.辅助衣服红, 法器Type.辅助鞋子红,
            法器Type.射手武器红, 法器Type.射手头盔红, 法器Type.射手衣服红, 法器Type.射手鞋子红,
            法器Type.法师武器红, 法器Type.法师头盔红, 法器Type.法师衣服红, 法器Type.法师鞋子红
        }
    },

    // ==================== 8. 荒品 (对应原先的 彩色) ====================
    {
        QualityType.荒品, new List<法器Type>()
        {
            法器Type.战士武器彩, 法器Type.战士头盔彩, 法器Type.战士衣服彩, 法器Type.战士鞋子彩,
            法器Type.控制武器彩, 法器Type.控制头盔彩, 法器Type.控制衣服彩, 法器Type.控制鞋子彩,
            法器Type.辅助武器彩, 法器Type.辅助头盔彩, 法器Type.辅助衣服彩, 法器Type.辅助鞋子彩,
            法器Type.射手武器彩, 法器Type.射手头盔彩, 法器Type.射手衣服彩, 法器Type.射手鞋子彩,
            法器Type.法师武器彩, 法器Type.法师头盔彩, 法器Type.法师衣服彩, 法器Type.法师鞋子彩
        }
    }
};
    public static Dictionary<法器Type, QualityType> 法器品质Dic = new Dictionary<法器Type, QualityType>()
{
    // ==================== 1. 战士 ====================
    { 法器Type.战士武器白, QualityType.黄品 },
    { 法器Type.战士武器绿, QualityType.玄品 },
    { 法器Type.战士武器蓝, QualityType.地品 },
    { 法器Type.战士武器紫, QualityType.天品 },
    { 法器Type.战士武器橙, QualityType.宇品 },
    { 法器Type.战士武器粉, QualityType.宙品 },
    { 法器Type.战士武器红, QualityType.洪品 },
    { 法器Type.战士武器彩, QualityType.荒品 },

    { 法器Type.战士头盔白, QualityType.黄品 },
    { 法器Type.战士头盔绿, QualityType.玄品 },
    { 法器Type.战士头盔蓝, QualityType.地品 },
    { 法器Type.战士头盔紫, QualityType.天品 },
    { 法器Type.战士头盔橙, QualityType.宇品 },
    { 法器Type.战士头盔粉, QualityType.宙品 },
    { 法器Type.战士头盔红, QualityType.洪品 },
    { 法器Type.战士头盔彩, QualityType.荒品 },

    { 法器Type.战士衣服白, QualityType.黄品 },
    { 法器Type.战士衣服绿, QualityType.玄品 },
    { 法器Type.战士衣服蓝, QualityType.地品 },
    { 法器Type.战士衣服紫, QualityType.天品 },
    { 法器Type.战士衣服橙, QualityType.宇品 },
    { 法器Type.战士衣服粉, QualityType.宙品 },
    { 法器Type.战士衣服红, QualityType.洪品 },
    { 法器Type.战士衣服彩, QualityType.荒品 },

    { 法器Type.战士鞋子白, QualityType.黄品 },
    { 法器Type.战士鞋子绿, QualityType.玄品 },
    { 法器Type.战士鞋子蓝, QualityType.地品 },
    { 法器Type.战士鞋子紫, QualityType.天品 },
    { 法器Type.战士鞋子橙, QualityType.宇品 },
    { 法器Type.战士鞋子粉, QualityType.宙品 },
    { 法器Type.战士鞋子红, QualityType.洪品 },
    { 法器Type.战士鞋子彩, QualityType.荒品 },

    // ==================== 2. 控制 ====================
    { 法器Type.控制武器白, QualityType.黄品 },
    { 法器Type.控制武器绿, QualityType.玄品 },
    { 法器Type.控制武器蓝, QualityType.地品 },
    { 法器Type.控制武器紫, QualityType.天品 },
    { 法器Type.控制武器橙, QualityType.宇品 },
    { 法器Type.控制武器粉, QualityType.宙品 },
    { 法器Type.控制武器红, QualityType.洪品 },
    { 法器Type.控制武器彩, QualityType.荒品 },

    { 法器Type.控制头盔白, QualityType.黄品 },
    { 法器Type.控制头盔绿, QualityType.玄品 },
    { 法器Type.控制头盔蓝, QualityType.地品 },
    { 法器Type.控制头盔紫, QualityType.天品 },
    { 法器Type.控制头盔橙, QualityType.宇品 },
    { 法器Type.控制头盔粉, QualityType.宙品 },
    { 法器Type.控制头盔红, QualityType.洪品 },
    { 法器Type.控制头盔彩, QualityType.荒品 },

    { 法器Type.控制衣服白, QualityType.黄品 },
    { 法器Type.控制衣服绿, QualityType.玄品 },
    { 法器Type.控制衣服蓝, QualityType.地品 },
    { 法器Type.控制衣服紫, QualityType.天品 },
    { 法器Type.控制衣服橙, QualityType.宇品 },
    { 法器Type.控制衣服粉, QualityType.宙品 },
    { 法器Type.控制衣服红, QualityType.洪品 },
    { 法器Type.控制衣服彩, QualityType.荒品 },

    { 法器Type.控制鞋子白, QualityType.黄品 },
    { 法器Type.控制鞋子绿, QualityType.玄品 },
    { 法器Type.控制鞋子蓝, QualityType.地品 },
    { 法器Type.控制鞋子紫, QualityType.天品 },
    { 法器Type.控制鞋子橙, QualityType.宇品 },
    { 法器Type.控制鞋子粉, QualityType.宙品 },
    { 法器Type.控制鞋子红, QualityType.洪品 },
    { 法器Type.控制鞋子彩, QualityType.荒品 },

    // ==================== 3. 辅助 ====================
    { 法器Type.辅助武器白, QualityType.黄品 },
    { 法器Type.辅助武器绿, QualityType.玄品 },
    { 法器Type.辅助武器蓝, QualityType.地品 },
    { 法器Type.辅助武器紫, QualityType.天品 },
    { 法器Type.辅助武器橙, QualityType.宇品 },
    { 法器Type.辅助武器粉, QualityType.宙品 },
    { 法器Type.辅助武器红, QualityType.洪品 },
    { 法器Type.辅助武器彩, QualityType.荒品 },

    { 法器Type.辅助头盔白, QualityType.黄品 },
    { 法器Type.辅助头盔绿, QualityType.玄品 },
    { 法器Type.辅助头盔蓝, QualityType.地品 },
    { 法器Type.辅助头盔紫, QualityType.天品 },
    { 法器Type.辅助头盔橙, QualityType.宇品 },
    { 法器Type.辅助头盔粉, QualityType.宙品 },
    { 法器Type.辅助头盔红, QualityType.洪品 },
    { 法器Type.辅助头盔彩, QualityType.荒品 },

    { 法器Type.辅助衣服白, QualityType.黄品 },
    { 法器Type.辅助衣服绿, QualityType.玄品 },
    { 法器Type.辅助衣服蓝, QualityType.地品 },
    { 法器Type.辅助衣服紫, QualityType.天品 },
    { 法器Type.辅助衣服橙, QualityType.宇品 },
    { 法器Type.辅助衣服粉, QualityType.宙品 },
    { 法器Type.辅助衣服红, QualityType.洪品 },
    { 法器Type.辅助衣服彩, QualityType.荒品 },

    { 法器Type.辅助鞋子白, QualityType.黄品 },
    { 法器Type.辅助鞋子绿, QualityType.玄品 },
    { 法器Type.辅助鞋子蓝, QualityType.地品 },
    { 法器Type.辅助鞋子紫, QualityType.天品 },
    { 法器Type.辅助鞋子橙, QualityType.宇品 },
    { 法器Type.辅助鞋子粉, QualityType.宙品 },
    { 法器Type.辅助鞋子红, QualityType.洪品 },
    { 法器Type.辅助鞋子彩, QualityType.荒品 },

    // ==================== 4. 射手 ====================
    { 法器Type.射手武器白, QualityType.黄品 },
    { 法器Type.射手武器绿, QualityType.玄品 },
    { 法器Type.射手武器蓝, QualityType.地品 },
    { 法器Type.射手武器紫, QualityType.天品 },
    { 法器Type.射手武器橙, QualityType.宇品 },
    { 法器Type.射手武器粉, QualityType.宙品 },
    { 法器Type.射手武器红, QualityType.洪品 },
    { 法器Type.射手武器彩, QualityType.荒品 },

    { 法器Type.射手头盔白, QualityType.黄品 },
    { 法器Type.射手头盔绿, QualityType.玄品 },
    { 法器Type.射手头盔蓝, QualityType.地品 },
    { 法器Type.射手头盔紫, QualityType.天品 },
    { 法器Type.射手头盔橙, QualityType.宇品 },
    { 法器Type.射手头盔粉, QualityType.宙品 },
    { 法器Type.射手头盔红, QualityType.洪品 },
    { 法器Type.射手头盔彩, QualityType.荒品 },

    { 法器Type.射手衣服白, QualityType.黄品 },
    { 法器Type.射手衣服绿, QualityType.玄品 },
    { 法器Type.射手衣服蓝, QualityType.地品 },
    { 法器Type.射手衣服紫, QualityType.天品 },
    { 法器Type.射手衣服橙, QualityType.宇品 },
    { 法器Type.射手衣服粉, QualityType.宙品 },
    { 法器Type.射手衣服红, QualityType.洪品 },
    { 法器Type.射手衣服彩, QualityType.荒品 },

    { 法器Type.射手鞋子白, QualityType.黄品 },
    { 法器Type.射手鞋子绿, QualityType.玄品 },
    { 法器Type.射手鞋子蓝, QualityType.地品 },
    { 法器Type.射手鞋子紫, QualityType.天品 },
    { 法器Type.射手鞋子橙, QualityType.宇品 },
    { 法器Type.射手鞋子粉, QualityType.宙品 },
    { 法器Type.射手鞋子红, QualityType.洪品 },
    { 法器Type.射手鞋子彩, QualityType.荒品 },

    // ==================== 5. 法师 ====================
    { 法器Type.法师武器白, QualityType.黄品 },
    { 法器Type.法师武器绿, QualityType.玄品 },
    { 法器Type.法师武器蓝, QualityType.地品 },
    { 法器Type.法师武器紫, QualityType.天品 },
    { 法器Type.法师武器橙, QualityType.宇品 },
    { 法器Type.法师武器粉, QualityType.宙品 },
    { 法器Type.法师武器红, QualityType.洪品 },
    { 法器Type.法师武器彩, QualityType.荒品 },

    { 法器Type.法师头盔白, QualityType.黄品 },
    { 法器Type.法师头盔绿, QualityType.玄品 },
    { 法器Type.法师头盔蓝, QualityType.地品 },
    { 法器Type.法师头盔紫, QualityType.天品 },
    { 法器Type.法师头盔橙, QualityType.宇品 },
    { 法器Type.法师头盔粉, QualityType.宙品 },
    { 法器Type.法师头盔红, QualityType.洪品 },
    { 法器Type.法师头盔彩, QualityType.荒品 },

    { 法器Type.法师衣服白, QualityType.黄品 },
    { 法器Type.法师衣服绿, QualityType.玄品 },
    { 法器Type.法师衣服蓝, QualityType.地品 },
    { 法器Type.法师衣服紫, QualityType.天品 },
    { 法器Type.法师衣服橙, QualityType.宇品 },
    { 法器Type.法师衣服粉, QualityType.宙品 },
    { 法器Type.法师衣服红, QualityType.洪品 },
    { 法器Type.法师衣服彩, QualityType.荒品 },

    { 法器Type.法师鞋子白, QualityType.黄品 },
    { 法器Type.法师鞋子绿, QualityType.玄品 },
    { 法器Type.法师鞋子蓝, QualityType.地品 },
    { 法器Type.法师鞋子紫, QualityType.天品 },
    { 法器Type.法师鞋子橙, QualityType.宇品 },
    { 法器Type.法师鞋子粉, QualityType.宙品 },
    { 法器Type.法师鞋子红, QualityType.洪品 },
    { 法器Type.法师鞋子彩, QualityType.荒品 },
};

    //掉落0-4件
    public static List<float> 掉落数量概率List = new List<float>()
    {
        10, 40, 30, 15, 5
    };
    public static Dictionary<JingJieType, List<float>> 法器掉落概率Dic = new Dictionary<JingJieType, List<float>>()
    {
        { JingJieType.练气 , new List<float>(){100,0,0,0,0,0,0,0}},
        { JingJieType.筑基 , new List<float>(){80,20,0,0,0,0,0,0}},
        { JingJieType.金丹 , new List<float>(){50,50,0,0,0,0,0,0}},
        { JingJieType.元婴 , new List<float>(){10,70,20,0,0,0,0,0}},
        { JingJieType.化神 , new List<float>(){0,50,50,0,0,0,0,0}},
        { JingJieType.合体 , new List<float>(){0,20,70,10,0,0,0,0}},
        { JingJieType.大乘 , new List<float>(){0,0,80,20,0,0,0,0}},
        { JingJieType.天仙 , new List<float>(){0,0,60,40,0,0,0,0}},
        { JingJieType.玄仙 , new List<float>(){0,0,40,50,10,0,0,0}},
        { JingJieType.金仙 , new List<float>(){0,0,10,70,20,0,0,0}},
        { JingJieType.太乙金仙 , new List<float>(){0,00,00,70,30,0,0,0}},
        { JingJieType.大罗金仙 , new List<float>(){0,0,13,40,40,7,0,0}},
        { JingJieType.准圣 , new List<float>(){0,0,5,30,50,15,0,0}},
        { JingJieType.圣人 , new List<float>(){0,0,0,15,60,25,0,0}},
        { JingJieType.天道圣人 , new List<float>(){0,0,0,0,62,35,3,0}},
        { JingJieType.大道圣人 , new List<float>(){0,0,0,0,42,50,8,0}},
        { JingJieType.混元圣人 , new List<float>(){0,0,0,0,20,65,15,0}},
        { JingJieType.鸿蒙 , new List<float>(){0,0,0,0,4,70,25,1}},
    };

    public static 法器 单次法器掉落(JingJieType jingJieType)
    {
        QualityType 掉落品质 = QualityType.黄品;
        float count = 0;
        float 品质random=Random.Range(0,100);
        foreach (var item in 掉落数量概率List)
        {
            count += item;
            if (品质random < count) break;
            掉落品质++;
        }
        var list = 法器品质列表Dic[掉落品质];
        法器 法器 = new 法器();
        法器.法器Type = list[Random.Range(0, list.Count)];
        var 附加属性列表 = Get法器附加属性(掉落品质);
        法器.list = 附加属性列表;
        法器.孔个数 = Random.Range(0, (int)掉落品质+1);
        return 法器;
    }
    public static List<法器> Get关卡法器掉落(JingJieType jingJieType)
    {
        int 掉落数量 = 0;
        float count = 0;
        float 数量random=Random.Range(0,100);
        foreach (var item in 掉落数量概率List)
        {
            count += item;
            if (数量random < count) break;
            掉落数量++;
        }

        List<法器> list = new List<法器>();
        for (int i = 0; i < 掉落数量; i++)
        {
            list.Add(单次法器掉落(jingJieType));
        }

        return list;
    }
    public static Dictionary<法器附加属性品质type, minmax> 法器Minmaxes = new Dictionary<法器附加属性品质type, minmax>()
    {
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害,QualityType = QualityType.玄品},new minmax(){min = 10,max = 10}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害,QualityType = QualityType.玄品},new minmax(){min = 10,max = 10}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害,QualityType = QualityType.玄品},new minmax(){min = 10,max = 10}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害,QualityType = QualityType.玄品},new minmax(){min = 10,max = 10}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害,QualityType = QualityType.玄品},new minmax(){min = 10,max = 10}},
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害,QualityType = QualityType.地品},new minmax(){min = 10,max = 20}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害,QualityType = QualityType.地品},new minmax(){min = 10,max = 20}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害,QualityType = QualityType.地品},new minmax(){min = 10,max = 20}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害,QualityType = QualityType.地品},new minmax(){min = 10,max = 20}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害,QualityType = QualityType.地品},new minmax(){min = 10,max = 20}},
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害,QualityType = QualityType.天品},new minmax(){min = 15,max = 30}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害,QualityType = QualityType.天品},new minmax(){min = 15,max = 30}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害,QualityType = QualityType.天品},new minmax(){min = 15,max = 30}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害,QualityType = QualityType.天品},new minmax(){min = 15,max = 30}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害,QualityType = QualityType.天品},new minmax(){min = 15,max = 30}},
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害,QualityType = QualityType.宇品},new minmax(){min = 25,max = 50}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害,QualityType = QualityType.宇品},new minmax(){min = 25,max = 50}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害,QualityType = QualityType.宇品},new minmax(){min = 25,max = 50}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害,QualityType = QualityType.宇品},new minmax(){min = 25,max = 50}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害,QualityType = QualityType.宇品},new minmax(){min = 25,max = 50}},
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害,QualityType = QualityType.宙品},new minmax(){min = 40,max = 80}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害,QualityType = QualityType.宙品},new minmax(){min = 40,max = 80}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害,QualityType = QualityType.宙品},new minmax(){min = 40,max = 80}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害,QualityType = QualityType.宙品},new minmax(){min = 40,max = 80}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害,QualityType = QualityType.宙品},new minmax(){min = 40,max = 80}},
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害,QualityType = QualityType.洪品},new minmax(){min = 70,max = 120}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害,QualityType = QualityType.洪品},new minmax(){min = 70,max = 120}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害,QualityType = QualityType.洪品},new minmax(){min = 70,max = 120}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害,QualityType = QualityType.洪品},new minmax(){min = 70,max = 120}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害,QualityType = QualityType.洪品},new minmax(){min = 70,max = 120}},
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害,QualityType = QualityType.荒品},new minmax(){min = 120,max = 200}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害,QualityType = QualityType.荒品},new minmax(){min = 120,max = 200}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害,QualityType = QualityType.荒品},new minmax(){min = 120,max = 200}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害,QualityType = QualityType.荒品},new minmax(){min = 120,max = 200}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害,QualityType = QualityType.荒品},new minmax(){min = 120,max = 200}},
        
        
        
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透,QualityType = QualityType.玄品},new minmax(){min = 10,max = 10}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透,QualityType = QualityType.玄品},new minmax(){min = 10,max = 10}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透,QualityType = QualityType.玄品},new minmax(){min = 10,max = 10}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透,QualityType = QualityType.玄品},new minmax(){min = 10,max = 10}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透,QualityType = QualityType.玄品},new minmax(){min = 10,max = 10}},
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透,QualityType = QualityType.地品},new minmax(){min = 10,max = 20}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透,QualityType = QualityType.地品},new minmax(){min = 10,max = 20}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透,QualityType = QualityType.地品},new minmax(){min = 10,max = 20}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透,QualityType = QualityType.地品},new minmax(){min = 10,max = 20}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透,QualityType = QualityType.地品},new minmax(){min = 10,max = 20}},
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透,QualityType = QualityType.天品},new minmax(){min = 15,max = 30}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透,QualityType = QualityType.天品},new minmax(){min = 15,max = 30}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透,QualityType = QualityType.天品},new minmax(){min = 15,max = 30}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透,QualityType = QualityType.天品},new minmax(){min = 15,max = 30}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透,QualityType = QualityType.天品},new minmax(){min = 15,max = 30}},
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透,QualityType = QualityType.宇品},new minmax(){min = 25,max = 50}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透,QualityType = QualityType.宇品},new minmax(){min = 25,max = 50}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透,QualityType = QualityType.宇品},new minmax(){min = 25,max = 50}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透,QualityType = QualityType.宇品},new minmax(){min = 25,max = 50}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透,QualityType = QualityType.宇品},new minmax(){min = 25,max = 50}},
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透,QualityType = QualityType.宙品},new minmax(){min = 40,max = 80}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透,QualityType = QualityType.宙品},new minmax(){min = 40,max = 80}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透,QualityType = QualityType.宙品},new minmax(){min = 40,max = 80}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透,QualityType = QualityType.宙品},new minmax(){min = 40,max = 80}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透,QualityType = QualityType.宙品},new minmax(){min = 40,max = 80}},
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透,QualityType = QualityType.洪品},new minmax(){min = 70,max = 120}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透,QualityType = QualityType.洪品},new minmax(){min = 70,max = 120}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透,QualityType = QualityType.洪品},new minmax(){min = 70,max = 120}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透,QualityType = QualityType.洪品},new minmax(){min = 70,max = 120}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透,QualityType = QualityType.洪品},new minmax(){min = 70,max = 120}},
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透,QualityType = QualityType.荒品},new minmax(){min = 120,max = 200}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透,QualityType = QualityType.荒品},new minmax(){min = 120,max = 200}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透,QualityType = QualityType.荒品},new minmax(){min = 120,max = 200}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透,QualityType = QualityType.荒品},new minmax(){min = 120,max = 200}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透,QualityType = QualityType.荒品},new minmax(){min = 120,max = 200}},
        
        
        
        
        
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害,QualityType = QualityType.黄品},new minmax(){min = 2,max = 3}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害,QualityType = QualityType.玄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害,QualityType = QualityType.地品},new minmax(){min = 5,max = 10}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害,QualityType = QualityType.天品},new minmax(){min = 10,max = 20}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害,QualityType = QualityType.宇品},new minmax(){min = 15,max = 30}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害,QualityType = QualityType.宙品},new minmax(){min = 25,max = 50}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害,QualityType = QualityType.洪品},new minmax(){min = 40,max = 80}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害,QualityType = QualityType.荒品},new minmax(){min = 80,max = 130}},


        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤,QualityType = QualityType.玄品},new minmax(){min = 5,max = 8}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤,QualityType = QualityType.地品},new minmax(){min = 8,max = 15}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤,QualityType = QualityType.天品},new minmax(){min = 15,max = 25}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤,QualityType = QualityType.宇品},new minmax(){min = 20,max = 40}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤,QualityType = QualityType.宙品},new minmax(){min = 30,max = 60}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤,QualityType = QualityType.洪品},new minmax(){min = 50,max = 100}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤,QualityType = QualityType.荒品},new minmax(){min = 100,max = 160}},
        
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤,QualityType = QualityType.玄品},new minmax(){min = 5,max = 8}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤,QualityType = QualityType.地品},new minmax(){min = 8,max = 15}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤,QualityType = QualityType.天品},new minmax(){min = 15,max = 25}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤,QualityType = QualityType.宇品},new minmax(){min = 20,max = 40}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤,QualityType = QualityType.宙品},new minmax(){min = 30,max = 60}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤,QualityType = QualityType.洪品},new minmax(){min = 50,max = 100}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤,QualityType = QualityType.荒品},new minmax(){min = 100,max = 160}},
        
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤,QualityType = QualityType.玄品},new minmax(){min = 5,max = 8}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤,QualityType = QualityType.地品},new minmax(){min = 8,max = 15}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤,QualityType = QualityType.天品},new minmax(){min = 15,max = 25}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤,QualityType = QualityType.宇品},new minmax(){min = 20,max = 40}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤,QualityType = QualityType.宙品},new minmax(){min = 30,max = 60}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤,QualityType = QualityType.洪品},new minmax(){min = 50,max = 100}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤,QualityType = QualityType.荒品},new minmax(){min = 100,max = 160}},
        
        
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害,QualityType = QualityType.黄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害,QualityType = QualityType.玄品},new minmax(){min = 5,max = 8}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害,QualityType = QualityType.地品},new minmax(){min = 8,max = 15}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害,QualityType = QualityType.天品},new minmax(){min = 15,max = 25}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害,QualityType = QualityType.宇品},new minmax(){min = 20,max = 40}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害,QualityType = QualityType.宙品},new minmax(){min = 30,max = 60}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害,QualityType = QualityType.洪品},new minmax(){min = 50,max = 100}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害,QualityType = QualityType.荒品},new minmax(){min = 100,max = 160}},
        
        
        
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率,QualityType = QualityType.黄品},new minmax(){min = 2,max = 3}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率,QualityType = QualityType.玄品},new minmax(){min = 3,max = 5}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率,QualityType = QualityType.地品},new minmax(){min = 5,max = 10}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率,QualityType = QualityType.天品},new minmax(){min = 10,max = 20}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率,QualityType = QualityType.宇品},new minmax(){min = 15,max = 30}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率,QualityType = QualityType.宙品},new minmax(){min = 25,max = 50}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率,QualityType = QualityType.洪品},new minmax(){min = 40,max = 80}},
        {new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率,QualityType = QualityType.荒品},new minmax(){min = 80,max = 130}},
    };
    public static int Get孔数量(QualityType qualityType)
    {
        int max = (int)qualityType;
        int random = Random.Range(0, max + 1);
        return random;
    }

    public static List<法器附加属性值> Get法器附加属性(QualityType qualityType)
    {
        List<法器附加属性值> list = new List<法器附加属性值>();
        for (int i = 0; i < (int)qualityType; i++)
        {
            int type = Random.Range(1, Enum.GetValues(typeof(法器附加属性Type)).Length);
            法器附加属性Type 附加属性Type = (法器附加属性Type)type;
            float min=法器Minmaxes[new 法器附加属性品质type(){法器附加属性Type = 附加属性Type,QualityType =  qualityType}].min;
            float max=法器Minmaxes[new 法器附加属性品质type(){法器附加属性Type = 附加属性Type,QualityType =  qualityType}].max;
            法器附加属性值 法器附加属性值 = new 法器附加属性值();
            法器附加属性值.法器附加属性Type = (法器附加属性Type)type;
            法器附加属性值.count=Random.Range(min,max);
            list.Add(法器附加属性值);
        }
        return list;
    }
}
