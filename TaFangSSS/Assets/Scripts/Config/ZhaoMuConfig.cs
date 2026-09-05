using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Config
{
    public class ZhaoMuItem
    {
        public QualityType type;
        public int count;
    }

    public class ZhaoMuConfig
    {
        public static Dictionary<PropType, int> 招募商店价格Dic = new Dictionary<PropType, int>()
        {
            // 黄品价格 = 5
            { PropType.丹童元神, 5 },
            { PropType.土地元神, 5 },
            { PropType.河伯元神, 5 },
            { PropType.瑶池仙女元神, 5 },

            // 玄品价格 = 10
            { PropType.石敢当元神, 10 },
            { PropType.玄女元神, 10 },
            { PropType.龟丞相元神, 10 },
            { PropType.太白金星元神, 10 },

            // 地品价格 = 20
            { PropType.多闻天王元神, 25 },
            { PropType.广目天王元神, 25 },
            { PropType.雷震子元神, 25 },
            { PropType.月老元神, 25 },

            // 天品价格 = 40
            { PropType.嫦娥元神, 100 },
            { PropType.杨戬元神, 100 },
            { PropType.妲己元神, 100 },
            { PropType.牛魔王元神, 100 },

            // 宇品价格 = 80
            { PropType.哪吒元神, 500 },
            { PropType.孙悟空元神, 500 },
            { PropType.碧霄元神, 500 },
            { PropType.琼霄元神, 500 },

            // 宙品价格 = 160
            { PropType.羲和元神, 2000 },
            { PropType.常羲元神, 2000 },
            { PropType.后羿元神, 2000 },
            { PropType.云霄元神, 2000 },

            // 洪品价格 = 320
            { PropType.女娲元神, 5000 },
            { PropType.老子元神, 5000 },
            { PropType.通天元神, 5000 },
            { PropType.元始元神, 5000 },
            { PropType.盘古元神, 10000 },
            { PropType.鸿钧元神, 10000 },
        };
        
        public static Dictionary<JingJieType, List<ZhaoMuItem>> ZhaoMuGaiLvNormalDic =
            new Dictionary<JingJieType, List<ZhaoMuItem>>()
            {
                {
                    JingJieType.练气,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 75 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 25 }
                    }
                },

                {
                    JingJieType.筑基,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 60 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 40 }
                    }
                },

                {
                    JingJieType.金丹,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 40 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 60 },
                    }
                },

                {
                    JingJieType.元婴,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 40 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 15 }
                    }
                },

                {
                    JingJieType.化神,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 50 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 20 }
                    }
                },

                {
                    JingJieType.合体,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 50 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 5 }
                    }
                },

                {
                    JingJieType.大乘,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 10 }
                    }
                },

                {
                    JingJieType.天仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 15 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 40 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 15 }
                    }
                },

                {
                    JingJieType.玄仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 20 }
                    }
                },

                {
                    JingJieType.金仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 32 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 3 }
                    }
                },

                {
                    JingJieType.太乙金仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 40 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 5 }
                    }
                },

                {
                    JingJieType.大罗金仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 5 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 15 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 42 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 8 }
                    }
                },

                {
                    JingJieType.准圣,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 3 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 40 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 12 }
                    }
                },

                {
                    JingJieType.圣人,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 3 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 16 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 1 },
                    }
                },

                {
                    JingJieType.天道圣人,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 2 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 3 },
                    }
                },

                {
                    JingJieType.大道圣人,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 2 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 8 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 16 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 24 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 5 },
                    }
                },

                {
                    JingJieType.混元圣人,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 12 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 8 },
                    }
                },
                
                {
                    JingJieType.鸿蒙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 2 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 5 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 12 },
                    }
                },
            };







        public static Dictionary<JingJieType, List<ZhaoMuItem>> ZhaoMuGaiLvGaoJiDic =
            new Dictionary<JingJieType, List<ZhaoMuItem>>()
            {
                {
                    JingJieType.练气,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 50 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 25 },
                    }
                },

                {
                    JingJieType.筑基,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 40 },
                    }
                },

                {
                    JingJieType.金丹,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 15 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 40 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 15 }
                    }
                },

                {
                    JingJieType.元婴,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 20 }
                    }
                },

                {
                    JingJieType.化神,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 32 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 3 }
                    }
                },

                {
                    JingJieType.合体,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 40 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 5 }
                    }
                },

                {
                    JingJieType.大乘,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 5 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 15 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 42 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 8 }
                    }
                },

                {
                    JingJieType.天仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 3 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 40 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 12 }
                    }
                },

                {
                    JingJieType.玄仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 3 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 16 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 1 },
                    }
                },

                {
                    JingJieType.金仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 2 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 3 },
                    }
                },

                {
                    JingJieType.太乙金仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 2 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 8 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 16 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 24 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 5 },
                    }
                },

                {
                    JingJieType.大罗金仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 12 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 8 },
                    }
                },

                {
                    JingJieType.准圣,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 13 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 12 },
                    }
                },

                {
                    JingJieType.圣人,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 13 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 15 },
                        new ZhaoMuItem() { type = QualityType.洪品, count = 2 },
                    }
                },

                {
                    JingJieType.天道圣人,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 13 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 18 },
                        new ZhaoMuItem() { type = QualityType.洪品, count = 4 },
                    }
                },

                {
                    JingJieType.大道圣人,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 2 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 21 },
                        new ZhaoMuItem() { type = QualityType.洪品, count = 6 },
                    }
                },

                {
                    JingJieType.混元圣人,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 2 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 9 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 24 },
                        new ZhaoMuItem() { type = QualityType.洪品, count = 8 },
                        new ZhaoMuItem() { type = QualityType.荒品, count = 1 },
                    }
                },
                
                
                {
                    JingJieType.鸿蒙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 2 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 4 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 15 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.洪品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.荒品, count = 3 },
                    }
                },
            };


        public static PropType NormalZhaoMu()
        {
            List<ZhaoMuItem> list = ZhaoMuGaiLvNormalDic[PlayerData.S.历史最高境界];
            int random=Random.Range(1, 101);
            int count = 0;
            int quality = 1;
            foreach (var item in list)
            {
                count += item.count;
                if (random <= count)
                {
                    break;
                }
                quality++;
            }
            QualityType qualityType=(QualityType)quality;
            List<HeroType> herolist=HeroConfig.QualityHeroDic[qualityType].ToList();
            HeroType randomHero = herolist[Random.Range(0, herolist.Count)];
            return HeroConfig.HeroToPropDic[randomHero];
        }
        
        
        public static PropType GaoJiZhaoMu()
        {
            List<ZhaoMuItem> list = ZhaoMuGaiLvGaoJiDic[PlayerData.S.历史最高境界];
            int random=Random.Range(1, 101);
            int count = 0;
            int quality = 1;
            foreach (var item in list)
            {
                count += item.count;
                if (random <= count)
                {
                    break;
                }
                quality++;
            }
            QualityType qualityType=(QualityType)quality;
            List<HeroType> herolist=HeroConfig.QualityHeroDic[qualityType].ToList();
            HeroType randomHero = herolist[Random.Range(0, herolist.Count)];
            return HeroConfig.HeroToPropDic[randomHero];
        }
    }
}