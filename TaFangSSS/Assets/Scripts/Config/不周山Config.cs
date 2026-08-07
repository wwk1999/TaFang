using System.Collections.Generic;
using Config;
using UnityEngine;

public class 不周山秘境寻宝Item
{
    public bool 寻宝;
    public float time;
    public bool 重复;
    public List<寻宝法则道具item> list;
}
public class 寻宝法则道具item
{
    public PropType 法则Type;
    public int count;
}
public class 不周山Config
{
    public static int Get不周山最大层数()
    {
        switch (PlayerData.S.JingJieType)
        {
            case JingJieType.练气:
            case JingJieType.筑基:
            case JingJieType.金丹:
            case JingJieType.元婴:
                return 0;
            case JingJieType.化神:
            case JingJieType.合体:
                return 1;
            case JingJieType.大乘:
            case JingJieType.天仙:
                return 2;
            case JingJieType.玄仙:
            case JingJieType.金仙:
                return 3;
            case JingJieType.太乙金仙:
            case JingJieType.大罗金仙:
                return 4;
            case JingJieType.准圣:
            case JingJieType.圣人:
                return 5;
            case JingJieType.天道圣人:
            case JingJieType.大道圣人:
                return 6;
            case JingJieType.混元圣人:
                return 7;
            case JingJieType.鸿蒙:
                return 8;
        }
        return 0;
    }
    
    
    
    public static Dictionary<int, 秘境属性> 不周山关卡Dic = new Dictionary<int, 秘境属性>()
    {
        {
            1,
            new 秘境属性()
            {
                jingJieType = JingJieType.化神,
                list = new List<掉落item>() {  new 掉落item() { quality = QualityType.宇品, 概率 = 90 },  new 掉落item() { quality = QualityType.宙品, 概率 = 10 },}, 
                掉落数量 = 3, 
                需要年数 = 0.5f,
                需要人数=3,
                需要英雄品质=QualityType.地品,
                需要英雄星级=1,
                需要英雄元素=YuanSuType.None,
                需要英雄职业=ZhiYeType.None,
            }
        },
        
        {
            2,
            new 秘境属性()
            {
                jingJieType = JingJieType.大乘,
                list = new List<掉落item>() { new 掉落item() { quality = QualityType.宇品, 概率 = 75 },  new 掉落item() { quality = QualityType.宙品, 概率 = 25 },}, 
                掉落数量 = 4, 
                需要年数 = 1,
                需要人数=3,
                需要英雄品质=QualityType.天品,
                需要英雄星级=1,
                需要英雄元素=YuanSuType.None,
                需要英雄职业=ZhiYeType.None,
            }
        },
        
        {
            3,
            new 秘境属性()
            {
                jingJieType = JingJieType.玄仙,
                list = new List<掉落item>() {  new 掉落item() { quality = QualityType.宇品, 概率 = 60 },  new 掉落item() { quality = QualityType.宙品, 概率 = 40 },new 掉落item() { quality = QualityType.洪品, 概率 = 5 },}, 
                掉落数量 = 5, 
                需要年数 = 2,
                需要人数=4,
                需要英雄品质=QualityType.天品,
                需要英雄星级=2,
                需要英雄元素=YuanSuType.None,
                需要英雄职业=ZhiYeType.None,
            }
        },
        
        
        {
            4,
            new 秘境属性()
            {
                jingJieType = JingJieType.太乙金仙,
                list = new List<掉落item>() { new 掉落item() { quality = QualityType.宇品, 概率 = 50 },  new 掉落item() { quality = QualityType.宙品, 概率 = 40 },new 掉落item() { quality = QualityType.洪品, 概率 = 10 },}, 
                掉落数量 = 6, 
                需要年数 = 5,
                需要人数=4,
                需要英雄品质=QualityType.宇品,
                需要英雄星级=2,
                需要英雄元素=YuanSuType.None,
                需要英雄职业=ZhiYeType.None,
            }
        },
        
        {
            5,
            new 秘境属性()
            {
                jingJieType = JingJieType.准圣,
                list = new List<掉落item>() { new 掉落item() { quality = QualityType.宇品, 概率 = 35 },  new 掉落item() { quality = QualityType.宙品, 概率 = 50 },new 掉落item() { quality = QualityType.洪品, 概率 = 15 },}, 
                掉落数量 = 7, 
                需要年数 = 10,
                需要人数=4,
                需要英雄品质=QualityType.宙品,
                需要英雄星级=2,
                需要英雄元素=YuanSuType.None,
                需要英雄职业=ZhiYeType.None,
            }
        },
        
        {
            6,
            new 秘境属性()
            {
                jingJieType = JingJieType.天道圣人,
                list = new List<掉落item>() { new 掉落item() { quality = QualityType.宇品, 概率 = 20 },  new 掉落item() { quality = QualityType.宙品, 概率 = 60 },new 掉落item() { quality = QualityType.洪品, 概率 = 20 },}, 
                掉落数量 = 8, 
                需要年数 = 20,
                需要人数=4,
                需要英雄品质=QualityType.宙品,
                需要英雄星级=3,
                需要英雄元素=YuanSuType.None,
                需要英雄职业=ZhiYeType.None,
            }
        },
        
        {
            7,
            new 秘境属性()
            {
                jingJieType = JingJieType.混元圣人,
                list = new List<掉落item>() {  new 掉落item() { quality = QualityType.宙品, 概率 = 70 },new 掉落item() { quality = QualityType.洪品, 概率 = 25 },new 掉落item() { quality = QualityType.荒品, 概率 = 5 },}, 
                掉落数量 = 9, 
                需要年数 = 50,
                需要人数=4,
                需要英雄品质=QualityType.洪品,
                需要英雄星级=2,
                需要英雄元素=YuanSuType.None,
                需要英雄职业=ZhiYeType.None,
            }
        },
        
        {
            8,
            new 秘境属性()
            {
                jingJieType = JingJieType.鸿蒙,
                list = new List<掉落item>() {  new 掉落item() { quality = QualityType.宙品, 概率 = 50 },new 掉落item() { quality = QualityType.洪品, 概率 = 40 },new 掉落item() { quality = QualityType.荒品, 概率 = 10 },}, 
                掉落数量 = 10, 
                需要年数 = 100,
                需要人数=2,
                需要英雄品质=QualityType.荒品,
                需要英雄星级=3,
                需要英雄元素=YuanSuType.None,
                需要英雄职业=ZhiYeType.None,
            }
        },
    };
    
    public static PropType Get随机法则Type(QualityType qualityType)
    {
        var list = HeroConfig.QualityHeroDic[qualityType];
        int random=Random.Range(0, list.Count);
        return  法则config.法则TypeDic[list[random]];
    }
    
    public static List<PropType> Get不周山掉落(int 层数)
    {
        int count = 不周山关卡Dic[层数].掉落数量;
        List<PropType> list = new List<PropType>();
        for (int i = 0; i < count; i++)
        {
            float random = Random.Range(0, 100f);
            float 概率 = 0;
            QualityType quality=QualityType.None;
            foreach (var item in 不周山关卡Dic[层数].list)
            {
                概率 += item.概率;
                if (random <= 概率)
                {
                    quality=item.quality;
                    break;
                }
            }
            list.Add(Get随机法则Type(quality));
        }

        return list;
    }
}
