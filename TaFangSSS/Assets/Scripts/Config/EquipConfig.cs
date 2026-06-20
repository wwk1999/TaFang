 using Config;

 public enum EquipType
 {
  None,
  衣服,
  头盔,
  鞋子,
  护手,
  戒指,
  项链,
 }
public class EquipConfig
{
    public static QualityType GetEquipQuality(int level)
    {
        if (level <= 20)
        {
            return QualityType.黄品;
        }else if (level <= 40)
        {
            return QualityType.玄品;
        }else if (level <= 60)
        {
            return QualityType.地品;
        }else if (level <= 80)
        {
            return QualityType.天品;
        }else if (level <= 100)
        {
            return QualityType.宇品;
        }else if (level <= 120)
        {
            return QualityType.宙品;
        }else if (level <= 140)
        {
            return QualityType.洪品;
        }else if (level <= 40)
        {
            return QualityType.荒品;
        }
        return QualityType.None;
    }
}
