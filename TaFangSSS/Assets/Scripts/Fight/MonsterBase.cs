using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Random = UnityEngine.Random;

public class MonsterBase : MonoBehaviour
{
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
   public Animator 受击Animation;
   public Collider2D Collider2D;

   public Slider MonsterSlider;
   [NonSerialized] public MonsterAttribute MonsterAttribute;
   [NonSerialized]public float CurrentHP;
   [NonSerialized] public float basespeed;
   private float CurrentAttackTime = 0;
   private float RealSpeed => GetRealSpeed();
   [NonSerialized] public float 瑶池冰辅助=0;
   [NonSerialized] public float 龟丞相减速=0;
   [NonSerialized] public float 黑暗符=0;
   [NonSerialized]public bool isDead=false;
   [NonSerialized] public float 冰符=0;
   private int 黑暗符次数 = 0;

   public void Set灼烧伤害(float damage)
   {
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
      float scale = 0.1f * 黑暗符次数;
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
      return value;
   }
   private void OnEnable()
   {
      if (MonsterTypeName == MonsterTypeName.None)
      {
         return;
      }

      黑暗符次数 = 0;
      isDead = false;
      InitAttribute();
      image.sortingOrder = (int)(transform.position.y * -100)+1;
      bg.sortingOrder = (int)(transform.position.y * -100);
      HpCanvas.sortingOrder = (int)(transform.position.y * -100)+3;
      灼烧image.sortingOrder = (int)(transform.position.y * -100)+2;
      冰块.sortingOrder = (int)(transform.position.y * -100)+2;
      MonsterSlider.gameObject.SetActive(false);
      CurrentHP = MonsterAttribute.Hp;
      image.sprite = ResourcesConfig.GetMonsterSprite(MonsterTypeName);
   }

   public void InitAttribute()
   {
      主线关卡Type 主线关卡Type = LevelConfig.当前主线关卡Type;
      MonsterType monsterType=MonsterConfig.MonsterTypeDic[MonsterTypeName];
      主线关卡怪物Item 主线关卡怪物Item=new 主线关卡怪物Item(){主线关卡Type =  主线关卡Type, MonsterType = monsterType};
      MonsterAttribute = Get怪物属性(主线关卡怪物Item);
      Monster特性Type monster特性Type=MonsterConfig.怪物特性Dic[MonsterTypeName];
      basespeed = MonsterConfig.怪物速度Dic[monster特性Type];
   }

   public MonsterAttribute Get怪物属性(主线关卡怪物Item item)
   {
      MonsterAttribute 怪物属性 = MonsterConfig.主线关卡怪物属性Dic[item];
      if (LevelConfig.Is混沌虚空)
      {
         int count = LevelConfig.混沌虚空层数 - 1;
         怪物属性.Attack*=Mathf.Pow(1.2f, count);
         怪物属性.Hp*=Mathf.Pow(1.2f, count);
         怪物属性.Defense*=Mathf.Pow(1.2f, count);
      }

      return 怪物属性;
   }

   public float 元素伤害(float damage,YuanSuType yuanSuType,属性config.领主总属性 属性)
   {
      switch (yuanSuType)
      {
         case YuanSuType.冰:
            damage *= 属性.冰霜伤害增幅;
            break;
         case YuanSuType.火:
            damage *= 属性.火焰伤害增幅;
            break;
         case YuanSuType.黑暗:
            damage *= 属性.黑暗伤害增幅;
            break;
         case YuanSuType.物理:
            damage *= 属性.物理伤害增幅;
            break;
         case YuanSuType.电:
            damage *= 属性.雷电伤害增幅;
            break;
      }

      return damage;
   }
   
   public float 职业伤害(float damage,ZhiYeType zhiYeType,属性config.领主总属性 属性)
   {
      switch (zhiYeType)
      {
         case ZhiYeType.法师:
            damage *= 属性.法师增幅;
            break;
         case ZhiYeType.战士:
            damage *= 属性.战士增幅;
            break;
         case ZhiYeType.射手:
            damage *= 属性.射手增幅;
            break;
         case ZhiYeType.控制:
            damage *= 属性.控制增幅;
            break;
      }

      return damage;
   }

