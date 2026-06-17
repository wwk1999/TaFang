using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MonsterBase : MonoBehaviour
{
   public SpriteRenderer bg;
   public Canvas HpCanvas;
   public SpriteRenderer image;
   [NonSerialized]public MonsterTypeName MonsterTypeName=MonsterTypeName.None;
   public Transform 伤害trans;
   public Animation 攻击Animation;
   public Animation 受击Animation;
   public Collider2D Collider2D;

   public Slider MonsterSlider;
   [NonSerialized] public MonsterAttribute MonsterAttribute;
   [NonSerialized]public float CurrentHP;
   [NonSerialized] public float speed;
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
      speed = MonsterConfig.怪物速度Dic[monster特性Type];
   }

   public void Hurt(float 原始Damage,YuanSuType yuanSuType)
   {
      MonsterSlider.gameObject.SetActive(true);
      受击Animation.Play();
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
      transform.position=new Vector3(transform.position.x-speed*Time.deltaTime,transform.position.y,transform.position.z);
   }

   public void Die()
   {
      MonsterType monsterType = MonsterConfig.MonsterTypeDic[MonsterTypeName];
      switch (monsterType)
      {
         case MonsterType.Normal:
            var 普通怪死亡 = FightController.S.普通怪死亡Queue.Dequeue();
            普通怪死亡.gameObject.transform.position = transform.position;
            普通怪死亡.order=(int)(transform.position.y * -100);
            普通怪死亡.gameObject.SetActive(true);
            FightController.S.普通怪Queue.Enqueue(this as 普通怪);
            break;
         case MonsterType.Elite:
            var 精英怪死亡 = FightController.S.精英怪死亡Queue.Dequeue();
            精英怪死亡.gameObject.transform.position = transform.position;
            精英怪死亡.order=(int)(transform.position.y * -100);
            精英怪死亡.gameObject.SetActive(true);
            FightController.S.精英怪Queue.Enqueue(this as 精英怪);
            break;
         case MonsterType.Boss:
            var 首领怪死亡 = FightController.S.首领怪死亡Queue.Dequeue();
            首领怪死亡.gameObject.transform.position = transform.position;
            首领怪死亡.order=(int)(transform.position.y * -100);
            首领怪死亡.gameObject.SetActive(true);
            FightController.S.首领怪Queue.Enqueue(this as 首领怪);
            break;
      }
      gameObject.SetActive(false);
   }
}
