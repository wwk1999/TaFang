using System;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class ResourcesConfig : MonoBehaviour
{
	public static Sprite 铲除;

	public static Sprite 灵植背包格子空;

	public static Sprite 灵植背包格子白;

	public static Sprite 灵植背包格子绿;

	public static Sprite 灵植背包格子蓝;

	public static Sprite 灵植背包格子紫;

	public static Sprite 灵植背包格子橙;

	public static Sprite 灵植背包格子粉;

	public static Sprite 灵植背包格子红;

	public static Sprite 灵植背包格子彩;

	public static Sprite 提速肥料白;

	public static Sprite 提速肥料绿;

	public static Sprite 提速肥料蓝;

	public static Sprite 提速肥料紫;

	public static Sprite 提速肥料橙;

	public static Sprite 提速肥料粉;

	public static Sprite 提速肥料红;

	public static Sprite 提速肥料彩;

	public static Sprite 增产肥料白;

	public static Sprite 增产肥料绿;

	public static Sprite 增产肥料蓝;

	public static Sprite 增产肥料紫;

	public static Sprite 增产肥料橙;

	public static Sprite 增产肥料粉;

	public static Sprite 增产肥料红;

	public static Sprite 增产肥料彩;

	public static Sprite 延时肥料白;

	public static Sprite 延时肥料绿;

	public static Sprite 延时肥料蓝;

	public static Sprite 延时肥料紫;

	public static Sprite 延时肥料橙;

	public static Sprite 延时肥料粉;

	public static Sprite 延时肥料红;

	public static Sprite 延时肥料彩;

	public static Sprite 异化肥料白;

	public static Sprite 异化肥料绿;

	public static Sprite 异化肥料蓝;

	public static Sprite 异化肥料紫;

	public static Sprite 异化肥料橙;

	public static Sprite 异化肥料粉;

	public static Sprite 异化肥料红;

	public static Sprite 异化肥料彩;

	public static Sprite 作物品质背景框白;

	public static Sprite 作物品质背景框绿;

	public static Sprite 作物品质背景框蓝;

	public static Sprite 作物品质背景框紫;

	public static Sprite 作物品质背景框橙;

	public static Sprite 作物品质背景框粉;

	public static Sprite 作物品质背景框红;

	public static Sprite 作物品质背景框彩;

	public static Sprite 播种;

	public static Sprite 成熟icon;

	public static Sprite 土地默认;

	public static Sprite 黑土地;

	public static Sprite 紫土地;

	public static Sprite 金土地;

	public static Sprite 红土地;

	public static Sprite 土地默认亮;

	public static Sprite 黑土地亮;

	public static Sprite 紫土地亮;

	public static Sprite 金土地亮;

	public static Sprite 红土地亮;

	public static Sprite 土地禁用;

	public static Sprite 紫云英幼苗;

	public static Sprite 紫云英成长;

	public static Sprite 紫云英成熟;

	public static Sprite 紫云英变异;

	public static Sprite 紫云英种子;

	public static Sprite 紫云英收获;

	public static Sprite 紫云英变异收获;

	public static Sprite 曜日葵幼苗;

	public static Sprite 曜日葵成长;

	public static Sprite 曜日葵成熟;

	public static Sprite 曜日葵变异;

	public static Sprite 曜日葵种子;

	public static Sprite 曜日葵收获;

	public static Sprite 曜日葵变异收获;

	public static Sprite 幻音铃幼苗;

	public static Sprite 幻音铃成长;

	public static Sprite 幻音铃成熟;

	public static Sprite 幻音铃变异;

	public static Sprite 幻音铃种子;

	public static Sprite 幻音铃收获;

	public static Sprite 幻音铃变异收获;

	public static Sprite 幻紫玫幼苗;

	public static Sprite 幻紫玫成长;

	public static Sprite 幻紫玫成熟;

	public static Sprite 幻紫玫变异;

	public static Sprite 幻紫玫种子;

	public static Sprite 幻紫玫收获;

	public static Sprite 幻紫玫变异收获;

	public static Sprite 九幽紫幼苗;

	public static Sprite 九幽紫成长;

	public static Sprite 九幽紫成熟;

	public static Sprite 九幽紫变异;

	public static Sprite 九幽紫种子;

	public static Sprite 九幽紫收获;

	public static Sprite 九幽紫变异收获;

	public static Sprite 赤焰百合幼苗;

	public static Sprite 赤焰百合成长;

	public static Sprite 赤焰百合成熟;

	public static Sprite 赤焰百合变异;

	public static Sprite 赤焰百合种子;

	public static Sprite 赤焰百合收获;

	public static Sprite 赤焰百合变异收获;

	public static Sprite 碧海螺幼苗;

	public static Sprite 碧海螺成长;

	public static Sprite 碧海螺成熟;

	public static Sprite 碧海螺变异;

	public static Sprite 碧海螺种子;

	public static Sprite 碧海螺收获;

	public static Sprite 碧海螺变异收获;

	public static Sprite 粉面佛莲幼苗;

	public static Sprite 粉面佛莲成长;

	public static Sprite 粉面佛莲成熟;

	public static Sprite 粉面佛莲变异;

	public static Sprite 粉面佛莲种子;

	public static Sprite 粉面佛莲收获;

	public static Sprite 粉面佛莲变异收获;

	public static Sprite 紫幽草幼苗;

	public static Sprite 紫幽草成长;

	public static Sprite 紫幽草成熟;

	public static Sprite 紫幽草变异;

	public static Sprite 紫幽草种子;

	public static Sprite 紫幽草收获;

	public static Sprite 紫幽草变异收获;

	public static Sprite 三生花幼苗;

	public static Sprite 三生花成长;

	public static Sprite 三生花成熟;

	public static Sprite 三生花变异;

	public static Sprite 三生花种子;

	public static Sprite 三生花收获;

	public static Sprite 三生花变异收获;

	public static Sprite 向阳花幼苗;

	public static Sprite 向阳花成长;

	public static Sprite 向阳花成熟;

	public static Sprite 向阳花变异;

	public static Sprite 向阳花种子;

	public static Sprite 向阳花收获;

	public static Sprite 向阳花变异收获;

	public static Sprite 白玉玲幼苗;

	public static Sprite 白玉玲成长;

	public static Sprite 白玉玲成熟;

	public static Sprite 白玉玲变异;

	public static Sprite 白玉玲种子;

	public static Sprite 白玉玲收获;

	public static Sprite 白玉玲变异收获;

	public static Sprite 赤阳花幼苗;

	public static Sprite 赤阳花成长;

	public static Sprite 赤阳花成熟;

	public static Sprite 赤阳花变异;

	public static Sprite 赤阳花种子;

	public static Sprite 赤阳花收获;

	public static Sprite 赤阳花变异收获;

	public static Sprite 寒星兰幼苗;

	public static Sprite 寒星兰成长;

	public static Sprite 寒星兰成熟;

	public static Sprite 寒星兰变异;

	public static Sprite 寒星兰种子;

	public static Sprite 寒星兰收获;

	public static Sprite 寒星兰变异收获;

	public static Sprite 赤霞花幼苗;

	public static Sprite 赤霞花成长;

	public static Sprite 赤霞花成熟;

	public static Sprite 赤霞花变异;

	public static Sprite 赤霞花种子;

	public static Sprite 赤霞花收获;

	public static Sprite 赤霞花变异收获;

	public static Sprite 惊雷子幼苗;

	public static Sprite 惊雷子成长;

	public static Sprite 惊雷子成熟;

	public static Sprite 惊雷子变异;

	public static Sprite 惊雷子种子;

	public static Sprite 惊雷子收获;

	public static Sprite 惊雷子变异收获;

	public static Sprite 幽兰铃幼苗;

	public static Sprite 幽兰铃成长;

	public static Sprite 幽兰铃成熟;

	public static Sprite 幽兰铃变异;

	public static Sprite 幽兰铃种子;

	public static Sprite 幽兰铃收获;

	public static Sprite 幽兰铃变异收获;

	public static Sprite 空谷幽兰幼苗;

	public static Sprite 空谷幽兰成长;

	public static Sprite 空谷幽兰成熟;

	public static Sprite 空谷幽兰变异;

	public static Sprite 空谷幽兰种子;

	public static Sprite 空谷幽兰收获;

	public static Sprite 空谷幽兰变异收获;

	public static Sprite 醉仙球幼苗;

	public static Sprite 醉仙球成长;

	public static Sprite 醉仙球成熟;

	public static Sprite 醉仙球变异;

	public static Sprite 醉仙球种子;

	public static Sprite 醉仙球收获;

	public static Sprite 醉仙球变异收获;

	public static Sprite 醉仙菌幼苗;

	public static Sprite 醉仙菌成长;

	public static Sprite 醉仙菌成熟;

	public static Sprite 醉仙菌变异;

	public static Sprite 醉仙菌种子;

	public static Sprite 醉仙菌收获;

	public static Sprite 醉仙菌变异收获;

	public static Sprite 太素花幼苗;

	public static Sprite 太素花成长;

	public static Sprite 太素花成熟;

	public static Sprite 太素花变异;

	public static Sprite 太素花种子;

	public static Sprite 太素花收获;

	public static Sprite 太素花变异收获;

	public static Sprite 灵犀铃幼苗;

	public static Sprite 灵犀铃成长;

	public static Sprite 灵犀铃成熟;

	public static Sprite 灵犀铃变异;

	public static Sprite 灵犀铃种子;

	public static Sprite 灵犀铃收获;

	public static Sprite 灵犀铃变异收获;

	public static Sprite 血菩提幼苗;

	public static Sprite 血菩提成长;

	public static Sprite 血菩提成熟;

	public static Sprite 血菩提变异;

	public static Sprite 血菩提种子;

	public static Sprite 血菩提收获;

	public static Sprite 血菩提变异收获;

	public static Sprite 紫晶铃幼苗;

	public static Sprite 紫晶铃成长;

	public static Sprite 紫晶铃成熟;

	public static Sprite 紫晶铃变异;

	public static Sprite 紫晶铃种子;

	public static Sprite 紫晶铃收获;

	public static Sprite 紫晶铃变异收获;

	public static Sprite 招财草幼苗;

	public static Sprite 招财草成长;

	public static Sprite 招财草成熟;

	public static Sprite 招财草变异;

	public static Sprite 招财草种子;

	public static Sprite 招财草收获;

	public static Sprite 招财草变异收获;

	public static Sprite 粉霞仙幼苗;

	public static Sprite 粉霞仙成长;

	public static Sprite 粉霞仙成熟;

	public static Sprite 粉霞仙变异;

	public static Sprite 粉霞仙种子;

	public static Sprite 粉霞仙收获;

	public static Sprite 粉霞仙变异收获;

	public static Sprite 黄龙掌幼苗;

	public static Sprite 黄龙掌成长;

	public static Sprite 黄龙掌成熟;

	public static Sprite 黄龙掌变异;

	public static Sprite 黄龙掌种子;

	public static Sprite 黄龙掌收获;

	public static Sprite 黄龙掌变异收获;

	public static Sprite 玄冰魄幼苗;

	public static Sprite 玄冰魄成长;

	public static Sprite 玄冰魄成熟;

	public static Sprite 玄冰魄变异;

	public static Sprite 玄冰魄种子;

	public static Sprite 玄冰魄收获;

	public static Sprite 玄冰魄变异收获;

	public static Sprite 修罗花幼苗;

	public static Sprite 修罗花成长;

	public static Sprite 修罗花成熟;

	public static Sprite 修罗花变异;

	public static Sprite 修罗花种子;

	public static Sprite 修罗花收获;

	public static Sprite 修罗花变异收获;

	public static Sprite 金乌葵幼苗;

	public static Sprite 金乌葵成长;

	public static Sprite 金乌葵成熟;

	public static Sprite 金乌葵变异;

	public static Sprite 金乌葵种子;

	public static Sprite 金乌葵收获;

	public static Sprite 金乌葵变异收获;

	public static Sprite 幻樱木幼苗;

	public static Sprite 幻樱木成长;

	public static Sprite 幻樱木成熟;

	public static Sprite 幻樱木变异;

	public static Sprite 幻樱木种子;

	public static Sprite 幻樱木收获;

	public static Sprite 幻樱木变异收获;

	public static Sprite 白玉莲幼苗;

	public static Sprite 白玉莲成长;

	public static Sprite 白玉莲成熟;

	public static Sprite 白玉莲变异;

	public static Sprite 白玉莲种子;

	public static Sprite 白玉莲收获;

	public static Sprite 白玉莲变异收获;

	public static Sprite 仙子icon1;

	public static Sprite 仙子icon2;

	public static Sprite 仙子icon3;

	public static Sprite 仙子icon4;

	public static Sprite 仙子icon5;

	public static Sprite 仙子icon6;

	public static Sprite 仙子icon7;

	public static Sprite 仙子icon8;

	public static Sprite 仙子icon9;

	public static Sprite 仙子icon10;

	public static Sprite 仙子icon11;

	public static Sprite 仙子icon12;

	public static Sprite 仙子icon13;

	public static Sprite 仙子icon14;

	public static Sprite 仙子头像1;

	public static Sprite 仙子头像2;

	public static Sprite 仙子头像3;

	public static Sprite 仙子头像4;

	public static Sprite 仙子头像5;

	public static Sprite 仙子头像6;

	public static Sprite 仙子头像7;

	public static Sprite 仙子头像8;

	public static Sprite 仙子头像9;

	public static Sprite 仙子头像10;

	public static Sprite 仙子头像11;

	public static Sprite 仙子头像12;

	public static Sprite 仙子头像13;

	public static Sprite 仙子头像14;

	public static Sprite 火1;

	public static Sprite 火2;

	public static Sprite 火3;

	public static Sprite 火4;

	public static Sprite 火5;

	public static Sprite 火6;

	public static Sprite 火7;

	public static Sprite 火8;

	public static Sprite 电1;

	public static Sprite 电2;

	public static Sprite 电3;

	public static Sprite 电4;

	public static Sprite 电5;

	public static Sprite 电6;

	public static Sprite 电7;

	public static Sprite 电8;

	public static Sprite 物1;

	public static Sprite 物2;

	public static Sprite 物3;

	public static Sprite 物4;

	public static Sprite 物5;

	public static Sprite 物6;

	public static Sprite 物7;

	public static Sprite 物8;

	public static Sprite 冰1;

	public static Sprite 冰2;

	public static Sprite 冰3;

	public static Sprite 冰4;

	public static Sprite 冰5;

	public static Sprite 冰6;

	public static Sprite 冰7;

	public static Sprite 冰8;

	public static Sprite 暗1;

	public static Sprite 暗2;

	public static Sprite 暗3;

	public static Sprite 暗4;

	public static Sprite 暗5;

	public static Sprite 暗6;

	public static Sprite 暗7;

	public static Sprite 暗8;

	public static Sprite 公;

	public static Sprite 母;

	public static Sprite 星星;

	public static Sprite 月亮;

	public static Sprite 太阳;

	public static Sprite 钻石;

	public static Sprite 轮回石;

	public static Sprite 血晶;

	public static Sprite 玄铁;

	public static Sprite 矿石;

	public static Sprite 玉髓;

	public static Sprite 建筑item暗;

	public static Sprite 建筑item亮;

	public static Sprite 道场矿场;

	public static Sprite 道场玄铁洞;

	public static Sprite 道场地脉;

	public static Sprite 道场功德碑;

	public static Sprite 道场坊市;

	public static Sprite 道场炼丹室;

	public static Sprite 道场炼器室;

	public static Sprite 道场领主府;

	public static Sprite 道场聚贤阁;

	public static Sprite 道场仙女阁;

	public static Sprite 道场灵兽坊;

	public static Sprite 道场灵植园;

	public static Sprite 红按钮;

	public static Sprite 黑按钮;

	public static Sprite toggle亮;

	public static Sprite toggle暗;

	public static Sprite 供奉品质标签白;

	public static Sprite 供奉品质标签绿;

	public static Sprite 供奉品质标签蓝;

	public static Sprite 供奉品质标签紫;

	public static Sprite 供奉品质标签橙;

	public static Sprite 供奉品质标签粉;

	public static Sprite 供奉品质标签红;

	public static Sprite 供奉品质标签彩;

	public static Sprite 供奉特性标签白;

	public static Sprite 供奉特性标签绿;

	public static Sprite 供奉特性标签蓝;

	public static Sprite 供奉特性标签紫;

	public static Sprite 供奉特性标签橙;

	public static Sprite 供奉特性标签粉;

	public static Sprite 供奉特性标签红;

	public static Sprite 供奉特性标签彩;

	public static Sprite 矿;

	public static Sprite 丹;

	public static Sprite 器;

	public static Sprite 贤;

	public static Sprite 铁;

	public static Sprite 玉;

	public static Sprite 德;

	public static Sprite 坊;

	public static Sprite 兽;

	public static Sprite 仙;

	public static Sprite 女供奉1;

	public static Sprite 女供奉2;

	public static Sprite 女供奉3;

	public static Sprite 女供奉4;

	public static Sprite 女供奉5;

	public static Sprite 女供奉6;

	public static Sprite 女供奉7;

	public static Sprite 女供奉8;

	public static Sprite 女供奉9;

	public static Sprite 女供奉10;

	public static Sprite 女供奉11;

	public static Sprite 女供奉12;

	public static Sprite 女供奉13;

	public static Sprite 女供奉14;

	public static Sprite 女供奉15;

	public static Sprite 女供奉16;

	public static Sprite 女供奉17;

	public static Sprite 女供奉18;

	public static Sprite 女供奉19;

	public static Sprite 女供奉20;

	public static Sprite 女供奉21;

	public static Sprite 女供奉22;

	public static Sprite 女供奉23;

	public static Sprite 女供奉24;

	public static Sprite 女供奉25;

	public static Sprite 女供奉26;

	public static Sprite 女供奉27;

	public static Sprite 女供奉28;

	public static Sprite 女供奉29;

	public static Sprite 女供奉30;

	public static Dictionary<符文Type, Sprite[]> 符文SpriteCache = new Dictionary<符文Type, Sprite[]>();

	public static Sprite 丹童平台;

	public static Sprite 土地平台;

	public static Sprite 河伯平台;

	public static Sprite 瑶池仙女平台;

	public static Sprite 石敢当平台;

	public static Sprite 玄女平台;

	public static Sprite 龟丞相平台;

	public static Sprite 太白金星平台;

	public static Sprite 多闻天王平台;

	public static Sprite 广目天王平台;

	public static Sprite 雷震子平台;

	public static Sprite 月老平台;

	public static Sprite 嫦娥平台;

	public static Sprite 杨戬平台;

	public static Sprite 妲己平台;

	public static Sprite 牛魔王平台;

	public static Sprite 哪吒平台;

	public static Sprite 孙悟空平台;

	public static Sprite 碧霄平台;

	public static Sprite 琼霄平台;

	public static Sprite 羲和平台;

	public static Sprite 常羲平台;

	public static Sprite 后羿平台;

	public static Sprite 云霄平台;

	public static Sprite 女娲平台;

	public static Sprite 老子平台;

	public static Sprite 通天平台;

	public static Sprite 元始平台;

	public static Sprite 鸿钧平台;

	public static Sprite 盘古平台;

	public static Sprite 丹童头像;

	public static Sprite 土地头像;

	public static Sprite 河伯头像;

	public static Sprite 瑶池仙女头像;

	public static Sprite 石敢当头像;

	public static Sprite 玄女头像;

	public static Sprite 龟丞相头像;

	public static Sprite 太白金星头像;

	public static Sprite 多闻天王头像;

	public static Sprite 广目天王头像;

	public static Sprite 雷震子头像;

	public static Sprite 月老头像;

	public static Sprite 嫦娥头像;

	public static Sprite 杨戬头像;

	public static Sprite 妲己头像;

	public static Sprite 牛魔王头像;

	public static Sprite 哪吒头像;

	public static Sprite 孙悟空头像;

	public static Sprite 碧霄头像;

	public static Sprite 琼霄头像;

	public static Sprite 羲和头像;

	public static Sprite 常羲头像;

	public static Sprite 后羿头像;

	public static Sprite 云霄头像;

	public static Sprite 女娲头像;

	public static Sprite 老子头像;

	public static Sprite 通天头像;

	public static Sprite 元始头像;

	public static Sprite 鸿钧头像;

	public static Sprite 盘古头像;

	public static Sprite 编队界面英雄背景框白;

	public static Sprite 编队界面英雄背景框绿;

	public static Sprite 编队界面英雄背景框蓝;

	public static Sprite 编队界面英雄背景框紫;

	public static Sprite 编队界面英雄背景框橙;

	public static Sprite 编队界面英雄背景框粉;

	public static Sprite 编队界面英雄背景框红;

	public static Sprite 编队界面英雄背景框彩;

	public static Sprite 装备背景框;

	public static Sprite 标签亮;

	public static Sprite 标签暗;

	public static Sprite 英雄背景框白;

	public static Sprite 英雄背景框绿;

	public static Sprite 英雄背景框蓝;

	public static Sprite 英雄背景框紫;

	public static Sprite 英雄背景框粉;

	public static Sprite 英雄背景框橙;

	public static Sprite 英雄背景框红;

	public static Sprite 英雄背景框彩;

	public static Sprite 圆环暗;

	public static Sprite 圆环亮;

	public static Sprite 英雄伤害;

	public static Sprite 技能冷却缩减;

	public static Sprite 击退距离;

	public static Sprite 效果范围;

	public static Sprite 瑶池减速效果;

	public static Sprite 瑶池持续时间;

	public static Sprite 龟丞相减速;

	public static Sprite 妲己效果;

	public static Sprite 妲己持续时间;

	public static Sprite 孙悟空挥棒次数;

	public static Sprite 琼霄控制时长;

	public static Sprite 女娲效果;

	public static Sprite 女娲持续时间;

	public static Sprite 元始火种个数;

	public static Sprite 火种旋转速度;

	public static Sprite 元始下场时间;

	public static Sprite 玄冰风弹道速度减少;

	public static Sprite 玄冰风每秒增长速度增加;

	public static Sprite 无极天火数量;

	public static Sprite 混沌开天拳出拳数量增加;

	public static Sprite 神通冷却时间;

	public static Sprite 神通伤害1;

	public static Sprite 神通伤害2;

	public static Sprite 神通能量;

	public static Sprite 被辅助英雄伤害;

	public static Sprite 被辅助英雄暴击率;

	public static Sprite 被辅助英雄暴击伤害;

	public static Sprite 技能伤害1;

	public static Sprite 技能伤害2;

	public static Sprite 射手分裂;

	public static Sprite 射手穿透;

	public static Sprite 物理伤害;

	public static Sprite 雷电伤害;

	public static Sprite 黑暗伤害;

	public static Sprite 火焰伤害;

	public static Sprite 冰霜伤害;

	public static Sprite 火焰灼烧伤害;

	public static Sprite 火焰灼烧时间;

	public static Sprite 火焰灼烧最大层数;

	public static Sprite 冰减速;

	public static Sprite 冰概率冰冻;

	public static Sprite 冰冻时间;

	public static Sprite 冰冻增伤;

	public static Sprite 易电状态概率;

	public static Sprite 易电状态时间;

	public static Sprite 易电状态伤害;

	public static Sprite 黑暗印记储存伤害;

	public static Sprite 黑暗印记减少引爆层数;

	public static Sprite 黑暗印记增加引爆层数;

	public static Sprite 物理碎甲怪物百分比;

	public static Sprite 物理碎甲领主攻击百分比;

	public static Sprite 物理无抗性加伤害;

	public static Sprite 增加所有英雄伤害;

	public static Sprite 寻宝速度;

	public static Sprite 概率紫变橙;

	public static Sprite 概率橙变粉;

	public static Sprite 概率粉变红;

	public static Sprite 概率红变彩;

	public static Sprite 概率提升数量;

	public static Sprite 暴击率;

	public static Sprite 暴击伤害;

	public static Sprite 普通怪增伤;

	public static Sprite 精英怪增伤;

	public static Sprite 首领怪增伤;

	public static Sprite 石敢当锤子速度;

	public static Sprite 被辅助英雄普通怪伤害;

	public static Sprite 被辅助英雄精英怪伤害;

	public static Sprite 被辅助英雄首领怪伤害;

	public static Sprite 被辅助元素伤害;

	public static Sprite 哪吒神通数量;

	public static Sprite 碧霄神通数量;

	public static Sprite 羲和神通数量;

	public static Sprite 被辅助英雄技能伤害;

	public static Sprite 女娲神通效果;

	public static AudioClip 丹童神通配音;

	public static Sprite 丹童神通icon;

	public static Sprite 土地神通icon;

	public static Sprite 河伯神通icon;

	public static Sprite 瑶池仙女神通icon;

	public static Sprite 石敢当神通icon;

	public static Sprite 玄女神通icon;

	public static Sprite 龟丞相神通icon;

	public static Sprite 太白金星神通icon;

	public static Sprite 多闻天王神通icon;

	public static Sprite 广目天王神通icon;

	public static Sprite 雷震子神通icon;

	public static Sprite 月老神通icon;

	public static Sprite 嫦娥神通icon;

	public static Sprite 杨戬神通icon;

	public static Sprite 妲己神通icon;

	public static Sprite 牛魔王神通icon;

	public static Sprite 哪吒神通icon;

	public static Sprite 孙悟空神通icon;

	public static Sprite 碧霄神通icon;

	public static Sprite 琼霄神通icon;

	public static Sprite 羲和神通icon;

	public static Sprite 常羲神通icon;

	public static Sprite 后羿神通icon;

	public static Sprite 云霄神通icon;

	public static Sprite 女娲神通icon;

	public static Sprite 老子神通icon;

	public static Sprite 通天神通icon;

	public static Sprite 元始神通icon;

	public static Sprite 鸿钧神通icon;

	public static Sprite 盘古神通icon;

	public static Sprite 丹童神通横幅;

	public static Sprite 土地神通横幅;

	public static Sprite 河伯神通横幅;

	public static Sprite 瑶池仙女神通横幅;

	public static Sprite 石敢当神通横幅;

	public static Sprite 玄女神通横幅;

	public static Sprite 龟丞相神通横幅;

	public static Sprite 太白金星神通横幅;

	public static Sprite 多闻天王神通横幅;

	public static Sprite 广目天王神通横幅;

	public static Sprite 雷震子神通横幅;

	public static Sprite 月老神通横幅;

	public static Sprite 嫦娥神通横幅;

	public static Sprite 杨戬神通横幅;

	public static Sprite 妲己神通横幅;

	public static Sprite 牛魔王神通横幅;

	public static Sprite 哪吒神通横幅;

	public static Sprite 孙悟空神通横幅;

	public static Sprite 碧霄神通横幅;

	public static Sprite 琼霄神通横幅;

	public static Sprite 羲和神通横幅;

	public static Sprite 常羲神通横幅;

	public static Sprite 后羿神通横幅;

	public static Sprite 云霄神通横幅;

	public static Sprite 女娲神通横幅;

	public static Sprite 老子神通横幅;

	public static Sprite 通天神通横幅;

	public static Sprite 元始神通横幅;

	public static Sprite 鸿钧神通横幅;

	public static Sprite 盘古神通横幅;

	public static Sprite Buff修炼速度白;

	public static Sprite Buff修炼速度绿;

	public static Sprite Buff修炼速度蓝;

	public static Sprite Buff修炼速度紫;

	public static Sprite Buff修炼速度橙;

	public static Sprite Buff修炼速度粉;

	public static Sprite Buff修炼速度红;

	public static Sprite Buff修炼速度彩;

	public static Sprite Buff掉宝率白;

	public static Sprite Buff掉宝率绿;

	public static Sprite Buff掉宝率蓝;

	public static Sprite Buff掉宝率紫;

	public static Sprite Buff掉宝率橙;

	public static Sprite Buff掉宝率粉;

	public static Sprite Buff掉宝率红;

	public static Sprite Buff掉宝率彩;

	public static Sprite 加号背景框1;

	public static Sprite 丹方火焰伤害白;

	public static Sprite 丹方火焰伤害绿;

	public static Sprite 丹方火焰伤害蓝;

	public static Sprite 丹方火焰伤害紫;

	public static Sprite 丹方火焰伤害橙;

	public static Sprite 丹方火焰伤害粉;

	public static Sprite 丹方火焰伤害红;

	public static Sprite 丹方火焰伤害彩;

	public static Sprite 丹方冰霜伤害白;

	public static Sprite 丹方冰霜伤害绿;

	public static Sprite 丹方冰霜伤害蓝;

	public static Sprite 丹方冰霜伤害紫;

	public static Sprite 丹方冰霜伤害橙;

	public static Sprite 丹方冰霜伤害粉;

	public static Sprite 丹方冰霜伤害红;

	public static Sprite 丹方冰霜伤害彩;

	public static Sprite 丹方雷电伤害白;

	public static Sprite 丹方雷电伤害绿;

	public static Sprite 丹方雷电伤害蓝;

	public static Sprite 丹方雷电伤害紫;

	public static Sprite 丹方雷电伤害橙;

	public static Sprite 丹方雷电伤害粉;

	public static Sprite 丹方雷电伤害红;

	public static Sprite 丹方雷电伤害彩;

	public static Sprite 丹方黑暗伤害白;

	public static Sprite 丹方黑暗伤害绿;

	public static Sprite 丹方黑暗伤害蓝;

	public static Sprite 丹方黑暗伤害紫;

	public static Sprite 丹方黑暗伤害橙;

	public static Sprite 丹方黑暗伤害粉;

	public static Sprite 丹方黑暗伤害红;

	public static Sprite 丹方黑暗伤害彩;

	public static Sprite 丹方物理伤害白;

	public static Sprite 丹方物理伤害绿;

	public static Sprite 丹方物理伤害蓝;

	public static Sprite 丹方物理伤害紫;

	public static Sprite 丹方物理伤害橙;

	public static Sprite 丹方物理伤害粉;

	public static Sprite 丹方物理伤害红;

	public static Sprite 丹方物理伤害彩;

	public static Sprite 丹方战士伤害白;

	public static Sprite 丹方战士伤害绿;

	public static Sprite 丹方战士伤害蓝;

	public static Sprite 丹方战士伤害紫;

	public static Sprite 丹方战士伤害橙;

	public static Sprite 丹方战士伤害粉;

	public static Sprite 丹方战士伤害红;

	public static Sprite 丹方战士伤害彩;

	public static Sprite 丹方法师伤害白;

	public static Sprite 丹方法师伤害绿;

	public static Sprite 丹方法师伤害蓝;

	public static Sprite 丹方法师伤害紫;

	public static Sprite 丹方法师伤害橙;

	public static Sprite 丹方法师伤害粉;

	public static Sprite 丹方法师伤害红;

	public static Sprite 丹方法师伤害彩;

	public static Sprite 丹方射手伤害白;

	public static Sprite 丹方射手伤害绿;

	public static Sprite 丹方射手伤害蓝;

	public static Sprite 丹方射手伤害紫;

	public static Sprite 丹方射手伤害橙;

	public static Sprite 丹方射手伤害粉;

	public static Sprite 丹方射手伤害红;

	public static Sprite 丹方射手伤害彩;

	public static Sprite 丹方控制伤害白;

	public static Sprite 丹方控制伤害绿;

	public static Sprite 丹方控制伤害蓝;

	public static Sprite 丹方控制伤害紫;

	public static Sprite 丹方控制伤害橙;

	public static Sprite 丹方控制伤害粉;

	public static Sprite 丹方控制伤害红;

	public static Sprite 丹方控制伤害彩;

	public static Sprite 丹方辅助伤害白;

	public static Sprite 丹方辅助伤害绿;

	public static Sprite 丹方辅助伤害蓝;

	public static Sprite 丹方辅助伤害紫;

	public static Sprite 丹方辅助伤害橙;

	public static Sprite 丹方辅助伤害粉;

	public static Sprite 丹方辅助伤害红;

	public static Sprite 丹方辅助伤害彩;

	public static Sprite 丹方最终伤害白;

	public static Sprite 丹方最终伤害绿;

	public static Sprite 丹方最终伤害蓝;

	public static Sprite 丹方最终伤害紫;

	public static Sprite 丹方最终伤害橙;

	public static Sprite 丹方最终伤害粉;

	public static Sprite 丹方最终伤害红;

	public static Sprite 丹方最终伤害彩;

	public static Sprite 丹方修炼速度白;

	public static Sprite 丹方修炼速度绿;

	public static Sprite 丹方修炼速度蓝;

	public static Sprite 丹方修炼速度紫;

	public static Sprite 丹方修炼速度橙;

	public static Sprite 丹方修炼速度粉;

	public static Sprite 丹方修炼速度红;

	public static Sprite 丹方修炼速度彩;

	public static Sprite 丹方掉宝率白;

	public static Sprite 丹方掉宝率绿;

	public static Sprite 丹方掉宝率蓝;

	public static Sprite 丹方掉宝率紫;

	public static Sprite 丹方掉宝率橙;

	public static Sprite 丹方掉宝率粉;

	public static Sprite 丹方掉宝率红;

	public static Sprite 丹方掉宝率彩;

	public static Sprite 丹方英雄暴击伤害白;

	public static Sprite 丹方英雄暴击伤害绿;

	public static Sprite 丹方英雄暴击伤害蓝;

	public static Sprite 丹方英雄暴击伤害紫;

	public static Sprite 丹方英雄暴击伤害橙;

	public static Sprite 丹方英雄暴击伤害粉;

	public static Sprite 丹方英雄暴击伤害红;

	public static Sprite 丹方英雄暴击伤害彩;

	public static Sprite 丹方加跟脚白;

	public static Sprite 丹方加跟脚绿;

	public static Sprite 丹方加跟脚蓝;

	public static Sprite 丹方加跟脚紫;

	public static Sprite 丹方加跟脚橙;

	public static Sprite 丹方加跟脚粉;

	public static Sprite 丹方加跟脚红;

	public static Sprite 丹方加跟脚彩;

	public static Sprite 丹方英雄火焰伤害白;

	public static Sprite 丹方英雄火焰伤害绿;

	public static Sprite 丹方英雄火焰伤害蓝;

	public static Sprite 丹方英雄火焰伤害紫;

	public static Sprite 丹方英雄火焰伤害橙;

	public static Sprite 丹方英雄火焰伤害粉;

	public static Sprite 丹方英雄火焰伤害红;

	public static Sprite 丹方英雄火焰伤害彩;

	public static Sprite 丹方英雄冰霜伤害白;

	public static Sprite 丹方英雄冰霜伤害绿;

	public static Sprite 丹方英雄冰霜伤害蓝;

	public static Sprite 丹方英雄冰霜伤害紫;

	public static Sprite 丹方英雄冰霜伤害橙;

	public static Sprite 丹方英雄冰霜伤害粉;

	public static Sprite 丹方英雄冰霜伤害红;

	public static Sprite 丹方英雄冰霜伤害彩;

	public static Sprite 丹方英雄雷电伤害白;

	public static Sprite 丹方英雄雷电伤害绿;

	public static Sprite 丹方英雄雷电伤害蓝;

	public static Sprite 丹方英雄雷电伤害紫;

	public static Sprite 丹方英雄雷电伤害橙;

	public static Sprite 丹方英雄雷电伤害粉;

	public static Sprite 丹方英雄雷电伤害红;

	public static Sprite 丹方英雄雷电伤害彩;

	public static Sprite 丹方英雄黑暗伤害白;

	public static Sprite 丹方英雄黑暗伤害绿;

	public static Sprite 丹方英雄黑暗伤害蓝;

	public static Sprite 丹方英雄黑暗伤害紫;

	public static Sprite 丹方英雄黑暗伤害橙;

	public static Sprite 丹方英雄黑暗伤害粉;

	public static Sprite 丹方英雄黑暗伤害红;

	public static Sprite 丹方英雄黑暗伤害彩;

	public static Sprite 丹方英雄物理伤害白;

	public static Sprite 丹方英雄物理伤害绿;

	public static Sprite 丹方英雄物理伤害蓝;

	public static Sprite 丹方英雄物理伤害紫;

	public static Sprite 丹方英雄物理伤害橙;

	public static Sprite 丹方英雄物理伤害粉;

	public static Sprite 丹方英雄物理伤害红;

	public static Sprite 丹方英雄物理伤害彩;

	public static Sprite 丹方英雄战士伤害白;

	public static Sprite 丹方英雄战士伤害绿;

	public static Sprite 丹方英雄战士伤害蓝;

	public static Sprite 丹方英雄战士伤害紫;

	public static Sprite 丹方英雄战士伤害橙;

	public static Sprite 丹方英雄战士伤害粉;

	public static Sprite 丹方英雄战士伤害红;

	public static Sprite 丹方英雄战士伤害彩;

	public static Sprite 丹方英雄法师伤害白;

	public static Sprite 丹方英雄法师伤害绿;

	public static Sprite 丹方英雄法师伤害蓝;

	public static Sprite 丹方英雄法师伤害紫;

	public static Sprite 丹方英雄法师伤害橙;

	public static Sprite 丹方英雄法师伤害粉;

	public static Sprite 丹方英雄法师伤害红;

	public static Sprite 丹方英雄法师伤害彩;

	public static Sprite 丹方英雄射手伤害白;

	public static Sprite 丹方英雄射手伤害绿;

	public static Sprite 丹方英雄射手伤害蓝;

	public static Sprite 丹方英雄射手伤害紫;

	public static Sprite 丹方英雄射手伤害橙;

	public static Sprite 丹方英雄射手伤害粉;

	public static Sprite 丹方英雄射手伤害红;

	public static Sprite 丹方英雄射手伤害彩;

	public static Sprite 丹方英雄控制伤害白;

	public static Sprite 丹方英雄控制伤害绿;

	public static Sprite 丹方英雄控制伤害蓝;

	public static Sprite 丹方英雄控制伤害紫;

	public static Sprite 丹方英雄控制伤害橙;

	public static Sprite 丹方英雄控制伤害粉;

	public static Sprite 丹方英雄控制伤害红;

	public static Sprite 丹方英雄控制伤害彩;

	public static Sprite 丹方英雄辅助伤害白;

	public static Sprite 丹方英雄辅助伤害绿;

	public static Sprite 丹方英雄辅助伤害蓝;

	public static Sprite 丹方英雄辅助伤害紫;

	public static Sprite 丹方英雄辅助伤害橙;

	public static Sprite 丹方英雄辅助伤害粉;

	public static Sprite 丹方英雄辅助伤害红;

	public static Sprite 丹方英雄辅助伤害彩;

	public static Sprite 丹方英雄最终伤害白;

	public static Sprite 丹方英雄最终伤害绿;

	public static Sprite 丹方英雄最终伤害蓝;

	public static Sprite 丹方英雄最终伤害紫;

	public static Sprite 丹方英雄最终伤害橙;

	public static Sprite 丹方英雄最终伤害粉;

	public static Sprite 丹方英雄最终伤害红;

	public static Sprite 丹方英雄最终伤害彩;

	public static Sprite 火焰伤害白;

	public static Sprite 火焰伤害绿;

	public static Sprite 火焰伤害蓝;

	public static Sprite 火焰伤害紫;

	public static Sprite 火焰伤害橙;

	public static Sprite 火焰伤害粉;

	public static Sprite 火焰伤害红;

	public static Sprite 火焰伤害彩;

	public static Sprite 冰霜伤害白;

	public static Sprite 冰霜伤害绿;

	public static Sprite 冰霜伤害蓝;

	public static Sprite 冰霜伤害紫;

	public static Sprite 冰霜伤害橙;

	public static Sprite 冰霜伤害粉;

	public static Sprite 冰霜伤害红;

	public static Sprite 冰霜伤害彩;

	public static Sprite 雷电伤害白;

	public static Sprite 雷电伤害绿;

	public static Sprite 雷电伤害蓝;

	public static Sprite 雷电伤害紫;

	public static Sprite 雷电伤害橙;

	public static Sprite 雷电伤害粉;

	public static Sprite 雷电伤害红;

	public static Sprite 雷电伤害彩;

	public static Sprite 黑暗伤害白;

	public static Sprite 黑暗伤害绿;

	public static Sprite 黑暗伤害蓝;

	public static Sprite 黑暗伤害紫;

	public static Sprite 黑暗伤害橙;

	public static Sprite 黑暗伤害粉;

	public static Sprite 黑暗伤害红;

	public static Sprite 黑暗伤害彩;

	public static Sprite 物理伤害白;

	public static Sprite 物理伤害绿;

	public static Sprite 物理伤害蓝;

	public static Sprite 物理伤害紫;

	public static Sprite 物理伤害橙;

	public static Sprite 物理伤害粉;

	public static Sprite 物理伤害红;

	public static Sprite 物理伤害彩;

	public static Sprite 战士伤害白;

	public static Sprite 战士伤害绿;

	public static Sprite 战士伤害蓝;

	public static Sprite 战士伤害紫;

	public static Sprite 战士伤害橙;

	public static Sprite 战士伤害粉;

	public static Sprite 战士伤害红;

	public static Sprite 战士伤害彩;

	public static Sprite 法师伤害白;

	public static Sprite 法师伤害绿;

	public static Sprite 法师伤害蓝;

	public static Sprite 法师伤害紫;

	public static Sprite 法师伤害橙;

	public static Sprite 法师伤害粉;

	public static Sprite 法师伤害红;

	public static Sprite 法师伤害彩;

	public static Sprite 射手伤害白;

	public static Sprite 射手伤害绿;

	public static Sprite 射手伤害蓝;

	public static Sprite 射手伤害紫;

	public static Sprite 射手伤害橙;

	public static Sprite 射手伤害粉;

	public static Sprite 射手伤害红;

	public static Sprite 射手伤害彩;

	public static Sprite 控制伤害白;

	public static Sprite 控制伤害绿;

	public static Sprite 控制伤害蓝;

	public static Sprite 控制伤害紫;

	public static Sprite 控制伤害橙;

	public static Sprite 控制伤害粉;

	public static Sprite 控制伤害红;

	public static Sprite 控制伤害彩;

	public static Sprite 辅助伤害白;

	public static Sprite 辅助伤害绿;

	public static Sprite 辅助伤害蓝;

	public static Sprite 辅助伤害紫;

	public static Sprite 辅助伤害橙;

	public static Sprite 辅助伤害粉;

	public static Sprite 辅助伤害红;

	public static Sprite 辅助伤害彩;

	public static Sprite 最终伤害白;

	public static Sprite 最终伤害绿;

	public static Sprite 最终伤害蓝;

	public static Sprite 最终伤害紫;

	public static Sprite 最终伤害橙;

	public static Sprite 最终伤害粉;

	public static Sprite 最终伤害红;

	public static Sprite 最终伤害彩;

	public static Sprite 修炼速度白;

	public static Sprite 修炼速度绿;

	public static Sprite 修炼速度蓝;

	public static Sprite 修炼速度紫;

	public static Sprite 修炼速度橙;

	public static Sprite 修炼速度粉;

	public static Sprite 修炼速度红;

	public static Sprite 修炼速度彩;

	public static Sprite 掉宝率白;

	public static Sprite 掉宝率绿;

	public static Sprite 掉宝率蓝;

	public static Sprite 掉宝率紫;

	public static Sprite 掉宝率橙;

	public static Sprite 掉宝率粉;

	public static Sprite 掉宝率红;

	public static Sprite 掉宝率彩;

	public static Sprite 英雄暴击伤害白;

	public static Sprite 英雄暴击伤害绿;

	public static Sprite 英雄暴击伤害蓝;

	public static Sprite 英雄暴击伤害紫;

	public static Sprite 英雄暴击伤害橙;

	public static Sprite 英雄暴击伤害粉;

	public static Sprite 英雄暴击伤害红;

	public static Sprite 英雄暴击伤害彩;

	public static Sprite 加跟脚白;

	public static Sprite 加跟脚绿;

	public static Sprite 加跟脚蓝;

	public static Sprite 加跟脚紫;

	public static Sprite 加跟脚橙;

	public static Sprite 加跟脚粉;

	public static Sprite 加跟脚红;

	public static Sprite 加跟脚彩;

	public static Sprite 英雄火焰伤害白;

	public static Sprite 英雄火焰伤害绿;

	public static Sprite 英雄火焰伤害蓝;

	public static Sprite 英雄火焰伤害紫;

	public static Sprite 英雄火焰伤害橙;

	public static Sprite 英雄火焰伤害粉;

	public static Sprite 英雄火焰伤害红;

	public static Sprite 英雄火焰伤害彩;

	public static Sprite 英雄冰霜伤害白;

	public static Sprite 英雄冰霜伤害绿;

	public static Sprite 英雄冰霜伤害蓝;

	public static Sprite 英雄冰霜伤害紫;

	public static Sprite 英雄冰霜伤害橙;

	public static Sprite 英雄冰霜伤害粉;

	public static Sprite 英雄冰霜伤害红;

	public static Sprite 英雄冰霜伤害彩;

	public static Sprite 英雄雷电伤害白;

	public static Sprite 英雄雷电伤害绿;

	public static Sprite 英雄雷电伤害蓝;

	public static Sprite 英雄雷电伤害紫;

	public static Sprite 英雄雷电伤害橙;

	public static Sprite 英雄雷电伤害粉;

	public static Sprite 英雄雷电伤害红;

	public static Sprite 英雄雷电伤害彩;

	public static Sprite 英雄黑暗伤害白;

	public static Sprite 英雄黑暗伤害绿;

	public static Sprite 英雄黑暗伤害蓝;

	public static Sprite 英雄黑暗伤害紫;

	public static Sprite 英雄黑暗伤害橙;

	public static Sprite 英雄黑暗伤害粉;

	public static Sprite 英雄黑暗伤害红;

	public static Sprite 英雄黑暗伤害彩;

	public static Sprite 英雄物理伤害白;

	public static Sprite 英雄物理伤害绿;

	public static Sprite 英雄物理伤害蓝;

	public static Sprite 英雄物理伤害紫;

	public static Sprite 英雄物理伤害橙;

	public static Sprite 英雄物理伤害粉;

	public static Sprite 英雄物理伤害红;

	public static Sprite 英雄物理伤害彩;

	public static Sprite 英雄战士伤害白;

	public static Sprite 英雄战士伤害绿;

	public static Sprite 英雄战士伤害蓝;

	public static Sprite 英雄战士伤害紫;

	public static Sprite 英雄战士伤害橙;

	public static Sprite 英雄战士伤害粉;

	public static Sprite 英雄战士伤害红;

	public static Sprite 英雄战士伤害彩;

	public static Sprite 英雄法师伤害白;

	public static Sprite 英雄法师伤害绿;

	public static Sprite 英雄法师伤害蓝;

	public static Sprite 英雄法师伤害紫;

	public static Sprite 英雄法师伤害橙;

	public static Sprite 英雄法师伤害粉;

	public static Sprite 英雄法师伤害红;

	public static Sprite 英雄法师伤害彩;

	public static Sprite 英雄射手伤害白;

	public static Sprite 英雄射手伤害绿;

	public static Sprite 英雄射手伤害蓝;

	public static Sprite 英雄射手伤害紫;

	public static Sprite 英雄射手伤害橙;

	public static Sprite 英雄射手伤害粉;

	public static Sprite 英雄射手伤害红;

	public static Sprite 英雄射手伤害彩;

	public static Sprite 英雄控制伤害白;

	public static Sprite 英雄控制伤害绿;

	public static Sprite 英雄控制伤害蓝;

	public static Sprite 英雄控制伤害紫;

	public static Sprite 英雄控制伤害橙;

	public static Sprite 英雄控制伤害粉;

	public static Sprite 英雄控制伤害红;

	public static Sprite 英雄控制伤害彩;

	public static Sprite 英雄辅助伤害白;

	public static Sprite 英雄辅助伤害绿;

	public static Sprite 英雄辅助伤害蓝;

	public static Sprite 英雄辅助伤害紫;

	public static Sprite 英雄辅助伤害橙;

	public static Sprite 英雄辅助伤害粉;

	public static Sprite 英雄辅助伤害红;

	public static Sprite 英雄辅助伤害彩;

	public static Sprite 英雄最终伤害白;

	public static Sprite 英雄最终伤害绿;

	public static Sprite 英雄最终伤害蓝;

	public static Sprite 英雄最终伤害紫;

	public static Sprite 英雄最终伤害橙;

	public static Sprite 英雄最终伤害粉;

	public static Sprite 英雄最终伤害红;

	public static Sprite 英雄最终伤害彩;

	public static Sprite 金银花蕊白;

	public static Sprite 金银花蕊绿;

	public static Sprite 金银花蕊蓝;

	public static Sprite 金银花蕊紫;

	public static Sprite 金银花蕊橙;

	public static Sprite 金银花蕊粉;

	public static Sprite 金银花蕊红;

	public static Sprite 金银花蕊彩;

	public static Sprite 马兜铃果白;

	public static Sprite 马兜铃果绿;

	public static Sprite 马兜铃果蓝;

	public static Sprite 马兜铃果紫;

	public static Sprite 马兜铃果橙;

	public static Sprite 马兜铃果粉;

	public static Sprite 马兜铃果红;

	public static Sprite 马兜铃果彩;

	public static Sprite 四叶参根白;

	public static Sprite 四叶参根绿;

	public static Sprite 四叶参根蓝;

	public static Sprite 四叶参根紫;

	public static Sprite 四叶参根橙;

	public static Sprite 四叶参根粉;

	public static Sprite 四叶参根红;

	public static Sprite 四叶参根彩;

	public static Sprite 千年雪莲白;

	public static Sprite 千年雪莲绿;

	public static Sprite 千年雪莲蓝;

	public static Sprite 千年雪莲紫;

	public static Sprite 千年雪莲橙;

	public static Sprite 千年雪莲粉;

	public static Sprite 千年雪莲红;

	public static Sprite 千年雪莲彩;

	public static Sprite 回春草白;

	public static Sprite 回春草绿;

	public static Sprite 回春草蓝;

	public static Sprite 回春草紫;

	public static Sprite 回春草橙;

	public static Sprite 回春草粉;

	public static Sprite 回春草红;

	public static Sprite 回春草彩;

	public static Sprite 补血花白;

	public static Sprite 补血花绿;

	public static Sprite 补血花蓝;

	public static Sprite 补血花紫;

	public static Sprite 补血花橙;

	public static Sprite 补血花粉;

	public static Sprite 补血花红;

	public static Sprite 补血花彩;

	public static Sprite 龙纹草白;

	public static Sprite 龙纹草绿;

	public static Sprite 龙纹草蓝;

	public static Sprite 龙纹草紫;

	public static Sprite 龙纹草橙;

	public static Sprite 龙纹草粉;

	public static Sprite 龙纹草红;

	public static Sprite 龙纹草彩;

	public static Sprite 九曲黄泉草白;

	public static Sprite 九曲黄泉草绿;

	public static Sprite 九曲黄泉草蓝;

	public static Sprite 九曲黄泉草紫;

	public static Sprite 九曲黄泉草橙;

	public static Sprite 九曲黄泉草粉;

	public static Sprite 九曲黄泉草红;

	public static Sprite 九曲黄泉草彩;

	public static Sprite 千幻蝶恋花白;

	public static Sprite 千幻蝶恋花绿;

	public static Sprite 千幻蝶恋花蓝;

	public static Sprite 千幻蝶恋花紫;

	public static Sprite 千幻蝶恋花橙;

	public static Sprite 千幻蝶恋花粉;

	public static Sprite 千幻蝶恋花红;

	public static Sprite 千幻蝶恋花彩;

	public static Sprite 聚灵凝神叶白;

	public static Sprite 聚灵凝神叶绿;

	public static Sprite 聚灵凝神叶蓝;

	public static Sprite 聚灵凝神叶紫;

	public static Sprite 聚灵凝神叶橙;

	public static Sprite 聚灵凝神叶粉;

	public static Sprite 聚灵凝神叶红;

	public static Sprite 聚灵凝神叶彩;

	public static Sprite 最终伤害;

	public static Sprite 冷却缩减;

	public static Sprite 全元素增伤;

	public static Sprite 元素人人为我;

	public static Sprite 元素我为人人;

	public static Sprite 全职业增伤;

	public static Sprite 职业人人为我;

	public static Sprite 职业我为人人;

	public static Sprite 暴击爆伤;

	public static Sprite 二次暴击;

	public static Sprite 轮回次数加伤;

	public static Sprite 轮回系数;

	public static Sprite 时间流速加快;

	public static Sprite 练气;

	public static Sprite 筑基;

	public static Sprite 金丹;

	public static Sprite 元婴;

	public static Sprite 化神;

	public static Sprite 合体;

	public static Sprite 大乘;

	public static Sprite 天仙;

	public static Sprite 玄仙;

	public static Sprite 金仙;

	public static Sprite 太乙金仙;

	public static Sprite 大罗金仙;

	public static Sprite 准圣;

	public static Sprite 圣人;

	public static Sprite 天道圣人;

	public static Sprite 大道圣人;

	public static Sprite 混元圣人;

	public static Sprite 仙石精华;
	public static Sprite 符箓;

	public static Sprite 法器粉尘;

	public static Sprite 古朴按钮亮;

	public static Sprite 古朴按钮暗;

	public static Sprite 按钮黑;

	public static Sprite 按钮白;

	public static Sprite 孔背景框;

	public static Dictionary<仙石Type, Sprite[]> 仙石SpriteCache = new Dictionary<仙石Type, Sprite[]>();

	public static Dictionary<法器Type, Sprite[]> 法器SpriteCache = new Dictionary<法器Type, Sprite[]>();

	public static Dictionary<法器材料Type, Sprite[]> 材料SpriteCache = new Dictionary<法器材料Type, Sprite[]>();

	public static Sprite 青木狼;

	public static Sprite 铁背龟;

	public static Sprite 荆棘猿;

	public static Sprite 千年树精;

	public static Sprite 熔岩蜥;

	public static Sprite 火鸦;

	public static Sprite 炎晶巨人;

	public static Sprite 地火蛟;

	public static Sprite 怨魂蝶;

	public static Sprite 食骨鳄;

	public static Sprite 无面鬼;

	public static Sprite 九幽尸王;

	public static Sprite 罡风鹫;

	public static Sprite 裂空蝎;

	public static Sprite 虚影兽;

	public static Sprite 双首海蛇;

	public static Sprite 幻鳞鱼;

	public static Sprite 铁钳蟹;

	public static Sprite 万象鲸;

	public static Sprite 饕餮;

	public static Sprite 云纹兽;

	public static Sprite 星光蝶;

	public static Sprite 朱雀;

	public static Sprite 白虎;

	public static Sprite 仙灵鹤;

	public static Sprite 玉兔精;

	public static Sprite 朱厌;

	public static Sprite 应龙;

	public static Sprite 虚空兽;

	public static Sprite 混沌兽;

	public static Sprite 归墟古凤;

	public static Sprite 归墟古龙;

	public static Sprite 道纹甲虫;

	public static Sprite 混沌蝠;

	public static Sprite 梼杌;

	public static Sprite 霸下;

	public static Sprite 玄黄蜉蝣;

	public static Sprite 剑齿虎;

	public static Sprite 混元兽;

	public static Sprite 道胎灵童;

	public static Sprite 青丘白狐;

	public static Sprite 青丘黑狐;

	public static Sprite 白泽;

	public static Sprite 九尾狐;

	public static Sprite 远古巨兽;

	public static Sprite 法则之兽;

	public static Sprite 凤凰;

	public static Sprite 真龙;

	public static Sprite 远古凶兽;

	public static Sprite 远古大蛇;

	public static Sprite 穷奇;

	public static Sprite 麒麟;

	public static Sprite 先天魔神;

	public static Sprite 混沌巨兽;

	public static Sprite 劫兽;

	public static Sprite 混沌之眼;

	public static Sprite 归墟古兽;

	public static Sprite 时空扭曲者;

	public static Sprite 混沌古兽;

	public static Sprite 永恒之门;

	public static Sprite 石皮野猪;

	public static Sprite 铁羽麻雀;

	public static Sprite 裂蹄蛮牛;

	public static Sprite 风吼应龙;

	public static Sprite 棘背豪猪;

	public static Sprite 赤眼乌鸦;

	public static Sprite 碎岩巨蜥;

	public static Sprite 雷翼飞廉;

	public static Sprite 甲壳穿山;

	public static Sprite 毒牙田鼠;

	public static Sprite 震地巨蟾;

	public static Sprite 冰晶玄龟;

	public static Sprite 骨刺刺猬;

	public static Sprite 火羽雉鸡;

	public static Sprite 熔岩巨蟒;

	public static Sprite 双首炎蟒;

	public static Sprite 铜鳞鲤鱼;

	public static Sprite 铁爪鹰隼;

	public static Sprite 金刚巨猿;

	public static Sprite 紫电麒麟;

	public static Sprite 青面狼妖;

	public static Sprite 赤尾狐精;

	public static Sprite 三眼毒蟾;

	public static Sprite 九尾天狐;

	public static Sprite 黑风蛇妖;

	public static Sprite 金瞳猫妖;

	public static Sprite 四臂魔猿;

	public static Sprite 七首蛟龙;

	public static Sprite 碧磷蝎精;

	public static Sprite 霜白蛛妖;

	public static Sprite 六翼蜈蚣;

	public static Sprite 八足火蛛;

	public static Sprite 黄沙鼠妖;

	public static Sprite 紫电貂精;

	public static Sprite 双头狼王;

	public static Sprite 金翅大鹏;

	public static Sprite 赤焰蚁精;

	public static Sprite 寒冰蝶妖;

	public static Sprite 五色毒蟾;

	public static Sprite 玄冥巨蟒;

	public static Sprite 噬骨秃鹫;

	public static Sprite 腐肉豺狼;

	public static Sprite 血瞳巨人;

	public static Sprite 三头地狱犬;

	public static Sprite 丧魂幽灵;

	public static Sprite 碎骨骷髅;

	public static Sprite 尸煞尸王;

	public static Sprite 六臂夜叉;

	public static Sprite 怨气怨灵;

	public static Sprite 诅咒木偶;

	public static Sprite 嗜血蝠王;

	public static Sprite 九婴凶蛇;

	public static Sprite 毒雾瘴精;

	public static Sprite 枯木树妖;

	public static Sprite 熔岩巨人;

	public static Sprite 赤地旱魃;

	public static Sprite 暗影影魔;

	public static Sprite 蚀金蚁群;

	public static Sprite 暴风巨鹏;

	public static Sprite 吞天朱厌;

	public static Sprite 雷霆石像;

	public static Sprite 寒冰雕像;

	public static Sprite 烈焰守护者;

	public static Sprite 混沌饕餮;

	public static Sprite 黄金剑狮;

	public static Sprite 月影毒狼;

	public static Sprite 星辰守护者;

	public static Sprite 太极鲲鹏;

	public static Sprite 地脉石灵;

	public static Sprite 天罡星傀;

	public static Sprite 时空撕裂者;

	public static Sprite 烛龙九阴;

	public static Sprite 虚无吞噬兽;

	public static Sprite 混沌畸变体;

	public static Sprite 轮回审判官;

	public static Sprite 魔化盘古;

	public static Sprite 因果裁决者;

	public static Sprite 终末湮灭虫;

	public static Sprite 命运编织者;

	public static Sprite 混沌道尊;

	public static Sprite 藤蔓猴;

	public static Sprite 木灵蝶;

	public static Sprite 千年树妖;

	public static Sprite 青木蛟;

	public static Sprite 火岩虫;

	public static Sprite 熔岩火蜥;

	public static Sprite 炎髓魔猿;

	public static Sprite 火山兽;

	public static Sprite 黑风貂;

	public static Sprite 浮空水母;

	public static Sprite 黑风双煞;

	public static Sprite 黑风老妖;

	public static Sprite 水形怪;

	public static Sprite 深渊鮟鱇;

	public static Sprite 玄水毒蛟;

	public static Sprite 玄水兽;

	public static Sprite 雷纹蛛;

	public static Sprite 雷灵球;

	public static Sprite 紫雷夔牛;

	public static Sprite 紫雷兽;

	public static Sprite 白骨兵;

	public static Sprite 噬魂鸦;

	public static Sprite 白骨将;

	public static Sprite 白骨兽;

	public static Sprite 金甲傀;

	public static Sprite 戈刃灵;

	public static Sprite 金戈将;

	public static Sprite 金戈兽;

	public static Sprite 幻梦蝶;

	public static Sprite 幻梦虫;

	public static Sprite 幻梦妖;

	public static Sprite 幻梦兽;

	public static Sprite 混沌虫;

	public static Sprite 吞噬兽;

	public static Sprite 混沌魔将;

	public static Sprite 混沌兽王;

	public static Sprite 天道卫;

	public static Sprite 造化灵;

	public static Sprite 天道将;

	public static Sprite 天道兽;

	public static Sprite 练气白;

	public static Sprite 练气绿;

	public static Sprite 练气蓝;

	public static Sprite 练气紫;

	public static Sprite 练气橙;

	public static Sprite 练气粉;

	public static Sprite 练气红;

	public static Sprite 练气彩;

	public static Sprite 筑基白;

	public static Sprite 筑基绿;

	public static Sprite 筑基蓝;

	public static Sprite 筑基紫;

	public static Sprite 筑基橙;

	public static Sprite 筑基粉;

	public static Sprite 筑基红;

	public static Sprite 筑基彩;

	public static Sprite 金丹白;

	public static Sprite 金丹绿;

	public static Sprite 金丹蓝;

	public static Sprite 金丹紫;

	public static Sprite 金丹橙;

	public static Sprite 金丹粉;

	public static Sprite 金丹红;

	public static Sprite 金丹彩;

	public static Sprite 元婴白;

	public static Sprite 元婴绿;

	public static Sprite 元婴蓝;

	public static Sprite 元婴紫;

	public static Sprite 元婴橙;

	public static Sprite 元婴粉;

	public static Sprite 元婴红;

	public static Sprite 元婴彩;

	public static Sprite 化神白;

	public static Sprite 化神绿;

	public static Sprite 化神蓝;

	public static Sprite 化神紫;

	public static Sprite 化神橙;

	public static Sprite 化神粉;

	public static Sprite 化神红;

	public static Sprite 化神彩;

	public static Sprite 合体白;

	public static Sprite 合体绿;

	public static Sprite 合体蓝;

	public static Sprite 合体紫;

	public static Sprite 合体橙;

	public static Sprite 合体粉;

	public static Sprite 合体红;

	public static Sprite 合体彩;

	public static Sprite 大乘白;

	public static Sprite 大乘绿;

	public static Sprite 大乘蓝;

	public static Sprite 大乘紫;

	public static Sprite 大乘橙;

	public static Sprite 大乘粉;

	public static Sprite 大乘红;

	public static Sprite 大乘彩;

	public static Sprite 天仙白;

	public static Sprite 天仙绿;

	public static Sprite 天仙蓝;

	public static Sprite 天仙紫;

	public static Sprite 天仙橙;

	public static Sprite 天仙粉;

	public static Sprite 天仙红;

	public static Sprite 天仙彩;

	public static Sprite 玄仙白;

	public static Sprite 玄仙绿;

	public static Sprite 玄仙蓝;

	public static Sprite 玄仙紫;

	public static Sprite 玄仙橙;

	public static Sprite 玄仙粉;

	public static Sprite 玄仙红;

	public static Sprite 玄仙彩;

	public static Sprite 金仙白;

	public static Sprite 金仙绿;

	public static Sprite 金仙蓝;

	public static Sprite 金仙紫;

	public static Sprite 金仙橙;

	public static Sprite 金仙粉;

	public static Sprite 金仙红;

	public static Sprite 金仙彩;

	public static Sprite 太乙金仙白;

	public static Sprite 太乙金仙绿;

	public static Sprite 太乙金仙蓝;

	public static Sprite 太乙金仙紫;

	public static Sprite 太乙金仙橙;

	public static Sprite 太乙金仙粉;

	public static Sprite 太乙金仙红;

	public static Sprite 太乙金仙彩;

	public static Sprite 大罗金仙白;

	public static Sprite 大罗金仙绿;

	public static Sprite 大罗金仙蓝;

	public static Sprite 大罗金仙紫;

	public static Sprite 大罗金仙橙;

	public static Sprite 大罗金仙粉;

	public static Sprite 大罗金仙红;

	public static Sprite 大罗金仙彩;

	public static Sprite 准圣白;

	public static Sprite 准圣绿;

	public static Sprite 准圣蓝;

	public static Sprite 准圣紫;

	public static Sprite 准圣橙;

	public static Sprite 准圣粉;

	public static Sprite 准圣红;

	public static Sprite 准圣彩;

	public static Sprite 圣人白;

	public static Sprite 圣人绿;

	public static Sprite 圣人蓝;

	public static Sprite 圣人紫;

	public static Sprite 圣人橙;

	public static Sprite 圣人粉;

	public static Sprite 圣人红;

	public static Sprite 圣人彩;

	public static Sprite 天道圣人白;

	public static Sprite 天道圣人绿;

	public static Sprite 天道圣人蓝;

	public static Sprite 天道圣人紫;

	public static Sprite 天道圣人橙;

	public static Sprite 天道圣人粉;

	public static Sprite 天道圣人红;

	public static Sprite 天道圣人彩;

	public static Sprite 大道圣人白;

	public static Sprite 大道圣人绿;

	public static Sprite 大道圣人蓝;

	public static Sprite 大道圣人紫;

	public static Sprite 大道圣人橙;

	public static Sprite 大道圣人粉;

	public static Sprite 大道圣人红;

	public static Sprite 大道圣人彩;

	public static Sprite 混元圣人白;

	public static Sprite 混元圣人绿;

	public static Sprite 混元圣人蓝;

	public static Sprite 混元圣人紫;

	public static Sprite 混元圣人橙;

	public static Sprite 混元圣人粉;

	public static Sprite 混元圣人红;

	public static Sprite 混元圣人彩;

	public static Sprite 功法经验;

	public static Sprite 传道背景框彩;

	public static Sprite 传道背景框橙;

	public static Sprite 传道背景框白;

	public static Sprite 传道背景框粉;

	public static Sprite 传道背景框紫;

	public static Sprite 传道背景框红;

	public static Sprite 传道背景框绿;

	public static Sprite 传道背景框蓝;

	public static Sprite 传道icon彩;

	public static Sprite 传道icon橙;

	public static Sprite 传道icon白;

	public static Sprite 传道icon粉;

	public static Sprite 传道icon紫;

	public static Sprite 传道icon红;

	public static Sprite 传道icon绿;

	public static Sprite 传道icon蓝;

	public static Sprite 传道按钮彩;

	public static Sprite 传道按钮橙;

	public static Sprite 传道按钮白;

	public static Sprite 传道按钮粉;

	public static Sprite 传道按钮紫;

	public static Sprite 传道按钮红;

	public static Sprite 传道按钮绿;

	public static Sprite 传道按钮蓝;

	public static Sprite 射手彩;

	public static Sprite 射手橙;

	public static Sprite 射手白;

	public static Sprite 射手粉;

	public static Sprite 射手紫;

	public static Sprite 射手红;

	public static Sprite 射手绿;

	public static Sprite 射手蓝;

	public static Sprite 战士彩;

	public static Sprite 战士橙;

	public static Sprite 战士白;

	public static Sprite 战士粉;

	public static Sprite 战士紫;

	public static Sprite 战士红;

	public static Sprite 战士绿;

	public static Sprite 战士蓝;

	public static Sprite 控制彩;

	public static Sprite 控制橙;

	public static Sprite 控制白;

	public static Sprite 控制粉;

	public static Sprite 控制紫;

	public static Sprite 控制红;

	public static Sprite 控制绿;

	public static Sprite 控制蓝;

	public static Sprite 法师彩;

	public static Sprite 法师橙;

	public static Sprite 法师白;

	public static Sprite 法师粉;

	public static Sprite 法师紫;

	public static Sprite 法师红;

	public static Sprite 法师绿;

	public static Sprite 法师蓝;

	public static Sprite 辅助彩;

	public static Sprite 辅助橙;

	public static Sprite 辅助白;

	public static Sprite 辅助粉;

	public static Sprite 辅助紫;

	public static Sprite 辅助红;

	public static Sprite 辅助绿;

	public static Sprite 辅助蓝;

	public static AudioClip 首领出现;

	public static AudioClip 瑶池;

	public static AudioClip 土地;

	public static AudioClip 丹童;

	public static AudioClip 河伯1;

	public static AudioClip 河伯2;

	public static AudioClip 怪物死亡;

	public static AudioClip 太白金星;

	public static AudioClip 石敢当;

	public static AudioClip 玄女;

	public static AudioClip 龟丞相audio;

	public static AudioClip 哪吒;

	public static AudioClip 孙悟空;

	public static AudioClip 碧霄;

	public static AudioClip 琼霄;

	public static AudioClip 多闻天王;

	public static AudioClip 广目天王;

	public static AudioClip 雷震子;

	public static AudioClip 月老;

	public static AudioClip 嫦娥;

	public static AudioClip 杨戬;

	public static AudioClip 妲己;

	public static AudioClip 牛魔王audio;

	public static AudioClip 羲和;

	public static AudioClip 常羲;

	public static AudioClip 后羿;

	public static AudioClip 云霄;

	public static AudioClip 女娲;

	public static AudioClip 老子;

	public static AudioClip 元始;

	public static AudioClip 通天;

	public static AudioClip 鸿钧audio;

	public static AudioClip 盘古audio;

	public static AudioClip 按钮进入;

	public static AudioClip 按钮点击;

	public static AudioClip 错误;

	public static AudioClip Toggle;

	public static AudioClip 招募;

	public static AudioClip 成功;

	public static Sprite 问号;

	public static Sprite 开始按钮亮;

	public static Sprite 开始按钮暗;

	public static Sprite 倍速按钮亮;

	public static Sprite 倍速按钮暗;

	public static Sprite 羁绊背景框紫;

	public static Sprite 羁绊背景框橙;

	public static Sprite 羁绊背景框粉;

	public static Sprite 羁绊背景框红;

	public static Sprite 羁绊背景框彩;

	public static Sprite 混沌归元;

	public static Sprite 诛仙剑阵;

	public static Sprite 开天辟地;

	public static Sprite 圣德光辉;

	public static Sprite 造化乾坤;

	public static Sprite 菩提风火;

	public static Sprite 天地人;

	public static Sprite 山河七宝;

	public static Sprite 弑神定海;

	public static Sprite 翻海断岳;

	public static Sprite 五行飞仙斩;

	public static Sprite 照落金莲;

	public static Sprite 紫金断岳;

	public static Sprite 五方照落;

	public static Sprite 加号背景框;

	public static Sprite 城墙icon白;

	public static Sprite 城墙icon绿;

	public static Sprite 城墙icon蓝;

	public static Sprite 城墙icon紫;

	public static Sprite 城墙icon橙;

	public static Sprite 城墙icon粉;

	public static Sprite 城墙icon红;

	public static Sprite 城墙icon彩;

	public static Sprite 城墙装备背景框白;

	public static Sprite 城墙装备背景框绿;

	public static Sprite 城墙装备背景框蓝;

	public static Sprite 城墙装备背景框紫;

	public static Sprite 城墙装备背景框橙;

	public static Sprite 城墙装备背景框粉;

	public static Sprite 城墙装备背景框红;

	public static Sprite 城墙装备背景框彩;

	public static Sprite 不动明王阵;

	public static Sprite 不周山柱;

	public static Sprite 不朽魂晶;

	public static Sprite 不死木;

	public static Sprite 不灭玄石;

	public static Sprite 九曲黄河阵;

	public static Sprite 初源露;

	public static Sprite 厚土珠;

	public static Sprite 反伤岩;

	public static Sprite 周天星斗大阵;

	public static Sprite 土灵珠;

	public static Sprite 地髓晶;

	public static Sprite 大道本源;

	public static Sprite 天命罗盘;

	public static Sprite 天机石;

	public static Sprite 天罡石;

	public static Sprite 山河阵盘;

	public static Sprite 星辰沙;

	public static Sprite 星辰铁;

	public static Sprite 永恒之火;

	public static Sprite 混沌磐石;

	public static Sprite 灵兽骨粉;

	public static Sprite 灵石尘;

	public static Sprite 灵藤蔓;

	public static Sprite 玄武石;

	public static Sprite 玄黄之气;

	public static Sprite 百年桃木;

	public static Sprite 蛟龙骨;

	public static Sprite 血琥珀;

	public static Sprite 轮回印记;

	public static Sprite 雷击木;

	public static Sprite 鸿蒙灵根;

	public static Sprite 凌霄宝殿按钮;

	public static Sprite 凌霄宝殿按钮亮;

	public static Sprite 凌霄宝殿按钮暗;

	public static Sprite 混沌虚空格子亮;

	public static Sprite 混沌虚空格子暗;

	public static Sprite 道宝标签紫;

	public static Sprite 道宝标签橙;

	public static Sprite 道宝标签粉;

	public static Sprite 道宝标签红;

	public static Sprite 道宝标签彩;

	public static Sprite 山河社稷图;

	public static Sprite 七宝妙树;

	public static Sprite 天书;

	public static Sprite 地书;

	public static Sprite 弑神枪;

	public static Sprite 冥书;

	public static Sprite 定海神珠;

	public static Sprite 河图洛书;

	public static Sprite 翻天印;

	public static Sprite 紫金葫芦;

	public static Sprite 金蛟剪;

	public static Sprite 斩仙飞刀;

	public static Sprite 五色神光;

	public static Sprite 宝莲灯;

	public static Sprite 落宝金钱;

	public static Sprite 先天五方旗;

	public static Sprite 混沌青莲;

	public static Sprite 造化玉碟;

	public static Sprite 混沌珠;

	public static Sprite 开天斧;

	public static Sprite 盘古幡;

	public static Sprite 混沌钟;

	public static Sprite 诛仙剑;

	public static Sprite 戮仙剑;

	public static Sprite 陷仙剑;

	public static Sprite 绝仙剑;

	public static Sprite 乾坤鼎;

	public static Sprite 菩提妙树;

	public static Sprite 玲珑塔;

	public static Sprite 炼妖壶;

	public static Sprite 女娲石;

	public static Sprite 轩辕剑;

	public static Sprite 玉净瓶;

	public static Sprite 照妖镜;

	public static Sprite 风火轮;

	public static Sprite 如意金箍棒;

	public static Sprite 按钮亮;

	public static Sprite 按钮暗;

	public static Sprite 锋锐4;

	public static Sprite 锋锐5;

	public static Sprite 锋锐6;

	public static Sprite 锋锐7;

	public static Sprite 锋锐8;

	public static Sprite 战意4;

	public static Sprite 战意5;

	public static Sprite 战意6;

	public static Sprite 战意7;

	public static Sprite 战意8;

	public static Sprite 咒力4;

	public static Sprite 咒力5;

	public static Sprite 咒力6;

	public static Sprite 咒力7;

	public static Sprite 咒力8;

	public static Sprite 束魂4;

	public static Sprite 束魂5;

	public static Sprite 束魂6;

	public static Sprite 束魂7;

	public static Sprite 束魂8;

	public static Sprite 矢锋4;

	public static Sprite 矢锋5;

	public static Sprite 矢锋6;

	public static Sprite 矢锋7;

	public static Sprite 矢锋8;

	public static Sprite 清道4;

	public static Sprite 清道5;

	public static Sprite 清道6;

	public static Sprite 清道7;

	public static Sprite 清道8;

	public static Sprite 破军4;

	public static Sprite 破军5;

	public static Sprite 破军6;

	public static Sprite 破军7;

	public static Sprite 破军8;

	public static Sprite 暗蚀4;

	public static Sprite 暗蚀5;

	public static Sprite 暗蚀6;

	public static Sprite 暗蚀7;

	public static Sprite 暗蚀8;

	public static Sprite 雷霆4;

	public static Sprite 雷霆5;

	public static Sprite 雷霆6;

	public static Sprite 雷霆7;

	public static Sprite 雷霆8;

	public static Sprite 焚烬4;

	public static Sprite 焚烬5;

	public static Sprite 焚烬6;

	public static Sprite 焚烬7;

	public static Sprite 焚烬8;

	public static Sprite 霜寒4;

	public static Sprite 霜寒5;

	public static Sprite 霜寒6;

	public static Sprite 霜寒7;

	public static Sprite 霜寒8;

	public static Sprite 斩首4;

	public static Sprite 斩首5;

	public static Sprite 斩首6;

	public static Sprite 斩首7;

	public static Sprite 斩首8;

	public static Sprite 绝命4;

	public static Sprite 绝命5;

	public static Sprite 绝命6;

	public static Sprite 绝命7;

	public static Sprite 绝命8;

	public static Sprite 饮血4;

	public static Sprite 饮血5;

	public static Sprite 饮血6;

	public static Sprite 饮血7;

	public static Sprite 饮血8;

	public static Sprite 固垒4;

	public static Sprite 固垒5;

	public static Sprite 固垒6;

	public static Sprite 固垒7;

	public static Sprite 固垒8;

	public static Sprite 不破4;

	public static Sprite 不破5;

	public static Sprite 不破6;

	public static Sprite 不破7;

	public static Sprite 不破8;

	public static Sprite 恃强4;

	public static Sprite 恃强5;

	public static Sprite 恃强6;

	public static Sprite 恃强7;

	public static Sprite 恃强8;

	public static Sprite 致命4;

	public static Sprite 致命5;

	public static Sprite 致命6;

	public static Sprite 致命7;

	public static Sprite 致命8;

	public static Sprite 无常4;

	public static Sprite 无常5;

	public static Sprite 无常6;

	public static Sprite 无常7;

	public static Sprite 无常8;

	public static Sprite 破法4;

	public static Sprite 破法5;

	public static Sprite 破法6;

	public static Sprite 破法7;

	public static Sprite 破法8;

	public static Sprite 镇关4;

	public static Sprite 镇关5;

	public static Sprite 镇关6;

	public static Sprite 镇关7;

	public static Sprite 镇关8;

	public static Sprite 连珠4;

	public static Sprite 连珠5;

	public static Sprite 连珠6;

	public static Sprite 连珠7;

	public static Sprite 连珠8;

	public static Sprite 回响4;

	public static Sprite 回响5;

	public static Sprite 回响6;

	public static Sprite 回响7;

	public static Sprite 回响8;

	public static Sprite 心炎4;

	public static Sprite 心炎5;

	public static Sprite 心炎6;

	public static Sprite 心炎7;

	public static Sprite 心炎8;

	public static Sprite 扶摇4;

	public static Sprite 扶摇5;

	public static Sprite 扶摇6;

	public static Sprite 扶摇7;

	public static Sprite 扶摇8;

	public static Sprite 焚天4;

	public static Sprite 焚天5;

	public static Sprite 焚天6;

	public static Sprite 焚天7;

	public static Sprite 焚天8;

	public static Sprite 齐天战意4;

	public static Sprite 齐天战意5;

	public static Sprite 齐天战意6;

	public static Sprite 齐天战意7;

	public static Sprite 齐天战意8;

	public static Sprite 冰龙回响4;

	public static Sprite 冰龙回响5;

	public static Sprite 冰龙回响6;

	public static Sprite 冰龙回响7;

	public static Sprite 冰龙回响8;

	public static Sprite 定身4;

	public static Sprite 定身5;

	public static Sprite 定身6;

	public static Sprite 定身7;

	public static Sprite 定身8;

	public static Sprite 云破4;

	public static Sprite 云破5;

	public static Sprite 云破6;

	public static Sprite 云破7;

	public static Sprite 云破8;

	public static Sprite 落日4;

	public static Sprite 落日5;

	public static Sprite 落日6;

	public static Sprite 落日7;

	public static Sprite 落日8;

	public static Sprite 曦日灼4;

	public static Sprite 曦日灼5;

	public static Sprite 曦日灼6;

	public static Sprite 曦日灼7;

	public static Sprite 曦日灼8;

	public static Sprite 寒月4;

	public static Sprite 寒月5;

	public static Sprite 寒月6;

	public static Sprite 寒月7;

	public static Sprite 寒月8;

	public static Sprite 补天4;

	public static Sprite 补天5;

	public static Sprite 补天6;

	public static Sprite 补天7;

	public static Sprite 补天8;

	public static Sprite 截天4;

	public static Sprite 截天5;

	public static Sprite 截天6;

	public static Sprite 截天7;

	public static Sprite 截天8;

	public static Sprite 玄风4;

	public static Sprite 玄风5;

	public static Sprite 玄风6;

	public static Sprite 玄风7;

	public static Sprite 玄风8;

	public static Sprite 始火4;

	public static Sprite 始火5;

	public static Sprite 始火6;

	public static Sprite 始火7;

	public static Sprite 始火8;

	public static Sprite 鸿蒙陨4;

	public static Sprite 鸿蒙陨5;

	public static Sprite 鸿蒙陨6;

	public static Sprite 鸿蒙陨7;

	public static Sprite 鸿蒙陨8;

	public static Sprite 开天4;

	public static Sprite 开天5;

	public static Sprite 开天6;

	public static Sprite 开天7;

	public static Sprite 开天8;

	public static Sprite 冰;

	public static Sprite 剑;

	public static Sprite 力;

	public static Sprite 原始;

	public static Sprite 斗;

	public static Sprite 日;

	public static Sprite 月;

	public static Sprite 火;

	public static Sprite 禁;

	public static Sprite 箭;

	public static Sprite 诛仙;

	public static Sprite 造化;

	public static Sprite 道;

	public static Sprite 鸿蒙;

	public static Sprite 品质元神白;

	public static Sprite 品质元神绿;

	public static Sprite 品质元神蓝;

	public static Sprite 品质元神紫;

	public static Sprite 品质元神橙;

	public static Sprite 品质元神粉;

	public static Sprite 品质元神红;

	public static Sprite 品质元神彩;

	public static TMP_ColorGradient 火焰TMP;

	public static TMP_ColorGradient 冰霜TMP;

	public static TMP_ColorGradient 物理TMP;

	public static TMP_ColorGradient 雷电TMP;

	public static TMP_ColorGradient 黑暗TMP;

	public static TMP_ColorGradient 黄TMP;

	public static TMP_ColorGradient 玄TMP;

	public static TMP_ColorGradient 地TMP;

	public static TMP_ColorGradient 天TMP;

	public static TMP_ColorGradient 宇TMP;

	public static TMP_ColorGradient 宙TMP;

	public static TMP_ColorGradient 洪TMP;

	public static TMP_ColorGradient 荒TMP;

	public static Sprite 丹童技能icon;

	public static Sprite 土地技能icon;

	public static Sprite 河伯技能icon;

	public static Sprite 瑶池仙女技能icon;

	public static Sprite 石敢当技能icon;

	public static Sprite 玄女技能icon;

	public static Sprite 龟丞相技能icon;

	public static Sprite 太白金星技能icon;

	public static Sprite 多闻天王技能icon;

	public static Sprite 广目天王技能icon;

	public static Sprite 雷震子技能icon;

	public static Sprite 月老技能icon;

	public static Sprite 嫦娥技能icon;

	public static Sprite 杨戬技能icon;

	public static Sprite 妲己技能icon;

	public static Sprite 牛魔王技能icon;

	public static Sprite 哪吒技能icon;

	public static Sprite 孙悟空技能icon;

	public static Sprite 碧霄技能icon;

	public static Sprite 琼霄技能icon;

	public static Sprite 羲和技能icon;

	public static Sprite 常羲技能icon;

	public static Sprite 后羿技能icon;

	public static Sprite 云霄技能icon;

	public static Sprite 女娲技能icon;

	public static Sprite 老子技能icon;

	public static Sprite 通天技能icon;

	public static Sprite 元始技能icon;

	public static Sprite 鸿钧技能icon;

	public static Sprite 盘古技能icon;

	public static Sprite 物理icon;

	public static Sprite 火焰icon;

	public static Sprite 黑暗icon;

	public static Sprite 雷电icon;

	public static Sprite 冰霜icon;

	public static Sprite 黄;

	public static Sprite 玄;

	public static Sprite 地;

	public static Sprite 天;

	public static Sprite 宇;

	public static Sprite 宙;

	public static Sprite 洪;

	public static Sprite 荒;

	public static Sprite 锁;

	public static Sprite 解锁;

	public static Sprite 强化窗口装备背景框亮;

	public static Sprite 强化窗口装备背景框暗;

	public static Sprite 强化窗口按钮亮;

	public static Sprite 强化窗口按钮暗;

	public static TMP_ColorGradient 灰色TMP;

	public static TMP_ColorGradient 高级招募TMP;

	public static TMP_ColorGradient 纯黄TMP;

	public static Sprite 突破背景凡;

	public static Sprite 突破背景灵;

	public static Sprite 突破背景仙;

	public static Sprite 突破背景圣;

	public static Sprite 突破背景荒;

	public static Sprite 护手白;

	public static Sprite 护手绿;

	public static Sprite 护手蓝;

	public static Sprite 护手紫;

	public static Sprite 护手橙;

	public static Sprite 护手粉;

	public static Sprite 护手红;

	public static Sprite 护手彩;

	public static Sprite 头盔白;

	public static Sprite 头盔绿;

	public static Sprite 头盔蓝;

	public static Sprite 头盔紫;

	public static Sprite 头盔橙;

	public static Sprite 头盔粉;

	public static Sprite 头盔红;

	public static Sprite 头盔彩;

	public static Sprite 项链白;

	public static Sprite 项链绿;

	public static Sprite 项链蓝;

	public static Sprite 项链紫;

	public static Sprite 项链橙;

	public static Sprite 项链粉;

	public static Sprite 项链红;

	public static Sprite 项链彩;

	public static Sprite 戒指白;

	public static Sprite 戒指绿;

	public static Sprite 戒指蓝;

	public static Sprite 戒指紫;

	public static Sprite 戒指橙;

	public static Sprite 戒指粉;

	public static Sprite 戒指红;

	public static Sprite 戒指彩;

	public static Sprite 衣服白;

	public static Sprite 衣服绿;

	public static Sprite 衣服蓝;

	public static Sprite 衣服紫;

	public static Sprite 衣服橙;

	public static Sprite 衣服粉;

	public static Sprite 衣服红;

	public static Sprite 衣服彩;

	public static Sprite 鞋子白;

	public static Sprite 鞋子绿;

	public static Sprite 鞋子蓝;

	public static Sprite 鞋子紫;

	public static Sprite 鞋子橙;

	public static Sprite 鞋子粉;

	public static Sprite 鞋子红;

	public static Sprite 鞋子彩;

	public static Sprite 招募概率按钮亮;

	public static Sprite 招募概率按钮暗;

	public static Sprite 品质标签白;

	public static Sprite 品质标签绿;

	public static Sprite 品质标签蓝;

	public static Sprite 品质标签紫;

	public static Sprite 品质标签橙;

	public static Sprite 品质标签粉;

	public static Sprite 品质标签红;

	public static Sprite 品质标签彩;

	public static Sprite UI人物背景框白;

	public static Sprite UI人物背景框绿;

	public static Sprite UI人物背景框蓝;

	public static Sprite UI人物背景框紫;

	public static Sprite UI人物背景框橙;

	public static Sprite UI人物背景框粉;

	public static Sprite UI人物背景框红;

	public static Sprite UI人物背景框彩;

	public static Sprite 战斗人物背景框白;

	public static Sprite 战斗人物背景框绿;

	public static Sprite 战斗人物背景框蓝;

	public static Sprite 战斗人物背景框紫;

	public static Sprite 战斗人物背景框橙;

	public static Sprite 战斗人物背景框粉;

	public static Sprite 战斗人物背景框红;

	public static Sprite 战斗人物背景框彩;

	public static Sprite 道具背景框白;

	public static Sprite 道具背景框绿;

	public static Sprite 道具背景框蓝;

	public static Sprite 道具背景框紫;

	public static Sprite 道具背景框橙;

	public static Sprite 道具背景框粉;

	public static Sprite 道具背景框红;

	public static Sprite 道具背景框彩;

	public static Sprite 道具背景框白1;

	public static Sprite 道具背景框绿1;

	public static Sprite 道具背景框蓝1;

	public static Sprite 道具背景框紫1;

	public static Sprite 道具背景框橙1;

	public static Sprite 道具背景框粉1;

	public static Sprite 道具背景框红1;

	public static Sprite 道具背景框彩1;

	public static Sprite 小怪背景框;

	public static Sprite 精英怪背景框;

	public static Sprite Boss背景框;

	public static Sprite 辅助;

	public static Sprite 射手;

	public static Sprite 控制;

	public static Sprite 战士;

	public static Sprite 法师;

	public static Sprite 全职业经验值;

	public static Sprite 功德;

	public static Sprite 头盔锻造石;

	public static Sprite 射手经验值;

	public static Sprite 戒指锻造石;

	public static Sprite 战士经验值;

	public static Sprite 护手锻造石;

	public static Sprite 招募卷;

	public static Sprite 控制经验值;

	public static Sprite 法师经验值;

	public static Sprite 洗练石;

	public static Sprite 灵魂;

	public static Sprite 衣服锻造石;

	public static Sprite 辅助经验值;

	public static Sprite 鞋子锻造石;

	public static Sprite 项链锻造石;

	public static Sprite 高级招募卷;

	public static Sprite 花果山;

	public static Sprite 水帘洞;

	public static Sprite 傲来国;

	public static Sprite 东海龙宫;

	public static Sprite 蓬莱仙岛;

	public static Sprite 五行山;

	public static Sprite 高老庄;

	public static Sprite 平顶山;

	public static Sprite 女儿国;

	public static Sprite 火焰山;

	public static Sprite 狮驼岭;

	public static Sprite 小雷音寺;

	public static Sprite 流沙河;

	public static Sprite 芭蕉洞;

	public static Sprite 冥府;

	public static Sprite 南天门;

	public static Sprite 瑶池仙境;

	public static Sprite 斩妖台;

	public static Sprite 御马监;

	public static Sprite 蟠桃园;

	public static Sprite 兜率宫;

	public static Sprite 紫微宫;

	public static Sprite 昊天殿;

	public static Sprite 登天路;

	public static Sprite 欲界天;

	public static Sprite 色界天;

	public static Sprite 无色天;

	public static Sprite 四梵天;

	public static Sprite 玉清境清微天;

	public static Sprite 上清境禹余天;

	public static Sprite 太清境大赤天;

	public static Sprite 大罗天;

	public static Sprite 猴精;

	public static Sprite 山魈;

	public static Sprite 马猴头领;

	public static Sprite 通臂猿猴;

	public static Sprite 水虱精;

	public static Sprite 蝙蝠精;

	public static Sprite 铁背苍猿;

	public static Sprite 水帘洞主;

	public static Sprite 傲来民兵;

	public static Sprite 猎户;

	public static Sprite 傲来偏将;

	public static Sprite 傲来国师;

	public static Sprite 虾兵;

	public static Sprite 蟹将;

	public static Sprite 龟丞相;

	public static Sprite 东海龙王;

	public static Sprite 仙鹤;

	public static Sprite 灵芝童;

	public static Sprite 蓬莱剑仙;

	public static Sprite 蓬莱岛主;

	public static Sprite 山石精;

	public static Sprite 土蝼;

	public static Sprite 五行山神;

	public static Sprite 压山符灵;

	public static Sprite 野猪精;

	public static Sprite 高才;

	public static Sprite 高太公;

	public static Sprite 猪刚鬣;

	public static Sprite 莲花洞小妖;

	public static Sprite 狐阿七;

	public static Sprite 银角大王;

	public static Sprite 金角大王;

	public static Sprite 女儿国兵;

	public static Sprite 女儿国将;

	public static Sprite 女儿国太师;

	public static Sprite 女儿国国王;

	public static Sprite 火焰精;

	public static Sprite 赤蛇;

	public static Sprite 红孩儿;

	public static Sprite 牛魔王;

	public static Sprite 芭蕉精;

	public static Sprite 火焰童;

	public static Sprite 铁扇侍女;

	public static Sprite 铁扇公主;

	public static Sprite 流沙精;

	public static Sprite 水鬼;

	public static Sprite 水蛇妖;

	public static Sprite 沙和尚;

	public static Sprite 假罗汉;

	public static Sprite 假金刚;

	public static Sprite 黄眉童子;

	public static Sprite 黄眉老祖;

	public static Sprite 青狮精手下;

	public static Sprite 白象精手下;

	public static Sprite 大鹏金翅雕;

	public static Sprite 青狮精;

	public static Sprite 牛头;

	public static Sprite 马面;

	public static Sprite 判官;

	public static Sprite 阎罗王;

	public static Sprite 天兵;

	public static Sprite 天将;

	public static Sprite 守卫统领;

	public static Sprite 巨灵王;

	public static Sprite 瑶池仙女;

	public static Sprite 瑶池守卫;

	public static Sprite 仙女首领;

	public static Sprite 西王母;

	public static Sprite 执法天兵;

	public static Sprite 执法天将;

	public static Sprite 斩妖剑侍;

	public static Sprite 天刑星君;

	public static Sprite 天马精;

	public static Sprite 监丞侍卫;

	public static Sprite 弼马温;

	public static Sprite 天马星君;

	public static Sprite 桃园力士;

	public static Sprite 桃园仙女;

	public static Sprite 蟠桃守卫;

	public static Sprite 蟠桃树精;

	public static Sprite 炼丹道童;

	public static Sprite 烧火道童;

	public static Sprite 兜率宫侍卫;

	public static Sprite 太上老君;

	public static Sprite 紫微星侍;

	public static Sprite 天罡星卒;

	public static Sprite 北极星君;

	public static Sprite 紫微大帝;

	public static Sprite 镇殿守卫;

	public static Sprite 镇殿天将;

	public static Sprite 九龙神卫;

	public static Sprite 玉皇大帝;

	public static Sprite 登天石傀;

	public static Sprite 罡风精;

	public static Sprite 雷劫之灵;

	public static Sprite 守天路神将;

	public static Sprite 欲念魅妖;

	public static Sprite 幻音雀;

	public static Sprite 贪欲魔;

	public static Sprite 欲界天魔王;

	public static Sprite 色相天女;

	public static Sprite 光音天众;

	public static Sprite 形色尊者;

	public static Sprite 色界天主;

	public static Sprite 虚灵;

	public static Sprite 空无影;

	public static Sprite 太虚之魂;

	public static Sprite 无色天祖;

	public static Sprite 梵天守卫;

	public static Sprite 净居天人;

	public static Sprite 善现尊者;

	public static Sprite 四梵天王;

	public static Sprite 清微仙童;

	public static Sprite 玄光玉女;

	public static Sprite 玉清道卫;

	public static Sprite 魔元始天尊;

	public static Sprite 禹余灵官;

	public static Sprite 紫霞仙鹤;

	public static Sprite 上清剑侍;

	public static Sprite 魔灵宝天尊;

	public static Sprite 大赤丹童;

	public static Sprite 炉火精;

	public static Sprite 太清护卫;

	public static Sprite 魔老子;

	public static Sprite 弥罗侍卫;

	public static Sprite 弥罗宫卫;

	public static Sprite 混元道兵;

	public static Sprite 魔鸿钧;

	public static Sprite 混沌蠕虫;

	public static Sprite 虚空螯虫;

	public static Sprite 虚空巨兽;

	public static Sprite 混沌主宰;

	public static Sprite Get职业icon(ZhiYeType zhiYeType)
	{
		return (Sprite)(zhiYeType switch
		{
			ZhiYeType.射手 => 射手, 
			ZhiYeType.战士 => 战士, 
			ZhiYeType.辅助 => 辅助, 
			ZhiYeType.法师 => 法师, 
			ZhiYeType.控制 => 控制, 
			_ => null, 
		});
	}

	public static Sprite Get功法Sprite(功法Type type)
	{
		return (Sprite)(type switch
		{
			功法Type.战士白 => 战士白, 
			功法Type.战士绿 => 战士绿, 
			功法Type.战士蓝 => 战士蓝, 
			功法Type.战士紫 => 战士紫, 
			功法Type.战士粉 => 战士粉, 
			功法Type.战士红 => 战士红, 
			功法Type.战士橙 => 战士橙, 
			功法Type.战士彩 => 战士彩, 
			功法Type.射手白 => 射手白, 
			功法Type.射手绿 => 射手绿, 
			功法Type.射手蓝 => 射手蓝, 
			功法Type.射手紫 => 射手紫, 
			功法Type.射手粉 => 射手粉, 
			功法Type.射手红 => 射手红, 
			功法Type.射手橙 => 射手橙, 
			功法Type.射手彩 => 射手彩, 
			功法Type.控制白 => 控制白, 
			功法Type.控制绿 => 控制绿, 
			功法Type.控制蓝 => 控制蓝, 
			功法Type.控制紫 => 控制紫, 
			功法Type.控制粉 => 控制粉, 
			功法Type.控制红 => 控制红, 
			功法Type.控制橙 => 控制橙, 
			功法Type.控制彩 => 控制彩, 
			功法Type.辅助白 => 辅助白, 
			功法Type.辅助绿 => 辅助绿, 
			功法Type.辅助蓝 => 辅助蓝, 
			功法Type.辅助紫 => 辅助紫, 
			功法Type.辅助粉 => 辅助粉, 
			功法Type.辅助红 => 辅助红, 
			功法Type.辅助橙 => 辅助橙, 
			功法Type.辅助彩 => 辅助彩, 
			功法Type.法师白 => 法师白, 
			功法Type.法师绿 => 法师绿, 
			功法Type.法师蓝 => 法师蓝, 
			功法Type.法师紫 => 法师紫, 
			功法Type.法师粉 => 法师粉, 
			功法Type.法师红 => 法师红, 
			功法Type.法师橙 => 法师橙, 
			功法Type.法师彩 => 法师彩, 
			_ => null, 
		});
	}

	public static Sprite Get元素Sprite(YuanSuType yuanSuType)
	{
		return (Sprite)(yuanSuType switch
		{
			YuanSuType.火 => 火焰icon, 
			YuanSuType.冰 => 冰霜icon, 
			YuanSuType.电 => 雷电icon, 
			YuanSuType.黑暗 => 黑暗icon, 
			YuanSuType.物理 => 物理icon, 
			_ => null, 
		});
	}

	public static Sprite GetHeroSprite(HeroType type)
	{
		return (Sprite)(type switch
		{
			HeroType.丹童 => 丹童头像, 
			HeroType.土地 => 土地头像, 
			HeroType.河伯 => 河伯头像, 
			HeroType.瑶池仙女 => 瑶池仙女头像, 
			HeroType.石敢当 => 石敢当头像, 
			HeroType.玄女 => 玄女头像, 
			HeroType.龟丞相 => 龟丞相头像, 
			HeroType.太白金星 => 太白金星头像, 
			HeroType.多闻天王 => 多闻天王头像, 
			HeroType.广目天王 => 广目天王头像, 
			HeroType.雷震子 => 雷震子头像, 
			HeroType.月老 => 月老头像, 
			HeroType.嫦娥 => 嫦娥头像, 
			HeroType.杨戬 => 杨戬头像, 
			HeroType.妲己 => 妲己头像, 
			HeroType.牛魔王 => 牛魔王头像, 
			HeroType.哪吒 => 哪吒头像, 
			HeroType.孙悟空 => 孙悟空头像, 
			HeroType.碧霄 => 碧霄头像, 
			HeroType.琼霄 => 琼霄头像, 
			HeroType.羲和 => 羲和头像, 
			HeroType.常羲 => 常羲头像, 
			HeroType.后羿 => 后羿头像, 
			HeroType.云霄 => 云霄头像, 
			HeroType.女娲 => 女娲头像, 
			HeroType.老子 => 老子头像, 
			HeroType.通天 => 通天头像, 
			HeroType.元始 => 元始头像, 
			HeroType.鸿钧 => 鸿钧头像, 
			HeroType.盘古 => 盘古头像, 
			_ => null, 
		});
	}

	public static Sprite Get道宝标签Sprite(道宝Quality quality)
	{
		return (Sprite)(quality switch
		{
			道宝Quality.混沌至宝 => 道宝标签彩, 
			道宝Quality.先天至宝 => 道宝标签红, 
			道宝Quality.功德至宝 => 道宝标签粉, 
			道宝Quality.先天灵宝 => 道宝标签橙, 
			道宝Quality.后天法宝 => 道宝标签紫, 
			_ => null, 
		});
	}

	public static Sprite GetMonsterSprite(MonsterTypeName type)
	{
		return (Sprite)(type switch
		{
			MonsterTypeName.猴精 => 猴精, 
			MonsterTypeName.山魈 => 山魈, 
			MonsterTypeName.水虱精 => 水虱精, 
			MonsterTypeName.蝙蝠精 => 蝙蝠精, 
			MonsterTypeName.傲来民兵 => 傲来民兵, 
			MonsterTypeName.猎户 => 猎户, 
			MonsterTypeName.傲来偏将 => 傲来偏将, 
			MonsterTypeName.傲来国师 => 傲来国师, 
			MonsterTypeName.虾兵 => 虾兵, 
			MonsterTypeName.蟹将 => 蟹将, 
			MonsterTypeName.龟丞相 => 龟丞相, 
			MonsterTypeName.东海龙王 => 东海龙王, 
			MonsterTypeName.仙鹤 => 仙鹤, 
			MonsterTypeName.灵芝童 => 灵芝童, 
			MonsterTypeName.蓬莱剑仙 => 蓬莱剑仙, 
			MonsterTypeName.山石精 => 山石精, 
			MonsterTypeName.土蝼 => 土蝼, 
			MonsterTypeName.五行山神 => 五行山神, 
			MonsterTypeName.野猪精 => 野猪精, 
			MonsterTypeName.高才 => 高才, 
			MonsterTypeName.高太公 => 高太公, 
			MonsterTypeName.猪刚鬣 => 猪刚鬣, 
			MonsterTypeName.莲花洞小妖 => 莲花洞小妖, 
			MonsterTypeName.狐阿七 => 狐阿七, 
			MonsterTypeName.银角大王 => 银角大王, 
			MonsterTypeName.金角大王 => 金角大王, 
			MonsterTypeName.女儿国兵 => 女儿国兵, 
			MonsterTypeName.女儿国将 => 女儿国将, 
			MonsterTypeName.女儿国太师 => 女儿国太师, 
			MonsterTypeName.女儿国国王 => 女儿国国王, 
			MonsterTypeName.火焰精 => 火焰精, 
			MonsterTypeName.赤蛇 => 赤蛇, 
			MonsterTypeName.红孩儿 => 红孩儿, 
			MonsterTypeName.牛魔王 => 牛魔王, 
			MonsterTypeName.芭蕉精 => 芭蕉精, 
			MonsterTypeName.火焰童 => 火焰童, 
			MonsterTypeName.铁扇侍女 => 铁扇侍女, 
			MonsterTypeName.铁扇公主 => 铁扇公主, 
			MonsterTypeName.流沙精 => 流沙精, 
			MonsterTypeName.水鬼 => 水鬼, 
			MonsterTypeName.水蛇妖 => 水蛇妖, 
			MonsterTypeName.沙和尚 => 沙和尚, 
			MonsterTypeName.假罗汉 => 假罗汉, 
			MonsterTypeName.假金刚 => 假金刚, 
			MonsterTypeName.黄眉童子 => 黄眉童子, 
			MonsterTypeName.黄眉老祖 => 黄眉老祖, 
			MonsterTypeName.青狮精手下 => 青狮精手下, 
			MonsterTypeName.白象精手下 => 白象精手下, 
			MonsterTypeName.大鹏金翅雕 => 大鹏金翅雕, 
			MonsterTypeName.青狮精 => 青狮精, 
			MonsterTypeName.牛头 => 牛头, 
			MonsterTypeName.马面 => 马面, 
			MonsterTypeName.判官 => 判官, 
			MonsterTypeName.阎罗王 => 阎罗王, 
			MonsterTypeName.天兵 => 天兵, 
			MonsterTypeName.天将 => 天将, 
			MonsterTypeName.守卫统领 => 守卫统领, 
			MonsterTypeName.巨灵王 => 巨灵王, 
			MonsterTypeName.瑶池仙女 => 瑶池仙女, 
			MonsterTypeName.瑶池守卫 => 瑶池守卫, 
			MonsterTypeName.仙女首领 => 仙女首领, 
			MonsterTypeName.西王母 => 西王母, 
			MonsterTypeName.执法天兵 => 执法天兵, 
			MonsterTypeName.执法天将 => 执法天将, 
			MonsterTypeName.斩妖剑侍 => 斩妖剑侍, 
			MonsterTypeName.天刑星君 => 天刑星君, 
			MonsterTypeName.天马精 => 天马精, 
			MonsterTypeName.监丞侍卫 => 监丞侍卫, 
			MonsterTypeName.弼马温 => 弼马温, 
			MonsterTypeName.天马星君 => 天马星君, 
			MonsterTypeName.桃园力士 => 桃园力士, 
			MonsterTypeName.桃园仙女 => 桃园仙女, 
			MonsterTypeName.蟠桃守卫 => 蟠桃守卫, 
			MonsterTypeName.蟠桃树精 => 蟠桃树精, 
			MonsterTypeName.炼丹道童 => 炼丹道童, 
			MonsterTypeName.烧火道童 => 烧火道童, 
			MonsterTypeName.兜率宫侍卫 => 兜率宫侍卫, 
			MonsterTypeName.太上老君 => 太上老君, 
			MonsterTypeName.紫微星侍 => 紫微星侍, 
			MonsterTypeName.天罡星卒 => 天罡星卒, 
			MonsterTypeName.北极星君 => 北极星君, 
			MonsterTypeName.紫微大帝 => 紫微大帝, 
			MonsterTypeName.镇殿守卫 => 镇殿守卫, 
			MonsterTypeName.镇殿天将 => 镇殿天将, 
			MonsterTypeName.九龙神卫 => 九龙神卫, 
			MonsterTypeName.玉皇大帝 => 玉皇大帝, 
			MonsterTypeName.登天石傀 => 登天石傀, 
			MonsterTypeName.罡风精 => 罡风精, 
			MonsterTypeName.雷劫之灵 => 雷劫之灵, 
			MonsterTypeName.守天路神将 => 守天路神将, 
			MonsterTypeName.欲念魅妖 => 欲念魅妖, 
			MonsterTypeName.幻音雀 => 幻音雀, 
			MonsterTypeName.贪欲魔 => 贪欲魔, 
			MonsterTypeName.欲界天魔王 => 欲界天魔王, 
			MonsterTypeName.色相天女 => 色相天女, 
			MonsterTypeName.光音天众 => 光音天众, 
			MonsterTypeName.形色尊者 => 形色尊者, 
			MonsterTypeName.色界天主 => 色界天主, 
			MonsterTypeName.虚灵 => 虚灵, 
			MonsterTypeName.空无影 => 空无影, 
			MonsterTypeName.太虚之魂 => 太虚之魂, 
			MonsterTypeName.无色天祖 => 无色天祖, 
			MonsterTypeName.梵天守卫 => 梵天守卫, 
			MonsterTypeName.净居天人 => 净居天人, 
			MonsterTypeName.善现尊者 => 善现尊者, 
			MonsterTypeName.四梵天王 => 四梵天王, 
			MonsterTypeName.清微仙童 => 清微仙童, 
			MonsterTypeName.玄光玉女 => 玄光玉女, 
			MonsterTypeName.玉清道卫 => 玉清道卫, 
			MonsterTypeName.魔元始天尊 => 魔元始天尊, 
			MonsterTypeName.禹余灵官 => 禹余灵官, 
			MonsterTypeName.紫霞仙鹤 => 紫霞仙鹤, 
			MonsterTypeName.上清剑侍 => 上清剑侍, 
			MonsterTypeName.魔灵宝天尊 => 魔灵宝天尊, 
			MonsterTypeName.大赤丹童 => 大赤丹童, 
			MonsterTypeName.炉火精 => 炉火精, 
			MonsterTypeName.太清护卫 => 太清护卫, 
			MonsterTypeName.魔老子 => 魔老子, 
			MonsterTypeName.弥罗侍卫 => 弥罗侍卫, 
			MonsterTypeName.弥罗宫卫 => 弥罗宫卫, 
			MonsterTypeName.混元道兵 => 混元道兵, 
			MonsterTypeName.魔鸿钧 => 魔鸿钧, 
			MonsterTypeName.混沌蠕虫 => 混沌蠕虫, 
			MonsterTypeName.虚空螯虫 => 虚空螯虫, 
			MonsterTypeName.虚空巨兽 => 虚空巨兽, 
			MonsterTypeName.混沌主宰 => 混沌主宰, 
			MonsterTypeName.青木狼 => 青木狼, 
			MonsterTypeName.铁背龟 => 铁背龟, 
			MonsterTypeName.荆棘猿 => 荆棘猿, 
			MonsterTypeName.千年树精 => 千年树精, 
			MonsterTypeName.熔岩蜥 => 熔岩蜥, 
			MonsterTypeName.火鸦 => 火鸦, 
			MonsterTypeName.炎晶巨人 => 炎晶巨人, 
			MonsterTypeName.地火蛟 => 地火蛟, 
			MonsterTypeName.怨魂蝶 => 怨魂蝶, 
			MonsterTypeName.食骨鳄 => 食骨鳄, 
			MonsterTypeName.无面鬼 => 无面鬼, 
			MonsterTypeName.九幽尸王 => 九幽尸王, 
			MonsterTypeName.罡风鹫 => 罡风鹫, 
			MonsterTypeName.裂空蝎 => 裂空蝎, 
			MonsterTypeName.虚影兽 => 虚影兽, 
			MonsterTypeName.双首海蛇 => 双首海蛇, 
			MonsterTypeName.幻鳞鱼 => 幻鳞鱼, 
			MonsterTypeName.铁钳蟹 => 铁钳蟹, 
			MonsterTypeName.万象鲸 => 万象鲸, 
			MonsterTypeName.饕餮 => 饕餮, 
			MonsterTypeName.云纹兽 => 云纹兽, 
			MonsterTypeName.星光蝶 => 星光蝶, 
			MonsterTypeName.朱雀 => 朱雀, 
			MonsterTypeName.白虎 => 白虎, 
			MonsterTypeName.仙灵鹤 => 仙灵鹤, 
			MonsterTypeName.玉兔精 => 玉兔精, 
			MonsterTypeName.朱厌 => 朱厌, 
			MonsterTypeName.应龙 => 应龙, 
			MonsterTypeName.虚空兽 => 虚空兽, 
			MonsterTypeName.混沌兽 => 混沌兽, 
			MonsterTypeName.归墟古凤 => 归墟古凤, 
			MonsterTypeName.归墟古龙 => 归墟古龙, 
			MonsterTypeName.道纹甲虫 => 道纹甲虫, 
			MonsterTypeName.混沌蝠 => 混沌蝠, 
			MonsterTypeName.梼杌 => 梼杌, 
			MonsterTypeName.霸下 => 霸下, 
			MonsterTypeName.玄黄蜉蝣 => 玄黄蜉蝣, 
			MonsterTypeName.剑齿虎 => 剑齿虎, 
			MonsterTypeName.混元兽 => 混元兽, 
			MonsterTypeName.道胎灵童 => 道胎灵童, 
			MonsterTypeName.青丘白狐 => 青丘白狐, 
			MonsterTypeName.青丘黑狐 => 青丘黑狐, 
			MonsterTypeName.白泽 => 白泽, 
			MonsterTypeName.九尾狐 => 九尾狐, 
			MonsterTypeName.远古巨兽 => 远古巨兽, 
			MonsterTypeName.法则之兽 => 法则之兽, 
			MonsterTypeName.凤凰 => 凤凰, 
			MonsterTypeName.真龙 => 真龙, 
			MonsterTypeName.远古凶兽 => 远古凶兽, 
			MonsterTypeName.远古大蛇 => 远古大蛇, 
			MonsterTypeName.穷奇 => 穷奇, 
			MonsterTypeName.麒麟 => 麒麟, 
			MonsterTypeName.先天魔神 => 先天魔神, 
			MonsterTypeName.混沌巨兽 => 混沌巨兽, 
			MonsterTypeName.劫兽 => 劫兽, 
			MonsterTypeName.混沌之眼 => 混沌之眼, 
			MonsterTypeName.归墟古兽 => 归墟古兽, 
			MonsterTypeName.时空扭曲者 => 时空扭曲者, 
			MonsterTypeName.混沌古兽 => 混沌古兽, 
			MonsterTypeName.永恒之门 => 永恒之门, 
			MonsterTypeName.石皮野猪 => 石皮野猪, 
			MonsterTypeName.铁羽麻雀 => 铁羽麻雀, 
			MonsterTypeName.裂蹄蛮牛 => 裂蹄蛮牛, 
			MonsterTypeName.风吼应龙 => 风吼应龙, 
			MonsterTypeName.棘背豪猪 => 棘背豪猪, 
			MonsterTypeName.赤眼乌鸦 => 赤眼乌鸦, 
			MonsterTypeName.碎岩巨蜥 => 碎岩巨蜥, 
			MonsterTypeName.雷翼飞廉 => 雷翼飞廉, 
			MonsterTypeName.甲壳穿山 => 甲壳穿山, 
			MonsterTypeName.毒牙田鼠 => 毒牙田鼠, 
			MonsterTypeName.震地巨蟾 => 震地巨蟾, 
			MonsterTypeName.冰晶玄龟 => 冰晶玄龟, 
			MonsterTypeName.骨刺刺猬 => 骨刺刺猬, 
			MonsterTypeName.火羽雉鸡 => 火羽雉鸡, 
			MonsterTypeName.熔岩巨蟒 => 熔岩巨蟒, 
			MonsterTypeName.双首炎蟒 => 双首炎蟒, 
			MonsterTypeName.铜鳞鲤鱼 => 铜鳞鲤鱼, 
			MonsterTypeName.铁爪鹰隼 => 铁爪鹰隼, 
			MonsterTypeName.金刚巨猿 => 金刚巨猿, 
			MonsterTypeName.紫电麒麟 => 紫电麒麟, 
			MonsterTypeName.青面狼妖 => 青面狼妖, 
			MonsterTypeName.赤尾狐精 => 赤尾狐精, 
			MonsterTypeName.三眼毒蟾 => 三眼毒蟾, 
			MonsterTypeName.九尾天狐 => 九尾天狐, 
			MonsterTypeName.黑风蛇妖 => 黑风蛇妖, 
			MonsterTypeName.金瞳猫妖 => 金瞳猫妖, 
			MonsterTypeName.四臂魔猿 => 四臂魔猿, 
			MonsterTypeName.七首蛟龙 => 七首蛟龙, 
			MonsterTypeName.碧磷蝎精 => 碧磷蝎精, 
			MonsterTypeName.霜白蛛妖 => 霜白蛛妖, 
			MonsterTypeName.六翼蜈蚣 => 六翼蜈蚣, 
			MonsterTypeName.八足火蛛 => 八足火蛛, 
			MonsterTypeName.黄沙鼠妖 => 黄沙鼠妖, 
			MonsterTypeName.紫电貂精 => 紫电貂精, 
			MonsterTypeName.双头狼王 => 双头狼王, 
			MonsterTypeName.金翅大鹏 => 金翅大鹏, 
			MonsterTypeName.赤焰蚁精 => 赤焰蚁精, 
			MonsterTypeName.寒冰蝶妖 => 寒冰蝶妖, 
			MonsterTypeName.五色毒蟾 => 五色毒蟾, 
			MonsterTypeName.玄冥巨蟒 => 玄冥巨蟒, 
			MonsterTypeName.噬骨秃鹫 => 噬骨秃鹫, 
			MonsterTypeName.腐肉豺狼 => 腐肉豺狼, 
			MonsterTypeName.血瞳巨人 => 血瞳巨人, 
			MonsterTypeName.三头地狱犬 => 三头地狱犬, 
			MonsterTypeName.丧魂幽灵 => 丧魂幽灵, 
			MonsterTypeName.碎骨骷髅 => 碎骨骷髅, 
			MonsterTypeName.尸煞尸王 => 尸煞尸王, 
			MonsterTypeName.六臂夜叉 => 六臂夜叉, 
			MonsterTypeName.怨气怨灵 => 怨气怨灵, 
			MonsterTypeName.诅咒木偶 => 诅咒木偶, 
			MonsterTypeName.嗜血蝠王 => 嗜血蝠王, 
			MonsterTypeName.九婴凶蛇 => 九婴凶蛇, 
			MonsterTypeName.毒雾瘴精 => 毒雾瘴精, 
			MonsterTypeName.枯木树妖 => 枯木树妖, 
			MonsterTypeName.熔岩巨人 => 熔岩巨人, 
			MonsterTypeName.赤地旱魃 => 赤地旱魃, 
			MonsterTypeName.暗影影魔 => 暗影影魔, 
			MonsterTypeName.蚀金蚁群 => 蚀金蚁群, 
			MonsterTypeName.暴风巨鹏 => 暴风巨鹏, 
			MonsterTypeName.吞天朱厌 => 吞天朱厌, 
			MonsterTypeName.雷霆石像 => 雷霆石像, 
			MonsterTypeName.寒冰雕像 => 寒冰雕像, 
			MonsterTypeName.烈焰守护者 => 烈焰守护者, 
			MonsterTypeName.混沌饕餮 => 混沌饕餮, 
			MonsterTypeName.黄金剑狮 => 黄金剑狮, 
			MonsterTypeName.月影毒狼 => 月影毒狼, 
			MonsterTypeName.星辰守护者 => 星辰守护者, 
			MonsterTypeName.太极鲲鹏 => 太极鲲鹏, 
			MonsterTypeName.地脉石灵 => 地脉石灵, 
			MonsterTypeName.天罡星傀 => 天罡星傀, 
			MonsterTypeName.时空撕裂者 => 时空撕裂者, 
			MonsterTypeName.烛龙九阴 => 烛龙九阴, 
			MonsterTypeName.虚无吞噬兽 => 虚无吞噬兽, 
			MonsterTypeName.混沌畸变体 => 混沌畸变体, 
			MonsterTypeName.轮回审判官 => 轮回审判官, 
			MonsterTypeName.魔化盘古 => 魔化盘古, 
			MonsterTypeName.因果裁决者 => 因果裁决者, 
			MonsterTypeName.终末湮灭虫 => 终末湮灭虫, 
			MonsterTypeName.命运编织者 => 命运编织者, 
			MonsterTypeName.混沌道尊 => 混沌道尊, 
			MonsterTypeName.藤蔓猴 => 藤蔓猴, 
			MonsterTypeName.木灵蝶 => 木灵蝶, 
			MonsterTypeName.千年树妖 => 千年树妖, 
			MonsterTypeName.青木蛟 => 青木蛟, 
			MonsterTypeName.火岩虫 => 火岩虫, 
			MonsterTypeName.熔岩火蜥 => 熔岩火蜥, 
			MonsterTypeName.炎髓魔猿 => 炎髓魔猿, 
			MonsterTypeName.火山兽 => 火山兽, 
			MonsterTypeName.黑风貂 => 黑风貂, 
			MonsterTypeName.浮空水母 => 浮空水母, 
			MonsterTypeName.黑风双煞 => 黑风双煞, 
			MonsterTypeName.黑风老妖 => 黑风老妖, 
			MonsterTypeName.水形怪 => 水形怪, 
			MonsterTypeName.深渊鮟鱇 => 深渊鮟鱇, 
			MonsterTypeName.玄水毒蛟 => 玄水毒蛟, 
			MonsterTypeName.玄水兽 => 玄水兽, 
			MonsterTypeName.雷纹蛛 => 雷纹蛛, 
			MonsterTypeName.雷灵球 => 雷灵球, 
			MonsterTypeName.紫雷夔牛 => 紫雷夔牛, 
			MonsterTypeName.紫雷兽 => 紫雷兽, 
			MonsterTypeName.白骨兵 => 白骨兵, 
			MonsterTypeName.噬魂鸦 => 噬魂鸦, 
			MonsterTypeName.白骨将 => 白骨将, 
			MonsterTypeName.白骨兽 => 白骨兽, 
			MonsterTypeName.金甲傀 => 金甲傀, 
			MonsterTypeName.戈刃灵 => 戈刃灵, 
			MonsterTypeName.金戈将 => 金戈将, 
			MonsterTypeName.金戈兽 => 金戈兽, 
			MonsterTypeName.幻梦蝶 => 幻梦蝶, 
			MonsterTypeName.幻梦虫 => 幻梦虫, 
			MonsterTypeName.幻梦妖 => 幻梦妖, 
			MonsterTypeName.幻梦兽 => 幻梦兽, 
			MonsterTypeName.混沌虫 => 混沌虫, 
			MonsterTypeName.吞噬兽 => 吞噬兽, 
			MonsterTypeName.混沌魔将 => 混沌魔将, 
			MonsterTypeName.混沌兽王 => 混沌兽王, 
			MonsterTypeName.天道卫 => 天道卫, 
			MonsterTypeName.造化灵 => 造化灵, 
			MonsterTypeName.天道将 => 天道将, 
			MonsterTypeName.天道兽 => 天道兽, 
			_ => null, 
		});
	}

	public static Sprite GetPropSprite(PropType propType)
	{
		return (Sprite)(propType switch
		{
			PropType.功法经验 => 功法经验, 
			PropType.冰之法则 => 冰, 
			PropType.火之法则 => 火, 
			PropType.斗之法则 => 斗, 
			PropType.禁之法则 => 禁, 
			PropType.剑之法则 => 剑, 
			PropType.日之法则 => 日, 
			PropType.月之法则 => 月, 
			PropType.箭之法则 => 箭, 
			PropType.造化法则 => 造化, 
			PropType.原始法则 => 原始, 
			PropType.诛仙法则 => 诛仙, 
			PropType.道之法则 => 道, 
			PropType.鸿蒙法则 => 鸿蒙, 
			PropType.力之法则 => 力, 
			PropType.功德 => 功德, 
			PropType.洗练石 => 洗练石, 
			PropType.灵魂 => 灵魂, 
			PropType.法师经验值 => 法师经验值, 
			PropType.战士经验值 => 战士经验值, 
			PropType.控制经验值 => 控制经验值, 
			PropType.辅助经验值 => 辅助经验值, 
			PropType.射手经验值 => 射手经验值, 
			PropType.全职业经验值 => 全职业经验值, 
			PropType.衣服锻造石 => 衣服锻造石, 
			PropType.头盔锻造石 => 头盔锻造石, 
			PropType.护手锻造石 => 护手锻造石, 
			PropType.项链锻造石 => 项链锻造石, 
			PropType.戒指锻造石 => 戒指锻造石, 
			PropType.鞋子锻造石 => 鞋子锻造石, 
			PropType.招募卷 => 招募卷, 
			PropType.高级招募卷 => 高级招募卷, 
			PropType.法器粉尘 => 法器粉尘, 
			PropType.仙石精华 => 仙石精华, 
			PropType.符箓 => 符箓, 
			PropType.矿石 => 矿石, 
			PropType.玄铁 => 玄铁, 
			PropType.玉髓 => 玉髓, 
			PropType.石1 => Get法器材料Sprite(法器材料Type.石, 1), 
			PropType.石2 => Get法器材料Sprite(法器材料Type.石, 2), 
			PropType.石3 => Get法器材料Sprite(法器材料Type.石, 3), 
			PropType.石4 => Get法器材料Sprite(法器材料Type.石, 4), 
			PropType.石5 => Get法器材料Sprite(法器材料Type.石, 5), 
			PropType.石6 => Get法器材料Sprite(法器材料Type.石, 6), 
			PropType.石7 => Get法器材料Sprite(法器材料Type.石, 7), 
			PropType.石8 => Get法器材料Sprite(法器材料Type.石, 8), 
			PropType.石9 => Get法器材料Sprite(法器材料Type.石, 9), 
			PropType.石10 => Get法器材料Sprite(法器材料Type.石, 10), 
			PropType.石11 => Get法器材料Sprite(法器材料Type.石, 11), 
			PropType.石12 => Get法器材料Sprite(法器材料Type.石, 12), 
			PropType.石13 => Get法器材料Sprite(法器材料Type.石, 13), 
			PropType.石14 => Get法器材料Sprite(法器材料Type.石, 14), 
			PropType.石15 => Get法器材料Sprite(法器材料Type.石, 15), 
			PropType.石16 => Get法器材料Sprite(法器材料Type.石, 16), 
			PropType.铁1 => Get法器材料Sprite(法器材料Type.铁, 1), 
			PropType.铁2 => Get法器材料Sprite(法器材料Type.铁, 2), 
			PropType.铁3 => Get法器材料Sprite(法器材料Type.铁, 3), 
			PropType.铁4 => Get法器材料Sprite(法器材料Type.铁, 4), 
			PropType.铁5 => Get法器材料Sprite(法器材料Type.铁, 5), 
			PropType.铁6 => Get法器材料Sprite(法器材料Type.铁, 6), 
			PropType.铁7 => Get法器材料Sprite(法器材料Type.铁, 7), 
			PropType.铁8 => Get法器材料Sprite(法器材料Type.铁, 8), 
			PropType.铁9 => Get法器材料Sprite(法器材料Type.铁, 9), 
			PropType.铁10 => Get法器材料Sprite(法器材料Type.铁, 10), 
			PropType.铁11 => Get法器材料Sprite(法器材料Type.铁, 11), 
			PropType.铁12 => Get法器材料Sprite(法器材料Type.铁, 12), 
			PropType.铁13 => Get法器材料Sprite(法器材料Type.铁, 13), 
			PropType.铁14 => Get法器材料Sprite(法器材料Type.铁, 14), 
			PropType.铁15 => Get法器材料Sprite(法器材料Type.铁, 15), 
			PropType.铁16 => Get法器材料Sprite(法器材料Type.铁, 16), 
			PropType.羽1 => Get法器材料Sprite(法器材料Type.羽, 1), 
			PropType.羽2 => Get法器材料Sprite(法器材料Type.羽, 2), 
			PropType.羽3 => Get法器材料Sprite(法器材料Type.羽, 3), 
			PropType.羽4 => Get法器材料Sprite(法器材料Type.羽, 4), 
			PropType.羽5 => Get法器材料Sprite(法器材料Type.羽, 5), 
			PropType.羽6 => Get法器材料Sprite(法器材料Type.羽, 6), 
			PropType.羽7 => Get法器材料Sprite(法器材料Type.羽, 7), 
			PropType.羽8 => Get法器材料Sprite(法器材料Type.羽, 8), 
			PropType.羽9 => Get法器材料Sprite(法器材料Type.羽, 9), 
			PropType.羽10 => Get法器材料Sprite(法器材料Type.羽, 10), 
			PropType.羽11 => Get法器材料Sprite(法器材料Type.羽, 11), 
			PropType.羽12 => Get法器材料Sprite(法器材料Type.羽, 12), 
			PropType.羽13 => Get法器材料Sprite(法器材料Type.羽, 13), 
			PropType.羽14 => Get法器材料Sprite(法器材料Type.羽, 14), 
			PropType.羽15 => Get法器材料Sprite(法器材料Type.羽, 15), 
			PropType.羽16 => Get法器材料Sprite(法器材料Type.羽, 16), 
			PropType.砂1 => Get法器材料Sprite(法器材料Type.砂, 1), 
			PropType.砂2 => Get法器材料Sprite(法器材料Type.砂, 2), 
			PropType.砂3 => Get法器材料Sprite(法器材料Type.砂, 3), 
			PropType.砂4 => Get法器材料Sprite(法器材料Type.砂, 4), 
			PropType.砂5 => Get法器材料Sprite(法器材料Type.砂, 5), 
			PropType.砂6 => Get法器材料Sprite(法器材料Type.砂, 6), 
			PropType.砂7 => Get法器材料Sprite(法器材料Type.砂, 7), 
			PropType.砂8 => Get法器材料Sprite(法器材料Type.砂, 8), 
			PropType.砂9 => Get法器材料Sprite(法器材料Type.砂, 9), 
			PropType.砂10 => Get法器材料Sprite(法器材料Type.砂, 10), 
			PropType.砂11 => Get法器材料Sprite(法器材料Type.砂, 11), 
			PropType.砂12 => Get法器材料Sprite(法器材料Type.砂, 12), 
			PropType.砂13 => Get法器材料Sprite(法器材料Type.砂, 13), 
			PropType.砂14 => Get法器材料Sprite(法器材料Type.砂, 14), 
			PropType.砂15 => Get法器材料Sprite(法器材料Type.砂, 15), 
			PropType.砂16 => Get法器材料Sprite(法器材料Type.砂, 16), 
			PropType.轮回石 => 轮回石, 
			PropType.血晶 => 血晶, 
			_ => null, 
		});
	}

	public static Sprite Get道具背景框Sprite(PropType propType)
	{
		return (Sprite)(PropConfig.GetProp品质(propType) switch
		{
			QualityType.黄品 => 道具背景框白, 
			QualityType.玄品 => 道具背景框绿, 
			QualityType.地品 => 道具背景框蓝, 
			QualityType.天品 => 道具背景框紫, 
			QualityType.宇品 => 道具背景框橙, 
			QualityType.宙品 => 道具背景框粉, 
			QualityType.洪品 => 道具背景框红, 
			QualityType.荒品 => 道具背景框彩, 
			_ => null, 
		});
	}

	public static Sprite Get道具背景框SpriteByPropType(QualityType propType)
	{
		return (Sprite)(propType switch
		{
			QualityType.黄品 => 道具背景框白1, 
			QualityType.玄品 => 道具背景框绿1, 
			QualityType.地品 => 道具背景框蓝1, 
			QualityType.天品 => 道具背景框紫1, 
			QualityType.宇品 => 道具背景框橙1, 
			QualityType.宙品 => 道具背景框粉1, 
			QualityType.洪品 => 道具背景框红1, 
			QualityType.荒品 => 道具背景框彩1, 
			_ => null, 
		});
	}

	public static Sprite Get道具背景框SpriteByQuality(QualityType QualityType)
	{
		return (Sprite)(QualityType switch
		{
			QualityType.黄品 => 道具背景框白, 
			QualityType.玄品 => 道具背景框绿, 
			QualityType.地品 => 道具背景框蓝, 
			QualityType.天品 => 道具背景框紫, 
			QualityType.宇品 => 道具背景框橙, 
			QualityType.宙品 => 道具背景框粉, 
			QualityType.洪品 => 道具背景框红, 
			QualityType.荒品 => 道具背景框彩, 
			_ => null, 
		});
	}

	public static Sprite GetEquipSprite(EquipType equipType, QualityType qualityType)
	{
		switch (equipType)
		{
		case EquipType.头盔:
			switch (qualityType)
			{
			case QualityType.黄品:
				return 头盔白;
			case QualityType.玄品:
				return 头盔绿;
			case QualityType.地品:
				return 头盔蓝;
			case QualityType.天品:
				return 头盔紫;
			case QualityType.宇品:
				return 头盔橙;
			case QualityType.宙品:
				return 头盔粉;
			case QualityType.洪品:
				return 头盔红;
			case QualityType.荒品:
				return 头盔彩;
			}
			break;
		case EquipType.鞋子:
			switch (qualityType)
			{
			case QualityType.黄品:
				return 鞋子白;
			case QualityType.玄品:
				return 鞋子绿;
			case QualityType.地品:
				return 鞋子蓝;
			case QualityType.天品:
				return 鞋子紫;
			case QualityType.宇品:
				return 鞋子橙;
			case QualityType.宙品:
				return 鞋子粉;
			case QualityType.洪品:
				return 鞋子红;
			case QualityType.荒品:
				return 鞋子彩;
			}
			break;
		case EquipType.衣服:
			switch (qualityType)
			{
			case QualityType.黄品:
				return 衣服白;
			case QualityType.玄品:
				return 衣服绿;
			case QualityType.地品:
				return 衣服蓝;
			case QualityType.天品:
				return 衣服紫;
			case QualityType.宇品:
				return 衣服橙;
			case QualityType.宙品:
				return 衣服粉;
			case QualityType.洪品:
				return 衣服红;
			case QualityType.荒品:
				return 衣服彩;
			}
			break;
		case EquipType.项链:
			switch (qualityType)
			{
			case QualityType.黄品:
				return 项链白;
			case QualityType.玄品:
				return 项链绿;
			case QualityType.地品:
				return 项链蓝;
			case QualityType.天品:
				return 项链紫;
			case QualityType.宇品:
				return 项链橙;
			case QualityType.宙品:
				return 项链粉;
			case QualityType.洪品:
				return 项链红;
			case QualityType.荒品:
				return 项链彩;
			}
			break;
		case EquipType.戒指:
			switch (qualityType)
			{
			case QualityType.黄品:
				return 戒指白;
			case QualityType.玄品:
				return 戒指绿;
			case QualityType.地品:
				return 戒指蓝;
			case QualityType.天品:
				return 戒指紫;
			case QualityType.宇品:
				return 戒指橙;
			case QualityType.宙品:
				return 戒指粉;
			case QualityType.洪品:
				return 戒指红;
			case QualityType.荒品:
				return 戒指彩;
			}
			break;
		case EquipType.护手:
			switch (qualityType)
			{
			case QualityType.黄品:
				return 护手白;
			case QualityType.玄品:
				return 护手绿;
			case QualityType.地品:
				return 护手蓝;
			case QualityType.天品:
				return 护手紫;
			case QualityType.宇品:
				return 护手橙;
			case QualityType.宙品:
				return 护手粉;
			case QualityType.洪品:
				return 护手红;
			case QualityType.荒品:
				return 护手彩;
			}
			break;
		}
		return null;
	}

	public static Sprite Get标签背景(QualityType qualityType)
	{
		return (Sprite)(qualityType switch
		{
			QualityType.黄品 => 品质标签白, 
			QualityType.玄品 => 品质标签绿, 
			QualityType.地品 => 品质标签蓝, 
			QualityType.天品 => 品质标签紫, 
			QualityType.宇品 => 品质标签橙, 
			QualityType.宙品 => 品质标签粉, 
			QualityType.洪品 => 品质标签红, 
			QualityType.荒品 => 品质标签彩, 
			_ => null, 
		});
	}

	public static Sprite Get艺术字(QualityType qualityType)
	{
		return (Sprite)(qualityType switch
		{
			QualityType.黄品 => 黄, 
			QualityType.玄品 => 玄, 
			QualityType.地品 => 地, 
			QualityType.天品 => 天, 
			QualityType.宇品 => 宇, 
			QualityType.宙品 => 宙, 
			QualityType.洪品 => 洪, 
			QualityType.荒品 => 荒, 
			_ => null, 
		});
	}

	public static Sprite Get技能icon(HeroType heroType)
	{
		return (Sprite)(heroType switch
		{
			HeroType.None => null, 
			HeroType.丹童 => 丹童技能icon, 
			HeroType.土地 => 土地技能icon, 
			HeroType.河伯 => 河伯技能icon, 
			HeroType.瑶池仙女 => 瑶池仙女技能icon, 
			HeroType.石敢当 => 石敢当技能icon, 
			HeroType.玄女 => 玄女技能icon, 
			HeroType.龟丞相 => 龟丞相技能icon, 
			HeroType.太白金星 => 太白金星技能icon, 
			HeroType.多闻天王 => 多闻天王技能icon, 
			HeroType.广目天王 => 广目天王技能icon, 
			HeroType.雷震子 => 雷震子技能icon, 
			HeroType.月老 => 月老技能icon, 
			HeroType.嫦娥 => 嫦娥技能icon, 
			HeroType.杨戬 => 杨戬技能icon, 
			HeroType.妲己 => 妲己技能icon, 
			HeroType.牛魔王 => 牛魔王技能icon, 
			HeroType.哪吒 => 哪吒技能icon, 
			HeroType.孙悟空 => 孙悟空技能icon, 
			HeroType.碧霄 => 碧霄技能icon, 
			HeroType.琼霄 => 琼霄技能icon, 
			HeroType.羲和 => 羲和技能icon, 
			HeroType.常羲 => 常羲技能icon, 
			HeroType.后羿 => 后羿技能icon, 
			HeroType.云霄 => 云霄技能icon, 
			HeroType.女娲 => 女娲技能icon, 
			HeroType.老子 => 老子技能icon, 
			HeroType.通天 => 通天技能icon, 
			HeroType.元始 => 元始技能icon, 
			HeroType.鸿钧 => 鸿钧技能icon, 
			HeroType.盘古 => 盘古技能icon, 
			_ => null, 
		});
	}

	public static Sprite Get职业经验值Sprite(ZhiYeType zhiYeType)
	{
		return (Sprite)(zhiYeType switch
		{
			ZhiYeType.射手 => 射手经验值, 
			ZhiYeType.战士 => 战士经验值, 
			ZhiYeType.辅助 => 辅助经验值, 
			ZhiYeType.法师 => 法师经验值, 
			ZhiYeType.控制 => 控制经验值, 
			_ => null, 
		});
	}

	public static Sprite Get品质元神Sprite(QualityType qualityType)
	{
		return (Sprite)(qualityType switch
		{
			QualityType.黄品 => 品质元神白, 
			QualityType.玄品 => 品质元神绿, 
			QualityType.地品 => 品质元神蓝, 
			QualityType.天品 => 品质元神紫, 
			QualityType.宇品 => 品质元神橙, 
			QualityType.宙品 => 品质元神粉, 
			QualityType.洪品 => 品质元神红, 
			QualityType.荒品 => 品质元神彩, 
			_ => null, 
		});
	}

	public static Sprite Get法则Sprite(HeroType heroType)
	{
		return (Sprite)(heroType switch
		{
			HeroType.哪吒 => 火, 
			HeroType.孙悟空 => 斗, 
			HeroType.碧霄 => 冰, 
			HeroType.琼霄 => 禁, 
			HeroType.云霄 => 剑, 
			HeroType.后羿 => 箭, 
			HeroType.羲和 => 日, 
			HeroType.常羲 => 月, 
			HeroType.女娲 => 造化, 
			HeroType.元始 => 原始, 
			HeroType.通天 => 诛仙, 
			HeroType.老子 => 道, 
			HeroType.鸿钧 => 鸿蒙, 
			HeroType.盘古 => 力, 
			_ => null, 
		});
	}

	private static Sprite[] Load阶数Sprites(string path)
	{
		Sprite[] array = Resources.LoadAll<Sprite>(path);
		if (array == null || array.Length == 0)
		{
			return (Sprite[])(object)new Sprite[0];
		}
		Array.Sort(array, (Sprite a, Sprite b) => 取尾部序号(((Object)a).name).CompareTo(取尾部序号(((Object)b).name)));
		return array;
	}

	private static int 取尾部序号(string spriteName)
	{
		int num = spriteName.LastIndexOf('_');
		if (num >= 0 && int.TryParse(spriteName.Substring(num + 1), out var result))
		{
			return result;
		}
		return int.MaxValue;
	}

	public static Sprite Get法器Sprite(法器Type 法器Type, int 阶数 = 1)
	{
		if (阶数 < 1 || 阶数 > 16)
		{
			return null;
		}
		if (法器SpriteCache.TryGetValue(法器Type, out var value) && value.Length >= 阶数)
		{
			return value[阶数 - 1];
		}
		return null;
	}

	public static Sprite Get道纹Sprite(道纹Type type, QualityType qualityType)
	{
		switch (type)
		{
		case 道纹Type.增加百分比攻击力:
			switch ((int)qualityType)
			{
			case 4:
				return 锋锐4;
			case 5:
				return 锋锐5;
			case 6:
				return 锋锐6;
			case 7:
				return 锋锐7;
			case 8:
				return 锋锐8;
			}
			break;
		case 道纹Type.增加战士伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 战意4;
			case 5:
				return 战意5;
			case 6:
				return 战意6;
			case 7:
				return 战意7;
			case 8:
				return 战意8;
			}
			break;
		case 道纹Type.增加法师伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 咒力4;
			case 5:
				return 咒力5;
			case 6:
				return 咒力6;
			case 7:
				return 咒力7;
			case 8:
				return 咒力8;
			}
			break;
		case 道纹Type.增加控制伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 束魂4;
			case 5:
				return 束魂5;
			case 6:
				return 束魂6;
			case 7:
				return 束魂7;
			case 8:
				return 束魂8;
			}
			break;
		case 道纹Type.增加射手伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 矢锋4;
			case 5:
				return 矢锋5;
			case 6:
				return 矢锋6;
			case 7:
				return 矢锋7;
			case 8:
				return 矢锋8;
			}
			break;
		case 道纹Type.增加小怪伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 清道4;
			case 5:
				return 清道5;
			case 6:
				return 清道6;
			case 7:
				return 清道7;
			case 8:
				return 清道8;
			}
			break;
		case 道纹Type.增加物理伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 破军4;
			case 5:
				return 破军5;
			case 6:
				return 破军6;
			case 7:
				return 破军7;
			case 8:
				return 破军8;
			}
			break;
		case 道纹Type.增加黑暗伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 暗蚀4;
			case 5:
				return 暗蚀5;
			case 6:
				return 暗蚀6;
			case 7:
				return 暗蚀7;
			case 8:
				return 暗蚀8;
			}
			break;
		case 道纹Type.增加雷电伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 雷霆4;
			case 5:
				return 雷霆5;
			case 6:
				return 雷霆6;
			case 7:
				return 雷霆7;
			case 8:
				return 雷霆8;
			}
			break;
		case 道纹Type.增加火焰伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 焚烬4;
			case 5:
				return 焚烬5;
			case 6:
				return 焚烬6;
			case 7:
				return 焚烬7;
			case 8:
				return 焚烬8;
			}
			break;
		case 道纹Type.增加冰霜伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 霜寒4;
			case 5:
				return 霜寒5;
			case 6:
				return 霜寒6;
			case 7:
				return 霜寒7;
			case 8:
				return 霜寒8;
			}
			break;
		case 道纹Type.增加精英怪和首领伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 斩首4;
			case 5:
				return 斩首5;
			case 6:
				return 斩首6;
			case 7:
				return 斩首7;
			case 8:
				return 斩首8;
			}
			break;
		case 道纹Type.城墙低血增加伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 绝命4;
			case 5:
				return 绝命5;
			case 6:
				return 绝命6;
			case 7:
				return 绝命7;
			case 8:
				return 绝命8;
			}
			break;
		case 道纹Type.击杀精英怪城墙回血:
			switch ((int)qualityType)
			{
			case 4:
				return 饮血4;
			case 5:
				return 饮血5;
			case 6:
				return 饮血6;
			case 7:
				return 饮血7;
			case 8:
				return 饮血8;
			}
			break;
		case 道纹Type.城墙血量百分比:
			switch ((int)qualityType)
			{
			case 4:
				return 固垒4;
			case 5:
				return 固垒5;
			case 6:
				return 固垒6;
			case 7:
				return 固垒7;
			case 8:
				return 固垒8;
			}
			break;
		case 道纹Type.城墙免疫伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 不破4;
			case 5:
				return 不破5;
			case 6:
				return 不破6;
			case 7:
				return 不破7;
			case 8:
				return 不破8;
			}
			break;
		case 道纹Type.城墙满血时加伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 恃强4;
			case 5:
				return 恃强5;
			case 6:
				return 恃强6;
			case 7:
				return 恃强7;
			case 8:
				return 恃强8;
			}
			break;
		case 道纹Type.英雄暴击率:
			switch ((int)qualityType)
			{
			case 4:
				return 致命4;
			case 5:
				return 致命5;
			case 6:
				return 致命6;
			case 7:
				return 致命7;
			case 8:
				return 致命8;
			}
			break;
		case 道纹Type.伤害在范围内浮动:
			switch ((int)qualityType)
			{
			case 4:
				return 无常4;
			case 5:
				return 无常5;
			case 6:
				return 无常6;
			case 7:
				return 无常7;
			case 8:
				return 无常8;
			}
			break;
		case 道纹Type.无视抗性:
			switch ((int)qualityType)
			{
			case 4:
				return 破法4;
			case 5:
				return 破法5;
			case 6:
				return 破法6;
			case 7:
				return 破法7;
			case 8:
				return 破法8;
			}
			break;
		case 道纹Type.战士对靠近城墙敌人伤害增高:
			switch ((int)qualityType)
			{
			case 4:
				return 镇关4;
			case 5:
				return 镇关5;
			case 6:
				return 镇关6;
			case 7:
				return 镇关7;
			case 8:
				return 镇关8;
			}
			break;
		case 道纹Type.射手对远距离敌人伤害增高:
			switch ((int)qualityType)
			{
			case 4:
				return 连珠4;
			case 5:
				return 连珠5;
			case 6:
				return 连珠6;
			case 7:
				return 连珠7;
			case 8:
				return 连珠8;
			}
			break;
		case 道纹Type.控制冷却缩减:
			switch ((int)qualityType)
			{
			case 4:
				return 回响4;
			case 5:
				return 回响5;
			case 6:
				return 回响6;
			case 7:
				return 回响7;
			case 8:
				return 回响8;
			}
			break;
		case 道纹Type.法师暴击率:
			switch ((int)qualityType)
			{
			case 4:
				return 心炎4;
			case 5:
				return 心炎5;
			case 6:
				return 心炎6;
			case 7:
				return 心炎7;
			case 8:
				return 心炎8;
			}
			break;
		case 道纹Type.辅助被辅助英雄伤害增幅:
			switch ((int)qualityType)
			{
			case 4:
				return 扶摇4;
			case 5:
				return 扶摇5;
			case 6:
				return 扶摇6;
			case 7:
				return 扶摇7;
			case 8:
				return 扶摇8;
			}
			break;
		case 道纹Type.三味真火无视抗性百分比:
			switch ((int)qualityType)
			{
			case 4:
				return 焚天4;
			case 5:
				return 焚天5;
			case 6:
				return 焚天6;
			case 7:
				return 焚天7;
			case 8:
				return 焚天8;
			}
			break;
		case 道纹Type.孙悟空每秒增加伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 齐天战意4;
			case 5:
				return 齐天战意5;
			case 6:
				return 齐天战意6;
			case 7:
				return 齐天战意7;
			case 8:
				return 齐天战意8;
			}
			break;
		case 道纹Type.碧霄冰龙有概率再次释放:
			switch ((int)qualityType)
			{
			case 4:
				return 冰龙回响4;
			case 5:
				return 冰龙回响5;
			case 6:
				return 冰龙回响6;
			case 7:
				return 冰龙回响7;
			case 8:
				return 冰龙回响8;
			}
			break;
		case 道纹Type.琼霄定身衰减效果减少:
			switch ((int)qualityType)
			{
			case 4:
				return 定身4;
			case 5:
				return 定身5;
			case 6:
				return 定身6;
			case 7:
				return 定身7;
			case 8:
				return 定身8;
			}
			break;
		case 道纹Type.云霄最终伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 云破4;
			case 5:
				return 云破5;
			case 6:
				return 云破6;
			case 7:
				return 云破7;
			case 8:
				return 云破8;
			}
			break;
		case 道纹Type.后羿距离越远伤害越高:
			switch ((int)qualityType)
			{
			case 4:
				return 落日4;
			case 5:
				return 落日5;
			case 6:
				return 落日6;
			case 7:
				return 落日7;
			case 8:
				return 落日8;
			}
			break;
		case 道纹Type.羲和灼烧伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 曦日灼4;
			case 5:
				return 曦日灼5;
			case 6:
				return 曦日灼6;
			case 7:
				return 曦日灼7;
			case 8:
				return 曦日灼8;
			}
			break;
		case 道纹Type.常曦有概率冻结敌人:
			switch ((int)qualityType)
			{
			case 4:
				return 寒月4;
			case 5:
				return 寒月5;
			case 6:
				return 寒月6;
			case 7:
				return 寒月7;
			case 8:
				return 寒月8;
			}
			break;
		case 道纹Type.女娲增加被辅助冷却缩减:
			switch ((int)qualityType)
			{
			case 4:
				return 补天4;
			case 5:
				return 补天5;
			case 6:
				return 补天6;
			case 7:
				return 补天7;
			case 8:
				return 补天8;
			}
			break;
		case 道纹Type.通天每次暴击增加伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 截天4;
			case 5:
				return 截天5;
			case 6:
				return 截天6;
			case 7:
				return 截天7;
			case 8:
				return 截天8;
			}
			break;
		case 道纹Type.老子旋风体积越大伤害越高:
			switch ((int)qualityType)
			{
			case 4:
				return 玄风4;
			case 5:
				return 玄风5;
			case 6:
				return 玄风6;
			case 7:
				return 玄风7;
			case 8:
				return 玄风8;
			}
			break;
		case 道纹Type.元始每次释放有概率增加火种数量:
			switch ((int)qualityType)
			{
			case 4:
				return 始火4;
			case 5:
				return 始火5;
			case 6:
				return 始火6;
			case 7:
				return 始火7;
			case 8:
				return 始火8;
			}
			break;
		case 道纹Type.鸿钧每释放陨石增加伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 鸿蒙陨4;
			case 5:
				return 鸿蒙陨5;
			case 6:
				return 鸿蒙陨6;
			case 7:
				return 鸿蒙陨7;
			case 8:
				return 鸿蒙陨8;
			}
			break;
		case 道纹Type.盘古每击杀敌人增加伤害:
			switch ((int)qualityType)
			{
			case 4:
				return 开天4;
			case 5:
				return 开天5;
			case 6:
				return 开天6;
			case 7:
				return 开天7;
			case 8:
				return 开天8;
			}
			break;
		}
		return null;
	}

	public static Sprite Get道宝Sprite(道宝Type 道宝Type)
	{
		return (Sprite)(道宝Type switch
		{
			道宝Type.混沌青莲 => 混沌青莲, 
			道宝Type.造化玉碟 => 造化玉碟, 
			道宝Type.混沌珠 => 混沌珠, 
			道宝Type.开天斧 => 开天斧, 
			道宝Type.盘古幡 => 盘古幡, 
			道宝Type.混沌钟 => 混沌钟, 
			道宝Type.诛仙剑 => 诛仙剑, 
			道宝Type.戮仙剑 => 戮仙剑, 
			道宝Type.陷仙剑 => 陷仙剑, 
			道宝Type.绝仙剑 => 绝仙剑, 
			道宝Type.玲珑塔 => 玲珑塔, 
			道宝Type.轩辕剑 => 轩辕剑, 
			道宝Type.女娲石 => 女娲石, 
			道宝Type.炼妖壶 => 炼妖壶, 
			道宝Type.玉净瓶 => 玉净瓶, 
			道宝Type.乾坤鼎 => 乾坤鼎, 
			道宝Type.菩提妙树 => 菩提妙树, 
			道宝Type.风火轮 => 风火轮, 
			道宝Type.山河社稷图 => 山河社稷图, 
			道宝Type.七宝妙树 => 七宝妙树, 
			道宝Type.天书 => 天书, 
			道宝Type.地书 => 地书, 
			道宝Type.冥书 => 冥书, 
			道宝Type.弑神枪 => 弑神枪, 
			道宝Type.定海神珠 => 定海神珠, 
			道宝Type.河图洛书 => 河图洛书, 
			道宝Type.翻天印 => 翻天印, 
			道宝Type.紫金葫芦 => 紫金葫芦, 
			道宝Type.金蛟剪 => 金蛟剪, 
			道宝Type.斩仙飞刀 => 斩仙飞刀, 
			道宝Type.五色神光 => 五色神光, 
			道宝Type.宝莲灯 => 宝莲灯, 
			道宝Type.落宝金钱 => 落宝金钱, 
			道宝Type.先天五方旗 => 先天五方旗, 
			道宝Type.照妖镜 => 照妖镜, 
			道宝Type.如意金箍棒 => 如意金箍棒, 
			_ => null, 
		});
	}

	public static Sprite Get主线关卡Sprite(主线关卡Type Type)
	{
		return (Sprite)(Type switch
		{
			主线关卡Type.花果山 => 花果山, 
			主线关卡Type.水帘洞 => 水帘洞, 
			主线关卡Type.蓬莱仙岛 => 蓬莱仙岛, 
			主线关卡Type.五行山 => 五行山, 
			主线关卡Type.傲来国 => 傲来国, 
			主线关卡Type.高老庄 => 高老庄, 
			主线关卡Type.女儿国 => 女儿国, 
			主线关卡Type.小雷音寺 => 小雷音寺, 
			主线关卡Type.平顶山 => 平顶山, 
			主线关卡Type.火焰山 => 火焰山, 
			主线关卡Type.芭蕉洞 => 芭蕉洞, 
			主线关卡Type.流沙河 => 流沙河, 
			主线关卡Type.狮驼岭 => 狮驼岭, 
			主线关卡Type.东海龙宫 => 东海龙宫, 
			主线关卡Type.冥府 => 冥府, 
			主线关卡Type.南天门 => 南天门, 
			主线关卡Type.瑶池仙境 => 瑶池仙境, 
			主线关卡Type.斩妖台 => 斩妖台, 
			主线关卡Type.御马监 => 御马监, 
			主线关卡Type.蟠桃园 => 蟠桃园, 
			主线关卡Type.兜率宫 => 兜率宫, 
			主线关卡Type.紫微宫 => 紫微宫, 
			主线关卡Type.昊天殿 => 昊天殿, 
			主线关卡Type.登天路 => 登天路, 
			主线关卡Type.欲界天 => 欲界天, 
			主线关卡Type.色界天 => 色界天, 
			主线关卡Type.无色天 => 无色天, 
			主线关卡Type.四梵天 => 四梵天, 
			主线关卡Type.玉清境清微天 => 玉清境清微天, 
			主线关卡Type.上清境禹余天 => 上清境禹余天, 
			主线关卡Type.太清境大赤天 => 太清境大赤天, 
			主线关卡Type.大罗天 => 大罗天, 
			_ => null, 
		});
	}

	public static TMP_ColorGradient Get品质TMP(QualityType Type)
	{
		return Type switch
		{
			QualityType.黄品 => 黄TMP, 
			QualityType.玄品 => 玄TMP, 
			QualityType.地品 => 地TMP, 
			QualityType.天品 => 天TMP, 
			QualityType.宇品 => 宇TMP, 
			QualityType.宙品 => 宙TMP, 
			QualityType.洪品 => 洪TMP, 
			QualityType.荒品 => 荒TMP, 
			_ => null, 
		};
	}

	public static Sprite Get城墙Sprite(城墙道具Type Type)
	{
		return (Sprite)(Type switch
		{
			城墙道具Type.不动明王阵 => 不动明王阵, 
			城墙道具Type.不周山柱 => 不周山柱, 
			城墙道具Type.不朽魂晶 => 不朽魂晶, 
			城墙道具Type.不死木 => 不死木, 
			城墙道具Type.不灭玄石 => 不灭玄石, 
			城墙道具Type.九曲黄河阵 => 九曲黄河阵, 
			城墙道具Type.初源露 => 初源露, 
			城墙道具Type.厚土珠 => 厚土珠, 
			城墙道具Type.不灭岩 => 反伤岩, 
			城墙道具Type.周天星斗大阵 => 周天星斗大阵, 
			城墙道具Type.土灵珠 => 土灵珠, 
			城墙道具Type.地髓晶 => 地髓晶, 
			城墙道具Type.大道本源 => 大道本源, 
			城墙道具Type.天命罗盘 => 天命罗盘, 
			城墙道具Type.天机石 => 天机石, 
			城墙道具Type.天罡石 => 天罡石, 
			城墙道具Type.山河阵盘 => 山河阵盘, 
			城墙道具Type.星辰沙 => 星辰沙, 
			城墙道具Type.星辰铁 => 星辰铁, 
			城墙道具Type.永恒之火 => 永恒之火, 
			城墙道具Type.混沌磐石 => 混沌磐石, 
			城墙道具Type.灵兽骨粉 => 灵兽骨粉, 
			城墙道具Type.灵石尘 => 灵石尘, 
			城墙道具Type.灵藤蔓 => 灵藤蔓, 
			城墙道具Type.玄武石 => 玄武石, 
			城墙道具Type.玄黄之气 => 玄黄之气, 
			城墙道具Type.百年桃木 => 百年桃木, 
			城墙道具Type.蛟龙骨 => 蛟龙骨, 
			城墙道具Type.血琥珀 => 血琥珀, 
			城墙道具Type.轮回印记 => 轮回印记, 
			城墙道具Type.雷击木 => 雷击木, 
			城墙道具Type.鸿蒙灵根 => 鸿蒙灵根, 
			_ => null, 
		});
	}

	public static Sprite Get城墙Icon()
	{
		if (XSingleton<PlayerData>.S.城墙等级 < 10)
		{
			return 城墙icon白;
		}
		if (XSingleton<PlayerData>.S.城墙等级 < 20)
		{
			return 城墙icon绿;
		}
		if (XSingleton<PlayerData>.S.城墙等级 < 30)
		{
			return 城墙icon蓝;
		}
		if (XSingleton<PlayerData>.S.城墙等级 < 40)
		{
			return 城墙icon紫;
		}
		if (XSingleton<PlayerData>.S.城墙等级 < 50)
		{
			return 城墙icon橙;
		}
		if (XSingleton<PlayerData>.S.城墙等级 < 60)
		{
			return 城墙icon粉;
		}
		if (XSingleton<PlayerData>.S.城墙等级 < 70)
		{
			return 城墙icon红;
		}
		return 城墙icon彩;
	}

	public static Sprite Get城墙装备背景框(QualityType type)
	{
		return (Sprite)(type switch
		{
			QualityType.黄品 => 城墙装备背景框白, 
			QualityType.玄品 => 城墙装备背景框绿, 
			QualityType.地品 => 城墙装备背景框蓝, 
			QualityType.天品 => 城墙装备背景框紫, 
			QualityType.宇品 => 城墙装备背景框橙, 
			QualityType.宙品 => 城墙装备背景框粉, 
			QualityType.洪品 => 城墙装备背景框红, 
			QualityType.荒品 => 城墙装备背景框彩, 
			_ => null, 
		});
	}

	public static Sprite Get羁绊Sprite(羁绊Type Type)
	{
		return (Sprite)(Type switch
		{
			羁绊Type.混沌归元 => 混沌归元, 
			羁绊Type.诛仙剑阵 => 诛仙剑阵, 
			羁绊Type.开天辟地 => 开天辟地, 
			羁绊Type.圣德光辉 => 圣德光辉, 
			羁绊Type.造化乾坤 => 造化乾坤, 
			羁绊Type.菩提风火 => 菩提风火, 
			羁绊Type.天地人 => 天地人, 
			羁绊Type.山河七宝 => 山河七宝, 
			羁绊Type.弑神定海 => 弑神定海, 
			羁绊Type.翻海断岳 => 翻海断岳, 
			羁绊Type.五行飞仙斩 => 五行飞仙斩, 
			羁绊Type.照落金莲 => 照落金莲, 
			羁绊Type.紫金断岳 => 紫金断岳, 
			羁绊Type.五方照落 => 五方照落, 
			_ => 道具背景框白, 
		});
	}

	public static Sprite Get羁绊背景框(QualityType type)
	{
		return (Sprite)(type switch
		{
			QualityType.天品 => 羁绊背景框紫, 
			QualityType.宇品 => 羁绊背景框橙, 
			QualityType.宙品 => 羁绊背景框粉, 
			QualityType.洪品 => 羁绊背景框红, 
			QualityType.荒品 => 羁绊背景框彩, 
			_ => null, 
		});
	}

	public static Sprite Get传道背景框(QualityType type)
	{
		return (Sprite)(type switch
		{
			QualityType.黄品 => 传道背景框白, 
			QualityType.玄品 => 传道背景框绿, 
			QualityType.地品 => 传道背景框蓝, 
			QualityType.天品 => 传道背景框紫, 
			QualityType.宇品 => 传道背景框橙, 
			QualityType.宙品 => 传道背景框粉, 
			QualityType.洪品 => 传道背景框红, 
			QualityType.荒品 => 传道背景框彩, 
			_ => null, 
		});
	}

	public static Sprite Get传道按钮(QualityType type)
	{
		return (Sprite)(type switch
		{
			QualityType.黄品 => 传道按钮白, 
			QualityType.玄品 => 传道按钮绿, 
			QualityType.地品 => 传道按钮蓝, 
			QualityType.天品 => 传道按钮紫, 
			QualityType.宇品 => 传道按钮橙, 
			QualityType.宙品 => 传道按钮粉, 
			QualityType.洪品 => 传道按钮红, 
			QualityType.荒品 => 传道按钮彩, 
			_ => null, 
		});
	}

	public static Sprite Get传道icon(QualityType type)
	{
		return (Sprite)(type switch
		{
			QualityType.黄品 => 传道icon白, 
			QualityType.玄品 => 传道icon绿, 
			QualityType.地品 => 传道icon蓝, 
			QualityType.天品 => 传道icon紫, 
			QualityType.宇品 => 传道icon橙, 
			QualityType.宙品 => 传道icon粉, 
			QualityType.洪品 => 传道icon红, 
			QualityType.荒品 => 传道icon彩, 
			_ => null, 
		});
	}

	public static Sprite Get突破灵物(JingJieType jingJieType, QualityType type)
	{
		return (Sprite)(jingJieType switch
		{
			JingJieType.练气 => type switch
			{
				QualityType.黄品 => 练气白, 
				QualityType.玄品 => 练气绿, 
				QualityType.地品 => 练气蓝, 
				QualityType.天品 => 练气紫, 
				QualityType.宇品 => 练气橙, 
				QualityType.宙品 => 练气粉, 
				QualityType.洪品 => 练气红, 
				QualityType.荒品 => 练气彩, 
				_ => null, 
			}, 
			JingJieType.筑基 => type switch
			{
				QualityType.黄品 => 筑基白, 
				QualityType.玄品 => 筑基绿, 
				QualityType.地品 => 筑基蓝, 
				QualityType.天品 => 筑基紫, 
				QualityType.宇品 => 筑基橙, 
				QualityType.宙品 => 筑基粉, 
				QualityType.洪品 => 筑基红, 
				QualityType.荒品 => 筑基彩, 
				_ => null, 
			}, 
			JingJieType.金丹 => type switch
			{
				QualityType.黄品 => 金丹白, 
				QualityType.玄品 => 金丹绿, 
				QualityType.地品 => 金丹蓝, 
				QualityType.天品 => 金丹紫, 
				QualityType.宇品 => 金丹橙, 
				QualityType.宙品 => 金丹粉, 
				QualityType.洪品 => 金丹红, 
				QualityType.荒品 => 金丹彩, 
				_ => null, 
			}, 
			JingJieType.元婴 => type switch
			{
				QualityType.黄品 => 元婴白, 
				QualityType.玄品 => 元婴绿, 
				QualityType.地品 => 元婴蓝, 
				QualityType.天品 => 元婴紫, 
				QualityType.宇品 => 元婴橙, 
				QualityType.宙品 => 元婴粉, 
				QualityType.洪品 => 元婴红, 
				QualityType.荒品 => 元婴彩, 
				_ => null, 
			}, 
			JingJieType.化神 => type switch
			{
				QualityType.黄品 => 化神白, 
				QualityType.玄品 => 化神绿, 
				QualityType.地品 => 化神蓝, 
				QualityType.天品 => 化神紫, 
				QualityType.宇品 => 化神橙, 
				QualityType.宙品 => 化神粉, 
				QualityType.洪品 => 化神红, 
				QualityType.荒品 => 化神彩, 
				_ => null, 
			}, 
			JingJieType.合体 => type switch
			{
				QualityType.黄品 => 合体白, 
				QualityType.玄品 => 合体绿, 
				QualityType.地品 => 合体蓝, 
				QualityType.天品 => 合体紫, 
				QualityType.宇品 => 合体橙, 
				QualityType.宙品 => 合体粉, 
				QualityType.洪品 => 合体红, 
				QualityType.荒品 => 合体彩, 
				_ => null, 
			}, 
			JingJieType.大乘 => type switch
			{
				QualityType.黄品 => 大乘白, 
				QualityType.玄品 => 大乘绿, 
				QualityType.地品 => 大乘蓝, 
				QualityType.天品 => 大乘紫, 
				QualityType.宇品 => 大乘橙, 
				QualityType.宙品 => 大乘粉, 
				QualityType.洪品 => 大乘红, 
				QualityType.荒品 => 大乘彩, 
				_ => null, 
			}, 
			JingJieType.天仙 => type switch
			{
				QualityType.黄品 => 天仙白, 
				QualityType.玄品 => 天仙绿, 
				QualityType.地品 => 天仙蓝, 
				QualityType.天品 => 天仙紫, 
				QualityType.宇品 => 天仙橙, 
				QualityType.宙品 => 天仙粉, 
				QualityType.洪品 => 天仙红, 
				QualityType.荒品 => 天仙彩, 
				_ => null, 
			}, 
			JingJieType.玄仙 => type switch
			{
				QualityType.黄品 => 玄仙白, 
				QualityType.玄品 => 玄仙绿, 
				QualityType.地品 => 玄仙蓝, 
				QualityType.天品 => 玄仙紫, 
				QualityType.宇品 => 玄仙橙, 
				QualityType.宙品 => 玄仙粉, 
				QualityType.洪品 => 玄仙红, 
				QualityType.荒品 => 玄仙彩, 
				_ => null, 
			}, 
			JingJieType.金仙 => type switch
			{
				QualityType.黄品 => 金仙白, 
				QualityType.玄品 => 金仙绿, 
				QualityType.地品 => 金仙蓝, 
				QualityType.天品 => 金仙紫, 
				QualityType.宇品 => 金仙橙, 
				QualityType.宙品 => 金仙粉, 
				QualityType.洪品 => 金仙红, 
				QualityType.荒品 => 金仙彩, 
				_ => null, 
			}, 
			JingJieType.太乙金仙 => type switch
			{
				QualityType.黄品 => 太乙金仙白, 
				QualityType.玄品 => 太乙金仙绿, 
				QualityType.地品 => 太乙金仙蓝, 
				QualityType.天品 => 太乙金仙紫, 
				QualityType.宇品 => 太乙金仙橙, 
				QualityType.宙品 => 太乙金仙粉, 
				QualityType.洪品 => 太乙金仙红, 
				QualityType.荒品 => 太乙金仙彩, 
				_ => null, 
			}, 
			JingJieType.大罗金仙 => type switch
			{
				QualityType.黄品 => 大罗金仙白, 
				QualityType.玄品 => 大罗金仙绿, 
				QualityType.地品 => 大罗金仙蓝, 
				QualityType.天品 => 大罗金仙紫, 
				QualityType.宇品 => 大罗金仙橙, 
				QualityType.宙品 => 大罗金仙粉, 
				QualityType.洪品 => 大罗金仙红, 
				QualityType.荒品 => 大罗金仙彩, 
				_ => null, 
			}, 
			JingJieType.准圣 => type switch
			{
				QualityType.黄品 => 准圣白, 
				QualityType.玄品 => 准圣绿, 
				QualityType.地品 => 准圣蓝, 
				QualityType.天品 => 准圣紫, 
				QualityType.宇品 => 准圣橙, 
				QualityType.宙品 => 准圣粉, 
				QualityType.洪品 => 准圣红, 
				QualityType.荒品 => 准圣彩, 
				_ => null, 
			}, 
			JingJieType.圣人 => type switch
			{
				QualityType.黄品 => 圣人白, 
				QualityType.玄品 => 圣人绿, 
				QualityType.地品 => 圣人蓝, 
				QualityType.天品 => 圣人紫, 
				QualityType.宇品 => 圣人橙, 
				QualityType.宙品 => 圣人粉, 
				QualityType.洪品 => 圣人红, 
				QualityType.荒品 => 圣人彩, 
				_ => null, 
			}, 
			JingJieType.天道圣人 => type switch
			{
				QualityType.黄品 => 天道圣人白, 
				QualityType.玄品 => 天道圣人绿, 
				QualityType.地品 => 天道圣人蓝, 
				QualityType.天品 => 天道圣人紫, 
				QualityType.宇品 => 天道圣人橙, 
				QualityType.宙品 => 天道圣人粉, 
				QualityType.洪品 => 天道圣人红, 
				QualityType.荒品 => 天道圣人彩, 
				_ => null, 
			}, 
			JingJieType.大道圣人 => type switch
			{
				QualityType.黄品 => 大道圣人白, 
				QualityType.玄品 => 大道圣人绿, 
				QualityType.地品 => 大道圣人蓝, 
				QualityType.天品 => 大道圣人紫, 
				QualityType.宇品 => 大道圣人橙, 
				QualityType.宙品 => 大道圣人粉, 
				QualityType.洪品 => 大道圣人红, 
				QualityType.荒品 => 大道圣人彩, 
				_ => null, 
			}, 
			JingJieType.混元圣人 => type switch
			{
				QualityType.黄品 => 混元圣人白, 
				QualityType.玄品 => 混元圣人绿, 
				QualityType.地品 => 混元圣人蓝, 
				QualityType.天品 => 混元圣人紫, 
				QualityType.宇品 => 混元圣人橙, 
				QualityType.宙品 => 混元圣人粉, 
				QualityType.洪品 => 混元圣人红, 
				QualityType.荒品 => 混元圣人彩, 
				_ => null, 
			}, 
			_ => null, 
		});
	}

	public static Sprite Get仙石Sprite(仙石Type 仙石Type, int 阶数)
	{
		if (阶数 < 1 || 阶数 > 16)
		{
			return null;
		}
		if (仙石SpriteCache.TryGetValue(仙石Type, out var sprites) && sprites != null && sprites.Length >= 阶数)
		{
			return sprites[阶数 - 1];
		}
		return null;
	}

	public static Sprite Get境界Icon(JingJieType jingJieType)
	{
		switch (jingJieType)
		{
		case JingJieType.练气:
			return 练气;
		case JingJieType.筑基:
			return 筑基;
		case JingJieType.金丹:
			return 金丹;
		case JingJieType.元婴:
			return 元婴;
		case JingJieType.化神:
			return 化神;
		case JingJieType.合体:
			return 合体;
		case JingJieType.大乘:
			return 大乘;
		case JingJieType.天仙:
			return 天仙;
		case JingJieType.玄仙:
			return 玄仙;
		case JingJieType.金仙:
			return 金仙;
		case JingJieType.太乙金仙:
			return 太乙金仙;
		case JingJieType.大罗金仙:
			return 大罗金仙;
		case JingJieType.准圣:
			return 准圣;
		case JingJieType.圣人:
			return 圣人;
		case JingJieType.天道圣人:
			return 天道圣人;
		case JingJieType.大道圣人:
			return 大道圣人;
		case JingJieType.混元圣人:
		case JingJieType.鸿蒙:
			return 混元圣人;
		default:
			return null;
		}
	}

	public static Sprite Get神物Icon(神物Type type)
	{
		return (Sprite)(type switch
		{
			神物Type.最终伤害 => 最终伤害, 
			神物Type.冷却缩减 => 冷却缩减, 
			神物Type.全元素增伤 => 全元素增伤, 
			神物Type.元素人人为我 => 元素人人为我, 
			神物Type.元素我为人人 => 元素我为人人, 
			神物Type.全职业增伤 => 全职业增伤, 
			神物Type.职业人人为我 => 职业人人为我, 
			神物Type.职业我为人人 => 职业我为人人, 
			神物Type.暴击爆伤 => 暴击爆伤, 
			神物Type.二次暴击 => 二次暴击, 
			神物Type.轮回次数加伤 => 轮回次数加伤, 
			神物Type.轮回系数 => 轮回系数, 
			神物Type.时间流速加快 => 时间流速加快, 
			_ => null, 
		});
	}

	public static Sprite Get灵药Icon(灵药Type type, QualityType qualityType)
	{
		return (Sprite)(type switch
		{
			灵药Type.金银花蕊 => qualityType switch
			{
				QualityType.黄品 => 金银花蕊白, 
				QualityType.玄品 => 金银花蕊绿, 
				QualityType.地品 => 金银花蕊蓝, 
				QualityType.天品 => 金银花蕊紫, 
				QualityType.宇品 => 金银花蕊橙, 
				QualityType.宙品 => 金银花蕊粉, 
				QualityType.洪品 => 金银花蕊红, 
				QualityType.荒品 => 金银花蕊彩, 
				_ => null, 
			}, 
			灵药Type.马兜铃果 => qualityType switch
			{
				QualityType.黄品 => 马兜铃果白, 
				QualityType.玄品 => 马兜铃果绿, 
				QualityType.地品 => 马兜铃果蓝, 
				QualityType.天品 => 马兜铃果紫, 
				QualityType.宇品 => 马兜铃果橙, 
				QualityType.宙品 => 马兜铃果粉, 
				QualityType.洪品 => 马兜铃果红, 
				QualityType.荒品 => 马兜铃果彩, 
				_ => null, 
			}, 
			灵药Type.四叶参根 => qualityType switch
			{
				QualityType.黄品 => 四叶参根白, 
				QualityType.玄品 => 四叶参根绿, 
				QualityType.地品 => 四叶参根蓝, 
				QualityType.天品 => 四叶参根紫, 
				QualityType.宇品 => 四叶参根橙, 
				QualityType.宙品 => 四叶参根粉, 
				QualityType.洪品 => 四叶参根红, 
				QualityType.荒品 => 四叶参根彩, 
				_ => null, 
			}, 
			灵药Type.千年雪莲 => qualityType switch
			{
				QualityType.黄品 => 千年雪莲白, 
				QualityType.玄品 => 千年雪莲绿, 
				QualityType.地品 => 千年雪莲蓝, 
				QualityType.天品 => 千年雪莲紫, 
				QualityType.宇品 => 千年雪莲橙, 
				QualityType.宙品 => 千年雪莲粉, 
				QualityType.洪品 => 千年雪莲红, 
				QualityType.荒品 => 千年雪莲彩, 
				_ => null, 
			}, 
			灵药Type.回春草 => qualityType switch
			{
				QualityType.黄品 => 回春草白, 
				QualityType.玄品 => 回春草绿, 
				QualityType.地品 => 回春草蓝, 
				QualityType.天品 => 回春草紫, 
				QualityType.宇品 => 回春草橙, 
				QualityType.宙品 => 回春草粉, 
				QualityType.洪品 => 回春草红, 
				QualityType.荒品 => 回春草彩, 
				_ => null, 
			}, 
			灵药Type.补血花 => qualityType switch
			{
				QualityType.黄品 => 补血花白, 
				QualityType.玄品 => 补血花绿, 
				QualityType.地品 => 补血花蓝, 
				QualityType.天品 => 补血花紫, 
				QualityType.宇品 => 补血花橙, 
				QualityType.宙品 => 补血花粉, 
				QualityType.洪品 => 补血花红, 
				QualityType.荒品 => 补血花彩, 
				_ => null, 
			}, 
			灵药Type.龙纹草 => qualityType switch
			{
				QualityType.黄品 => 龙纹草白, 
				QualityType.玄品 => 龙纹草绿, 
				QualityType.地品 => 龙纹草蓝, 
				QualityType.天品 => 龙纹草紫, 
				QualityType.宇品 => 龙纹草橙, 
				QualityType.宙品 => 龙纹草粉, 
				QualityType.洪品 => 龙纹草红, 
				QualityType.荒品 => 龙纹草彩, 
				_ => null, 
			}, 
			灵药Type.九曲黄泉草 => qualityType switch
			{
				QualityType.黄品 => 九曲黄泉草白, 
				QualityType.玄品 => 九曲黄泉草绿, 
				QualityType.地品 => 九曲黄泉草蓝, 
				QualityType.天品 => 九曲黄泉草紫, 
				QualityType.宇品 => 九曲黄泉草橙, 
				QualityType.宙品 => 九曲黄泉草粉, 
				QualityType.洪品 => 九曲黄泉草红, 
				QualityType.荒品 => 九曲黄泉草彩, 
				_ => null, 
			}, 
			灵药Type.千幻蝶恋花 => qualityType switch
			{
				QualityType.黄品 => 千幻蝶恋花白, 
				QualityType.玄品 => 千幻蝶恋花绿, 
				QualityType.地品 => 千幻蝶恋花蓝, 
				QualityType.天品 => 千幻蝶恋花紫, 
				QualityType.宇品 => 千幻蝶恋花橙, 
				QualityType.宙品 => 千幻蝶恋花粉, 
				QualityType.洪品 => 千幻蝶恋花红, 
				QualityType.荒品 => 千幻蝶恋花彩, 
				_ => null, 
			}, 
			灵药Type.聚灵凝神叶 => qualityType switch
			{
				QualityType.黄品 => 聚灵凝神叶白, 
				QualityType.玄品 => 聚灵凝神叶绿, 
				QualityType.地品 => 聚灵凝神叶蓝, 
				QualityType.天品 => 聚灵凝神叶紫, 
				QualityType.宇品 => 聚灵凝神叶橙, 
				QualityType.宙品 => 聚灵凝神叶粉, 
				QualityType.洪品 => 聚灵凝神叶红, 
				QualityType.荒品 => 聚灵凝神叶彩, 
				_ => null, 
			}, 
			_ => null, 
		});
	}

	public static Sprite Get丹方icon(丹药Type 丹药Type, QualityType qualityType)
	{
		return (Sprite)(丹药Type switch
		{
			丹药Type.火焰伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方火焰伤害白, 
				QualityType.玄品 => 丹方火焰伤害绿, 
				QualityType.地品 => 丹方火焰伤害蓝, 
				QualityType.天品 => 丹方火焰伤害紫, 
				QualityType.宇品 => 丹方火焰伤害橙, 
				QualityType.宙品 => 丹方火焰伤害粉, 
				QualityType.洪品 => 丹方火焰伤害红, 
				QualityType.荒品 => 丹方火焰伤害彩, 
				_ => null, 
			}, 
			丹药Type.冰霜伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方冰霜伤害白, 
				QualityType.玄品 => 丹方冰霜伤害绿, 
				QualityType.地品 => 丹方冰霜伤害蓝, 
				QualityType.天品 => 丹方冰霜伤害紫, 
				QualityType.宇品 => 丹方冰霜伤害橙, 
				QualityType.宙品 => 丹方冰霜伤害粉, 
				QualityType.洪品 => 丹方冰霜伤害红, 
				QualityType.荒品 => 丹方冰霜伤害彩, 
				_ => null, 
			}, 
			丹药Type.雷电伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方雷电伤害白, 
				QualityType.玄品 => 丹方雷电伤害绿, 
				QualityType.地品 => 丹方雷电伤害蓝, 
				QualityType.天品 => 丹方雷电伤害紫, 
				QualityType.宇品 => 丹方雷电伤害橙, 
				QualityType.宙品 => 丹方雷电伤害粉, 
				QualityType.洪品 => 丹方雷电伤害红, 
				QualityType.荒品 => 丹方雷电伤害彩, 
				_ => null, 
			}, 
			丹药Type.黑暗伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方黑暗伤害白, 
				QualityType.玄品 => 丹方黑暗伤害绿, 
				QualityType.地品 => 丹方黑暗伤害蓝, 
				QualityType.天品 => 丹方黑暗伤害紫, 
				QualityType.宇品 => 丹方黑暗伤害橙, 
				QualityType.宙品 => 丹方黑暗伤害粉, 
				QualityType.洪品 => 丹方黑暗伤害红, 
				QualityType.荒品 => 丹方黑暗伤害彩, 
				_ => null, 
			}, 
			丹药Type.物理伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方物理伤害白, 
				QualityType.玄品 => 丹方物理伤害绿, 
				QualityType.地品 => 丹方物理伤害蓝, 
				QualityType.天品 => 丹方物理伤害紫, 
				QualityType.宇品 => 丹方物理伤害橙, 
				QualityType.宙品 => 丹方物理伤害粉, 
				QualityType.洪品 => 丹方物理伤害红, 
				QualityType.荒品 => 丹方物理伤害彩, 
				_ => null, 
			}, 
			丹药Type.战士伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方战士伤害白, 
				QualityType.玄品 => 丹方战士伤害绿, 
				QualityType.地品 => 丹方战士伤害蓝, 
				QualityType.天品 => 丹方战士伤害紫, 
				QualityType.宇品 => 丹方战士伤害橙, 
				QualityType.宙品 => 丹方战士伤害粉, 
				QualityType.洪品 => 丹方战士伤害红, 
				QualityType.荒品 => 丹方战士伤害彩, 
				_ => null, 
			}, 
			丹药Type.法师伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方法师伤害白, 
				QualityType.玄品 => 丹方法师伤害绿, 
				QualityType.地品 => 丹方法师伤害蓝, 
				QualityType.天品 => 丹方法师伤害紫, 
				QualityType.宇品 => 丹方法师伤害橙, 
				QualityType.宙品 => 丹方法师伤害粉, 
				QualityType.洪品 => 丹方法师伤害红, 
				QualityType.荒品 => 丹方法师伤害彩, 
				_ => null, 
			}, 
			丹药Type.射手伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方射手伤害白, 
				QualityType.玄品 => 丹方射手伤害绿, 
				QualityType.地品 => 丹方射手伤害蓝, 
				QualityType.天品 => 丹方射手伤害紫, 
				QualityType.宇品 => 丹方射手伤害橙, 
				QualityType.宙品 => 丹方射手伤害粉, 
				QualityType.洪品 => 丹方射手伤害红, 
				QualityType.荒品 => 丹方射手伤害彩, 
				_ => null, 
			}, 
			丹药Type.控制伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方控制伤害白, 
				QualityType.玄品 => 丹方控制伤害绿, 
				QualityType.地品 => 丹方控制伤害蓝, 
				QualityType.天品 => 丹方控制伤害紫, 
				QualityType.宇品 => 丹方控制伤害橙, 
				QualityType.宙品 => 丹方控制伤害粉, 
				QualityType.洪品 => 丹方控制伤害红, 
				QualityType.荒品 => 丹方控制伤害彩, 
				_ => null, 
			}, 
			丹药Type.最终伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方最终伤害白, 
				QualityType.玄品 => 丹方最终伤害绿, 
				QualityType.地品 => 丹方最终伤害蓝, 
				QualityType.天品 => 丹方最终伤害紫, 
				QualityType.宇品 => 丹方最终伤害橙, 
				QualityType.宙品 => 丹方最终伤害粉, 
				QualityType.洪品 => 丹方最终伤害红, 
				QualityType.荒品 => 丹方最终伤害彩, 
				_ => null, 
			}, 
			丹药Type.修炼速度 => qualityType switch
			{
				QualityType.黄品 => 丹方修炼速度白, 
				QualityType.玄品 => 丹方修炼速度绿, 
				QualityType.地品 => 丹方修炼速度蓝, 
				QualityType.天品 => 丹方修炼速度紫, 
				QualityType.宇品 => 丹方修炼速度橙, 
				QualityType.宙品 => 丹方修炼速度粉, 
				QualityType.洪品 => 丹方修炼速度红, 
				QualityType.荒品 => 丹方修炼速度彩, 
				_ => null, 
			}, 
			丹药Type.掉宝率 => qualityType switch
			{
				QualityType.黄品 => 丹方掉宝率白, 
				QualityType.玄品 => 丹方掉宝率绿, 
				QualityType.地品 => 丹方掉宝率蓝, 
				QualityType.天品 => 丹方掉宝率紫, 
				QualityType.宇品 => 丹方掉宝率橙, 
				QualityType.宙品 => 丹方掉宝率粉, 
				QualityType.洪品 => 丹方掉宝率红, 
				QualityType.荒品 => 丹方掉宝率彩, 
				_ => null, 
			}, 
			丹药Type.英雄暴击伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方英雄暴击伤害白, 
				QualityType.玄品 => 丹方英雄暴击伤害绿, 
				QualityType.地品 => 丹方英雄暴击伤害蓝, 
				QualityType.天品 => 丹方英雄暴击伤害紫, 
				QualityType.宇品 => 丹方英雄暴击伤害橙, 
				QualityType.宙品 => 丹方英雄暴击伤害粉, 
				QualityType.洪品 => 丹方英雄暴击伤害红, 
				QualityType.荒品 => 丹方英雄暴击伤害彩, 
				_ => null, 
			}, 
			丹药Type.加跟脚 => qualityType switch
			{
				QualityType.黄品 => 丹方加跟脚白, 
				QualityType.玄品 => 丹方加跟脚绿, 
				QualityType.地品 => 丹方加跟脚蓝, 
				QualityType.天品 => 丹方加跟脚紫, 
				QualityType.宇品 => 丹方加跟脚橙, 
				QualityType.宙品 => 丹方加跟脚粉, 
				QualityType.洪品 => 丹方加跟脚红, 
				QualityType.荒品 => 丹方加跟脚彩, 
				_ => null, 
			}, 
			丹药Type.英雄火焰伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方英雄火焰伤害白, 
				QualityType.玄品 => 丹方英雄火焰伤害绿, 
				QualityType.地品 => 丹方英雄火焰伤害蓝, 
				QualityType.天品 => 丹方英雄火焰伤害紫, 
				QualityType.宇品 => 丹方英雄火焰伤害橙, 
				QualityType.宙品 => 丹方英雄火焰伤害粉, 
				QualityType.洪品 => 丹方英雄火焰伤害红, 
				QualityType.荒品 => 丹方英雄火焰伤害彩, 
				_ => null, 
			}, 
			丹药Type.英雄冰霜伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方英雄冰霜伤害白, 
				QualityType.玄品 => 丹方英雄冰霜伤害绿, 
				QualityType.地品 => 丹方英雄冰霜伤害蓝, 
				QualityType.天品 => 丹方英雄冰霜伤害紫, 
				QualityType.宇品 => 丹方英雄冰霜伤害橙, 
				QualityType.宙品 => 丹方英雄冰霜伤害粉, 
				QualityType.洪品 => 丹方英雄冰霜伤害红, 
				QualityType.荒品 => 丹方英雄冰霜伤害彩, 
				_ => null, 
			}, 
			丹药Type.英雄雷电伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方英雄雷电伤害白, 
				QualityType.玄品 => 丹方英雄雷电伤害绿, 
				QualityType.地品 => 丹方英雄雷电伤害蓝, 
				QualityType.天品 => 丹方英雄雷电伤害紫, 
				QualityType.宇品 => 丹方英雄雷电伤害橙, 
				QualityType.宙品 => 丹方英雄雷电伤害粉, 
				QualityType.洪品 => 丹方英雄雷电伤害红, 
				QualityType.荒品 => 丹方英雄雷电伤害彩, 
				_ => null, 
			}, 
			丹药Type.英雄黑暗伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方英雄黑暗伤害白, 
				QualityType.玄品 => 丹方英雄黑暗伤害绿, 
				QualityType.地品 => 丹方英雄黑暗伤害蓝, 
				QualityType.天品 => 丹方英雄黑暗伤害紫, 
				QualityType.宇品 => 丹方英雄黑暗伤害橙, 
				QualityType.宙品 => 丹方英雄黑暗伤害粉, 
				QualityType.洪品 => 丹方英雄黑暗伤害红, 
				QualityType.荒品 => 丹方英雄黑暗伤害彩, 
				_ => null, 
			}, 
			丹药Type.英雄物理伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方英雄物理伤害白, 
				QualityType.玄品 => 丹方英雄物理伤害绿, 
				QualityType.地品 => 丹方英雄物理伤害蓝, 
				QualityType.天品 => 丹方英雄物理伤害紫, 
				QualityType.宇品 => 丹方英雄物理伤害橙, 
				QualityType.宙品 => 丹方英雄物理伤害粉, 
				QualityType.洪品 => 丹方英雄物理伤害红, 
				QualityType.荒品 => 丹方英雄物理伤害彩, 
				_ => null, 
			}, 
			丹药Type.英雄最终伤害 => qualityType switch
			{
				QualityType.黄品 => 丹方英雄最终伤害白, 
				QualityType.玄品 => 丹方英雄最终伤害绿, 
				QualityType.地品 => 丹方英雄最终伤害蓝, 
				QualityType.天品 => 丹方英雄最终伤害紫, 
				QualityType.宇品 => 丹方英雄最终伤害橙, 
				QualityType.宙品 => 丹方英雄最终伤害粉, 
				QualityType.洪品 => 丹方英雄最终伤害红, 
				QualityType.荒品 => 丹方英雄最终伤害彩, 
				_ => null, 
			}, 
			_ => null, 
		});
	}

	public static Sprite Get丹药icon(丹药Type 丹药Type, QualityType qualityType)
	{
		return (Sprite)(丹药Type switch
		{
			丹药Type.火焰伤害 => qualityType switch
			{
				QualityType.黄品 => 火焰伤害白, 
				QualityType.玄品 => 火焰伤害绿, 
				QualityType.地品 => 火焰伤害蓝, 
				QualityType.天品 => 火焰伤害紫, 
				QualityType.宇品 => 火焰伤害橙, 
				QualityType.宙品 => 火焰伤害粉, 
				QualityType.洪品 => 火焰伤害红, 
				QualityType.荒品 => 火焰伤害彩, 
				_ => null, 
			}, 
			丹药Type.冰霜伤害 => qualityType switch
			{
				QualityType.黄品 => 冰霜伤害白, 
				QualityType.玄品 => 冰霜伤害绿, 
				QualityType.地品 => 冰霜伤害蓝, 
				QualityType.天品 => 冰霜伤害紫, 
				QualityType.宇品 => 冰霜伤害橙, 
				QualityType.宙品 => 冰霜伤害粉, 
				QualityType.洪品 => 冰霜伤害红, 
				QualityType.荒品 => 冰霜伤害彩, 
				_ => null, 
			}, 
			丹药Type.雷电伤害 => qualityType switch
			{
				QualityType.黄品 => 雷电伤害白, 
				QualityType.玄品 => 雷电伤害绿, 
				QualityType.地品 => 雷电伤害蓝, 
				QualityType.天品 => 雷电伤害紫, 
				QualityType.宇品 => 雷电伤害橙, 
				QualityType.宙品 => 雷电伤害粉, 
				QualityType.洪品 => 雷电伤害红, 
				QualityType.荒品 => 雷电伤害彩, 
				_ => null, 
			}, 
			丹药Type.黑暗伤害 => qualityType switch
			{
				QualityType.黄品 => 黑暗伤害白, 
				QualityType.玄品 => 黑暗伤害绿, 
				QualityType.地品 => 黑暗伤害蓝, 
				QualityType.天品 => 黑暗伤害紫, 
				QualityType.宇品 => 黑暗伤害橙, 
				QualityType.宙品 => 黑暗伤害粉, 
				QualityType.洪品 => 黑暗伤害红, 
				QualityType.荒品 => 黑暗伤害彩, 
				_ => null, 
			}, 
			丹药Type.物理伤害 => qualityType switch
			{
				QualityType.黄品 => 物理伤害白, 
				QualityType.玄品 => 物理伤害绿, 
				QualityType.地品 => 物理伤害蓝, 
				QualityType.天品 => 物理伤害紫, 
				QualityType.宇品 => 物理伤害橙, 
				QualityType.宙品 => 物理伤害粉, 
				QualityType.洪品 => 物理伤害红, 
				QualityType.荒品 => 物理伤害彩, 
				_ => null, 
			}, 
			丹药Type.战士伤害 => qualityType switch
			{
				QualityType.黄品 => 战士伤害白, 
				QualityType.玄品 => 战士伤害绿, 
				QualityType.地品 => 战士伤害蓝, 
				QualityType.天品 => 战士伤害紫, 
				QualityType.宇品 => 战士伤害橙, 
				QualityType.宙品 => 战士伤害粉, 
				QualityType.洪品 => 战士伤害红, 
				QualityType.荒品 => 战士伤害彩, 
				_ => null, 
			}, 
			丹药Type.法师伤害 => qualityType switch
			{
				QualityType.黄品 => 法师伤害白, 
				QualityType.玄品 => 法师伤害绿, 
				QualityType.地品 => 法师伤害蓝, 
				QualityType.天品 => 法师伤害紫, 
				QualityType.宇品 => 法师伤害橙, 
				QualityType.宙品 => 法师伤害粉, 
				QualityType.洪品 => 法师伤害红, 
				QualityType.荒品 => 法师伤害彩, 
				_ => null, 
			}, 
			丹药Type.射手伤害 => qualityType switch
			{
				QualityType.黄品 => 射手伤害白, 
				QualityType.玄品 => 射手伤害绿, 
				QualityType.地品 => 射手伤害蓝, 
				QualityType.天品 => 射手伤害紫, 
				QualityType.宇品 => 射手伤害橙, 
				QualityType.宙品 => 射手伤害粉, 
				QualityType.洪品 => 射手伤害红, 
				QualityType.荒品 => 射手伤害彩, 
				_ => null, 
			}, 
			丹药Type.控制伤害 => qualityType switch
			{
				QualityType.黄品 => 控制伤害白, 
				QualityType.玄品 => 控制伤害绿, 
				QualityType.地品 => 控制伤害蓝, 
				QualityType.天品 => 控制伤害紫, 
				QualityType.宇品 => 控制伤害橙, 
				QualityType.宙品 => 控制伤害粉, 
				QualityType.洪品 => 控制伤害红, 
				QualityType.荒品 => 控制伤害彩, 
				_ => null, 
			}, 
			丹药Type.最终伤害 => qualityType switch
			{
				QualityType.黄品 => 最终伤害白, 
				QualityType.玄品 => 最终伤害绿, 
				QualityType.地品 => 最终伤害蓝, 
				QualityType.天品 => 最终伤害紫, 
				QualityType.宇品 => 最终伤害橙, 
				QualityType.宙品 => 最终伤害粉, 
				QualityType.洪品 => 最终伤害红, 
				QualityType.荒品 => 最终伤害彩, 
				_ => null, 
			}, 
			丹药Type.修炼速度 => qualityType switch
			{
				QualityType.黄品 => 修炼速度白, 
				QualityType.玄品 => 修炼速度绿, 
				QualityType.地品 => 修炼速度蓝, 
				QualityType.天品 => 修炼速度紫, 
				QualityType.宇品 => 修炼速度橙, 
				QualityType.宙品 => 修炼速度粉, 
				QualityType.洪品 => 修炼速度红, 
				QualityType.荒品 => 修炼速度彩, 
				_ => null, 
			}, 
			丹药Type.掉宝率 => qualityType switch
			{
				QualityType.黄品 => 掉宝率白, 
				QualityType.玄品 => 掉宝率绿, 
				QualityType.地品 => 掉宝率蓝, 
				QualityType.天品 => 掉宝率紫, 
				QualityType.宇品 => 掉宝率橙, 
				QualityType.宙品 => 掉宝率粉, 
				QualityType.洪品 => 掉宝率红, 
				QualityType.荒品 => 掉宝率彩, 
				_ => null, 
			}, 
			丹药Type.英雄暴击伤害 => qualityType switch
			{
				QualityType.黄品 => 英雄暴击伤害白, 
				QualityType.玄品 => 英雄暴击伤害绿, 
				QualityType.地品 => 英雄暴击伤害蓝, 
				QualityType.天品 => 英雄暴击伤害紫, 
				QualityType.宇品 => 英雄暴击伤害橙, 
				QualityType.宙品 => 英雄暴击伤害粉, 
				QualityType.洪品 => 英雄暴击伤害红, 
				QualityType.荒品 => 英雄暴击伤害彩, 
				_ => null, 
			}, 
			丹药Type.加跟脚 => qualityType switch
			{
				QualityType.黄品 => 加跟脚白, 
				QualityType.玄品 => 加跟脚绿, 
				QualityType.地品 => 加跟脚蓝, 
				QualityType.天品 => 加跟脚紫, 
				QualityType.宇品 => 加跟脚橙, 
				QualityType.宙品 => 加跟脚粉, 
				QualityType.洪品 => 加跟脚红, 
				QualityType.荒品 => 加跟脚彩, 
				_ => null, 
			}, 
			丹药Type.英雄火焰伤害 => qualityType switch
			{
				QualityType.黄品 => 英雄火焰伤害白, 
				QualityType.玄品 => 英雄火焰伤害绿, 
				QualityType.地品 => 英雄火焰伤害蓝, 
				QualityType.天品 => 英雄火焰伤害紫, 
				QualityType.宇品 => 英雄火焰伤害橙, 
				QualityType.宙品 => 英雄火焰伤害粉, 
				QualityType.洪品 => 英雄火焰伤害红, 
				QualityType.荒品 => 英雄火焰伤害彩, 
				_ => null, 
			}, 
			丹药Type.英雄冰霜伤害 => qualityType switch
			{
				QualityType.黄品 => 英雄冰霜伤害白, 
				QualityType.玄品 => 英雄冰霜伤害绿, 
				QualityType.地品 => 英雄冰霜伤害蓝, 
				QualityType.天品 => 英雄冰霜伤害紫, 
				QualityType.宇品 => 英雄冰霜伤害橙, 
				QualityType.宙品 => 英雄冰霜伤害粉, 
				QualityType.洪品 => 英雄冰霜伤害红, 
				QualityType.荒品 => 英雄冰霜伤害彩, 
				_ => null, 
			}, 
			丹药Type.英雄雷电伤害 => qualityType switch
			{
				QualityType.黄品 => 英雄雷电伤害白, 
				QualityType.玄品 => 英雄雷电伤害绿, 
				QualityType.地品 => 英雄雷电伤害蓝, 
				QualityType.天品 => 英雄雷电伤害紫, 
				QualityType.宇品 => 英雄雷电伤害橙, 
				QualityType.宙品 => 英雄雷电伤害粉, 
				QualityType.洪品 => 英雄雷电伤害红, 
				QualityType.荒品 => 英雄雷电伤害彩, 
				_ => null, 
			}, 
			丹药Type.英雄黑暗伤害 => qualityType switch
			{
				QualityType.黄品 => 英雄黑暗伤害白, 
				QualityType.玄品 => 英雄黑暗伤害绿, 
				QualityType.地品 => 英雄黑暗伤害蓝, 
				QualityType.天品 => 英雄黑暗伤害紫, 
				QualityType.宇品 => 英雄黑暗伤害橙, 
				QualityType.宙品 => 英雄黑暗伤害粉, 
				QualityType.洪品 => 英雄黑暗伤害红, 
				QualityType.荒品 => 英雄黑暗伤害彩, 
				_ => null, 
			}, 
			丹药Type.英雄物理伤害 => qualityType switch
			{
				QualityType.黄品 => 英雄物理伤害白, 
				QualityType.玄品 => 英雄物理伤害绿, 
				QualityType.地品 => 英雄物理伤害蓝, 
				QualityType.天品 => 英雄物理伤害紫, 
				QualityType.宇品 => 英雄物理伤害橙, 
				QualityType.宙品 => 英雄物理伤害粉, 
				QualityType.洪品 => 英雄物理伤害红, 
				QualityType.荒品 => 英雄物理伤害彩, 
				_ => null, 
			}, 
			丹药Type.英雄最终伤害 => qualityType switch
			{
				QualityType.黄品 => 英雄最终伤害白, 
				QualityType.玄品 => 英雄最终伤害绿, 
				QualityType.地品 => 英雄最终伤害蓝, 
				QualityType.天品 => 英雄最终伤害紫, 
				QualityType.宇品 => 英雄最终伤害橙, 
				QualityType.宙品 => 英雄最终伤害粉, 
				QualityType.洪品 => 英雄最终伤害红, 
				QualityType.荒品 => 英雄最终伤害彩, 
				_ => null, 
			}, 
			_ => null, 
		});
	}

	public static Sprite GetBuffIcon(丹药Type type, QualityType qualityType)
	{
		switch (type)
		{
		case 丹药Type.修炼速度:
			switch (qualityType)
			{
			case QualityType.黄品:
				return Buff修炼速度白;
			case QualityType.玄品:
				return Buff修炼速度绿;
			case QualityType.地品:
				return Buff修炼速度蓝;
			case QualityType.天品:
				return Buff修炼速度紫;
			case QualityType.宇品:
				return Buff修炼速度橙;
			case QualityType.宙品:
				return Buff修炼速度粉;
			case QualityType.洪品:
				return Buff修炼速度红;
			case QualityType.荒品:
				return Buff修炼速度彩;
			}
			break;
		case 丹药Type.掉宝率:
			switch (qualityType)
			{
			case QualityType.黄品:
				return Buff掉宝率白;
			case QualityType.玄品:
				return Buff掉宝率绿;
			case QualityType.地品:
				return Buff掉宝率蓝;
			case QualityType.天品:
				return Buff掉宝率紫;
			case QualityType.宇品:
				return Buff掉宝率橙;
			case QualityType.宙品:
				return Buff掉宝率粉;
			case QualityType.洪品:
				return Buff掉宝率红;
			case QualityType.荒品:
				return Buff掉宝率彩;
			}
			break;
		}
		return null;
	}

	public static Sprite Get英雄神通横幅(HeroType herotype)
	{
		return (Sprite)(herotype switch
		{
			HeroType.丹童 => 丹童神通横幅, 
			HeroType.土地 => 土地神通横幅, 
			HeroType.河伯 => 河伯神通横幅, 
			HeroType.瑶池仙女 => 瑶池仙女神通横幅, 
			HeroType.石敢当 => 石敢当神通横幅, 
			HeroType.玄女 => 玄女神通横幅, 
			HeroType.龟丞相 => 龟丞相神通横幅, 
			HeroType.太白金星 => 太白金星神通横幅, 
			HeroType.多闻天王 => 多闻天王神通横幅, 
			HeroType.广目天王 => 广目天王神通横幅, 
			HeroType.雷震子 => 雷震子神通横幅, 
			HeroType.月老 => 月老神通横幅, 
			HeroType.嫦娥 => 嫦娥神通横幅, 
			HeroType.杨戬 => 杨戬神通横幅, 
			HeroType.妲己 => 妲己神通横幅, 
			HeroType.牛魔王 => 牛魔王神通横幅, 
			HeroType.哪吒 => 哪吒神通横幅, 
			HeroType.孙悟空 => 孙悟空神通横幅, 
			HeroType.碧霄 => 碧霄神通横幅, 
			HeroType.琼霄 => 琼霄神通横幅, 
			HeroType.羲和 => 羲和神通横幅, 
			HeroType.常羲 => 常羲神通横幅, 
			HeroType.后羿 => 后羿神通横幅, 
			HeroType.云霄 => 云霄神通横幅, 
			HeroType.女娲 => 女娲神通横幅, 
			HeroType.老子 => 老子神通横幅, 
			HeroType.通天 => 通天神通横幅, 
			HeroType.元始 => 元始神通横幅, 
			HeroType.鸿钧 => 鸿钧神通横幅, 
			HeroType.盘古 => 盘古神通横幅, 
			_ => null, 
		});
	}

	public static Sprite Get英雄技能树Icon(技能Type type)
	{
		return (Sprite)(type switch
		{
			技能Type.英雄伤害 => 英雄伤害, 
			技能Type.技能冷却缩减 => 技能冷却缩减, 
			技能Type.击退距离 => 击退距离, 
			技能Type.效果范围 => 效果范围, 
			技能Type.瑶池减速效果 => 瑶池减速效果, 
			技能Type.瑶池持续时间 => 瑶池持续时间, 
			技能Type.龟丞相减速 => 龟丞相减速, 
			技能Type.妲己效果 => 妲己效果, 
			技能Type.妲己持续时间 => 妲己持续时间, 
			技能Type.孙悟空挥棒次数 => 孙悟空挥棒次数, 
			技能Type.琼霄控制时长 => 琼霄控制时长, 
			技能Type.女娲效果 => 女娲效果, 
			技能Type.女娲持续时间 => 女娲持续时间, 
			技能Type.元始火种个数 => 元始火种个数, 
			技能Type.火种旋转速度 => 火种旋转速度, 
			技能Type.元始下场时间 => 元始下场时间, 
			技能Type.玄冰风弹道速度减少 => 玄冰风弹道速度减少, 
			技能Type.玄冰风每秒增长速度增加 => 玄冰风每秒增长速度增加, 
			技能Type.无极天火数量 => 无极天火数量, 
			技能Type.混沌开天拳出拳数量增加 => 混沌开天拳出拳数量增加, 
			技能Type.神通冷却时间 => 神通冷却时间, 
			技能Type.神通伤害1 => 神通伤害1, 
			技能Type.神通伤害2 => 神通伤害2, 
			技能Type.神通能量 => 神通能量, 
			技能Type.被辅助英雄伤害 => 被辅助英雄伤害, 
			技能Type.被辅助英雄暴击率 => 被辅助英雄暴击率, 
			技能Type.被辅助英雄暴击伤害 => 被辅助英雄暴击伤害, 
			技能Type.技能伤害1 => 技能伤害1, 
			技能Type.技能伤害2 => 技能伤害2, 
			技能Type.射手分裂 => 射手分裂, 
			技能Type.射手穿透 => 射手穿透, 
			技能Type.物理伤害 => 物理伤害, 
			技能Type.雷电伤害 => 雷电伤害, 
			技能Type.黑暗伤害 => 黑暗伤害, 
			技能Type.火焰伤害 => 火焰伤害, 
			技能Type.冰霜伤害 => 冰霜伤害, 
			技能Type.火焰灼烧伤害 => 火焰灼烧伤害, 
			技能Type.火焰灼烧时间 => 火焰灼烧时间, 
			技能Type.火焰灼烧最大层数 => 火焰灼烧最大层数, 
			技能Type.冰减速 => 冰减速, 
			技能Type.冰概率冰冻 => 冰概率冰冻, 
			技能Type.冰冻时间 => 冰冻时间, 
			技能Type.冰冻增伤 => 冰冻增伤, 
			技能Type.易电状态概率 => 易电状态概率, 
			技能Type.易电状态时间 => 易电状态时间, 
			技能Type.易电状态伤害 => 易电状态伤害, 
			技能Type.黑暗印记储存伤害 => 黑暗印记储存伤害, 
			技能Type.黑暗印记减少引爆层数 => 黑暗印记减少引爆层数, 
			技能Type.黑暗印记增加引爆层数 => 黑暗印记增加引爆层数, 
			技能Type.物理碎甲怪物百分比 => 物理碎甲怪物百分比, 
			技能Type.物理碎甲领主攻击百分比 => 物理碎甲领主攻击百分比, 
			技能Type.物理无抗性加伤害 => 物理无抗性加伤害, 
			技能Type.增加所有英雄伤害 => 增加所有英雄伤害, 
			技能Type.寻宝速度 => 寻宝速度, 
			技能Type.概率紫变橙 => 概率紫变橙, 
			技能Type.概率橙变粉 => 概率橙变粉, 
			技能Type.概率粉变红 => 概率粉变红, 
			技能Type.概率红变彩 => 概率红变彩, 
			技能Type.概率提升数量 => 概率提升数量, 
			技能Type.暴击率 => 暴击率, 
			技能Type.暴击伤害 => 暴击伤害, 
			技能Type.普通怪增伤 => 普通怪增伤, 
			技能Type.精英怪增伤 => 精英怪增伤, 
			技能Type.首领怪增伤 => 首领怪增伤, 
			技能Type.石敢当锤子速度 => 石敢当锤子速度, 
			技能Type.被辅助英雄普通怪伤害 => 被辅助英雄普通怪伤害, 
			技能Type.被辅助英雄精英怪伤害 => 被辅助英雄精英怪伤害, 
			技能Type.被辅助英雄首领怪伤害 => 被辅助英雄首领怪伤害, 
			技能Type.被辅助元素伤害 => 被辅助元素伤害, 
			技能Type.哪吒神通数量 => 哪吒神通数量, 
			技能Type.碧霄神通数量 => 碧霄神通数量, 
			技能Type.羲和神通数量 => 羲和神通数量, 
			技能Type.被辅助英雄技能伤害 => 被辅助英雄技能伤害, 
			技能Type.女娲神通效果 => 女娲神通效果, 
			_ => null, 
		});
	}

	public static Sprite Get英雄神通icon(HeroType herotype)
	{
		return (Sprite)(herotype switch
		{
			HeroType.丹童 => 丹童神通icon, 
			HeroType.土地 => 土地神通icon, 
			HeroType.河伯 => 河伯神通icon, 
			HeroType.瑶池仙女 => 瑶池仙女神通icon, 
			HeroType.石敢当 => 石敢当神通icon, 
			HeroType.玄女 => 玄女神通icon, 
			HeroType.龟丞相 => 龟丞相神通icon, 
			HeroType.太白金星 => 太白金星神通icon, 
			HeroType.多闻天王 => 多闻天王神通icon, 
			HeroType.广目天王 => 广目天王神通icon, 
			HeroType.雷震子 => 雷震子神通icon, 
			HeroType.月老 => 月老神通icon, 
			HeroType.嫦娥 => 嫦娥神通icon, 
			HeroType.杨戬 => 杨戬神通icon, 
			HeroType.妲己 => 妲己神通icon, 
			HeroType.牛魔王 => 牛魔王神通icon, 
			HeroType.哪吒 => 哪吒神通icon, 
			HeroType.孙悟空 => 孙悟空神通icon, 
			HeroType.碧霄 => 碧霄神通icon, 
			HeroType.琼霄 => 琼霄神通icon, 
			HeroType.羲和 => 羲和神通icon, 
			HeroType.常羲 => 常羲神通icon, 
			HeroType.后羿 => 后羿神通icon, 
			HeroType.云霄 => 云霄神通icon, 
			HeroType.女娲 => 女娲神通icon, 
			HeroType.老子 => 老子神通icon, 
			HeroType.通天 => 通天神通icon, 
			HeroType.元始 => 元始神通icon, 
			HeroType.鸿钧 => 鸿钧神通icon, 
			HeroType.盘古 => 盘古神通icon, 
			_ => null, 
		});
	}

	public static Sprite Get英雄背景框(QualityType type)
	{
		return (Sprite)(type switch
		{
			QualityType.黄品 => 英雄背景框白, 
			QualityType.玄品 => 英雄背景框绿, 
			QualityType.地品 => 英雄背景框蓝, 
			QualityType.天品 => 英雄背景框紫, 
			QualityType.宇品 => 英雄背景框橙, 
			QualityType.宙品 => 英雄背景框粉, 
			QualityType.洪品 => 英雄背景框红, 
			QualityType.荒品 => 英雄背景框彩, 
			_ => null, 
		});
	}

	public static Sprite Get编队界面英雄背景框(QualityType type)
	{
		return (Sprite)(type switch
		{
			QualityType.黄品 => 编队界面英雄背景框白, 
			QualityType.玄品 => 编队界面英雄背景框绿, 
			QualityType.地品 => 编队界面英雄背景框蓝, 
			QualityType.天品 => 编队界面英雄背景框紫, 
			QualityType.宇品 => 编队界面英雄背景框橙, 
			QualityType.宙品 => 编队界面英雄背景框粉, 
			QualityType.洪品 => 编队界面英雄背景框红, 
			QualityType.荒品 => 编队界面英雄背景框彩, 
			_ => null, 
		});
	}

	public static Sprite Get英雄平台Sprite(HeroType herotype)
	{
		return (Sprite)(herotype switch
		{
			HeroType.丹童 => 丹童平台, 
			HeroType.土地 => 土地平台, 
			HeroType.河伯 => 河伯平台, 
			HeroType.瑶池仙女 => 瑶池仙女平台, 
			HeroType.石敢当 => 石敢当平台, 
			HeroType.玄女 => 玄女平台, 
			HeroType.龟丞相 => 龟丞相平台, 
			HeroType.太白金星 => 太白金星平台, 
			HeroType.多闻天王 => 多闻天王平台, 
			HeroType.广目天王 => 广目天王平台, 
			HeroType.雷震子 => 雷震子平台, 
			HeroType.月老 => 月老平台, 
			HeroType.嫦娥 => 嫦娥平台, 
			HeroType.杨戬 => 杨戬平台, 
			HeroType.妲己 => 妲己平台, 
			HeroType.牛魔王 => 牛魔王平台, 
			HeroType.哪吒 => 哪吒平台, 
			HeroType.孙悟空 => 孙悟空平台, 
			HeroType.碧霄 => 碧霄平台, 
			HeroType.琼霄 => 琼霄平台, 
			HeroType.羲和 => 羲和平台, 
			HeroType.常羲 => 常羲平台, 
			HeroType.后羿 => 后羿平台, 
			HeroType.云霄 => 云霄平台, 
			HeroType.女娲 => 女娲平台, 
			HeroType.老子 => 老子平台, 
			HeroType.通天 => 通天平台, 
			HeroType.元始 => 元始平台, 
			HeroType.鸿钧 => 鸿钧平台, 
			HeroType.盘古 => 盘古平台, 
			_ => null, 
		});
	}

	public static Sprite Get符文Sprite(符文Type type, QualityType quality)
	{
		int index = (int)quality - 1;
		if (type == 符文Type.None || index < 0 || index > 7)
		{
			return null;
		}
		if (符文SpriteCache.TryGetValue(type, out var arr) && arr.Length > index)
		{
			return arr[index];
		}
		return null;
	}

	public static Sprite Get女供奉Sprite()
	{
		return Get女供奉Sprite(Random.Range(1, 31));
	}

	public static Sprite Get女供奉Sprite(int id)
	{
		return (Sprite)(id switch
		{
			1 => 女供奉1, 
			2 => 女供奉2, 
			3 => 女供奉3, 
			4 => 女供奉4, 
			5 => 女供奉5, 
			6 => 女供奉6, 
			7 => 女供奉7, 
			8 => 女供奉8, 
			9 => 女供奉9, 
			10 => 女供奉10, 
			11 => 女供奉11, 
			12 => 女供奉12, 
			13 => 女供奉13, 
			14 => 女供奉14, 
			15 => 女供奉15, 
			16 => 女供奉16, 
			17 => 女供奉17, 
			18 => 女供奉18, 
			19 => 女供奉19, 
			20 => 女供奉20, 
			21 => 女供奉21, 
			22 => 女供奉22, 
			23 => 女供奉23, 
			24 => 女供奉24, 
			25 => 女供奉25, 
			26 => 女供奉26, 
			27 => 女供奉27, 
			28 => 女供奉28, 
			29 => 女供奉29, 
			30 => 女供奉30, 
			_ => 女供奉1, 
		});
	}

	public static Sprite Get领主数值icon(建筑Type 建筑type)
	{
		return (Sprite)(建筑type switch
		{
			建筑Type.功德碑 => 德, 
			建筑Type.玄铁洞 => 铁, 
			建筑Type.矿场 => 矿, 
			建筑Type.炼丹室 => 丹, 
			建筑Type.炼器室 => 器, 
			建筑Type.坊市 => 坊, 
			建筑Type.灵兽坊 => 兽, 
			建筑Type.仙女阁 => 仙, 
			建筑Type.地脉 => 玉, 
			建筑Type.聚贤阁 => 贤, 
			_ => null, 
		});
	}

	public static Sprite Get供奉特性标签(供奉品质Type 供奉品质Type)
	{
		return (Sprite)(供奉品质Type switch
		{
			供奉品质Type.凡 => 供奉特性标签白, 
			供奉品质Type.灵 => 供奉特性标签蓝, 
			供奉品质Type.仙 => 供奉特性标签橙, 
			供奉品质Type.圣 => 供奉特性标签红, 
			供奉品质Type.道 => 供奉特性标签彩, 
			_ => null, 
		});
	}

	public static Sprite Get供奉品质标签(供奉品质Type 供奉品质Type)
	{
		return (Sprite)(供奉品质Type switch
		{
			供奉品质Type.凡 => 供奉品质标签白, 
			供奉品质Type.灵 => 供奉品质标签蓝, 
			供奉品质Type.仙 => 供奉品质标签橙, 
			供奉品质Type.圣 => 供奉品质标签红, 
			供奉品质Type.道 => 供奉品质标签彩, 
			_ => null, 
		});
	}

	public static Sprite Get道场建筑Sprite(建筑Type type)
	{
		return (Sprite)(type switch
		{
			建筑Type.矿场 => 道场矿场, 
			建筑Type.坊市 => 道场坊市, 
			建筑Type.聚贤阁 => 道场聚贤阁, 
			建筑Type.灵兽坊 => 道场灵兽坊, 
			建筑Type.灵植园 => 道场灵植园, 
			建筑Type.仙女阁 => 道场仙女阁, 
			建筑Type.地脉 => 道场地脉, 
			建筑Type.领主府 => 道场领主府, 
			建筑Type.炼丹室 => 道场炼丹室, 
			建筑Type.炼器室 => 道场炼器室, 
			建筑Type.玄铁洞 => 道场玄铁洞, 
			建筑Type.功德碑 => 道场功德碑, 
			_ => null, 
		});
	}

	public static Sprite Get法器材料Sprite(法器材料Type 法器材料Type, int 阶数)
	{
		if (阶数 < 1 || 阶数 > 16)
		{
			return null;
		}
		if (材料SpriteCache.TryGetValue(法器材料Type, out var value) && value.Length >= 阶数)
		{
			return value[阶数 - 1];
		}
		return null;
	}

	[Obsolete("请使用 Get法器材料Sprite(法器材料Type type, int 阶数) 代替")]
	public static Sprite Get法器材料Sprite(法器材料Type 法器材料Type, QualityType qualityType)
	{
		if (qualityType < QualityType.黄品 || qualityType > (QualityType)16)
		{
			return null;
		}
		return Get法器材料Sprite(法器材料Type, (int)qualityType);
	}

	public static Sprite Get灵兽Sprite(灵兽Type 灵兽Type)
	{
		return (Sprite)(灵兽Type switch
		{
			灵兽Type.火1 => 火1, 
			灵兽Type.火2 => 火2, 
			灵兽Type.火3 => 火3, 
			灵兽Type.火4 => 火4, 
			灵兽Type.火5 => 火5, 
			灵兽Type.火6 => 火6, 
			灵兽Type.火7 => 火7, 
			灵兽Type.火8 => 火8, 
			灵兽Type.电1 => 电1, 
			灵兽Type.电2 => 电2, 
			灵兽Type.电3 => 电3, 
			灵兽Type.电4 => 电4, 
			灵兽Type.电5 => 电5, 
			灵兽Type.电6 => 电6, 
			灵兽Type.电7 => 电7, 
			灵兽Type.电8 => 电8, 
			灵兽Type.物1 => 物1, 
			灵兽Type.物2 => 物2, 
			灵兽Type.物3 => 物3, 
			灵兽Type.物4 => 物4, 
			灵兽Type.物5 => 物5, 
			灵兽Type.物6 => 物6, 
			灵兽Type.物7 => 物7, 
			灵兽Type.物8 => 物8, 
			灵兽Type.冰1 => 冰1, 
			灵兽Type.冰2 => 冰2, 
			灵兽Type.冰3 => 冰3, 
			灵兽Type.冰4 => 冰4, 
			灵兽Type.冰5 => 冰5, 
			灵兽Type.冰6 => 冰6, 
			灵兽Type.冰7 => 冰7, 
			灵兽Type.冰8 => 冰8, 
			灵兽Type.暗1 => 暗1, 
			灵兽Type.暗2 => 暗2, 
			灵兽Type.暗3 => 暗3, 
			灵兽Type.暗4 => 暗4, 
			灵兽Type.暗5 => 暗5, 
			灵兽Type.暗6 => 暗6, 
			灵兽Type.暗7 => 暗7, 
			灵兽Type.暗8 => 暗8, 
			_ => null, 
		});
	}

	public static Sprite Get仙子Icon(仙子Type 仙子Type)
	{
		return (Sprite)(仙子Type switch
		{
			仙子Type.伤害 => 仙子icon1, 
			仙子Type.合欢 => 仙子icon13, 
			仙子Type.灵兽 => 仙子icon9, 
			仙子Type.炼器 => 仙子icon14, 
			仙子Type.炼丹 => 仙子icon12, 
			仙子Type.掉宝 => 仙子icon11, 
			仙子Type.时间流速 => 仙子icon3, 
			仙子Type.轮回 => 仙子icon4, 
			仙子Type.功法 => 仙子icon8, 
			仙子Type.符文 => 仙子icon10, 
			仙子Type.领主装备 => 仙子icon7, 
			_ => null, 
		});
	}

	public static Sprite Get仙子头像(仙子Type 仙子Type)
	{
		return (Sprite)(仙子Type switch
		{
			仙子Type.伤害 => 仙子头像1, 
			仙子Type.合欢 => 仙子头像13, 
			仙子Type.灵兽 => 仙子头像9, 
			仙子Type.炼器 => 仙子头像14, 
			仙子Type.炼丹 => 仙子头像12, 
			仙子Type.掉宝 => 仙子头像11, 
			仙子Type.时间流速 => 仙子头像3, 
			仙子Type.轮回 => 仙子头像4, 
			仙子Type.功法 => 仙子头像8, 
			仙子Type.符文 => 仙子头像10, 
			仙子Type.领主装备 => 仙子头像7, 
			_ => null, 
		});
	}

	public static Sprite Get灵植幼苗Sprite(灵植Type 灵植Type)
	{
		return (Sprite)(灵植Type switch
		{
			灵植Type.紫云英 => 紫云英幼苗, 
			灵植Type.曜日葵 => 曜日葵幼苗, 
			灵植Type.幻音铃 => 幻音铃幼苗, 
			灵植Type.幻紫玫 => 幻紫玫幼苗, 
			灵植Type.九幽紫 => 九幽紫幼苗, 
			灵植Type.赤焰百合 => 赤焰百合幼苗, 
			灵植Type.碧海螺 => 碧海螺幼苗, 
			灵植Type.粉面佛莲 => 粉面佛莲幼苗, 
			灵植Type.紫幽草 => 紫幽草幼苗, 
			灵植Type.三生花 => 三生花幼苗, 
			灵植Type.向阳花 => 向阳花幼苗, 
			灵植Type.白玉玲 => 白玉玲幼苗, 
			灵植Type.赤阳花 => 赤阳花幼苗, 
			灵植Type.寒星兰 => 寒星兰幼苗, 
			灵植Type.赤霞花 => 赤霞花幼苗, 
			灵植Type.惊雷子 => 惊雷子幼苗, 
			灵植Type.幽兰铃 => 幽兰铃幼苗, 
			灵植Type.空谷幽兰 => 空谷幽兰幼苗, 
			灵植Type.醉仙球 => 醉仙球幼苗, 
			灵植Type.醉仙菌 => 醉仙菌幼苗, 
			灵植Type.太素花 => 太素花幼苗, 
			灵植Type.灵犀铃 => 灵犀铃幼苗, 
			灵植Type.血菩提 => 血菩提幼苗, 
			灵植Type.紫晶铃 => 紫晶铃幼苗, 
			灵植Type.招财草 => 招财草幼苗, 
			灵植Type.粉霞仙 => 粉霞仙幼苗, 
			灵植Type.黄龙掌 => 黄龙掌幼苗, 
			灵植Type.玄冰魄 => 玄冰魄幼苗, 
			灵植Type.修罗花 => 修罗花幼苗, 
			灵植Type.金乌葵 => 金乌葵幼苗, 
			灵植Type.幻樱木 => 幻樱木幼苗, 
			灵植Type.白玉莲 => 白玉莲幼苗, 
			_ => null, 
		});
	}

	public static Sprite Get灵植成长Sprite(灵植Type 灵植Type)
	{
		return (Sprite)(灵植Type switch
		{
			灵植Type.紫云英 => 紫云英成长, 
			灵植Type.曜日葵 => 曜日葵成长, 
			灵植Type.幻音铃 => 幻音铃成长, 
			灵植Type.幻紫玫 => 幻紫玫成长, 
			灵植Type.九幽紫 => 九幽紫成长, 
			灵植Type.赤焰百合 => 赤焰百合成长, 
			灵植Type.碧海螺 => 碧海螺成长, 
			灵植Type.粉面佛莲 => 粉面佛莲成长, 
			灵植Type.紫幽草 => 紫幽草成长, 
			灵植Type.三生花 => 三生花成长, 
			灵植Type.向阳花 => 向阳花成长, 
			灵植Type.白玉玲 => 白玉玲成长, 
			灵植Type.赤阳花 => 赤阳花成长, 
			灵植Type.寒星兰 => 寒星兰成长, 
			灵植Type.赤霞花 => 赤霞花成长, 
			灵植Type.惊雷子 => 惊雷子成长, 
			灵植Type.幽兰铃 => 幽兰铃成长, 
			灵植Type.空谷幽兰 => 空谷幽兰成长, 
			灵植Type.醉仙球 => 醉仙球成长, 
			灵植Type.醉仙菌 => 醉仙菌成长, 
			灵植Type.太素花 => 太素花成长, 
			灵植Type.灵犀铃 => 灵犀铃成长, 
			灵植Type.血菩提 => 血菩提成长, 
			灵植Type.紫晶铃 => 紫晶铃成长, 
			灵植Type.招财草 => 招财草成长, 
			灵植Type.粉霞仙 => 粉霞仙成长, 
			灵植Type.黄龙掌 => 黄龙掌成长, 
			灵植Type.玄冰魄 => 玄冰魄成长, 
			灵植Type.修罗花 => 修罗花成长, 
			灵植Type.金乌葵 => 金乌葵成长, 
			灵植Type.幻樱木 => 幻樱木成长, 
			灵植Type.白玉莲 => 白玉莲成长, 
			_ => null, 
		});
	}

	public static Sprite Get灵植成熟Sprite(灵植Type 灵植Type)
	{
		return (Sprite)(灵植Type switch
		{
			灵植Type.紫云英 => 紫云英成熟, 
			灵植Type.曜日葵 => 曜日葵成熟, 
			灵植Type.幻音铃 => 幻音铃成熟, 
			灵植Type.幻紫玫 => 幻紫玫成熟, 
			灵植Type.九幽紫 => 九幽紫成熟, 
			灵植Type.赤焰百合 => 赤焰百合成熟, 
			灵植Type.碧海螺 => 碧海螺成熟, 
			灵植Type.粉面佛莲 => 粉面佛莲成熟, 
			灵植Type.紫幽草 => 紫幽草成熟, 
			灵植Type.三生花 => 三生花成熟, 
			灵植Type.向阳花 => 向阳花成熟, 
			灵植Type.白玉玲 => 白玉玲成熟, 
			灵植Type.赤阳花 => 赤阳花成熟, 
			灵植Type.寒星兰 => 寒星兰成熟, 
			灵植Type.赤霞花 => 赤霞花成熟, 
			灵植Type.惊雷子 => 惊雷子成熟, 
			灵植Type.幽兰铃 => 幽兰铃成熟, 
			灵植Type.空谷幽兰 => 空谷幽兰成熟, 
			灵植Type.醉仙球 => 醉仙球成熟, 
			灵植Type.醉仙菌 => 醉仙菌成熟, 
			灵植Type.太素花 => 太素花成熟, 
			灵植Type.灵犀铃 => 灵犀铃成熟, 
			灵植Type.血菩提 => 血菩提成熟, 
			灵植Type.紫晶铃 => 紫晶铃成熟, 
			灵植Type.招财草 => 招财草成熟, 
			灵植Type.粉霞仙 => 粉霞仙成熟, 
			灵植Type.黄龙掌 => 黄龙掌成熟, 
			灵植Type.玄冰魄 => 玄冰魄成熟, 
			灵植Type.修罗花 => 修罗花成熟, 
			灵植Type.金乌葵 => 金乌葵成熟, 
			灵植Type.幻樱木 => 幻樱木成熟, 
			灵植Type.白玉莲 => 白玉莲成熟, 
			_ => null, 
		});
	}

	public static Sprite Get灵植变异Sprite(灵植Type 灵植Type)
	{
		return (Sprite)(灵植Type switch
		{
			灵植Type.紫云英 => 紫云英变异, 
			灵植Type.曜日葵 => 曜日葵变异, 
			灵植Type.幻音铃 => 幻音铃变异, 
			灵植Type.幻紫玫 => 幻紫玫变异, 
			灵植Type.九幽紫 => 九幽紫变异, 
			灵植Type.赤焰百合 => 赤焰百合变异, 
			灵植Type.碧海螺 => 碧海螺变异, 
			灵植Type.粉面佛莲 => 粉面佛莲变异, 
			灵植Type.紫幽草 => 紫幽草变异, 
			灵植Type.三生花 => 三生花变异, 
			灵植Type.向阳花 => 向阳花变异, 
			灵植Type.白玉玲 => 白玉玲变异, 
			灵植Type.赤阳花 => 赤阳花变异, 
			灵植Type.寒星兰 => 寒星兰变异, 
			灵植Type.赤霞花 => 赤霞花变异, 
			灵植Type.惊雷子 => 惊雷子变异, 
			灵植Type.幽兰铃 => 幽兰铃变异, 
			灵植Type.空谷幽兰 => 空谷幽兰变异, 
			灵植Type.醉仙球 => 醉仙球变异, 
			灵植Type.醉仙菌 => 醉仙菌变异, 
			灵植Type.太素花 => 太素花变异, 
			灵植Type.灵犀铃 => 灵犀铃变异, 
			灵植Type.血菩提 => 血菩提变异, 
			灵植Type.紫晶铃 => 紫晶铃变异, 
			灵植Type.招财草 => 招财草变异, 
			灵植Type.粉霞仙 => 粉霞仙变异, 
			灵植Type.黄龙掌 => 黄龙掌变异, 
			灵植Type.玄冰魄 => 玄冰魄变异, 
			灵植Type.修罗花 => 修罗花变异, 
			灵植Type.金乌葵 => 金乌葵变异, 
			灵植Type.幻樱木 => 幻樱木变异, 
			灵植Type.白玉莲 => 白玉莲变异, 
			_ => null, 
		});
	}

	public static Sprite Get灵植种子Sprite(灵植Type 灵植Type)
	{
		return (Sprite)(灵植Type switch
		{
			灵植Type.紫云英 => 紫云英种子, 
			灵植Type.曜日葵 => 曜日葵种子, 
			灵植Type.幻音铃 => 幻音铃种子, 
			灵植Type.幻紫玫 => 幻紫玫种子, 
			灵植Type.九幽紫 => 九幽紫种子, 
			灵植Type.赤焰百合 => 赤焰百合种子, 
			灵植Type.碧海螺 => 碧海螺种子, 
			灵植Type.粉面佛莲 => 粉面佛莲种子, 
			灵植Type.紫幽草 => 紫幽草种子, 
			灵植Type.三生花 => 三生花种子, 
			灵植Type.向阳花 => 向阳花种子, 
			灵植Type.白玉玲 => 白玉玲种子, 
			灵植Type.赤阳花 => 赤阳花种子, 
			灵植Type.寒星兰 => 寒星兰种子, 
			灵植Type.赤霞花 => 赤霞花种子, 
			灵植Type.惊雷子 => 惊雷子种子, 
			灵植Type.幽兰铃 => 幽兰铃种子, 
			灵植Type.空谷幽兰 => 空谷幽兰种子, 
			灵植Type.醉仙球 => 醉仙球种子, 
			灵植Type.醉仙菌 => 醉仙菌种子, 
			灵植Type.太素花 => 太素花种子, 
			灵植Type.灵犀铃 => 灵犀铃种子, 
			灵植Type.血菩提 => 血菩提种子, 
			灵植Type.紫晶铃 => 紫晶铃种子, 
			灵植Type.招财草 => 招财草种子, 
			灵植Type.粉霞仙 => 粉霞仙种子, 
			灵植Type.黄龙掌 => 黄龙掌种子, 
			灵植Type.玄冰魄 => 玄冰魄种子, 
			灵植Type.修罗花 => 修罗花种子, 
			灵植Type.金乌葵 => 金乌葵种子, 
			灵植Type.幻樱木 => 幻樱木种子, 
			灵植Type.白玉莲 => 白玉莲种子, 
			_ => null, 
		});
	}

	public static Sprite Get灵植收获Sprite(灵植Type 灵植Type)
	{
		return (Sprite)(灵植Type switch
		{
			灵植Type.紫云英 => 紫云英收获, 
			灵植Type.曜日葵 => 曜日葵收获, 
			灵植Type.幻音铃 => 幻音铃收获, 
			灵植Type.幻紫玫 => 幻紫玫收获, 
			灵植Type.九幽紫 => 九幽紫收获, 
			灵植Type.赤焰百合 => 赤焰百合收获, 
			灵植Type.碧海螺 => 碧海螺收获, 
			灵植Type.粉面佛莲 => 粉面佛莲收获, 
			灵植Type.紫幽草 => 紫幽草收获, 
			灵植Type.三生花 => 三生花收获, 
			灵植Type.向阳花 => 向阳花收获, 
			灵植Type.白玉玲 => 白玉玲收获, 
			灵植Type.赤阳花 => 赤阳花收获, 
			灵植Type.寒星兰 => 寒星兰收获, 
			灵植Type.赤霞花 => 赤霞花收获, 
			灵植Type.惊雷子 => 惊雷子收获, 
			灵植Type.幽兰铃 => 幽兰铃收获, 
			灵植Type.空谷幽兰 => 空谷幽兰收获, 
			灵植Type.醉仙球 => 醉仙球收获, 
			灵植Type.醉仙菌 => 醉仙菌收获, 
			灵植Type.太素花 => 太素花收获, 
			灵植Type.灵犀铃 => 灵犀铃收获, 
			灵植Type.血菩提 => 血菩提收获, 
			灵植Type.紫晶铃 => 紫晶铃收获, 
			灵植Type.招财草 => 招财草收获, 
			灵植Type.粉霞仙 => 粉霞仙收获, 
			灵植Type.黄龙掌 => 黄龙掌收获, 
			灵植Type.玄冰魄 => 玄冰魄收获, 
			灵植Type.修罗花 => 修罗花收获, 
			灵植Type.金乌葵 => 金乌葵收获, 
			灵植Type.幻樱木 => 幻樱木收获, 
			灵植Type.白玉莲 => 白玉莲收获, 
			_ => null, 
		});
	}

	public static Sprite Get灵植变异收获Sprite(灵植Type 灵植Type)
	{
		return (Sprite)(灵植Type switch
		{
			灵植Type.紫云英 => 紫云英变异收获, 
			灵植Type.曜日葵 => 曜日葵变异收获, 
			灵植Type.幻音铃 => 幻音铃变异收获, 
			灵植Type.幻紫玫 => 幻紫玫变异收获, 
			灵植Type.九幽紫 => 九幽紫变异收获, 
			灵植Type.赤焰百合 => 赤焰百合变异收获, 
			灵植Type.碧海螺 => 碧海螺变异收获, 
			灵植Type.粉面佛莲 => 粉面佛莲变异收获, 
			灵植Type.紫幽草 => 紫幽草变异收获, 
			灵植Type.三生花 => 三生花变异收获, 
			灵植Type.向阳花 => 向阳花变异收获, 
			灵植Type.白玉玲 => 白玉玲变异收获, 
			灵植Type.赤阳花 => 赤阳花变异收获, 
			灵植Type.寒星兰 => 寒星兰变异收获, 
			灵植Type.赤霞花 => 赤霞花变异收获, 
			灵植Type.惊雷子 => 惊雷子变异收获, 
			灵植Type.幽兰铃 => 幽兰铃变异收获, 
			灵植Type.空谷幽兰 => 空谷幽兰变异收获, 
			灵植Type.醉仙球 => 醉仙球变异收获, 
			灵植Type.醉仙菌 => 醉仙菌变异收获, 
			灵植Type.太素花 => 太素花变异收获, 
			灵植Type.灵犀铃 => 灵犀铃变异收获, 
			灵植Type.血菩提 => 血菩提变异收获, 
			灵植Type.紫晶铃 => 紫晶铃变异收获, 
			灵植Type.招财草 => 招财草变异收获, 
			灵植Type.粉霞仙 => 粉霞仙变异收获, 
			灵植Type.黄龙掌 => 黄龙掌变异收获, 
			灵植Type.玄冰魄 => 玄冰魄变异收获, 
			灵植Type.修罗花 => 修罗花变异收获, 
			灵植Type.金乌葵 => 金乌葵变异收获, 
			灵植Type.幻樱木 => 幻樱木变异收获, 
			灵植Type.白玉莲 => 白玉莲变异收获, 
			_ => null, 
		});
	}

	public static Sprite Get土地Sprite(土地Type 土地Type)
	{
		return (Sprite)(土地Type switch
		{
			土地Type.普通土地 => 土地默认, 
			土地Type.黑土地 => 黑土地, 
			土地Type.紫土地 => 紫土地, 
			土地Type.金土地 => 金土地, 
			土地Type.红土地 => 红土地, 
			_ => null, 
		});
	}

	public static Sprite Get土地亮Sprite(土地Type 土地Type)
	{
		return (Sprite)(土地Type switch
		{
			土地Type.普通土地 => 土地默认亮, 
			土地Type.黑土地 => 黑土地亮, 
			土地Type.紫土地 => 紫土地亮, 
			土地Type.金土地 => 金土地亮, 
			土地Type.红土地 => 红土地亮, 
			_ => null, 
		});
	}

	public static Sprite Get作物品质背景框(QualityType qualityType)
	{
		return (Sprite)(qualityType switch
		{
			QualityType.黄品 => 作物品质背景框白, 
			QualityType.玄品 => 作物品质背景框绿, 
			QualityType.地品 => 作物品质背景框蓝, 
			QualityType.天品 => 作物品质背景框紫, 
			QualityType.宇品 => 作物品质背景框橙, 
			QualityType.宙品 => 作物品质背景框粉, 
			QualityType.洪品 => 作物品质背景框红, 
			QualityType.荒品 => 作物品质背景框彩, 
			_ => null, 
		});
	}

	public static Sprite Get肥料Icon(肥料Type 肥料Type, QualityType QualityType)
	{
		return (Sprite)(肥料Type switch
		{
			肥料Type.提速 => QualityType switch
			{
				QualityType.黄品 => 提速肥料白, 
				QualityType.玄品 => 提速肥料绿, 
				QualityType.地品 => 提速肥料蓝, 
				QualityType.天品 => 提速肥料紫, 
				QualityType.宇品 => 提速肥料橙, 
				QualityType.宙品 => 提速肥料粉, 
				QualityType.洪品 => 提速肥料红, 
				QualityType.荒品 => 提速肥料彩, 
				_ => null, 
			}, 
			肥料Type.增产 => QualityType switch
			{
				QualityType.黄品 => 增产肥料白, 
				QualityType.玄品 => 增产肥料绿, 
				QualityType.地品 => 增产肥料蓝, 
				QualityType.天品 => 增产肥料紫, 
				QualityType.宇品 => 增产肥料橙, 
				QualityType.宙品 => 增产肥料粉, 
				QualityType.洪品 => 增产肥料红, 
				QualityType.荒品 => 增产肥料彩, 
				_ => null, 
			}, 
			肥料Type.延时 => QualityType switch
			{
				QualityType.黄品 => 延时肥料白, 
				QualityType.玄品 => 延时肥料绿, 
				QualityType.地品 => 延时肥料蓝, 
				QualityType.天品 => 延时肥料紫, 
				QualityType.宇品 => 延时肥料橙, 
				QualityType.宙品 => 延时肥料粉, 
				QualityType.洪品 => 延时肥料红, 
				QualityType.荒品 => 延时肥料彩, 
				_ => null, 
			}, 
			肥料Type.异化 => QualityType switch
			{
				QualityType.黄品 => 异化肥料白, 
				QualityType.玄品 => 异化肥料绿, 
				QualityType.地品 => 异化肥料蓝, 
				QualityType.天品 => 异化肥料紫, 
				QualityType.宇品 => 异化肥料橙, 
				QualityType.宙品 => 异化肥料粉, 
				QualityType.洪品 => 异化肥料红, 
				QualityType.荒品 => 异化肥料彩, 
				_ => null, 
			}, 
			_ => null, 
		});
	}

	public static Sprite Get灵植背包格子(QualityType type)
	{
		return (Sprite)(type switch
		{
			QualityType.黄品 => 灵植背包格子白, 
			QualityType.玄品 => 灵植背包格子绿, 
			QualityType.地品 => 灵植背包格子蓝, 
			QualityType.天品 => 灵植背包格子紫, 
			QualityType.宇品 => 灵植背包格子橙, 
			QualityType.宙品 => 灵植背包格子粉, 
			QualityType.洪品 => 灵植背包格子红, 
			QualityType.荒品 => 灵植背包格子彩, 
			_ => null, 
		});
	}

	public static void Init()
	{
		铲除 = Resources.Load<Sprite>("Sprite/灵植icon/铲除");
		灵植背包格子空 = Resources.Load<Sprite>("Sprite/灵植icon/背包格子/空");
		灵植背包格子白 = Resources.Load<Sprite>("Sprite/灵植icon/背包格子/白");
		灵植背包格子绿 = Resources.Load<Sprite>("Sprite/灵植icon/背包格子/绿");
		灵植背包格子蓝 = Resources.Load<Sprite>("Sprite/灵植icon/背包格子/蓝");
		灵植背包格子紫 = Resources.Load<Sprite>("Sprite/灵植icon/背包格子/紫");
		灵植背包格子橙 = Resources.Load<Sprite>("Sprite/灵植icon/背包格子/橙");
		灵植背包格子粉 = Resources.Load<Sprite>("Sprite/灵植icon/背包格子/粉");
		灵植背包格子红 = Resources.Load<Sprite>("Sprite/灵植icon/背包格子/红");
		灵植背包格子彩 = Resources.Load<Sprite>("Sprite/灵植icon/背包格子/彩");
		提速肥料白 = Resources.LoadAll<Sprite>("Sprite/肥料icon/提速")[0];
		提速肥料绿 = Resources.LoadAll<Sprite>("Sprite/肥料icon/提速")[1];
		提速肥料蓝 = Resources.LoadAll<Sprite>("Sprite/肥料icon/提速")[2];
		提速肥料紫 = Resources.LoadAll<Sprite>("Sprite/肥料icon/提速")[3];
		提速肥料橙 = Resources.LoadAll<Sprite>("Sprite/肥料icon/提速")[4];
		提速肥料粉 = Resources.LoadAll<Sprite>("Sprite/肥料icon/提速")[5];
		提速肥料红 = Resources.LoadAll<Sprite>("Sprite/肥料icon/提速")[6];
		提速肥料彩 = Resources.LoadAll<Sprite>("Sprite/肥料icon/提速")[7];
		增产肥料白 = Resources.LoadAll<Sprite>("Sprite/肥料icon/增产")[0];
		增产肥料绿 = Resources.LoadAll<Sprite>("Sprite/肥料icon/增产")[1];
		增产肥料蓝 = Resources.LoadAll<Sprite>("Sprite/肥料icon/增产")[2];
		增产肥料紫 = Resources.LoadAll<Sprite>("Sprite/肥料icon/增产")[3];
		增产肥料橙 = Resources.LoadAll<Sprite>("Sprite/肥料icon/增产")[4];
		增产肥料粉 = Resources.LoadAll<Sprite>("Sprite/肥料icon/增产")[5];
		增产肥料红 = Resources.LoadAll<Sprite>("Sprite/肥料icon/增产")[6];
		增产肥料彩 = Resources.LoadAll<Sprite>("Sprite/肥料icon/增产")[7];
		延时肥料白 = Resources.LoadAll<Sprite>("Sprite/肥料icon/延时")[0];
		延时肥料绿 = Resources.LoadAll<Sprite>("Sprite/肥料icon/延时")[1];
		延时肥料蓝 = Resources.LoadAll<Sprite>("Sprite/肥料icon/延时")[2];
		延时肥料紫 = Resources.LoadAll<Sprite>("Sprite/肥料icon/延时")[3];
		延时肥料橙 = Resources.LoadAll<Sprite>("Sprite/肥料icon/延时")[4];
		延时肥料粉 = Resources.LoadAll<Sprite>("Sprite/肥料icon/延时")[5];
		延时肥料红 = Resources.LoadAll<Sprite>("Sprite/肥料icon/延时")[6];
		延时肥料彩 = Resources.LoadAll<Sprite>("Sprite/肥料icon/延时")[7];
		异化肥料白 = Resources.LoadAll<Sprite>("Sprite/肥料icon/异化")[0];
		异化肥料绿 = Resources.LoadAll<Sprite>("Sprite/肥料icon/异化")[1];
		异化肥料蓝 = Resources.LoadAll<Sprite>("Sprite/肥料icon/异化")[2];
		异化肥料紫 = Resources.LoadAll<Sprite>("Sprite/肥料icon/异化")[3];
		异化肥料橙 = Resources.LoadAll<Sprite>("Sprite/肥料icon/异化")[4];
		异化肥料粉 = Resources.LoadAll<Sprite>("Sprite/肥料icon/异化")[5];
		异化肥料红 = Resources.LoadAll<Sprite>("Sprite/肥料icon/异化")[6];
		异化肥料彩 = Resources.LoadAll<Sprite>("Sprite/肥料icon/异化")[7];
		作物品质背景框白 = Resources.Load<Sprite>("Sprite/灵植icon/作物品质框/白");
		作物品质背景框绿 = Resources.Load<Sprite>("Sprite/灵植icon/作物品质框/绿");
		作物品质背景框蓝 = Resources.Load<Sprite>("Sprite/灵植icon/作物品质框/蓝");
		作物品质背景框紫 = Resources.Load<Sprite>("Sprite/灵植icon/作物品质框/紫");
		作物品质背景框橙 = Resources.Load<Sprite>("Sprite/灵植icon/作物品质框/橙");
		作物品质背景框粉 = Resources.Load<Sprite>("Sprite/灵植icon/作物品质框/粉");
		作物品质背景框红 = Resources.Load<Sprite>("Sprite/灵植icon/作物品质框/红");
		作物品质背景框彩 = Resources.Load<Sprite>("Sprite/灵植icon/作物品质框/彩");
		成熟icon = Resources.Load<Sprite>("Sprite/灵植icon/成熟");
		播种 = Resources.Load<Sprite>("Sprite/灵植icon/播种");
		土地默认 = Resources.Load<Sprite>("Sprite/灵植icon/土地默认/普通土地_默认");
		黑土地 = Resources.Load<Sprite>("Sprite/灵植icon/土地默认/黑土地_默认");
		紫土地 = Resources.Load<Sprite>("Sprite/灵植icon/土地默认/紫土地_默认");
		金土地 = Resources.Load<Sprite>("Sprite/灵植icon/土地默认/金土地_默认");
		红土地 = Resources.Load<Sprite>("Sprite/灵植icon/土地默认/红土地_默认");
		土地默认亮 = Resources.Load<Sprite>("Sprite/灵植icon/土地选中/普通土地_选中");
		黑土地亮 = Resources.Load<Sprite>("Sprite/灵植icon/土地选中/黑土地_选中");
		紫土地亮 = Resources.Load<Sprite>("Sprite/灵植icon/土地选中/紫土地_选中");
		金土地亮 = Resources.Load<Sprite>("Sprite/灵植icon/土地选中/金土地_选中");
		红土地亮 = Resources.Load<Sprite>("Sprite/灵植icon/土地选中/红土地_选中");
		土地禁用 = Resources.Load<Sprite>("Sprite/灵植icon/共用_未解锁覆盖");
		紫云英幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[0];
		紫云英成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[1];
		紫云英成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[2];
		紫云英变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[3];
		紫云英种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子1")[0];
		紫云英收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子1")[4];
		紫云英变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子1")[8];
		曜日葵幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[4];
		曜日葵成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[5];
		曜日葵成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[6];
		曜日葵变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[7];
		曜日葵种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子1")[1];
		曜日葵收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子1")[5];
		曜日葵变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子1")[9];
		幻音铃幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[8];
		幻音铃成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[9];
		幻音铃成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[10];
		幻音铃变异 = Resources.Load<Sprite>("Sprite/灵植icon/image");
		幻音铃种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子1")[2];
		幻音铃收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子1")[6];
		幻音铃变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子1")[10];
		幻紫玫幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[12];
		幻紫玫成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[13];
		幻紫玫成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[14];
		幻紫玫变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/1")[15];
		幻紫玫种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子1")[3];
		幻紫玫收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子1")[7];
		幻紫玫变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子1")[11];
		九幽紫幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[0];
		九幽紫成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[1];
		九幽紫成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[2];
		九幽紫变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[3];
		九幽紫种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子2")[0];
		九幽紫收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子2")[4];
		九幽紫变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子2")[8];
		赤焰百合幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[4];
		赤焰百合成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[5];
		赤焰百合成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[6];
		赤焰百合变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[7];
		赤焰百合种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子2")[1];
		赤焰百合收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子2")[5];
		赤焰百合变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子2")[9];
		碧海螺幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[8];
		碧海螺成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[9];
		碧海螺成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[10];
		碧海螺变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[11];
		碧海螺种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子2")[2];
		碧海螺收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子2")[6];
		碧海螺变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子2")[10];
		粉面佛莲幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[12];
		粉面佛莲成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[13];
		粉面佛莲成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[14];
		粉面佛莲变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/2")[15];
		粉面佛莲种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子2")[3];
		粉面佛莲收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子2")[7];
		粉面佛莲变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子2")[11];
		紫幽草幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/3")[8];
		紫幽草成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/3")[9];
		紫幽草成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/3")[10];
		紫幽草变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/3")[11];
		紫幽草种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子3")[2];
		紫幽草收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子3")[6];
		紫幽草变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子3")[10];
		三生花幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/3")[12];
		三生花成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/3")[13];
		三生花成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/3")[14];
		三生花变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/3")[15];
		三生花种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子3")[3];
		三生花收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子3")[7];
		三生花变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子3")[11];
		向阳花幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/4")[0];
		向阳花成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/4")[1];
		向阳花成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/4")[2];
		向阳花变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/4")[3];
		向阳花种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子4")[0];
		向阳花收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子4")[4];
		向阳花变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子4")[8];
		白玉玲幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/4")[8];
		白玉玲成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/4")[9];
		白玉玲成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/4")[10];
		白玉玲变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/4")[11];
		白玉玲种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子4")[2];
		白玉玲收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子4")[6];
		白玉玲变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子4")[10];
		赤阳花幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/4")[12];
		赤阳花成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/4")[13];
		赤阳花成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/4")[14];
		赤阳花变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/4")[15];
		赤阳花种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子4")[3];
		赤阳花收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子4")[7];
		赤阳花变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子4")[11];
		寒星兰幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[0];
		寒星兰成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[1];
		寒星兰成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[2];
		寒星兰变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[3];
		寒星兰种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子5")[0];
		寒星兰收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子5")[4];
		寒星兰变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子5")[8];
		赤霞花幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[4];
		赤霞花成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[5];
		赤霞花成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[6];
		赤霞花变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[7];
		赤霞花种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子5")[1];
		赤霞花收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子5")[5];
		赤霞花变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子5")[9];
		惊雷子幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[8];
		惊雷子成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[9];
		惊雷子成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[10];
		惊雷子变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[11];
		惊雷子种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子5")[2];
		惊雷子收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子5")[6];
		惊雷子变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子5")[10];
		幽兰铃幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[12];
		幽兰铃成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[13];
		幽兰铃成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[14];
		幽兰铃变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/5")[15];
		幽兰铃种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子5")[3];
		幽兰铃收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子5")[7];
		幽兰铃变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子5")[11];
		空谷幽兰幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[0];
		空谷幽兰成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[1];
		空谷幽兰成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[2];
		空谷幽兰变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[3];
		空谷幽兰种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子6")[0];
		空谷幽兰收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子6")[4];
		空谷幽兰变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子6")[8];
		醉仙球幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[4];
		醉仙球成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[5];
		醉仙球成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[6];
		醉仙球变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[7];
		醉仙球种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子6")[1];
		醉仙球收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子6")[5];
		醉仙球变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子6")[9];
		醉仙菌幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[8];
		醉仙菌成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[9];
		醉仙菌成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[10];
		醉仙菌变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[11];
		醉仙菌种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子6")[2];
		醉仙菌收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子6")[6];
		醉仙菌变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子6")[10];
		太素花幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[12];
		太素花成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[13];
		太素花成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[14];
		太素花变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/6")[15];
		太素花种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子6")[3];
		太素花收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子6")[7];
		太素花变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子6")[11];
		灵犀铃幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[0];
		灵犀铃成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[1];
		灵犀铃成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[2];
		灵犀铃变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[3];
		灵犀铃种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子7")[0];
		灵犀铃收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子7")[4];
		灵犀铃变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子7")[8];
		血菩提幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[4];
		血菩提成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[5];
		血菩提成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[6];
		血菩提变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[7];
		血菩提种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子7")[1];
		血菩提收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子7")[5];
		血菩提变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子7")[9];
		紫晶铃幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[8];
		紫晶铃成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[9];
		紫晶铃成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[10];
		紫晶铃变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[11];
		紫晶铃种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子7")[2];
		紫晶铃收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子7")[6];
		紫晶铃变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子7")[10];
		招财草幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[12];
		招财草成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[13];
		招财草成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[14];
		招财草变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/7")[15];
		招财草种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子7")[3];
		招财草收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子7")[7];
		招财草变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子7")[11];
		粉霞仙幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[0];
		粉霞仙成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[1];
		粉霞仙成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[2];
		粉霞仙变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[3];
		粉霞仙种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子8")[0];
		粉霞仙收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子8")[4];
		粉霞仙变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子8")[8];
		黄龙掌幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[4];
		黄龙掌成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[5];
		黄龙掌成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[6];
		黄龙掌变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[7];
		黄龙掌种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子8")[1];
		黄龙掌收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子8")[5];
		黄龙掌变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子8")[9];
		玄冰魄幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[8];
		玄冰魄成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[9];
		玄冰魄成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[10];
		玄冰魄变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[11];
		玄冰魄种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子8")[2];
		玄冰魄收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子8")[6];
		玄冰魄变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子8")[10];
		修罗花幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[12];
		修罗花成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[13];
		修罗花成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[14];
		修罗花变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/8")[15];
		修罗花种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子8")[3];
		修罗花收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子8")[7];
		修罗花变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子8")[11];
		金乌葵幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/9")[0];
		金乌葵成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/9")[1];
		金乌葵成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/9")[2];
		金乌葵变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/9")[3];
		金乌葵种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子9")[0];
		金乌葵收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子9")[4];
		金乌葵变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子9")[8];
		幻樱木幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/9")[4];
		幻樱木成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/9")[5];
		幻樱木成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/9")[6];
		幻樱木变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/9")[7];
		幻樱木种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子9")[1];
		幻樱木收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子9")[5];
		幻樱木变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子9")[9];
		白玉莲幼苗 = Resources.LoadAll<Sprite>("Sprite/灵植icon/9")[8];
		白玉莲成长 = Resources.LoadAll<Sprite>("Sprite/灵植icon/9")[9];
		白玉莲成熟 = Resources.LoadAll<Sprite>("Sprite/灵植icon/9")[10];
		白玉莲变异 = Resources.LoadAll<Sprite>("Sprite/灵植icon/9")[11];
		白玉莲种子 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子9")[2];
		白玉莲收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子9")[6];
		白玉莲变异收获 = Resources.LoadAll<Sprite>("Sprite/灵植icon/种子9")[10];
		仙子icon1 = Resources.Load<Sprite>("Sprite/仙子icon/1");
		仙子icon2 = Resources.Load<Sprite>("Sprite/仙子icon/2");
		仙子icon3 = Resources.Load<Sprite>("Sprite/仙子icon/3");
		仙子icon4 = Resources.Load<Sprite>("Sprite/仙子icon/4");
		仙子icon5 = Resources.Load<Sprite>("Sprite/仙子icon/5");
		仙子icon6 = Resources.Load<Sprite>("Sprite/仙子icon/6");
		仙子icon7 = Resources.Load<Sprite>("Sprite/仙子icon/7");
		仙子icon8 = Resources.Load<Sprite>("Sprite/仙子icon/8");
		仙子icon9 = Resources.Load<Sprite>("Sprite/仙子icon/9");
		仙子icon10 = Resources.Load<Sprite>("Sprite/仙子icon/10");
		仙子icon11 = Resources.Load<Sprite>("Sprite/仙子icon/11");
		仙子icon12 = Resources.Load<Sprite>("Sprite/仙子icon/12");
		仙子icon13 = Resources.Load<Sprite>("Sprite/仙子icon/13");
		仙子icon14 = Resources.Load<Sprite>("Sprite/仙子icon/14");
		仙子头像1 = Resources.Load<Sprite>("Sprite/仙子头像/1");
		仙子头像2 = Resources.Load<Sprite>("Sprite/仙子头像/2");
		仙子头像3 = Resources.Load<Sprite>("Sprite/仙子头像/3");
		仙子头像4 = Resources.Load<Sprite>("Sprite/仙子头像/4");
		仙子头像5 = Resources.Load<Sprite>("Sprite/仙子头像/5");
		仙子头像6 = Resources.Load<Sprite>("Sprite/仙子头像/6");
		仙子头像7 = Resources.Load<Sprite>("Sprite/仙子头像/7");
		仙子头像8 = Resources.Load<Sprite>("Sprite/仙子头像/8");
		仙子头像9 = Resources.Load<Sprite>("Sprite/仙子头像/9");
		仙子头像10 = Resources.Load<Sprite>("Sprite/仙子头像/10");
		仙子头像11 = Resources.Load<Sprite>("Sprite/仙子头像/11");
		仙子头像12 = Resources.Load<Sprite>("Sprite/仙子头像/12");
		仙子头像13 = Resources.Load<Sprite>("Sprite/仙子头像/13");
		仙子头像14 = Resources.Load<Sprite>("Sprite/仙子头像/14");
		火1 = Resources.Load<Sprite>("Sprite/灵兽icon/火1");
		火2 = Resources.Load<Sprite>("Sprite/灵兽icon/火2");
		火3 = Resources.Load<Sprite>("Sprite/灵兽icon/火3");
		火4 = Resources.Load<Sprite>("Sprite/灵兽icon/火4");
		火5 = Resources.Load<Sprite>("Sprite/灵兽icon/火5");
		火6 = Resources.Load<Sprite>("Sprite/灵兽icon/火6");
		火7 = Resources.Load<Sprite>("Sprite/灵兽icon/火7");
		火8 = Resources.Load<Sprite>("Sprite/灵兽icon/火8");
		冰1 = Resources.Load<Sprite>("Sprite/灵兽icon/冰1");
		冰2 = Resources.Load<Sprite>("Sprite/灵兽icon/冰2");
		冰3 = Resources.Load<Sprite>("Sprite/灵兽icon/冰3");
		冰4 = Resources.Load<Sprite>("Sprite/灵兽icon/冰4");
		冰5 = Resources.Load<Sprite>("Sprite/灵兽icon/冰5");
		冰6 = Resources.Load<Sprite>("Sprite/灵兽icon/冰6");
		冰7 = Resources.Load<Sprite>("Sprite/灵兽icon/冰7");
		冰8 = Resources.Load<Sprite>("Sprite/灵兽icon/冰8");
		物1 = Resources.Load<Sprite>("Sprite/灵兽icon/物1");
		物2 = Resources.Load<Sprite>("Sprite/灵兽icon/物2");
		物3 = Resources.Load<Sprite>("Sprite/灵兽icon/物3");
		物4 = Resources.Load<Sprite>("Sprite/灵兽icon/物4");
		物5 = Resources.Load<Sprite>("Sprite/灵兽icon/物5");
		物6 = Resources.Load<Sprite>("Sprite/灵兽icon/物6");
		物7 = Resources.Load<Sprite>("Sprite/灵兽icon/物7");
		物8 = Resources.Load<Sprite>("Sprite/灵兽icon/物8");
		暗1 = Resources.Load<Sprite>("Sprite/灵兽icon/暗1");
		暗2 = Resources.Load<Sprite>("Sprite/灵兽icon/暗2");
		暗3 = Resources.Load<Sprite>("Sprite/灵兽icon/暗3");
		暗4 = Resources.Load<Sprite>("Sprite/灵兽icon/暗4");
		暗5 = Resources.Load<Sprite>("Sprite/灵兽icon/暗5");
		暗6 = Resources.Load<Sprite>("Sprite/灵兽icon/暗6");
		暗7 = Resources.Load<Sprite>("Sprite/灵兽icon/暗7");
		暗8 = Resources.Load<Sprite>("Sprite/灵兽icon/暗8");
		电1 = Resources.Load<Sprite>("Sprite/灵兽icon/电1");
		电2 = Resources.Load<Sprite>("Sprite/灵兽icon/电2");
		电3 = Resources.Load<Sprite>("Sprite/灵兽icon/电3");
		电4 = Resources.Load<Sprite>("Sprite/灵兽icon/电4");
		电5 = Resources.Load<Sprite>("Sprite/灵兽icon/电5");
		电6 = Resources.Load<Sprite>("Sprite/灵兽icon/电6");
		电7 = Resources.Load<Sprite>("Sprite/灵兽icon/电7");
		电8 = Resources.Load<Sprite>("Sprite/灵兽icon/电8");
		公 = Resources.Load<Sprite>("Sprite/灵兽icon/公");
		母 = Resources.Load<Sprite>("Sprite/灵兽icon/母");
		星星 = Resources.Load<Sprite>("Sprite/星级icon/星星");
		月亮 = Resources.Load<Sprite>("Sprite/星级icon/月亮");
		太阳 = Resources.Load<Sprite>("Sprite/星级icon/太阳");
		钻石 = Resources.Load<Sprite>("Sprite/星级icon/钻石");
		轮回石 = Resources.Load<Sprite>("Sprite/DaoJu/轮回石");
		血晶 = Resources.Load<Sprite>("Sprite/DaoJu/血晶");
		材料SpriteCache[法器材料Type.铁] = Load阶数Sprites("Sprite/法器材料/铁");
		材料SpriteCache[法器材料Type.石] = Load阶数Sprites("Sprite/法器材料/石");
		材料SpriteCache[法器材料Type.羽] = Load阶数Sprites("Sprite/法器材料/羽");
		材料SpriteCache[法器材料Type.砂] = Load阶数Sprites("Sprite/法器材料/砂");
		玄铁 = Resources.Load<Sprite>("Sprite/DaoJu/玄铁");
		矿石 = Resources.Load<Sprite>("Sprite/DaoJu/矿石");
		玉髓 = Resources.Load<Sprite>("Sprite/DaoJu/玉髓");
		建筑item暗 = Resources.Load<Sprite>("Sprite/领主府/建筑item暗");
		建筑item亮 = Resources.Load<Sprite>("Sprite/领主府/建筑item亮");
		道场矿场 = Resources.Load<Sprite>("Sprite/道场/矿场");
		道场玄铁洞 = Resources.Load<Sprite>("Sprite/道场/玄铁洞");
		道场聚贤阁 = Resources.Load<Sprite>("Sprite/道场/聚贤阁");
		道场仙女阁 = Resources.Load<Sprite>("Sprite/道场/仙女阁");
		道场灵兽坊 = Resources.Load<Sprite>("Sprite/道场/灵兽坊");
		道场灵植园 = Resources.Load<Sprite>("Sprite/道场/灵植园");
		道场功德碑 = Resources.Load<Sprite>("Sprite/道场/功德碑");
		道场地脉 = Resources.Load<Sprite>("Sprite/道场/地脉");
		道场领主府 = Resources.Load<Sprite>("Sprite/道场/领主府");
		道场炼丹室 = Resources.Load<Sprite>("Sprite/道场/炼丹室");
		道场炼器室 = Resources.Load<Sprite>("Sprite/道场/炼器室");
		道场坊市 = Resources.Load<Sprite>("Sprite/道场/坊市");
		红按钮 = Resources.Load<Sprite>("Sprite/按钮/红按钮");
		黑按钮 = Resources.Load<Sprite>("Sprite/按钮/黑按钮");
		toggle亮 = Resources.Load<Sprite>("Sprite/按钮/toggle亮");
		toggle暗 = Resources.Load<Sprite>("Sprite/按钮/toggle暗");
		供奉特性标签彩 = Resources.Load<Sprite>("Sprite/领主府/供奉特性标签/标签彩");
		供奉特性标签红 = Resources.Load<Sprite>("Sprite/领主府/供奉特性标签/标签红");
		供奉特性标签粉 = Resources.Load<Sprite>("Sprite/领主府/供奉特性标签/标签粉");
		供奉特性标签橙 = Resources.Load<Sprite>("Sprite/领主府/供奉特性标签/标签橙");
		供奉特性标签紫 = Resources.Load<Sprite>("Sprite/领主府/供奉特性标签/标签紫");
		供奉特性标签蓝 = Resources.Load<Sprite>("Sprite/领主府/供奉特性标签/标签蓝");
		供奉特性标签绿 = Resources.Load<Sprite>("Sprite/领主府/供奉特性标签/标签绿");
		供奉特性标签白 = Resources.Load<Sprite>("Sprite/领主府/供奉特性标签/标签白");
		供奉品质标签彩 = Resources.Load<Sprite>("Sprite/领主府/供奉品质标签/标签彩");
		供奉品质标签红 = Resources.Load<Sprite>("Sprite/领主府/供奉品质标签/标签红");
		供奉品质标签粉 = Resources.Load<Sprite>("Sprite/领主府/供奉品质标签/标签粉");
		供奉品质标签橙 = Resources.Load<Sprite>("Sprite/领主府/供奉品质标签/标签橙");
		供奉品质标签紫 = Resources.Load<Sprite>("Sprite/领主府/供奉品质标签/标签紫");
		供奉品质标签蓝 = Resources.Load<Sprite>("Sprite/领主府/供奉品质标签/标签蓝");
		供奉品质标签绿 = Resources.Load<Sprite>("Sprite/领主府/供奉品质标签/标签绿");
		供奉品质标签白 = Resources.Load<Sprite>("Sprite/领主府/供奉品质标签/标签白");
		矿 = Resources.Load<Sprite>("Sprite/领主府/数值icon/矿");
		丹 = Resources.Load<Sprite>("Sprite/领主府/数值icon/丹");
		器 = Resources.Load<Sprite>("Sprite/领主府/数值icon/器");
		德 = Resources.Load<Sprite>("Sprite/领主府/数值icon/德");
		玉 = Resources.Load<Sprite>("Sprite/领主府/数值icon/玉");
		贤 = Resources.Load<Sprite>("Sprite/领主府/数值icon/贤");
		铁 = Resources.Load<Sprite>("Sprite/领主府/数值icon/铁");
		坊 = Resources.Load<Sprite>("Sprite/领主府/数值icon/坊");
		仙 = Resources.Load<Sprite>("Sprite/领主府/数值icon/仙");
		兽 = Resources.Load<Sprite>("Sprite/领主府/数值icon/兽");
		女供奉1 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/1");
		女供奉2 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/2");
		女供奉3 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/3");
		女供奉4 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/4");
		女供奉5 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/5");
		女供奉6 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/6");
		女供奉7 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/7");
		女供奉8 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/8");
		女供奉9 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/9");
		女供奉10 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/10");
		女供奉11 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/11");
		女供奉12 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/12");
		女供奉13 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/13");
		女供奉14 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/14");
		女供奉15 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/15");
		女供奉16 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/16");
		女供奉17 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/17");
		女供奉18 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/18");
		女供奉19 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/19");
		女供奉20 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/20");
		女供奉21 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/21");
		女供奉22 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/22");
		女供奉23 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/23");
		女供奉24 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/24");
		女供奉25 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/25");
		女供奉26 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/26");
		女供奉27 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/27");
		女供奉28 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/28");
		女供奉29 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/29");
		女供奉30 = Resources.Load<Sprite>("Sprite/RenWu/供奉/女/30");
		foreach (var kv in 符文Config.符文名Dic)
		{
			符文SpriteCache[kv.Key] = Load阶数Sprites("Sprite/符文/" + kv.Value);
		}
		编队界面英雄背景框白 = Resources.Load<Sprite>("Sprite/编队界面英雄背景框/白");
		编队界面英雄背景框绿 = Resources.Load<Sprite>("Sprite/编队界面英雄背景框/绿");
		编队界面英雄背景框蓝 = Resources.Load<Sprite>("Sprite/编队界面英雄背景框/蓝");
		编队界面英雄背景框紫 = Resources.Load<Sprite>("Sprite/编队界面英雄背景框/紫");
		编队界面英雄背景框橙 = Resources.Load<Sprite>("Sprite/编队界面英雄背景框/橙");
		编队界面英雄背景框粉 = Resources.Load<Sprite>("Sprite/编队界面英雄背景框/粉");
		编队界面英雄背景框红 = Resources.Load<Sprite>("Sprite/编队界面英雄背景框/红");
		编队界面英雄背景框彩 = Resources.Load<Sprite>("Sprite/编队界面英雄背景框/彩");
		装备背景框 = Resources.Load<Sprite>("Sprite/技能树图标/装备背景框");
		标签亮 = Resources.Load<Sprite>("Sprite/技能树图标/标签亮");
		标签暗 = Resources.Load<Sprite>("Sprite/技能树图标/标签暗");
		英雄背景框白 = Resources.Load<Sprite>("Sprite/英雄背景框/白");
		英雄背景框绿 = Resources.Load<Sprite>("Sprite/英雄背景框/绿");
		英雄背景框蓝 = Resources.Load<Sprite>("Sprite/英雄背景框/蓝");
		英雄背景框紫 = Resources.Load<Sprite>("Sprite/英雄背景框/紫");
		英雄背景框橙 = Resources.Load<Sprite>("Sprite/英雄背景框/橙");
		英雄背景框粉 = Resources.Load<Sprite>("Sprite/英雄背景框/粉");
		英雄背景框红 = Resources.Load<Sprite>("Sprite/英雄背景框/红");
		英雄背景框彩 = Resources.Load<Sprite>("Sprite/英雄背景框/彩");
		圆环暗 = Resources.Load<Sprite>("Sprite/技能树图标/圆环暗");
		圆环亮 = Resources.Load<Sprite>("Sprite/技能树图标/圆环亮");
		英雄伤害 = Resources.Load<Sprite>("Sprite/技能树图标/英雄伤害");
		技能冷却缩减 = Resources.Load<Sprite>("Sprite/技能树图标/技能冷却缩减");
		击退距离 = Resources.Load<Sprite>("Sprite/技能树图标/击退距离");
		效果范围 = Resources.Load<Sprite>("Sprite/技能树图标/效果范围");
		瑶池减速效果 = Resources.Load<Sprite>("Sprite/技能树图标/瑶池减速效果");
		瑶池持续时间 = Resources.Load<Sprite>("Sprite/技能树图标/瑶池持续时间");
		龟丞相减速 = Resources.Load<Sprite>("Sprite/技能树图标/龟丞相减速");
		妲己效果 = Resources.Load<Sprite>("Sprite/技能树图标/妲己效果");
		妲己持续时间 = Resources.Load<Sprite>("Sprite/技能树图标/妲己持续时间");
		孙悟空挥棒次数 = Resources.Load<Sprite>("Sprite/技能树图标/孙悟空挥棒次数");
		琼霄控制时长 = Resources.Load<Sprite>("Sprite/技能树图标/琼霄控制时长");
		女娲效果 = Resources.Load<Sprite>("Sprite/技能树图标/女娲效果");
		女娲持续时间 = Resources.Load<Sprite>("Sprite/技能树图标/女娲持续时间");
		元始火种个数 = Resources.Load<Sprite>("Sprite/技能树图标/元始火种个数");
		火种旋转速度 = Resources.Load<Sprite>("Sprite/技能树图标/火种旋转速度");
		元始下场时间 = Resources.Load<Sprite>("Sprite/技能树图标/元始下场时间");
		玄冰风弹道速度减少 = Resources.Load<Sprite>("Sprite/技能树图标/玄冰风弹道速度减少");
		玄冰风每秒增长速度增加 = Resources.Load<Sprite>("Sprite/技能树图标/玄冰风每秒增长速度增加");
		无极天火数量 = Resources.Load<Sprite>("Sprite/技能树图标/无极天火数量");
		混沌开天拳出拳数量增加 = Resources.Load<Sprite>("Sprite/技能树图标/混沌开天拳出拳数量增加");
		神通冷却时间 = Resources.Load<Sprite>("Sprite/技能树图标/神通冷却时间");
		神通伤害1 = Resources.Load<Sprite>("Sprite/技能树图标/神通伤害1");
		神通伤害2 = Resources.Load<Sprite>("Sprite/技能树图标/神通伤害2");
		神通能量 = Resources.Load<Sprite>("Sprite/技能树图标/神通能量");
		被辅助英雄伤害 = Resources.Load<Sprite>("Sprite/技能树图标/被辅助英雄伤害");
		被辅助英雄暴击率 = Resources.Load<Sprite>("Sprite/技能树图标/被辅助英雄暴击率");
		被辅助英雄暴击伤害 = Resources.Load<Sprite>("Sprite/技能树图标/被辅助英雄暴击伤害");
		技能伤害1 = Resources.Load<Sprite>("Sprite/技能树图标/技能伤害1");
		技能伤害2 = Resources.Load<Sprite>("Sprite/技能树图标/技能伤害2");
		射手分裂 = Resources.Load<Sprite>("Sprite/技能树图标/射手分裂");
		射手穿透 = Resources.Load<Sprite>("Sprite/技能树图标/射手穿透");
		物理伤害 = Resources.Load<Sprite>("Sprite/技能树图标/物理伤害");
		雷电伤害 = Resources.Load<Sprite>("Sprite/技能树图标/雷电伤害");
		黑暗伤害 = Resources.Load<Sprite>("Sprite/技能树图标/黑暗伤害");
		火焰伤害 = Resources.Load<Sprite>("Sprite/技能树图标/火焰伤害");
		冰霜伤害 = Resources.Load<Sprite>("Sprite/技能树图标/冰霜伤害");
		火焰灼烧伤害 = Resources.Load<Sprite>("Sprite/技能树图标/火焰灼烧伤害");
		火焰灼烧时间 = Resources.Load<Sprite>("Sprite/技能树图标/火焰灼烧时间");
		火焰灼烧最大层数 = Resources.Load<Sprite>("Sprite/技能树图标/火焰灼烧最大层数");
		冰减速 = Resources.Load<Sprite>("Sprite/技能树图标/冰减速");
		冰概率冰冻 = Resources.Load<Sprite>("Sprite/技能树图标/冰概率冰冻");
		冰冻时间 = Resources.Load<Sprite>("Sprite/技能树图标/冰冻时间");
		冰冻增伤 = Resources.Load<Sprite>("Sprite/技能树图标/冰冻增伤");
		易电状态概率 = Resources.Load<Sprite>("Sprite/技能树图标/易电状态概率");
		易电状态时间 = Resources.Load<Sprite>("Sprite/技能树图标/易电状态时间");
		易电状态伤害 = Resources.Load<Sprite>("Sprite/技能树图标/易电状态伤害");
		黑暗印记储存伤害 = Resources.Load<Sprite>("Sprite/技能树图标/黑暗印记储存伤害");
		黑暗印记减少引爆层数 = Resources.Load<Sprite>("Sprite/技能树图标/黑暗印记减少引爆层数");
		黑暗印记增加引爆层数 = Resources.Load<Sprite>("Sprite/技能树图标/黑暗印记增加引爆层数");
		物理碎甲怪物百分比 = Resources.Load<Sprite>("Sprite/技能树图标/物理碎甲怪物百分比");
		物理碎甲领主攻击百分比 = Resources.Load<Sprite>("Sprite/技能树图标/物理碎甲领主攻击百分比");
		物理无抗性加伤害 = Resources.Load<Sprite>("Sprite/技能树图标/物理无抗性加伤害");
		增加所有英雄伤害 = Resources.Load<Sprite>("Sprite/技能树图标/增加所有英雄伤害");
		寻宝速度 = Resources.Load<Sprite>("Sprite/技能树图标/寻宝速度");
		概率紫变橙 = Resources.Load<Sprite>("Sprite/技能树图标/概率紫变橙");
		概率橙变粉 = Resources.Load<Sprite>("Sprite/技能树图标/概率橙变粉");
		概率粉变红 = Resources.Load<Sprite>("Sprite/技能树图标/概率粉变红");
		概率红变彩 = Resources.Load<Sprite>("Sprite/技能树图标/概率红变彩");
		概率提升数量 = Resources.Load<Sprite>("Sprite/技能树图标/概率提升数量");
		暴击率 = Resources.Load<Sprite>("Sprite/技能树图标/暴击率");
		暴击伤害 = Resources.Load<Sprite>("Sprite/技能树图标/暴击伤害");
		普通怪增伤 = Resources.Load<Sprite>("Sprite/技能树图标/普通怪增伤");
		精英怪增伤 = Resources.Load<Sprite>("Sprite/技能树图标/精英怪增伤");
		首领怪增伤 = Resources.Load<Sprite>("Sprite/技能树图标/首领怪增伤");
		石敢当锤子速度 = Resources.Load<Sprite>("Sprite/技能树图标/石敢当锤子速度");
		被辅助英雄普通怪伤害 = Resources.Load<Sprite>("Sprite/技能树图标/被辅助英雄普通怪伤害");
		被辅助英雄精英怪伤害 = Resources.Load<Sprite>("Sprite/技能树图标/被辅助英雄精英怪伤害");
		被辅助英雄首领怪伤害 = Resources.Load<Sprite>("Sprite/技能树图标/被辅助英雄首领怪伤害");
		被辅助元素伤害 = Resources.Load<Sprite>("Sprite/技能树图标/被辅助元素伤害");
		哪吒神通数量 = Resources.Load<Sprite>("Sprite/技能树图标/哪吒神通数量");
		碧霄神通数量 = Resources.Load<Sprite>("Sprite/技能树图标/碧霄神通数量");
		羲和神通数量 = Resources.Load<Sprite>("Sprite/技能树图标/羲和神通数量");
		被辅助英雄技能伤害 = Resources.Load<Sprite>("Sprite/技能树图标/被辅助英雄技能伤害");
		女娲神通效果 = Resources.Load<Sprite>("Sprite/技能树图标/女娲神通效果");
		丹童平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/丹童");
		土地平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/土地");
		河伯平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/河伯");
		瑶池仙女平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/瑶池仙女");
		石敢当平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/石敢当");
		玄女平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/玄女");
		龟丞相平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/龟丞相");
		太白金星平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/太白金星");
		多闻天王平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/多闻天王");
		广目天王平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/广木天王");
		雷震子平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/雷震子");
		月老平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/月老");
		嫦娥平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/嫦娥");
		杨戬平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/杨戬");
		妲己平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/妲己");
		牛魔王平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/牛魔王");
		哪吒平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/哪吒");
		孙悟空平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/孙悟空");
		碧霄平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/碧霄");
		琼霄平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/琼霄");
		羲和平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/羲和");
		常羲平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/常羲");
		后羿平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/后羿");
		云霄平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/云霄");
		女娲平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/女娲");
		老子平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/老子");
		通天平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/通天");
		元始平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/元始");
		鸿钧平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/鸿钧");
		盘古平台 = Resources.Load<Sprite>("Sprite/RenWu/平台/盘古");
		丹童头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/丹童");
		土地头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/土地");
		河伯头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/河伯");
		瑶池仙女头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/瑶池仙女");
		石敢当头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/石敢当");
		玄女头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/玄女");
		龟丞相头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/龟丞相");
		太白金星头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/太白金星");
		多闻天王头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/多闻天王");
		广目天王头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/广木天王");
		雷震子头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/雷震子");
		月老头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/月老");
		嫦娥头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/嫦娥");
		杨戬头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/杨戬");
		妲己头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/妲己");
		牛魔王头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/牛魔王");
		哪吒头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/哪吒");
		孙悟空头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/孙悟空");
		碧霄头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/碧霄");
		琼霄头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/琼霄");
		羲和头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/羲和");
		常羲头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/常羲");
		后羿头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/后羿");
		云霄头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/云霄");
		女娲头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/女娲");
		老子头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/老子");
		通天头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/通天");
		元始头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/元始");
		鸿钧头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/鸿钧");
		盘古头像 = Resources.Load<Sprite>("Sprite/RenWu/头像/盘古");
		丹童神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/丹童");
		土地神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/土地");
		河伯神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/河伯");
		瑶池仙女神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/瑶池");
		石敢当神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/石敢当");
		玄女神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/玄女");
		龟丞相神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/龟丞相");
		太白金星神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/太白金星");
		多闻天王神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/多闻天王");
		广目天王神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/广目天王");
		雷震子神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/雷震子");
		月老神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/月老");
		嫦娥神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/嫦娥");
		杨戬神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/杨戬");
		妲己神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/妲己");
		牛魔王神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/牛魔王");
		哪吒神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/哪吒");
		孙悟空神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/孙悟空");
		碧霄神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/碧霄");
		琼霄神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/琼霄");
		羲和神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/羲和");
		常羲神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/常羲");
		后羿神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/后羿");
		云霄神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/云霄");
		女娲神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/女娲");
		老子神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/老子");
		通天神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/通天");
		元始神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/元始");
		鸿钧神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/鸿钧");
		盘古神通icon = Resources.Load<Sprite>("Sprite/英雄神通icon/盘古");
		Buff修炼速度白 = Resources.Load<Sprite>("Sprite/BuffIcon/修炼速度白");
		丹童神通配音 = Resources.Load<AudioClip>("音效/神通配音/丹童");
		丹童神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/丹童");
		土地神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/土地");
		河伯神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/河伯");
		瑶池仙女神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/瑶池");
		石敢当神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/石敢当");
		玄女神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/玄女");
		龟丞相神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/龟丞相");
		太白金星神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/太白金星");
		多闻天王神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/多闻天王");
		广目天王神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/广目天王");
		雷震子神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/雷震子");
		月老神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/月老");
		嫦娥神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/嫦娥");
		杨戬神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/杨戬");
		妲己神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/妲己");
		牛魔王神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/牛魔王");
		哪吒神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/哪吒");
		孙悟空神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/孙悟空");
		碧霄神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/碧霄");
		琼霄神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/琼霄");
		羲和神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/羲和");
		常羲神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/常羲");
		后羿神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/后羿");
		云霄神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/云霄");
		女娲神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/女娲");
		老子神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/老子");
		通天神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/通天");
		元始神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/元始");
		鸿钧神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/鸿钧");
		盘古神通横幅 = Resources.Load<Sprite>("Sprite/英雄神通横幅/盘古");
		Buff修炼速度白 = Resources.Load<Sprite>("Sprite/BuffIcon/修炼速度白");
		Buff修炼速度绿 = Resources.Load<Sprite>("Sprite/BuffIcon/修炼速度绿");
		Buff修炼速度蓝 = Resources.Load<Sprite>("Sprite/BuffIcon/修炼速度蓝");
		Buff修炼速度紫 = Resources.Load<Sprite>("Sprite/BuffIcon/修炼速度紫");
		Buff修炼速度橙 = Resources.Load<Sprite>("Sprite/BuffIcon/修炼速度橙");
		Buff修炼速度粉 = Resources.Load<Sprite>("Sprite/BuffIcon/修炼速度粉");
		Buff修炼速度红 = Resources.Load<Sprite>("Sprite/BuffIcon/修炼速度红");
		Buff修炼速度彩 = Resources.Load<Sprite>("Sprite/BuffIcon/修炼速度彩");
		Buff掉宝率白 = Resources.Load<Sprite>("Sprite/BuffIcon/掉宝率白");
		Buff掉宝率绿 = Resources.Load<Sprite>("Sprite/BuffIcon/掉宝率绿");
		Buff掉宝率蓝 = Resources.Load<Sprite>("Sprite/BuffIcon/掉宝率蓝");
		Buff掉宝率紫 = Resources.Load<Sprite>("Sprite/BuffIcon/掉宝率紫");
		Buff掉宝率橙 = Resources.Load<Sprite>("Sprite/BuffIcon/掉宝率橙");
		Buff掉宝率粉 = Resources.Load<Sprite>("Sprite/BuffIcon/掉宝率粉");
		Buff掉宝率红 = Resources.Load<Sprite>("Sprite/BuffIcon/掉宝率红");
		Buff掉宝率彩 = Resources.Load<Sprite>("Sprite/BuffIcon/掉宝率彩");
		加号背景框1 = Resources.Load<Sprite>("Sprite/按钮/加号背景框");
		丹方火焰伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/火元丹")[0];
		丹方火焰伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/火元丹")[1];
		丹方火焰伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/火元丹")[2];
		丹方火焰伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/火元丹")[3];
		丹方火焰伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/火元丹")[4];
		丹方火焰伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/火元丹")[5];
		丹方火焰伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/火元丹")[6];
		丹方火焰伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/火元丹")[7];
		丹方冰霜伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/霜华丹")[0];
		丹方冰霜伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/霜华丹")[1];
		丹方冰霜伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/霜华丹")[2];
		丹方冰霜伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/霜华丹")[3];
		丹方冰霜伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/霜华丹")[4];
		丹方冰霜伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/霜华丹")[5];
		丹方冰霜伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/霜华丹")[6];
		丹方冰霜伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/霜华丹")[7];
		丹方雷电伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/雷魄丹")[0];
		丹方雷电伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/雷魄丹")[1];
		丹方雷电伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/雷魄丹")[2];
		丹方雷电伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/雷魄丹")[3];
		丹方雷电伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/雷魄丹")[4];
		丹方雷电伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/雷魄丹")[5];
		丹方雷电伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/雷魄丹")[6];
		丹方雷电伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/雷魄丹")[7];
		丹方黑暗伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冥丹")[0];
		丹方黑暗伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冥丹")[1];
		丹方黑暗伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冥丹")[2];
		丹方黑暗伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冥丹")[3];
		丹方黑暗伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冥丹")[4];
		丹方黑暗伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冥丹")[5];
		丹方黑暗伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冥丹")[6];
		丹方黑暗伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冥丹")[7];
		丹方物理伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破罡丹")[0];
		丹方物理伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破罡丹")[1];
		丹方物理伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破罡丹")[2];
		丹方物理伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破罡丹")[3];
		丹方物理伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破罡丹")[4];
		丹方物理伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破罡丹")[5];
		丹方物理伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破罡丹")[6];
		丹方物理伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破罡丹")[7];
		丹方战士伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/虎力丹")[0];
		丹方战士伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/虎力丹")[1];
		丹方战士伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/虎力丹")[2];
		丹方战士伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/虎力丹")[3];
		丹方战士伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/虎力丹")[4];
		丹方战士伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/虎力丹")[5];
		丹方战士伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/虎力丹")[6];
		丹方战士伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/虎力丹")[7];
		丹方法师伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/灵蕴丹")[0];
		丹方法师伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/灵蕴丹")[1];
		丹方法师伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/灵蕴丹")[2];
		丹方法师伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/灵蕴丹")[3];
		丹方法师伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/灵蕴丹")[4];
		丹方法师伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/灵蕴丹")[5];
		丹方法师伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/灵蕴丹")[6];
		丹方法师伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/灵蕴丹")[7];
		丹方射手伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凝矢丹")[0];
		丹方射手伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凝矢丹")[1];
		丹方射手伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凝矢丹")[2];
		丹方射手伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凝矢丹")[3];
		丹方射手伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凝矢丹")[4];
		丹方射手伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凝矢丹")[5];
		丹方射手伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凝矢丹")[6];
		丹方射手伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凝矢丹")[7];
		丹方控制伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/缚灵丹")[0];
		丹方控制伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/缚灵丹")[1];
		丹方控制伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/缚灵丹")[2];
		丹方控制伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/缚灵丹")[3];
		丹方控制伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/缚灵丹")[4];
		丹方控制伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/缚灵丹")[5];
		丹方控制伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/缚灵丹")[6];
		丹方控制伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/缚灵丹")[7];
		丹方辅助伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄辅丹")[0];
		丹方辅助伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄辅丹")[1];
		丹方辅助伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄辅丹")[2];
		丹方辅助伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄辅丹")[3];
		丹方辅助伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄辅丹")[4];
		丹方辅助伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄辅丹")[5];
		丹方辅助伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄辅丹")[6];
		丹方辅助伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄辅丹")[7];
		丹方最终伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/归元丹")[0];
		丹方最终伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/归元丹")[1];
		丹方最终伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/归元丹")[2];
		丹方最终伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/归元丹")[3];
		丹方最终伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/归元丹")[4];
		丹方最终伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/归元丹")[5];
		丹方最终伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/归元丹")[6];
		丹方最终伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/归元丹")[7];
		丹方修炼速度白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/悟道丹")[0];
		丹方修炼速度绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/悟道丹")[1];
		丹方修炼速度蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/悟道丹")[2];
		丹方修炼速度紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/悟道丹")[3];
		丹方修炼速度橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/悟道丹")[4];
		丹方修炼速度粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/悟道丹")[5];
		丹方修炼速度红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/悟道丹")[6];
		丹方修炼速度彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/悟道丹")[7];
		丹方掉宝率白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/寻龙丹")[0];
		丹方掉宝率绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/寻龙丹")[1];
		丹方掉宝率蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/寻龙丹")[2];
		丹方掉宝率紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/寻龙丹")[3];
		丹方掉宝率橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/寻龙丹")[4];
		丹方掉宝率粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/寻龙丹")[5];
		丹方掉宝率红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/寻龙丹")[6];
		丹方掉宝率彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/寻龙丹")[7];
		丹方英雄暴击伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/绝杀丹")[0];
		丹方英雄暴击伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/绝杀丹")[1];
		丹方英雄暴击伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/绝杀丹")[2];
		丹方英雄暴击伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/绝杀丹")[3];
		丹方英雄暴击伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/绝杀丹")[4];
		丹方英雄暴击伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/绝杀丹")[5];
		丹方英雄暴击伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/绝杀丹")[6];
		丹方英雄暴击伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/绝杀丹")[7];
		丹方加跟脚白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/洗髓伐脉丹")[0];
		丹方加跟脚绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/洗髓伐脉丹")[1];
		丹方加跟脚蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/洗髓伐脉丹")[2];
		丹方加跟脚紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/洗髓伐脉丹")[3];
		丹方加跟脚橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/洗髓伐脉丹")[4];
		丹方加跟脚粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/洗髓伐脉丹")[5];
		丹方加跟脚红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/洗髓伐脉丹")[6];
		丹方加跟脚彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/洗髓伐脉丹")[7];
		丹方英雄火焰伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凤火丹")[0];
		丹方英雄火焰伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凤火丹")[1];
		丹方英雄火焰伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凤火丹")[2];
		丹方英雄火焰伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凤火丹")[3];
		丹方英雄火焰伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凤火丹")[4];
		丹方英雄火焰伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凤火丹")[5];
		丹方英雄火焰伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凤火丹")[6];
		丹方英雄火焰伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/凤火丹")[7];
		丹方英雄冰霜伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冰丹")[0];
		丹方英雄冰霜伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冰丹")[1];
		丹方英雄冰霜伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冰丹")[2];
		丹方英雄冰霜伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冰丹")[3];
		丹方英雄冰霜伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冰丹")[4];
		丹方英雄冰霜伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冰丹")[5];
		丹方英雄冰霜伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冰丹")[6];
		丹方英雄冰霜伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/玄冰丹")[7];
		丹方英雄雷电伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/奔雷丹")[0];
		丹方英雄雷电伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/奔雷丹")[1];
		丹方英雄雷电伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/奔雷丹")[2];
		丹方英雄雷电伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/奔雷丹")[3];
		丹方英雄雷电伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/奔雷丹")[4];
		丹方英雄雷电伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/奔雷丹")[5];
		丹方英雄雷电伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/奔雷丹")[6];
		丹方英雄雷电伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/奔雷丹")[7];
		丹方英雄黑暗伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/幽泉丹")[0];
		丹方英雄黑暗伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/幽泉丹")[1];
		丹方英雄黑暗伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/幽泉丹")[2];
		丹方英雄黑暗伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/幽泉丹")[3];
		丹方英雄黑暗伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/幽泉丹")[4];
		丹方英雄黑暗伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/幽泉丹")[5];
		丹方英雄黑暗伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/幽泉丹")[6];
		丹方英雄黑暗伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/幽泉丹")[7];
		丹方英雄物理伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/金刚丹")[0];
		丹方英雄物理伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/金刚丹")[1];
		丹方英雄物理伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/金刚丹")[2];
		丹方英雄物理伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/金刚丹")[3];
		丹方英雄物理伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/金刚丹")[4];
		丹方英雄物理伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/金刚丹")[5];
		丹方英雄物理伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/金刚丹")[6];
		丹方英雄物理伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/金刚丹")[7];
		丹方英雄战士伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/骁勇丹")[0];
		丹方英雄战士伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/骁勇丹")[1];
		丹方英雄战士伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/骁勇丹")[2];
		丹方英雄战士伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/骁勇丹")[3];
		丹方英雄战士伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/骁勇丹")[4];
		丹方英雄战士伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/骁勇丹")[5];
		丹方英雄战士伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/骁勇丹")[6];
		丹方英雄战士伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/骁勇丹")[7];
		丹方英雄法师伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/天机丹")[0];
		丹方英雄法师伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/天机丹")[1];
		丹方英雄法师伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/天机丹")[2];
		丹方英雄法师伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/天机丹")[3];
		丹方英雄法师伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/天机丹")[4];
		丹方英雄法师伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/天机丹")[5];
		丹方英雄法师伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/天机丹")[6];
		丹方英雄法师伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/天机丹")[7];
		丹方英雄射手伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破军丹")[0];
		丹方英雄射手伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破军丹")[1];
		丹方英雄射手伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破军丹")[2];
		丹方英雄射手伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破军丹")[3];
		丹方英雄射手伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破军丹")[4];
		丹方英雄射手伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破军丹")[5];
		丹方英雄射手伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破军丹")[6];
		丹方英雄射手伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/破军丹")[7];
		丹方英雄控制伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/镇魂丹")[0];
		丹方英雄控制伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/镇魂丹")[1];
		丹方英雄控制伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/镇魂丹")[2];
		丹方英雄控制伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/镇魂丹")[3];
		丹方英雄控制伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/镇魂丹")[4];
		丹方英雄控制伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/镇魂丹")[5];
		丹方英雄控制伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/镇魂丹")[6];
		丹方英雄控制伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/镇魂丹")[7];
		丹方英雄辅助伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/太初丹")[0];
		丹方英雄辅助伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/太初丹")[1];
		丹方英雄辅助伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/太初丹")[2];
		丹方英雄辅助伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/太初丹")[3];
		丹方英雄辅助伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/太初丹")[4];
		丹方英雄辅助伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/太初丹")[5];
		丹方英雄辅助伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/太初丹")[6];
		丹方英雄辅助伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/太初丹")[7];
		丹方英雄最终伤害白 = Resources.LoadAll<Sprite>("Sprite/丹方icon/混元丹")[0];
		丹方英雄最终伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹方icon/混元丹")[1];
		丹方英雄最终伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹方icon/混元丹")[2];
		丹方英雄最终伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹方icon/混元丹")[3];
		丹方英雄最终伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹方icon/混元丹")[4];
		丹方英雄最终伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹方icon/混元丹")[5];
		丹方英雄最终伤害红 = Resources.LoadAll<Sprite>("Sprite/丹方icon/混元丹")[6];
		丹方英雄最终伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹方icon/混元丹")[7];
		火焰伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/火焰伤害")[0];
		火焰伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/火焰伤害")[1];
		火焰伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/火焰伤害")[2];
		火焰伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/火焰伤害")[3];
		火焰伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/火焰伤害")[4];
		火焰伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/火焰伤害")[5];
		火焰伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/火焰伤害")[6];
		火焰伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/火焰伤害")[7];
		冰霜伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/冰霜伤害")[0];
		冰霜伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/冰霜伤害")[1];
		冰霜伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/冰霜伤害")[2];
		冰霜伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/冰霜伤害")[3];
		冰霜伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/冰霜伤害")[4];
		冰霜伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/冰霜伤害")[5];
		冰霜伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/冰霜伤害")[6];
		冰霜伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/冰霜伤害")[7];
		雷电伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/雷电伤害")[0];
		雷电伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/雷电伤害")[1];
		雷电伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/雷电伤害")[2];
		雷电伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/雷电伤害")[3];
		雷电伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/雷电伤害")[4];
		雷电伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/雷电伤害")[5];
		雷电伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/雷电伤害")[6];
		雷电伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/雷电伤害")[7];
		黑暗伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/黑暗伤害")[0];
		黑暗伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/黑暗伤害")[1];
		黑暗伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/黑暗伤害")[2];
		黑暗伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/黑暗伤害")[3];
		黑暗伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/黑暗伤害")[4];
		黑暗伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/黑暗伤害")[5];
		黑暗伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/黑暗伤害")[6];
		黑暗伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/黑暗伤害")[7];
		物理伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/物理伤害")[0];
		物理伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/物理伤害")[1];
		物理伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/物理伤害")[2];
		物理伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/物理伤害")[3];
		物理伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/物理伤害")[4];
		物理伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/物理伤害")[5];
		物理伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/物理伤害")[6];
		物理伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/物理伤害")[7];
		战士伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/战士伤害")[0];
		战士伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/战士伤害")[1];
		战士伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/战士伤害")[2];
		战士伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/战士伤害")[3];
		战士伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/战士伤害")[4];
		战士伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/战士伤害")[5];
		战士伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/战士伤害")[6];
		战士伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/战士伤害")[7];
		法师伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/法师伤害")[0];
		法师伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/法师伤害")[1];
		法师伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/法师伤害")[2];
		法师伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/法师伤害")[3];
		法师伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/法师伤害")[4];
		法师伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/法师伤害")[5];
		法师伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/法师伤害")[6];
		法师伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/法师伤害")[7];
		射手伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/射手伤害")[0];
		射手伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/射手伤害")[1];
		射手伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/射手伤害")[2];
		射手伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/射手伤害")[3];
		射手伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/射手伤害")[4];
		射手伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/射手伤害")[5];
		射手伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/射手伤害")[6];
		射手伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/射手伤害")[7];
		控制伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/控制伤害")[0];
		控制伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/控制伤害")[1];
		控制伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/控制伤害")[2];
		控制伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/控制伤害")[3];
		控制伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/控制伤害")[4];
		控制伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/控制伤害")[5];
		控制伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/控制伤害")[6];
		控制伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/控制伤害")[7];
		辅助伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/辅助伤害")[0];
		辅助伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/辅助伤害")[1];
		辅助伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/辅助伤害")[2];
		辅助伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/辅助伤害")[3];
		辅助伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/辅助伤害")[4];
		辅助伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/辅助伤害")[5];
		辅助伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/辅助伤害")[6];
		辅助伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/辅助伤害")[7];
		最终伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/最终伤害")[0];
		最终伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/最终伤害")[1];
		最终伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/最终伤害")[2];
		最终伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/最终伤害")[3];
		最终伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/最终伤害")[4];
		最终伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/最终伤害")[5];
		最终伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/最终伤害")[6];
		最终伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/最终伤害")[7];
		修炼速度白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/修炼速度")[0];
		修炼速度绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/修炼速度")[1];
		修炼速度蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/修炼速度")[2];
		修炼速度紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/修炼速度")[3];
		修炼速度橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/修炼速度")[4];
		修炼速度粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/修炼速度")[5];
		修炼速度红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/修炼速度")[6];
		修炼速度彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/修炼速度")[7];
		掉宝率白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/掉宝率")[0];
		掉宝率绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/掉宝率")[1];
		掉宝率蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/掉宝率")[2];
		掉宝率紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/掉宝率")[3];
		掉宝率橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/掉宝率")[4];
		掉宝率粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/掉宝率")[5];
		掉宝率红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/掉宝率")[6];
		掉宝率彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/掉宝率")[7];
		英雄暴击伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄暴击伤害")[0];
		英雄暴击伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄暴击伤害")[1];
		英雄暴击伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄暴击伤害")[2];
		英雄暴击伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄暴击伤害")[3];
		英雄暴击伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄暴击伤害")[4];
		英雄暴击伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄暴击伤害")[5];
		英雄暴击伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄暴击伤害")[6];
		英雄暴击伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄暴击伤害")[7];
		加跟脚白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/加跟脚")[0];
		加跟脚绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/加跟脚")[1];
		加跟脚蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/加跟脚")[2];
		加跟脚紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/加跟脚")[3];
		加跟脚橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/加跟脚")[4];
		加跟脚粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/加跟脚")[5];
		加跟脚红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/加跟脚")[6];
		加跟脚彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/加跟脚")[7];
		英雄火焰伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄火焰伤害")[0];
		英雄火焰伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄火焰伤害")[1];
		英雄火焰伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄火焰伤害")[2];
		英雄火焰伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄火焰伤害")[3];
		英雄火焰伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄火焰伤害")[4];
		英雄火焰伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄火焰伤害")[5];
		英雄火焰伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄火焰伤害")[6];
		英雄火焰伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄火焰伤害")[7];
		英雄冰霜伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄冰霜伤害")[0];
		英雄冰霜伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄冰霜伤害")[1];
		英雄冰霜伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄冰霜伤害")[2];
		英雄冰霜伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄冰霜伤害")[3];
		英雄冰霜伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄冰霜伤害")[4];
		英雄冰霜伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄冰霜伤害")[5];
		英雄冰霜伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄冰霜伤害")[6];
		英雄冰霜伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄冰霜伤害")[7];
		英雄雷电伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄雷电伤害")[0];
		英雄雷电伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄雷电伤害")[1];
		英雄雷电伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄雷电伤害")[2];
		英雄雷电伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄雷电伤害")[3];
		英雄雷电伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄雷电伤害")[4];
		英雄雷电伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄雷电伤害")[5];
		英雄雷电伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄雷电伤害")[6];
		英雄雷电伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄雷电伤害")[7];
		英雄黑暗伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄黑暗伤害")[0];
		英雄黑暗伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄黑暗伤害")[1];
		英雄黑暗伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄黑暗伤害")[2];
		英雄黑暗伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄黑暗伤害")[3];
		英雄黑暗伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄黑暗伤害")[4];
		英雄黑暗伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄黑暗伤害")[5];
		英雄黑暗伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄黑暗伤害")[6];
		英雄黑暗伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄黑暗伤害")[7];
		英雄物理伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄物理伤害")[0];
		英雄物理伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄物理伤害")[1];
		英雄物理伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄物理伤害")[2];
		英雄物理伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄物理伤害")[3];
		英雄物理伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄物理伤害")[4];
		英雄物理伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄物理伤害")[5];
		英雄物理伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄物理伤害")[6];
		英雄物理伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄物理伤害")[7];
		英雄战士伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄战士伤害")[0];
		英雄战士伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄战士伤害")[1];
		英雄战士伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄战士伤害")[2];
		英雄战士伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄战士伤害")[3];
		英雄战士伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄战士伤害")[4];
		英雄战士伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄战士伤害")[5];
		英雄战士伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄战士伤害")[6];
		英雄战士伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄战士伤害")[7];
		英雄法师伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄法师伤害")[0];
		英雄法师伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄法师伤害")[1];
		英雄法师伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄法师伤害")[2];
		英雄法师伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄法师伤害")[3];
		英雄法师伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄法师伤害")[4];
		英雄法师伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄法师伤害")[5];
		英雄法师伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄法师伤害")[6];
		英雄法师伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄法师伤害")[7];
		英雄射手伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄射手伤害")[0];
		英雄射手伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄射手伤害")[1];
		英雄射手伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄射手伤害")[2];
		英雄射手伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄射手伤害")[3];
		英雄射手伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄射手伤害")[4];
		英雄射手伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄射手伤害")[5];
		英雄射手伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄射手伤害")[6];
		英雄射手伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄射手伤害")[7];
		英雄控制伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄控制伤害")[0];
		英雄控制伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄控制伤害")[1];
		英雄控制伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄控制伤害")[2];
		英雄控制伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄控制伤害")[3];
		英雄控制伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄控制伤害")[4];
		英雄控制伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄控制伤害")[5];
		英雄控制伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄控制伤害")[6];
		英雄控制伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄控制伤害")[7];
		英雄辅助伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄辅助伤害")[0];
		英雄辅助伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄辅助伤害")[1];
		英雄辅助伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄辅助伤害")[2];
		英雄辅助伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄辅助伤害")[3];
		英雄辅助伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄辅助伤害")[4];
		英雄辅助伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄辅助伤害")[5];
		英雄辅助伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄辅助伤害")[6];
		英雄辅助伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄辅助伤害")[7];
		英雄最终伤害白 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄最终伤害")[0];
		英雄最终伤害绿 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄最终伤害")[1];
		英雄最终伤害蓝 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄最终伤害")[2];
		英雄最终伤害紫 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄最终伤害")[3];
		英雄最终伤害橙 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄最终伤害")[4];
		英雄最终伤害粉 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄最终伤害")[5];
		英雄最终伤害红 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄最终伤害")[6];
		英雄最终伤害彩 = Resources.LoadAll<Sprite>("Sprite/丹药icon/英雄最终伤害")[7];
		金银花蕊白 = Resources.LoadAll<Sprite>("Sprite/灵药icon/金银花蕊")[0];
		金银花蕊绿 = Resources.LoadAll<Sprite>("Sprite/灵药icon/金银花蕊")[1];
		金银花蕊蓝 = Resources.LoadAll<Sprite>("Sprite/灵药icon/金银花蕊")[2];
		金银花蕊紫 = Resources.LoadAll<Sprite>("Sprite/灵药icon/金银花蕊")[3];
		金银花蕊橙 = Resources.LoadAll<Sprite>("Sprite/灵药icon/金银花蕊")[4];
		金银花蕊粉 = Resources.LoadAll<Sprite>("Sprite/灵药icon/金银花蕊")[5];
		金银花蕊红 = Resources.LoadAll<Sprite>("Sprite/灵药icon/金银花蕊")[6];
		金银花蕊彩 = Resources.LoadAll<Sprite>("Sprite/灵药icon/金银花蕊")[7];
		马兜铃果白 = Resources.LoadAll<Sprite>("Sprite/灵药icon/马兜铃果")[0];
		马兜铃果绿 = Resources.LoadAll<Sprite>("Sprite/灵药icon/马兜铃果")[1];
		马兜铃果蓝 = Resources.LoadAll<Sprite>("Sprite/灵药icon/马兜铃果")[2];
		马兜铃果紫 = Resources.LoadAll<Sprite>("Sprite/灵药icon/马兜铃果")[3];
		马兜铃果橙 = Resources.LoadAll<Sprite>("Sprite/灵药icon/马兜铃果")[4];
		马兜铃果粉 = Resources.LoadAll<Sprite>("Sprite/灵药icon/马兜铃果")[5];
		马兜铃果红 = Resources.LoadAll<Sprite>("Sprite/灵药icon/马兜铃果")[6];
		马兜铃果彩 = Resources.LoadAll<Sprite>("Sprite/灵药icon/马兜铃果")[7];
		四叶参根白 = Resources.LoadAll<Sprite>("Sprite/灵药icon/四叶参根")[0];
		四叶参根绿 = Resources.LoadAll<Sprite>("Sprite/灵药icon/四叶参根")[1];
		四叶参根蓝 = Resources.LoadAll<Sprite>("Sprite/灵药icon/四叶参根")[2];
		四叶参根紫 = Resources.LoadAll<Sprite>("Sprite/灵药icon/四叶参根")[3];
		四叶参根橙 = Resources.LoadAll<Sprite>("Sprite/灵药icon/四叶参根")[4];
		四叶参根粉 = Resources.LoadAll<Sprite>("Sprite/灵药icon/四叶参根")[5];
		四叶参根红 = Resources.LoadAll<Sprite>("Sprite/灵药icon/四叶参根")[6];
		四叶参根彩 = Resources.LoadAll<Sprite>("Sprite/灵药icon/四叶参根")[7];
		千年雪莲白 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千年雪莲")[0];
		千年雪莲绿 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千年雪莲")[1];
		千年雪莲蓝 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千年雪莲")[2];
		千年雪莲紫 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千年雪莲")[3];
		千年雪莲橙 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千年雪莲")[4];
		千年雪莲粉 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千年雪莲")[5];
		千年雪莲红 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千年雪莲")[6];
		千年雪莲彩 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千年雪莲")[7];
		回春草白 = Resources.LoadAll<Sprite>("Sprite/灵药icon/回春草")[0];
		回春草绿 = Resources.LoadAll<Sprite>("Sprite/灵药icon/回春草")[1];
		回春草蓝 = Resources.LoadAll<Sprite>("Sprite/灵药icon/回春草")[2];
		回春草紫 = Resources.LoadAll<Sprite>("Sprite/灵药icon/回春草")[3];
		回春草橙 = Resources.LoadAll<Sprite>("Sprite/灵药icon/回春草")[4];
		回春草粉 = Resources.LoadAll<Sprite>("Sprite/灵药icon/回春草")[5];
		回春草红 = Resources.LoadAll<Sprite>("Sprite/灵药icon/回春草")[6];
		回春草彩 = Resources.LoadAll<Sprite>("Sprite/灵药icon/回春草")[7];
		补血花白 = Resources.LoadAll<Sprite>("Sprite/灵药icon/补血花")[0];
		补血花绿 = Resources.LoadAll<Sprite>("Sprite/灵药icon/补血花")[1];
		补血花蓝 = Resources.LoadAll<Sprite>("Sprite/灵药icon/补血花")[2];
		补血花紫 = Resources.LoadAll<Sprite>("Sprite/灵药icon/补血花")[3];
		补血花橙 = Resources.LoadAll<Sprite>("Sprite/灵药icon/补血花")[4];
		补血花粉 = Resources.LoadAll<Sprite>("Sprite/灵药icon/补血花")[5];
		补血花红 = Resources.LoadAll<Sprite>("Sprite/灵药icon/补血花")[6];
		补血花彩 = Resources.LoadAll<Sprite>("Sprite/灵药icon/补血花")[7];
		龙纹草白 = Resources.LoadAll<Sprite>("Sprite/灵药icon/龙纹草")[0];
		龙纹草绿 = Resources.LoadAll<Sprite>("Sprite/灵药icon/龙纹草")[1];
		龙纹草蓝 = Resources.LoadAll<Sprite>("Sprite/灵药icon/龙纹草")[2];
		龙纹草紫 = Resources.LoadAll<Sprite>("Sprite/灵药icon/龙纹草")[3];
		龙纹草橙 = Resources.LoadAll<Sprite>("Sprite/灵药icon/龙纹草")[4];
		龙纹草粉 = Resources.LoadAll<Sprite>("Sprite/灵药icon/龙纹草")[5];
		龙纹草红 = Resources.LoadAll<Sprite>("Sprite/灵药icon/龙纹草")[6];
		龙纹草彩 = Resources.LoadAll<Sprite>("Sprite/灵药icon/龙纹草")[7];
		九曲黄泉草白 = Resources.LoadAll<Sprite>("Sprite/灵药icon/九曲黄泉草")[0];
		九曲黄泉草绿 = Resources.LoadAll<Sprite>("Sprite/灵药icon/九曲黄泉草")[1];
		九曲黄泉草蓝 = Resources.LoadAll<Sprite>("Sprite/灵药icon/九曲黄泉草")[2];
		九曲黄泉草紫 = Resources.LoadAll<Sprite>("Sprite/灵药icon/九曲黄泉草")[3];
		九曲黄泉草橙 = Resources.LoadAll<Sprite>("Sprite/灵药icon/九曲黄泉草")[4];
		九曲黄泉草粉 = Resources.LoadAll<Sprite>("Sprite/灵药icon/九曲黄泉草")[5];
		九曲黄泉草红 = Resources.LoadAll<Sprite>("Sprite/灵药icon/九曲黄泉草")[6];
		九曲黄泉草彩 = Resources.LoadAll<Sprite>("Sprite/灵药icon/九曲黄泉草")[7];
		千幻蝶恋花白 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千幻蝶恋花")[0];
		千幻蝶恋花绿 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千幻蝶恋花")[1];
		千幻蝶恋花蓝 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千幻蝶恋花")[2];
		千幻蝶恋花紫 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千幻蝶恋花")[3];
		千幻蝶恋花橙 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千幻蝶恋花")[4];
		千幻蝶恋花粉 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千幻蝶恋花")[5];
		千幻蝶恋花红 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千幻蝶恋花")[6];
		千幻蝶恋花彩 = Resources.LoadAll<Sprite>("Sprite/灵药icon/千幻蝶恋花")[7];
		聚灵凝神叶白 = Resources.LoadAll<Sprite>("Sprite/灵药icon/聚灵凝神叶")[0];
		聚灵凝神叶绿 = Resources.LoadAll<Sprite>("Sprite/灵药icon/聚灵凝神叶")[1];
		聚灵凝神叶蓝 = Resources.LoadAll<Sprite>("Sprite/灵药icon/聚灵凝神叶")[2];
		聚灵凝神叶紫 = Resources.LoadAll<Sprite>("Sprite/灵药icon/聚灵凝神叶")[3];
		聚灵凝神叶橙 = Resources.LoadAll<Sprite>("Sprite/灵药icon/聚灵凝神叶")[4];
		聚灵凝神叶粉 = Resources.LoadAll<Sprite>("Sprite/灵药icon/聚灵凝神叶")[5];
		聚灵凝神叶红 = Resources.LoadAll<Sprite>("Sprite/灵药icon/聚灵凝神叶")[6];
		聚灵凝神叶彩 = Resources.LoadAll<Sprite>("Sprite/灵药icon/聚灵凝神叶")[7];
		最终伤害 = Resources.Load<Sprite>("Sprite/神物icon/最终伤害");
		冷却缩减 = Resources.Load<Sprite>("Sprite/神物icon/冷却缩减");
		全元素增伤 = Resources.Load<Sprite>("Sprite/神物icon/全元素增伤");
		元素人人为我 = Resources.Load<Sprite>("Sprite/神物icon/元素人人为我");
		元素我为人人 = Resources.Load<Sprite>("Sprite/神物icon/元素我为人人");
		全职业增伤 = Resources.Load<Sprite>("Sprite/神物icon/全职业增伤");
		职业人人为我 = Resources.Load<Sprite>("Sprite/神物icon/职业人人为我");
		职业我为人人 = Resources.Load<Sprite>("Sprite/神物icon/职业我为人人");
		暴击爆伤 = Resources.Load<Sprite>("Sprite/神物icon/暴击爆伤");
		二次暴击 = Resources.Load<Sprite>("Sprite/神物icon/二次暴击");
		轮回次数加伤 = Resources.Load<Sprite>("Sprite/神物icon/轮回次数加伤");
		轮回系数 = Resources.Load<Sprite>("Sprite/神物icon/轮回系数");
		时间流速加快 = Resources.Load<Sprite>("Sprite/神物icon/时间流速加快");
		练气 = Resources.Load<Sprite>("Sprite/境界/练气");
		筑基 = Resources.Load<Sprite>("Sprite/境界/筑基");
		金丹 = Resources.Load<Sprite>("Sprite/境界/金丹");
		元婴 = Resources.Load<Sprite>("Sprite/境界/元婴");
		化神 = Resources.Load<Sprite>("Sprite/境界/化神");
		合体 = Resources.Load<Sprite>("Sprite/境界/合体");
		大乘 = Resources.Load<Sprite>("Sprite/境界/大乘");
		天仙 = Resources.Load<Sprite>("Sprite/境界/天仙");
		玄仙 = Resources.Load<Sprite>("Sprite/境界/玄仙");
		金仙 = Resources.Load<Sprite>("Sprite/境界/金仙");
		太乙金仙 = Resources.Load<Sprite>("Sprite/境界/太乙金仙");
		大罗金仙 = Resources.Load<Sprite>("Sprite/境界/大罗金仙");
		准圣 = Resources.Load<Sprite>("Sprite/境界/准圣");
		圣人 = Resources.Load<Sprite>("Sprite/境界/圣人");
		天道圣人 = Resources.Load<Sprite>("Sprite/境界/天道圣人");
		大道圣人 = Resources.Load<Sprite>("Sprite/境界/大道圣人");
		混元圣人 = Resources.Load<Sprite>("Sprite/境界/混元圣人");
		法器粉尘 = Resources.Load<Sprite>("Sprite/法器/粉尘");
		仙石精华 = Resources.Load<Sprite>("Sprite/仙石/精华");
		符箓 = Resources.Load<Sprite>("Sprite/符文/符箓");
		古朴按钮亮 = Resources.Load<Sprite>("Sprite/按钮/古朴按钮亮");
		古朴按钮暗 = Resources.Load<Sprite>("Sprite/按钮/古朴按钮暗");
		孔背景框 = Resources.Load<Sprite>("Sprite/按钮/孔背景框");
		按钮黑 = Resources.LoadAll<Sprite>("Sprite/按钮/黑白按钮")[0];
		按钮白 = Resources.LoadAll<Sprite>("Sprite/按钮/黑白按钮")[1];
		仙石SpriteCache[仙石Type.赤阳石] = Load阶数Sprites("Sprite/仙石/赤阳石");
		仙石SpriteCache[仙石Type.太虚石] = Load阶数Sprites("Sprite/仙石/太虚石");
		仙石SpriteCache[仙石Type.清心玉] = Load阶数Sprites("Sprite/仙石/清心玉");
		仙石SpriteCache[仙石Type.玄冥石] = Load阶数Sprites("Sprite/仙石/玄冥石");
		仙石SpriteCache[仙石Type.玄灵晶] = Load阶数Sprites("Sprite/仙石/玄灵晶");
		仙石SpriteCache[仙石Type.天罡石] = Load阶数Sprites("Sprite/仙石/天罡石");
		法器SpriteCache[法器Type.战士衣服] = Load阶数Sprites("Sprite/法器/战士衣服");
		法器SpriteCache[法器Type.战士武器] = Load阶数Sprites("Sprite/法器/战士武器");
		法器SpriteCache[法器Type.战士头盔] = Load阶数Sprites("Sprite/法器/战士头盔");
		法器SpriteCache[法器Type.战士鞋子] = Load阶数Sprites("Sprite/法器/战士鞋子");
		法器SpriteCache[法器Type.控制衣服] = Load阶数Sprites("Sprite/法器/控制衣服");
		法器SpriteCache[法器Type.控制武器] = Load阶数Sprites("Sprite/法器/控制武器");
		法器SpriteCache[法器Type.控制头盔] = Load阶数Sprites("Sprite/法器/控制头盔");
		法器SpriteCache[法器Type.控制鞋子] = Load阶数Sprites("Sprite/法器/控制鞋子");
		法器SpriteCache[法器Type.辅助衣服] = Load阶数Sprites("Sprite/法器/辅助衣服");
		法器SpriteCache[法器Type.辅助武器] = Load阶数Sprites("Sprite/法器/辅助武器");
		法器SpriteCache[法器Type.辅助头盔] = Load阶数Sprites("Sprite/法器/辅助头盔");
		法器SpriteCache[法器Type.辅助鞋子] = Load阶数Sprites("Sprite/法器/辅助鞋子");
		法器SpriteCache[法器Type.射手衣服] = Load阶数Sprites("Sprite/法器/射手衣服");
		法器SpriteCache[法器Type.射手武器] = Load阶数Sprites("Sprite/法器/射手武器");
		法器SpriteCache[法器Type.射手头盔] = Load阶数Sprites("Sprite/法器/射手头盔");
		法器SpriteCache[法器Type.射手鞋子] = Load阶数Sprites("Sprite/法器/射手鞋子");
		法器SpriteCache[法器Type.法师衣服] = Load阶数Sprites("Sprite/法器/法师衣服");
		法器SpriteCache[法器Type.法师武器] = Load阶数Sprites("Sprite/法器/法师武器");
		法器SpriteCache[法器Type.法师头盔] = Load阶数Sprites("Sprite/法器/法师头盔");
		法器SpriteCache[法器Type.法师鞋子] = Load阶数Sprites("Sprite/法器/法师鞋子");
		青木狼 = Resources.Load<Sprite>("Sprite/洞天怪物icon/青木狼");
		铁背龟 = Resources.Load<Sprite>("Sprite/洞天怪物icon/铁背龟");
		荆棘猿 = Resources.Load<Sprite>("Sprite/洞天怪物icon/荆棘猿");
		千年树精 = Resources.Load<Sprite>("Sprite/洞天怪物icon/千年树精");
		熔岩蜥 = Resources.Load<Sprite>("Sprite/洞天怪物icon/熔岩蜥");
		火鸦 = Resources.Load<Sprite>("Sprite/洞天怪物icon/火鸦");
		炎晶巨人 = Resources.Load<Sprite>("Sprite/洞天怪物icon/炎晶巨人");
		地火蛟 = Resources.Load<Sprite>("Sprite/洞天怪物icon/地火蛟");
		怨魂蝶 = Resources.Load<Sprite>("Sprite/洞天怪物icon/怨魂蝶");
		食骨鳄 = Resources.Load<Sprite>("Sprite/洞天怪物icon/食骨鳄");
		无面鬼 = Resources.Load<Sprite>("Sprite/洞天怪物icon/无面鬼");
		九幽尸王 = Resources.Load<Sprite>("Sprite/洞天怪物icon/九幽尸王");
		罡风鹫 = Resources.Load<Sprite>("Sprite/洞天怪物icon/罡风鹫");
		裂空蝎 = Resources.Load<Sprite>("Sprite/洞天怪物icon/裂空蝎");
		虚影兽 = Resources.Load<Sprite>("Sprite/洞天怪物icon/虚影兽");
		双首海蛇 = Resources.Load<Sprite>("Sprite/洞天怪物icon/双首海蛇");
		幻鳞鱼 = Resources.Load<Sprite>("Sprite/洞天怪物icon/幻鳞鱼");
		铁钳蟹 = Resources.Load<Sprite>("Sprite/洞天怪物icon/铁钳蟹");
		万象鲸 = Resources.Load<Sprite>("Sprite/洞天怪物icon/万象鲸");
		饕餮 = Resources.Load<Sprite>("Sprite/洞天怪物icon/饕餮");
		云纹兽 = Resources.Load<Sprite>("Sprite/洞天怪物icon/云纹兽");
		星光蝶 = Resources.Load<Sprite>("Sprite/洞天怪物icon/星光蝶");
		朱雀 = Resources.Load<Sprite>("Sprite/洞天怪物icon/朱雀");
		白虎 = Resources.Load<Sprite>("Sprite/洞天怪物icon/白虎");
		仙灵鹤 = Resources.Load<Sprite>("Sprite/洞天怪物icon/仙灵鹤");
		玉兔精 = Resources.Load<Sprite>("Sprite/洞天怪物icon/玉兔精");
		朱厌 = Resources.Load<Sprite>("Sprite/洞天怪物icon/朱厌");
		应龙 = Resources.Load<Sprite>("Sprite/洞天怪物icon/应龙");
		虚空兽 = Resources.Load<Sprite>("Sprite/洞天怪物icon/虚空兽");
		混沌兽 = Resources.Load<Sprite>("Sprite/洞天怪物icon/混沌兽");
		归墟古凤 = Resources.Load<Sprite>("Sprite/洞天怪物icon/归墟古凤");
		归墟古龙 = Resources.Load<Sprite>("Sprite/洞天怪物icon/归墟古龙");
		道纹甲虫 = Resources.Load<Sprite>("Sprite/洞天怪物icon/道纹甲虫");
		混沌蝠 = Resources.Load<Sprite>("Sprite/洞天怪物icon/混沌蝠");
		梼杌 = Resources.Load<Sprite>("Sprite/洞天怪物icon/梼杌");
		霸下 = Resources.Load<Sprite>("Sprite/洞天怪物icon/霸下");
		玄黄蜉蝣 = Resources.Load<Sprite>("Sprite/洞天怪物icon/玄黄蜉蝣");
		剑齿虎 = Resources.Load<Sprite>("Sprite/洞天怪物icon/剑齿虎");
		混元兽 = Resources.Load<Sprite>("Sprite/洞天怪物icon/混元兽");
		道胎灵童 = Resources.Load<Sprite>("Sprite/洞天怪物icon/道胎灵童");
		青丘白狐 = Resources.Load<Sprite>("Sprite/洞天怪物icon/青丘白狐");
		青丘黑狐 = Resources.Load<Sprite>("Sprite/洞天怪物icon/青丘黑狐");
		白泽 = Resources.Load<Sprite>("Sprite/洞天怪物icon/白泽");
		九尾狐 = Resources.Load<Sprite>("Sprite/洞天怪物icon/九尾狐");
		远古巨兽 = Resources.Load<Sprite>("Sprite/洞天怪物icon/远古巨兽");
		法则之兽 = Resources.Load<Sprite>("Sprite/洞天怪物icon/法则之兽");
		凤凰 = Resources.Load<Sprite>("Sprite/洞天怪物icon/凤凰");
		真龙 = Resources.Load<Sprite>("Sprite/洞天怪物icon/真龙");
		远古凶兽 = Resources.Load<Sprite>("Sprite/洞天怪物icon/远古凶兽");
		远古大蛇 = Resources.Load<Sprite>("Sprite/洞天怪物icon/远古大蛇");
		穷奇 = Resources.Load<Sprite>("Sprite/洞天怪物icon/穷奇");
		麒麟 = Resources.Load<Sprite>("Sprite/洞天怪物icon/麒麟");
		先天魔神 = Resources.Load<Sprite>("Sprite/洞天怪物icon/先天魔神");
		混沌巨兽 = Resources.Load<Sprite>("Sprite/洞天怪物icon/混沌巨兽");
		劫兽 = Resources.Load<Sprite>("Sprite/洞天怪物icon/劫兽");
		混沌之眼 = Resources.Load<Sprite>("Sprite/洞天怪物icon/混沌之眼");
		归墟古兽 = Resources.Load<Sprite>("Sprite/洞天怪物icon/归墟古兽");
		时空扭曲者 = Resources.Load<Sprite>("Sprite/洞天怪物icon/时空扭曲者");
		混沌古兽 = Resources.Load<Sprite>("Sprite/洞天怪物icon/混沌古兽");
		永恒之门 = Resources.Load<Sprite>("Sprite/洞天怪物icon/永恒之门");
		石皮野猪 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/石皮野猪");
		铁羽麻雀 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/铁羽麻雀");
		裂蹄蛮牛 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/裂蹄蛮牛");
		风吼应龙 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/风吼应龙");
		棘背豪猪 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/棘背豪猪");
		赤眼乌鸦 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/赤眼乌鸦");
		碎岩巨蜥 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/碎岩巨蜥");
		雷翼飞廉 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/雷翼飞廉");
		甲壳穿山 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/甲壳穿山");
		毒牙田鼠 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/毒牙田鼠");
		震地巨蟾 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/震地巨蟾");
		冰晶玄龟 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/冰晶玄龟");
		骨刺刺猬 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/骨刺刺猬");
		火羽雉鸡 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/火羽雉鸡");
		熔岩巨蟒 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/熔岩巨蟒");
		双首炎蟒 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/双首炎蟒");
		铜鳞鲤鱼 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/铜鳞鲤鱼");
		铁爪鹰隼 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/铁爪鹰隼");
		金刚巨猿 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/金刚巨猿");
		紫电麒麟 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/紫电麒麟");
		青面狼妖 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/青面狼妖");
		赤尾狐精 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/赤尾狐精");
		三眼毒蟾 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/三眼毒蟾");
		九尾天狐 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/九尾天狐");
		黑风蛇妖 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/黑风蛇妖");
		金瞳猫妖 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/金瞳猫妖");
		四臂魔猿 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/四臂魔猿");
		七首蛟龙 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/七首蛟龙");
		碧磷蝎精 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/碧磷蝎精");
		霜白蛛妖 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/霜白蛛妖");
		六翼蜈蚣 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/六翼蜈蚣");
		八足火蛛 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/八足火蛛");
		黄沙鼠妖 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/黄沙鼠妖");
		紫电貂精 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/紫电貂精");
		双头狼王 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/双头狼王");
		金翅大鹏 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/金翅大鹏");
		赤焰蚁精 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/赤焰蚁精");
		寒冰蝶妖 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/寒冰蝶妖");
		五色毒蟾 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/五色毒蟾");
		玄冥巨蟒 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/玄冥巨蟒");
		噬骨秃鹫 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/噬骨秃鹫");
		腐肉豺狼 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/腐肉豺狼");
		血瞳巨人 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/血瞳巨人");
		三头地狱犬 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/三头地狱犬");
		丧魂幽灵 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/丧魂幽灵");
		碎骨骷髅 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/碎骨骷髅");
		尸煞尸王 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/尸煞尸王");
		六臂夜叉 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/六臂夜叉");
		怨气怨灵 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/怨气怨灵");
		诅咒木偶 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/诅咒木偶");
		嗜血蝠王 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/嗜血蝠王");
		九婴凶蛇 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/九婴凶蛇");
		毒雾瘴精 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/毒雾瘴精");
		枯木树妖 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/枯木树妖");
		熔岩巨人 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/熔岩巨人");
		赤地旱魃 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/赤地旱魃");
		暗影影魔 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/暗影影魔");
		蚀金蚁群 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/蚀金蚁群");
		暴风巨鹏 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/暴风巨鹏");
		吞天朱厌 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/吞天朱厌");
		雷霆石像 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/雷霆石像");
		寒冰雕像 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/寒冰雕像");
		烈焰守护者 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/烈焰守护者");
		混沌饕餮 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/混沌饕餮");
		黄金剑狮 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/黄金剑狮");
		月影毒狼 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/月影毒狼");
		星辰守护者 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/星辰守护者");
		太极鲲鹏 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/太极鲲鹏");
		地脉石灵 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/地脉石灵");
		天罡星傀 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/天罡星傀");
		时空撕裂者 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/时空撕裂者");
		烛龙九阴 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/烛龙九阴");
		虚无吞噬兽 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/虚无吞噬兽");
		混沌畸变体 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/混沌畸变体");
		轮回审判官 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/轮回审判官");
		魔化盘古 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/魔化盘古");
		因果裁决者 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/因果裁决者");
		终末湮灭虫 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/终末湮灭虫");
		命运编织者 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/命运编织者");
		混沌道尊 = Resources.Load<Sprite>("Sprite/遗迹怪物icon/混沌道尊");
		藤蔓猴 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/藤蔓猴");
		木灵蝶 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/木灵蝶");
		千年树妖 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/千年树妖");
		青木蛟 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/青木蛟");
		火岩虫 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/火岩虫");
		熔岩火蜥 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/熔岩火蜥");
		炎髓魔猿 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/炎髓魔猿");
		火山兽 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/火山兽");
		黑风貂 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/黑风貂");
		浮空水母 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/浮空水母");
		黑风双煞 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/黑风双煞");
		黑风老妖 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/黑风老妖");
		水形怪 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/水形怪");
		深渊鮟鱇 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/深渊鮟鱇");
		玄水毒蛟 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/玄水毒蛟");
		玄水兽 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/玄水兽");
		雷纹蛛 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/雷纹蛛");
		雷灵球 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/雷灵球");
		紫雷夔牛 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/紫雷夔牛");
		紫雷兽 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/紫雷兽");
		白骨兵 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/白骨兵");
		噬魂鸦 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/噬魂鸦");
		白骨将 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/白骨将");
		白骨兽 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/白骨兽");
		金甲傀 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/金甲傀");
		戈刃灵 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/戈刃灵");
		金戈将 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/金戈将");
		金戈兽 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/金戈兽");
		幻梦蝶 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/幻梦蝶");
		幻梦虫 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/幻梦虫");
		幻梦妖 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/幻梦妖");
		幻梦兽 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/幻梦兽");
		混沌虫 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/混沌虫");
		吞噬兽 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/吞噬兽");
		混沌魔将 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/混沌魔将");
		混沌兽王 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/混沌兽王");
		天道卫 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/天道卫");
		造化灵 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/造化灵");
		天道将 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/天道将");
		天道兽 = Resources.Load<Sprite>("Sprite/符文之地怪物icon/天道兽");
		筑基白 = Resources.Load<Sprite>("Sprite/突破灵物/筑基白");
		筑基绿 = Resources.Load<Sprite>("Sprite/突破灵物/筑基绿");
		筑基蓝 = Resources.Load<Sprite>("Sprite/突破灵物/筑基蓝");
		筑基紫 = Resources.Load<Sprite>("Sprite/突破灵物/筑基紫");
		筑基橙 = Resources.Load<Sprite>("Sprite/突破灵物/筑基橙");
		筑基粉 = Resources.Load<Sprite>("Sprite/突破灵物/筑基粉");
		筑基红 = Resources.Load<Sprite>("Sprite/突破灵物/筑基红");
		筑基彩 = Resources.Load<Sprite>("Sprite/突破灵物/筑基彩");
		练气白 = Resources.Load<Sprite>("Sprite/突破灵物/练气白");
		练气绿 = Resources.Load<Sprite>("Sprite/突破灵物/练气绿");
		练气蓝 = Resources.Load<Sprite>("Sprite/突破灵物/练气蓝");
		练气紫 = Resources.Load<Sprite>("Sprite/突破灵物/练气紫");
		练气橙 = Resources.Load<Sprite>("Sprite/突破灵物/练气橙");
		练气粉 = Resources.Load<Sprite>("Sprite/突破灵物/练气粉");
		练气红 = Resources.Load<Sprite>("Sprite/突破灵物/练气红");
		练气彩 = Resources.Load<Sprite>("Sprite/突破灵物/练气彩");
		金丹白 = Resources.Load<Sprite>("Sprite/突破灵物/金丹白");
		金丹绿 = Resources.Load<Sprite>("Sprite/突破灵物/金丹绿");
		金丹蓝 = Resources.Load<Sprite>("Sprite/突破灵物/金丹蓝");
		金丹紫 = Resources.Load<Sprite>("Sprite/突破灵物/金丹紫");
		金丹橙 = Resources.Load<Sprite>("Sprite/突破灵物/金丹橙");
		金丹粉 = Resources.Load<Sprite>("Sprite/突破灵物/金丹粉");
		金丹红 = Resources.Load<Sprite>("Sprite/突破灵物/金丹红");
		金丹彩 = Resources.Load<Sprite>("Sprite/突破灵物/金丹彩");
		元婴白 = Resources.Load<Sprite>("Sprite/突破灵物/元婴白");
		元婴绿 = Resources.Load<Sprite>("Sprite/突破灵物/元婴绿");
		元婴蓝 = Resources.Load<Sprite>("Sprite/突破灵物/元婴蓝");
		元婴紫 = Resources.Load<Sprite>("Sprite/突破灵物/元婴紫");
		元婴橙 = Resources.Load<Sprite>("Sprite/突破灵物/元婴橙");
		元婴粉 = Resources.Load<Sprite>("Sprite/突破灵物/元婴粉");
		元婴红 = Resources.Load<Sprite>("Sprite/突破灵物/元婴红");
		元婴彩 = Resources.Load<Sprite>("Sprite/突破灵物/元婴彩");
		化神白 = Resources.Load<Sprite>("Sprite/突破灵物/化神白");
		化神绿 = Resources.Load<Sprite>("Sprite/突破灵物/化神绿");
		化神蓝 = Resources.Load<Sprite>("Sprite/突破灵物/化神蓝");
		化神紫 = Resources.Load<Sprite>("Sprite/突破灵物/化神紫");
		化神橙 = Resources.Load<Sprite>("Sprite/突破灵物/化神橙");
		化神粉 = Resources.Load<Sprite>("Sprite/突破灵物/化神粉");
		化神红 = Resources.Load<Sprite>("Sprite/突破灵物/化神红");
		化神彩 = Resources.Load<Sprite>("Sprite/突破灵物/化神彩");
		合体白 = Resources.Load<Sprite>("Sprite/突破灵物/合体白");
		合体绿 = Resources.Load<Sprite>("Sprite/突破灵物/合体绿");
		合体蓝 = Resources.Load<Sprite>("Sprite/突破灵物/合体蓝");
		合体紫 = Resources.Load<Sprite>("Sprite/突破灵物/合体紫");
		合体橙 = Resources.Load<Sprite>("Sprite/突破灵物/合体橙");
		合体粉 = Resources.Load<Sprite>("Sprite/突破灵物/合体粉");
		合体红 = Resources.Load<Sprite>("Sprite/突破灵物/合体红");
		合体彩 = Resources.Load<Sprite>("Sprite/突破灵物/合体彩");
		大乘白 = Resources.Load<Sprite>("Sprite/突破灵物/大乘白");
		大乘绿 = Resources.Load<Sprite>("Sprite/突破灵物/大乘绿");
		大乘蓝 = Resources.Load<Sprite>("Sprite/突破灵物/大乘蓝");
		大乘紫 = Resources.Load<Sprite>("Sprite/突破灵物/大乘紫");
		大乘橙 = Resources.Load<Sprite>("Sprite/突破灵物/大乘橙");
		大乘粉 = Resources.Load<Sprite>("Sprite/突破灵物/大乘粉");
		大乘红 = Resources.Load<Sprite>("Sprite/突破灵物/大乘红");
		大乘彩 = Resources.Load<Sprite>("Sprite/突破灵物/大乘彩");
		天仙白 = Resources.Load<Sprite>("Sprite/突破灵物/天仙白");
		天仙绿 = Resources.Load<Sprite>("Sprite/突破灵物/天仙绿");
		天仙蓝 = Resources.Load<Sprite>("Sprite/突破灵物/天仙蓝");
		天仙紫 = Resources.Load<Sprite>("Sprite/突破灵物/天仙紫");
		天仙橙 = Resources.Load<Sprite>("Sprite/突破灵物/天仙橙");
		天仙粉 = Resources.Load<Sprite>("Sprite/突破灵物/天仙粉");
		天仙红 = Resources.Load<Sprite>("Sprite/突破灵物/天仙红");
		天仙彩 = Resources.Load<Sprite>("Sprite/突破灵物/天仙彩");
		玄仙白 = Resources.Load<Sprite>("Sprite/突破灵物/玄仙白");
		玄仙绿 = Resources.Load<Sprite>("Sprite/突破灵物/玄仙绿");
		玄仙蓝 = Resources.Load<Sprite>("Sprite/突破灵物/玄仙蓝");
		玄仙紫 = Resources.Load<Sprite>("Sprite/突破灵物/玄仙紫");
		玄仙橙 = Resources.Load<Sprite>("Sprite/突破灵物/玄仙橙");
		玄仙粉 = Resources.Load<Sprite>("Sprite/突破灵物/玄仙粉");
		玄仙红 = Resources.Load<Sprite>("Sprite/突破灵物/玄仙红");
		玄仙彩 = Resources.Load<Sprite>("Sprite/突破灵物/玄仙彩");
		金仙白 = Resources.Load<Sprite>("Sprite/突破灵物/金仙白");
		金仙绿 = Resources.Load<Sprite>("Sprite/突破灵物/金仙绿");
		金仙蓝 = Resources.Load<Sprite>("Sprite/突破灵物/金仙蓝");
		金仙紫 = Resources.Load<Sprite>("Sprite/突破灵物/金仙紫");
		金仙橙 = Resources.Load<Sprite>("Sprite/突破灵物/金仙橙");
		金仙粉 = Resources.Load<Sprite>("Sprite/突破灵物/金仙粉");
		金仙红 = Resources.Load<Sprite>("Sprite/突破灵物/金仙红");
		金仙彩 = Resources.Load<Sprite>("Sprite/突破灵物/金仙彩");
		太乙金仙白 = Resources.Load<Sprite>("Sprite/突破灵物/太乙金仙白");
		太乙金仙绿 = Resources.Load<Sprite>("Sprite/突破灵物/太乙金仙绿");
		太乙金仙蓝 = Resources.Load<Sprite>("Sprite/突破灵物/太乙金仙蓝");
		太乙金仙紫 = Resources.Load<Sprite>("Sprite/突破灵物/太乙金仙紫");
		太乙金仙橙 = Resources.Load<Sprite>("Sprite/突破灵物/太乙金仙橙");
		太乙金仙粉 = Resources.Load<Sprite>("Sprite/突破灵物/太乙金仙粉");
		太乙金仙红 = Resources.Load<Sprite>("Sprite/突破灵物/太乙金仙红");
		太乙金仙彩 = Resources.Load<Sprite>("Sprite/突破灵物/太乙金仙彩");
		大罗金仙白 = Resources.Load<Sprite>("Sprite/突破灵物/大罗金仙白");
		大罗金仙绿 = Resources.Load<Sprite>("Sprite/突破灵物/大罗金仙绿");
		大罗金仙蓝 = Resources.Load<Sprite>("Sprite/突破灵物/大罗金仙蓝");
		大罗金仙紫 = Resources.Load<Sprite>("Sprite/突破灵物/大罗金仙紫");
		大罗金仙橙 = Resources.Load<Sprite>("Sprite/突破灵物/大罗金仙橙");
		大罗金仙粉 = Resources.Load<Sprite>("Sprite/突破灵物/大罗金仙粉");
		大罗金仙红 = Resources.Load<Sprite>("Sprite/突破灵物/大罗金仙红");
		大罗金仙彩 = Resources.Load<Sprite>("Sprite/突破灵物/大罗金仙彩");
		准圣白 = Resources.Load<Sprite>("Sprite/突破灵物/准圣白");
		准圣绿 = Resources.Load<Sprite>("Sprite/突破灵物/准圣绿");
		准圣蓝 = Resources.Load<Sprite>("Sprite/突破灵物/准圣蓝");
		准圣紫 = Resources.Load<Sprite>("Sprite/突破灵物/准圣紫");
		准圣橙 = Resources.Load<Sprite>("Sprite/突破灵物/准圣橙");
		准圣粉 = Resources.Load<Sprite>("Sprite/突破灵物/准圣粉");
		准圣红 = Resources.Load<Sprite>("Sprite/突破灵物/准圣红");
		准圣彩 = Resources.Load<Sprite>("Sprite/突破灵物/准圣彩");
		圣人白 = Resources.Load<Sprite>("Sprite/突破灵物/圣人白");
		圣人绿 = Resources.Load<Sprite>("Sprite/突破灵物/圣人绿");
		圣人蓝 = Resources.Load<Sprite>("Sprite/突破灵物/圣人蓝");
		圣人紫 = Resources.Load<Sprite>("Sprite/突破灵物/圣人紫");
		圣人橙 = Resources.Load<Sprite>("Sprite/突破灵物/圣人橙");
		圣人粉 = Resources.Load<Sprite>("Sprite/突破灵物/圣人粉");
		圣人红 = Resources.Load<Sprite>("Sprite/突破灵物/圣人红");
		圣人彩 = Resources.Load<Sprite>("Sprite/突破灵物/圣人彩");
		天道圣人白 = Resources.Load<Sprite>("Sprite/突破灵物/天道圣人白");
		天道圣人绿 = Resources.Load<Sprite>("Sprite/突破灵物/天道圣人绿");
		天道圣人蓝 = Resources.Load<Sprite>("Sprite/突破灵物/天道圣人蓝");
		天道圣人紫 = Resources.Load<Sprite>("Sprite/突破灵物/天道圣人紫");
		天道圣人橙 = Resources.Load<Sprite>("Sprite/突破灵物/天道圣人橙");
		天道圣人粉 = Resources.Load<Sprite>("Sprite/突破灵物/天道圣人粉");
		天道圣人红 = Resources.Load<Sprite>("Sprite/突破灵物/天道圣人红");
		天道圣人彩 = Resources.Load<Sprite>("Sprite/突破灵物/天道圣人彩");
		大道圣人白 = Resources.Load<Sprite>("Sprite/突破灵物/大道圣人白");
		大道圣人绿 = Resources.Load<Sprite>("Sprite/突破灵物/大道圣人绿");
		大道圣人蓝 = Resources.Load<Sprite>("Sprite/突破灵物/大道圣人蓝");
		大道圣人紫 = Resources.Load<Sprite>("Sprite/突破灵物/大道圣人紫");
		大道圣人橙 = Resources.Load<Sprite>("Sprite/突破灵物/大道圣人橙");
		大道圣人粉 = Resources.Load<Sprite>("Sprite/突破灵物/大道圣人粉");
		大道圣人红 = Resources.Load<Sprite>("Sprite/突破灵物/大道圣人红");
		大道圣人彩 = Resources.Load<Sprite>("Sprite/突破灵物/大道圣人彩");
		混元圣人白 = Resources.Load<Sprite>("Sprite/突破灵物/混元圣人白");
		混元圣人绿 = Resources.Load<Sprite>("Sprite/突破灵物/混元圣人绿");
		混元圣人蓝 = Resources.Load<Sprite>("Sprite/突破灵物/混元圣人蓝");
		混元圣人紫 = Resources.Load<Sprite>("Sprite/突破灵物/混元圣人紫");
		混元圣人橙 = Resources.Load<Sprite>("Sprite/突破灵物/混元圣人橙");
		混元圣人粉 = Resources.Load<Sprite>("Sprite/突破灵物/混元圣人粉");
		混元圣人红 = Resources.Load<Sprite>("Sprite/突破灵物/混元圣人红");
		混元圣人彩 = Resources.Load<Sprite>("Sprite/突破灵物/混元圣人彩");
		功法经验 = Resources.Load<Sprite>("Sprite/DaoJu/功法经验");
		传道背景框彩 = Resources.Load<Sprite>("Sprite/传道/背景框彩");
		传道背景框橙 = Resources.Load<Sprite>("Sprite/传道/背景框橙");
		传道背景框白 = Resources.Load<Sprite>("Sprite/传道/背景框白");
		传道背景框粉 = Resources.Load<Sprite>("Sprite/传道/背景框粉");
		传道背景框紫 = Resources.Load<Sprite>("Sprite/传道/背景框紫");
		传道背景框红 = Resources.Load<Sprite>("Sprite/传道/背景框红");
		传道背景框绿 = Resources.Load<Sprite>("Sprite/传道/背景框绿");
		传道背景框蓝 = Resources.Load<Sprite>("Sprite/传道/背景框蓝");
		传道icon彩 = Resources.Load<Sprite>("Sprite/传道/icon彩");
		传道icon橙 = Resources.Load<Sprite>("Sprite/传道/icon橙");
		传道icon白 = Resources.Load<Sprite>("Sprite/传道/icon白");
		传道icon粉 = Resources.Load<Sprite>("Sprite/传道/icon粉");
		传道icon紫 = Resources.Load<Sprite>("Sprite/传道/icon紫");
		传道icon红 = Resources.Load<Sprite>("Sprite/传道/icon红");
		传道icon绿 = Resources.Load<Sprite>("Sprite/传道/icon绿");
		传道icon蓝 = Resources.Load<Sprite>("Sprite/传道/icon蓝");
		传道按钮彩 = Resources.Load<Sprite>("Sprite/传道/按钮彩");
		传道按钮橙 = Resources.Load<Sprite>("Sprite/传道/按钮橙");
		传道按钮白 = Resources.Load<Sprite>("Sprite/传道/按钮白");
		传道按钮粉 = Resources.Load<Sprite>("Sprite/传道/按钮粉");
		传道按钮紫 = Resources.Load<Sprite>("Sprite/传道/按钮紫");
		传道按钮红 = Resources.Load<Sprite>("Sprite/传道/按钮红");
		传道按钮绿 = Resources.Load<Sprite>("Sprite/传道/按钮绿");
		传道按钮蓝 = Resources.Load<Sprite>("Sprite/传道/按钮蓝");
		射手彩 = Resources.Load<Sprite>("Sprite/功法/射手彩");
		射手橙 = Resources.Load<Sprite>("Sprite/功法/射手橙");
		射手白 = Resources.Load<Sprite>("Sprite/功法/射手白");
		射手粉 = Resources.Load<Sprite>("Sprite/功法/射手粉");
		射手紫 = Resources.Load<Sprite>("Sprite/功法/射手紫");
		射手红 = Resources.Load<Sprite>("Sprite/功法/射手红");
		射手绿 = Resources.Load<Sprite>("Sprite/功法/射手绿");
		射手蓝 = Resources.Load<Sprite>("Sprite/功法/射手蓝");
		战士彩 = Resources.Load<Sprite>("Sprite/功法/战士彩");
		战士橙 = Resources.Load<Sprite>("Sprite/功法/战士橙");
		战士白 = Resources.Load<Sprite>("Sprite/功法/战士白");
		战士粉 = Resources.Load<Sprite>("Sprite/功法/战士粉");
		战士紫 = Resources.Load<Sprite>("Sprite/功法/战士紫");
		战士红 = Resources.Load<Sprite>("Sprite/功法/战士红");
		战士绿 = Resources.Load<Sprite>("Sprite/功法/战士绿");
		战士蓝 = Resources.Load<Sprite>("Sprite/功法/战士蓝");
		控制彩 = Resources.Load<Sprite>("Sprite/功法/控制彩");
		控制橙 = Resources.Load<Sprite>("Sprite/功法/控制橙");
		控制白 = Resources.Load<Sprite>("Sprite/功法/控制白");
		控制粉 = Resources.Load<Sprite>("Sprite/功法/控制粉");
		控制紫 = Resources.Load<Sprite>("Sprite/功法/控制紫");
		控制红 = Resources.Load<Sprite>("Sprite/功法/控制红");
		控制绿 = Resources.Load<Sprite>("Sprite/功法/控制绿");
		控制蓝 = Resources.Load<Sprite>("Sprite/功法/控制蓝");
		法师彩 = Resources.Load<Sprite>("Sprite/功法/法师彩");
		法师橙 = Resources.Load<Sprite>("Sprite/功法/法师橙");
		法师白 = Resources.Load<Sprite>("Sprite/功法/法师白");
		法师粉 = Resources.Load<Sprite>("Sprite/功法/法师粉");
		法师紫 = Resources.Load<Sprite>("Sprite/功法/法师紫");
		法师红 = Resources.Load<Sprite>("Sprite/功法/法师红");
		法师绿 = Resources.Load<Sprite>("Sprite/功法/法师绿");
		法师蓝 = Resources.Load<Sprite>("Sprite/功法/法师蓝");
		辅助彩 = Resources.Load<Sprite>("Sprite/功法/辅助彩");
		辅助橙 = Resources.Load<Sprite>("Sprite/功法/辅助橙");
		辅助白 = Resources.Load<Sprite>("Sprite/功法/辅助白");
		辅助粉 = Resources.Load<Sprite>("Sprite/功法/辅助粉");
		辅助紫 = Resources.Load<Sprite>("Sprite/功法/辅助紫");
		辅助红 = Resources.Load<Sprite>("Sprite/功法/辅助红");
		辅助绿 = Resources.Load<Sprite>("Sprite/功法/辅助绿");
		辅助蓝 = Resources.Load<Sprite>("Sprite/功法/辅助蓝");
		丹童 = Resources.Load<AudioClip>("音效/丹童");
		土地 = Resources.Load<AudioClip>("音效/土地");
		河伯1 = Resources.Load<AudioClip>("音效/河伯1");
		河伯2 = Resources.Load<AudioClip>("音效/河伯2");
		瑶池 = Resources.Load<AudioClip>("音效/瑶池");
		首领出现 = Resources.Load<AudioClip>("音效/首领出现");
		怪物死亡 = Resources.Load<AudioClip>("音效/怪物死亡");
		太白金星 = Resources.Load<AudioClip>("音效/太白金星");
		石敢当 = Resources.Load<AudioClip>("音效/石敢当");
		玄女 = Resources.Load<AudioClip>("音效/玄女");
		龟丞相audio = Resources.Load<AudioClip>("音效/龟丞相");
		多闻天王 = Resources.Load<AudioClip>("音效/多闻天王");
		广目天王 = Resources.Load<AudioClip>("音效/广目天王");
		雷震子 = Resources.Load<AudioClip>("音效/雷震子");
		月老 = Resources.Load<AudioClip>("音效/月老");
		嫦娥 = Resources.Load<AudioClip>("音效/嫦娥");
		杨戬 = Resources.Load<AudioClip>("音效/杨戬");
		妲己 = Resources.Load<AudioClip>("音效/妲己");
		牛魔王audio = Resources.Load<AudioClip>("音效/牛魔王");
		哪吒 = Resources.Load<AudioClip>("音效/哪吒");
		孙悟空 = Resources.Load<AudioClip>("音效/孙悟空");
		碧霄 = Resources.Load<AudioClip>("音效/碧霄");
		琼霄 = Resources.Load<AudioClip>("音效/琼霄");
		羲和 = Resources.Load<AudioClip>("音效/羲和");
		常羲 = Resources.Load<AudioClip>("音效/常羲");
		后羿 = Resources.Load<AudioClip>("音效/后羿");
		云霄 = Resources.Load<AudioClip>("音效/云霄");
		女娲 = Resources.Load<AudioClip>("音效/女娲");
		老子 = Resources.Load<AudioClip>("音效/老子");
		元始 = Resources.Load<AudioClip>("音效/元始");
		通天 = Resources.Load<AudioClip>("音效/通天");
		鸿钧audio = Resources.Load<AudioClip>("音效/鸿钧");
		盘古audio = Resources.Load<AudioClip>("音效/盘古");
		按钮进入 = Resources.Load<AudioClip>("音效/按钮进入");
		按钮点击 = Resources.Load<AudioClip>("音效/按钮点击");
		错误 = Resources.Load<AudioClip>("音效/错误");
		Toggle = Resources.Load<AudioClip>("音效/Toggle");
		招募 = Resources.Load<AudioClip>("音效/招募");
		成功 = Resources.Load<AudioClip>("音效/成功");
		问号 = Resources.Load<Sprite>("Sprite/问号");
		开始按钮亮 = Resources.Load<Sprite>("Sprite/战斗界面/开始按钮亮");
		开始按钮暗 = Resources.Load<Sprite>("Sprite/战斗界面/开始按钮暗");
		倍速按钮亮 = Resources.Load<Sprite>("Sprite/战斗界面/倍速按钮亮");
		倍速按钮暗 = Resources.Load<Sprite>("Sprite/战斗界面/倍速按钮暗");
		羁绊背景框紫 = Resources.Load<Sprite>("Sprite/羁绊图标/紫");
		羁绊背景框橙 = Resources.Load<Sprite>("Sprite/羁绊图标/橙");
		羁绊背景框粉 = Resources.Load<Sprite>("Sprite/羁绊图标/粉");
		羁绊背景框红 = Resources.Load<Sprite>("Sprite/羁绊图标/红");
		羁绊背景框彩 = Resources.Load<Sprite>("Sprite/羁绊图标/彩");
		混沌归元 = Resources.Load<Sprite>("Sprite/羁绊图标/混沌归元");
		诛仙剑阵 = Resources.Load<Sprite>("Sprite/羁绊图标/诛仙剑阵");
		开天辟地 = Resources.Load<Sprite>("Sprite/羁绊图标/开天辟地");
		圣德光辉 = Resources.Load<Sprite>("Sprite/羁绊图标/圣德光辉");
		造化乾坤 = Resources.Load<Sprite>("Sprite/羁绊图标/造化乾坤");
		菩提风火 = Resources.Load<Sprite>("Sprite/羁绊图标/菩提风火");
		天地人 = Resources.Load<Sprite>("Sprite/羁绊图标/天地人");
		山河七宝 = Resources.Load<Sprite>("Sprite/羁绊图标/山河七宝");
		弑神定海 = Resources.Load<Sprite>("Sprite/羁绊图标/弑神定海");
		翻海断岳 = Resources.Load<Sprite>("Sprite/羁绊图标/翻海断岳");
		五行飞仙斩 = Resources.Load<Sprite>("Sprite/羁绊图标/五行飞仙斩");
		照落金莲 = Resources.Load<Sprite>("Sprite/羁绊图标/照落金莲");
		紫金断岳 = Resources.Load<Sprite>("Sprite/羁绊图标/紫金断岳");
		五方照落 = Resources.Load<Sprite>("Sprite/羁绊图标/五方照落");
		加号背景框 = Resources.Load<Sprite>("Sprite/地图界面UI/加号背景框");
		城墙icon白 = Resources.Load<Sprite>("Sprite/城墙icon/白");
		城墙icon绿 = Resources.Load<Sprite>("Sprite/城墙icon/绿");
		城墙icon蓝 = Resources.Load<Sprite>("Sprite/城墙icon/蓝");
		城墙icon紫 = Resources.Load<Sprite>("Sprite/城墙icon/紫");
		城墙icon橙 = Resources.Load<Sprite>("Sprite/城墙icon/橙");
		城墙icon粉 = Resources.Load<Sprite>("Sprite/城墙icon/粉");
		城墙icon红 = Resources.Load<Sprite>("Sprite/城墙icon/红");
		城墙icon彩 = Resources.Load<Sprite>("Sprite/城墙icon/彩");
		城墙装备背景框白 = Resources.Load<Sprite>("Sprite/城墙icon/背景框白");
		城墙装备背景框绿 = Resources.Load<Sprite>("Sprite/城墙icon/背景框绿");
		城墙装备背景框蓝 = Resources.Load<Sprite>("Sprite/城墙icon/背景框蓝");
		城墙装备背景框紫 = Resources.Load<Sprite>("Sprite/城墙icon/背景框紫");
		城墙装备背景框橙 = Resources.Load<Sprite>("Sprite/城墙icon/背景框橙");
		城墙装备背景框粉 = Resources.Load<Sprite>("Sprite/城墙icon/背景框粉");
		城墙装备背景框红 = Resources.Load<Sprite>("Sprite/城墙icon/背景框红");
		城墙装备背景框彩 = Resources.Load<Sprite>("Sprite/城墙icon/背景框彩");
		不动明王阵 = Resources.Load<Sprite>("Sprite/城墙icon/不动明王阵");
		不周山柱 = Resources.Load<Sprite>("Sprite/城墙icon/不周山柱");
		不朽魂晶 = Resources.Load<Sprite>("Sprite/城墙icon/不朽魂晶");
		不死木 = Resources.Load<Sprite>("Sprite/城墙icon/不死木");
		不灭玄石 = Resources.Load<Sprite>("Sprite/城墙icon/不灭玄石");
		九曲黄河阵 = Resources.Load<Sprite>("Sprite/城墙icon/九曲黄河阵");
		初源露 = Resources.Load<Sprite>("Sprite/城墙icon/初源露");
		厚土珠 = Resources.Load<Sprite>("Sprite/城墙icon/厚土珠");
		反伤岩 = Resources.Load<Sprite>("Sprite/城墙icon/反伤岩");
		周天星斗大阵 = Resources.Load<Sprite>("Sprite/城墙icon/周天星斗大阵");
		土灵珠 = Resources.Load<Sprite>("Sprite/城墙icon/土灵珠");
		地髓晶 = Resources.Load<Sprite>("Sprite/城墙icon/地髓晶");
		大道本源 = Resources.Load<Sprite>("Sprite/城墙icon/大道本源");
		天命罗盘 = Resources.Load<Sprite>("Sprite/城墙icon/天命罗盘");
		天机石 = Resources.Load<Sprite>("Sprite/城墙icon/天机石");
		天罡石 = Resources.Load<Sprite>("Sprite/城墙icon/天罡石");
		山河阵盘 = Resources.Load<Sprite>("Sprite/城墙icon/山河阵盘");
		星辰沙 = Resources.Load<Sprite>("Sprite/城墙icon/星辰沙");
		星辰铁 = Resources.Load<Sprite>("Sprite/城墙icon/星辰铁");
		永恒之火 = Resources.Load<Sprite>("Sprite/城墙icon/永恒之火");
		混沌磐石 = Resources.Load<Sprite>("Sprite/城墙icon/混沌磐石");
		灵兽骨粉 = Resources.Load<Sprite>("Sprite/城墙icon/灵兽骨粉");
		灵石尘 = Resources.Load<Sprite>("Sprite/城墙icon/灵石尘");
		灵藤蔓 = Resources.Load<Sprite>("Sprite/城墙icon/灵藤蔓");
		玄武石 = Resources.Load<Sprite>("Sprite/城墙icon/玄武石");
		玄黄之气 = Resources.Load<Sprite>("Sprite/城墙icon/玄黄之气");
		百年桃木 = Resources.Load<Sprite>("Sprite/城墙icon/百年桃木");
		蛟龙骨 = Resources.Load<Sprite>("Sprite/城墙icon/蛟龙骨");
		血琥珀 = Resources.Load<Sprite>("Sprite/城墙icon/血琥珀");
		轮回印记 = Resources.Load<Sprite>("Sprite/城墙icon/轮回印记");
		雷击木 = Resources.Load<Sprite>("Sprite/城墙icon/雷击木");
		鸿蒙灵根 = Resources.Load<Sprite>("Sprite/城墙icon/鸿蒙灵根");
		凌霄宝殿按钮 = Resources.Load<Sprite>("Sprite/地图界面UI/按钮");
		凌霄宝殿按钮暗 = Resources.Load<Sprite>("Sprite/地图界面UI/按钮暗");
		凌霄宝殿按钮亮 = Resources.Load<Sprite>("Sprite/地图界面UI/按钮亮");
		混沌虚空格子亮 = Resources.Load<Sprite>("Sprite/地图界面UI/格子亮");
		混沌虚空格子暗 = Resources.Load<Sprite>("Sprite/地图界面UI/格子暗");
		道宝标签紫 = Resources.Load<Sprite>("Sprite/道宝标签/道宝标签紫");
		道宝标签橙 = Resources.Load<Sprite>("Sprite/道宝标签/道宝标签橙");
		道宝标签粉 = Resources.Load<Sprite>("Sprite/道宝标签/道宝标签粉");
		道宝标签红 = Resources.Load<Sprite>("Sprite/道宝标签/道宝标签红");
		道宝标签彩 = Resources.Load<Sprite>("Sprite/道宝标签/道宝标签彩");
		山河社稷图 = Resources.LoadAll<Sprite>("Sprite/道宝/天地人")[0];
		七宝妙树 = Resources.LoadAll<Sprite>("Sprite/道宝/天地人")[1];
		天书 = Resources.LoadAll<Sprite>("Sprite/道宝/天地人")[2];
		地书 = Resources.LoadAll<Sprite>("Sprite/道宝/天地人")[3];
		弑神枪 = Resources.LoadAll<Sprite>("Sprite/道宝/天地人")[4];
		冥书 = Resources.LoadAll<Sprite>("Sprite/道宝/天地人")[5];
		定海神珠 = Resources.LoadAll<Sprite>("Sprite/道宝/天地人")[6];
		河图洛书 = Resources.LoadAll<Sprite>("Sprite/道宝/天地人")[7];
		翻天印 = Resources.LoadAll<Sprite>("Sprite/道宝/翻天印")[0];
		紫金葫芦 = Resources.LoadAll<Sprite>("Sprite/道宝/翻天印")[1];
		金蛟剪 = Resources.LoadAll<Sprite>("Sprite/道宝/翻天印")[2];
		斩仙飞刀 = Resources.LoadAll<Sprite>("Sprite/道宝/翻天印")[3];
		五色神光 = Resources.LoadAll<Sprite>("Sprite/道宝/翻天印")[4];
		宝莲灯 = Resources.LoadAll<Sprite>("Sprite/道宝/翻天印")[5];
		落宝金钱 = Resources.LoadAll<Sprite>("Sprite/道宝/翻天印")[6];
		先天五方旗 = Resources.LoadAll<Sprite>("Sprite/道宝/翻天印")[7];
		混沌青莲 = Resources.LoadAll<Sprite>("Sprite/道宝/彩色")[0];
		造化玉碟 = Resources.LoadAll<Sprite>("Sprite/道宝/彩色")[1];
		混沌珠 = Resources.LoadAll<Sprite>("Sprite/道宝/彩色")[2];
		开天斧 = Resources.LoadAll<Sprite>("Sprite/道宝/彩色")[3];
		盘古幡 = Resources.LoadAll<Sprite>("Sprite/道宝/诛仙剑")[0];
		混沌钟 = Resources.LoadAll<Sprite>("Sprite/道宝/诛仙剑")[1];
		诛仙剑 = Resources.LoadAll<Sprite>("Sprite/道宝/诛仙剑")[2];
		戮仙剑 = Resources.LoadAll<Sprite>("Sprite/道宝/诛仙剑")[3];
		陷仙剑 = Resources.LoadAll<Sprite>("Sprite/道宝/诛仙剑")[4];
		绝仙剑 = Resources.LoadAll<Sprite>("Sprite/道宝/诛仙剑")[5];
		乾坤鼎 = Resources.LoadAll<Sprite>("Sprite/道宝/诛仙剑")[6];
		菩提妙树 = Resources.LoadAll<Sprite>("Sprite/道宝/诛仙剑")[7];
		玲珑塔 = Resources.LoadAll<Sprite>("Sprite/道宝/玉净瓶")[0];
		炼妖壶 = Resources.LoadAll<Sprite>("Sprite/道宝/玉净瓶")[1];
		女娲石 = Resources.LoadAll<Sprite>("Sprite/道宝/玉净瓶")[2];
		轩辕剑 = Resources.LoadAll<Sprite>("Sprite/道宝/玉净瓶")[3];
		玉净瓶 = Resources.LoadAll<Sprite>("Sprite/道宝/玉净瓶")[4];
		照妖镜 = Resources.LoadAll<Sprite>("Sprite/道宝/玉净瓶")[5];
		风火轮 = Resources.LoadAll<Sprite>("Sprite/道宝/玉净瓶")[6];
		如意金箍棒 = Resources.LoadAll<Sprite>("Sprite/道宝/玉净瓶")[7];
		按钮亮 = Resources.Load<Sprite>("Sprite/按钮亮");
		按钮暗 = Resources.Load<Sprite>("Sprite/按钮暗");
		锋锐4 = Resources.Load<Sprite>("Sprite/道纹/锋锐4");
		锋锐5 = Resources.Load<Sprite>("Sprite/道纹/锋锐5");
		锋锐6 = Resources.Load<Sprite>("Sprite/道纹/锋锐6");
		锋锐7 = Resources.Load<Sprite>("Sprite/道纹/锋锐7");
		锋锐8 = Resources.Load<Sprite>("Sprite/道纹/锋锐8");
		战意4 = Resources.Load<Sprite>("Sprite/道纹/战意4");
		战意5 = Resources.LoadAll<Sprite>("Sprite/道纹/战意56")[0];
		战意6 = Resources.LoadAll<Sprite>("Sprite/道纹/战意56")[1];
		战意7 = Resources.LoadAll<Sprite>("Sprite/道纹/战意78")[0];
		战意8 = Resources.LoadAll<Sprite>("Sprite/道纹/战意78")[1];
		咒力4 = Resources.Load<Sprite>("Sprite/道纹/咒力");
		咒力5 = Resources.LoadAll<Sprite>("Sprite/道纹/咒力5678")[0];
		咒力6 = Resources.LoadAll<Sprite>("Sprite/道纹/咒力5678")[1];
		咒力7 = Resources.LoadAll<Sprite>("Sprite/道纹/咒力5678")[2];
		咒力8 = Resources.LoadAll<Sprite>("Sprite/道纹/咒力5678")[3];
		束魂4 = Resources.Load<Sprite>("Sprite/道纹/束魂4");
		束魂5 = Resources.Load<Sprite>("Sprite/道纹/束魂5");
		束魂6 = Resources.Load<Sprite>("Sprite/道纹/束魂6");
		束魂7 = Resources.Load<Sprite>("Sprite/道纹/束魂7");
		束魂8 = Resources.Load<Sprite>("Sprite/道纹/束魂8");
		矢锋4 = Resources.Load<Sprite>("Sprite/道纹/矢锋4");
		矢锋5 = Resources.Load<Sprite>("Sprite/道纹/矢锋5");
		矢锋6 = Resources.Load<Sprite>("Sprite/道纹/矢锋6");
		矢锋7 = Resources.Load<Sprite>("Sprite/道纹/矢锋7");
		矢锋8 = Resources.Load<Sprite>("Sprite/道纹/矢锋8");
		清道4 = Resources.Load<Sprite>("Sprite/道纹/清道4");
		清道5 = Resources.Load<Sprite>("Sprite/道纹/清道5");
		清道6 = Resources.Load<Sprite>("Sprite/道纹/清道6");
		清道7 = Resources.LoadAll<Sprite>("Sprite/道纹/清道78")[0];
		清道8 = Resources.LoadAll<Sprite>("Sprite/道纹/清道78")[1];
		破军4 = Resources.Load<Sprite>("Sprite/道纹/破军4");
		破军5 = Resources.Load<Sprite>("Sprite/道纹/破军5");
		破军6 = Resources.Load<Sprite>("Sprite/道纹/破军6");
		破军7 = Resources.Load<Sprite>("Sprite/道纹/破军7");
		破军8 = Resources.Load<Sprite>("Sprite/道纹/破军8");
		暗蚀4 = Resources.Load<Sprite>("Sprite/道纹/暗蚀4");
		暗蚀5 = Resources.Load<Sprite>("Sprite/道纹/暗蚀5");
		暗蚀6 = Resources.Load<Sprite>("Sprite/道纹/暗蚀6");
		暗蚀7 = Resources.Load<Sprite>("Sprite/道纹/暗蚀7");
		暗蚀8 = Resources.Load<Sprite>("Sprite/道纹/暗蚀8");
		雷霆4 = Resources.Load<Sprite>("Sprite/道纹/雷霆4");
		雷霆5 = Resources.Load<Sprite>("Sprite/道纹/雷霆5");
		雷霆6 = Resources.Load<Sprite>("Sprite/道纹/雷霆6");
		雷霆7 = Resources.LoadAll<Sprite>("Sprite/道纹/雷霆78")[0];
		雷霆8 = Resources.LoadAll<Sprite>("Sprite/道纹/雷霆78")[1];
		焚烬4 = Resources.Load<Sprite>("Sprite/道纹/焚烬4");
		焚烬5 = Resources.Load<Sprite>("Sprite/道纹/焚烬5");
		焚烬6 = Resources.Load<Sprite>("Sprite/道纹/焚烬6");
		焚烬7 = Resources.LoadAll<Sprite>("Sprite/道纹/焚烬78")[0];
		焚烬8 = Resources.LoadAll<Sprite>("Sprite/道纹/焚烬78")[1];
		霜寒4 = Resources.Load<Sprite>("Sprite/道纹/霜寒4");
		霜寒5 = Resources.Load<Sprite>("Sprite/道纹/霜寒5");
		霜寒6 = Resources.Load<Sprite>("Sprite/道纹/霜寒6");
		霜寒7 = Resources.Load<Sprite>("Sprite/道纹/霜寒7");
		霜寒8 = Resources.Load<Sprite>("Sprite/道纹/霜寒8");
		斩首4 = Resources.Load<Sprite>("Sprite/道纹/斩首4");
		斩首5 = Resources.Load<Sprite>("Sprite/道纹/斩首5");
		斩首6 = Resources.Load<Sprite>("Sprite/道纹/斩首6");
		斩首7 = Resources.Load<Sprite>("Sprite/道纹/斩首7");
		斩首8 = Resources.Load<Sprite>("Sprite/道纹/斩首8");
		绝命4 = Resources.LoadAll<Sprite>("Sprite/道纹/定身绝命")[5];
		绝命5 = Resources.LoadAll<Sprite>("Sprite/道纹/定身绝命")[6];
		绝命6 = Resources.LoadAll<Sprite>("Sprite/道纹/定身绝命")[7];
		绝命7 = Resources.LoadAll<Sprite>("Sprite/道纹/定身绝命")[8];
		绝命8 = Resources.LoadAll<Sprite>("Sprite/道纹/定身绝命")[9];
		饮血4 = Resources.Load<Sprite>("Sprite/道纹/饮血4");
		饮血5 = Resources.Load<Sprite>("Sprite/道纹/饮血5");
		饮血6 = Resources.Load<Sprite>("Sprite/道纹/饮血6");
		饮血7 = Resources.Load<Sprite>("Sprite/道纹/饮血7");
		饮血8 = Resources.Load<Sprite>("Sprite/道纹/饮血8");
		固垒4 = Resources.Load<Sprite>("Sprite/道纹/固垒4");
		固垒5 = Resources.Load<Sprite>("Sprite/道纹/固垒5");
		固垒6 = Resources.Load<Sprite>("Sprite/道纹/固垒6");
		固垒7 = Resources.Load<Sprite>("Sprite/道纹/固垒7");
		固垒8 = Resources.Load<Sprite>("Sprite/道纹/固垒8");
		不破4 = Resources.Load<Sprite>("Sprite/道纹/不破4");
		不破5 = Resources.Load<Sprite>("Sprite/道纹/不破5");
		不破6 = Resources.Load<Sprite>("Sprite/道纹/不破6");
		不破7 = Resources.Load<Sprite>("Sprite/道纹/不破7");
		不破8 = Resources.Load<Sprite>("Sprite/道纹/不破8");
		恃强4 = Resources.Load<Sprite>("Sprite/道纹/恃强4");
		恃强5 = Resources.Load<Sprite>("Sprite/道纹/恃强5");
		恃强6 = Resources.Load<Sprite>("Sprite/道纹/恃强6");
		恃强7 = Resources.Load<Sprite>("Sprite/道纹/恃强7");
		恃强8 = Resources.Load<Sprite>("Sprite/道纹/恃强8");
		致命4 = Resources.Load<Sprite>("Sprite/道纹/致命4");
		致命5 = Resources.LoadAll<Sprite>("Sprite/道纹/致命5678")[0];
		致命6 = Resources.LoadAll<Sprite>("Sprite/道纹/致命5678")[1];
		致命7 = Resources.LoadAll<Sprite>("Sprite/道纹/致命5678")[2];
		致命8 = Resources.LoadAll<Sprite>("Sprite/道纹/致命5678")[3];
		无常4 = Resources.LoadAll<Sprite>("Sprite/道纹/无常45678")[0];
		无常5 = Resources.LoadAll<Sprite>("Sprite/道纹/无常45678")[1];
		无常6 = Resources.LoadAll<Sprite>("Sprite/道纹/无常45678")[2];
		无常7 = Resources.LoadAll<Sprite>("Sprite/道纹/无常45678")[3];
		无常8 = Resources.LoadAll<Sprite>("Sprite/道纹/无常45678")[4];
		破法4 = Resources.Load<Sprite>("Sprite/道纹/破法4");
		破法5 = Resources.Load<Sprite>("Sprite/道纹/破法5");
		破法6 = Resources.Load<Sprite>("Sprite/道纹/破法6");
		破法7 = Resources.Load<Sprite>("Sprite/道纹/破法7");
		破法8 = Resources.Load<Sprite>("Sprite/道纹/破法8");
		镇关4 = Resources.Load<Sprite>("Sprite/道纹/镇关4");
		镇关5 = Resources.Load<Sprite>("Sprite/道纹/镇关5");
		镇关6 = Resources.Load<Sprite>("Sprite/道纹/镇关6");
		镇关7 = Resources.Load<Sprite>("Sprite/道纹/镇关7");
		镇关8 = Resources.Load<Sprite>("Sprite/道纹/镇关8");
		连珠4 = Resources.Load<Sprite>("Sprite/道纹/连珠4");
		连珠5 = Resources.LoadAll<Sprite>("Sprite/道纹/连珠5678")[0];
		连珠6 = Resources.LoadAll<Sprite>("Sprite/道纹/连珠5678")[1];
		连珠7 = Resources.LoadAll<Sprite>("Sprite/道纹/连珠5678")[2];
		连珠8 = Resources.LoadAll<Sprite>("Sprite/道纹/连珠5678")[3];
		回响4 = Resources.Load<Sprite>("Sprite/道纹/回响4");
		回响5 = Resources.Load<Sprite>("Sprite/道纹/回响5");
		回响6 = Resources.LoadAll<Sprite>("Sprite/道纹/回响678")[0];
		回响7 = Resources.LoadAll<Sprite>("Sprite/道纹/回响678")[1];
		回响8 = Resources.LoadAll<Sprite>("Sprite/道纹/回响678")[2];
		心炎4 = Resources.Load<Sprite>("Sprite/道纹/心炎4");
		心炎5 = Resources.Load<Sprite>("Sprite/道纹/心炎5");
		心炎6 = Resources.Load<Sprite>("Sprite/道纹/心炎6");
		心炎7 = Resources.LoadAll<Sprite>("Sprite/道纹/心炎78")[0];
		心炎8 = Resources.LoadAll<Sprite>("Sprite/道纹/心炎78")[1];
		扶摇4 = Resources.Load<Sprite>("Sprite/道纹/扶摇4");
		扶摇5 = Resources.Load<Sprite>("Sprite/道纹/扶摇5");
		扶摇6 = Resources.Load<Sprite>("Sprite/道纹/扶摇6");
		扶摇7 = Resources.Load<Sprite>("Sprite/道纹/扶摇7");
		扶摇8 = Resources.Load<Sprite>("Sprite/道纹/扶摇8");
		焚天4 = Resources.Load<Sprite>("Sprite/道纹/焚天4");
		焚天5 = Resources.Load<Sprite>("Sprite/道纹/焚天5");
		焚天6 = Resources.Load<Sprite>("Sprite/道纹/焚天6");
		焚天7 = Resources.Load<Sprite>("Sprite/道纹/焚天7");
		焚天8 = Resources.Load<Sprite>("Sprite/道纹/焚天8");
		齐天战意4 = Resources.Load<Sprite>("Sprite/道纹/齐天战意4");
		齐天战意5 = Resources.Load<Sprite>("Sprite/道纹/齐天战意5");
		齐天战意6 = Resources.Load<Sprite>("Sprite/道纹/齐天战意6");
		齐天战意7 = Resources.Load<Sprite>("Sprite/道纹/齐天战意7");
		齐天战意8 = Resources.Load<Sprite>("Sprite/道纹/齐天战意8");
		冰龙回响4 = Resources.Load<Sprite>("Sprite/道纹/冰龙回响4");
		冰龙回响5 = Resources.Load<Sprite>("Sprite/道纹/冰龙回响5");
		冰龙回响6 = Resources.Load<Sprite>("Sprite/道纹/冰龙回响6");
		冰龙回响7 = Resources.Load<Sprite>("Sprite/道纹/冰龙回响7");
		冰龙回响8 = Resources.Load<Sprite>("Sprite/道纹/冰龙回响8");
		定身4 = Resources.LoadAll<Sprite>("Sprite/道纹/定身绝命")[0];
		定身5 = Resources.LoadAll<Sprite>("Sprite/道纹/定身绝命")[1];
		定身6 = Resources.LoadAll<Sprite>("Sprite/道纹/定身绝命")[2];
		定身7 = Resources.LoadAll<Sprite>("Sprite/道纹/定身绝命")[3];
		定身8 = Resources.LoadAll<Sprite>("Sprite/道纹/定身绝命")[4];
		云破4 = Resources.Load<Sprite>("Sprite/道纹/云破4");
		云破5 = Resources.Load<Sprite>("Sprite/道纹/云破5");
		云破6 = Resources.Load<Sprite>("Sprite/道纹/云破6");
		云破7 = Resources.Load<Sprite>("Sprite/道纹/云破7");
		云破8 = Resources.Load<Sprite>("Sprite/道纹/云破8");
		落日4 = Resources.Load<Sprite>("Sprite/道纹/落日4");
		落日5 = Resources.Load<Sprite>("Sprite/道纹/落日5");
		落日6 = Resources.Load<Sprite>("Sprite/道纹/落日6");
		落日7 = Resources.Load<Sprite>("Sprite/道纹/落日7");
		落日8 = Resources.Load<Sprite>("Sprite/道纹/落日8");
		曦日灼4 = Resources.Load<Sprite>("Sprite/道纹/曦日灼4");
		曦日灼5 = Resources.LoadAll<Sprite>("Sprite/道纹/曦日灼5678")[0];
		曦日灼6 = Resources.LoadAll<Sprite>("Sprite/道纹/曦日灼5678")[1];
		曦日灼7 = Resources.LoadAll<Sprite>("Sprite/道纹/曦日灼5678")[2];
		曦日灼8 = Resources.LoadAll<Sprite>("Sprite/道纹/曦日灼5678")[3];
		寒月4 = Resources.Load<Sprite>("Sprite/道纹/寒月4");
		寒月5 = Resources.Load<Sprite>("Sprite/道纹/寒月5");
		寒月6 = Resources.Load<Sprite>("Sprite/道纹/寒月6");
		寒月7 = Resources.Load<Sprite>("Sprite/道纹/寒月7");
		寒月8 = Resources.Load<Sprite>("Sprite/道纹/寒月8");
		补天4 = Resources.Load<Sprite>("Sprite/道纹/补天4");
		补天5 = Resources.LoadAll<Sprite>("Sprite/道纹/补天5678")[0];
		补天6 = Resources.LoadAll<Sprite>("Sprite/道纹/补天5678")[1];
		补天7 = Resources.LoadAll<Sprite>("Sprite/道纹/补天5678")[2];
		补天8 = Resources.LoadAll<Sprite>("Sprite/道纹/补天5678")[3];
		截天4 = Resources.Load<Sprite>("Sprite/道纹/截天4");
		截天5 = Resources.Load<Sprite>("Sprite/道纹/截天5");
		截天6 = Resources.Load<Sprite>("Sprite/道纹/截天6");
		截天7 = Resources.Load<Sprite>("Sprite/道纹/截天7");
		截天8 = Resources.Load<Sprite>("Sprite/道纹/截天8");
		玄风4 = Resources.Load<Sprite>("Sprite/道纹/玄风4");
		玄风5 = Resources.Load<Sprite>("Sprite/道纹/玄风5");
		玄风6 = Resources.LoadAll<Sprite>("Sprite/道纹/玄风678")[0];
		玄风7 = Resources.LoadAll<Sprite>("Sprite/道纹/玄风678")[1];
		玄风8 = Resources.LoadAll<Sprite>("Sprite/道纹/玄风678")[2];
		始火4 = Resources.Load<Sprite>("Sprite/道纹/始火4");
		始火5 = Resources.Load<Sprite>("Sprite/道纹/始火5");
		始火6 = Resources.Load<Sprite>("Sprite/道纹/始火6");
		始火7 = Resources.Load<Sprite>("Sprite/道纹/始火7");
		始火8 = Resources.Load<Sprite>("Sprite/道纹/始火8");
		鸿蒙陨4 = Resources.Load<Sprite>("Sprite/道纹/鸿蒙陨4");
		鸿蒙陨5 = Resources.Load<Sprite>("Sprite/道纹/鸿蒙陨5");
		鸿蒙陨6 = Resources.Load<Sprite>("Sprite/道纹/鸿蒙陨6");
		鸿蒙陨7 = Resources.Load<Sprite>("Sprite/道纹/鸿蒙陨7");
		鸿蒙陨8 = Resources.Load<Sprite>("Sprite/道纹/鸿蒙陨8");
		开天4 = Resources.Load<Sprite>("Sprite/道纹/开天4");
		开天5 = Resources.Load<Sprite>("Sprite/道纹/开天5");
		开天6 = Resources.Load<Sprite>("Sprite/道纹/开天6");
		开天7 = Resources.Load<Sprite>("Sprite/道纹/开天7");
		开天8 = Resources.Load<Sprite>("Sprite/道纹/开天8");
		冰 = Resources.Load<Sprite>("Sprite/法则icon/冰");
		剑 = Resources.Load<Sprite>("Sprite/法则icon/剑");
		力 = Resources.Load<Sprite>("Sprite/法则icon/力");
		原始 = Resources.Load<Sprite>("Sprite/法则icon/原始");
		斗 = Resources.Load<Sprite>("Sprite/法则icon/斗");
		日 = Resources.Load<Sprite>("Sprite/法则icon/日");
		月 = Resources.Load<Sprite>("Sprite/法则icon/月");
		火 = Resources.Load<Sprite>("Sprite/法则icon/火");
		禁 = Resources.Load<Sprite>("Sprite/法则icon/禁");
		箭 = Resources.Load<Sprite>("Sprite/法则icon/箭");
		诛仙 = Resources.Load<Sprite>("Sprite/法则icon/诛仙");
		造化 = Resources.Load<Sprite>("Sprite/法则icon/造化");
		道 = Resources.Load<Sprite>("Sprite/法则icon/道");
		鸿蒙 = Resources.Load<Sprite>("Sprite/法则icon/鸿蒙");
		品质元神白 = Resources.LoadAll<Sprite>("Sprite/品质元神/品质元神")[0];
		品质元神绿 = Resources.LoadAll<Sprite>("Sprite/品质元神/品质元神")[1];
		品质元神蓝 = Resources.LoadAll<Sprite>("Sprite/品质元神/品质元神")[2];
		品质元神紫 = Resources.LoadAll<Sprite>("Sprite/品质元神/品质元神")[3];
		品质元神橙 = Resources.LoadAll<Sprite>("Sprite/品质元神/品质元神")[4];
		品质元神粉 = Resources.LoadAll<Sprite>("Sprite/品质元神/品质元神")[5];
		品质元神红 = Resources.LoadAll<Sprite>("Sprite/品质元神/品质元神")[6];
		品质元神彩 = Resources.LoadAll<Sprite>("Sprite/品质元神/品质元神")[7];
		火焰TMP = Resources.Load<TMP_ColorGradient>("TMP/火焰TMP");
		冰霜TMP = Resources.Load<TMP_ColorGradient>("TMP/冰霜TMP");
		雷电TMP = Resources.Load<TMP_ColorGradient>("TMP/雷电TMP");
		黑暗TMP = Resources.Load<TMP_ColorGradient>("TMP/黑暗TMP");
		物理TMP = Resources.Load<TMP_ColorGradient>("TMP/物理TMP");
		黄TMP = Resources.Load<TMP_ColorGradient>("TMP/黄");
		玄TMP = Resources.Load<TMP_ColorGradient>("TMP/玄");
		地TMP = Resources.Load<TMP_ColorGradient>("TMP/地");
		天TMP = Resources.Load<TMP_ColorGradient>("TMP/天");
		宇TMP = Resources.Load<TMP_ColorGradient>("TMP/宇");
		宙TMP = Resources.Load<TMP_ColorGradient>("TMP/宙");
		洪TMP = Resources.Load<TMP_ColorGradient>("TMP/洪");
		荒TMP = Resources.Load<TMP_ColorGradient>("TMP/荒");
		丹童技能icon = Resources.Load<Sprite>("Sprite/技能icon/丹童技能");
		土地技能icon = Resources.LoadAll<Sprite>("Sprite/技能icon/土地龟丞相技能")[0];
		河伯技能icon = Resources.Load<Sprite>("Sprite/技能icon/河伯技能");
		瑶池仙女技能icon = Resources.Load<Sprite>("Sprite/技能icon/瑶池技能");
		石敢当技能icon = Resources.Load<Sprite>("Sprite/技能icon/石敢当技能");
		玄女技能icon = Resources.Load<Sprite>("Sprite/技能icon/玄女技能");
		龟丞相技能icon = Resources.LoadAll<Sprite>("Sprite/技能icon/土地龟丞相技能")[1];
		太白金星技能icon = Resources.Load<Sprite>("Sprite/技能icon/太白金星技能");
		多闻天王技能icon = Resources.Load<Sprite>("Sprite/技能icon/多闻天王技能");
		广目天王技能icon = Resources.Load<Sprite>("Sprite/技能icon/广目天王技能");
		雷震子技能icon = Resources.Load<Sprite>("Sprite/技能icon/雷震子技能");
		月老技能icon = Resources.Load<Sprite>("Sprite/技能icon/月老技能");
		嫦娥技能icon = Resources.Load<Sprite>("Sprite/技能icon/嫦娥技能");
		杨戬技能icon = Resources.Load<Sprite>("Sprite/技能icon/杨戬技能");
		妲己技能icon = Resources.Load<Sprite>("Sprite/技能icon/妲己技能");
		牛魔王技能icon = Resources.Load<Sprite>("Sprite/技能icon/牛魔王技能");
		哪吒技能icon = Resources.Load<Sprite>("Sprite/技能icon/哪吒技能");
		孙悟空技能icon = Resources.Load<Sprite>("Sprite/技能icon/孙悟空技能");
		碧霄技能icon = Resources.Load<Sprite>("Sprite/技能icon/碧霄技能");
		琼霄技能icon = Resources.Load<Sprite>("Sprite/技能icon/琼霄技能");
		羲和技能icon = Resources.Load<Sprite>("Sprite/技能icon/羲和技能");
		常羲技能icon = Resources.Load<Sprite>("Sprite/技能icon/常羲技能");
		后羿技能icon = Resources.Load<Sprite>("Sprite/技能icon/后羿技能");
		云霄技能icon = Resources.Load<Sprite>("Sprite/技能icon/云霄技能");
		女娲技能icon = Resources.Load<Sprite>("Sprite/技能icon/女娲技能");
		老子技能icon = Resources.Load<Sprite>("Sprite/技能icon/老子技能");
		通天技能icon = Resources.Load<Sprite>("Sprite/技能icon/通天技能");
		元始技能icon = Resources.Load<Sprite>("Sprite/技能icon/元始技能");
		鸿钧技能icon = Resources.Load<Sprite>("Sprite/技能icon/鸿钧技能");
		盘古技能icon = Resources.Load<Sprite>("Sprite/技能icon/盘古技能");
		物理icon = Resources.Load<Sprite>("Sprite/元素icon/物理icon");
		火焰icon = Resources.Load<Sprite>("Sprite/元素icon/火焰icon");
		黑暗icon = Resources.Load<Sprite>("Sprite/元素icon/黑暗icon");
		雷电icon = Resources.Load<Sprite>("Sprite/元素icon/雷电icon");
		冰霜icon = Resources.Load<Sprite>("Sprite/元素icon/冰霜icon");
		黄 = Resources.LoadAll<Sprite>("Sprite/品质艺术字/品质艺术字")[0];
		玄 = Resources.LoadAll<Sprite>("Sprite/品质艺术字/品质艺术字")[1];
		地 = Resources.LoadAll<Sprite>("Sprite/品质艺术字/品质艺术字")[2];
		天 = Resources.LoadAll<Sprite>("Sprite/品质艺术字/品质艺术字")[3];
		宇 = Resources.LoadAll<Sprite>("Sprite/品质艺术字/品质艺术字")[4];
		宙 = Resources.LoadAll<Sprite>("Sprite/品质艺术字/品质艺术字")[5];
		洪 = Resources.LoadAll<Sprite>("Sprite/品质艺术字/品质艺术字")[6];
		荒 = Resources.LoadAll<Sprite>("Sprite/品质艺术字/品质艺术字")[7];
		锁 = Resources.Load<Sprite>("Sprite/强化窗口/锁");
		解锁 = Resources.Load<Sprite>("Sprite/强化窗口/解锁");
		强化窗口装备背景框亮 = Resources.LoadAll<Sprite>("Sprite/强化窗口/装备背景框")[1];
		强化窗口装备背景框暗 = Resources.LoadAll<Sprite>("Sprite/强化窗口/装备背景框")[0];
		强化窗口按钮亮 = Resources.Load<Sprite>("Sprite/强化窗口/按钮亮");
		强化窗口按钮暗 = Resources.Load<Sprite>("Sprite/强化窗口/按钮暗");
		灰色TMP = Resources.Load<TMP_ColorGradient>("TMP/灰色");
		高级招募TMP = Resources.Load<TMP_ColorGradient>("TMP/高级招募");
		纯黄TMP = Resources.Load<TMP_ColorGradient>("TMP/纯黄");
		突破背景凡 = Resources.Load<Sprite>("Sprite/突破背景/凡");
		突破背景灵 = Resources.Load<Sprite>("Sprite/突破背景/灵");
		突破背景仙 = Resources.Load<Sprite>("Sprite/突破背景/仙");
		突破背景圣 = Resources.Load<Sprite>("Sprite/突破背景/圣");
		突破背景荒 = Resources.Load<Sprite>("Sprite/突破背景/荒");
		护手白 = Resources.Load<Sprite>("Sprite/装备/护手/白");
		护手绿 = Resources.Load<Sprite>("Sprite/装备/护手/绿");
		护手蓝 = Resources.Load<Sprite>("Sprite/装备/护手/蓝");
		护手紫 = Resources.Load<Sprite>("Sprite/装备/护手/紫");
		护手橙 = Resources.Load<Sprite>("Sprite/装备/护手/橙");
		护手粉 = Resources.Load<Sprite>("Sprite/装备/护手/粉");
		护手红 = Resources.Load<Sprite>("Sprite/装备/护手/红");
		护手彩 = Resources.Load<Sprite>("Sprite/装备/护手/彩");
		鞋子白 = Resources.Load<Sprite>("Sprite/装备/鞋子/白");
		鞋子绿 = Resources.Load<Sprite>("Sprite/装备/鞋子/绿");
		鞋子蓝 = Resources.Load<Sprite>("Sprite/装备/鞋子/蓝");
		鞋子紫 = Resources.Load<Sprite>("Sprite/装备/鞋子/紫");
		鞋子橙 = Resources.Load<Sprite>("Sprite/装备/鞋子/橙");
		鞋子粉 = Resources.Load<Sprite>("Sprite/装备/鞋子/粉");
		鞋子红 = Resources.Load<Sprite>("Sprite/装备/鞋子/红");
		鞋子彩 = Resources.Load<Sprite>("Sprite/装备/鞋子/彩");
		头盔白 = Resources.Load<Sprite>("Sprite/装备/头盔/白");
		头盔绿 = Resources.Load<Sprite>("Sprite/装备/头盔/绿");
		头盔蓝 = Resources.Load<Sprite>("Sprite/装备/头盔/蓝");
		头盔紫 = Resources.Load<Sprite>("Sprite/装备/头盔/紫");
		头盔橙 = Resources.Load<Sprite>("Sprite/装备/头盔/橙");
		头盔粉 = Resources.Load<Sprite>("Sprite/装备/头盔/粉");
		头盔红 = Resources.Load<Sprite>("Sprite/装备/头盔/红");
		头盔彩 = Resources.Load<Sprite>("Sprite/装备/头盔/彩");
		项链白 = Resources.Load<Sprite>("Sprite/装备/项链/白");
		项链绿 = Resources.Load<Sprite>("Sprite/装备/项链/绿");
		项链蓝 = Resources.Load<Sprite>("Sprite/装备/项链/蓝");
		项链紫 = Resources.Load<Sprite>("Sprite/装备/项链/紫");
		项链橙 = Resources.Load<Sprite>("Sprite/装备/项链/橙");
		项链粉 = Resources.Load<Sprite>("Sprite/装备/项链/粉");
		项链红 = Resources.Load<Sprite>("Sprite/装备/项链/红");
		项链彩 = Resources.Load<Sprite>("Sprite/装备/项链/彩");
		戒指白 = Resources.Load<Sprite>("Sprite/装备/戒指/白");
		戒指绿 = Resources.Load<Sprite>("Sprite/装备/戒指/绿");
		戒指蓝 = Resources.Load<Sprite>("Sprite/装备/戒指/蓝");
		戒指紫 = Resources.Load<Sprite>("Sprite/装备/戒指/紫");
		戒指橙 = Resources.Load<Sprite>("Sprite/装备/戒指/橙");
		戒指粉 = Resources.Load<Sprite>("Sprite/装备/戒指/粉");
		戒指红 = Resources.Load<Sprite>("Sprite/装备/戒指/红");
		戒指彩 = Resources.Load<Sprite>("Sprite/装备/戒指/彩");
		衣服白 = Resources.Load<Sprite>("Sprite/装备/衣服/白");
		衣服绿 = Resources.Load<Sprite>("Sprite/装备/衣服/绿");
		衣服蓝 = Resources.Load<Sprite>("Sprite/装备/衣服/蓝");
		衣服紫 = Resources.Load<Sprite>("Sprite/装备/衣服/紫");
		衣服橙 = Resources.Load<Sprite>("Sprite/装备/衣服/橙");
		衣服粉 = Resources.Load<Sprite>("Sprite/装备/衣服/粉");
		衣服红 = Resources.Load<Sprite>("Sprite/装备/衣服/红");
		衣服彩 = Resources.Load<Sprite>("Sprite/装备/衣服/彩");
		招募概率按钮亮 = Resources.Load<Sprite>("Sprite/招募/招募概率按钮亮");
		招募概率按钮暗 = Resources.Load<Sprite>("Sprite/招募/招募概率按钮暗");
		品质标签白 = Resources.Load<Sprite>("Sprite/品质标签/白");
		品质标签绿 = Resources.Load<Sprite>("Sprite/品质标签/绿");
		品质标签蓝 = Resources.Load<Sprite>("Sprite/品质标签/蓝");
		品质标签紫 = Resources.Load<Sprite>("Sprite/品质标签/紫");
		品质标签橙 = Resources.Load<Sprite>("Sprite/品质标签/橙");
		品质标签粉 = Resources.Load<Sprite>("Sprite/品质标签/粉");
		品质标签红 = Resources.Load<Sprite>("Sprite/品质标签/红");
		品质标签彩 = Resources.Load<Sprite>("Sprite/品质标签/彩");
		战斗人物背景框白 = Resources.Load<Sprite>("Sprite/战斗人物背景框/白");
		战斗人物背景框绿 = Resources.Load<Sprite>("Sprite/战斗人物背景框/绿");
		战斗人物背景框蓝 = Resources.Load<Sprite>("Sprite/战斗人物背景框/蓝");
		战斗人物背景框紫 = Resources.Load<Sprite>("Sprite/战斗人物背景框/紫");
		战斗人物背景框橙 = Resources.Load<Sprite>("Sprite/战斗人物背景框/橙");
		战斗人物背景框粉 = Resources.Load<Sprite>("Sprite/战斗人物背景框/粉");
		战斗人物背景框红 = Resources.Load<Sprite>("Sprite/战斗人物背景框/红");
		战斗人物背景框彩 = Resources.Load<Sprite>("Sprite/战斗人物背景框/彩");
		UI人物背景框白 = Resources.Load<Sprite>("Sprite/UI人物背景框/白");
		UI人物背景框绿 = Resources.Load<Sprite>("Sprite/UI人物背景框/绿");
		UI人物背景框蓝 = Resources.Load<Sprite>("Sprite/UI人物背景框/蓝");
		UI人物背景框紫 = Resources.Load<Sprite>("Sprite/UI人物背景框/紫");
		UI人物背景框橙 = Resources.Load<Sprite>("Sprite/UI人物背景框/橙");
		UI人物背景框粉 = Resources.Load<Sprite>("Sprite/UI人物背景框/粉");
		UI人物背景框红 = Resources.Load<Sprite>("Sprite/UI人物背景框/红");
		UI人物背景框彩 = Resources.Load<Sprite>("Sprite/UI人物背景框/彩");
		道具背景框白 = Resources.Load<Sprite>("Sprite/道具背景框/白");
		道具背景框绿 = Resources.Load<Sprite>("Sprite/道具背景框/绿");
		道具背景框蓝 = Resources.Load<Sprite>("Sprite/道具背景框/蓝");
		道具背景框紫 = Resources.Load<Sprite>("Sprite/道具背景框/紫");
		道具背景框橙 = Resources.Load<Sprite>("Sprite/道具背景框/橙");
		道具背景框粉 = Resources.Load<Sprite>("Sprite/道具背景框/粉");
		道具背景框红 = Resources.Load<Sprite>("Sprite/道具背景框/红");
		道具背景框彩 = Resources.Load<Sprite>("Sprite/道具背景框/彩");
		道具背景框白1 = Resources.Load<Sprite>("Sprite/道具背景框/白4");
		道具背景框绿1 = Resources.Load<Sprite>("Sprite/道具背景框/绿4");
		道具背景框蓝1 = Resources.Load<Sprite>("Sprite/道具背景框/蓝4");
		道具背景框紫1 = Resources.Load<Sprite>("Sprite/道具背景框/紫4");
		道具背景框橙1 = Resources.Load<Sprite>("Sprite/道具背景框/橙4");
		道具背景框粉1 = Resources.Load<Sprite>("Sprite/道具背景框/粉4");
		道具背景框红1 = Resources.Load<Sprite>("Sprite/道具背景框/红4");
		道具背景框彩1 = Resources.Load<Sprite>("Sprite/道具背景框/彩4");
		小怪背景框 = Resources.Load<Sprite>("Sprite/怪物背景框/小怪背景框");
		精英怪背景框 = Resources.Load<Sprite>("Sprite/怪物背景框/精英怪背景框");
		Boss背景框 = Resources.Load<Sprite>("Sprite/怪物背景框/boss背景框");
		全职业经验值 = Resources.Load<Sprite>("Sprite/DaoJu/全职业经验值");
		功德 = Resources.Load<Sprite>("Sprite/DaoJu/功德");
		头盔锻造石 = Resources.Load<Sprite>("Sprite/DaoJu/头盔锻造石");
		射手经验值 = Resources.Load<Sprite>("Sprite/DaoJu/射手经验值");
		射手 = Resources.Load<Sprite>("Sprite/DaoJu/射手");
		戒指锻造石 = Resources.Load<Sprite>("Sprite/DaoJu/戒指锻造石");
		战士经验值 = Resources.Load<Sprite>("Sprite/DaoJu/战士经验值");
		战士 = Resources.Load<Sprite>("Sprite/DaoJu/战士");
		护手锻造石 = Resources.Load<Sprite>("Sprite/DaoJu/护手锻造石");
		招募卷 = Resources.Load<Sprite>("Sprite/DaoJu/招募卷");
		控制经验值 = Resources.Load<Sprite>("Sprite/DaoJu/控制经验值");
		法师经验值 = Resources.Load<Sprite>("Sprite/DaoJu/法师经验值");
		控制 = Resources.Load<Sprite>("Sprite/DaoJu/控制");
		法师 = Resources.Load<Sprite>("Sprite/DaoJu/法师");
		洗练石 = Resources.Load<Sprite>("Sprite/DaoJu/洗练石");
		灵魂 = Resources.Load<Sprite>("Sprite/DaoJu/灵魂");
		衣服锻造石 = Resources.Load<Sprite>("Sprite/DaoJu/衣服锻造石");
		辅助经验值 = Resources.Load<Sprite>("Sprite/DaoJu/辅助经验值");
		辅助 = Resources.Load<Sprite>("Sprite/DaoJu/辅助");
		鞋子锻造石 = Resources.Load<Sprite>("Sprite/DaoJu/鞋子锻造石");
		项链锻造石 = Resources.Load<Sprite>("Sprite/DaoJu/项链锻造石");
		高级招募卷 = Resources.Load<Sprite>("Sprite/DaoJu/高级招募卷");
		花果山 = Resources.Load<Sprite>("Sprite/新地图icon/花果山");
		水帘洞 = Resources.Load<Sprite>("Sprite/新地图icon/水帘洞");
		傲来国 = Resources.Load<Sprite>("Sprite/新地图icon/傲来国");
		东海龙宫 = Resources.Load<Sprite>("Sprite/新地图icon/通天河");
		蓬莱仙岛 = Resources.Load<Sprite>("Sprite/新地图icon/蓬莱仙岛");
		五行山 = Resources.Load<Sprite>("Sprite/新地图icon/五行山");
		高老庄 = Resources.Load<Sprite>("Sprite/新地图icon/高老庄");
		平顶山 = Resources.Load<Sprite>("Sprite/新地图icon/平顶山");
		女儿国 = Resources.Load<Sprite>("Sprite/新地图icon/女儿国");
		火焰山 = Resources.Load<Sprite>("Sprite/新地图icon/火焰山");
		狮驼岭 = Resources.Load<Sprite>("Sprite/新地图icon/狮驼岭");
		小雷音寺 = Resources.Load<Sprite>("Sprite/新地图icon/小雷音寺");
		流沙河 = Resources.Load<Sprite>("Sprite/新地图icon/流沙河");
		芭蕉洞 = Resources.Load<Sprite>("Sprite/新地图icon/芭蕉洞");
		冥府 = Resources.Load<Sprite>("Sprite/新地图icon/冥府");
		南天门 = Resources.Load<Sprite>("Sprite/新地图icon/南天门");
		瑶池仙境 = Resources.Load<Sprite>("Sprite/新地图icon/瑶池仙境");
		斩妖台 = Resources.Load<Sprite>("Sprite/新地图icon/斩妖台");
		御马监 = Resources.Load<Sprite>("Sprite/新地图icon/御马监");
		蟠桃园 = Resources.Load<Sprite>("Sprite/新地图icon/蟠桃园");
		兜率宫 = Resources.Load<Sprite>("Sprite/新地图icon/兜率宫");
		紫微宫 = Resources.Load<Sprite>("Sprite/新地图icon/紫微宫");
		昊天殿 = Resources.Load<Sprite>("Sprite/新地图icon/昊天殿");
		登天路 = Resources.Load<Sprite>("Sprite/地图icon/登天路");
		欲界天 = Resources.Load<Sprite>("Sprite/地图icon/欲界天");
		色界天 = Resources.Load<Sprite>("Sprite/地图icon/色界天");
		无色天 = Resources.Load<Sprite>("Sprite/地图icon/无色天");
		四梵天 = Resources.Load<Sprite>("Sprite/地图icon/四梵天");
		玉清境清微天 = Resources.Load<Sprite>("Sprite/地图icon/玉清境清微天");
		上清境禹余天 = Resources.Load<Sprite>("Sprite/地图icon/上清境禹余天");
		太清境大赤天 = Resources.Load<Sprite>("Sprite/地图icon/太清境大赤天");
		大罗天 = Resources.Load<Sprite>("Sprite/地图icon/大罗天");
		猴精 = Resources.Load<Sprite>("Sprite/怪物icon/猴精");
		山魈 = Resources.Load<Sprite>("Sprite/怪物icon/山魈");
		马猴头领 = Resources.Load<Sprite>("Sprite/怪物icon/马猴头领");
		通臂猿猴 = Resources.Load<Sprite>("Sprite/怪物icon/通臂猿猴");
		水虱精 = Resources.Load<Sprite>("Sprite/怪物icon/水虱精");
		蝙蝠精 = Resources.Load<Sprite>("Sprite/怪物icon/蝙蝠精");
		铁背苍猿 = Resources.Load<Sprite>("Sprite/怪物icon/铁背苍猿");
		水帘洞主 = Resources.Load<Sprite>("Sprite/怪物icon/水帘洞主");
		傲来民兵 = Resources.Load<Sprite>("Sprite/怪物icon/傲来民兵");
		猎户 = Resources.Load<Sprite>("Sprite/怪物icon/猎户");
		傲来偏将 = Resources.Load<Sprite>("Sprite/怪物icon/傲来偏将");
		傲来国师 = Resources.Load<Sprite>("Sprite/怪物icon/傲来国师");
		虾兵 = Resources.Load<Sprite>("Sprite/怪物icon/虾兵");
		蟹将 = Resources.Load<Sprite>("Sprite/怪物icon/蟹将");
		龟丞相 = Resources.Load<Sprite>("Sprite/怪物icon/龟丞相");
		东海龙王 = Resources.Load<Sprite>("Sprite/怪物icon/东海龙王");
		仙鹤 = Resources.Load<Sprite>("Sprite/怪物icon/仙鹤");
		灵芝童 = Resources.Load<Sprite>("Sprite/怪物icon/灵芝童");
		蓬莱剑仙 = Resources.Load<Sprite>("Sprite/怪物icon/蓬莱剑仙");
		蓬莱岛主 = Resources.Load<Sprite>("Sprite/怪物icon/蓬莱岛主");
		山石精 = Resources.Load<Sprite>("Sprite/怪物icon/山石精");
		土蝼 = Resources.Load<Sprite>("Sprite/怪物icon/土蝼");
		五行山神 = Resources.Load<Sprite>("Sprite/怪物icon/五行山神");
		压山符灵 = Resources.Load<Sprite>("Sprite/怪物icon/压山符灵");
		野猪精 = Resources.Load<Sprite>("Sprite/怪物icon/野猪精");
		高才 = Resources.Load<Sprite>("Sprite/怪物icon/高才");
		高太公 = Resources.Load<Sprite>("Sprite/怪物icon/高太公");
		猪刚鬣 = Resources.Load<Sprite>("Sprite/怪物icon/猪刚鬣");
		莲花洞小妖 = Resources.Load<Sprite>("Sprite/怪物icon/莲花洞小妖");
		狐阿七 = Resources.Load<Sprite>("Sprite/怪物icon/狐阿七");
		银角大王 = Resources.Load<Sprite>("Sprite/怪物icon/银角大王");
		金角大王 = Resources.Load<Sprite>("Sprite/怪物icon/金角大王");
		女儿国兵 = Resources.Load<Sprite>("Sprite/怪物icon/女儿国兵");
		女儿国将 = Resources.Load<Sprite>("Sprite/怪物icon/女儿国将");
		女儿国太师 = Resources.Load<Sprite>("Sprite/怪物icon/女儿国太师");
		女儿国国王 = Resources.Load<Sprite>("Sprite/怪物icon/女儿国国王");
		火焰精 = Resources.Load<Sprite>("Sprite/怪物icon/火焰精");
		赤蛇 = Resources.Load<Sprite>("Sprite/怪物icon/赤蛇");
		红孩儿 = Resources.Load<Sprite>("Sprite/怪物icon/红孩儿");
		牛魔王 = Resources.Load<Sprite>("Sprite/怪物icon/牛魔王");
		芭蕉精 = Resources.Load<Sprite>("Sprite/怪物icon/芭蕉精");
		火焰童 = Resources.Load<Sprite>("Sprite/怪物icon/火焰童");
		铁扇侍女 = Resources.Load<Sprite>("Sprite/怪物icon/铁扇侍女");
		铁扇公主 = Resources.Load<Sprite>("Sprite/怪物icon/铁扇公主");
		流沙精 = Resources.Load<Sprite>("Sprite/怪物icon/流沙精");
		水鬼 = Resources.Load<Sprite>("Sprite/怪物icon/水鬼");
		水蛇妖 = Resources.Load<Sprite>("Sprite/怪物icon/水蛇妖");
		沙和尚 = Resources.Load<Sprite>("Sprite/怪物icon/沙和尚");
		假罗汉 = Resources.Load<Sprite>("Sprite/怪物icon/假罗汉");
		假金刚 = Resources.Load<Sprite>("Sprite/怪物icon/假金刚");
		黄眉童子 = Resources.Load<Sprite>("Sprite/怪物icon/黄眉童子");
		黄眉老祖 = Resources.Load<Sprite>("Sprite/怪物icon/黄眉老祖");
		青狮精手下 = Resources.Load<Sprite>("Sprite/怪物icon/青狮精手下");
		白象精手下 = Resources.Load<Sprite>("Sprite/怪物icon/白象精手下");
		大鹏金翅雕 = Resources.Load<Sprite>("Sprite/怪物icon/大鹏金翅雕");
		青狮精 = Resources.Load<Sprite>("Sprite/怪物icon/青狮精");
		牛头 = Resources.Load<Sprite>("Sprite/怪物icon/牛头");
		马面 = Resources.Load<Sprite>("Sprite/怪物icon/马面");
		判官 = Resources.Load<Sprite>("Sprite/怪物icon/判官");
		阎罗王 = Resources.Load<Sprite>("Sprite/怪物icon/阎罗王");
		天兵 = Resources.Load<Sprite>("Sprite/怪物icon/天兵");
		天将 = Resources.Load<Sprite>("Sprite/怪物icon/天将");
		守卫统领 = Resources.Load<Sprite>("Sprite/怪物icon/守卫统领");
		巨灵王 = Resources.Load<Sprite>("Sprite/怪物icon/巨灵王");
		瑶池仙女 = Resources.Load<Sprite>("Sprite/怪物icon/瑶池仙女");
		瑶池守卫 = Resources.Load<Sprite>("Sprite/怪物icon/瑶池守卫");
		仙女首领 = Resources.Load<Sprite>("Sprite/怪物icon/仙女首领");
		西王母 = Resources.Load<Sprite>("Sprite/怪物icon/西王母");
		执法天兵 = Resources.Load<Sprite>("Sprite/怪物icon/执法天兵");
		执法天将 = Resources.Load<Sprite>("Sprite/怪物icon/执法天将");
		斩妖剑侍 = Resources.Load<Sprite>("Sprite/怪物icon/斩妖剑侍");
		天刑星君 = Resources.Load<Sprite>("Sprite/怪物icon/天刑星君");
		天马精 = Resources.Load<Sprite>("Sprite/怪物icon/天马精");
		监丞侍卫 = Resources.Load<Sprite>("Sprite/怪物icon/监丞侍卫");
		弼马温 = Resources.Load<Sprite>("Sprite/怪物icon/弼马温");
		天马星君 = Resources.Load<Sprite>("Sprite/怪物icon/天马星君");
		桃园力士 = Resources.Load<Sprite>("Sprite/怪物icon/桃园力士");
		桃园仙女 = Resources.Load<Sprite>("Sprite/怪物icon/桃园仙女");
		蟠桃守卫 = Resources.Load<Sprite>("Sprite/怪物icon/蟠桃守卫");
		蟠桃树精 = Resources.Load<Sprite>("Sprite/怪物icon/蟠桃树精");
		炼丹道童 = Resources.Load<Sprite>("Sprite/怪物icon/炼丹道童");
		烧火道童 = Resources.Load<Sprite>("Sprite/怪物icon/烧火道童");
		兜率宫侍卫 = Resources.Load<Sprite>("Sprite/怪物icon/兜率宫侍卫");
		太上老君 = Resources.Load<Sprite>("Sprite/怪物icon/太上老君");
		紫微星侍 = Resources.Load<Sprite>("Sprite/怪物icon/紫微星侍");
		天罡星卒 = Resources.Load<Sprite>("Sprite/怪物icon/天罡星卒");
		北极星君 = Resources.Load<Sprite>("Sprite/怪物icon/北极星君");
		紫微大帝 = Resources.Load<Sprite>("Sprite/怪物icon/紫微大帝");
		镇殿守卫 = Resources.Load<Sprite>("Sprite/怪物icon/镇殿守卫");
		镇殿天将 = Resources.Load<Sprite>("Sprite/怪物icon/镇殿天将");
		九龙神卫 = Resources.Load<Sprite>("Sprite/怪物icon/九龙神卫");
		玉皇大帝 = Resources.Load<Sprite>("Sprite/怪物icon/玉皇大帝");
		登天石傀 = Resources.Load<Sprite>("Sprite/怪物icon/登天石傀");
		罡风精 = Resources.Load<Sprite>("Sprite/怪物icon/罡风精");
		雷劫之灵 = Resources.Load<Sprite>("Sprite/怪物icon/雷劫之灵");
		守天路神将 = Resources.Load<Sprite>("Sprite/怪物icon/守天路神将");
		欲念魅妖 = Resources.Load<Sprite>("Sprite/怪物icon/欲念魅妖");
		幻音雀 = Resources.Load<Sprite>("Sprite/怪物icon/幻音雀");
		贪欲魔 = Resources.Load<Sprite>("Sprite/怪物icon/贪欲魔");
		欲界天魔王 = Resources.Load<Sprite>("Sprite/怪物icon/欲界天魔王");
		色相天女 = Resources.Load<Sprite>("Sprite/怪物icon/色相天女");
		光音天众 = Resources.Load<Sprite>("Sprite/怪物icon/光音天众");
		形色尊者 = Resources.Load<Sprite>("Sprite/怪物icon/形色尊者");
		色界天主 = Resources.Load<Sprite>("Sprite/怪物icon/色界天主");
		虚灵 = Resources.Load<Sprite>("Sprite/怪物icon/虚灵");
		空无影 = Resources.Load<Sprite>("Sprite/怪物icon/空无影");
		太虚之魂 = Resources.Load<Sprite>("Sprite/怪物icon/太虚之魂");
		无色天祖 = Resources.Load<Sprite>("Sprite/怪物icon/无色天祖");
		梵天守卫 = Resources.Load<Sprite>("Sprite/怪物icon/梵天守卫");
		净居天人 = Resources.Load<Sprite>("Sprite/怪物icon/净居天人");
		善现尊者 = Resources.Load<Sprite>("Sprite/怪物icon/善现尊者");
		四梵天王 = Resources.Load<Sprite>("Sprite/怪物icon/四梵天王");
		清微仙童 = Resources.Load<Sprite>("Sprite/怪物icon/清微仙童");
		玄光玉女 = Resources.Load<Sprite>("Sprite/怪物icon/玄光玉女");
		玉清道卫 = Resources.Load<Sprite>("Sprite/怪物icon/玉清道卫");
		魔元始天尊 = Resources.Load<Sprite>("Sprite/怪物icon/魔元始天尊");
		禹余灵官 = Resources.Load<Sprite>("Sprite/怪物icon/禹余灵官");
		紫霞仙鹤 = Resources.Load<Sprite>("Sprite/怪物icon/紫霞仙鹤");
		上清剑侍 = Resources.Load<Sprite>("Sprite/怪物icon/上清剑侍");
		魔灵宝天尊 = Resources.Load<Sprite>("Sprite/怪物icon/魔灵宝天尊");
		大赤丹童 = Resources.Load<Sprite>("Sprite/怪物icon/大赤丹童");
		炉火精 = Resources.Load<Sprite>("Sprite/怪物icon/炉火精");
		太清护卫 = Resources.Load<Sprite>("Sprite/怪物icon/太清护卫");
		魔老子 = Resources.Load<Sprite>("Sprite/怪物icon/魔老子");
		弥罗侍卫 = Resources.Load<Sprite>("Sprite/怪物icon/弥罗侍卫");
		弥罗宫卫 = Resources.Load<Sprite>("Sprite/怪物icon/弥罗宫卫");
		混元道兵 = Resources.Load<Sprite>("Sprite/怪物icon/混元道兵");
		魔鸿钧 = Resources.Load<Sprite>("Sprite/怪物icon/魔鸿钧");
		混沌蠕虫 = Resources.Load<Sprite>("Sprite/怪物icon/混沌蠕虫");
		虚空螯虫 = Resources.Load<Sprite>("Sprite/怪物icon/混沌巨兽");
		虚空巨兽 = Resources.Load<Sprite>("Sprite/怪物icon/混沌守卫");
		混沌主宰 = Resources.Load<Sprite>("Sprite/怪物icon/混沌吞噬者");
	}
}
