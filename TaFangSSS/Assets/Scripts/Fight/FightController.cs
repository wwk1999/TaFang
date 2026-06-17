using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class FightController : XSingleton<FightController>
{
    [NonSerialized] public float CreateMonsterTime = 1f;
    [NonSerialized] public float CurrentCreateMonsterTime = 0;

    [NonSerialized] public Dictionary<int, HashSet<MonsterBase>> Monster分区Dic = new Dictionary<int, HashSet<MonsterBase>>()
    {
        { 1, new HashSet<MonsterBase>() },
        { 2, new HashSet<MonsterBase>() },
        { 3, new HashSet<MonsterBase>() },
        { 4, new HashSet<MonsterBase>() },
        { 5, new HashSet<MonsterBase>() },
        { 6, new HashSet<MonsterBase>() },
        { 7, new HashSet<MonsterBase>() },
    };
    [NonSerialized]public Dictionary<Collider2D,MonsterBase>MonsterColliderDic = new Dictionary<Collider2D,MonsterBase>();
    
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

    public Vector2 GetAttackPostion()
    {
        if (Monster分区Dic[1].Count > 0)
        {
            return Monster分区Dic[1].First().gameObject.transform.position;
        }
        if (Monster分区Dic[2].Count > 0)
        {
            return Monster分区Dic[2].First().gameObject.transform.position;
        }
        if (Monster分区Dic[3].Count > 0)
        {
            return Monster分区Dic[3].First().gameObject.transform.position;
        }
        if (Monster分区Dic[4].Count > 0)
        {
            return Monster分区Dic[4].First().gameObject.transform.position;
        }
        if (Monster分区Dic[5].Count > 0)
        {
            return Monster分区Dic[5].First().gameObject.transform.position;
        }
        if (Monster分区Dic[6].Count > 0)
        {
            return Monster分区Dic[6].First().gameObject.transform.position;
        }
        if (Monster分区Dic[7].Count > 0)
        {
            return Monster分区Dic[7].First().gameObject.transform.position;
        }

        return new Vector2(10000,10000);
    }

    public void Shot普通魔法弹(攻击特效Type 攻击特效Type,Vector2 shotPos, Vector2 dir, float damage, YuanSuType yuanSuType,float speed)
    {
        普通魔法弹带peng 魔法弹 = null;
        switch (攻击特效Type) // 请将“攻击特效类型变量”替换为实际的变量名
        {
            case 攻击特效Type.电魔法弹:
                魔法弹 = 电魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.黑暗飞箭:
                魔法弹 = 黑暗飞箭Queue.Dequeue();
                break;
            case 攻击特效Type.黑暗剑气:
                魔法弹 = 黑暗剑气Queue.Dequeue();
                break;
            case 攻击特效Type.物理箭:
                魔法弹 = 物理箭Queue.Dequeue();
                break;
            case 攻击特效Type.紫鬼弹:
                魔法弹 = 紫鬼弹Queue.Dequeue();
                break;
            case 攻击特效Type.黑暗花魔法弹:
                魔法弹 = 黑暗花魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.冰爆气魔法弹:
                魔法弹 = 冰爆气魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.电龙魔法弹:
                魔法弹 = 电龙魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.电爆气魔法弹:
                魔法弹 = 电爆气魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.冰大魔法弹:
                魔法弹 = 冰大魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.火虎魔法弹:
                魔法弹 = 火虎魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.黑暗魔法弹:
                魔法弹 = 黑暗魔法弹Queue.Dequeue();
                break;
        }
        魔法弹.transform.position = shotPos;
        魔法弹.damage = damage;
        魔法弹.MoveDirection = dir;
        魔法弹.MoveSpeed = speed;
        魔法弹.YuanSuType = yuanSuType;
        魔法弹.gameObject.SetActive(true);

    }
    public 序列纯显示一次 GetPeng(攻击特效Type type)
    {
        switch (type)
        {
            case 攻击特效Type.电魔法弹:
                return 电魔法弹PengQueue.Count > 0 ? 电魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.黑暗飞箭:
                return 黑暗飞箭PengQueue.Count > 0 ? 黑暗飞箭PengQueue.Dequeue() : null;
            case 攻击特效Type.黑暗剑气:
                return 黑暗剑气PengQueue.Count > 0 ? 黑暗剑气PengQueue.Dequeue() : null;
            case 攻击特效Type.物理箭:
                return 物理箭PengQueue.Count > 0 ? 物理箭PengQueue.Dequeue() : null;
            case 攻击特效Type.紫鬼弹:
                return 紫鬼弹PengQueue.Count > 0 ? 紫鬼弹PengQueue.Dequeue() : null;
            case 攻击特效Type.黑暗花魔法弹:
                return 黑暗花魔法弹PengQueue.Count > 0 ? 黑暗花魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.冰爆气魔法弹:
                return 冰爆气魔法弹PengQueue.Count > 0 ? 冰爆气魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.电龙魔法弹:
                return 电龙魔法弹PengQueue.Count > 0 ? 电龙魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.电爆气魔法弹:
                return 电爆气魔法弹PengQueue.Count > 0 ? 电爆气魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.冰大魔法弹:
                return 冰大魔法弹PengQueue.Count > 0 ? 冰大魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.火虎魔法弹:
                return 火虎魔法弹PengQueue.Count > 0 ? 火虎魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.黑暗魔法弹:
                return 黑暗魔法弹PengQueue.Count > 0 ? 黑暗魔法弹PengQueue.Dequeue() : null;
            default:
                return null;
        }
    }
    
    public void 普通魔法弹Hide(普通魔法弹带peng 普通魔法弹带peng, 攻击特效Type type, GameObject gameObject)
    {
        switch (type)
        {
            case 攻击特效Type.电魔法弹:
                电魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.黑暗飞箭:
                黑暗飞箭Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.黑暗剑气:
                黑暗剑气Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.物理箭:
                物理箭Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.紫鬼弹:
                紫鬼弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.黑暗花魔法弹:
                黑暗花魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.冰爆气魔法弹:
                冰爆气魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.电龙魔法弹:
                电龙魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.电爆气魔法弹:
                电爆气魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.冰大魔法弹:
                冰大魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.火虎魔法弹:
                火虎魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.黑暗魔法弹:
                黑暗魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.None:
            default:
                // None 或未知类型不处理，或者可加入默认逻辑
                break;
        }
        gameObject.SetActive(false);
    }
    
    public void 序列纯显示一次Hide(序列纯显示一次 序列纯显示一次, 序列纯显示一次Type type, GameObject gameObject)
    {
        switch (type)
        {
            case 序列纯显示一次Type.电魔法弹Peng:
                电魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.黑暗飞箭Peng:
                黑暗飞箭PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.黑暗剑气Peng:
                黑暗剑气PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.物理箭Peng:
                物理箭PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.紫鬼弹Peng:
                紫鬼弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.黑暗花魔法弹Peng:
                黑暗花魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.冰爆气魔法弹Peng:
                冰爆气魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.电龙魔法弹Peng:
                电龙魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.电爆气魔法弹Peng:
                电爆气魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.冰大魔法弹Peng:
                冰大魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.火虎魔法弹Peng:
                火虎魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.黑暗魔法弹Peng:
                黑暗魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            default:
                // 可选的默认处理，比如抛出异常或忽略
                break;
        }
        gameObject.SetActive(false);
    }
    
    public void Spine纯显示一次Hide(Spine纯显示一次 Spine纯显示一次,特效Type type,GameObject gameObject)
    {
        switch (type)
        {
            case 特效Type.普通怪死亡:
                普通怪死亡Queue.Enqueue(Spine纯显示一次);
                break;
            case 特效Type.精英怪死亡:
                精英怪死亡Queue.Enqueue(Spine纯显示一次);
                break;
            case 特效Type.首领怪死亡:
                首领怪死亡Queue.Enqueue(Spine纯显示一次);
                break;
        }
        gameObject.SetActive(false);
    }

    public void CreateNormalMonster()
    {
        float x = 10f;
        float y = Random.Range(-4f, 4f);
        var monster=普通怪Queue.Dequeue();
        monster.transform.position = new Vector3(x,y,0);
        List<MonsterTypeName> list = LevelConfig.LevelMonsterDic[LevelConfig.CurrentLevelSmallType];
        int random=Random.Range(0,2);
        monster.MonsterTypeName = list[random];
        monster.gameObject.SetActive(true);
        MonsterColliderDic[monster.Collider2D] = monster;
    }

    private void Update()
    {
        CurrentCreateMonsterTime+=Time.deltaTime;
        if (CurrentCreateMonsterTime >= CreateMonsterTime)
        {
            CreateNormalMonster();
            CurrentCreateMonsterTime = 0;
        }
    }

    public void InitPeng(序列纯显示一次Type type)
    {
        for (int i = 0; i < 100; i++)
        {
            switch (type)
            {
                case 序列纯显示一次Type.电魔法弹Peng:
                    var 电魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/电魔法弹Peng")).GetComponent<序列纯显示一次>();
                    电魔法弹PengQueue.Enqueue(电魔法弹Peng);
                    break;
                case 序列纯显示一次Type.黑暗飞箭Peng:
                    var 黑暗飞箭Peng = Instantiate(Resources.Load("Prefabs/特效/黑暗飞箭Peng")).GetComponent<序列纯显示一次>();
                    黑暗飞箭PengQueue.Enqueue(黑暗飞箭Peng);
                    break;
                case 序列纯显示一次Type.黑暗剑气Peng:
                    var 黑暗剑气Peng = Instantiate(Resources.Load("Prefabs/特效/黑暗剑气Peng")).GetComponent<序列纯显示一次>();
                    黑暗剑气PengQueue.Enqueue(黑暗剑气Peng);
                    break;
                case 序列纯显示一次Type.物理箭Peng:
                    var 物理箭Peng = Instantiate(Resources.Load("Prefabs/特效/物理箭Peng")).GetComponent<序列纯显示一次>();
                    物理箭PengQueue.Enqueue(物理箭Peng);
                    break;
                case 序列纯显示一次Type.紫鬼弹Peng:
                    var 紫鬼弹Peng = Instantiate(Resources.Load("Prefabs/特效/紫鬼弹Peng")).GetComponent<序列纯显示一次>();
                    紫鬼弹PengQueue.Enqueue(紫鬼弹Peng);
                    break;
                case 序列纯显示一次Type.黑暗花魔法弹Peng:
                    var 黑暗花魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/黑暗花魔法弹Peng")).GetComponent<序列纯显示一次>();
                    黑暗花魔法弹PengQueue.Enqueue(黑暗花魔法弹Peng);
                    break;
                case 序列纯显示一次Type.冰爆气魔法弹Peng:
                    var 冰爆气魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/冰爆气魔法弹Peng")).GetComponent<序列纯显示一次>();
                    冰爆气魔法弹PengQueue.Enqueue(冰爆气魔法弹Peng);
                    break;
                case 序列纯显示一次Type.电龙魔法弹Peng:
                    var 电龙魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/电龙魔法弹Peng")).GetComponent<序列纯显示一次>();
                    电龙魔法弹PengQueue.Enqueue(电龙魔法弹Peng);
                    break;
                case 序列纯显示一次Type.电爆气魔法弹Peng:
                    var 电爆气魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/电爆气魔法弹Peng")).GetComponent<序列纯显示一次>();
                    电爆气魔法弹PengQueue.Enqueue(电爆气魔法弹Peng);
                    break;
                case 序列纯显示一次Type.冰大魔法弹Peng:
                    var 冰大魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/冰大魔法弹Peng")).GetComponent<序列纯显示一次>();
                    冰大魔法弹PengQueue.Enqueue(冰大魔法弹Peng);
                    break;
                case 序列纯显示一次Type.火虎魔法弹Peng:
                    var 火虎魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/火虎魔法弹Peng")).GetComponent<序列纯显示一次>();
                    火虎魔法弹PengQueue.Enqueue(火虎魔法弹Peng);
                    break;
                case 序列纯显示一次Type.黑暗魔法弹Peng:
                    var 黑暗魔法弹Peng = Instantiate(Resources.Load("Prefabs/特效/黑暗魔法弹Peng")).GetComponent<序列纯显示一次>();
                    黑暗魔法弹PengQueue.Enqueue(黑暗魔法弹Peng);
                    break;
                case 序列纯显示一次Type.None:
                default:
                    // None 或未知类型不处理，可根据需要添加日志或异常
                    break;
            }
        }
    }

    public void Init攻击特效(攻击特效Type type)
    {
        for (int i = 0; i < 100; i++)
        {
            switch (type)
            {
                case 攻击特效Type.电魔法弹:
                    var 电魔法弹 = Instantiate(Resources.Load("Prefabs/特效/电魔法弹")).GetComponent<普通魔法弹带peng>();
                    电魔法弹Queue.Enqueue(电魔法弹);
                    break;
                case 攻击特效Type.黑暗飞箭:
                    var 黑暗飞箭 = Instantiate(Resources.Load("Prefabs/特效/黑暗飞箭")).GetComponent<普通魔法弹带peng>();
                    黑暗飞箭Queue.Enqueue(黑暗飞箭);
                    break;
                case 攻击特效Type.黑暗剑气:
                    var 黑暗剑气 = Instantiate(Resources.Load("Prefabs/特效/黑暗剑气")).GetComponent<普通魔法弹带peng>();
                    黑暗剑气Queue.Enqueue(黑暗剑气);
                    break;
                case 攻击特效Type.物理箭:
                    var 物理箭 = Instantiate(Resources.Load("Prefabs/特效/物理箭")).GetComponent<普通魔法弹带peng>();
                    物理箭Queue.Enqueue(物理箭);
                    break;
                case 攻击特效Type.紫鬼弹:
                    var 紫鬼弹 = Instantiate(Resources.Load("Prefabs/特效/紫鬼弹")).GetComponent<普通魔法弹带peng>();
                    紫鬼弹Queue.Enqueue(紫鬼弹);
                    break;
                case 攻击特效Type.黑暗花魔法弹:
                    var 黑暗花魔法弹 = Instantiate(Resources.Load("Prefabs/特效/黑暗花魔法弹")).GetComponent<普通魔法弹带peng>();
                    黑暗花魔法弹Queue.Enqueue(黑暗花魔法弹);
                    break;
                case 攻击特效Type.冰爆气魔法弹:
                    var 冰爆气魔法弹 = Instantiate(Resources.Load("Prefabs/特效/冰爆气魔法弹")).GetComponent<普通魔法弹带peng>();
                    冰爆气魔法弹Queue.Enqueue(冰爆气魔法弹);
                    break;
                case 攻击特效Type.电龙魔法弹:
                    var 电龙魔法弹 = Instantiate(Resources.Load("Prefabs/特效/电龙魔法弹")).GetComponent<普通魔法弹带peng>();
                    电龙魔法弹Queue.Enqueue(电龙魔法弹);
                    break;
                case 攻击特效Type.电爆气魔法弹:
                    var 电爆气魔法弹 = Instantiate(Resources.Load("Prefabs/特效/电爆气魔法弹")).GetComponent<普通魔法弹带peng>();
                    电爆气魔法弹Queue.Enqueue(电爆气魔法弹);
                    break;
                case 攻击特效Type.冰大魔法弹:
                    var 冰大魔法弹 = Instantiate(Resources.Load("Prefabs/特效/冰大魔法弹")).GetComponent<普通魔法弹带peng>();
                    冰大魔法弹Queue.Enqueue(冰大魔法弹);
                    break;
                case 攻击特效Type.火虎魔法弹:
                    var 火虎魔法弹 = Instantiate(Resources.Load("Prefabs/特效/火虎魔法弹")).GetComponent<普通魔法弹带peng>();
                    火虎魔法弹Queue.Enqueue(火虎魔法弹);
                    break;
                case 攻击特效Type.黑暗魔法弹:
                    var 黑暗魔法弹 = Instantiate(Resources.Load("Prefabs/特效/黑暗魔法弹")).GetComponent<普通魔法弹带peng>();
                    黑暗魔法弹Queue.Enqueue(黑暗魔法弹);
                    break;
                case 攻击特效Type.None:
                default:
                    // None 或未知类型不处理，或可抛出异常
                    break;
            }
        }
    }

    public void InitHeroSkill()
    {
        var herolist=PlayerData.S.出战英雄List[PlayerData.S.CurrentBianDui-1];
        foreach (var hero in herolist)
        {
            if (HeroConfig.HeroSkillDic.ContainsKey(hero)&&hero!=HeroType.None)
            {
                foreach (var item in HeroConfig.HeroSkillDic[hero].攻击特效List)
                {
                    Init攻击特效(item);
                }
                foreach (var item in HeroConfig.HeroSkillDic[hero].PengList)
                {
                    InitPeng(item);
                }
            }
        }
    }

    public void Init怪物死亡Queue()
    {
        for (int i = 0; i < 100; i++)
        {
            var 普通怪 = Instantiate(Resources.Load("Prefabs/Fight/普通怪物Item")).GetComponent<普通怪>();
            普通怪.gameObject.SetActive(false);
            普通怪Queue.Enqueue(普通怪);
            var 伤害数字 = Instantiate(Resources.Load("Prefabs/Fight/伤害数字")).GetComponent<伤害数字>();
            伤害数字.gameObject.SetActive(false);
            伤害数字Queue.Enqueue(伤害数字);
            var 普通怪死亡 = Instantiate(Resources.Load("Prefabs/特效/普通怪死亡")).GetComponent<Spine纯显示一次>();
            普通怪死亡.gameObject.SetActive(false);
            普通怪死亡Queue.Enqueue(普通怪死亡);
        }

        for (int i = 0; i < 5; i++)
        {
            var 精英怪死亡 = Instantiate(Resources.Load("Prefabs/特效/精英怪死亡")).GetComponent<Spine纯显示一次>();
            精英怪死亡.gameObject.SetActive(false);
            精英怪死亡Queue.Enqueue(精英怪死亡);
            
            var 首领怪死亡 = Instantiate(Resources.Load("Prefabs/特效/首领怪死亡")).GetComponent<Spine纯显示一次>();
            首领怪死亡.gameObject.SetActive(false);
            首领怪死亡Queue.Enqueue(首领怪死亡);
            
            var 精英怪 = Instantiate(Resources.Load("Prefabs/Fight/精英怪物Item")).GetComponent<精英怪>();
            精英怪.gameObject.SetActive(false);
            精英怪Queue.Enqueue(精英怪);
            
            var 首领怪 = Instantiate(Resources.Load("Prefabs/Fight/首领怪物Item")).GetComponent<首领怪>();
            首领怪.gameObject.SetActive(false);
            首领怪Queue.Enqueue(首领怪);
        }
    }

    public void Show伤害数字(float 最终伤害, YuanSuType yuanSuType,Vector2 pos)
    {
        var item=伤害数字Queue.Dequeue();
        item.damage = 最终伤害;
        item.YuanSuType = yuanSuType;
        item.transform.position = pos;
        item.gameObject.SetActive(true);
    }
}
