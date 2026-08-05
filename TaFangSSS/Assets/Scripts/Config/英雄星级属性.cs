using Config;

public class 英雄星级属性
{
    public static float Get英雄Cd(HeroType heroType)
    {
        switch (heroType)
        {
            case HeroType.丹童:          return 丹童Cd;
            case HeroType.土地:          return 土地Cd;
            case HeroType.河伯:          return 河伯Cd;
            case HeroType.瑶池仙女:      return 瑶池仙女Cd;
            case HeroType.石敢当:        return 石敢当Cd;
            case HeroType.玄女:          return 玄女Cd;
            case HeroType.龟丞相:        return 龟丞相Cd;
            case HeroType.太白金星:      return 太白金星Cd;
            case HeroType.多闻天王:      return 多闻天王Cd;
            case HeroType.广目天王:      return 广目天王Cd;
            case HeroType.雷震子:        return 雷震子Cd;
            case HeroType.月老:          return 月老Cd;
            case HeroType.嫦娥:          return 嫦娥Cd;
            case HeroType.杨戬:          return 杨戬Cd;
            case HeroType.妲己:          return 妲己Cd;
            case HeroType.牛魔王:        return 牛魔王Cd;
            case HeroType.哪吒:          return 哪吒Cd;
            case HeroType.孙悟空:        return 孙悟空Cd;
            case HeroType.碧霄:          return 碧霄Cd;
            case HeroType.琼霄:          return 琼霄Cd;
            case HeroType.羲和:          return 羲和Cd;
            case HeroType.常羲:          return 常曦Cd;
            case HeroType.后羿:          return 后羿Cd;
            case HeroType.云霄:          return 云霄Cd;
            case HeroType.女娲:          return 女娲Cd;
            case HeroType.老子:          return 老子Cd;
            case HeroType.通天:          return 通天Cd;
            case HeroType.元始:          return 元始Cd;
            case HeroType.鸿钧:          return 鸿钧Cd;
            case HeroType.盘古:          return 盘古Cd;
            case HeroType.None:
            default:
                return 9999f;            
        }
    }
    
    public static float Get英雄攻击数值(HeroType heroType)    
    {
        switch (heroType)
        {
            case HeroType.丹童:          return 丹童攻击数值;
            case HeroType.土地:          return 土地攻击数值;
            case HeroType.河伯:          return 河伯攻击数值;
            case HeroType.石敢当:        return 石敢当攻击数值;
            case HeroType.玄女:          return 玄女攻击数值;
            case HeroType.龟丞相:        return 龟丞相攻击数值;
            case HeroType.太白金星:      return 太白金星攻击数值;
            case HeroType.多闻天王:      return 多闻天王攻击数值;
            case HeroType.广目天王:      return 广目天王攻击数值;
            case HeroType.雷震子:        return 雷震子攻击数值;
            case HeroType.月老:          return 月老攻击数值;
            case HeroType.嫦娥:          return 嫦娥攻击数值;
            case HeroType.杨戬:          return 杨戬攻击数值;
            case HeroType.牛魔王:        return 牛魔王攻击数值;
            case HeroType.哪吒:          return 哪吒攻击数值;
            case HeroType.孙悟空:        return 孙悟空攻击数值;
            case HeroType.碧霄:          return 碧霄攻击数值;
            case HeroType.琼霄:          return 琼霄攻击数值;
            case HeroType.羲和:          return 羲和攻击数值;
            case HeroType.常羲:          return 常曦攻击数值;
            case HeroType.后羿:          return 后羿攻击数值;
            case HeroType.云霄:          return 云霄攻击数值;
            case HeroType.老子:          return 老子攻击数值;
            case HeroType.通天:          return 通天攻击数值;
            case HeroType.元始:          return 元始攻击数值;
            case HeroType.鸿钧:          return 鸿钧攻击数值;
            case HeroType.盘古:          return 盘古攻击数值;
            case HeroType.None:
            default:
                return 0f;
        }
    }

    
    public static float 丹童攻击数值 => Get丹童攻击数值();
    public static float 丹童Cd=> Get丹童Cd();
    public static float 土地击退距离 => Get土地击退距离();
    public static float 土地攻击数值 => Get土地攻击数值();
    public static float 土地Cd=> Get土地Cd();

    public static float 河伯攻击数值 => Get河伯攻击数值();
    public static float 河伯Cd=> Get河伯Cd();
    public static float 河伯效果范围=> Get河伯效果范围();
    
    public static float 瑶池仙女Cd=> Get瑶池仙女Cd();
    public static float 瑶池仙女持续时间=> Get瑶池仙女持续时间();
    public static float 瑶池仙女减速效果=> Get瑶池仙女减速效果();
    
