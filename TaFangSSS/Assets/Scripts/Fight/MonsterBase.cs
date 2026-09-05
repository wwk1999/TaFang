using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using DG.Tweening;
public class MonsterBase : MonoBehaviour
{
   public GameObject 图片;
   public SpriteRenderer 冰块;
   public GameObject 灼烧obj;
   public SpriteRenderer 灼烧image;
   [NonSerialized]public float 灼烧time = 0;
   [NonSerialized]public float 灼烧伤害=0;
   [NonSerialized]public float 灼烧间隔 = 1;
   [NonSerialized]public float 灼烧当前时间 = 0;
   [NonSerialized]public float 冰冻time = 0;

   public SpriteRenderer bg;
   public Canvas HpCanvas;
   public SpriteRenderer image;
   [NonSerialized]public MonsterTypeName MonsterTypeName=MonsterTypeName.None;
   public Transform 伤害trans;
   public Animator 攻击Animation;
   public Animator 移动Animation;
   public Animator 受击Animation;
   public Collider2D Collider2D;

   public Slider MonsterSlider;
   public Slider 残影Slider;

   [NonSerialized] public MonsterAttribute MonsterAttribute;
   [NonSerialized]public float CurrentHP;
   [NonSerialized] public float basespeed;
   private float CurrentAttackTime = 0;
   private float RealSpeed => GetRealSpeed();
   [NonSerialized] public float 瑶池冰辅助=0;
   [NonSerialized] public bool 女娲电辅助;
   [NonSerialized] public bool 妲己黑暗辅助;
   [NonSerialized] public bool 妲己神通;
   [NonSerialized] public bool 女娲神通;
   [NonSerialized] public float 龟丞相减速=0;
   [NonSerialized] public float 黑暗符=0;
   [NonSerialized]public bool isDead=false;
   [NonSerialized] public float 冰符=0;
   private DG.Tweening.Tweener 残影DOTween;
   private int 黑暗符次数 = 0;
   private Rigidbody2D _rb;
   private MonsterType _怪物类型;
   private float _怪物攻击距离;
   private float _上次伤害数字时间;
   private float 上次受击动画时间 = 0;

   public void Set灼烧伤害(float damage)
   {
      damage *= 属性config.总属性.羲和灼烧伤害;
      if (灼烧time <= 0)
      {
         灼烧伤害 = damage;
      }
      else
      {
         灼烧伤害 += 英雄星级属性.羲和灼烧叠加伤害 / 100f * damage;
      }
   }
   public void Set黑暗符(float time)
   {
      // 琼霄定身衰减减少已是0~1比率（Get道纹数值内部已/100），不能再除100
      float scale = 0.1f * 黑暗符次数*(1-属性config.总属性.琼霄定身衰减减少);
      黑暗符 = time * (1-scale);
      黑暗符次数++;
   }

   public float GetRealSpeed()
   {
      float value = basespeed;
      if (瑶池冰辅助 > 0)
      {
         value *= (1-英雄星级属性.瑶池仙女减速效果/100f);
      }
      if (冰符 > 0)
      {
         value *= (1-英雄星级属性.常曦减速效果/100f);
      }
      if (龟丞相减速 > 0)
      {
         value *= (1-英雄星级属性.龟丞相减速效果/100f);
      }

      if (transform.position.x < 城墙Config.泥沼减速距离)
      {
         value*=(1-城墙Config.泥沼减速效果/100f);
      }

      if (_怪物类型 == MonsterType.Elite)
      {
         value /= 2.5f;
      }
      if (_怪物类型 == MonsterType.Boss)
      {
         value /= 5f;
      }
      return value;
   }
   private void Awake()
   {
      _rb = gameObject.AddComponent<Rigidbody2D>();
      _rb.bodyType = RigidbodyType2D.Kinematic;
      _rb.useFullKinematicContacts = true;
      _rb.gravityScale = 0;
   }

   private void OnEnable()
   {
      if (MonsterTypeName == MonsterTypeName.None)
      {
         return;
      }

      // 缓存只跟 MonsterTypeName 相关的一次性查询，避免 Update 每帧查 Dictionary
      _怪物类型 = MonsterConfig.MonsterTypeDic[MonsterTypeName];
      _怪物攻击距离 = FightConfig.怪物攻击距离Dic[_怪物类型];

      if (MonsterConfig.怪物翻转Dic[MonsterTypeName])
      {
         图片.transform.localRotation = Quaternion.Euler(0, 0, 0);   // 不翻转
      }
      else
      {
         图片.transform.localRotation = Quaternion.Euler(0, 180, 0); // Y轴翻转180度
      }

      灼烧time = 0;
      移动Animation.enabled = true;
      移动Animation.Play("怪物移动", 0, 0f);
      黑暗符次数 = 0;
      isDead = false;
      InitAttribute();
      image.sortingOrder = (int)(transform.position.y * -100)+1;
      bg.sortingOrder = (int)(transform.position.y * -100);
      HpCanvas.sortingOrder = (int)(transform.position.y * -100)+3;
      灼烧image.sortingOrder = (int)(transform.position.y * -100)+2;
      冰块.sortingOrder = (int)(transform.position.y * -100)+2;
      MonsterSlider.gameObject.SetActive(false);
      残影Slider.gameObject.SetActive(false);
      CurrentHP = MonsterAttribute.Hp;
      image.sprite = ResourcesConfig.GetMonsterSprite(MonsterTypeName);
   }

