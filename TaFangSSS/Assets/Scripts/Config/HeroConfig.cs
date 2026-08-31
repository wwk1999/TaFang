using System.Collections.Generic;

namespace Config
{
    public class HeroData
    {
        public int Level;
        public int 元神;
        public bool 派遣;
        public 功法Type 功法Type;
        public int 功法等级;
        public float  功法经验;
        public int 功法星级;
        public 法器 武器 = null;
        public 法器 衣服 = null;
        public 法器 头盔 = null;
        public 法器 鞋子 = null;
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

    public class 英雄神通配置Item
    {
        public float cd;
        public float 能量;
        public float damage;
    }
    public class HeroConfig
    {
        public static HeroExp Get升星材料(QualityType qualityType, int xj)
        {
            HeroExp heroExp = new HeroExp();
            switch (qualityType)
            {
                case QualityType.黄品:
                    switch (xj)
                    {
                        case -1:
                            heroExp.Exp = 0;
                            heroExp.元神 = 1;
                            break;
                        case 0:
                            heroExp.Exp = 100;
                            heroExp.元神 = 1;
                            break;
                        case 1:
                            heroExp.Exp = 200;
                            heroExp.元神 = 2;
                            break;
                        case 2:
                            heroExp.Exp = 300;
                            heroExp.元神 = 3;
                            break;
                        case 3:
                            heroExp.Exp = 400;
                            heroExp.元神 = 4;
                            break;
                        case 4:
                            heroExp.Exp = 500;
                            heroExp.元神 = 5;
                            break;
                    }
                    break;
                
                case QualityType.玄品:
                    switch (xj)
                    {
                        case -1:
                            heroExp.Exp = 0;
                            heroExp.元神 = 1;
                            break;
                        case 0:
                            heroExp.Exp = 200;
                            heroExp.元神 = 1;
                            break;
                        case 1:
                            heroExp.Exp = 400;
                            heroExp.元神 = 2;
                            break;
                        case 2:
                            heroExp.Exp = 600;
                            heroExp.元神 = 3;
                            break;
                        case 3:
                            heroExp.Exp = 800;
                            heroExp.元神 = 4;
                            break;
                        case 4:
                            heroExp.Exp = 1000;
                            heroExp.元神 = 5;
                            break;
                    }
                    break;
                
                case QualityType.地品:
                    switch (xj)
                    {
                        case -1:
                            heroExp.Exp = 0;
                            heroExp.元神 = 1;
                            break;
                        case 0:
                            heroExp.Exp = 300;
                            heroExp.元神 = 1;
                            break;
                        case 1:
                            heroExp.Exp = 600;
                            heroExp.元神 = 2;
                            break;
                        case 2:
                            heroExp.Exp = 900;
                            heroExp.元神 = 3;
                            break;
                        case 3:
                            heroExp.Exp = 1200;
                            heroExp.元神 = 4;
                            break;
                        case 4:
                            heroExp.Exp = 1500;
                            heroExp.元神 = 5;
                            break;
                    }
                    break;
                
                case QualityType.天品:
                    switch (xj)
                    {
                        case -1:
                            heroExp.Exp = 0;
                            heroExp.元神 = 1;
                            break;
                        case 0:
                            heroExp.Exp = 500;
                            heroExp.元神 = 1;
                            break;
                        case 1:
                            heroExp.Exp = 1000;
                            heroExp.元神 = 2;
                            break;
                        case 2:
                            heroExp.Exp = 1500;
                            heroExp.元神 = 3;
                            break;
                        case 3:
                            heroExp.Exp = 2000;
                            heroExp.元神 = 4;
                            break;
                        case 4:
                            heroExp.Exp = 2500;
                            heroExp.元神 = 5;
                            break;
                    }
                    break;
                
                case QualityType.宇品:
                    switch (xj)
                    {
                        case -1:
                            heroExp.Exp = 0;
                            heroExp.元神 = 1;
                            break;
                        case 0:
                            heroExp.Exp = 800;
                            heroExp.元神 = 1;
                            break;
                        case 1:
                            heroExp.Exp = 1600;
                            heroExp.元神 = 2;
                            break;
                        case 2:
                            heroExp.Exp = 2400;
                            heroExp.元神 = 3;
                            break;
                        case 3:
                            heroExp.Exp = 3200;
                            heroExp.元神 = 4;
                            break;
                        case 4:
                            heroExp.Exp = 4000;
                            heroExp.元神 = 5;
                            break;
                    }
                    break;
                
                case QualityType.宙品:
                    switch (xj)
                    {
                        case -1:
                            heroExp.Exp = 0;
                            heroExp.元神 = 1;
                            break;
                        case 0:
                            heroExp.Exp = 1200;
                            heroExp.元神 = 1;
                            break;
                        case 1:
                            heroExp.Exp = 2400;
                            heroExp.元神 = 2;
                            break;
                        case 2:
                            heroExp.Exp = 3600;
                            heroExp.元神 = 3;
                            break;
                        case 3:
                            heroExp.Exp = 4800;
                            heroExp.元神 = 4;
                            break;
                        case 4:
                            heroExp.Exp = 6000;
                            heroExp.元神 = 5;
                            break;
                    }
                    break;
                
                case QualityType.洪品:
                    switch (xj)
                    {
                        case -1:
                            heroExp.Exp = 0;
                            heroExp.元神 = 1;
                            break;
                        case 0:
                            heroExp.Exp = 1800;
                            heroExp.元神 = 1;
                            break;
                        case 1:
                            heroExp.Exp = 3600;
                            heroExp.元神 = 2;
                            break;
                        case 2:
                            heroExp.Exp = 5400;
                            heroExp.元神 = 3;
                            break;
                        case 3:
                            heroExp.Exp = 7200;
                            heroExp.元神 = 4;
                            break;
                        case 4:
                            heroExp.Exp = 9000;
                            heroExp.元神 = 5;
                            break;
                    }
                    break;
                
                case QualityType.荒品:
                    switch (xj)
                    {
                        case -1:
                            heroExp.Exp = 0;
                            heroExp.元神 = 1;
                            break;
                        case 0:
                            heroExp.Exp = 3000;
                            heroExp.元神 = 1;
                            break;
                        case 1:
                            heroExp.Exp = 6000;
                            heroExp.元神 = 2;
                            break;
                        case 2:
                            heroExp.Exp = 9000;
                            heroExp.元神 = 3;
                            break;
                        case 3:
                            heroExp.Exp = 12000;
                            heroExp.元神 = 4;
                            break;
                        case 4:
                            heroExp.Exp = 15000;
                            heroExp.元神 = 5;
                            break;
                    }
                    break;
            }

            return heroExp;
        }