    public static float 石敢当攻击数值 => Get石敢当攻击数值();
    public static float 石敢当Cd=> Get石敢当Cd();
    public static float 石敢当效果范围=> Get石敢当效果范围();
    
    public static float 玄女攻击数值 => Get玄女攻击数值();
    public static float 玄女Cd=> Get玄女Cd();
    public static float 玄女效果范围=> Get玄女效果范围();
    
    public static float 龟丞相攻击数值 => Get龟丞相攻击数值();
    public static float 龟丞相Cd=> Get龟丞相Cd();
    public static float 龟丞相减速效果 => Get龟丞相减速效果();
    
    public static float 太白金星攻击数值 => Get太白金星攻击数值();
    public static float 太白金星Cd=> Get太白金星Cd();
    
    
    public static float 多闻天王攻击数值 => Get多闻天王攻击数值();
    public static float 多闻天王Cd=> Get多闻天王Cd();
    
    
    public static float 广目天王攻击数值 => Get广目天王攻击数值();
    public static float 广目天王Cd=> Get广目天王Cd();
    public static float 广目天王效果范围=> Get广目天王效果范围();
    
    
    public static float 雷震子攻击数值 => Get雷震子攻击数值();
    public static float 雷震子Cd=> Get雷震子Cd();
    public static float 雷震子效果范围=> Get雷震子效果范围();
    
    public static float 月老攻击数值 => Get月老攻击数值();
    public static float 月老Cd=> Get月老Cd();
    
    
    public static float 嫦娥攻击数值 => Get嫦娥攻击数值();
    public static float 嫦娥Cd=> Get嫦娥Cd();
    public static float 嫦娥效果范围=> Get嫦娥效果范围();
    
    public static float 杨戬攻击数值 => Get杨戬攻击数值();
    public static float 杨戬Cd=> Get杨戬Cd();
    public static float 杨戬攻击数量 => Get杨戬攻击数量();


    public static float 妲己Cd=> Get妲己Cd();
    public static float 妲己持续时间=> Get妲己持续时间();
    public static float 妲己效果=> Get妲己效果();
    
    public static float 牛魔王攻击数值 => Get牛魔王攻击数值();
    public static float 牛魔王Cd=> Get牛魔王Cd();
    public static float 牛魔王效果范围=> Get牛魔王效果范围();
    
    public static float 哪吒攻击数值 => Get哪吒攻击数值();
    public static float 哪吒Cd=> Get哪吒Cd();
    public static float 哪吒效果范围=> Get哪吒效果范围();
    
    public static float 孙悟空攻击数值 => Get孙悟空攻击数值();
    public static float 孙悟空Cd=> Get孙悟空Cd();
    public static float 孙悟空效果范围=> Get孙悟空效果范围();
    public static int 孙悟空次数=> Get孙悟空次数();

    public static float 孙悟空每次下场伤害 => Get孙悟空每次下场伤害();
    
    
    public static float 碧霄攻击数值 => Get碧霄攻击数值();
    public static float 碧霄Cd=> Get碧霄Cd();
    public static float 碧霄效果范围=> Get碧霄效果范围();
    
    
    
    public static float 琼霄攻击数值 => Get琼霄攻击数值();
    public static float 琼霄Cd=> Get琼霄Cd();
    public static float 琼霄效果范围=> Get琼霄效果范围();
    public static float 琼霄定身时长=> Get琼霄琼霄定身时长();

    
    public static float 羲和攻击数值 => Get羲和攻击数值();
    public static float 羲和Cd=> Get羲和Cd();
    public static float 羲和效果范围=> Get羲和效果范围();
    public static float 羲和灼烧伤害=> Get羲和灼烧伤害();
    public static float 羲和灼烧叠加伤害=> Get羲和灼烧叠加伤害();

    
    public static float 常曦攻击数值 => Get常曦攻击数值();
    public static float 常曦Cd=> Get常曦Cd();
    public static float 常曦效果范围=> Get常曦效果范围();
    public static float 常曦减速效果=> Get常曦减速效果();
    
    
    public static float 后羿攻击数值 => Get后羿攻击数值();
    public static float 后羿Cd=> Get后羿Cd();
    public static float 后羿攻击数量 => Get后羿攻击数量();
    public static float 后羿连射概率 => Get后羿连射概率();

    
    public static float 云霄攻击数值 => Get云霄攻击数值();
    public static float 云霄Cd=> Get云霄Cd();
    public static float 云霄效果范围=> Get云霄效果范围();
    
    
    public static float 女娲Cd=> Get女娲Cd();
    public static float 女娲持续时间=> Get女娲持续时间();
    public static float 女娲效果=> Get女娲冷却缩减效果();
    public static float 女娲辅助伤害=> Get女娲辅助伤害();

    
    