   public void InitAttribute()
   {
      主线关卡Type 主线关卡Type = LevelConfig.当前主线关卡Type;
      MonsterType monsterType=MonsterConfig.MonsterTypeDic[MonsterTypeName];
      主线关卡怪物Item 主线关卡怪物Item=new 主线关卡怪物Item(){主线关卡Type =  主线关卡Type, MonsterType = monsterType};
      洞天怪物Item 洞天怪物Item=new 洞天怪物Item(){JingJieType =  PlayerData.S.当前轮回境界, MonsterType = monsterType};

      if (LevelConfig.当前关卡类型 == 关卡类型.主线关卡)
      {
         MonsterAttribute = Get主线关卡怪物属性(主线关卡怪物Item);
      }
      if (LevelConfig.当前关卡类型 == 关卡类型.洞天秘境)
      {
         MonsterAttribute = Get洞天怪物属性(洞天怪物Item,LevelConfig.当前洞天QualityType);
      }
      if (LevelConfig.当前关卡类型 == 关卡类型.远古遗迹)
      {
         MonsterAttribute = Get遗迹怪物属性(monsterType);
      }
      Monster特性Type monster特性Type=MonsterConfig.怪物特性Dic[MonsterTypeName];
      basespeed = MonsterConfig.怪物速度Dic[monster特性Type];
   }
   
   public MonsterAttribute Get遗迹怪物属性(MonsterType monsterType)
   {
      MonsterAttribute 基础属性 = 神物Config.遗迹关卡怪物属性Dic[new 遗迹关卡怪物Item(){神物Type = LevelConfig.当前神物Type,MonsterType = monsterType}];
      MonsterAttribute 怪物属性 = new MonsterAttribute()
      {
         Hp = 基础属性.Hp,
         Attack = 基础属性.Attack,
         Defense = 基础属性.Defense,
         物理抗性 = 基础属性.物理抗性,
         冰霜抗性 = 基础属性.冰霜抗性,
         火焰抗性 = 基础属性.火焰抗性,
         黑暗抗性 = 基础属性.黑暗抗性,
         雷电抗性 = 基础属性.雷电抗性,
      };
      return 怪物属性;
   }

   public MonsterAttribute Get洞天怪物属性(洞天怪物Item item,QualityType qualityType)
   {
      MonsterAttribute 基础属性 = 灵物突破Config.洞天怪物属性Dic[item];
      MonsterAttribute 怪物属性 = new MonsterAttribute()
      {
         Hp = 基础属性.Hp,
         Attack = 基础属性.Attack,
         Defense = 基础属性.Defense,
         物理抗性 = 基础属性.物理抗性,
         冰霜抗性 = 基础属性.冰霜抗性,
         火焰抗性 = 基础属性.火焰抗性,
         黑暗抗性 = 基础属性.黑暗抗性,
         雷电抗性 = 基础属性.雷电抗性,
      };
      float 倍率 = 灵物突破Config.洞天品质倍数Dic[qualityType];
      怪物属性.Attack *= 1+(倍率/10);
      怪物属性.Hp *= 倍率;
      怪物属性.Defense *= 1+(倍率/10);
      return 怪物属性;
   }

   public MonsterAttribute Get主线关卡怪物属性(主线关卡怪物Item item)
   {
      MonsterAttribute 基础属性 = MonsterConfig.主线关卡怪物属性Dic[item];
      // MonsterAttribute 是引用类型，必须拷贝一份再修改，否则会污染字典里的基础数据
      MonsterAttribute 怪物属性 = new MonsterAttribute()
      {
         Hp = 基础属性.Hp,
         Attack = 基础属性.Attack,
         Defense = 基础属性.Defense,
         物理抗性 = 基础属性.物理抗性,
         冰霜抗性 = 基础属性.冰霜抗性,
         火焰抗性 = 基础属性.火焰抗性,
         黑暗抗性 = 基础属性.黑暗抗性,
         雷电抗性 = 基础属性.雷电抗性,
      };
      if (LevelConfig.Is混沌虚空)
      {
         int count = LevelConfig.战斗混沌虚空层数 - 1;
         float 倍率 = Mathf.Pow(1.2f, count);
         怪物属性.Attack *= 倍率;
         怪物属性.Hp *= 倍率;
         怪物属性.Defense *= 倍率;
      }

      return 怪物属性;
   }

   public float 元素伤害(float damage,YuanSuType yuanSuType)
   {
      switch (yuanSuType)
      {
         case YuanSuType.冰:
            damage *= FightController.S.冰霜伤害;
            break;
         case YuanSuType.火:
            damage *= FightController.S.火焰伤害;
            break;
         case YuanSuType.黑暗:
            damage *= FightController.S.黑暗伤害;
            break;
         case YuanSuType.物理:
            damage *= FightController.S.物理伤害;
            break;
         case YuanSuType.电:
            damage *= FightController.S.雷电伤害;
            break;
      }

      return damage;
   }
   
   public float 职业伤害(float damage,ZhiYeType zhiYeType)
   {
      switch (zhiYeType)
      {
         case ZhiYeType.法师:
            damage *= FightController.S.法师伤害;
            break;
         case ZhiYeType.战士:
            damage *= FightController.S.战士伤害;
            break;
         case ZhiYeType.射手:
            damage *= FightController.S.射手伤害;
            break;
         case ZhiYeType.控制:
            damage *= FightController.S.控制伤害;
            break;
      }

      return damage;
   }

