using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;

public class QueueController:XSingleton<QueueController>
{
    [NonSerialized] public Queue<伤害数字> 伤害数字Queue = new Queue<伤害数字>();
    [NonSerialized] public Queue<Spine纯显示一次> 普通怪死亡Queue = new Queue<Spine纯显示一次>();
    [NonSerialized] public Queue<Spine纯显示一次> 精英怪死亡Queue = new Queue<Spine纯显示一次>();
    [NonSerialized] public Queue<Spine纯显示一次> 首领怪死亡Queue = new Queue<Spine纯显示一次>();
    [NonSerialized] public Queue<普通怪> 普通怪Queue = new Queue<普通怪>();
    [NonSerialized] public Queue<精英怪> 精英怪Queue = new Queue<精英怪>();
    [NonSerialized] public Queue<首领怪> 首领怪Queue = new Queue<首领怪>();
    
    [NonSerialized] public Queue<序列纯显示一次> 电魔法弹PengQueue = new Queue<序列纯显示一次>();
    [NonSerialized] public Queue<序列纯显示一次> 黑暗飞箭PengQueue = new Queue<序列纯显示一次>();
    [NonSerialized] public Queue<序列纯显示一次> 黑暗剑气PengQueue = new Queue<序列纯显示一次>();
    [NonSerialized] public Queue<序列纯显示一次> 物理箭PengQueue = new Queue<序列纯显示一次>();
    [NonSerialized] public Queue<序列纯显示一次> 紫鬼弹PengQueue = new Queue<序列纯显示一次>();
    [NonSerialized] public Queue<序列纯显示一次> 黑暗花魔法弹PengQueue = new Queue<序列纯显示一次>();
    [NonSerialized] public Queue<序列纯显示一次> 冰爆气魔法弹PengQueue = new Queue<序列纯显示一次>();
    [NonSerialized] public Queue<序列纯显示一次> 电龙魔法弹PengQueue = new Queue<序列纯显示一次>();
    [NonSerialized] public Queue<序列纯显示一次> 电爆气魔法弹PengQueue = new Queue<序列纯显示一次>();
    [NonSerialized] public Queue<序列纯显示一次> 冰大魔法弹PengQueue = new Queue<序列纯显示一次>();
    [NonSerialized] public Queue<序列纯显示一次> 火虎魔法弹PengQueue = new Queue<序列纯显示一次>();
    [NonSerialized] public Queue<序列纯显示一次> 黑暗魔法弹PengQueue = new Queue<序列纯显示一次>();

    
    [NonSerialized] public Queue<普通魔法弹带peng> 电魔法弹Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized] public Queue<普通魔法弹带peng> 黑暗飞箭Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized] public Queue<普通魔法弹带peng> 黑暗剑气Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized] public Queue<普通魔法弹带peng> 物理箭Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized] public Queue<普通魔法弹带peng> 紫鬼弹Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized] public Queue<普通魔法弹带peng> 黑暗花魔法弹Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized] public Queue<普通魔法弹带peng> 冰爆气魔法弹Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized] public Queue<普通魔法弹带peng> 电龙魔法弹Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized] public Queue<普通魔法弹带peng> 电爆气魔法弹Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized] public Queue<普通魔法弹带peng> 冰大魔法弹Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized] public Queue<普通魔法弹带peng> 火虎魔法弹Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized] public Queue<普通魔法弹带peng> 黑暗魔法弹Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized] public Queue<普通魔法弹带peng> 普通火魔法弹Queue = new Queue<普通魔法弹带peng>();

    
    
    [NonSerialized]public Queue<序列一次伤害技能>冰刺Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<石敢当锤子>石敢当锤子Queue = new Queue<石敢当锤子>();

    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    
    public IEnumerator InitHeroSkill()
    {
        var herolist=PlayerData.S.出战英雄List[PlayerData.S.CurrentBianDui-1];
        int count = 0;
        foreach (var hero in herolist)
        {
            if (HeroConfig.HeroSkillDic.ContainsKey(hero)&&hero!=HeroType.None)
            {
                foreach (var item in HeroConfig.HeroSkillDic[hero].攻击特效List)
                {
                    StartCoroutine(Init攻击特效(item));
                }
                foreach (var item in HeroConfig.HeroSkillDic[hero].PengList)
                {
                    StartCoroutine(InitPeng(item));
                }
            }
        }

        yield return null;
    }
    
    
    public IEnumerator InitPeng(PengType type,int fream=10)
    {
        int count = 0;
        for (int i = 0; i < 100; i++)
        {
            switch (type)
            {
                case PengType.电魔法弹Peng:
                    if (电魔法弹PengQueue.Count > 100)
                    {
                        break;
                    }
                    var 电魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/电魔法弹Peng"),transform).GetComponent<序列纯显示一次>();
                    电魔法弹Peng.gameObject.SetActive(false);
                    电魔法弹PengQueue.Enqueue(电魔法弹Peng);
                    break;
                case PengType.黑暗飞箭Peng:
                    if (黑暗飞箭PengQueue.Count > 100)
                    {
                        break;
                    }
                    var 黑暗飞箭Peng = Instantiate(Resources.Load("Prefabs/特效/黑暗飞箭Peng"),transform).GetComponent<序列纯显示一次>();
                    黑暗飞箭Peng.gameObject.SetActive(false);
                    黑暗飞箭PengQueue.Enqueue(黑暗飞箭Peng);
                    break;
                case PengType.黑暗剑气Peng:
                    if (黑暗剑气PengQueue.Count > 100)
                    {
                        break;
                    }
                    var 黑暗剑气Peng = Instantiate(Resources.Load("Prefabs/特效/黑暗剑气Peng"),transform).GetComponent<序列纯显示一次>();
                    黑暗剑气Peng.gameObject.SetActive(false);
                    黑暗剑气PengQueue.Enqueue(黑暗剑气Peng);
                    break;
                case PengType.物理箭Peng:
                    if (物理箭PengQueue.Count > 100)
                    {
                        break;
                    }
                    var 物理箭Peng = Instantiate(Resources.Load("Prefabs/特效/物理箭Peng"),transform).GetComponent<序列纯显示一次>();
                    物理箭Peng.gameObject.SetActive(false);
                    物理箭PengQueue.Enqueue(物理箭Peng);
                    break;
                case PengType.紫鬼弹Peng:
                    if (紫鬼弹PengQueue.Count > 100)
                    {
                        break;
                    }
                    var 紫鬼弹Peng = Instantiate(Resources.Load("Prefabs/特效/紫鬼弹Peng"),transform).GetComponent<序列纯显示一次>();
                    紫鬼弹Peng.gameObject.SetActive(false);
                    紫鬼弹PengQueue.Enqueue(紫鬼弹Peng);
                    break;
                case PengType.黑暗花魔法弹Peng:
                    if (黑暗花魔法弹PengQueue.Count > 100)
                    {
                        break;
                    }
                    var 黑暗花魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/黑暗花魔法弹Peng"),transform).GetComponent<序列纯显示一次>();
                    黑暗花魔法弹Peng.gameObject.SetActive(false);
                    黑暗花魔法弹PengQueue.Enqueue(黑暗花魔法弹Peng);
                    break;
                case PengType.冰爆气魔法弹Peng:
                    if (冰爆气魔法弹PengQueue.Count > 100)
                    {
                        break;
                    }
                    var 冰爆气魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/冰爆气魔法弹Peng"),transform).GetComponent<序列纯显示一次>();
                    冰爆气魔法弹Peng.gameObject.SetActive(false);
                    冰爆气魔法弹PengQueue.Enqueue(冰爆气魔法弹Peng);
                    break;
                case PengType.电龙魔法弹Peng:
                    if (电龙魔法弹PengQueue.Count > 100)
                    {
                        break;
                    }
                    var 电龙魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/电龙魔法弹Peng"),transform).GetComponent<序列纯显示一次>();
                    电龙魔法弹Peng.gameObject.SetActive(false);
                    电龙魔法弹PengQueue.Enqueue(电龙魔法弹Peng);
                    break;
                case PengType.电爆气魔法弹Peng:
                    if (电爆气魔法弹PengQueue.Count > 100)
                    {
                        break;
                    }
                    var 电爆气魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/电爆气魔法弹Peng"),transform).GetComponent<序列纯显示一次>();
                    电爆气魔法弹Peng.gameObject.SetActive(false);
                    电爆气魔法弹PengQueue.Enqueue(电爆气魔法弹Peng);
                    break;
                case PengType.冰大魔法弹Peng:
                    if (冰大魔法弹PengQueue.Count > 100)
                    {
                        break;
                    }
                    var 冰大魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/冰大魔法弹Peng"),transform).GetComponent<序列纯显示一次>();
                    冰大魔法弹Peng.gameObject.SetActive(false);
                    冰大魔法弹PengQueue.Enqueue(冰大魔法弹Peng);
                    break;
                case PengType.火虎魔法弹Peng:
                    if (火虎魔法弹PengQueue.Count > 100)
                    {
                        break;
                    }
                    var 火虎魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/火虎魔法弹Peng"),transform).GetComponent<序列纯显示一次>();
                    火虎魔法弹Peng.gameObject.SetActive(false);
                    火虎魔法弹PengQueue.Enqueue(火虎魔法弹Peng);
                    break;
                case PengType.黑暗魔法弹Peng:
                    if (黑暗魔法弹PengQueue.Count > 100)
                    {
                        break;
                    }
                    var 黑暗魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/黑暗魔法弹Peng"),transform).GetComponent<序列纯显示一次>();
                    黑暗魔法弹Peng.gameObject.SetActive(false);
                    黑暗魔法弹PengQueue.Enqueue(黑暗魔法弹Peng);
                    break;
                case PengType.None:
                default:
                    // None 或未知类型不处理，可根据需要添加日志或异常
                    break;
            }
            count++;
            if (count % fream == 0)
            {
                yield return null;
            }
        }
    }

    
    
    
     public IEnumerator Init怪物Queue(int fream=10)
    {
        var 普通怪数量 = LevelConfig.LevelInfos[LevelConfig.CurrentLevelSmallType].NormalMonsterCount;
        var 精英怪数量 = LevelConfig.LevelInfos[LevelConfig.CurrentLevelSmallType].EliteMonsterCount;

        int count = 0;
        for (int i = 0; i < 普通怪数量; i++)
        {
            if (普通怪Queue.Count > 普通怪数量)
            {
                break;
            }
             var 普通怪 = Instantiate(Resources.Load("Prefabs/Fight/普通怪物Item"),transform).GetComponent<普通怪>();
             普通怪.gameObject.SetActive(false);
             普通怪Queue.Enqueue(普通怪);
             count++;
             if (count % fream == 0)
             {
                 yield return null;
             }
        }

        for (int i = 0; i < 100; i++)
        {
            if (伤害数字Queue.Count > 100)
            {
                break;
            }
            var 伤害数字 = Instantiate(Resources.Load("Prefabs/Fight/伤害数字"), transform).GetComponent<伤害数字>();
            伤害数字.gameObject.SetActive(false);
            伤害数字Queue.Enqueue(伤害数字);
            count++;
            if (count % fream == 0)
            {
                yield return null;
            }
        }

        for (int i = 0; i < 50; i++)
        {
            if (普通怪死亡Queue.Count > 50)
            {
                break;
            }
            var 普通怪死亡 = Instantiate(Resources.Load("Prefabs/特效/怪物死亡特效/普通怪死亡"), transform).GetComponent<Spine纯显示一次>();
            普通怪死亡.gameObject.SetActive(false);
            普通怪死亡Queue.Enqueue(普通怪死亡);
            count++;
            if (count % fream == 0)
            {
                yield return null;
            }
        }
        for (int i = 0; i < 精英怪数量; i++)
        {
            var 精英怪 = Instantiate(Resources.Load("Prefabs/Fight/精英怪物Item"),transform).GetComponent<精英怪>();
            精英怪.gameObject.SetActive(false);
            精英怪Queue.Enqueue(精英怪);
            count++;
            if (count % fream == 0)
            {
                yield return null;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            var 精英怪死亡 = Instantiate(Resources.Load("Prefabs/特效/怪物死亡特效/精英怪死亡"),transform).GetComponent<Spine纯显示一次>();
            精英怪死亡.gameObject.SetActive(false);
            精英怪死亡Queue.Enqueue(精英怪死亡);
            
            var 首领怪死亡 = Instantiate(Resources.Load("Prefabs/特效/怪物死亡特效/首领怪死亡"),transform).GetComponent<Spine纯显示一次>();
            首领怪死亡.gameObject.SetActive(false);
            首领怪死亡Queue.Enqueue(首领怪死亡);
            
            var 首领怪 = Instantiate(Resources.Load("Prefabs/Fight/首领怪物Item"),transform).GetComponent<首领怪>();
            首领怪.gameObject.SetActive(false);
            首领怪Queue.Enqueue(首领怪);
            count++;
            if (count % fream == 0)
            {
                yield return null;
            }
        }
    }
    
     public IEnumerator Init攻击特效(攻击特效Type type,int fream=10)
    {
        int count = 0;
        for (int i = 0; i < 100; i++)
        {
            switch (type)
            {
                case 攻击特效Type.石敢当锤子:
                    if (石敢当锤子Queue.Count > 100)
                    {
                        break;
                    }
                    var 石敢当锤子 = Instantiate(Resources.Load("Prefabs/特效/石敢当锤子"),transform).GetComponent<石敢当锤子>();
                    石敢当锤子.gameObject.SetActive(false);
                    石敢当锤子Queue.Enqueue(石敢当锤子);
                    break;
                case 攻击特效Type.电魔法弹:
                    if (电魔法弹Queue.Count > 100)
                    {
                        break;
                    }
                    var 电魔法弹 = Instantiate(Resources.Load("Prefabs/特效/电魔法弹"),transform).GetComponent<普通魔法弹带peng>();
                    电魔法弹.gameObject.SetActive(false);
                    电魔法弹Queue.Enqueue(电魔法弹);
                    break;
                case 攻击特效Type.黑暗飞箭:
                    if (黑暗飞箭Queue.Count > 100)
                    {
                        break;
                    }
                    var 黑暗飞箭 = Instantiate(Resources.Load("Prefabs/特效/黑暗飞箭"),transform).GetComponent<普通魔法弹带peng>();
                    黑暗飞箭.gameObject.SetActive(false);
                    黑暗飞箭Queue.Enqueue(黑暗飞箭);
                    break;
                case 攻击特效Type.黑暗剑气:
                    if (黑暗剑气Queue.Count > 100)
                    {
                        break;
                    }
                    var 黑暗剑气 = Instantiate(Resources.Load("Prefabs/特效/黑暗剑气"),transform).GetComponent<普通魔法弹带peng>();
                    黑暗剑气.gameObject.SetActive(false);
                    黑暗剑气Queue.Enqueue(黑暗剑气);
                    break;
                case 攻击特效Type.物理箭:
                    if (物理箭Queue.Count > 100)
                    {
                        break;
                    }
                    var 物理箭 = Instantiate(Resources.Load("Prefabs/特效/物理箭"),transform).GetComponent<普通魔法弹带peng>();
                    物理箭.gameObject.SetActive(false);
                    物理箭Queue.Enqueue(物理箭);
                    break;
                case 攻击特效Type.紫鬼弹:
                    if (紫鬼弹Queue.Count > 100)
                    {
                        break;
                    }
                    var 紫鬼弹 = Instantiate(Resources.Load("Prefabs/特效/紫鬼弹"),transform).GetComponent<普通魔法弹带peng>();
                    紫鬼弹.gameObject.SetActive(false);
                    紫鬼弹Queue.Enqueue(紫鬼弹);
                    break;
                case 攻击特效Type.黑暗花魔法弹:
                    if (黑暗花魔法弹Queue.Count > 100)
                    {
                        break;
                    }
                    var 黑暗花魔法弹 = Instantiate(Resources.Load("Prefabs/特效/黑暗花魔法弹"),transform).GetComponent<普通魔法弹带peng>();
                    黑暗花魔法弹.gameObject.SetActive(false);
                    黑暗花魔法弹Queue.Enqueue(黑暗花魔法弹);
                    break;
                case 攻击特效Type.冰爆气魔法弹:
                    if (冰爆气魔法弹Queue.Count > 100)
                    {
                        break;
                    }
                    var 冰爆气魔法弹 = Instantiate(Resources.Load("Prefabs/特效/冰爆气魔法弹"),transform).GetComponent<普通魔法弹带peng>();
                    冰爆气魔法弹.gameObject.SetActive(false);
                    冰爆气魔法弹Queue.Enqueue(冰爆气魔法弹);
                    break;
                case 攻击特效Type.电龙魔法弹:
                    if (电龙魔法弹Queue.Count > 100)
                    {
                        break;
                    }
                    var 电龙魔法弹 = Instantiate(Resources.Load("Prefabs/特效/电龙魔法弹"),transform).GetComponent<普通魔法弹带peng>();
                    电龙魔法弹.gameObject.SetActive(false);
                    电龙魔法弹Queue.Enqueue(电龙魔法弹);
                    break;
                case 攻击特效Type.电爆气魔法弹:
                    if (电爆气魔法弹Queue.Count > 100)
                    {
                        break;
                    }
                    var 电爆气魔法弹 = Instantiate(Resources.Load("Prefabs/特效/电爆气魔法弹"),transform).GetComponent<普通魔法弹带peng>();
                    电爆气魔法弹.gameObject.SetActive(false);
                    电爆气魔法弹Queue.Enqueue(电爆气魔法弹);
                    break;
                case 攻击特效Type.冰大魔法弹:
                    if (冰大魔法弹Queue.Count > 100)
                    {
                        break;
                    }
                    var 冰大魔法弹 = Instantiate(Resources.Load("Prefabs/特效/冰大魔法弹"),transform).GetComponent<普通魔法弹带peng>();
                    冰大魔法弹.gameObject.SetActive(false);
                    冰大魔法弹Queue.Enqueue(冰大魔法弹);
                    break;
                case 攻击特效Type.火虎魔法弹:
                    if (火虎魔法弹Queue.Count > 100)
                    {
                        break;
                    }
                    var 火虎魔法弹 = Instantiate(Resources.Load("Prefabs/特效/火虎魔法弹"),transform).GetComponent<普通魔法弹带peng>();
                    火虎魔法弹.gameObject.SetActive(false);
                    火虎魔法弹Queue.Enqueue(火虎魔法弹);
                    break;
                case 攻击特效Type.普通火魔法弹:
                    if (普通火魔法弹Queue.Count > 100)
                    {
                        break;
                    }
                    var 普通火魔法弹 = Instantiate(Resources.Load("Prefabs/特效/普通火魔法弹"),transform).GetComponent<普通魔法弹带peng>();
                    普通火魔法弹.gameObject.SetActive(false);
                    普通火魔法弹Queue.Enqueue(普通火魔法弹);
                    break;
                case 攻击特效Type.黑暗魔法弹:
                    if (黑暗魔法弹Queue.Count > 100)
                    {
                        break;
                    }
                    var 黑暗魔法弹 = Instantiate(Resources.Load("Prefabs/特效/黑暗魔法弹"),transform).GetComponent<普通魔法弹带peng>();
                    黑暗魔法弹.gameObject.SetActive(false);
                    黑暗魔法弹Queue.Enqueue(黑暗魔法弹);
                    break;
                
                case 攻击特效Type.冰刺:
                    if (冰刺Queue.Count > 100)
                    {
                        break;
                    }
                    var 冰刺 = Instantiate(Resources.Load("Prefabs/特效/冰刺"),transform).GetComponent<序列一次伤害技能>();
                    冰刺.gameObject.SetActive(false);
                    冰刺Queue.Enqueue(冰刺);
                    break;
                case 攻击特效Type.None:
                default:
                    // None 或未知类型不处理，或可抛出异常
                    break;
            }
            count++;
            if (count % fream == 0)
            {
                yield return null;
            }
        }
    }
}
