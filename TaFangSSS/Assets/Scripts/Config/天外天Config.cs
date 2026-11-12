using Config;

public enum 秘宝地点
{
    None,
    须弥宫,
    娲皇宫,
    碧游宫,
    玉虚宫,
    八景宫,
}

public enum 秘宝Type
{
    None,
    加全职业伤害,
    加全元素伤害,
    加暴击率,
    加暴击伤害,
    加最终伤害,
    加掉宝,
    加跟脚,
    加真灵,
    加轮回系数,
    暴击次数,
}

public class 秘宝
{
    public 秘宝地点 秘宝地点;
    public 秘宝Type 秘宝Type;
    public int 等级;
}
public class 天外天Config
{
    public static float Get秘宝值(int 等级, 秘宝Type 秘宝Type)
    {
        switch (秘宝Type)
        {
            case 秘宝Type.加全职业伤害:
                switch (等级)
                {
                    case 1:
                        return 100;
                    case 2:
                        return 500;
                    case 3:
                        return 2000;
                    case 4:
                        return 10000;
                }
                break;
            
            case 秘宝Type.加全元素伤害:
                switch (等级)
                {
                    case 1:
                        return 100;
                    case 2:
                        return 500;
                    case 3:
                        return 2000;
                    case 4:
                        return 10000;
                }
                break;
            
            case 秘宝Type.加暴击率:
                switch (等级)
                {
                    case 1:
                        return 30;
                    case 2:
                        return 60;
                    case 3:
                        return 100;
                    case 4:
                        return 200;
                }
                break;
            
            case 秘宝Type.加暴击伤害:
                switch (等级)
                {
                    case 1:
                        return 100;
                    case 2:
                        return 500;
                    case 3:
                        return 2000;
                    case 4:
                        return 10000;
                }
                break;
            
            case 秘宝Type.加最终伤害:
                switch (等级)
                {
                    case 1:
                        return 100;
                    case 2:
                        return 500;
                    case 3:
                        return 2000;
                    case 4:
                        return 10000;
                }
                break;
            
            case 秘宝Type.加掉宝:
                switch (等级)
                {
                    case 1:
                        return 10;
                    case 2:
                        return 20;
                    case 3:
                        return 30;
                    case 4:
                        return 50;
                }
                break;
            
            case 秘宝Type.加跟脚:
                switch (等级)
                {
                    case 1:
                        return 100;
                    case 2:
                        return 500;
                    case 3:
                        return 2000;
                    case 4:
                        return 10000;
                }
                break;
            
            case 秘宝Type.加真灵:
                switch (等级)
                {
                    case 1:
                        return 20;
                    case 2:
                        return 30;
                    case 3:
                        return 50;
                    case 4:
                        return 100;
                }
                break;
            
            case 秘宝Type.加轮回系数:
                switch (等级)
                {
                    case 1:
                        return 0.05f;
                    case 2:
                        return 0.05f;
                    case 3:
                        return 0.05f;
                    case 4:
                        return 0.05f;
                }
                break;
        }

        return 0;
    }
    
    public static float Get秘宝价格(int 等级, 秘宝Type 秘宝Type)
    {
        switch (秘宝Type)
        {
            case 秘宝Type.暴击次数:
                return 5000000;
            case 秘宝Type.加全职业伤害:
                switch (等级)
                {
                    case 1:
                        return 1000;
                    case 2:
                        return 5000;
                    case 3:
                        return 20000;
                    case 4:
                        return 100000;
                }
                break;
            
            case 秘宝Type.加全元素伤害:
                switch (等级)
                {
                    case 1:
                        return 1000;
                    case 2:
                        return 5000;
                    case 3:
                        return 20000;
                    case 4:
                        return 100000;
                }
                break;
            
            case 秘宝Type.加暴击率:
                switch (等级)
                {
                    case 1:
                        return 1000;
                    case 2:
                        return 5000;
                    case 3:
                        return 20000;
                    case 4:
                        return 100000;
                }
                break;
            
            case 秘宝Type.加暴击伤害:
                switch (等级)
                {
                    case 1:
                        return 1000;
                    case 2:
                        return 5000;
                    case 3:
                        return 20000;
                    case 4:
                        return 100000;
                }
                break;
            
            case 秘宝Type.加最终伤害:
                switch (等级)
                {
                    case 1:
                        return 1000;
                    case 2:
                        return 5000;
                    case 3:
                        return 20000;
                    case 4:
                        return 100000;
                }
                break;
            
            case 秘宝Type.加掉宝:
                switch (等级)
                {
                    case 1:
                        return 10000;
                    case 2:
                        return 50000;
                    case 3:
                        return 200000;
                    case 4:
                        return 1000000;
                }
                break;
            
            case 秘宝Type.加跟脚:
                switch (等级)
                {
                    case 1:
                        return 10000;
                    case 2:
                        return 50000;
                    case 3:
                        return 200000;
                    case 4:
                        return 1000000;
                }
                break;
            
            case 秘宝Type.加真灵:
                switch (等级)
                {
                    case 1:
                        return 100000;
                    case 2:
                        return 500000;
                    case 3:
                        return 2000000;
                    case 4:
                        return 10000000;
                }
                break;
            
            case 秘宝Type.加轮回系数:
                switch (等级)
                {
                    case 1:
                        return 30000;
                    case 2:
                        return 150000;
                    case 3:
                        return 800000;
                    case 4:
                        return 3000000;
                }
                break;
        }

        return 0;
    }

