using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class 矿工装备洗练无暇提示弹窗 : MonoBehaviour
{
   public Button 返回Button;
   public Button 确认Button;

   [NonSerialized] public 矿工装备 矿工装备;
   private void Start()
   {
      返回Button.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      确认Button.onClick.AddListener(() =>
      {
         var 价格=灵矿场Config.Get装备洗练粉尘(矿工装备.阶数, 矿工装备.QualityType) * Math.Pow(2, Get锁个数(矿工装备));
        PlayerData.S.矿工粉尘 -= (float)价格;
        // 复制一份配置值，避免随机加成直接改到静态配置表
        四维属性 配置四维 = 灵矿场Config.装备四维属性[矿工装备.阶数];
        四维属性 基础四维属性 = new 四维属性()
        {
            挖掘速度 = 配置四维.挖掘速度,
            固定收益 = 配置四维.固定收益,
            挖宝时间 = 配置四维.挖宝时间,
            成长速度 = 配置四维.成长速度,
        };
        bool 挖掘速度无暇 = Random.Range(0f, 100f) < 1f;
        bool 成长速度无暇 = Random.Range(0f, 100f) < 1f;
        bool 挖宝速度无暇 = Random.Range(0f, 100f) < 1f;
        bool 固定收益无暇 = Random.Range(0f, 100f) < 1f;
        if (!挖掘速度无暇) 基础四维属性.挖掘速度 *= Random.Range(灵矿场Config.装备随机最小区间, 灵矿场Config.装备随机最大区间);
        if (!挖宝速度无暇) 基础四维属性.挖宝时间 *= Random.Range(灵矿场Config.装备随机最小区间, 灵矿场Config.装备随机最大区间);
        if (!成长速度无暇) 基础四维属性.成长速度 *= Random.Range(灵矿场Config.装备随机最小区间, 灵矿场Config.装备随机最大区间);
        if (!固定收益无暇) 基础四维属性.固定收益 *= Random.Range(灵矿场Config.装备随机最小区间, 灵矿场Config.装备随机最大区间);
        switch (矿工装备.QualityType)
        {
            case QualityType.地品:
                基础四维属性.挖掘速度 *= 灵矿场Config.品质倍率[1];
                基础四维属性.挖宝时间 *= 灵矿场Config.品质倍率[1];
                基础四维属性.成长速度 *= 灵矿场Config.品质倍率[1];
                基础四维属性.固定收益 *= 灵矿场Config.品质倍率[1];
                break;
            case QualityType.宇品:
                基础四维属性.挖掘速度 *= 灵矿场Config.品质倍率[2];
                基础四维属性.挖宝时间 *= 灵矿场Config.品质倍率[2];
                基础四维属性.成长速度 *= 灵矿场Config.品质倍率[2];
                基础四维属性.固定收益 *= 灵矿场Config.品质倍率[2];
                break;
            case QualityType.洪品:
                基础四维属性.挖掘速度 *= 灵矿场Config.品质倍率[3];
                基础四维属性.挖宝时间 *= 灵矿场Config.品质倍率[3];
                基础四维属性.成长速度 *= 灵矿场Config.品质倍率[3];
                基础四维属性.固定收益 *= 灵矿场Config.品质倍率[3];
                break;
            case QualityType.荒品:
                基础四维属性.挖掘速度 *= 灵矿场Config.品质倍率[4];
                基础四维属性.挖宝时间 *= 灵矿场Config.品质倍率[4];
                基础四维属性.成长速度 *= 灵矿场Config.品质倍率[4];
                基础四维属性.固定收益 *= 灵矿场Config.品质倍率[4];
                break;
        }
        if (挖掘速度无暇) 基础四维属性.挖掘速度 *= 灵矿场Config.无暇倍率;
        if (成长速度无暇) 基础四维属性.成长速度 *= 灵矿场Config.无暇倍率;
        if (固定收益无暇) 基础四维属性.固定收益 *= 灵矿场Config.无暇倍率;
        if (挖宝速度无暇) 基础四维属性.挖宝时间 *= 灵矿场Config.无暇倍率;
        if(!矿工装备.固定收益洗练锁)矿工装备.固定收益无暇 = 固定收益无暇;
        if(!矿工装备.成长速度洗练锁)矿工装备.成长速度无暇 = 成长速度无暇;
        if(!矿工装备.挖掘速度洗练锁)矿工装备.挖掘速度无暇 = 挖掘速度无暇;
        if(!矿工装备.挖宝时间洗练锁)矿工装备.挖宝时间无暇 = 挖宝速度无暇;
        
        if(!矿工装备.固定收益洗练锁)矿工装备.基础四维.固定收益 = 基础四维属性.固定收益;
        if(!矿工装备.成长速度洗练锁)矿工装备.基础四维.成长速度 = 基础四维属性.成长速度;
        if(!矿工装备.挖掘速度洗练锁)矿工装备.基础四维.挖掘速度 = 基础四维属性.挖掘速度;
        if(!矿工装备.挖宝时间洗练锁)矿工装备.基础四维.挖宝时间 = 基础四维属性.挖宝时间;
        gameObject.SetActive(false);
        ObserverModuleManager.S.SendEvent("矿工装备确认洗练");
      });
   }
   private int Get锁个数(矿工装备 装备)
   {
       int value = 0;
       if (装备.挖掘速度洗练锁) value += 1;
       if (装备.固定收益洗练锁) value += 1;
       if (装备.成长速度洗练锁) value += 1;
       if (装备.挖宝时间洗练锁) value += 1;
       return value;
   }
}