   public bool 暴击检测(HeroType heroType)
   {
      float random = Random.Range(0, 100);
      属性config.领主总属性 属性 = new 属性config.领主总属性();
      float value = 属性.暴击率 * 100;
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
         return true;
      }
      else
      {
         return false;
      }
   }
   public void Hurt(float 原始Damage,HeroType heroType)
   {
      MonsterSlider.gameObject.SetActive(true);
      受击Animation.Play("怪物受击",0,0f);
      float 最终Damage = Math.Max(原始Damage - MonsterAttribute.Defense,0);
      bool 暴击 = 暴击检测(heroType);
      if (暴击)
      {
         最终Damage *= (2 + 属性config.Get英雄暴击伤害增幅());
      }

      最终Damage *= 属性config.总属性.最终伤害;
      if (transform.position.x < -2 && HeroConfig.HeroZhiYeDic[heroType].zhiYeType == ZhiYeType.战士)
      {
         最终Damage *= 属性config.总属性.战士对靠近城墙敌人伤害增高;
      }
      
      if (transform.position.x > 3.5f && HeroConfig.HeroZhiYeDic[heroType].zhiYeType == ZhiYeType.射手)
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

      switch (MonsterConfig.MonsterTypeDic[MonsterTypeName])
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
      
      最终Damage *= (1 + 道宝Config.羁绊最终伤害 / 100f);
      最终Damage *= (1 + FightController.S.总杀怪增伤 / 100f);
      最终Damage = 元素伤害(最终Damage, HeroConfig.HeroZhiYeDic[heroType].yuanSuType,属性config.总属性);
      最终Damage = 职业伤害(最终Damage, HeroConfig.HeroZhiYeDic[heroType].zhiYeType,属性config.总属性);
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
      switch (HeroConfig.HeroZhiYeDic[heroType].yuanSuType)
      {
         case YuanSuType.物理:
            
            抗性 = MonsterAttribute.物理抗性;
            break;
         case YuanSuType.电:
            抗性 = MonsterAttribute.雷电抗性;
            break;
         case YuanSuType.冰:
            抗性 = MonsterAttribute.冰霜抗性;
            break;
         case YuanSuType.火:
            抗性 = MonsterAttribute.火焰抗性;
            break;
         case YuanSuType.黑暗:
            抗性 = MonsterAttribute.黑暗抗性;
            break;
      }

      最终Damage *= (100 - (抗性-属性config.总属性.无视抗性*100)) / 100;
      FightController.S.Show伤害数字(最终Damage,HeroConfig.HeroZhiYeDic[heroType].yuanSuType,伤害trans.position);
      CurrentHP -= 最终Damage;
      MonsterSlider.gameObject.SetActive(true);
      MonsterSlider.maxValue = MonsterAttribute.Hp;
      MonsterSlider.value = CurrentHP;
      if (CurrentHP <= 0)
      {
         Die();
      }
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
         Hurt(灼烧伤害,HeroType.羲和);
      }
      float 城墙最近距离 = 0;
      CurrentAttackTime+=Time.deltaTime;
      switch (MonsterConfig.MonsterTypeDic[MonsterTypeName])
      {
         case MonsterType.Normal:
            城墙最近距离 = FightConfig.怪物攻击距离Dic[MonsterType.Normal];
            break;
         case MonsterType.Elite:
            城墙最近距离 = FightConfig.怪物攻击距离Dic[MonsterType.Elite];
            break;
         case MonsterType.Boss:
            城墙最近距离 = FightConfig.怪物攻击距离Dic[MonsterType.Boss];
            break;
      }

      if (transform.position.x > 城墙最近距离)
      {
         if (黑暗符 <= 0&&冰冻time<0)
         {
            transform.position=new Vector3(transform.position.x-RealSpeed*Time.deltaTime,transform.position.y,transform.position.z);
         }
      }
      else
      {
         if (CurrentAttackTime > 1f&&黑暗符 <= 0&&冰冻time<=0)
         {
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
      if (LevelConfig.当前主线关卡Type == PlayerData.S.最大主线关卡)
      {
         PlayerData.S.最大主线关卡++;
         ObserverModuleManager.S.SendEvent("SendUIToast",$"恭喜解锁{LevelConfig.主线关卡NameDic[PlayerData.S.最大主线关卡]}");
      }

      if (LevelConfig.当前关卡类型==关卡类型.主线关卡&&LevelConfig.Is混沌虚空 && LevelConfig.混沌虚空层数 == PlayerData.S.混沌虚空最大层数)
      {
         PlayerData.S.混沌虚空最大层数++;
      }
      Instantiate(Resources.Load("Prefabs/Window/胜利弹窗"));
   }
   public void Die()
   {
      if (isDead)
      {
         return;
      }
      isDead = true;
      FightController.S.总杀怪增伤 += 城墙Config.杀怪增伤数值;
      if (城墙Config.杀怪回血数值 > 0)
      {
         int value = (int)(城墙Config.杀怪回血数值 / 100f * 城墙Config.Get城墙最大生命值());
         FightController.S.城墙当前生命值=Math.Min(城墙Config.Get城墙最大生命值(),FightController.S.城墙当前生命值+value);
         FightController.S.Show伤害数字(value,YuanSuType.None,new Vector2(-5,0),true);
      }
      ObserverModuleManager.S.SendEvent("怪物死亡",this);
      FightController.S.KillMonsterCount++;
      int 小怪数量 = LevelConfig.LevelInfos[LevelConfig.当前主线关卡Type].NormalMonsterCount;
      int 精英怪数量 = LevelConfig.LevelInfos[LevelConfig.当前主线关卡Type].EliteMonsterCount;
      if (FightController.S.KillMonsterCount == 小怪数量/2)
      {
         FightController.S.CreateBossMonster();
      }
      for (int i = 1; i <= 精英怪数量; i++)
      {
         if (FightController.S.KillMonsterCount == (int)(小怪数量 * (i / (精英怪数量 + 1f))))
         {
            FightController.S.CreateEliteMonster();
            FightController.S.EliteMonsterCount++;
         }
      }
      
      if (FightController.S.KillMonsterCount == 小怪数量 + 精英怪数量+1)
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
      if (FightController.S.Monster分区Dic[1].Contains(this))
      {
         FightController.S.Monster分区Dic[1].Remove(this);
      }
      if (FightController.S.Monster分区Dic[2].Contains(this))
      {
         FightController.S.Monster分区Dic[2].Remove(this);
      }
      if (FightController.S.Monster分区Dic[3].Contains(this))
      {
         FightController.S.Monster分区Dic[3].Remove(this);
      }
      if (FightController.S.Monster分区Dic[4].Contains(this))
      {
         FightController.S.Monster分区Dic[4].Remove(this);
      }
      if (FightController.S.Monster分区Dic[5].Contains(this))
      {
         FightController.S.Monster分区Dic[5].Remove(this);
      }
      if (FightController.S.Monster分区Dic[6].Contains(this))
      {
         FightController.S.Monster分区Dic[6].Remove(this);
      }
      if (FightController.S.Monster分区Dic[7].Contains(this))
      {
         FightController.S.Monster分区Dic[7].Remove(this);
      }
      gameObject.SetActive(false);
   }
}