        public static Dictionary<QualityType, float> 升星奖励Dic = new Dictionary<QualityType, float>()
        {
            { QualityType.黄品, 1f },
            { QualityType.玄品, 2f },
            { QualityType.地品, 5f },
            { QualityType.天品, 10f },
            { QualityType.宇品, 20f },
            { QualityType.宙品, 50f },
            { QualityType.洪品, 100f },
            { QualityType.荒品, 300f },
        };
        public static string Get技能伤害string(float count, int addPercent = 0)
        {
            string numStr = count.ToString(); // 如 "0.3"
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char c in numStr)
            {
                sb.Append(c);
                sb.Append('\u200B'); // 每位后加零宽空格
            }
            // 若想去掉末尾多余的零宽空格，可加：if (sb.Length > 0) sb.Length--;

            // 根据参数决定是否追加百分号
            string suffix = "";
            switch (addPercent)
            {
                case 1:
                    suffix = "%";
                    break;
                case 2:
                    suffix = "S";
                    break;
            }

            return $"<color=green>{sb}{suffix}</color>";
        }

        public static string Get伤害str(string str)
        {
            return "<color=green>" + str + "</color>";
        }

        public static string Get元素string(YuanSuType type)
        {
            switch (type)
            {
                case YuanSuType.火:
                    return "<color=red>火焰</color>";
                case YuanSuType.冰:
                    return "<color=blue>冰霜</color>";
                case YuanSuType.黑暗:
                    return "<color=purple>黑暗</color>";
                case YuanSuType.物理:
                    return "<color=grey>物理</color>";
                case YuanSuType.电:
                    return "<color=yellow>雷电</color>";
            }

            return null;
        }

        public static string Get职业Name(ZhiYeType type)
        {
            switch (type)
            {
                case ZhiYeType.射手:
                    return "射手";
                case ZhiYeType.战士:
                    return "战士";
                case ZhiYeType.控制:
                    return "控制";
                case ZhiYeType.法师:
                    return "法师";
                case ZhiYeType.辅助:
                    return "辅助";
            }

            return null;
        }

