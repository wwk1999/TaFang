using System;
using System.Collections.Generic;
using System.Linq;
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
        public static Dictionary<JingJieType, HashSet<ZhaoMuItem>> ZhaoMuGaiLvNormalDic =
            new Dictionary<JingJieType, HashSet<ZhaoMuItem>>()
            {
                {
                    JingJieType.练气,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 75 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 25 }
                    }
                },

                {
                    JingJieType.筑基,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 60 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 40 }
                    }
                },

                {
                    JingJieType.金丹,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 50 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 40 },
                        new ZhaoMuItem() { type = QualityType.地, count = 10 }
                    }
                },

                {
                    JingJieType.元婴,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 40 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 45 },
                        new ZhaoMuItem() { type = QualityType.地, count = 15 }
                    }
                },

                {
                    JingJieType.化神,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 30 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 50 },
                        new ZhaoMuItem() { type = QualityType.地, count = 20 }
                    }
                },

                {
                    JingJieType.合体,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 25 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 50 },
                        new ZhaoMuItem() { type = QualityType.地, count = 20 },
                        new ZhaoMuItem() { type = QualityType.天, count = 5 }
                    }
                },

                {
                    JingJieType.大乘,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 20 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 45 },
                        new ZhaoMuItem() { type = QualityType.地, count = 25 },
                        new ZhaoMuItem() { type = QualityType.天, count = 10 }
                    }
                },

                {
                    JingJieType.天仙,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 15 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 40 },
                        new ZhaoMuItem() { type = QualityType.地, count = 30 },
                        new ZhaoMuItem() { type = QualityType.天, count = 15 }
                    }
                },

                {
                    JingJieType.玄仙,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 35 },
                        new ZhaoMuItem() { type = QualityType.地, count = 35 },
                        new ZhaoMuItem() { type = QualityType.天, count = 20 }
                    }
                },

                {
                    JingJieType.金仙,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 32 },
                        new ZhaoMuItem() { type = QualityType.地, count = 35 },
                        new ZhaoMuItem() { type = QualityType.天, count = 20 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 3 }
                    }
                },

                {
                    JingJieType.太乙金仙,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 20 },
                        new ZhaoMuItem() { type = QualityType.地, count = 40 },
                        new ZhaoMuItem() { type = QualityType.天, count = 25 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 5 }
                    }
                },

                {
                    JingJieType.大罗金仙,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 5 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 15 },
                        new ZhaoMuItem() { type = QualityType.地, count = 42 },
                        new ZhaoMuItem() { type = QualityType.天, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 8 }
                    }
                },

                {
                    JingJieType.准圣,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 3 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地, count = 40 },
                        new ZhaoMuItem() { type = QualityType.天, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 12 }
                    }
                },

                {
                    JingJieType.圣人,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 3 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地, count = 25 },
                        new ZhaoMuItem() { type = QualityType.天, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 16 },
                        new ZhaoMuItem() { type = QualityType.宙, count = 1 },
                    }
                },

                {
                    JingJieType.天道圣人,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 2 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地, count = 20 },
                        new ZhaoMuItem() { type = QualityType.天, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 20 },
                        new ZhaoMuItem() { type = QualityType.宙, count = 3 },
                    }
                },

                {
                    JingJieType.大道圣人,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 2 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 8 },
                        new ZhaoMuItem() { type = QualityType.地, count = 16 },
                        new ZhaoMuItem() { type = QualityType.天, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 24 },
                        new ZhaoMuItem() { type = QualityType.宙, count = 5 },
                    }
                },

                {
                    JingJieType.鸿蒙,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地, count = 12 },
                        new ZhaoMuItem() { type = QualityType.天, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宙, count = 8 },
                    }
                },
            };







        public static Dictionary<JingJieType, HashSet<ZhaoMuItem>> ZhaoMuGaiLvGaoJiDic =
            new Dictionary<JingJieType, HashSet<ZhaoMuItem>>()
            {
                {
                    JingJieType.练气,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 25 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 50 },
                        new ZhaoMuItem() { type = QualityType.地, count = 20 },
                        new ZhaoMuItem() { type = QualityType.天, count = 5 }
                    }
                },

                {
                    JingJieType.筑基,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 20 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 45 },
                        new ZhaoMuItem() { type = QualityType.地, count = 25 },
                        new ZhaoMuItem() { type = QualityType.天, count = 10 }
                    }
                },

                {
                    JingJieType.金丹,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 15 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 40 },
                        new ZhaoMuItem() { type = QualityType.地, count = 30 },
                        new ZhaoMuItem() { type = QualityType.天, count = 15 }
                    }
                },

                {
                    JingJieType.元婴,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 35 },
                        new ZhaoMuItem() { type = QualityType.地, count = 35 },
                        new ZhaoMuItem() { type = QualityType.天, count = 20 }
                    }
                },

                {
                    JingJieType.化神,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 32 },
                        new ZhaoMuItem() { type = QualityType.地, count = 35 },
                        new ZhaoMuItem() { type = QualityType.天, count = 20 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 3 }
                    }
                },

                {
                    JingJieType.合体,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 20 },
                        new ZhaoMuItem() { type = QualityType.地, count = 40 },
                        new ZhaoMuItem() { type = QualityType.天, count = 25 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 5 }
                    }
                },

                {
                    JingJieType.大乘,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 5 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 15 },
                        new ZhaoMuItem() { type = QualityType.地, count = 42 },
                        new ZhaoMuItem() { type = QualityType.天, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 8 }
                    }
                },

                {
                    JingJieType.天仙,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 3 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地, count = 40 },
                        new ZhaoMuItem() { type = QualityType.天, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 12 }
                    }
                },

                {
                    JingJieType.玄仙,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 3 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地, count = 25 },
                        new ZhaoMuItem() { type = QualityType.天, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 16 },
                        new ZhaoMuItem() { type = QualityType.宙, count = 1 },
                    }
                },

                {
                    JingJieType.金仙,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 2 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地, count = 20 },
                        new ZhaoMuItem() { type = QualityType.天, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 20 },
                        new ZhaoMuItem() { type = QualityType.宙, count = 3 },
                    }
                },

                {
                    JingJieType.太乙金仙,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 2 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 8 },
                        new ZhaoMuItem() { type = QualityType.地, count = 16 },
                        new ZhaoMuItem() { type = QualityType.天, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 24 },
                        new ZhaoMuItem() { type = QualityType.宙, count = 5 },
                    }
                },

                {
                    JingJieType.大罗金仙,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地, count = 12 },
                        new ZhaoMuItem() { type = QualityType.天, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宙, count = 8 },
                    }
                },

                {
                    JingJieType.准圣,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地, count = 13 },
                        new ZhaoMuItem() { type = QualityType.天, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宙, count = 12 },
                    }
                },

                {
                    JingJieType.圣人,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地, count = 13 },
                        new ZhaoMuItem() { type = QualityType.天, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宙, count = 15 },
                        new ZhaoMuItem() { type = QualityType.洪, count = 2 },
                    }
                },

                {
                    JingJieType.天道圣人,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地, count = 13 },
                        new ZhaoMuItem() { type = QualityType.天, count = 25 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宙, count = 18 },
                        new ZhaoMuItem() { type = QualityType.洪, count = 4 },
                    }
                },

                {
                    JingJieType.大道圣人,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 2 },
                        new ZhaoMuItem() { type = QualityType.地, count = 10 },
                        new ZhaoMuItem() { type = QualityType.天, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宙, count = 21 },
                        new ZhaoMuItem() { type = QualityType.洪, count = 6 },
                    }
                },

                {
                    JingJieType.鸿蒙,
                    new HashSet<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄, count = 2 },
                        new ZhaoMuItem() { type = QualityType.地, count = 9 },
                        new ZhaoMuItem() { type = QualityType.天, count = 25 },
                        new ZhaoMuItem() { type = QualityType.宇, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宙, count = 24 },
                        new ZhaoMuItem() { type = QualityType.洪, count = 8 },
                        new ZhaoMuItem() { type = QualityType.荒, count = 1 },
                    }
                },
            };


        public static PropType NormalZhaoMu()
        {
            HashSet<ZhaoMuItem> list = ZhaoMuGaiLvNormalDic[PlayerData.S.JingJieType];
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
            HeroType randomHero = herolist[Random.Range(0, list.Count)];
            return HeroConfig.HeroYuanShenDic[randomHero];
        }
        
        
        public static PropType GaoJiZhaoMu()
        {
            HashSet<ZhaoMuItem> list = ZhaoMuGaiLvGaoJiDic[PlayerData.S.JingJieType];
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
            HeroType randomHero = herolist[Random.Range(0, list.Count)];
            return HeroConfig.HeroYuanShenDic[randomHero];
        }
    }
}