   public bool 暴击检测(HeroType heroType)
   {
      float random = Random.Range(0, 100);
      float value = 属性config.总属性.暴击率 * 100;
      value += FightController.S.英雄法器属性Dic[heroType].暴击率;
      if (瑶池冰辅助 > 0)
      {
         value += FightController.S.英雄法器属性Dic[HeroType.瑶池仙女].暴击率;
      }
      if (妲己黑暗辅助)
      {
         value += FightController.S.英雄法器属性Dic[HeroType.妲己].暴击率;
      }

      if (妲己神通)
      {
         value += HeroConfig.英雄神通配置Dic[HeroType.妲己].damage;
      }
      if (女娲电辅助)
      {
         value += FightController.S.英雄法器属性Dic[HeroType.女娲].暴击率;
      }
      if (heroType == HeroType.通天)
      {
         value += 英雄星级属性.Get通天暴击率()*100;
      }

      if (HeroConfig.HeroZhiYeDic[heroType].zhiYeType == ZhiYeType.法师)
      {
         value += 属性config.总属性.法师暴击率*100;
      }
      if (random <= value)
      {
         if (heroType == HeroType.通天)
         {
            FightController.S.通天暴击次数++;
         }
         return true;
      }
      else
      {
         return false;
      }
   }
   
   public bool 二次暴击检测(HeroType heroType)
   {
      float random = Random.Range(0, 500);
      float value = 属性config.总属性.暴击率 * 100;
      value += FightController.S.英雄法器属性Dic[heroType].暴击率;
      if (瑶池冰辅助 > 0)
      {
         value += FightController.S.英雄法器属性Dic[HeroType.瑶池仙女].暴击率;
      }
      if (妲己黑暗辅助)
      {
         value += FightController.S.英雄法器属性Dic[HeroType.妲己].暴击率;
      }
      if (女娲电辅助)
      {
         value += FightController.S.英雄法器属性Dic[HeroType.女娲].暴击率;
      }
      if (heroType == HeroType.通天)
      {
         value += 英雄星级属性.Get通天暴击率()*100;
      }

      if (HeroConfig.HeroZhiYeDic[heroType].zhiYeType == ZhiYeType.法师)
      {
         value += 属性config.总属性.法师暴击率*100;
      }
      if (random <= value)
      {
         if (heroType == HeroType.通天)
         {
            FightController.S.通天暴击次数++;
         }
         return true;
      }
      else
      {
         return false;
      }
   }

   public float Get道纹伤害(float 原始Damage, HeroType heroType)
   {
      if (heroType == HeroType.孙悟空)
      {
         原始Damage *= (1 + FightController.S.孙悟空每秒增加伤害Time * 属性config.总属性.孙悟空每秒增加伤害);
      }

      if (heroType == HeroType.云霄)
      {
         原始Damage *= 属性config.总属性.云霄最终伤害;
      }

      if (heroType == HeroType.后羿)
      {
         float 距离 =transform.position.x - (-5f);
         原始Damage *= (1+属性config.总属性.后羿距离增伤*距离);
      }
      if (heroType == HeroType.常羲)
      {
         float random = Random.Range(0, 100);
         if (random <= 属性config.总属性.常曦冻结概率 * 100f)
         {
            冰冻time += 1;
         }
      }

      if (heroType == HeroType.通天)
      {
         原始Damage *= (1 + 属性config.总属性.通天暴击增伤 * FightController.S.通天暴击次数);
      }

      if (heroType == HeroType.鸿钧)
      {
         原始Damage *= (1f + FightController.S.鸿钧陨石次数 * 属性config.总属性.鸿钧陨石增伤);
      }

      if (heroType == HeroType.盘古)
      {
         原始Damage *= (1f + FightController.S.盘古击杀次数 * 属性config.总属性.盘古击杀增伤);
      }

      return 原始Damage;
   }

   public float 计算法师功法暴击伤害(float damage, HeroType heroType)
   {
      if (HeroConfig.HeroZhiYeDic[heroType].zhiYeType == ZhiYeType.法师 &&
          PlayerData.S.HeroDataDic[heroType].功法Type != 功法Type.None)
      {
         float 暴击伤害 = 功法Config.功法属性Dic[PlayerData.S.HeroDataDic[heroType].功法Type].count;
         damage *= (1 + 暴击伤害 / 100f);
      }

      return damage;
   }
   