        public static Dictionary<HeroType, List<string>> 英雄升星信息Dic = new Dictionary<HeroType, List<string>>()
        {
            {
                HeroType.丹童,
                new List<string>()
                {
                    $"技能伤害增加{Get伤害str("10%")}", 
                    $"技能冷却缩减增加{Get伤害str("10%")}", 
                    $"技能伤害增加{Get伤害str("15%")}", 
                    $"技能冷却缩减增加{Get伤害str("20%")}", 
                    $"技能伤害增加{Get伤害str("25%")}", 
                }
            },
            
            {
                HeroType.土地,
                new List<string>()
                {
                    $"技能击退距离增加{Get伤害str("10%")}", 
                    $"技能冷却缩减增加{Get伤害str("10%")}", 
                    $"技能伤害增加{Get伤害str("15%")}", 
                    $"技能冷却缩减增加{Get伤害str("20%")}", 
                    $"技能击退距离增加{Get伤害str("25%")}", 
                }
            },
            
            {
                HeroType.河伯,
                new List<string>()
                {
                    $"伤害增加{Get伤害str("10%")}", 
                    $"冷却缩减增加{Get伤害str("10%")}", 
                    $"伤害增加{Get伤害str("15%")}", 
                    $"冷却缩减增加{Get伤害str("20%")}", 
                    $"效果范围增加{Get伤害str("25%")}", 
                }
            },
            
            {
                HeroType.瑶池仙女,
                new List<string>()
                {
                    $"减速效果增加{Get伤害str("5%")}", 
                    $"冷却缩减增加{Get伤害str("10%")}", 
                    $"效果持续时间增加{Get伤害str("1S")}", 
                    $"减速效果增加{Get伤害str("10%")}", 
                    $"冷却缩减增加{Get伤害str("20%")}", 
                }
            },
            
            {
                HeroType.石敢当,
                new List<string>()
                {
                    $"破天锤伤害增加{Get伤害str("10%")}", 
                    $"破天锤冷却缩减增加{Get伤害str("10%")}", 
                    $"破天锤伤害增加{Get伤害str("15%")}", 
                    $"破天锤冷却缩减增加{Get伤害str("15%")}", 
                    $"破天锤效果范围增加{Get伤害str("20%")}", 
                }
            },
            
            {
                HeroType.玄女,
                new List<string>()
                {
                    $"七星连珠伤害增加{Get伤害str("10%")}", 
                    $"七星连珠冷却缩减增加{Get伤害str("10%")}", 
                    $"七星连珠伤害增加{Get伤害str("15%")}", 
                    $"七星连珠冷却缩减增加{Get伤害str("15%")}", 
                    $"七星连珠效果范围增加{Get伤害str("20%")}", 
                }
            },
            
            {
                HeroType.龟丞相,
                new List<string>()
                {
                    $"碎冰伤害增加{Get伤害str("10%")}", 
                    $"碎冰冷却缩减增加{Get伤害str("10%")}", 
                    $"碎冰减速效果增加{Get伤害str("5%")}", 
                    $"碎冰冷却缩减增加{Get伤害str("15%")}", 
                    $"碎冰减速效果增加{Get伤害str("10%")}", 
                }
            },
            
            {
                HeroType.太白金星,
                new List<string>()
                {
                    $"金星电闪伤害增加{Get伤害str("10%")}", 
                    $"金星电闪冷却缩减增加{Get伤害str("10%")}", 
                    $"金星电闪伤害增加{Get伤害str("15%")}", 
                    $"金星电闪冷却缩减增加{Get伤害str("15%")}", 
                    $"金星电闪伤害增加{Get伤害str("20%")}", 
                }
            },
            
            {
                HeroType.广目天王,
                new List<string>()
                {
                    $"暗影爪伤害增加{Get伤害str("10%")}", 
                    $"暗影爪冷却缩减增加{Get伤害str("15%")}", 
                    $"暗影爪伤害增加{Get伤害str("15%")}", 
                    $"暗影爪冷却缩减增加{Get伤害str("15%")}", 
                    $"暗影爪效果范围增加{Get伤害str("20%")}", 
                }
            },
            
            
            {
                HeroType.多闻天王,
                new List<string>()
                {
                    $"暗夜星矢伤害增加{Get伤害str("10%")}", 
                    $"暗夜星矢冷却缩减增加{Get伤害str("15%")}", 
                    $"暗夜星矢伤害增加{Get伤害str("15%")}", 
                    $"暗夜星矢冷却缩减增加{Get伤害str("20%")}", 
                    $"暗夜星矢伤害增加{Get伤害str("20%")}", 
                }
            },
            
            {
                HeroType.雷震子,
                new List<string>()
                {
                    $"雷霆万钧伤害增加{Get伤害str("10%")}", 
                    $"雷霆万钧冷却缩减增加{Get伤害str("15%")}", 
                    $"雷霆万钧伤害增加{Get伤害str("15%")}", 
                    $"雷霆万钧冷却缩减增加{Get伤害str("20%")}", 
                    $"雷霆万钧效果范围增加{Get伤害str("20%")}", 
                }
            },
            
            {
                HeroType.月老,
                new List<string>()
                {
                    $"红莲箭伤害增加{Get伤害str("10%")}", 
                    $"红莲箭冷却缩减增加{Get伤害str("15%")}", 
                    $"红莲箭伤害增加{Get伤害str("15%")}", 
                    $"红莲箭冷却缩减增加{Get伤害str("20%")}", 
                    $"红莲箭伤害增加{Get伤害str("25%")}", 
                }
            },
            
            {
                HeroType.嫦娥,
                new List<string>()
                {
                    $"月华雷殛伤害增加{Get伤害str("10%")}", 
                    $"月华雷殛冷却缩减增加{Get伤害str("15%")}", 
                    $"月华雷殛伤害增加{Get伤害str("15%")}", 
                    $"月华雷殛冷却缩减增加{Get伤害str("20%")}", 
                    $"月华雷殛效果范围增加{Get伤害str("20%")}", 
                }
            },
            
            {
                HeroType.杨戬,
                new List<string>()
                {
                    $"天眼电破伤害增加{Get伤害str("10%")}", 
                    $"天眼电破冷却缩减增加{Get伤害str("15%")}", 
                    $"天眼电破伤害增加{Get伤害str("15%")}", 
                    $"天眼电破冷却缩减增加{Get伤害str("20%")}", 
                    $"天眼电破数量增加{Get伤害str("1")},但伤害减少{Get伤害str("30%")}", 
                }
            },
            
            {
                HeroType.妲己,
                new List<string>()
                {
                    $"惑心魅惑效果增加{Get伤害str("5%")}", 
                    $"惑心魅惑冷却缩减增加{Get伤害str("15%")}", 
                    $"惑心魅惑持续时间增加{Get伤害str("1S")}", 
                    $"惑心魅惑冷却缩减增加{Get伤害str("20%")}", 
                    $"惑心魅惑效果增加{Get伤害str("10%")}", 
                }
            },
            
            {
                HeroType.牛魔王,
                new List<string>()
                {
                    $"蛮牛破伤害增加{Get伤害str("10%")}", 
                    $"蛮牛破冷却缩减增加{Get伤害str("15%")}", 
                    $"蛮牛破伤害增加{Get伤害str("15%")}", 
                    $"蛮牛破冷却缩减增加{Get伤害str("20%")}", 
                    $"蛮牛破效果范围增加{Get伤害str("20%")}", 
                }
            },
            
            {
                HeroType.哪吒,
                new List<string>()
                {
                    $"三味真火伤害增加{Get伤害str("10%")}", 
                    $"三味真火冷却缩减增加{Get伤害str("15%")}", 
                    $"三味真火伤害增加{Get伤害str("15%")}", 
                    $"三味真火冷却缩减增加{Get伤害str("20%")}", 
                    $"三味真火效果范围增加{Get伤害str("20%")}", 
                }
            },
            
            {
                HeroType.孙悟空,
                new List<string>()
                {
                    $"如意金箍棒伤害增加{Get伤害str("10%")}", 
                    $"如意金箍棒冷却缩减增加{Get伤害str("15%")}", 
                    $"如意金箍棒伤害增加{Get伤害str("15%")}", 
                    $"如意金箍棒挥棒次数增加{Get伤害str("1")}", 
                    $"如意金箍棒效果范围增加{Get伤害str("20%")}", 
                }
            },
            
            {
                HeroType.碧霄,
                new List<string>()
                {
                    $"冰龙啸天伤害增加{Get伤害str("10%")}", 
                    $"冰龙啸天冷却缩减增加{Get伤害str("15%")}", 
                    $"冰龙啸天伤害增加{Get伤害str("15%")}", 
                    $"冰龙啸天冷却缩减增加{Get伤害str("15%")}", 
                    $"冰龙啸天效果范围增加{Get伤害str("20%")}", 
                }
            },
            
            {
                HeroType.琼霄,
                new List<string>()
                {
                    $"暗影定身符伤害增加{Get伤害str("10%")}", 
                    $"暗影定身符冷却缩减增加{Get伤害str("10%")}", 
                    $"暗影定身符效果范围增加{Get伤害str("15%")}", 
                    $"暗影定身符伤害增加{Get伤害str("20%")}", 
                    $"暗影定身符定身时长增加{Get伤害str("0.5f")}", 
                }
            },
            
            {
                HeroType.羲和,
                new List<string>()
                {
                    $"烈日灼心阵伤害增加{Get伤害str("10%")}", 
                    $"烈日灼心阵冷却缩减增加{Get伤害str("10%")}", 
                    $"烈日灼心阵效果范围增加{Get伤害str("15%")}", 
                    $"烈日灼心阵伤害增加{Get伤害str("20%")}", 
                    $"烈日灼心阵灼烧伤害增加{Get伤害str("100%")}", 
                }
            },
            
            {
                HeroType.常羲,
                new List<string>()
                {
                    $"月华冰封阵伤害增加{Get伤害str("10%")}", 
                    $"月华冰封阵冷却缩减增加{Get伤害str("10%")}", 
                    $"月华冰封阵效果范围增加{Get伤害str("15%")}", 
                    $"月华冰封阵伤害增加{Get伤害str("20%")}", 
                    $"月华冰封阵减速效果增加{Get伤害str("15%")}", 
                }
            },
            
            {
                HeroType.后羿,
                new List<string>()
                {
                    $"射日神箭伤害增加{Get伤害str("10%")}", 
                    $"射日神箭冷却缩减增加{Get伤害str("15%")}", 
                    $"射日神箭数量增加{Get伤害str("1")}", 
                    $"射日神箭伤害增加{Get伤害str("20%")}", 
                    $"射日神箭数量增加{Get伤害str("1")}", 
                }
            },
            
            {
                HeroType.云霄,
                new List<string>()
                {
                    $"冰矢破空伤害增加{Get伤害str("10%")}", 
                    $"冰矢破空冷却缩减增加{Get伤害str("15%")}", 
                    $"冰矢破空伤害增加{Get伤害str("15%")}", 
                    $"冰矢破空冷却缩减增加{Get伤害str("20%")}", 
                    $"冰矢破空效果范围增加{Get伤害str("20%")}", 
                }
            },
            
            {
                HeroType.女娲,
                new List<string>()
                {
                    $"补天净化咒效果增加{Get伤害str("5%")}", 
                    $"补天净化咒冷却缩减增加{Get伤害str("15%")}", 
                    $"补天净化咒效果增加{Get伤害str("10%")}", 
                    $"补天净化咒冷却缩减增加{Get伤害str("15%")}", 
                    $"补天净化咒持续时间增加{Get伤害str("1S")}", 
                }
            },
            
            {
                HeroType.元始,
                new List<string>()
                {
                    $"鸿蒙火种伤害增加{Get伤害str("15%")}", 
                    $"鸿蒙火种持续时间增加{Get伤害str("1S")}", 
                    $"鸿蒙火种数量增加{Get伤害str("1")}", 
                    $"鸿蒙火种伤害增加{Get伤害str("20%")}", 
                    $"鸿蒙火种旋转速度增加{Get伤害str("25%")}", 
                }
            },
            
            {
                HeroType.老子,
                new List<string>()
                {
                    $"太清玄冰风伤害增加{Get伤害str("15%")}", 
                    $"太清玄冰风冷却缩减增加{Get伤害str("20%")}", 
                    $"太清玄冰风弹道速度减少{Get伤害str("20%")}", 
                    $"太清玄冰风伤害增加{Get伤害str("25%")}", 
                    $"太清玄冰风每秒增长速度增加{Get伤害str("5%")}", 
                }
            },
            
            {
                HeroType.通天,
                new List<string>()
                {
                    $"戮仙暗矢伤害增加{Get伤害str("15%")}", 
                    $"戮仙暗矢冷却缩减增加{Get伤害str("20%")}", 
                    $"戮仙暗矢数量增加{Get伤害str("1")}", 
                    $"戮仙暗矢伤害增加{Get伤害str("20%")}", 
                    $"戮仙暗矢数量增加{Get伤害str("1")}", 
                }
            },
            
            {
                HeroType.鸿钧,
                new List<string>()
                {
                    $"无极天火伤害增加{Get伤害str("20%")}", 
                    $"无极天火冷却缩减增加{Get伤害str("25%")}", 
                    $"无极天火数量增加{Get伤害str("1")}", 
                    $"无极天火效果范围增加{Get伤害str("20%")}", 
                    $"无极天火数量增加{Get伤害str("2")}", 
                }
            },
            
            {
                HeroType.盘古,
                new List<string>()
                {
                    $"混沌开天拳伤害增加{Get伤害str("20%")}", 
                    $"混沌开天拳冷却缩减增加{Get伤害str("20%")}", 
                    $"混沌开天拳出拳数量增加{Get伤害str("1")}", 
                    $"混沌开天拳伤害增加{Get伤害str("25%")}", 
                    $"混沌开天拳数量增加{Get伤害str("2")}", 
                }
            },
        };
        