    public static float 老子攻击数值 => Get老子攻击数值();
    public static float 老子Cd=> Get老子Cd();
    public static float 老子弹道速度=> Get老子弹道速度();
    public static float 老子增长速度=> Get老子增长速度();
    
    
    public static float 通天攻击数值 => Get通天攻击数值();
    public static float 通天Cd=> Get通天Cd();
    public static float 通天攻击数量 => Get通天攻击数量();
    
    
    public static int 元始攻击数量 => Get元始攻击数量();
    public static float 元始攻击数值 => Get元始攻击数值();
    public static float 元始持续时间 => Get元始持续时间();
    public static float 元始转速=> Get元始转速();
    public static float 元始Cd => Get元始Cd();
    public static float 元始体积 => Get元始体积();

    
    public static float 盘古攻击数值 => Get盘古攻击数值();
    public static float 盘古Cd=> Get盘古Cd();
    public static int 盘古攻击数量 => Get盘古攻击数量();
    public static float 盘古出拳增加伤害 => Get盘古出拳增加伤害();

    
    public static float 鸿钧攻击数值 => Get鸿钧攻击数值();
    public static float 鸿钧Cd=> Get鸿钧Cd();
    public static int 鸿钧攻击数量 => Get鸿钧攻击数量();
    public static float 鸿钧效果范围 => Get鸿钧效果范围();

    
    
    public static int Get鸿钧攻击数量()
    {
        int value = 3;
        int xj = PlayerData.S.HeroDataDic[HeroType.鸿钧].Level - 1;
        if (xj >= 3)
        {
            value += 1;
        }
        if (xj >= 5)
        {
            value += 2;
        }
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.鸿钧]/5;
        if (法则星级 >= 1)
        {
            value += 1;
        }
        if (法则星级 >= 2)
        {
            value += 1;
        }
        if (法则星级 >= 3)
        {
            value += 1;
        }
        if (法则星级 >= 4)
        {
            value += 1;
        }
        if (法则星级 >= 5)
        {
            value += 1;
        }

