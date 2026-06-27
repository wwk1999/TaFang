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

   public float GetRealSpeed()
   {
      float value = basespeed;
      if (瑶池冰辅助 > 0)
      {
         value *= 0.85f;
      }

      if (龟丞相减速 > 0)
      {
         value *= 0.5f;
      }
      return value;
   }
   private void OnEnable()
   {
      if (MonsterTypeName == MonsterTypeName.None)
      {
         return;
      }
      InitAttribute();
      image.sortingOrder = (int)(transform.position.y * -100)+1;
      bg.sortingOrder = (int)(transform.position.y * -100);
      HpCanvas.sortingOrder = (int)(transform.position.y * -100)+2;
      MonsterSlider.gameObject.SetActive(false);
      CurrentHP = MonsterAttribute.Hp;
      image.sprite = ResourcesConfig.GetMonsterSprite(MonsterTypeName);
   }

   public void InitAttribute()
   {
      LevelSmallType levelSmallType = MonsterConfig.MonsterLevelDic[MonsterTypeName];
      MonsterType monsterType=MonsterConfig.MonsterTypeDic[MonsterTypeName];
      普通关卡怪物Item 普通关卡怪物Item=new 普通关卡怪物Item(){LevelSmallType =  levelSmallType, MonsterType = monsterType};
      MonsterAttribute = MonsterConfig.普通关卡怪物属性Dic[普通关卡怪物Item];
      Monster特性Type monster特性Type=MonsterConfig.怪物特性Dic[MonsterTypeName];
      basespeed = MonsterConfig.怪物速度Dic[monster特性Type];
   }

   public void Hurt(float 原始Damage,YuanSuType yuanSuType)
   {
      MonsterSlider.gameObject.SetActive(true);
      受击Animation.Play("怪物受击",0,0f);
      float 最终Damage = 原始Damage - MonsterAttribute.Defense;
      float 抗性 = 0;
      switch (yuanSuType)
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

      最终Damage *= (100 - 抗性) / 100;
      FightController.S.Show伤害数字(最终Damage,yuanSuType,伤害trans.position);
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
      瑶池冰辅助-=Time.deltaTime;
      龟丞相减速-=Time.deltaTime;
      黑暗符-=Time.deltaTime;
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
         if (黑暗符 <= 0)
         {
            transform.position=new Vector3(transform.position.x-RealSpeed*Time.deltaTime,transform.position.y,transform.position.z);
         }
      }
      else
      {
         if (CurrentAttackTime > 1f)
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
      Instantiate(Resources.Load("Prefabs/Window/胜利弹窗"));
   }
   public void Die()
   {
      ObserverModuleManager.S.SendEvent("怪物死亡",this);
      FightController.S.KillMonsterCount++;
      if (FightController.S.KillMonsterCount ==
          (LevelConfig.LevelInfos[LevelConfig.CurrentLevelSmallType].NormalMonsterCount +
           LevelConfig.LevelInfos[LevelConfig.CurrentLevelSmallType].EliteMonsterCount))
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