        public static readonly Dictionary<HeroType, string> SkillNameDic = new Dictionary<HeroType, string>
        {
            { HeroType.None, "无" },

            // ---- 下界 / 初级仙灵 ----
            { HeroType.丹童, "丹火流星" }, // 射手·火
            { HeroType.土地, "暗影弹" }, // 控制·黑暗
            { HeroType.河伯, "冰锥刺" }, // 法师·冰
            { HeroType.瑶池仙女, "瑶池冰露" }, // 辅助·冰

            // ---- 地仙 / 散仙 ----
            { HeroType.石敢当, "石破天惊" }, // 战士·物理
            { HeroType.玄女, "七星连珠" }, // 法师·电
            { HeroType.龟丞相, "碎冰" }, // 控制·冰
            { HeroType.太白金星, "金星电闪" }, // 射手·电

            // ---- 天王 / 星官 ----
            { HeroType.多闻天王, "暗夜星矢" }, // 射手·黑暗
            { HeroType.广目天王, "暗影爪" }, // 战士·黑暗
            { HeroType.雷震子, "雷霆万钧" }, // 法师·电
            { HeroType.月老, "红莲箭" }, // 射手·火

            // ---- 大能 / 妖族 ----
            { HeroType.嫦娥, "月华雷殛" }, // 法师·电
            { HeroType.杨戬, "天眼电破" }, // 射手·电
            { HeroType.妲己, "惑心魅惑" }, // 辅助·黑暗
            { HeroType.牛魔王, "蛮牛破" }, // 战士·物理

            // ---- 封神 / 斗士 ----
            { HeroType.哪吒, "三昧真火" }, // 战士·火
            { HeroType.孙悟空, "如意金箍棒" }, // 战士·物理
            { HeroType.碧霄, "冰龙啸天" }, // 法师·冰
            { HeroType.琼霄, "暗影定身符" }, // 控制·黑暗
    
            // ---- 上古神明 ----
            { HeroType.羲和, "烈日灼心阵" }, // 法师·火（日母）
            { HeroType.常羲, "月华冰封阵" }, // 控制·冰（月母）
            { HeroType.后羿, "射日神箭" }, // 射手·物理
            { HeroType.云霄, "冰矢破空" }, // 射手·冰

            // ---- 创世 / 圣贤 ----
            { HeroType.女娲, "补天净化咒" }, // 辅助·电（炼石补天，雷电交加）
            { HeroType.老子, "太清玄冰风" }, // 法师·冰（炼丹紫气，玄冰为引）
            { HeroType.元始, "鸿蒙火种" }, // 战士·火（开天辟地之初火）
            { HeroType.通天, "戮仙暗矢" }, // 射手·黑暗（诛仙剑阵化箭）

            // ---- 天道 / 终极 ----
            { HeroType.鸿钧, "无极天火" }, // 法师·火（天道化身，万火之源）
            { HeroType.盘古, "混沌开天拳" } // 战士·物理（至强之力，宇宙创生）
        };
        public static Dictionary<HeroType, List<float>> HeroSkillDamageDic = new Dictionary<HeroType, List<float>>()
        {
            { HeroType.丹童, new List<float>() { 70 } },
            { HeroType.土地, new List<float>() { 50, 0.3f } },
            { HeroType.河伯, new List<float>() { 90 } },
            { HeroType.瑶池仙女, new List<float>() { 15, 2 } },

            { HeroType.石敢当, new List<float>() { 100 } },
            { HeroType.玄女, new List<float>() { 150 } },
            { HeroType.龟丞相, new List<float>() { 100, 15 } },
            { HeroType.太白金星, new List<float>() { 100 } },

            { HeroType.多闻天王, new List<float>() { 130 } },
            { HeroType.广目天王, new List<float>() { 150 } },
            { HeroType.雷震子, new List<float>() { 200 } },
            { HeroType.月老, new List<float>() { 130 } },

            { HeroType.嫦娥, new List<float>() { 260 } },
            { HeroType.杨戬, new List<float>() { 140 } },
            { HeroType.妲己, new List<float>() { 20, 2 } },
            { HeroType.牛魔王, new List<float>() { 300 } },

            { HeroType.哪吒, new List<float>() { 210 } },
            { HeroType.孙悟空, new List<float>() { 250 } },
            { HeroType.碧霄, new List<float>() { 350 } },
            { HeroType.琼霄, new List<float>() { 250, 1 } },

            { HeroType.羲和, new List<float>() { 300, 100, 3 } },
            { HeroType.常羲, new List<float>() { 300, 20, 2 } },
            { HeroType.后羿, new List<float>() { 300 } },
            { HeroType.云霄, new List<float>() { 300 } },

            { HeroType.女娲, new List<float>() { 20, 3 } },
            { HeroType.老子, new List<float>() { 300 ,5} },
            { HeroType.元始, new List<float>() { 300 ,3} },
            { HeroType.通天, new List<float>() { 400 } },

            { HeroType.鸿钧, new List<float>() { 600 } },
            { HeroType.盘古, new List<float>() { 600 } },

        };