   public void Hurt(float 原始Damage,HeroType heroType,攻击特效Type 攻击特效)
   {
      // 高频字典查找全部缓存到本地变量（同一个 heroType 被查 7+ 次）
      var heroZhiYe = HeroConfig.HeroZhiYeDic[heroType];
      var hero法器 = FightController.S.英雄法器属性Dic[heroType];
      var hero根基丹药 = FightController.S.英雄根基丹药属性Dic[heroType];
      var yuanSu = heroZhiYe.yuanSuType;
      var zhiYe = heroZhiYe.zhiYeType;

      // 受击动画节流：高频受击时只在 > 0.1s 间隔内播放，避免动画系统 hammered
      float now = Time.time;
      if (now - 上次受击动画时间 > 0.1f)
      {
         上次受击动画时间 = now;
         受击Animation.Play("怪物受击",0,0f);
      }

      float 最终Damage = Math.Max(原始Damage - MonsterAttribute.Defense,0);
      bool 暴击 = 暴击检测(heroType);
      if (暴击)
      {
         最终Damage *= (属性config.总属性.暴击伤害/100f);
         if (妲己神通)
         {
            最终Damage *= (1f+HeroConfig.英雄神通配置Dic[HeroType.妲己].damage/100f);
         }
         最终Damage *= (1f+体质Config.当前体质总属性.暴击伤害/100f);
         最终Damage *= (1f+hero根基丹药.暴击伤害/100f);
         最终Damage=计算法师功法暴击伤害(最终Damage,heroType);
         最终Damage*=(1+hero法器.暴击伤害/100f);
         if (属性config.总属性.二次暴击 != 0)
         {
            bool 二次暴击=二次暴击检测(heroType);
            if (二次暴击)
            {
               最终Damage *= (属性config.总属性.暴击伤害/100f);
               if (妲己神通)
               {
                  最终Damage *= (1f+HeroConfig.英雄神通配置Dic[HeroType.妲己].damage/100f);
               }
               最终Damage *= (1f+体质Config.当前体质总属性.暴击伤害/100f);
               最终Damage *= (1f+hero根基丹药.暴击伤害/100f);
               最终Damage=计算法师功法暴击伤害(最终Damage,heroType);
               最终Damage*=(1+hero法器.暴击伤害/100f);
               if (瑶池冰辅助 > 0)
               {
                  最终Damage*=(1+FightController.S.英雄法器属性Dic[HeroType.瑶池仙女].暴击伤害/100f);
               }
               if (妲己黑暗辅助)
               {
                  最终Damage*=(1+FightController.S.英雄法器属性Dic[HeroType.妲己].暴击伤害/100f);
               }
               if (女娲电辅助)
               {
                  最终Damage*=(1+FightController.S.英雄法器属性Dic[HeroType.女娲].暴击伤害/100f);
               }
            }
         }
      }

      if (FightController.S.攻击特效是否神通(攻击特效)&&女娲神通)
      {
         最终Damage *= (1f+HeroConfig.英雄神通配置Dic[HeroType.女娲].damage/100f);
      }
      最终Damage *= (1f+PlayerData.S.轮回次数*属性config.总属性.轮回次数加伤);
      最终Damage *= 属性config.总属性.最终伤害增幅;
      最终Damage *= (1f + 体质Config.当前体质总属性.每道年增加伤害 / 100f * PlayerData.S.长生道体年数);
      最终Damage=计算功法伤害(最终Damage,heroType);
      最终Damage=计算轮回次数加伤害(最终Damage,heroType);
      最终Damage = 计算根基丹药伤害(最终Damage, heroType);
      最终Damage = 计算体质伤害(最终Damage, heroType);
      最终Damage = 计算体质辅助伤害(最终Damage, heroType);
      最终Damage=计算法器伤害(最终Damage,heroType,heroType);
      最终Damage = 计算丹药伤害(最终Damage, heroType);
      if (瑶池冰辅助 > 0)
      {
         最终Damage=计算法器伤害(最终Damage,heroType,HeroType.瑶池仙女);
      }
      if (妲己黑暗辅助)
      {
         最终Damage=计算法器伤害(最终Damage,heroType,HeroType.妲己);
      }
      if (女娲电辅助 )
      {
         最终Damage=计算法器伤害(最终Damage,heroType,HeroType.女娲);
      }
      最终Damage = Get道纹伤害(最终Damage, heroType);
      if (transform.position.x < -2 && zhiYe == ZhiYeType.战士)
      {
         最终Damage *= 属性config.总属性.战士对靠近城墙敌人伤害增高;
      }
      
      if (transform.position.x > 3.5f && zhiYe == ZhiYeType.射手)
      {
         最终Damage *= 属性config.总属性.射手对远距离敌人伤害增高;
      }

      if (FightController.S.城墙当前生命值 == 城墙Config.Get城墙最大生命值())
      {
         最终Damage *= 属性config.总属性.城墙满血时加伤害;
      }

      if (属性config.总属性.伤害在范围内浮动 != 0)
      {
         float random = Random.Range(0.8f, 1f+属性config.总属性.伤害在范围内浮动);
         最终Damage*=random;
      }

      switch (_怪物类型)
      {
         case MonsterType.Normal:
            最终Damage *= 属性config.总属性.普通怪伤害增幅;
            break;
         case MonsterType.Elite:
            最终Damage *= 属性config.总属性.精英怪伤害增幅;
            break;
         case MonsterType.Boss:
            最终Damage *= 属性config.总属性.首领伤害增幅;
            break;
      }
      最终Damage *= (1 + FightController.S.总杀怪增伤 / 100f);
      最终Damage = 元素伤害(最终Damage, yuanSu);
      最终Damage = 职业伤害(最终Damage, zhiYe);
      float 城墙血量比例 = FightController.S.城墙当前生命值 / 城墙Config.Get城墙最大生命值();
      if (城墙血量比例 < 城墙Config.低血量增伤血量值/100f)
      {
         最终Damage *= (1 +  城墙Config.低血量增伤值/ 100f);
      }

      if (城墙血量比例 <= 0.3f)
      {
         最终Damage *= 属性config.总属性.城墙低血增加伤害;
      }
      if (城墙血量比例 > 城墙Config.高血量增伤血量值/100f)
      {
         最终Damage *= (1 +  城墙Config.高血量增伤值/ 100f);
      }
      float 抗性 = 0;
      switch (yuanSu)
      {
         case YuanSuType.冰:
            抗性=MonsterAttribute.冰霜抗性;
            break;
         case YuanSuType.火:
            抗性=MonsterAttribute.火焰抗性;
            break;
         case YuanSuType.黑暗:
            抗性=MonsterAttribute.黑暗抗性;
            break;
         case YuanSuType.物理:
            抗性=MonsterAttribute.物理抗性;
            break;
         case YuanSuType.电:
            抗性=MonsterAttribute.雷电抗性;
            break;
      }
      抗性 = 计算法器抗性(抗性, heroType,heroType);
      if (瑶池冰辅助 > 0)
      {
         抗性 = 计算法器抗性(抗性, heroType,HeroType.瑶池仙女);
      }
      if (妲己黑暗辅助)
      {
         抗性 = 计算法器抗性(抗性, heroType,HeroType.妲己);
      }
      if (女娲电辅助 )
      {
         抗性 = 计算法器抗性(抗性, heroType,HeroType.女娲);
      }
      // 注意：抗性已由上面的 计算法器抗性（主英雄+瑶池/妲己/女娲辅助）逐步折减，
      // 不能再从 MonsterAttribute 原始值重新赋值，否则辅助英雄的穿透会被丢弃

      float 无视抗性 = 属性config.总属性.无视抗性 * 100;
      if (heroType == HeroType.哪吒)
      {
         无视抗性 += 属性config.总属性.三味真火无视抗性百分比*100;
      }
      // 无视抗性为百分值（与法器穿透口径一致），需 /100f，否则10%无视会变成抗性/11
      最终Damage *= (100 - 抗性/(1f+无视抗性/100f)) / 100;

      FightController.S.当前英雄伤害Dic[heroType].总伤害 += 最终Damage;
      if (FightController.S.攻击特效是否神通(攻击特效))
      {
         FightController.S.当前英雄伤害Dic[heroType].神通伤害 += 最终Damage;
      }
      else
      {
         FightController.S.当前英雄伤害Dic[heroType].技能伤害 += 最终Damage;
      }
      if (Time.time - _上次伤害数字时间 > 0.1f)
      {
         _上次伤害数字时间 = Time.time;
         FightController.S.Show伤害数字(PlayerData.S.格式化数字(最终Damage),yuanSu,伤害trans.position,is暴击:暴击);
      }
      float 受伤前血量 = CurrentHP;
      CurrentHP -= 最终Damage;
      MonsterSlider.gameObject.SetActive(true);
      MonsterSlider.maxValue = MonsterAttribute.Hp;
      MonsterSlider.value = CurrentHP;
      残影Slider.gameObject.SetActive(true);
      残影Slider.maxValue = MonsterAttribute.Hp;
      残影Slider.value = 受伤前血量;
      if (残影DOTween != null && 残影DOTween.IsActive()) 残影DOTween.Kill();
      残影DOTween = DOTween.To(() => 残影Slider.value,
         x => 残影Slider.value = x,
         CurrentHP,
         0.5f);
      if (CurrentHP <= 0)
      {
         Die(heroType);
      }
   }

