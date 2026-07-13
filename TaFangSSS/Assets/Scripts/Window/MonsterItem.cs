using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class MonsterItem : MonoBehaviour
{
    [NonSerialized] public MonsterTypeName MonsterTypeName;
    public Image image;

    public void SetItem()
    {
        switch (MonsterTypeName)
        {
            // 花果山
            case MonsterTypeName.猴精:
                image.sprite = ResourcesConfig.猴精;
                break;
            case MonsterTypeName.山魈:
                image.sprite = ResourcesConfig.山魈;
                break;
            case MonsterTypeName.马猴头领:
                image.sprite = ResourcesConfig.马猴头领;
                break;
            case MonsterTypeName.通臂猿猴:
                image.sprite = ResourcesConfig.通臂猿猴;
                break;

            // 水帘洞
            case MonsterTypeName.水虱精:
                image.sprite = ResourcesConfig.水虱精;
                break;
            case MonsterTypeName.蝙蝠精:
                image.sprite = ResourcesConfig.蝙蝠精;
                break;
            case MonsterTypeName.铁背苍猿:
                image.sprite = ResourcesConfig.铁背苍猿;
                break;
            case MonsterTypeName.水帘洞主:
                image.sprite = ResourcesConfig.水帘洞主;
                break;

            // 傲来国
            case MonsterTypeName.傲来民兵:
                image.sprite = ResourcesConfig.傲来民兵;
                break;
            case MonsterTypeName.猎户:
                image.sprite = ResourcesConfig.猎户;
                break;
            case MonsterTypeName.傲来偏将:
                image.sprite = ResourcesConfig.傲来偏将;
                break;
            case MonsterTypeName.傲来国师:
                image.sprite = ResourcesConfig.傲来国师;
                break;

            // 东海龙宫
            case MonsterTypeName.虾兵:
                image.sprite = ResourcesConfig.虾兵;
                break;
            case MonsterTypeName.蟹将:
                image.sprite = ResourcesConfig.蟹将;
                break;
            case MonsterTypeName.龟丞相:
                image.sprite = ResourcesConfig.龟丞相;
                break;
            case MonsterTypeName.东海龙王:
                image.sprite = ResourcesConfig.东海龙王;
                break;

            // 蓬莱仙岛
            case MonsterTypeName.仙鹤:
                image.sprite = ResourcesConfig.仙鹤;
                break;
            case MonsterTypeName.灵芝童:
                image.sprite = ResourcesConfig.灵芝童;
                break;
            case MonsterTypeName.蓬莱剑仙:
                image.sprite = ResourcesConfig.蓬莱剑仙;
                break;
            case MonsterTypeName.蓬莱岛主:
                image.sprite = ResourcesConfig.蓬莱岛主;
                break;

            // 五行山
            case MonsterTypeName.山石精:
                image.sprite = ResourcesConfig.山石精;
                break;
            case MonsterTypeName.土蝼:
                image.sprite = ResourcesConfig.土蝼;
                break;
            case MonsterTypeName.五行山神:
                image.sprite = ResourcesConfig.五行山神;
                break;
            case MonsterTypeName.压山符灵:
                image.sprite = ResourcesConfig.压山符灵;
                break;

            // 高老庄
            case MonsterTypeName.野猪精:
                image.sprite = ResourcesConfig.野猪精;
                break;
            case MonsterTypeName.高才:
                image.sprite = ResourcesConfig.高才;
                break;
            case MonsterTypeName.高太公:
                image.sprite = ResourcesConfig.高太公;
                break;
            case MonsterTypeName.猪刚鬣:
                image.sprite = ResourcesConfig.猪刚鬣;
                break;

            // 平顶山
            case MonsterTypeName.莲花洞小妖:
                image.sprite = ResourcesConfig.莲花洞小妖;
                break;
            case MonsterTypeName.狐阿七:
                image.sprite = ResourcesConfig.狐阿七;
                break;
            case MonsterTypeName.银角大王:
                image.sprite = ResourcesConfig.银角大王;
                break;
            case MonsterTypeName.金角大王:
                image.sprite = ResourcesConfig.金角大王;
                break;

            // 女儿国
            case MonsterTypeName.女儿国兵:
                image.sprite = ResourcesConfig.女儿国兵;
                break;
            case MonsterTypeName.女儿国将:
                image.sprite = ResourcesConfig.女儿国将;
                break;
            case MonsterTypeName.女儿国太师:
                image.sprite = ResourcesConfig.女儿国太师;
                break;
            case MonsterTypeName.女儿国国王:
                image.sprite = ResourcesConfig.女儿国国王;
                break;

            // 火焰山
            case MonsterTypeName.火焰精:
                image.sprite = ResourcesConfig.火焰精;
                break;
            case MonsterTypeName.赤蛇:
                image.sprite = ResourcesConfig.赤蛇;
                break;
            case MonsterTypeName.红孩儿:
                image.sprite = ResourcesConfig.红孩儿;
                break;
            case MonsterTypeName.牛魔王:
                image.sprite = ResourcesConfig.牛魔王;
                break;

            // 狮驼岭
            case MonsterTypeName.青狮精手下:
                image.sprite = ResourcesConfig.青狮精手下;
                break;
            case MonsterTypeName.白象精手下:
                image.sprite = ResourcesConfig.白象精手下;
                break;
            case MonsterTypeName.大鹏金翅雕:
                image.sprite = ResourcesConfig.大鹏金翅雕;
                break;
            case MonsterTypeName.青狮精:
                image.sprite = ResourcesConfig.青狮精;
                break;

            // 小雷音寺
            case MonsterTypeName.假罗汉:
                image.sprite = ResourcesConfig.假罗汉;
                break;
            case MonsterTypeName.假金刚:
                image.sprite = ResourcesConfig.假金刚;
                break;
            case MonsterTypeName.黄眉童子:
                image.sprite = ResourcesConfig.黄眉童子;
                break;
            case MonsterTypeName.黄眉老祖:
                image.sprite = ResourcesConfig.黄眉老祖;
                break;

            // 流沙河
            case MonsterTypeName.流沙精:
                image.sprite = ResourcesConfig.流沙精;
                break;
            case MonsterTypeName.水鬼:
                image.sprite = ResourcesConfig.水鬼;
                break;
            case MonsterTypeName.水蛇妖:
                image.sprite = ResourcesConfig.水蛇妖;
                break;
            case MonsterTypeName.沙和尚:
                image.sprite = ResourcesConfig.沙和尚;
                break;

            // 芭蕉洞
            case MonsterTypeName.芭蕉精:
                image.sprite = ResourcesConfig.芭蕉精;
                break;
            case MonsterTypeName.火焰童:
                image.sprite = ResourcesConfig.火焰童;
                break;
            case MonsterTypeName.铁扇侍女:
                image.sprite = ResourcesConfig.铁扇侍女;
                break;
            case MonsterTypeName.铁扇公主:
                image.sprite = ResourcesConfig.铁扇公主;
                break;

            // 冥府
            case MonsterTypeName.牛头:
                image.sprite = ResourcesConfig.牛头;
                break;
            case MonsterTypeName.马面:
                image.sprite = ResourcesConfig.马面;
                break;
            case MonsterTypeName.判官:
                image.sprite = ResourcesConfig.判官;
                break;
            case MonsterTypeName.阎罗王:
                image.sprite = ResourcesConfig.阎罗王;
                break;

            // ==================== 天庭篇（凌霄宝殿十大关） ====================
            // 南天门
            case MonsterTypeName.天兵:
                image.sprite = ResourcesConfig.天兵;
                break;
            case MonsterTypeName.天将:
                image.sprite = ResourcesConfig.天将;
                break;
            case MonsterTypeName.守卫统领:
                image.sprite = ResourcesConfig.守卫统领;
                break;
            case MonsterTypeName.巨灵王:
                image.sprite = ResourcesConfig.巨灵王;
                break;

            // 瑶池仙境
            case MonsterTypeName.瑶池仙女:
                image.sprite = ResourcesConfig.瑶池仙女;
                break;
            case MonsterTypeName.瑶池守卫:
                image.sprite = ResourcesConfig.瑶池守卫;
                break;
            case MonsterTypeName.仙女首领:
                image.sprite = ResourcesConfig.仙女首领;
                break;
            case MonsterTypeName.西王母:
                image.sprite = ResourcesConfig.西王母;
                break;

            // 斩妖台
            case MonsterTypeName.执法天兵:
                image.sprite = ResourcesConfig.执法天兵;
                break;
            case MonsterTypeName.执法天将:
                image.sprite = ResourcesConfig.执法天将;
                break;
            case MonsterTypeName.斩妖剑侍:
                image.sprite = ResourcesConfig.斩妖剑侍;
                break;
            case MonsterTypeName.天刑星君:
                image.sprite = ResourcesConfig.天刑星君;
                break;

            // 御马监
            case MonsterTypeName.天马精:
                image.sprite = ResourcesConfig.天马精;
                break;
            case MonsterTypeName.监丞侍卫:
                image.sprite = ResourcesConfig.监丞侍卫;
                break;
            case MonsterTypeName.弼马温:
                image.sprite = ResourcesConfig.弼马温;
                break;
            case MonsterTypeName.天马星君:
                image.sprite = ResourcesConfig.天马星君;
                break;

            // 蟠桃园
            case MonsterTypeName.桃园力士:
                image.sprite = ResourcesConfig.桃园力士;
                break;
            case MonsterTypeName.桃园仙女:
                image.sprite = ResourcesConfig.桃园仙女;
                break;
            case MonsterTypeName.蟠桃守卫:
                image.sprite = ResourcesConfig.蟠桃守卫;
                break;
            case MonsterTypeName.蟠桃树精:
                image.sprite = ResourcesConfig.蟠桃树精;
                break;

            // 兜率宫
            case MonsterTypeName.炼丹道童:
                image.sprite = ResourcesConfig.炼丹道童;
                break;
            case MonsterTypeName.烧火道童:
                image.sprite = ResourcesConfig.烧火道童;
                break;
            case MonsterTypeName.兜率宫侍卫:
                image.sprite = ResourcesConfig.金银童子;
                break;
            case MonsterTypeName.太上老君:
                image.sprite = ResourcesConfig.太上老君;
                break;

            // 紫微宫
            case MonsterTypeName.紫微星侍:
                image.sprite = ResourcesConfig.紫微星侍;
                break;
            case MonsterTypeName.天罡星卒:
                image.sprite = ResourcesConfig.天罡星卒;
                break;
            case MonsterTypeName.北极星君:
                image.sprite = ResourcesConfig.北极星君;
                break;
            case MonsterTypeName.紫微大帝:
                image.sprite = ResourcesConfig.紫微大帝;
                break;

            // 昊天殿
            case MonsterTypeName.镇殿守卫:
                image.sprite = ResourcesConfig.镇殿守卫;
                break;
            case MonsterTypeName.镇殿天将:
                image.sprite = ResourcesConfig.镇殿天将;
                break;
            case MonsterTypeName.九龙神卫:
                image.sprite = ResourcesConfig.九龙神卫;
                break;
            case MonsterTypeName.玉皇大帝:
                image.sprite = ResourcesConfig.玉皇大帝;
                break;

            default:
                image.sprite = null;
                break;
        }
    }
}