        public static Dictionary<HeroType, string> HeroSkillInfoDic = new Dictionary<HeroType, string>()
        {
            {
                HeroType.丹童,
                "向怪物发出火焰弹，造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.丹童][0], 1) + "的" + Get元素string(YuanSuType.火) +
                "伤害"
            },
            {
                HeroType.土地,
                "向怪物发出暗影弹，造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.土地][0], 1) + "的" +
                Get元素string(YuanSuType.黑暗) + "伤害,并击退敌人" + Get技能伤害string(HeroSkillDamageDic[HeroType.土地][1])
            },
            {
                HeroType.河伯,
                "向怪物发出冰刺冲击，造成2段伤害,每段" + Get技能伤害string(HeroSkillDamageDic[HeroType.河伯][0], 1) + "的" +
                Get元素string(YuanSuType.冰) + "伤害"
            },
            {
                HeroType.瑶池仙女,
                "给随机一位英雄添加持续" + Get技能伤害string(HeroSkillDamageDic[HeroType.瑶池仙女][1], 2) + "的冰霜印记,携带冰霜印记的英雄攻击造成" +
                Get技能伤害string(HeroSkillDamageDic[HeroType.瑶池仙女][0], 1) + "的减速效果,持续" +
                Get技能伤害string(2, 2)
            },

            {
                HeroType.石敢当,
                "向怪物投掷破天锤,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.石敢当][0], 1) + "的" +
                Get元素string(YuanSuType.物理) + "伤害"
            },
            {
                HeroType.玄女,
                "对怪物释放七星阵,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.玄女][0], 1) + "的" +
                Get元素string(YuanSuType.电) + "伤害"
            },
            {
                HeroType.龟丞相,
                "对怪物释放碎冰术,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.龟丞相][0], 1) + "的" +
                Get元素string(YuanSuType.冰) + "伤害,并附加" + Get技能伤害string(HeroSkillDamageDic[HeroType.龟丞相][1], 1) +
                "的减速效果,持续" + Get技能伤害string(2, 2)
            },
            {
                HeroType.太白金星,
                "向怪物发出雷霆弹，造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.太白金星][0], 1) + "的" +
                Get元素string(YuanSuType.电) + "伤害"
            },

            {
                HeroType.广目天王,
                "下场靠近怪物,释放暗影爪,造成2段伤害,每段造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.广目天王][0], 1) + "的" +
                Get元素string(YuanSuType.黑暗) + "伤害"
            },
            {
                HeroType.多闻天王,
                "向怪物发出暗影弹,造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.多闻天王][0], 1) + "的" +
                Get元素string(YuanSuType.黑暗) + "伤害"
            },
            {
                HeroType.雷震子,
                "对怪物释放天雷,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.雷震子][0], 1) + "的" +
                Get元素string(YuanSuType.电) + "伤害"
            },
            {
                HeroType.月老,
                "对怪物释放红莲箭,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.月老][0], 1) + "的" +
                Get元素string(YuanSuType.火) + "伤害"
            },

            {
                HeroType.嫦娥,
                "对怪物释放月华雷,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.嫦娥][0], 1) + "的" +
                Get元素string(YuanSuType.电) + "伤害"
            },
            {
                HeroType.杨戬,
                "向怪物释放天眼破并穿透敌人,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.杨戬][0], 1) + "的" +
                Get元素string(YuanSuType.电) + "伤害"
            },
            {
                HeroType.妲己,
                "对随机一名英雄施加魅惑,提升该英雄" + Get技能伤害string(HeroSkillDamageDic[HeroType.妲己][0], 1) + "的伤害,并持续" +
                Get技能伤害string(HeroSkillDamageDic[HeroType.妲己][1], 2)
            },
            {
                HeroType.牛魔王,
                "下场靠近怪物,释放蛮牛爆,对命中敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.牛魔王][0], 1) + "的" +
                Get元素string(YuanSuType.物理) + "伤害"
            },

            {
                HeroType.哪吒,
                "下场靠近怪物,吐出三味真火,对命中敌人造成4段" + Get技能伤害string(HeroSkillDamageDic[HeroType.哪吒][0], 1) + "的" +
                Get元素string(YuanSuType.火) + "伤害"
            },
            {
                HeroType.孙悟空,
                "下场靠近怪物,挥动如意金箍棒,对命中敌人造成2段" + Get技能伤害string(HeroSkillDamageDic[HeroType.孙悟空][0], 1) + "的" +
                Get元素string(YuanSuType.物理) + "伤害"
            },
            {
                HeroType.碧霄,
                "向怪物释放冰龙啸天,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.碧霄][0], 1) + "的" +
                Get元素string(YuanSuType.冰) + "伤害"
            },
            {
                HeroType.琼霄,
                "向怪物释放暗影定身符,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.琼霄][0], 1) + "的" +
                Get元素string(YuanSuType.黑暗) + "伤害,并定身敌人" + Get技能伤害string(HeroSkillDamageDic[HeroType.琼霄][1], 2)+",对相同敌人的定身时间每次衰减10%"
            },

            {
                HeroType.羲和,
                "向怪物释放烈日灼心阵,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.羲和][0], 1) + "的" +
                Get元素string(YuanSuType.火) + "伤害,并施加灼烧效果，每秒对敌人造成" +
                Get技能伤害string(HeroSkillDamageDic[HeroType.羲和][1], 1) + "的" + Get元素string(YuanSuType.火) + "伤害,持续" +
                Get技能伤害string(HeroSkillDamageDic[HeroType.羲和][2], 2)
            },
            {
                HeroType.常羲,
                "向怪物释放月华冰封阵,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.常羲][0], 1) + "的" +
                Get元素string(YuanSuType.冰) + "伤害,并施加" + Get技能伤害string(HeroSkillDamageDic[HeroType.羲和][1], 1) +
                "的减速效果，持续" + Get技能伤害string(HeroSkillDamageDic[HeroType.羲和][2], 2)
            },
            {
                HeroType.后羿,
                "向怪物发射2支射日箭并穿透敌人,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.后羿][0], 1) + "的" +
                Get元素string(YuanSuType.物理) + "伤害"
            },
            {
                HeroType.云霄,
                "向怪物发射冰矢剑气并穿透敌人,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.云霄][0], 1) + "的" +
                Get元素string(YuanSuType.冰) + "伤害"
            },

            {
                HeroType.女娲,
                "对所有英雄施加补天净化咒，提高所有英雄" + Get技能伤害string(HeroSkillDamageDic[HeroType.女娲][0], 1) + "的冷却缩减,持续" +
                Get技能伤害string(HeroSkillDamageDic[HeroType.女娲][1], 2)
            },
            {
                HeroType.老子,
                "向怪物释放太清玄冰风,对命中的敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.老子][0], 1) + "的" +
                Get元素string(YuanSuType.冰) + "伤害,并每秒体积增加" + Get技能伤害string(HeroSkillDamageDic[HeroType.老子][1], 1)
            },
            {
                HeroType.元始,
                "下场靠近怪物,释放鸿蒙火种围绕自身,对命中敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.元始][0], 1) + "的" +
                Get元素string(YuanSuType.火) + "伤害"
            },
            {
                HeroType.通天,
                "向怪物释放2道戮仙暗矢,对命中敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.通天][0], 1) + "的" +
                Get元素string(YuanSuType.黑暗) + "伤害"
            },

            {
                HeroType.鸿钧,
                "召唤3道无极天火,对命中敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.鸿钧][0], 1) + "的" +
                Get元素string(YuanSuType.火) + "伤害"
            },
            {
                HeroType.盘古,
                "下场靠近怪物,施放2道混沌开天拳,对命中敌人造成" + Get技能伤害string(HeroSkillDamageDic[HeroType.盘古][0], 1) + "的" +
                Get元素string(YuanSuType.物理) + "伤害"
            },
        };
        

