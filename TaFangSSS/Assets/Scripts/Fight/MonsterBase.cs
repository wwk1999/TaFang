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

public class 灼烧
{
   public float 灼烧Time;
   public float 灼烧伤害;
   public float 灼烧当前时间;
   public int 灼烧层数;
}
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
   [NonSerialized]public float 易电time = 0;
   [NonSerialized]public float 易电伤害 = 0;
   [NonSerialized]public float 黑暗印记层数 = 0;
   [NonSerialized]public float 黑暗印记伤害 = 0;
   [NonSerialized]public float 怪物真实护甲 = 0;
   
   [NonSerialized]public Dictionary<HeroType,int>英雄攻击次数=new Dictionary<HeroType,int>();


   [NonSerialized] public Dictionary<HeroType, 灼烧> 英雄灼烧状态 = new Dictionary<HeroType, 灼烧>()
   {
      { HeroType.月老, new 灼烧() },
      { HeroType.哪吒, new 灼烧() },
      { HeroType.羲和, new 灼烧() },
      { HeroType.元始, new 灼烧() },
      { HeroType.鸿钧, new 灼烧() },
   };
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
   private int 异常状态个数 = 0;
   private float RealSpeed => GetRealSpeed();
   [NonSerialized] public float 瑶池冰辅助=0;//这里有bug，判断技能树的被辅助英雄的时候，没有被瑶池辅助的英雄的伤害也会被计算，因为不是实时更新
   [NonSerialized] public bool 女娲电辅助;//每次攻击怪物的时候都会先改变这些辅助状态，然后再计算
   [NonSerialized] public bool 妲己黑暗辅助;
   [NonSerialized] public bool 妲己神通;
   [NonSerialized] public bool 女娲神通;
   [NonSerialized] public float 龟丞相减速=0;
   [NonSerialized] public float 黑暗符=0;
   [NonSerialized]public bool isDead=false;
   [NonSerialized] public float 冰符=0;
   // 残影血条：手动插值替代每次受击 new DOTween（AOE 时零堆分配），观感与原 0.5s 线性追赶一致
   private bool _残影激活;
   private float _残影起始值;
   private float _残影目标值;
   private float _残影计时;
   // 主血条 0.1s 节流刷新：Hurt 只扣 CurrentHP + 置脏，Slider 赋值统一在 Update 做
   private bool _血条脏;
   private float _血条刷新计时;
   private const float _残影持续时间 = 0.5f;
   private const float _血条刷新间隔 = 0.1f;
   // 聚合法器每怪复用一份，避免每次受击 new 法器属性
   private readonly 法器属性 _聚合法器复用 = new 法器属性();
   // 当前 Hurt 的英雄静态数据缓存（职业/技能树/符文/法器/丹药引用），Hurt 入口赋值，各伤害子方法共用
   private 英雄战斗缓存 _ctx;
   private int 黑暗符次数 = 0;
   private Rigidbody2D _rb;
   private MonsterType _怪物类型;
   private float _怪物攻击距离;
   private float _上次伤害数字时间;
   private float 上次受击动画时间 = 0;

   [NonSerialized] public float 冰元素减速 = 0;//多次减速取最大值
   [NonSerialized] public float 冰元素减速时间 = 0;
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
         value*=(1f-FightController.S.英雄技能树属性[HeroType.瑶池仙女].瑶池减速效果/100f);
      }

      if (冰元素减速 > 0)
      {
         value *= (1-冰元素减速/100f);
      }
      if (冰符 > 0)
      {
         value *= (1-英雄星级属性.常曦减速效果/100f);
      }
      if (龟丞相减速 > 0)
      {
         value *= (1-英雄星级属性.龟丞相减速效果/100f);
         value*=(1f-FightController.S.英雄技能树属性[HeroType.龟丞相].龟丞相减速/100f);

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

      foreach (var item in 英雄灼烧状态)
      {
         item.Value.灼烧伤害 = 0;
         item.Value.灼烧层数 = 0;
         item.Value.灼烧当前时间 = 0;
         item.Value.灼烧Time = 0;
      }
      英雄攻击次数.Clear();
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
      // maxValue 只设一次；两条都先对齐全血，保证首次受击残影从满血开始追（原逻辑首帧残影 value 是陈旧值）
      MonsterSlider.maxValue = MonsterAttribute.Hp;
      残影Slider.maxValue = MonsterAttribute.Hp;
      MonsterSlider.value = CurrentHP;
      残影Slider.value = CurrentHP;
      _血条脏 = false;
      _血条刷新计时 = 0f;
      _残影激活 = false;
      _残影计时 = 0f;
      image.sprite = ResourcesConfig.GetMonsterSprite(MonsterTypeName);
      foreach (var item in 英雄灼烧状态)
      {
         item.Value.灼烧Time = 0;
         item.Value.灼烧伤害 = 0;
         item.Value.灼烧层数 = 0;
      }

      冰冻time = 0;
      冰元素减速 = 0;
      冰元素减速时间 = 0;
      易电伤害 = 0;
      易电time = 0;
      黑暗印记伤害 = 0;
      黑暗印记层数 = 0;
      怪物真实护甲 = MonsterAttribute.Defense;
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
      }if (LevelConfig.当前关卡类型 == 关卡类型.符文之地)
      {
         MonsterAttribute = Get符文之地怪物属性(monsterType);
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
   
   public MonsterAttribute Get符文之地怪物属性(MonsterType monsterType)
   {
      MonsterAttribute 基础属性 = 符文之地Config.符文之地关卡怪物属性Dic[new 符文之地关卡怪物Item(){符文之地Type = LevelConfig.当前符文之地Type,MonsterType = monsterType}];
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
      float value = FightController.S.领主暴击率 * 100;
      value += _ctx.法器.暴击率;
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

      if (_ctx.职业.zhiYeType == ZhiYeType.法师)
      {
         value += 属性config.总属性.法师暴击率*100;
      }

      value += _ctx.技能树.暴击率;
      if (瑶池冰辅助 > 0)
      {
         value += FightController.S.英雄技能树属性[HeroType.瑶池仙女].被辅助英雄暴击率 ;
      }
      if (妲己黑暗辅助||妲己神通)
      {
         value += FightController.S.英雄技能树属性[HeroType.妲己].被辅助英雄暴击率 ;
      }
      if (女娲电辅助||女娲神通)
      {
         value += FightController.S.英雄技能树属性[HeroType.女娲].被辅助英雄暴击率 ;
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
      float value = FightController.S.领主暴击率 * 100;
      value += _ctx.法器.暴击率;
      if (瑶池冰辅助 > 0)
      {
         value += FightController.S.英雄法器属性Dic[HeroType.瑶池仙女].暴击率;
      }
      value += _ctx.技能树.暴击率;

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

      if (_ctx.职业.zhiYeType == ZhiYeType.法师)
      {
         value += 属性config.总属性.法师暴击率*100;
      }
      if (瑶池冰辅助 > 0)
      {
         value += FightController.S.英雄技能树属性[HeroType.瑶池仙女].被辅助英雄暴击率 ;
      }
      if (妲己黑暗辅助||妲己神通)
      {
         value += FightController.S.英雄技能树属性[HeroType.妲己].被辅助英雄暴击率 ;
      }
      if (女娲电辅助||女娲神通)
      {
         value += FightController.S.英雄技能树属性[HeroType.女娲].被辅助英雄暴击率 ;
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
      if (_ctx.职业.zhiYeType == ZhiYeType.法师 &&
          PlayerData.S.HeroDataDic[heroType].功法Type != 功法Type.None)
      {
         float 暴击伤害 = 功法Config.功法属性Dic[PlayerData.S.HeroDataDic[heroType].功法Type].count;
         damage *= (1 + 暴击伤害 / 100f);
      }

      return damage;
   }

   public float 计算符文伤害(float damage, HeroType heroType, 攻击特效Type 攻击特效)
   {
      bool 是否神通 = FightController.S.攻击特效是否神通(攻击特效);
      YuanSuType yuansu = _ctx.职业.yuanSuType;
      ZhiYeType zhiye = _ctx.职业.zhiYeType;

      switch (yuansu)
      {
         case YuanSuType.冰:
            damage *= (1f + _ctx.符文.冰同气连枝 * FightController.S.出战元素个数[YuanSuType.冰] / 100f);
            break;
         case YuanSuType.黑暗:
            damage *= (1f + _ctx.符文.黑暗同气连枝 * FightController.S.出战元素个数[YuanSuType.黑暗] / 100f);
            break;
         case YuanSuType.火:
            damage *= (1f + _ctx.符文.火同气连枝 * FightController.S.出战元素个数[YuanSuType.火] / 100f);
            break;
         case YuanSuType.电:
            damage *= (1f + _ctx.符文.雷电同气连枝 * FightController.S.出战元素个数[YuanSuType.电] / 100f);
            break;
         case YuanSuType.物理:
            damage *= (1f + _ctx.符文.物理同气连枝 * FightController.S.出战元素个数[YuanSuType.物理] / 100f);
            break;
      }

      switch (zhiye)
      {
         case ZhiYeType.射手:
            damage *= (1f + _ctx.符文.射手同气连枝 * FightController.S.出战职业个数[ZhiYeType.射手] / 100f);
            break;
         case ZhiYeType.控制:
            damage *= (1f + _ctx.符文.控制同气连枝 * FightController.S.出战职业个数[ZhiYeType.控制] / 100f);
            break;
         case ZhiYeType.法师:
            damage *= (1f + _ctx.符文.法师同气连枝 * FightController.S.出战职业个数[ZhiYeType.法师] / 100f);
            break;
         case ZhiYeType.战士:
            damage *= (1f + _ctx.符文.战士同气连枝 * FightController.S.出战职业个数[ZhiYeType.战士] / 100f);
            break;
      }
      damage *= (1f + _ctx.符文.辅助同气连枝 * FightController.S.出战职业个数[ZhiYeType.辅助] / 100f);

      if (_ctx.符文.技能伤害减少神通伤害增加 > 0)
      {
         if (是否神通)
         {
            damage*=(1f+_ctx.符文.技能伤害减少神通伤害增加/100f);
         }
         else
         {
            damage /= 2;
         }
      }

      if (_ctx.符文.技能伤害增加不能释放神通 > 0)
      {
         if (!是否神通)
         {
            damage*=(1f+_ctx.符文.技能伤害增加不能释放神通/100f);
         }
      }

      if (英雄攻击次数[heroType] == 1)
      {
         damage*=(1f+_ctx.符文.对怪物的第一次伤害增加/100f);
      }
      damage*=(1f+_ctx.符文.对怪物攻击次数越多越加伤害*英雄攻击次数[heroType]/100f);
      damage*=(1f+FightController.S.献祭英雄增加伤害[FightController.S.出战英雄编号[heroType]]/100f);
      if (FightController.S.英雄辅助印记数量.ContainsKey(heroType))
      {
         damage*=(1f+FightController.S.英雄辅助印记数量[heroType]*_ctx.符文.辅助印记增伤/100f);
      }
      damage*=(1f+_ctx.符文.元素每有一个不同增伤*FightController.S.不同元素个数/100f);
      damage*=(1f+_ctx.符文.职业每有一个不同增伤*FightController.S.不同职业个数/100f);

      if (怪物真实护甲 == 0)
      {
         damage*=(1f+_ctx.符文.碎甲为0时加伤害/100f);
      }

      if (英雄灼烧状态.ContainsKey(heroType))
      {
         damage*=(1f+_ctx.符文.每层火焰灼烧加伤*英雄灼烧状态[heroType].灼烧层数/100f);
      }
      damage*=(1f+_ctx.符文.每层黑暗印记加伤*黑暗印记层数/100f);

      if (yuansu == YuanSuType.电 && 易电time > 0)
      {
         damage*=(1f+_ctx.符文.雷属性打易电状态加伤害/100f);
      }
      damage*=(1f+_ctx.符文.每有一个异常状态增伤*异常状态个数/100f);
      damage*=(1f+_ctx.符文.清除异常状态增伤/100f);

      if (异常状态个数 == 0)
      {
         damage*=(1f+_ctx.符文.没有异常状态增伤/100f);
      }
      damage *= (1f + _ctx.符文.取消冰冻每冰冻概率增伤 * _ctx.技能树.冰概率冰冻 /
         100f);
      return damage;
   }
   public float 计算技能树伤害(float damage, HeroType heroType,攻击特效Type 攻击特效)
   {
      YuanSuType yuansu = _ctx.职业.yuanSuType;
      bool 是否神通 = FightController.S.攻击特效是否神通(攻击特效);
      技能树属性 技能树属性 = _ctx.技能树;
      damage*=(1+技能树属性.英雄伤害/100f);
      
      if (是否神通)
      {
         damage *= (1f + _ctx.技能树.神通伤害 / 100f);
      }
      else
      {
         damage *= (1f + _ctx.技能树.技能伤害 / 100f);
      }

      switch (yuansu)
      {
         case YuanSuType.冰:
            damage *= (1f + _ctx.技能树.冰霜伤害 / 100f);
            break;
         case YuanSuType.物理:
            damage *= (1f + _ctx.技能树.物理伤害 / 100f);
            break;
         case YuanSuType.电:
            damage *= (1f + _ctx.技能树.雷电伤害 / 100f);
            break;
         case YuanSuType.黑暗:
            damage *= (1f + _ctx.技能树.黑暗伤害 / 100f);
            break;
         case YuanSuType.火:
            damage *= (1f + _ctx.技能树.火焰伤害 / 100f);
            break;
      }
      float 被辅助伤害 = 1;
      if (瑶池冰辅助 > 0)
      {
         switch (MonsterConfig.MonsterTypeDic[MonsterTypeName])
         {
            case MonsterType.Normal:
               被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.瑶池仙女].被辅助英雄普通怪伤害 / 100f);
               break;
            case MonsterType.Elite:
               被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.瑶池仙女].被辅助英雄精英怪伤害 / 100f);
               break;
            case MonsterType.Boss:
               被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.瑶池仙女].被辅助英雄首领怪伤害 / 100f);
               break;
         }

         if (!是否神通)
         {
            被辅助伤害 += FightController.S.英雄技能树属性[HeroType.瑶池仙女].被辅助英雄技能伤害 / 100f;
         }
         被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.瑶池仙女].被辅助英雄伤害 / 100f);
         被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.瑶池仙女].被辅助元素伤害 / 100f);
      }
      if (妲己黑暗辅助||妲己神通)
      {
         
         switch (MonsterConfig.MonsterTypeDic[MonsterTypeName])
         {
            case MonsterType.Normal:
               被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.妲己].被辅助英雄普通怪伤害 / 100f);
               break;
            case MonsterType.Elite:
               被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.妲己].被辅助英雄精英怪伤害 / 100f);
               break;
            case MonsterType.Boss:
               被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.妲己].被辅助英雄首领怪伤害 / 100f);
               break;
         }
         if (!是否神通)
         {
            被辅助伤害 += FightController.S.英雄技能树属性[HeroType.妲己].被辅助英雄技能伤害 / 100f;
         }
         被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.妲己].被辅助英雄伤害 / 100f);
         被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.妲己].被辅助元素伤害 / 100f);

      }
      if (女娲电辅助||女娲神通)
      {
         switch (MonsterConfig.MonsterTypeDic[MonsterTypeName])
         {
            case MonsterType.Normal:
               被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.女娲].被辅助英雄普通怪伤害 / 100f);
               break;
            case MonsterType.Elite:
               被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.女娲].被辅助英雄精英怪伤害 / 100f);
               break;
            case MonsterType.Boss:
               被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.女娲].被辅助英雄首领怪伤害 / 100f);
               break;
         }
         if (!是否神通)
         {
            被辅助伤害 += FightController.S.英雄技能树属性[HeroType.女娲].被辅助英雄技能伤害 / 100f;
         }
         被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.女娲].被辅助英雄伤害 / 100f);
         被辅助伤害 += (FightController.S.英雄技能树属性[HeroType.女娲].被辅助元素伤害 / 100f);
      }

      damage *= 被辅助伤害;
      return damage;
   }

   
   
   // 受击扣血：只改 CurrentHP + 置脏 + 启动残影，不直接刷主 Slider（0.1s 节流在 Update 统一做）；
   // 残影从当前显示值追向新血量，连续 AOE 时平滑下拖不跳变；死亡判定仍由各调用处立即执行
   private void 受击扣血(float damage)
   {
      CurrentHP -= damage;
      MonsterSlider.gameObject.SetActive(true);
      _血条脏 = true;
      if (!_残影激活) 残影Slider.gameObject.SetActive(true);
      _残影激活 = true;
      _残影起始值 = 残影Slider.value;
      _残影目标值 = CurrentHP;
      _残影计时 = 0f;
   }

   public void Hurt(float 原始Damage,HeroType heroType,攻击特效Type 攻击特效)
   {
      // 高频字典查找全部缓存到本地变量（同一个 heroType 被查 7+ 次）；
      // 职业/技能树/符文/法器/丹药整场战斗不变，走英雄战斗缓存（首次命中懒加载，之后只是一次字典 TryGetValue）
      _ctx = FightController.S.Get英雄战斗缓存(heroType);
      var heroZhiYe = _ctx.职业;
      var hero法器 = _ctx.法器;
      var hero根基丹药 = _ctx.根基丹药;
      var yuanSu = heroZhiYe.yuanSuType;
      var zhiYe = heroZhiYe.zhiYeType;
      if (英雄攻击次数.ContainsKey(heroType))
      {
         英雄攻击次数[heroType]++;
      }
      else
      {
         英雄攻击次数[heroType] = 1;
      }

      // 受击动画节流：高频受击时只在 > 0.1s 间隔内播放，避免动画系统 hammered
      float now = Time.time;
      if (now - 上次受击动画时间 > 0.1f)
      {
         上次受击动画时间 = now;
         受击Animation.Play("怪物受击",0,0f);
      }

      //冰元素减速冰冻
      if (_ctx.技能树.冰减速*(1f+_ctx.符文.冰减速效果/100f) > 冰元素减速)
      {
         冰元素减速 = _ctx.技能树.冰减速*(1f+_ctx.符文.冰减速效果/100f);
         冰元素减速时间 = 2;
      }
      if (_ctx.技能树.冰概率冰冻 > 0&&_ctx.符文.取消冰冻每冰冻概率增伤==0)
      {
         float random=Random.Range(0,100);
         if (random < _ctx.技能树.冰概率冰冻)
         {
            冰冻time = 1f + _ctx.技能树.冰冻时间;
         }
      }
      
      //易电
      if (_ctx.技能树.易电状态概率 > 0&&_ctx.技能树.易电状态伤害+30 > 易电伤害)
      {
         float random=Random.Range(0,100);
         if (random < _ctx.技能树.易电状态概率)
         {
            易电伤害 = _ctx.技能树.易电状态伤害 + 30;
            易电time=_ctx.技能树.易电状态时间 + 2;
         }
      }

      if (_ctx.技能树.物理碎甲怪物百分比 > 0)
      {
         怪物真实护甲 -= MonsterAttribute.Defense * _ctx.技能树.物理碎甲怪物百分比*(1f+_ctx.符文.加强碎甲效果/100f) / 100f;
         怪物真实护甲 = Math.Max(0, 怪物真实护甲);
      }
      if (_ctx.技能树.物理碎甲领主攻击百分比 > 0)
      {
         怪物真实护甲 -= FightController.S.领主总攻击力 * _ctx.技能树.物理碎甲领主攻击百分比*(1f+_ctx.符文.加强碎甲效果/100f) / 100f;
         怪物真实护甲 = Math.Max(0, 怪物真实护甲);
      }

      float 最终Damage = Math.Max(原始Damage - 怪物真实护甲,0);
      最终Damage *= (1f + FightController.S.技能树总所有英雄伤害 / 100f);
      if (怪物真实护甲 == 0)
      {
         最终Damage *= (1f + _ctx.技能树.物理无抗性加伤害 / 100f);
      }
      if (冰冻time > 0)
      {
         最终Damage *= (1f+_ctx.技能树.冰冻增伤/100f);
      }
      最终Damage *= (1f+易电伤害*(1f+_ctx.符文.增强易电效果/100f)/100f);
      最终Damage=计算技能树伤害(最终Damage,heroType,攻击特效);
      最终Damage=计算符文伤害(最终Damage,heroType,攻击特效);

      bool 暴击 = 暴击检测(heroType);
      if (暴击)
      {
         最终Damage *= (属性config.总属性.暴击伤害/100f);
         if (妲己神通)
         {
            最终Damage *= (1f+HeroConfig.英雄神通配置Dic[HeroType.妲己].damage/100f);
         }
         最终Damage *= (1f+_ctx.技能树.暴击伤害/100f);
         最终Damage *= (1f+FightController.S.缓存体质总属性.暴击伤害/100f);
         最终Damage *= (1f+hero根基丹药.暴击伤害/100f);
         最终Damage=计算法师功法暴击伤害(最终Damage,heroType);
         最终Damage*=(1+hero法器.暴击伤害/100f);
         float 被辅助暴击伤害 = 1;
         if (瑶池冰辅助 > 0)
         {
            被辅助暴击伤害 += FightController.S.英雄技能树属性[HeroType.瑶池仙女].被辅助英雄暴击伤害/100f ;
         }
         if (妲己黑暗辅助||妲己神通)
         {
            被辅助暴击伤害 += FightController.S.英雄技能树属性[HeroType.妲己].被辅助英雄暴击伤害 / 100f;
         }
         if (女娲电辅助||女娲神通)
         {
            被辅助暴击伤害 += FightController.S.英雄技能树属性[HeroType.女娲].被辅助英雄暴击伤害 / 100f;
         }

         最终Damage *= 被辅助暴击伤害;
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
               最终Damage *= 被辅助暴击伤害;
               最终Damage *= (1f+_ctx.技能树.暴击伤害/100f);
               最终Damage *= (1f+FightController.S.缓存体质总属性.暴击伤害/100f);
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
         最终Damage *= (1f+HeroConfig.英雄神通配置Dic[HeroType.女娲].damage/100f*(1f+FightController.S.英雄技能树属性[HeroType.女娲].女娲神通效果/100f));
      }
      最终Damage *= (1f+PlayerData.S.轮回次数*属性config.总属性.轮回次数加伤);
      最终Damage *= 属性config.总属性.最终伤害增幅;
      最终Damage *= (1f + FightController.S.缓存体质总属性.每道年增加伤害 / 100f * PlayerData.S.长生道体年数);
      最终Damage=计算功法伤害(最终Damage,heroType);
      最终Damage=计算轮回次数加伤害(最终Damage,heroType);
      最终Damage = 计算根基丹药伤害(最终Damage, heroType);
      最终Damage = 计算体质伤害(最终Damage, heroType);
      最终Damage = 计算体质辅助伤害(最终Damage, heroType);
      // 主英雄法器+在场辅助法器聚合成一份（字段相加），伤害只乘一次、穿透只除一次，不再连乘
      法器属性 聚合法器 = 获取聚合法器属性(heroType);
      最终Damage=计算法器伤害(最终Damage,heroType,聚合法器);
      最终Damage = 计算丹药伤害(最终Damage, heroType);
      最终Damage = Get道纹伤害(最终Damage, heroType);
      if (transform.position.x < -2 && zhiYe == ZhiYeType.战士)
      {
         最终Damage *= 属性config.总属性.战士对靠近城墙敌人伤害增高;
      }
      
      if (transform.position.x > 3.5f && zhiYe == ZhiYeType.射手)
      {
         最终Damage *= 属性config.总属性.射手对远距离敌人伤害增高;
      }

      if (FightController.S.城墙当前生命值 == FightController.S.缓存城墙最大生命值)
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
            最终Damage *= (1f+_ctx.技能树.普通怪增伤/100f);
            break;
         case MonsterType.Elite:
            最终Damage *= 属性config.总属性.精英怪伤害增幅;
            最终Damage *= (1f+_ctx.技能树.精英怪增伤/100f);
            break;
         case MonsterType.Boss:
            最终Damage *= 属性config.总属性.首领伤害增幅;
            最终Damage *= (1f+_ctx.技能树.首领怪增伤/100f);
            break;
      }
      最终Damage *= (1 + FightController.S.总杀怪增伤 / 100f);
      最终Damage = 元素伤害(最终Damage, yuanSu);
      最终Damage = 职业伤害(最终Damage, zhiYe);
      float 城墙血量比例 = FightController.S.城墙当前生命值 / FightController.S.缓存城墙最大生命值;
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
      // 穿透已按主英雄+在场辅助相加聚合，抗性只折减一次，不能再从 MonsterAttribute 原始值重新赋值
      抗性 = 计算法器抗性(抗性, heroType, 聚合法器);

      float 无视抗性 = 属性config.总属性.无视抗性 * 100;
      if (heroType == HeroType.哪吒)
      {
         无视抗性 += 属性config.总属性.三味真火无视抗性百分比*100;
      }
      // 无视抗性为百分值（与法器穿透口径一致），需 /100f，否则10%无视会变成抗性/11
      最终Damage *= (100 - 抗性/(1f+无视抗性/100f)) / 100;

      if (_ctx.符文.清除异常状态增伤 > 0)
      {
         清除异常();
      }
      
      
      //黑暗印记
      if (_ctx.技能树.黑暗印记储存伤害 > 0)
      {
         int 黑暗层数 = 5 + (int)_ctx.技能树.黑暗印记增加引爆层数 - (int)_ctx.技能树.黑暗印记减少引爆层数;
         if (黑暗印记层数 >= 黑暗层数)
         {
            黑暗印记层数 = 0;
            FightController.S.当前英雄伤害Dic[heroType].总伤害 += 黑暗印记伤害;
            FightController.S.当前英雄伤害Dic[heroType].技能伤害 += 黑暗印记伤害;
            FightController.S.Show伤害数字(PlayerData.S.格式化数字(黑暗印记伤害),YuanSuType.黑暗,伤害trans.position,is暴击:false);
            受击扣血(黑暗印记伤害);
            if (CurrentHP <= 0)
            {
               Die(heroType);
            }

            if (_ctx.符文.引爆时造成范围爆炸 > 0 && QueueController.S.黑暗印记爆炸Queue.Count > 0)
            {
               var 黑暗印记爆炸 = QueueController.S.黑暗印记爆炸Queue.Dequeue();
               黑暗印记爆炸.transform.position = transform.position;
               黑暗印记爆炸.damage = 黑暗印记伤害*(1f+_ctx.符文.引爆时造成范围爆炸/100f);
               黑暗印记爆炸.HeroType = heroType;
               黑暗印记爆炸.gameObject.SetActive(true);
            }
            黑暗印记伤害 = 0;
         }
         else
         {
            黑暗印记层数++;
            黑暗印记伤害 += 最终Damage * _ctx.技能树.黑暗印记储存伤害 / 100f;
         }
      }
      
      英雄灼烧( 最终Damage,heroType);
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
      受击扣血(最终Damage);
      if (CurrentHP <= 0)
      {
         Die(heroType);
      }
   }

   public void 英雄灼烧(float 最终Damage,HeroType  heroType)
   {
      if (heroType == HeroType.月老)
      {
         if (英雄灼烧状态[HeroType.月老].灼烧层数 < FightController.S.英雄技能树属性[HeroType.月老].火焰灼烧最大层数 + 1)
         {
            英雄灼烧状态[HeroType.月老].灼烧伤害 += 最终Damage*FightController.S.英雄技能树属性[HeroType.月老].火焰灼烧伤害/100f;
            英雄灼烧状态[HeroType.月老].灼烧Time = 2 + FightController.S.英雄技能树属性[HeroType.月老].火焰灼烧时间;
            英雄灼烧状态[HeroType.月老].灼烧层数++;
         }
      }
      
      if (heroType == HeroType.哪吒)
      {
         if (英雄灼烧状态[HeroType.哪吒].灼烧层数 < FightController.S.英雄技能树属性[HeroType.哪吒].火焰灼烧最大层数 + 1)
         {
            英雄灼烧状态[HeroType.哪吒].灼烧伤害 += 最终Damage*FightController.S.英雄技能树属性[HeroType.哪吒].火焰灼烧伤害/100f;
            英雄灼烧状态[HeroType.哪吒].灼烧Time = 2 + FightController.S.英雄技能树属性[HeroType.哪吒].火焰灼烧时间;
            英雄灼烧状态[HeroType.哪吒].灼烧层数++;
         }
      }
      
      if (heroType == HeroType.羲和)
      {
         if (英雄灼烧状态[HeroType.羲和].灼烧层数 < FightController.S.英雄技能树属性[HeroType.羲和].火焰灼烧最大层数 + 1)
         {
            英雄灼烧状态[HeroType.羲和].灼烧伤害 += 最终Damage*FightController.S.英雄技能树属性[HeroType.羲和].火焰灼烧伤害/100f;
            英雄灼烧状态[HeroType.羲和].灼烧Time = 2 + FightController.S.英雄技能树属性[HeroType.羲和].火焰灼烧时间;
            英雄灼烧状态[HeroType.羲和].灼烧层数++;

         }
      }
      
      
      if (heroType == HeroType.元始)
      {
         if (英雄灼烧状态[HeroType.元始].灼烧层数 < FightController.S.英雄技能树属性[HeroType.元始].火焰灼烧最大层数 + 1)
         {
            英雄灼烧状态[HeroType.元始].灼烧伤害 += 最终Damage*FightController.S.英雄技能树属性[HeroType.元始].火焰灼烧伤害/100f;
            英雄灼烧状态[HeroType.元始].灼烧Time = 2 + FightController.S.英雄技能树属性[HeroType.元始].火焰灼烧时间;
            英雄灼烧状态[HeroType.元始].灼烧层数++;

         }
      }
      
      
      if (heroType == HeroType.鸿钧)
      {
         if (英雄灼烧状态[HeroType.鸿钧].灼烧层数 < FightController.S.英雄技能树属性[HeroType.鸿钧].火焰灼烧最大层数 + 1)
         {
            英雄灼烧状态[HeroType.鸿钧].灼烧伤害 += 最终Damage*FightController.S.英雄技能树属性[HeroType.鸿钧].火焰灼烧伤害/100f;
            英雄灼烧状态[HeroType.鸿钧].灼烧Time = 2 + FightController.S.英雄技能树属性[HeroType.鸿钧].火焰灼烧时间;
            英雄灼烧状态[HeroType.鸿钧].灼烧层数++;
         }
      }
   }
   public float 计算法器抗性(float 抗性,HeroType heroType,法器属性 法器属性)
   {
      switch (_ctx.职业.yuanSuType)
      {
         case YuanSuType.物理:
            //怪物抗性是0-100；穿透已按自身+辅助相加聚合，只除一次
            抗性 /= (1f+法器属性.物理穿透/100f);
            break;
         case YuanSuType.电:
            抗性 /= (1f+法器属性.雷电穿透/100f);
            break;
         case YuanSuType.冰:
            抗性 /= (1f+法器属性.冰霜穿透/100f);
            break;
         case YuanSuType.火:
            抗性 /= (1f+法器属性.火焰穿透/100f);
            break;
         case YuanSuType.黑暗:
            抗性 /=(1f+法器属性.黑暗穿透/100f);
            break;
      }

      return 抗性;
   }

   public void 更新异常个数()
   {
      int count = 0;
      foreach (var item in 英雄灼烧状态)
      {
         if (item.Value.灼烧Time > 0)
         {
            count++;
            break;
         }
      }

      if (冰元素减速时间 > 0)
      {
         count++;
      }

      if (易电time > 0)
      {
         count++;
      }

      if (冰冻time > 0)
      {
         count++;
      }

      if (黑暗印记层数 == 0)
      {
         count++;
      }

      异常状态个数 = count;
   }
   
   public void 清除异常()
   {
      int count = 0;
      foreach (var item in 英雄灼烧状态)
      {
         item.Value.灼烧Time = 0;
         item.Value.灼烧层数 = 0;
         item.Value.灼烧伤害 = 0;
      }
     冰元素减速时间 = 0;
      易电time = 0;
      冰冻time= 0;
      黑暗印记层数 = 0;
      黑暗印记伤害 = 0;
      异常状态个数 = 0;
   }

   private void Update()
   {
      // 已死亡的怪物不再移动/攻击城墙/跳灼烧：万一 Die() 回收前还有残余帧，
      // 也不能让死怪走到城墙根卡住全局攻击目标
      if (isDead) return;
      更新异常个数();
      foreach (var item in 英雄灼烧状态)
      {
         item.Value.灼烧当前时间+=Time.deltaTime;
         item.Value.灼烧Time -= Time.deltaTime;
         if (item.Value.灼烧Time <= 0)
         {
            item.Value.灼烧伤害 = 0;
            item.Value.灼烧层数 = 0;
         }
         if (item.Value.灼烧伤害>0&&item.Value.灼烧当前时间 > 0 && item.Value.灼烧当前时间 > 灼烧间隔&&item.Value.灼烧Time>0)
         {
            item.Value.灼烧当前时间 = 0;
            FightController.S.当前英雄伤害Dic[item.Key].总伤害 += item.Value.灼烧伤害;
            FightController.S.当前英雄伤害Dic[item.Key].技能伤害 += item.Value.灼烧伤害;
            FightController.S.Show伤害数字(PlayerData.S.格式化数字(item.Value.灼烧伤害),YuanSuType.火,伤害trans.position,is暴击:false);
            受击扣血(item.Value.灼烧伤害);
            if (CurrentHP <= 0)
            {
               Die(item.Key);
            }
         }
      }
      冰元素减速时间-=Time.deltaTime;
      if (冰元素减速时间 <= 0)
      {
         冰元素减速 = 0;
      }
      灼烧time-=Time.deltaTime;
      灼烧当前时间+=Time.deltaTime;
      冰冻time-=Time.deltaTime;
      易电time-=Time.deltaTime;
      冰符-=Time.deltaTime;
      瑶池冰辅助-=Time.deltaTime;
      龟丞相减速-=Time.deltaTime;
      黑暗符-=Time.deltaTime;
      if (易电time <= 0)
      {
         易电伤害 = 0;
      }
      灼烧obj.gameObject.SetActive(灼烧time>0||英雄灼烧状态[HeroType.哪吒].灼烧Time>0||英雄灼烧状态[HeroType.羲和].灼烧Time>0||英雄灼烧状态[HeroType.月老].灼烧Time>0||英雄灼烧状态[HeroType.元始].灼烧Time>0||英雄灼烧状态[HeroType.鸿钧].灼烧Time>0);
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

      // 血条刷新节流：只有最近 0.1s 内被打过的怪才赋值 Slider；残影只在 0.5s 追赶期内插值
      if (_血条脏)
      {
         _血条刷新计时 += Time.deltaTime;
         if (_血条刷新计时 >= _血条刷新间隔)
         {
            _血条刷新计时 = 0f;
            _血条脏 = false;
            MonsterSlider.value = CurrentHP;
         }
      }
      if (_残影激活)
      {
         _残影计时 += Time.deltaTime;
         float t = Mathf.Clamp01(_残影计时 / _残影持续时间);
         残影Slider.value = Mathf.Lerp(_残影起始值, _残影目标值, t);
         if (t >= 1f) _残影激活 = false;
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
      YuanSuType yuansu=_ctx.职业.yuanSuType;
      switch (yuansu)
      {
         case YuanSuType.冰:
            damage *= (1f + _ctx.根基丹药.冰霜伤害 / 100f);
            break;
         case YuanSuType.火:
            damage *= (1f + _ctx.根基丹药.火焰伤害 / 100f);
            break;
         case YuanSuType.黑暗:
            damage *= (1f + _ctx.根基丹药.黑暗伤害 / 100f);
            break;
         case YuanSuType.电:
            damage *= (1f + _ctx.根基丹药.雷电伤害 / 100f);
            break;
         case YuanSuType.物理:
            damage *= (1f + _ctx.根基丹药.物理伤害 / 100f);
            break;
      }
      damage *= (1f + _ctx.根基丹药.最终伤害 / 100f);
      return damage;
   }

   public float 计算体质伤害(float damage, HeroType heroType)
   {
      YuanSuType yuanSuType = _ctx.职业.yuanSuType;
      ZhiYeType zhiYeType=_ctx.职业.zhiYeType;
      damage*=(1f + FightController.S.缓存体质总属性.最终伤害 / 100f);
      switch (zhiYeType)
      {
         case ZhiYeType.战士:
            damage *= (1f + FightController.S.缓存体质总属性.战士伤害 / 100f);
            break;
         case ZhiYeType.射手:
            damage *= (1f + FightController.S.缓存体质总属性.射手伤害 / 100f);
            break;
         case ZhiYeType.法师:
            damage *= (1f + FightController.S.缓存体质总属性.法师伤害 / 100f);
            break;
         case ZhiYeType.控制:
            damage *= (1f + FightController.S.缓存体质总属性.控制伤害 / 100f);
            break;
      }
      switch (yuanSuType)
      {
         case YuanSuType.冰:
            damage *= (1f + FightController.S.缓存体质总属性.冰霜伤害 / 100f);
            break;
         case YuanSuType.电:
            damage *= (1f + FightController.S.缓存体质总属性.雷电伤害 / 100f);
            break;
         case YuanSuType.火:
            damage *= (1f + FightController.S.缓存体质总属性.火焰伤害 / 100f);
            break;
         case YuanSuType.物理:
            damage *= (1f + FightController.S.缓存体质总属性.物理伤害 / 100f);
            break;
         case YuanSuType.黑暗:
            damage *= (1f + FightController.S.缓存体质总属性.黑暗伤害 / 100f);
            break;
      }

      return damage;
   }

   public float 计算体质辅助伤害(float damage, HeroType heroType)
   {
      if (瑶池冰辅助 > 0)
      {
         damage *= (1f + FightController.S.缓存体质总属性.辅助伤害 / 100f);
      }
      if (妲己黑暗辅助)
      {
         damage *= (1f + FightController.S.缓存体质总属性.辅助伤害 / 100f);
      }
      if (女娲电辅助)
      {
         damage *= (1f + FightController.S.缓存体质总属性.辅助伤害 / 100f);
      }
      return damage;
   }

   public float 计算轮回次数加伤害(float damage, HeroType heroType)
   {
      if(PlayerData.S.轮回次数==0)return  damage;
      float value=damage*PlayerData.S.轮回次数*(1f+FightController.S.缓存体质总属性.轮回次数加伤害/100f);
      return value;
   }
   public float 计算功法伤害(float damage,HeroType  heroType)
   {
      // 所有功法最终伤害加成统一求和后只乘一次：
      // 主英雄自身功法 + 瑶池/妲己/女娲的辅助功法（按怪物身上的辅助标志），
      // 不再让每个辅助各乘一个(1+加成)，避免多辅助数值乘算爆炸
      float 功法伤害加成 = 0f;
      var heroData = PlayerData.S.HeroDataDic[heroType];
      if (heroData.功法Type != 功法Type.None)
      {
         float 每重奖励 = 功法Config.功法升级最终伤害奖励Dic[功法Config.功法TypeQualityDic[heroData.功法Type]];
         功法伤害加成 += heroData.功法等级 * 每重奖励 / 100f
            * (1f + FightController.S.缓存体质总属性.功法每层效果 / 100f)
            * (1f + heroData.功法星级 * 0.2f);
      }
      // 辅助英雄功法加成（与主英雄功法相加，多个辅助一起加）
      if (瑶池冰辅助 > 0)
      {
         功法伤害加成 += 功法Config.Get辅助功法伤害加成(HeroType.瑶池仙女);
      }
      if (妲己黑暗辅助)
      {
         功法伤害加成 += 功法Config.Get辅助功法伤害加成(HeroType.妲己);
      }
      if (女娲电辅助)
      {
         功法伤害加成 += 功法Config.Get辅助功法伤害加成(HeroType.女娲);
      }
      return damage * (1f + 功法伤害加成);
   }

   public float 计算丹药伤害(float damage, HeroType heroType)
   {
      ZhiYeType zhiYeType = _ctx.职业.zhiYeType;
      YuanSuType yuanSuType=_ctx.职业.yuanSuType;
      switch (zhiYeType)
      {
         case ZhiYeType.战士:
            damage *= (1f + FightController.S.丹药战士伤害 / 100f);
            break;
         case ZhiYeType.射手:
            damage *= (1f + FightController.S.丹药射手伤害 / 100f);
            break;
         case ZhiYeType.法师:
            damage *= (1f + FightController.S.丹药法师伤害 / 100f);
            break;
         case ZhiYeType.控制:
            damage *= (1f + FightController.S.丹药控制伤害 / 100f);
            break;
      }

      switch (yuanSuType)
      {
         case YuanSuType.冰:
            damage *= (1f + FightController.S.丹药冰霜伤害 / 100f);
            break;
         case YuanSuType.火:
            damage *= (1f + FightController.S.丹药火焰伤害 / 100f);
            break;
         case YuanSuType.黑暗:
            damage *= (1f + FightController.S.丹药黑暗伤害 / 100f);
            break;
         case YuanSuType.电:
            damage *= (1f + FightController.S.丹药雷电伤害 / 100f);
            break;
         case YuanSuType.物理:
            damage *= (1f + FightController.S.丹药物理伤害 / 100f);
            break;
      }
      damage *= (1f + FightController.S.丹药最终伤害 / 100f);

      return damage;
   }

   // 聚合法器属性：主英雄自身法器 + 在场辅助（瑶池/妲己/女娲）法器，字段全部相加。
   // 伤害和穿透都基于这一份聚合值各乘/除一次，避免每个辅助各乘一个(1+x)导致数值连乘爆炸
   private 法器属性 获取聚合法器属性(HeroType heroType)
   {
      var dic = FightController.S.英雄法器属性Dic;
      // 复用每怪一份的 scratch（Hurt 内无重入），清零后重新累加，避免每次受击 new 法器属性
      法器属性 聚合 = _聚合法器复用;
      聚合.清零();
      void 累加(HeroType h)
      {
         if (!dic.TryGetValue(h, out var f) || f == null) return;
         聚合.暴击率 += f.暴击率;
         聚合.暴击伤害 += f.暴击伤害;
         聚合.火焰伤害 += f.火焰伤害;
         聚合.雷电伤害 += f.雷电伤害;
         聚合.黑暗伤害 += f.黑暗伤害;
         聚合.冰霜伤害 += f.冰霜伤害;
         聚合.物理伤害 += f.物理伤害;
         聚合.最终伤害 += f.最终伤害;
         聚合.普通怪增伤 += f.普通怪增伤;
         聚合.精英怪增伤 += f.精英怪增伤;
         聚合.首领怪增伤 += f.首领怪增伤;
         聚合.火焰穿透 += f.火焰穿透;
         聚合.雷电穿透 += f.雷电穿透;
         聚合.物理穿透 += f.物理穿透;
         聚合.冰霜穿透 += f.冰霜穿透;
         聚合.黑暗穿透 += f.黑暗穿透;
      }
      累加(heroType);
      if (瑶池冰辅助 > 0) 累加(HeroType.瑶池仙女);
      if (妲己黑暗辅助) 累加(HeroType.妲己);
      if (女娲电辅助) 累加(HeroType.女娲);
      return 聚合;
   }

   public float 计算法器伤害(float damage,HeroType  heroType,法器属性 法器属性)
   {
      MonsterType monsterType = MonsterConfig.MonsterTypeDic[MonsterTypeName];
      YuanSuType yuansu = _ctx.职业.yuanSuType;
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
            PlayerData.S.HeroDataDic[item].功法经验+=(1f+FightController.S.缓存体质总属性.功法经验加成/100f);
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
      }else if (LevelConfig.当前关卡类型 == 关卡类型.远古遗迹||LevelConfig.当前关卡类型 == 关卡类型.符文之地)
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
      try
      { 
         FightController.S.当前神通能量 += _ctx.符文.击杀怪物获得神通能量;
         ObserverModuleManager.S.SendEvent("符文减少神通冷却",heroType);
      ObserverModuleManager.S.SendEvent("播放怪物音效",战斗音效Type.怪物死亡);
      增加功法经验();
      if (heroType == HeroType.盘古)
      {
         FightController.S.盘古击杀次数++;
      }
      FightController.S.总杀怪增伤 += 城墙Config.杀怪增伤数值;
      if (城墙Config.杀怪回血数值 > 0)
      {
         int value = (int)(城墙Config.杀怪回血数值 / 100f * FightController.S.缓存城墙最大生命值);
         FightController.S.城墙当前生命值=Math.Min(FightController.S.缓存城墙最大生命值,FightController.S.城墙当前生命值+value);
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
      }else if (LevelConfig.当前关卡类型 == 关卡类型.符文之地)
      {
         小怪数量 = 符文之地Config.符文之地信息Dic[LevelConfig.当前符文之地Type].NormalMonsterCount;
         精英怪数量 = 符文之地Config.符文之地信息Dic[LevelConfig.当前符文之地Type].EliteMonsterCount;
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
         case MonsterType.Elite:
            FightController.S.城墙当前生命值 += 属性config.总属性.击杀精英怪城墙回血 * FightController.S.缓存城墙最大生命值;
            FightController.S.城墙当前生命值 = Math.Min(FightController.S.缓存城墙最大生命值, FightController.S.城墙当前生命值);
            ObserverModuleManager.S.SendEvent("设置护盾");
            break;
      }
      // 死亡特效只是表现层：AOE 同帧多杀时特效池可能暂时耗尽（普通50/精英5/首领5），
      // 空队列 Dequeue 会抛 InvalidOperationException，池空时跳过特效即可
      switch (monsterType)
      {
         case MonsterType.Normal:
            if (QueueController.S.普通怪死亡Queue.Count > 0)
            {
               var 普通怪死亡 = QueueController.S.普通怪死亡Queue.Dequeue();
               普通怪死亡.gameObject.transform.position = transform.position;
               普通怪死亡.order=(int)(transform.position.y * -100);
               普通怪死亡.gameObject.SetActive(true);
            }
            break;
         case MonsterType.Elite:
            if (QueueController.S.精英怪死亡Queue.Count > 0)
            {
               var 精英怪死亡 = QueueController.S.精英怪死亡Queue.Dequeue();
               精英怪死亡.gameObject.transform.position = transform.position;
               精英怪死亡.order=(int)(transform.position.y * -100);
               精英怪死亡.gameObject.SetActive(true);
            }
            break;
         case MonsterType.Boss:
            if (QueueController.S.首领怪死亡Queue.Count > 0)
            {
               var 首领怪死亡 = QueueController.S.首领怪死亡Queue.Dequeue();
               首领怪死亡.gameObject.transform.position = transform.position;
               首领怪死亡.order=(int)(transform.position.y * -100);
               首领怪死亡.gameObject.SetActive(true);
            }
            break;
      }
      }
      finally
      {
         // 关键回收：回池 + 退出场集合/分区 + 隐藏。无论 try 里哪一步抛异常都必须执行，
         // 否则死怪留在分区1会被 GetAttackMonster 一直选中，战斗英雄集体停攻
         switch (MonsterConfig.MonsterTypeDic[MonsterTypeName])
         {
            case MonsterType.Normal:
               QueueController.S.普通怪Queue.Enqueue(this as 普通怪);
               break;
            case MonsterType.Elite:
               QueueController.S.精英怪Queue.Enqueue(this as 精英怪);
               break;
            case MonsterType.Boss:
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
}
