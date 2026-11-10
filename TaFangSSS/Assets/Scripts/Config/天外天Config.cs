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
}

public class 秘宝
{
    public 秘宝地点 秘宝地点;
    public 秘宝Type 秘宝Type;
    public int 等级;
}
public class 天外天Config
{
    public float Get秘宝值(int 等级, 秘宝Type 秘宝Type)
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
}
