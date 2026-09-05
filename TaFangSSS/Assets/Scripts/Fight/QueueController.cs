using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;

public class QueueController:XSingleton<QueueController>
{
    [NonSerialized] public Queue<主页秘境item> 主页秘境itemQueue = new Queue<主页秘境item>();

    // 所有伤害数字共享同一个 World Space Canvas：1500 个数字同层合批为 1 个 draw call，
    // 避免每个数字自带 Canvas 导致的独立批次与逐 Canvas 重建开销
    private Transform _伤害数字CanvasRoot;
    public Transform 伤害数字CanvasRoot
    {
        get
        {
            if (_伤害数字CanvasRoot == null)
            {
                var go = new GameObject("伤害数字Canvas");
                go.layer = 5; // UI 层
                var canvas = go.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.WorldSpace;
                canvas.sortingOrder = 10000;
                var rt = (RectTransform)go.transform;
                rt.SetParent(transform, false);
                rt.localPosition = Vector3.zero;
                rt.localRotation = Quaternion.identity;
                rt.localScale = Vector3.one;
                rt.sizeDelta = new Vector2(100f, 100f);
                _伤害数字CanvasRoot = rt;
            }
            return _伤害数字CanvasRoot;
        }
    }

    
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
    [NonSerialized] public Queue<序列纯显示一次> 丹童神通PengQueue = new Queue<序列纯显示一次>();

    
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
    [NonSerialized] public Queue<普通魔法弹带peng> 冰剑气Queue = new Queue<普通魔法弹带peng>();

    
    
    [NonSerialized]public Queue<序列一次伤害技能>冰刺Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<石敢当锤子>石敢当锤子Queue = new Queue<石敢当锤子>();
    [NonSerialized]public Queue<序列一次伤害技能>玄女技能Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>龟丞相技能Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>落雷Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>嫦娥技能Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>冰龙Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>黑暗符Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<冰符>冰符Queue = new Queue<冰符>();
    [NonSerialized]public Queue<冰符>火符Queue = new Queue<冰符>();
    [NonSerialized]public Queue<冰符>盘古拳Queue = new Queue<冰符>();
    [NonSerialized] public Queue<循环伤害技能> 冰旋风Queue = new Queue<循环伤害技能>();
    [NonSerialized] public Queue<Spine一次伤害> 陨石Queue = new Queue<Spine一次伤害>();
    [NonSerialized]public Dictionary<Collider2D,MonsterBase>MonsterColliderDic = new Dictionary<Collider2D,MonsterBase>();

    
    
    
    
    
    