   public float 计算法器抗性(float 抗性,HeroType heroType,HeroType 辅助)
   {
      switch (HeroConfig.HeroZhiYeDic[heroType].yuanSuType)
      {
         case YuanSuType.物理:
            //怪物抗性是0-100
            抗性 /= (1f+FightController.S.英雄法器属性Dic[辅助].物理穿透/100f);
            break;
         case YuanSuType.电:
            抗性 /= (1f+FightController.S.英雄法器属性Dic[辅助].雷电穿透/100f);
            break;
         case YuanSuType.冰:
            抗性 /= (1f+FightController.S.英雄法器属性Dic[辅助].冰霜穿透/100f);
            break;
         case YuanSuType.火:
            抗性 /= (1f+FightController.S.英雄法器属性Dic[辅助].火焰穿透/100f);
            break;
         case YuanSuType.黑暗:
            抗性 /=(1f+FightController.S.英雄法器属性Dic[辅助].黑暗穿透/100f);
            break;
      }

      return 抗性;
   }

   private void Update()
   {
      灼烧time-=Time.deltaTime;
      灼烧当前时间+=Time.deltaTime;
      冰冻time-=Time.deltaTime;
      冰符-=Time.deltaTime;
      瑶池冰辅助-=Time.deltaTime;
      龟丞相减速-=Time.deltaTime;
      黑暗符-=Time.deltaTime;
      灼烧obj.gameObject.SetActive(灼烧time>0);
      冰块.gameObject.SetActive(冰冻time>0);
      if (灼烧time > 0 && 灼烧当前时间 > 灼烧间隔)
      {
         灼烧当前时间 = 0;
         Hurt(灼烧伤害,HeroType.羲和,攻击特效Type.火符);
      }
      float 城墙最近距离 = _怪物攻击距离;
      CurrentAttackTime+=Time.deltaTime;

      if (_rb.position.x > 城墙最近距离)
      {
         if (黑暗符 <= 0&&冰冻time<0)
         {
            移动Animation.speed = 1;
            Vector3 pos = _rb.position;
            _rb.MovePosition(new Vector2(pos.x-RealSpeed*Time.deltaTime, pos.y));
         }
         else
         {
            移动Animation.speed = 0;
         }
      }
      else
      {
         if (CurrentAttackTime > 1f&&黑暗符 <= 0&&冰冻time<=0)
         {
            移动Animation.enabled = false;
            怪物攻击();
            CurrentAttackTime = Random.Range(0f,0.3f);
         }
      }
   }