        return value;
    }
    public static float Get鸿钧攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.鸿钧][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.鸿钧].Level - 1;
        if (xj >= 1)
        {
            value *= 1.20f;
        }
        return value;
    }

    public static float Get鸿钧Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.鸿钧];
        int xj = PlayerData.S.HeroDataDic[HeroType.鸿钧].Level - 1;
        if (xj >= 2)
        {
            value /= 1.25f;
        }
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.鸿钧]/5;
        if (法则星级 >= 1)
        {
            value /= 1.05f;
        }
        if (法则星级 >= 2)
        {
            value /= 1.1f;
        }
        if (法则星级 >= 3)
        {
            value /= 1.15f;
        }
        if (法则星级 >= 4)
        {
            value /= 1.2f;
        }
        if (法则星级 >= 5)
        {
            value /= 1.25f;
        }

        return value;
    }
    
    public static float Get鸿钧效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.鸿钧].Level - 1;
        if (xj >= 4)
        {
            value *= 1.2f;
        }
        return value;
    }


    public static float Get盘古出拳增加伤害()
    {
        float value = 0;
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.盘古]/5;
        if (法则星级 >= 1)
        {
            value += 1;
        }
        if (法则星级 >= 2)
        {
            value += 1.25f;
        }
        if (法则星级 >= 3)
        {
            value += 1.5f;
        }
        if (法则星级 >= 4)
        {
            value += 1.75f;
        }
        if (法则星级 >= 5)
        {
            value += 2f;
        }
        return value;
    }
    
    public static int Get盘古攻击数量()
    {
        int value = 2;
        int xj = PlayerData.S.HeroDataDic[HeroType.盘古].Level - 1;
        if (xj >= 3)
        {
            value += 1;
        }
        if (xj >= 5)
        {
            value += 2;
        }
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.盘古]/5;
        if (法则星级 >= 1)
        {
            value += 1;
        }
        if (法则星级 >= 2)
        {
            value += 1;
        }
        if (法则星级 >= 3)
        {
            value += 1;
        }
        if (法则星级 >= 4)
        {
            value += 1;
        }
        if (法则星级 >= 5)
        {
            value += 1;
        }

        return value;
    }
    public static float Get盘古攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.盘古][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.盘古].Level - 1;
        if (xj >= 1)
        {
            value *= 1.20f;
        }
        if (xj >= 4)
        {
            value *= 1.25f;
        }
        return value;
    }

    public static float Get盘古Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.盘古];
        int xj = PlayerData.S.HeroDataDic[HeroType.盘古].Level - 1;
        if (xj >= 2)
        {
            value /= 1.2f;
        }
        return value;
    }
    
    
    public static float Get元始持续时间()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.元始][1];
        int xj = PlayerData.S.HeroDataDic[HeroType.元始].Level - 1;
        if (xj >= 2)
        {
            value += 1f;
        }
        return value;
    }

    public static float Get元始体积()
    {
        float value = 1f;
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.元始]/5;
        if (法则星级 >= 1)
        {
            value += 0.05f;
        }
        if (法则星级 >= 2)
        {
            value += 0.1f;
        }
        if (法则星级 >= 3)
        {
            value += 0.15f;
        }
        if (法则星级 >= 4)
        {
            value += 0.2f;
        }

        return value;
    }
    public static float Get元始转速()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.元始].Level - 1;
        if (xj >= 5)
        {
            value += 0.25f;
        }
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.元始]/5;
        if (法则星级 >= 1)
        {
            value += 0.05f;
        }
        if (法则星级 >= 2)
        {
            value += 0.1f;
        }
        if (法则星级 >= 3)
        {
            value += 0.15f;
        }
        if (法则星级 >= 4)
        {
            value += 0.2f;
        }
        
        return value;
    }
    
    public static float Get元始Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.元始];
        
        return value;
    }

    public static int Get元始攻击数量()
    {
        int value = 3;
        int xj = PlayerData.S.HeroDataDic[HeroType.元始].Level - 1;
        if (xj >= 3)
        {
            value += 1;
        }
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.元始]/5;
        if (法则星级 >= 5)
        {
            value += 1;
        }
        return value;
    }
    
    public static float Get元始攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.元始][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.元始].Level - 1;
        if (xj >= 1)
        {
            value *= 1.15f;
        }
        if (xj >= 4)
        {
            value *= 1.2f;
        }
        return value;
    }
    
    
    
    
    public static float Get通天攻击数量()
    {
        float value = 2;
        int xj = PlayerData.S.HeroDataDic[HeroType.通天].Level - 1;
        if (xj >= 3)
        {
            value += 1f;
        }
        if (xj >= 5)
        {
            value += 1f;
        }

        return value;
    }

    public static float Get通天暴击率()
    {
        float value = 0;
        int level = PlayerData.S.英雄法则等级Dic[HeroType.通天]/5;
        if (level >= 1)
        {
            value += 0.03f;
        }
        if (level >= 2)
        {
            value += 0.06f;
        }
        if (level >= 3)
        {
            value += 0.09f;
        }
        if (level >= 4)
        {
            value += 0.12f;
        }
        if (level >= 5)
        {
            value += 0.15f;
        }
        return value;
    }
    public static float Get通天攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.通天][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.通天].Level - 1;
        if (xj >= 1)
        {
            value *= 1.15f;
        }
        if (xj >= 4)
        {
            value *= 1.2f;
        }
        return value;
    }
    
    public static float Get通天Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.通天];
        int xj = PlayerData.S.HeroDataDic[HeroType.通天].Level - 1;
        if (xj >= 2)
        {
            value /= 1.2f;
        }
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.通天]/5;
        if (法则星级 >= 1)
        {
            value /= 1.05f;
        }
        if (法则星级 >= 2)
        {
            value /= 1.1f;
        }
        if (法则星级 >= 3)
        {
            value /= 1.15f;
        }
        if (法则星级 >= 4)
        {
            value /= 1.2f;
        }
        if (法则星级 >= 5)
        {
            value /= 1.25f;
        }
        return value;
    }
    
    
    
    
    
    public static float Get老子弹道速度()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.老子].Level - 1;
        if (xj >= 3)
        {
            value *= 0.8f;
        }
        return value;
    }
    
    public static float Get老子增长速度()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.老子][1];
        int xj = PlayerData.S.HeroDataDic[HeroType.老子].Level - 1;
        if (xj >= 5)
        {
            value += 5f;
        }
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.老子]/5;
        if (法则星级 >= 1)
        {
            value += 1f;
        }
        if (法则星级 >= 2)
        {
            value += 2f;
        }
        if (法则星级 >= 3)
        {
            value += 3f;
        }
        if (法则星级 >= 4)
        {
            value += 4f;
        }
        if (法则星级 >= 5)
        {
            value += 5f;
        }
        return value;
    }
    public static float Get老子Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.老子];
        int xj = PlayerData.S.HeroDataDic[HeroType.老子].Level - 1;
        if (xj >= 2)
        {
            value /= 1.2f;
        }
        return value;
    }
    public static float Get老子攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.老子][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.老子].Level - 1;
        if (xj >= 1)
        {
            value *= 1.15f;
        }
        if (xj >= 4)
        {
            value *= 1.25f;
        }
        return value;
    }

    public static float Get女娲辅助伤害()
    {
        float value = 0;
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.女娲]/5;
        if (法则星级 >= 1)
        {
            value += 3f;
        }
        if (法则星级 >= 2)
        {
            value += 6f;
        }
        if (法则星级 >= 3)
        {
            value += 9f;
        }
        if (法则星级 >= 4)
        {
            value += 12f;
        }
        if (法则星级 >= 5)
        {
            value += 15f;
        }

        return value;
    }
    public static float Get女娲冷却缩减效果()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.女娲][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.女娲].Level - 1;
        if (xj >= 1)
        {
            value += 5f;
        }
        if (xj >= 3)
        {
            value += 10f;
        }
        return value/100f;
    }
    public static float Get女娲持续时间()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.女娲][1];
        int xj = PlayerData.S.HeroDataDic[HeroType.女娲].Level - 1;
        if (xj >= 5)
        {
            value += 1f;
        }
        return value;
    }
    public static float Get女娲Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.女娲];
        int xj = PlayerData.S.HeroDataDic[HeroType.女娲].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        if (xj >= 4)
        {
            value /= 1.15f;
        }
        return value;
    }
    
    public static float Get云霄效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.云霄].Level - 1;
        if (xj >= 5)
        {
            value *= 1.2f;
        }
        return value;
    }
    public static float Get云霄Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.云霄];
        int xj = PlayerData.S.HeroDataDic[HeroType.云霄].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        if (xj >= 4)
        {
            value /= 1.2f;
        }
        
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.云霄]/5;
        if (法则星级 >= 1)
        {
            value /= 1.05f;
        }
        if (法则星级 >= 2)
        {
            value /= 1.1f;
        }
        if (法则星级 >= 3)
        {
            value /= 1.15f;
        }
        if (法则星级 >= 4)
        {
            value /= 1.2f;
        }
        if (法则星级 >= 5)
        {
            value /= 1.25f;
        }
        return value;
    }
    public static float Get云霄攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.云霄][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.云霄].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }

    public static float Get后羿连射概率()
    {
        float value = 0;
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.后羿]/5;
        if (法则星级 >= 1)
        {
            value += 3f;
        }
        if (法则星级 >= 2)
        {
            value += 6f;
        }
        if (法则星级 >= 3)
        {
            value += 9f;
        }
        if (法则星级 >= 4)
        {
            value += 12f;
        }
        if (法则星级 >= 5)
        {
            value += 15f;
        }

        return value;
    }

    
    public static float Get后羿攻击数量()
    {
        float value = 2;
        int xj = PlayerData.S.HeroDataDic[HeroType.后羿].Level - 1;
        if (xj >= 3)
        {
            value += 1f;
        }
        if (xj >= 5)
        {
            value += 1f;
        }

        return value;
    }
    public static float Get后羿攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.后羿][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.后羿].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 4)
        {
            value *= 1.2f;
        }
        return value;
    }

    public static float Get后羿Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.后羿];
        int xj = PlayerData.S.HeroDataDic[HeroType.后羿].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        return value;
    }
    
    
    public static float Get常曦减速效果()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.常羲][1];
        int xj = PlayerData.S.HeroDataDic[HeroType.常羲].Level - 1;
        if (xj >= 5)
        {
            value += 15f;
        }
        
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.常羲]/5;
        if (法则星级 >= 1)
        {
            value += 3;
        }
        if (法则星级 >= 2)
        {
            value += 6f;
        }
        if (法则星级 >= 3)
        {
            value += 9f;
        }
        if (法则星级 >= 4)
        {
            value += 12f;
        }
        if (法则星级 >= 5)
        {
            value += 15f;
        }
        return value;
    }
    
    public static float Get常曦效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.常羲].Level - 1;
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }
    public static float Get常曦Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.常羲];
        int xj = PlayerData.S.HeroDataDic[HeroType.常羲].Level - 1;
        if (xj >= 2)
        {
            value /= 1.1f;
        }
        return value;
    }
    public static float Get常曦攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.常羲][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.常羲].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 4)
        {
            value *= 1.2f;
        }
        return value;
    }

    public static float Get羲和灼烧叠加伤害()
    {
        float value = 0;
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.羲和]/5;
        if (法则星级 >= 1)
        {
            value += 10;
        }
        if (法则星级 >= 2)
        {
            value += 15f;
        }
        if (法则星级 >= 3)
        {
            value += 20f;
        }
        if (法则星级 >= 4)
        {
            value += 25f;
        }
        if (法则星级 >= 5)
        {
            value += 30f;
        }
        return value;
    }
    
    public static float Get羲和灼烧伤害()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.羲和][1];
        int xj = PlayerData.S.HeroDataDic[HeroType.羲和].Level - 1;
        if (xj >= 5)
        {
            value += 100f;
        }
        return value;
    }
    
    public static float Get羲和效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.羲和].Level - 1;
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }
    public static float Get羲和Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.羲和];
        int xj = PlayerData.S.HeroDataDic[HeroType.羲和].Level - 1;
        if (xj >= 2)
        {
            value /= 1.1f;
        }
        return value;
    }
    public static float Get羲和攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.羲和][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.羲和].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 4)
        {
            value *= 1.2f;
        }
        return value;
    }
    
    
    
    
    public static float Get琼霄琼霄定身时长()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.琼霄][1];
        int xj = PlayerData.S.HeroDataDic[HeroType.琼霄].Level - 1;
        if (xj >= 5)
        {
            value += 0.5f;
        }
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.琼霄]/5;
        if (法则星级 >= 1)
        {
            value += 0.1f;
        }
        if (法则星级 >= 2)
        {
            value += 0.2f;
        }
        if (法则星级 >= 3)
        {
            value += 0.3f;
        }
        if (法则星级 >= 4)
        {
            value += 0.4f;
        }
        if (法则星级 >= 5)
        {
            value += 0.5f;
        }
        return value;
    }
    
    public static float Get琼霄效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.琼霄].Level - 1;
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }
    public static float Get琼霄Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.琼霄];
        int xj = PlayerData.S.HeroDataDic[HeroType.琼霄].Level - 1;
        if (xj >= 2)
        {
            value /= 1.1f;
        }
        return value;
    }
    public static float Get琼霄攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.琼霄][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.琼霄].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 4)
        {
            value *= 1.2f;
        }
        return value;
    }
    
    
    
    
    
    public static float Get碧霄效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.碧霄].Level - 1;
        if (xj >= 5)
        {
            value += 0.2f;
        }

        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.碧霄]/5;
        if (法则星级 >= 1)
        {
            value += 0.05f;
        }
        if (法则星级 >= 3)
        {
            value += 0.15f;
        }
        if (法则星级 >= 5)
        {
            value += 0.25f;
        }
        return value;
    }
    public static float Get碧霄Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.碧霄];
        int xj = PlayerData.S.HeroDataDic[HeroType.碧霄].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        if (xj >= 4)
        {
            value /= 1.2f;
        }
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.碧霄]/5;
        if (法则星级 >= 2)
        {
            value /= 1.1f;
        }
        if (法则星级 >= 4)
        {
            value /= 1.2f;
        }
       
        return value;
    }
    public static float Get碧霄攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.碧霄][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.碧霄].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }

    public static float Get孙悟空每次下场伤害()
    {
        float value = 0;
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.孙悟空]/5;
        if (法则星级 >= 1)
        {
            value += 1f;
        }
        if (法则星级 >= 2)
        {
            value += 1.25f;
        }
        if (法则星级 >= 3)
        {
            value += 1.5f;
        }
        if (法则星级 >= 4)
        {
            value += 1.75f;
        }
        if (法则星级 >= 5)
        {
            value += 2f;
        }

        return value;
    }

    public static int Get孙悟空次数()
    {
        int value = 2;
        int xj = PlayerData.S.HeroDataDic[HeroType.孙悟空].Level - 1;
        if (xj >= 4)
        {
            value += 1;
        }

        return value;
    }
    public static float Get孙悟空效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.孙悟空].Level - 1;
        if (xj >= 5)
        {
            value *= 1.2f;
        }
        return value;
    }
    public static float Get孙悟空Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.孙悟空];
        int xj = PlayerData.S.HeroDataDic[HeroType.孙悟空].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        return value;
    }
    public static float Get孙悟空攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.孙悟空][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.孙悟空].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }
    
    
    public static float Get哪吒效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.哪吒].Level - 1;
        if (xj >= 5)
        {
            value += 0.2f;
        }
        int 法则星级 = PlayerData.S.英雄法则等级Dic[HeroType.哪吒] / 5;
        if (法则星级 >= 1)
        {
            value += 0.05f;
        }
        if (法则星级 >= 2)
        {
            value += 0.10f;
        }
        if (法则星级 >= 3)
        {
            value += 0.15f;
        }
        if (法则星级 >= 4)
        {
            value += 0.2f;
        }
        if (法则星级 >= 5)
        {
            value += 0.25f;
        }
        return value;
    }
    public static float Get哪吒Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.哪吒];
        int xj = PlayerData.S.HeroDataDic[HeroType.哪吒].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        if (xj >= 4)
        {
            value /= 1.2f;
        }
        return value;
    }
    public static float Get哪吒攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.哪吒][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.哪吒].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }

    public static float Get牛魔王效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.牛魔王].Level - 1;
        if (xj >= 5)
        {
            value *= 1.2f;
        }

        return value;
    }
    
    public static float Get牛魔王攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.牛魔王][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.牛魔王].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        if (xj >= 5)
        {
            value *= 0.75f;
        }
        return value;
    }

    public static float Get牛魔王Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.牛魔王];
        int xj = PlayerData.S.HeroDataDic[HeroType.牛魔王].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        if (xj >= 4)
        {
            value /= 1.2f;
        }
        return value;
    }
    
    public static float Get妲己效果()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.妲己][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.妲己].Level - 1;
        if (xj >= 1)
        {
            value += 5f;
        }
        if (xj >= 5)
        {
            value += 10f;
        }
        return value;
    }
    public static float Get妲己持续时间()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.妲己][1];
        int xj = PlayerData.S.HeroDataDic[HeroType.妲己].Level - 1;
        if (xj >= 3)
        {
            value += 1f;
        }
        return value;
    }
    public static float Get妲己Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.妲己];
        int xj = PlayerData.S.HeroDataDic[HeroType.妲己].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        if (xj >= 4)
        {
            value /= 1.2f;
        }
        if (xj >= 5)
        {
            value *= 1.2f;
        }
        return value;
    }
    

    public static float Get杨戬攻击数量()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.杨戬].Level - 1;
        if (xj >= 5)
        {
            value += 1f;
        }

        return value;
    }
    public static float Get杨戬攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.杨戬][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.杨戬].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        if (xj >= 5)
        {
            value *= 0.7f;
        }
        return value;
    }

    public static float Get杨戬Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.杨戬];
        int xj = PlayerData.S.HeroDataDic[HeroType.杨戬].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        if (xj >= 4)
        {
            value /= 1.2f;
        }
        return value;
    }
    
    
    
    public static float Get嫦娥效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.嫦娥].Level - 1;
        if (xj >= 5)
        {
            value *= 1.2f;
        }
        return value;
    }
    public static float Get嫦娥Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.嫦娥];
        int xj = PlayerData.S.HeroDataDic[HeroType.嫦娥].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        if (xj >= 4)
        {
            value /= 1.2f;
        }
        return value;
    }
    public static float Get嫦娥攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.嫦娥][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.嫦娥].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }
    
    
    public static float Get月老攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.月老][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.月老].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        if (xj >= 5)
        {
            value *= 1.25f;
        }
        return value;
    }

    public static float Get月老Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.月老];
        int xj = PlayerData.S.HeroDataDic[HeroType.月老].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        if (xj >= 4)
        {
            value /= 1.2f;
        }
        return value;
    }
    
    public static float Get雷震子效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.雷震子].Level - 1;
        if (xj >= 5)
        {
            value *= 1.2f;
        }
        return value;
    }
    public static float Get雷震子Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.雷震子];
        int xj = PlayerData.S.HeroDataDic[HeroType.雷震子].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        if (xj >= 4)
        {
            value /= 1.2f;
        }
        return value;
    }
    public static float Get雷震子攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.雷震子][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.雷震子].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }
    
    
    public static float Get广目天王效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.广目天王].Level - 1;
        if (xj >= 5)
        {
            value *= 1.2f;
        }
        return value;
    }
    public static float Get广目天王Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.广目天王];
        int xj = PlayerData.S.HeroDataDic[HeroType.广目天王].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        if (xj >= 4)
        {
            value /= 1.15f;
        }
        return value;
    }
    public static float Get广目天王攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.广目天王][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.广目天王].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }
    
    
    
    public static float Get多闻天王攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.多闻天王][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.多闻天王].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        if (xj >= 5)
        {
            value *= 1.2f;
        }
        return value;
    }

    public static float Get多闻天王Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.多闻天王];
        int xj = PlayerData.S.HeroDataDic[HeroType.多闻天王].Level - 1;
        if (xj >= 2)
        {
            value /= 1.15f;
        }
        if (xj >= 4)
        {
            value /= 1.2f;
        }
        return value;
    }
    
    
    public static float Get太白金星攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.太白金星][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.太白金星].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        if (xj >= 5)
        {
            value *= 1.2f;
        }
        return value;
    }

    public static float Get太白金星Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.太白金星];
        int xj = PlayerData.S.HeroDataDic[HeroType.太白金星].Level - 1;
        if (xj >= 2)
        {
            value /= 1.1f;
        }
        if (xj >= 4)
        {
            value /= 1.15f;
        }
        return value;
    }
    
    
    public static float Get龟丞相Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.龟丞相];
        int xj = PlayerData.S.HeroDataDic[HeroType.龟丞相].Level - 1;
        if (xj >= 2)
        {
            value /= 1.1f;
        }
        if (xj >= 4)
        {
            value /= 1.15f;
        }
        return value;
    }
    public static float Get龟丞相攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.龟丞相][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.龟丞相].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        return value;
    }
    public static float Get龟丞相减速效果()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.龟丞相][1];
        int xj = PlayerData.S.HeroDataDic[HeroType.龟丞相].Level - 1;
        if (xj >= 3)
        {
            value += 5;
        }
        if (xj >= 5)
        {
            value += 10;
        }
        return value;
    }
    
    public static float Get玄女效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.玄女].Level - 1;
        if (xj >= 5)
        {
            value *= 1.2f;
        }
        return value;
    }
    public static float Get玄女Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.玄女];
        int xj = PlayerData.S.HeroDataDic[HeroType.玄女].Level - 1;
        if (xj >= 2)
        {
            value /= 1.1f;
        }
        if (xj >= 4)
        {
            value /= 1.15f;
        }
        return value;
    }
    public static float Get玄女攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.玄女][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.玄女].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }
    
    public static float Get石敢当效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.石敢当].Level - 1;
        if (xj >= 5)
        {
            value *= 1.2f;
        }
        return value;
    }
    public static float Get石敢当Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.石敢当];
        int xj = PlayerData.S.HeroDataDic[HeroType.石敢当].Level - 1;
        if (xj >= 2)
        {
            value /= 1.1f;
        }
        if (xj >= 4)
        {
            value /= 1.15f;
        }
        return value;
    }
    public static float Get石敢当攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.石敢当][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.石敢当].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }
    

    public static float Get瑶池仙女减速效果()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.瑶池仙女][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.瑶池仙女].Level - 1;
        if (xj >= 1)
        {
            value += 5f;
        }
        if (xj >= 4)
        {
            value += 10f;
        }
        return value;
    }
    public static float Get瑶池仙女持续时间()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.瑶池仙女][1];
        int xj = PlayerData.S.HeroDataDic[HeroType.瑶池仙女].Level - 1;
        if (xj >= 3)
        {
            value += 1f;
        }
        return value;
    }
    public static float Get瑶池仙女Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.瑶池仙女];
        int xj = PlayerData.S.HeroDataDic[HeroType.瑶池仙女].Level - 1;
        if (xj >= 2)
        {
            value /= 1.1f;
        }
        if (xj >= 5)
        {
            value /= 1.2f;
        }
        return value;
    }
    public static float Get河伯效果范围()
    {
        float value = 1;
        int xj = PlayerData.S.HeroDataDic[HeroType.河伯].Level - 1;
        if (xj >= 5)
        {
            value *= 1.25f;
        }
        return value;
    }
    public static float Get河伯Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.河伯];
        int xj = PlayerData.S.HeroDataDic[HeroType.河伯].Level - 1;
        if (xj >= 2)
        {
            value /= 1.1f;
        }
        if (xj >= 4)
        {
            value /= 1.2f;
        }
        return value;
    }
    public static float Get河伯攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.河伯][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.河伯].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }
    public static float Get土地击退距离()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.土地][1];
        int xj = PlayerData.S.HeroDataDic[HeroType.土地].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 5)
        {
            value *= 1.25f;
        }
        return value;
    }
    public static float Get土地Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.土地];
        int xj = PlayerData.S.HeroDataDic[HeroType.土地].Level - 1;
        if (xj >= 2)
        {
            value /= 1.1f;
        }
        if (xj >= 4)
        {
            value /= 1.2f;
        }
        return value;
    }
    public static float Get土地攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.土地][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.土地].Level - 1;
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        return value;
    }
    public static float Get丹童攻击数值()
    {
        float value = HeroConfig.HeroSkillDamageDic[HeroType.丹童][0];
        int xj = PlayerData.S.HeroDataDic[HeroType.丹童].Level - 1;
        if (xj >= 1)
        {
            value *= 1.1f;
        }
        if (xj >= 3)
        {
            value *= 1.15f;
        }
        if (xj >= 5)
        {
            value *= 1.25f;
        }
        return value;
    }

    public static float Get丹童Cd()
    {
        float value = HeroConfig.HeroAttackTimeDic[HeroType.丹童];
        int xj = PlayerData.S.HeroDataDic[HeroType.丹童].Level - 1;
        if (xj >= 2)
        {
            value /= 1.1f;
        }
        if (xj >= 4)
        {
            value /= 1.2f;
        }
        return value;
    }
}