    [NonSerialized] public Queue<普通魔法弹带peng> 丹童神通Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized]public Queue<冰符>云霄神通Queue = new Queue<冰符>();
    [NonSerialized]public Queue<序列一次伤害技能>元始神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>哪吒神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<冰符>土地神通Queue = new Queue<冰符>();
    [NonSerialized]public Queue<序列一次伤害技能>多闻天王神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized] public Queue<普通魔法弹带peng> 太白金星神通Queue = new Queue<普通魔法弹带peng>();
    [NonSerialized]public Queue<冰符>嫦娥神通Queue = new Queue<冰符>();
    [NonSerialized]public Queue<冰符>孙悟空神通Queue = new Queue<冰符>();
    [NonSerialized]public Queue<序列一次伤害技能>常曦神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>广木天王神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>月老神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>杨戬神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<冰符>河伯神通Queue = new Queue<冰符>();
    [NonSerialized]public Queue<序列一次伤害技能>牛魔王神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>玄女神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<冰符>琼霄神通Queue = new Queue<冰符>();
    [NonSerialized]public Queue<序列一次伤害技能>盘古神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>石敢当神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>碧霄神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>老子神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<冰符>羲和神通Queue = new Queue<冰符>();
    [NonSerialized]public Queue<冰符>通天神通Queue = new Queue<冰符>();
    [NonSerialized]public Queue<序列一次伤害技能>雷震子神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<序列一次伤害技能>鸿钧神通Queue = new Queue<序列一次伤害技能>();
    [NonSerialized]public Queue<冰符>龟丞相神通Queue = new Queue<冰符>();

    
    
    protected override void Awake()
    {
        Application.targetFrameRate = 30;
        DontDestroyOnLoad(gameObject);
    }

    
    public IEnumerator InitHeroSkill()
    {
        var herolist=PlayerData.S.出战英雄List[PlayerData.S.当前出战编队-1];
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
                    if (冰大魔法弹PengQueue.Count > 200)
                    {
                        break;
                    }
                    var 冰大魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/冰大魔法弹Peng"),transform).GetComponent<序列纯显示一次>();
                    冰大魔法弹Peng.gameObject.SetActive(false);
                    冰大魔法弹PengQueue.Enqueue(冰大魔法弹Peng);
                    break;
                case PengType.火虎魔法弹Peng:
                    if (火虎魔法弹PengQueue.Count > 200)
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
                
                case PengType.丹童神通Peng:
                    if (丹童神通PengQueue.Count > 100)
                    {
                        break;
                    }
                    var 丹童神通Peng = Instantiate(Resources.Load("Prefabs/特效/神通/丹童神通peng"),transform).GetComponent<序列纯显示一次>();
                    丹童神通Peng.gameObject.SetActive(false);
                    丹童神通PengQueue.Enqueue(丹童神通Peng);
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


    public IEnumerator Init主页秘境itemQueue(int fream=5)
    {
        int count = 0;
        for (int i = 0; i < 150; i++)
        {
            count++;
           var item = Instantiate(Resources.Load("Prefabs/Window/主页秘境item"),transform).GetComponent<主页秘境item>();
            item.gameObject.SetActive(false); 
            if (count % fream == 0)
            {
                yield return null;
            }
        }
    }
    
    
     public IEnumerator Init怪物Queue(int fream=10)
     {
         int 普通怪数量 = 0;
         int 精英怪数量 = 0;
         if (LevelConfig.当前关卡类型 == 关卡类型.主线关卡)
         {
             普通怪数量 = LevelConfig.LevelInfos[LevelConfig.当前主线关卡Type].NormalMonsterCount;
             精英怪数量 = LevelConfig.LevelInfos[LevelConfig.当前主线关卡Type].EliteMonsterCount;
         }
         else if (LevelConfig.当前关卡类型 == 关卡类型.洞天秘境)
         {
             普通怪数量 = LevelConfig.洞天LevelInfos[new 洞天关卡Item(){JingJieType = PlayerData.S.当前轮回境界,qualityType = LevelConfig.当前洞天QualityType}].NormalMonsterCount;
             精英怪数量 = LevelConfig.洞天LevelInfos[new 洞天关卡Item(){JingJieType = PlayerData.S.当前轮回境界,qualityType = LevelConfig.当前洞天QualityType}].EliteMonsterCount;
         }
         else if (LevelConfig.当前关卡类型 == 关卡类型.远古遗迹)
         {
             普通怪数量 = 神物Config.遗迹关卡信息Dic[LevelConfig.当前神物Type].NormalMonsterCount;
             精英怪数量 = 神物Config.遗迹关卡信息Dic[LevelConfig.当前神物Type].EliteMonsterCount;
         }


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
             MonsterColliderDic[普通怪.Collider2D] = 普通怪;
             count++;
             if (count % fream == 0)
             {
                 yield return null;
             }
        }

        for (int i = 0; i < 1500; i++)
        {
            if (伤害数字Queue.Count > 1500)
            {
                break;
            }
            var 伤害数字 = Instantiate(Resources.Load("Prefabs/Fight/伤害数字"), 伤害数字CanvasRoot).GetComponent<伤害数字>();
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
            if (精英怪Queue.Count > 精英怪数量)
            {
                break;
            }
            var 精英怪 = Instantiate(Resources.Load("Prefabs/Fight/精英怪物Item"),transform).GetComponent<精英怪>();
            精英怪.gameObject.SetActive(false);
            精英怪Queue.Enqueue(精英怪);
            MonsterColliderDic[精英怪.Collider2D] = 精英怪;
            count++;
            if (count % fream == 0)
            {
                yield return null;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (精英怪死亡Queue.Count > 5)
            {
                break;
            }
            var 精英怪死亡 = Instantiate(Resources.Load("Prefabs/特效/怪物死亡特效/精英怪死亡"), transform).GetComponent<Spine纯显示一次>();
            精英怪死亡.gameObject.SetActive(false);
            精英怪死亡Queue.Enqueue(精英怪死亡);
        }

        for (int i = 0; i < 5; i++)
        {
            if (首领怪Queue.Count > 5)
            {
                break;
            }
        var 首领怪死亡 = Instantiate(Resources.Load("Prefabs/特效/怪物死亡特效/首领怪死亡"),transform).GetComponent<Spine纯显示一次>();
            首领怪死亡.gameObject.SetActive(false);
            首领怪死亡Queue.Enqueue(首领怪死亡);
            
            var 首领怪 = Instantiate(Resources.Load("Prefabs/Fight/首领怪物Item"),transform).GetComponent<首领怪>();
            首领怪.gameObject.SetActive(false);
            首领怪Queue.Enqueue(首领怪);
            MonsterColliderDic[首领怪.Collider2D] = 首领怪;
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
                case 攻击特效Type.陨石:
                    if (陨石Queue.Count > 50)
                    {
                        break;
                    }
                    var 陨石 = Instantiate(Resources.Load("Prefabs/特效/陨石"),transform).GetComponent<Spine一次伤害>();
                    陨石.gameObject.SetActive(false);
                    陨石Queue.Enqueue(陨石);
                    break;
                case 攻击特效Type.冰旋风:
                    if (冰旋风Queue.Count > 50)
                    {
                        break;
                    }
                    var 冰旋风 = Instantiate(Resources.Load("Prefabs/特效/冰旋风"),transform).GetComponent<循环伤害技能>();
                    冰旋风.gameObject.SetActive(false);
                    冰旋风Queue.Enqueue(冰旋风);
                    break;
                case 攻击特效Type.冰剑气:
                    if (冰剑气Queue.Count > 50)
                    {
                        break;
                    }
                    var 冰剑气 = Instantiate(Resources.Load("Prefabs/特效/冰剑气"),transform).GetComponent<普通魔法弹带peng>();
                    冰剑气.gameObject.SetActive(false);
                    冰剑气Queue.Enqueue(冰剑气);
                    break;
                case 攻击特效Type.盘古拳:
                    if (盘古拳Queue.Count > 3)
                    {
                        break;
                    }
                    var 盘古拳 = Instantiate(Resources.Load("Prefabs/特效/盘古拳"),transform).GetComponent<冰符>();
                    盘古拳.gameObject.SetActive(false);
                    盘古拳Queue.Enqueue(盘古拳);
                    break;
                case 攻击特效Type.火符:
                    if (火符Queue.Count > 2)
                    {
                        break;
                    }
                    var 火符 = Instantiate(Resources.Load("Prefabs/特效/火符"),transform).GetComponent<冰符>();
                    火符.gameObject.SetActive(false);
                    火符Queue.Enqueue(火符);
                    break;
                case 攻击特效Type.冰符:
                    if (冰符Queue.Count > 2)
                    {
                        break;
                    }
                    var 冰符 = Instantiate(Resources.Load("Prefabs/特效/冰符"),transform).GetComponent<冰符>();
                    冰符.gameObject.SetActive(false);
                    冰符Queue.Enqueue(冰符);
                    break;
                case 攻击特效Type.黑暗符:
                    if (黑暗符Queue.Count > 100)
                    {
                        break;
                    }
                    var 黑暗符 = Instantiate(Resources.Load("Prefabs/特效/黑暗符"),transform).GetComponent<序列一次伤害技能>();
                    黑暗符.gameObject.SetActive(false);
                    黑暗符Queue.Enqueue(黑暗符);
                    break;
                case 攻击特效Type.冰龙:
                    if (冰龙Queue.Count > 100)
                    {
                        break;
                    }
                    var 冰龙 = Instantiate(Resources.Load("Prefabs/特效/冰龙"),transform).GetComponent<序列一次伤害技能>();
                    冰龙.gameObject.SetActive(false);
                    冰龙Queue.Enqueue(冰龙);
                    break;
                case 攻击特效Type.嫦娥技能:
                    if (嫦娥技能Queue.Count > 100)
                    {
                        break;
                    }
                    var 嫦娥技能 = Instantiate(Resources.Load("Prefabs/特效/嫦娥技能"),transform).GetComponent<序列一次伤害技能>();
                    嫦娥技能.gameObject.SetActive(false);
                    嫦娥技能Queue.Enqueue(嫦娥技能);
                    break;
                case 攻击特效Type.落雷:
                    if (落雷Queue.Count > 100)
                    {
                        break;
                    }
                    var 落雷 = Instantiate(Resources.Load("Prefabs/特效/落雷"),transform).GetComponent<序列一次伤害技能>();
                    落雷.gameObject.SetActive(false);
                    落雷Queue.Enqueue(落雷);
                    break;
                case 攻击特效Type.龟丞相技能:
                    if (龟丞相技能Queue.Count > 100)
                    {
                        break;
                    }
                    var 龟丞相技能 = Instantiate(Resources.Load("Prefabs/特效/龟丞相技能"),transform).GetComponent<序列一次伤害技能>();
                    龟丞相技能.gameObject.SetActive(false);
                    龟丞相技能Queue.Enqueue(龟丞相技能);
                    break;
                case 攻击特效Type.玄女技能:
                    if (玄女技能Queue.Count > 100)
                    {
                        break;
                    }
                    var 玄女技能 = Instantiate(Resources.Load("Prefabs/特效/玄女技能"),transform).GetComponent<序列一次伤害技能>();
                    玄女技能.gameObject.SetActive(false);
                    玄女技能Queue.Enqueue(玄女技能);
                    break;
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
                    if (物理箭Queue.Count > 250)
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
                
                
                
                
                
                case 攻击特效Type.丹童神通:
                    if (丹童神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 丹童神通 = Instantiate(Resources.Load("Prefabs/特效/神通/丹童神通"),transform).GetComponent<普通魔法弹带peng>();
                    丹童神通.gameObject.SetActive(false);
                    丹童神通Queue.Enqueue(丹童神通);
                    break;
                
                case 攻击特效Type.太白金星神通:
                    if (太白金星神通Queue.Count > 6)
                    {
                        break;
                    }
                    var 太白金星神通 = Instantiate(Resources.Load("Prefabs/特效/神通/太白金星神通"),transform).GetComponent<普通魔法弹带peng>();
                    太白金星神通.gameObject.SetActive(false);
                    太白金星神通Queue.Enqueue(太白金星神通);
                    break;
                
                case 攻击特效Type.云霄神通:
                    if (云霄神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 云霄神通 = Instantiate(Resources.Load("Prefabs/特效/神通/云霄神通"),transform).GetComponent<冰符>();
                    云霄神通.gameObject.SetActive(false);
                    云霄神通Queue.Enqueue(云霄神通);
                    break;
                
                case 攻击特效Type.土地神通:
                    if (土地神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 土地神通 = Instantiate(Resources.Load("Prefabs/特效/神通/土地神通"),transform).GetComponent<冰符>();
                    土地神通.gameObject.SetActive(false);
                    土地神通Queue.Enqueue(土地神通);
                    break;
                case 攻击特效Type.孙悟空神通:
                    if (孙悟空神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 孙悟空神通 = Instantiate(Resources.Load("Prefabs/特效/神通/孙悟空神通"),transform).GetComponent<冰符>();
                    孙悟空神通.gameObject.SetActive(false);
                    孙悟空神通Queue.Enqueue(孙悟空神通);
                    break;
                case 攻击特效Type.琼霄神通:
                    if (琼霄神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 琼霄神通 = Instantiate(Resources.Load("Prefabs/特效/神通/琼霄神通"),transform).GetComponent<冰符>();
                    琼霄神通.gameObject.SetActive(false);
                    琼霄神通Queue.Enqueue(琼霄神通);
                    break;
                case 攻击特效Type.嫦娥神通:
                    if (嫦娥神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 嫦娥神通 = Instantiate(Resources.Load("Prefabs/特效/神通/嫦娥神通"),transform).GetComponent<冰符>();
                    嫦娥神通.gameObject.SetActive(false);
                    嫦娥神通Queue.Enqueue(嫦娥神通);
                    break;
                case 攻击特效Type.羲和神通:
                    if (羲和神通Queue.Count > 6)
                    {
                        break;
                    }
                    var 羲和神通 = Instantiate(Resources.Load("Prefabs/特效/神通/羲和神通"),transform).GetComponent<冰符>();
                    羲和神通.gameObject.SetActive(false);
                    羲和神通Queue.Enqueue(羲和神通);
                    break;
                case 攻击特效Type.通天神通:
                    if (通天神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 通天神通 = Instantiate(Resources.Load("Prefabs/特效/神通/通天神通"),transform).GetComponent<冰符>();
                    通天神通.gameObject.SetActive(false);
                    通天神通Queue.Enqueue(通天神通);
                    break;
                case 攻击特效Type.河伯神通:
                    if (河伯神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 河伯神通 = Instantiate(Resources.Load("Prefabs/特效/神通/河伯神通"),transform).GetComponent<冰符>();
                    河伯神通.gameObject.SetActive(false);
                    河伯神通Queue.Enqueue(河伯神通);
                    break;
                case 攻击特效Type.龟丞相神通:
                    if (龟丞相神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 龟丞相神通 = Instantiate(Resources.Load("Prefabs/特效/神通/龟丞相神通"),transform).GetComponent<冰符>();
                    龟丞相神通.gameObject.SetActive(false);
                    龟丞相神通Queue.Enqueue(龟丞相神通);
                    break;
                
                
                case 攻击特效Type.元始神通:
                    if (元始神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 元始神通 = Instantiate(Resources.Load("Prefabs/特效/神通/元始神通"),transform).GetComponent<序列一次伤害技能>();
                    元始神通.gameObject.SetActive(false);
                    元始神通Queue.Enqueue(元始神通);
                    break;
                
                case 攻击特效Type.鸿钧神通:
                    if (鸿钧神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 鸿钧神通 = Instantiate(Resources.Load("Prefabs/特效/神通/鸿钧神通"),transform).GetComponent<序列一次伤害技能>();
                    鸿钧神通.gameObject.SetActive(false);
                    鸿钧神通Queue.Enqueue(鸿钧神通);
                    break;
                
                case 攻击特效Type.老子神通:
                    if (老子神通Queue.Count > 6)
                    {
                        break;
                    }
                    var 老子神通 = Instantiate(Resources.Load("Prefabs/特效/神通/老子神通"),transform).GetComponent<序列一次伤害技能>();
                    老子神通.gameObject.SetActive(false);
                    老子神通Queue.Enqueue(老子神通);
                    break;
                
                case 攻击特效Type.碧霄神通:
                    if (碧霄神通Queue.Count > 30)
                    {
                        break;
                    }
                    var 碧霄神通 = Instantiate(Resources.Load("Prefabs/特效/神通/碧霄神通"),transform).GetComponent<序列一次伤害技能>();
                    碧霄神通.gameObject.SetActive(false);
                    碧霄神通Queue.Enqueue(碧霄神通);
                    break;
                
                case 攻击特效Type.石敢当神通:
                    if (石敢当神通Queue.Count > 6)
                    {
                        break;
                    }
                    var 石敢当神通 = Instantiate(Resources.Load("Prefabs/特效/神通/石敢当神通"),transform).GetComponent<序列一次伤害技能>();
                    石敢当神通.gameObject.SetActive(false);
                    石敢当神通Queue.Enqueue(石敢当神通);
                    break;
                
                case 攻击特效Type.盘古神通:
                    if (盘古神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 盘古神通 = Instantiate(Resources.Load("Prefabs/特效/神通/盘古神通"),transform).GetComponent<序列一次伤害技能>();
                    盘古神通.gameObject.SetActive(false);
                    盘古神通Queue.Enqueue(盘古神通);
                    break;
                
                case 攻击特效Type.玄女神通:
                    if (玄女神通Queue.Count > 30)
                    {
                        break;
                    }
                    var 玄女神通 = Instantiate(Resources.Load("Prefabs/特效/神通/玄女神通"),transform).GetComponent<序列一次伤害技能>();
                    玄女神通.gameObject.SetActive(false);
                    玄女神通Queue.Enqueue(玄女神通);
                    break;
                
                case 攻击特效Type.牛魔王神通:
                    if (牛魔王神通Queue.Count > 6)
                    {
                        break;
                    }
                    var 牛魔王神通 = Instantiate(Resources.Load("Prefabs/特效/神通/牛魔王神通"),transform).GetComponent<序列一次伤害技能>();
                    牛魔王神通.gameObject.SetActive(false);
                    牛魔王神通Queue.Enqueue(牛魔王神通);
                    break;
                
                case 攻击特效Type.杨戬神通:
                    if (杨戬神通Queue.Count > 6)
                    {
                        break;
                    }
                    var 杨戬神通 = Instantiate(Resources.Load("Prefabs/特效/神通/杨戬神通"),transform).GetComponent<序列一次伤害技能>();
                    杨戬神通.gameObject.SetActive(false);
                    杨戬神通Queue.Enqueue(杨戬神通);
                    break;
                case 攻击特效Type.月老神通:
                    if (月老神通Queue.Count > 20)
                    {
                        break;
                    }
                    var 月老神通 = Instantiate(Resources.Load("Prefabs/特效/神通/月老神通"),transform).GetComponent<序列一次伤害技能>();
                    月老神通.gameObject.SetActive(false);
                    月老神通Queue.Enqueue(月老神通);
                    break;
                
                case 攻击特效Type.常曦神通:
                    if (常曦神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 常曦神通 = Instantiate(Resources.Load("Prefabs/特效/神通/常曦神通"),transform).GetComponent<序列一次伤害技能>();
                    常曦神通.gameObject.SetActive(false);
                    常曦神通Queue.Enqueue(常曦神通);
                    break;
                
                case 攻击特效Type.广木天王神通:
                    if (广木天王神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 广木天王神通 = Instantiate(Resources.Load("Prefabs/特效/神通/广木天王神通"),transform).GetComponent<序列一次伤害技能>();
                    广木天王神通.gameObject.SetActive(false);
                    广木天王神通Queue.Enqueue(广木天王神通);
                    break;
                
                case 攻击特效Type.多闻天王神通:
                    if (多闻天王神通Queue.Count > 2)
                    {
                        break;
                    }
                    var 多闻天王神通 = Instantiate(Resources.Load("Prefabs/特效/神通/多闻天王神通"),transform).GetComponent<序列一次伤害技能>();
                    多闻天王神通.gameObject.SetActive(false);
                    多闻天王神通Queue.Enqueue(多闻天王神通);
                    break;
                
                case 攻击特效Type.哪吒神通:
                    if (哪吒神通Queue.Count > 30)
                    {
                        break;
                    }
                    var 哪吒神通 = Instantiate(Resources.Load("Prefabs/特效/神通/哪吒神通"),transform).GetComponent<序列一次伤害技能>();
                    哪吒神通.gameObject.SetActive(false);
                    哪吒神通Queue.Enqueue(哪吒神通);
                    break;
                
                case 攻击特效Type.雷震子神通:
                    if (雷震子神通Queue.Count > 30)
                    {
                        break;
                    }
                    var 雷震子神通 = Instantiate(Resources.Load("Prefabs/特效/神通/雷震子神通"),transform).GetComponent<序列一次伤害技能>();
                    雷震子神通.gameObject.SetActive(false);
                    雷震子神通Queue.Enqueue(雷震子神通);
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