   public void 怪物攻击()
   {
      攻击Animation.Play("怪物攻击",0,0f);
      ObserverModuleManager.S.SendEvent("围栏受击",MonsterAttribute.Attack,transform.position.y);
   }

   public IEnumerator Show胜利弹窗()
   {
      yield return new WaitForSeconds(1f);
      if (LevelConfig.当前关卡类型 == 关卡类型.主线关卡)
      {
          if (LevelConfig.当前主线关卡Type == PlayerData.S.最大主线关卡)
               {
                  if (LevelConfig.当前主线关卡Type == 主线关卡Type.混沌虚空)
                  {
                     if (PlayerData.S.混沌虚空最大层数 == LevelConfig.战斗混沌虚空层数)
                     {
                        PlayerData.S.关卡修炼速度加成 += LevelConfig.Get混沌虚空通关奖励(LevelConfig.战斗混沌虚空层数);
                     }
                  }
                  else
                  {
                     PlayerData.S.关卡修炼速度加成 += LevelConfig.主线关卡通关奖励Dic[LevelConfig.当前主线关卡Type];
                     PlayerData.S.最大主线关卡++;
                  }
                  
                  ObserverModuleManager.S.SendEvent("SendUIToast",$"恭喜解锁{LevelConfig.主线关卡NameDic[PlayerData.S.最大主线关卡]}");
               }
               if (LevelConfig.当前关卡类型==关卡类型.主线关卡&&LevelConfig.Is混沌虚空 && LevelConfig.战斗混沌虚空层数 == PlayerData.S.混沌虚空最大层数)
               {
                  PlayerData.S.混沌虚空最大层数++;
               }
      }
      Instantiate(Resources.Load("Prefabs/Window/胜利弹窗"));
   }

   public float 计算根基丹药伤害(float damage, HeroType heroType)
   {
      YuanSuType yuansu=HeroConfig.HeroZhiYeDic[heroType].yuanSuType;
      switch (yuansu)
      {
         case YuanSuType.冰:
            damage *= (1f + FightController.S.英雄根基丹药属性Dic[heroType].冰霜伤害 / 100f);
            break;
         case YuanSuType.火:
            damage *= (1f + FightController.S.英雄根基丹药属性Dic[heroType].火焰伤害 / 100f);
            break;
         case YuanSuType.黑暗:
            damage *= (1f + FightController.S.英雄根基丹药属性Dic[heroType].黑暗伤害 / 100f);
            break;
         case YuanSuType.电:
            damage *= (1f + FightController.S.英雄根基丹药属性Dic[heroType].雷电伤害 / 100f);
            break;
         case YuanSuType.物理:
            damage *= (1f + FightController.S.英雄根基丹药属性Dic[heroType].物理伤害 / 100f);
            break;
      }
      damage *= (1f + FightController.S.英雄根基丹药属性Dic[heroType].最终伤害 / 100f);
      return damage;
   }

   public float 计算体质伤害(float damage, HeroType heroType)
   {
      YuanSuType yuanSuType = HeroConfig.HeroZhiYeDic[heroType].yuanSuType;
      ZhiYeType zhiYeType=HeroConfig.HeroZhiYeDic[heroType].zhiYeType;
      damage*=(1f + 体质Config.当前体质总属性.最终伤害 / 100f);
      switch (zhiYeType)
      {
         case ZhiYeType.战士:
            damage *= (1f + 体质Config.当前体质总属性.战士伤害 / 100f);
            break;
         case ZhiYeType.射手:
            damage *= (1f + 体质Config.当前体质总属性.射手伤害 / 100f);
            break;
         case ZhiYeType.法师:
            damage *= (1f + 体质Config.当前体质总属性.法师伤害 / 100f);
            break;
         case ZhiYeType.控制:
            damage *= (1f + 体质Config.当前体质总属性.控制伤害 / 100f);
            break;
      }
      switch (yuanSuType)
      {
         case YuanSuType.冰:
            damage *= (1f + 体质Config.当前体质总属性.冰霜伤害 / 100f);
            break;
         case YuanSuType.电:
            damage *= (1f + 体质Config.当前体质总属性.雷电伤害 / 100f);
            break;
         case YuanSuType.火:
            damage *= (1f + 体质Config.当前体质总属性.火焰伤害 / 100f);
            break;
         case YuanSuType.物理:
            damage *= (1f + 体质Config.当前体质总属性.物理伤害 / 100f);
            break;
         case YuanSuType.黑暗:
            damage *= (1f + 体质Config.当前体质总属性.黑暗伤害 / 100f);
            break;
      }

      return damage;
   }

   public float 计算体质辅助伤害(float damage, HeroType heroType)
   {
      if (瑶池冰辅助 > 0)
      {
         damage *= (1f + 体质Config.当前体质总属性.辅助伤害 / 100f);
      }
      if (妲己黑暗辅助)
      {
         damage *= (1f + 体质Config.当前体质总属性.辅助伤害 / 100f);
      }
      if (女娲电辅助)
      {
         damage *= (1f + 体质Config.当前体质总属性.辅助伤害 / 100f);
      }
      return damage;
   }