    public static string Get秘宝名(秘宝地点 秘宝地点, 秘宝Type 秘宝Type)
    {
        if (秘宝Type == 秘宝Type.暴击次数)
        {
            switch (秘宝地点)
            {
                case 秘宝地点.八景宫:
                    return "八景陨圣晶";
                case 秘宝地点.须弥宫:
                    return "须弥陨圣晶";
                case 秘宝地点.娲皇宫:
                    return "娲皇陨圣晶";
                case 秘宝地点.玉虚宫:
                    return "玉虚陨圣晶";
                case 秘宝地点.碧游宫:
                    return "碧游陨圣晶";
            }
        }
        switch (秘宝地点)
        {
            case 秘宝地点.须弥宫:
                switch (秘宝Type)
                {
                    case 秘宝Type.加全职业伤害:
                        return "须弥通神玉";
                    case 秘宝Type.加全元素伤害:
                        return "须弥五色石";
                    case 秘宝Type.加暴击率:
                        return "须弥洞玄石";
                    case 秘宝Type.加暴击伤害:
                        return "须弥崩天印";
                    case 秘宝Type.加最终伤害:
                        return "须弥寂灭轮";
                    case 秘宝Type.加掉宝:
                        return "须弥福缘石";
                    case 秘宝Type.加跟脚:
                        return "须弥造化根";
                    case 秘宝Type.加真灵:
                        return "须弥真灵种";
                    case 秘宝Type.加轮回系数:
                        return "须弥转生珠";
                }
                break;
            
            case 秘宝地点.娲皇宫:
                switch (秘宝Type)
                {
                    case 秘宝Type.加全职业伤害:
                        return "娲皇通神玉";
                    case 秘宝Type.加全元素伤害:
                        return "娲皇五色石";
                    case 秘宝Type.加暴击率:
                        return "娲皇洞玄石";
                    case 秘宝Type.加暴击伤害:
                        return "娲皇崩天印";
                    case 秘宝Type.加最终伤害:
                        return "娲皇寂灭轮";
                    case 秘宝Type.加掉宝:
                        return "娲皇福缘石";
                    case 秘宝Type.加跟脚:
                        return "娲皇造化根";
                    case 秘宝Type.加真灵:
                        return "娲皇真灵种";
                    case 秘宝Type.加轮回系数:
                        return "娲皇转生珠";
                }
                break;
            
            case 秘宝地点.碧游宫:
                switch (秘宝Type)
                {
                    case 秘宝Type.加全职业伤害:
                        return "碧游通神玉";
                    case 秘宝Type.加全元素伤害:
                        return "碧游五色石";
                    case 秘宝Type.加暴击率:
                        return "碧游洞玄石";
                    case 秘宝Type.加暴击伤害:
                        return "碧游崩天印";
                    case 秘宝Type.加最终伤害:
                        return "碧游寂灭轮";
                    case 秘宝Type.加掉宝:
                        return "碧游福缘石";
                    case 秘宝Type.加跟脚:
                        return "碧游造化根";
                    case 秘宝Type.加真灵:
                        return "碧游真灵种";
                    case 秘宝Type.加轮回系数:
                        return "碧游转生珠";
                }
                break;
            
            case 秘宝地点.八景宫:
                switch (秘宝Type)
                {
                    case 秘宝Type.加全职业伤害:
                        return "八景通神玉";
                    case 秘宝Type.加全元素伤害:
                        return "八景五色石";
                    case 秘宝Type.加暴击率:
                        return "八景洞玄石";
                    case 秘宝Type.加暴击伤害:
                        return "八景崩天印";
                    case 秘宝Type.加最终伤害:
                        return "八景寂灭轮";
                    case 秘宝Type.加掉宝:
                        return "八景福缘石";
                    case 秘宝Type.加跟脚:
                        return "八景造化根";
                    case 秘宝Type.加真灵:
                        return "八景真灵种";
                    case 秘宝Type.加轮回系数:
                        return "八景转生珠";
                }
                break;
            
            
            case 秘宝地点.玉虚宫:
                switch (秘宝Type)
                {
                    case 秘宝Type.加全职业伤害:
                        return "玉虚通神玉";
                    case 秘宝Type.加全元素伤害:
                        return "玉虚五色石";
                    case 秘宝Type.加暴击率:
                        return "玉虚洞玄石";
                    case 秘宝Type.加暴击伤害:
                        return "玉虚崩天印";
                    case 秘宝Type.加最终伤害:
                        return "玉虚寂灭轮";
                    case 秘宝Type.加掉宝:
                        return "玉虚福缘石";
                    case 秘宝Type.加跟脚:
                        return "玉虚造化根";
                    case 秘宝Type.加真灵:
                        return "玉虚真灵种";
                    case 秘宝Type.加轮回系数:
                        return "玉虚转生珠";
                }
                break;
        }

        return "";
    }