        public static Dictionary<HeroType, float> HeroAttackTimeDic = new Dictionary<HeroType, float>()
        {
            { HeroType.丹童, 1.5f },
            { HeroType.土地, 1.5f },
            { HeroType.河伯, 3 },
            { HeroType.瑶池仙女, 5 },

            { HeroType.石敢当, 2 },
            { HeroType.玄女, 3 },
            { HeroType.龟丞相, 3 },
            { HeroType.太白金星, 1.5f },

            { HeroType.多闻天王, 1 },
            { HeroType.广目天王, 1f },
            { HeroType.雷震子, 3 },
            { HeroType.月老, 1.5f },

            { HeroType.嫦娥, 3 },
            { HeroType.杨戬, 1.5f },
            { HeroType.妲己, 5 },
            { HeroType.牛魔王, 1.2f },

            { HeroType.哪吒, 1f },
            { HeroType.孙悟空, 1f },
            { HeroType.碧霄, 3 },
            { HeroType.琼霄, 3 },

            { HeroType.羲和, 3 },
            { HeroType.常羲, 3 },
            { HeroType.后羿, 1.5f },
            { HeroType.云霄, 1.5f },

            { HeroType.女娲, 6 },
            { HeroType.老子, 3 },
            { HeroType.通天, 1.5f },
            { HeroType.元始, 1f },

            { HeroType.盘古, 1f },
            { HeroType.鸿钧, 3 },

        };
        public static Dictionary<HeroType, 英雄神通配置Item> 英雄神通配置Dic = new Dictionary<HeroType, 英雄神通配置Item>()
        {
            { HeroType.丹童, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.土地, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.河伯, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.瑶池仙女, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },

            { HeroType.石敢当, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.玄女, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.龟丞相,new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.太白金星, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },

            { HeroType.多闻天王, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.广目天王, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.雷震子, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.月老, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },

            { HeroType.嫦娥, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.杨戬, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.妲己, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.牛魔王, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },

            { HeroType.哪吒, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.孙悟空, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.碧霄, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.琼霄, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },

            { HeroType.羲和, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.常羲, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.后羿, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.云霄, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },

            { HeroType.女娲, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.老子, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.通天, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.元始, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100}},