   public float 计算轮回次数加伤害(float damage, HeroType heroType)
   {
      if(PlayerData.S.轮回次数==0)return  damage;
      float value=damage*PlayerData.S.轮回次数*(1f+体质Config.当前体质总属性.轮回次数加伤害/100f);
      return value;
   }
   public float 计算功法伤害(float damage,HeroType  heroType)
   {
      if (PlayerData.S.HeroDataDic[heroType].功法Type == 功法Type.None) return damage;
      int 功法等级 = PlayerData.S.HeroDataDic[heroType].功法等级;
      float 每重奖励 = 功法Config.功法升级最终伤害奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[heroType].功法Type]];

      damage *= (1 + 功法等级 * 每重奖励/ 100f*(1f+体质Config.当前体质总属性.功法每层效果/100f) );
      return damage;
   }

   public float 计算丹药伤害(float damage, HeroType heroType)
   {
      ZhiYeType zhiYeType = HeroConfig.HeroZhiYeDic[heroType].zhiYeType;
      YuanSuType yuanSuType=HeroConfig.HeroZhiYeDic[heroType].yuanSuType;
      switch (zhiYeType)
      {
         case ZhiYeType.战士:
            damage *= (1f + FightController.S.战士伤害 / 100f);
            break;
         case ZhiYeType.射手:
            damage *= (1f + FightController.S.射手伤害 / 100f);
            break;
         case ZhiYeType.法师:
            damage *= (1f + FightController.S.法师伤害 / 100f);
            break;
         case ZhiYeType.控制:
            damage *= (1f + FightController.S.控制伤害 / 100f);
            break;
      }

      switch (yuanSuType)
      {
         case YuanSuType.冰:
            damage *= (1f + FightController.S.冰霜伤害 / 100f);
            break;
         case YuanSuType.火:
            damage *= (1f + FightController.S.火焰伤害 / 100f);
            break;
         case YuanSuType.黑暗:
            damage *= (1f + FightController.S.黑暗伤害 / 100f);
            break;
         case YuanSuType.电:
            damage *= (1f + FightController.S.雷电伤害 / 100f);
            break;
         case YuanSuType.物理:
            damage *= (1f + FightController.S.物理伤害 / 100f);
            break;
      }

      return damage;
   }

   public float 计算法器伤害(float damage,HeroType  heroType,HeroType  辅助)
   {
      法器属性 法器属性 = FightController.S.英雄法器属性Dic[辅助];
      MonsterType monsterType = MonsterConfig.MonsterTypeDic[MonsterTypeName];
      YuanSuType yuansu = HeroConfig.HeroZhiYeDic[heroType].yuanSuType;
      switch (monsterType)
      {
         case MonsterType.Normal:
            damage*=(1+法器属性.普通怪增伤/100f);
            break;
         case MonsterType.Elite:
            damage*=(1+法器属性.精英怪增伤/100f);
            break;
         case MonsterType.Boss:
            damage*=(1+法器属性.首领怪增伤/100f);
            break;
      }
      switch (yuansu)
      {
         case YuanSuType.冰:
            damage*=(1+法器属性.冰霜伤害/100f);
            break;
         case YuanSuType.火:
            damage*=(1+法器属性.火焰伤害/100f);
            break;
         case YuanSuType.黑暗:
            damage*=(1+法器属性.黑暗伤害/100f);
            break;
         case YuanSuType.电:
            damage*=(1+法器属性.雷电伤害/100f);
            break;
         case YuanSuType.物理:
            damage*=(1+法器属性.物理伤害/100f);
            break;
      }

      damage *= (1 + 法器属性.最终伤害 / 100f);
      return damage;
   }
   
   public void 增加功法经验()
   {
      foreach (var item in PlayerData.S.出战英雄List[PlayerData.S.当前出战编队-1])
      {
         if (item == HeroType.None) return;
         if (PlayerData.S.HeroDataDic[item].功法Type != 功法Type.None)
         {
            PlayerData.S.HeroDataDic[item].功法经验+=(1f+体质Config.当前体质总属性.功法经验加成/100f);
            if (PlayerData.S.HeroDataDic[item].功法经验 >= 功法Config.Get功法升级经验(PlayerData.S.HeroDataDic[item].功法等级))
            {
               PlayerData.S.HeroDataDic[item].功法经验 -= 功法Config.Get功法升级经验(PlayerData.S.HeroDataDic[item].功法等级);
               PlayerData.S.HeroDataDic[item].功法等级++;
            }
         }
      }
   }

   public int 计算怪物总数(int 小怪数量, int 精英怪数量)
   {
      int 总数量 = 0;
      if (LevelConfig.当前关卡类型 == 关卡类型.主线关卡)
      {
         if (LevelConfig.当前主线关卡Type <= 主线关卡Type.水帘洞)
         {
            总数量 = 小怪数量;
         }else if (LevelConfig.当前主线关卡Type <= 主线关卡Type.五行山)
         {
            总数量 = 小怪数量+ 精英怪数量;
         }
         else
         {
            总数量 = 小怪数量+ 精英怪数量+1;
         }
      }
      else if (LevelConfig.当前关卡类型 == 关卡类型.洞天秘境)
      {
         if (PlayerData.S.当前轮回境界 < JingJieType.筑基)
         {
            总数量 = 小怪数量;
         }else if (PlayerData.S.当前轮回境界 < JingJieType.金丹)
         {
            总数量 = 小怪数量+ 精英怪数量;
         }
         else
         {
            总数量 = 小怪数量+ 精英怪数量+1;
         }
      }else if (LevelConfig.当前关卡类型 == 关卡类型.远古遗迹)
      {
         总数量 = 小怪数量+ 精英怪数量+1;
      }

      return 总数量;
   }
   public void Die(HeroType heroType)
   {
      if (isDead)
      {
         return;
      }
      isDead = true;
      ObserverModuleManager.S.SendEvent("播放怪物音效",战斗音效Type.怪物死亡);
      增加功法经验();
      if (heroType == HeroType.盘古)
      {
         FightController.S.盘古击杀次数++;
      }
      FightController.S.总杀怪增伤 += 城墙Config.杀怪增伤数值;
      if (城墙Config.杀怪回血数值 > 0)
      {
         int value = (int)(城墙Config.杀怪回血数值 / 100f * 城墙Config.Get城墙最大生命值());
         FightController.S.城墙当前生命值=Math.Min(城墙Config.Get城墙最大生命值(),FightController.S.城墙当前生命值+value);
         FightController.S.Show伤害数字(PlayerData.S.格式化数字(value),YuanSuType.None,new Vector2(-5,0),true);
      }
      ObserverModuleManager.S.SendEvent("怪物死亡",this);
      FightController.S.KillMonsterCount++;
      int 小怪数量 = 100;
      int 精英怪数量 = 2;
      if (LevelConfig.当前关卡类型 == 关卡类型.主线关卡)
      {
         小怪数量 = LevelConfig.LevelInfos[LevelConfig.当前主线关卡Type].NormalMonsterCount;
         精英怪数量 = LevelConfig.LevelInfos[LevelConfig.当前主线关卡Type].EliteMonsterCount;
      }else if (LevelConfig.当前关卡类型 == 关卡类型.洞天秘境)
      {
         小怪数量 = LevelConfig.洞天LevelInfos[new 洞天关卡Item(){JingJieType = PlayerData.S.当前轮回境界,qualityType = LevelConfig.当前洞天QualityType}].NormalMonsterCount;
         精英怪数量 = LevelConfig.洞天LevelInfos[new 洞天关卡Item() { JingJieType = PlayerData.S.当前轮回境界, qualityType = LevelConfig.当前洞天QualityType }].EliteMonsterCount;
      }else if (LevelConfig.当前关卡类型 == 关卡类型.远古遗迹)
      {
         小怪数量 = 神物Config.遗迹关卡信息Dic[LevelConfig.当前神物Type].NormalMonsterCount;
         精英怪数量 = 神物Config.遗迹关卡信息Dic[LevelConfig.当前神物Type].EliteMonsterCount;
      }
      if (SceneManager.GetActiveScene().name=="FightScene"&&FightController.S.KillMonsterCount == 小怪数量/2)
      {
         FightController.S.CreateBossMonster();
      }
      for (int i = 1; i <= 精英怪数量; i++)
      {
         if (SceneManager.GetActiveScene().name=="FightScene"&&FightController.S.KillMonsterCount == (int)(小怪数量 * (i / (精英怪数量 + 1f))))
         {
            FightController.S.CreateEliteMonster();
         }
      }

      float 总数量 = 0;
      总数量 = 计算怪物总数(小怪数量, 精英怪数量);
      
      ObserverModuleManager.S.SendEvent("刷新关卡进度",FightController.S.KillMonsterCount/总数量);
      if (FightController.S.KillMonsterCount == 总数量)
      {
         FightController.S.战斗结束 = true;
         FightController.S.StartCoroutine(Show胜利弹窗());
      }
      MonsterType monsterType = MonsterConfig.MonsterTypeDic[MonsterTypeName];
      switch (monsterType)
      {
         case MonsterType.Normal:
            var 普通怪死亡 = QueueController.S.普通怪死亡Queue.Dequeue();
            普通怪死亡.gameObject.transform.position = transform.position;
            普通怪死亡.order=(int)(transform.position.y * -100);
            普通怪死亡.gameObject.SetActive(true);
            QueueController.S.普通怪Queue.Enqueue(this as 普通怪);
            break;
         case MonsterType.Elite:
            FightController.S.城墙当前生命值 += 属性config.总属性.击杀精英怪城墙回血 * 城墙Config.Get城墙最大生命值();
            FightController.S.城墙当前生命值 = Math.Min(城墙Config.Get城墙最大生命值(), FightController.S.城墙当前生命值);
            ObserverModuleManager.S.SendEvent("设置护盾");
            var 精英怪死亡 = QueueController.S.精英怪死亡Queue.Dequeue();
            精英怪死亡.gameObject.transform.position = transform.position;
            精英怪死亡.order=(int)(transform.position.y * -100);
            精英怪死亡.gameObject.SetActive(true);
            QueueController.S.精英怪Queue.Enqueue(this as 精英怪);
            break;
         case MonsterType.Boss:
            var 首领怪死亡 = QueueController.S.首领怪死亡Queue.Dequeue();
            首领怪死亡.gameObject.transform.position = transform.position;
            首领怪死亡.order=(int)(transform.position.y * -100);
            首领怪死亡.gameObject.SetActive(true);
            QueueController.S.首领怪Queue.Enqueue(this as 首领怪);
            break;
      }
      FightController.S.当前怪物Set.Remove(this);
      for (int i = 1; i <= 7; i++)
      {
         FightController.S.Monster分区Dic[i].Remove(this);
      }
      gameObject.SetActive(false);
   }
}