    public static QualityType Get秘宝品质(int 等级, 秘宝Type 秘宝Type)
    {
        switch (秘宝Type)
        {
            case 秘宝Type.暴击次数:
                return QualityType.荒品;
            case 秘宝Type.加全职业伤害:
                switch (等级)
                {
                    case 1:
                        return QualityType.天品;
                    case 2:
                        return QualityType.宇品;
                    case 3:
                        return QualityType.宙品;
                    case 4:
                        return QualityType.洪品;
                }
                break;
            
            case 秘宝Type.加全元素伤害:
                switch (等级)
                {
                    case 1:
                        return QualityType.天品;
                    case 2:
                        return QualityType.宇品;
                    case 3:
                        return QualityType.宙品;
                    case 4:
                        return QualityType.洪品;
                }
                break;
            
            case 秘宝Type.加暴击率:
                switch (等级)
                {
                    case 1:
                        return QualityType.天品;
                    case 2:
                        return QualityType.宇品;
                    case 3:
                        return QualityType.宙品;
                    case 4:
                        return QualityType.洪品;
                }
                break;
            
            case 秘宝Type.加暴击伤害:
                switch (等级)
                {
                    case 1:
                        return QualityType.天品;
                    case 2:
                        return QualityType.宇品;
                    case 3:
                        return QualityType.宙品;
                    case 4:
                        return QualityType.洪品;
                }
                break;
            
            case 秘宝Type.加最终伤害:
                switch (等级)
                {
                    case 1:
                        return QualityType.天品;
                    case 2:
                        return QualityType.宇品;
                    case 3:
                        return QualityType.宙品;
                    case 4:
                        return QualityType.洪品;
                }
                break;
            
            case 秘宝Type.加掉宝:
                switch (等级)
                {
                    case 1:
                        return QualityType.宇品;
                    case 2:
                        return QualityType.宙品;
                    case 3:
                        return QualityType.洪品;
                    case 4:
                        return QualityType.荒品;
                }
                break;
            
            case 秘宝Type.加跟脚:
                switch (等级)
                {
                    case 1:
                        return QualityType.宇品;
                    case 2:
                        return QualityType.宙品;
                    case 3:
                        return QualityType.洪品;
                    case 4:
                        return QualityType.荒品;
                }
                break;
            
            case 秘宝Type.加真灵:
                switch (等级)
                {
                    case 1:
                        return QualityType.宇品;
                    case 2:
                        return QualityType.宙品;
                    case 3:
                        return QualityType.洪品;
                    case 4:
                        return QualityType.荒品;
                }
                break;
            
            case 秘宝Type.加轮回系数:
                switch (等级)
                {
                    case 1:
                        return QualityType.宇品;
                    case 2:
                        return QualityType.宙品;
                    case 3:
                        return QualityType.洪品;
                    case 4:
                        return QualityType.荒品;
                }
                break;
        }
        return QualityType.None;
    }
    public static float Get气运(int 关卡数)
    {
        float value = 100;
        value += 10 * (关卡数 - 1);
        return  value;
    }
}