            { HeroType.盘古, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },
            { HeroType.鸿钧, new 英雄神通配置Item(){cd = 5,能量 = 25,damage = 100} },

        };

        public static Dictionary<HeroType, HeroSkill> HeroSkillDic = new Dictionary<HeroType, HeroSkill>()
        {
            {
                HeroType.丹童, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.普通火魔法弹,攻击特效Type.丹童神通 },
                    PengList = new List<PengType>() { PengType.火虎魔法弹Peng }
                }
            },
            {
                HeroType.土地, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.黑暗魔法弹,攻击特效Type.土地神通 },
                    PengList = new List<PengType>() { PengType.黑暗魔法弹Peng }
                }
            },

            {
                HeroType.河伯, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.冰刺,攻击特效Type.河伯神通 },
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
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.石敢当锤子 ,攻击特效Type.石敢当神通},
                    PengList = new List<PengType>()
                }
            },
            {
                HeroType.玄女, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.玄女技能 ,攻击特效Type.玄女神通},
                    PengList = new List<PengType>()
                }
            },
            {
                HeroType.龟丞相, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.龟丞相技能 ,攻击特效Type.龟丞相神通},
                    PengList = new List<PengType>()
                }
            },
            {
                HeroType.太白金星, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.电魔法弹 ,攻击特效Type.太白金星神通},
                    PengList = new List<PengType>() { PengType.电魔法弹Peng }
                }
            },
            {
                HeroType.多闻天王, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.黑暗花魔法弹 ,攻击特效Type.多闻天王神通},
                    PengList = new List<PengType>() { PengType.黑暗花魔法弹Peng }
                }
            },
            {
                HeroType.雷震子, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.落雷 ,攻击特效Type.雷震子神通},
                    PengList = new List<PengType>() { }
                }
            },
            {
                HeroType.月老, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.火虎魔法弹 ,攻击特效Type.月老神通},
                    PengList = new List<PengType>() { PengType.火虎魔法弹Peng }
                }
            },
            {
                HeroType.嫦娥, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.嫦娥技能 ,攻击特效Type.嫦娥神通},
                    PengList = new List<PengType>() { }
                }
            },
            {
                HeroType.杨戬, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.电龙魔法弹 ,攻击特效Type.杨戬神通},
                    PengList = new List<PengType>() { PengType.电龙魔法弹Peng }
                }
            },
            {
                HeroType.妲己, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.黑暗辅助 },
                    PengList = new List<PengType>() { }
                }
            },
            {
                HeroType.牛魔王, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.牛魔王技能 ,攻击特效Type.牛魔王神通},
                    PengList = new List<PengType>() { }
                }
            },
            {
                HeroType.哪吒, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.喷火 ,攻击特效Type.哪吒神通},
                    PengList = new List<PengType>() { }
                }
            },
            {
                HeroType.孙悟空, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.孙悟空棒子 ,攻击特效Type.孙悟空神通},
                    PengList = new List<PengType>() { PengType.火虎魔法弹Peng }
                }
            },
            {
                HeroType.碧霄, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.冰龙 ,攻击特效Type.碧霄神通},
                    PengList = new List<PengType>() { }
                }
            },
            {
                HeroType.琼霄, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.黑暗符 ,攻击特效Type.琼霄神通},
                    PengList = new List<PengType>() { }
                }
            },
            {
                HeroType.后羿, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.物理箭 ,攻击特效Type.后羿神通},
                    PengList = new List<PengType>() { PengType.物理箭Peng }
                }
            },
            {
                HeroType.常羲, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.冰符 ,攻击特效Type.常曦神通},
                    PengList = new List<PengType>() { }
                }
            },
            {
                HeroType.羲和, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.火符 ,攻击特效Type.羲和神通},
                    PengList = new List<PengType>() { }
                }
            },
            {
                HeroType.云霄, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.冰剑气 ,攻击特效Type.云霄神通},
                    PengList = new List<PengType>() { PengType.冰大魔法弹Peng }
                }
            },
            {
                HeroType.老子, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.冰旋风 ,攻击特效Type.老子神通},
                    PengList = new List<PengType>() { PengType.冰大魔法弹Peng }
                }
            },

            {
                HeroType.元始, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.火球 ,攻击特效Type.元始神通},
                    PengList = new List<PengType>() { PengType.火虎魔法弹Peng }
                }
            },

            {
                HeroType.通天, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.黑暗剑气 ,攻击特效Type.通天神通},
                    PengList = new List<PengType>() { PengType.黑暗剑气Peng }
                }
            },

            {
                HeroType.盘古, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.盘古拳 ,攻击特效Type.盘古神通},
                    PengList = new List<PengType>() { }
                }
            },

            {
                HeroType.鸿钧, new HeroSkill()
                {
                    攻击特效List = new List<攻击特效Type>() { 攻击特效Type.陨石 ,攻击特效Type.鸿钧神通},
                    PengList = new List<PengType>() { }
                }
            },
        };

        public static Dictionary<ZhiYeType, float> 攻击范围Dic = new Dictionary<ZhiYeType, float>()
        {
            { ZhiYeType.战士, 10 },
            { ZhiYeType.法师, 12 },
            { ZhiYeType.辅助, 10 },
            { ZhiYeType.控制, 12 },
            { ZhiYeType.射手, 14 },
        };

        public static Dictionary<int, string> SuoTipDic = new Dictionary<int, string>()
        {
            { 2, "筑基解锁" },
            { 3, "金丹解锁" },
            { 4, "元婴解锁" },
            { 5, "化神解锁" },
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
            { HeroType.羲和, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.法师, yuanSuType = YuanSuType.火 } }, // 日母
            { HeroType.云霄, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.射手, yuanSuType = YuanSuType.冰 } }, // 三霄

            { HeroType.女娲, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.辅助, yuanSuType = YuanSuType.电 } }, // 炼石补天
            { HeroType.老子, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.法师, yuanSuType = YuanSuType.冰 } }, // 炼丹
            { HeroType.元始, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.战士, yuanSuType = YuanSuType.火 } }, // 盘古元神，力量
            { HeroType.通天, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.射手, yuanSuType = YuanSuType.黑暗 } },

            { HeroType.鸿钧, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.法师, yuanSuType = YuanSuType.火 } }, // 天道雷霆
            { HeroType.盘古, new HeroZhiYeYuanSu { zhiYeType = ZhiYeType.战士, yuanSuType = YuanSuType.物理 } } // 开天辟地，纯粹力量
        };

        

        public static Dictionary<QualityType, List<HeroType>> QualityHeroDic =
            new Dictionary<QualityType, List<HeroType>>()
            {
                {
                    QualityType.黄品,
                    new List<HeroType>()
                        { HeroType.丹童, HeroType.土地, HeroType.河伯, HeroType.瑶池仙女 }
                },
                {
                    QualityType.玄品,
                    new List<HeroType>()
                        { HeroType.石敢当, HeroType.玄女, HeroType.龟丞相, HeroType.太白金星 }
                },
                {
                    QualityType.地品,
                    new List<HeroType>()
                        { HeroType.多闻天王, HeroType.广目天王, HeroType.雷震子, HeroType.月老 }
                },
                {
                    QualityType.天品,
                    new List<HeroType>() { HeroType.嫦娥, HeroType.杨戬, HeroType.妲己, HeroType.牛魔王 }
                },
                {
                    QualityType.宇品,
                    new List<HeroType>() { HeroType.哪吒, HeroType.孙悟空, HeroType.碧霄, HeroType.琼霄 }
                },
                {
                    QualityType.宙品,
                    new List<HeroType>() { HeroType.羲和, HeroType.常羲, HeroType.后羿, HeroType.云霄 }
                },
                { QualityType.洪品, new List<HeroType>() { HeroType.女娲, HeroType.老子, HeroType.通天, HeroType.元始 } },
                { QualityType.荒品, new List<HeroType>() { HeroType.盘古, HeroType.鸿钧 } },
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