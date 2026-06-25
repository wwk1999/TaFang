using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FightController : XSingleton<FightController>
{
    [NonSerialized] public float CreateMonsterTime = 1f;
    [NonSerialized] public float 当前创建普通怪物时间 = 0;
    [NonSerialized] public float 当前创建精英怪物时间 = 0;
    private int NormalMonsterCount = 0;
    private int EliteMonsterCount = 0;
    [NonSerialized]public int KillMonsterCount = 0;



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
    
    
    public MonsterBase GetAttackMonster()
    {
        if (Monster分区Dic[1].Count > 0)
        {
            return Monster分区Dic[1].First();
        }
        if (Monster分区Dic[2].Count > 0)
        {
            return Monster分区Dic[2].First();
        }
        if (Monster分区Dic[3].Count > 0)
        {
            return Monster分区Dic[3].First();
        }
        if (Monster分区Dic[4].Count > 0)
        {
            return Monster分区Dic[4].First();
        }
        if (Monster分区Dic[5].Count > 0)
        {
            return Monster分区Dic[5].First();
        }
        if (Monster分区Dic[6].Count > 0)
        {
            return Monster分区Dic[6].First();
        }
        if (Monster分区Dic[7].Count > 0)
        {
            return Monster分区Dic[7].First();
        }

        return null;
    }

    public void 人物攻击(HeroType hero,Vector2 shotpos,Vector2 dir)
    {
        switch (hero)
        {
            case HeroType.丹童:
                Shot普通魔法弹(攻击特效Type.普通火魔法弹,shotpos,dir,HeroConfig.HeroDamageDic[hero],HeroConfig.HeroZhiYeDic[hero].yuanSuType,8);
                break;
            case HeroType.土地:
                Shot普通魔法弹(攻击特效Type.黑暗魔法弹,shotpos,dir,HeroConfig.HeroDamageDic[hero],HeroConfig.HeroZhiYeDic[hero].yuanSuType,8);
                break;
        }
    }

    public void Shot普通魔法弹(攻击特效Type 攻击特效Type,Vector2 shotPos, Vector2 dir, float damage, YuanSuType yuanSuType,float speed)
    {
        普通魔法弹带peng 魔法弹 = null;
        switch (攻击特效Type) // 请将“攻击特效类型变量”替换为实际的变量名
        {
            case 攻击特效Type.电魔法弹:
                魔法弹 = QueueController.S.电魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.黑暗飞箭:
                魔法弹 = QueueController.S.黑暗飞箭Queue.Dequeue();
                break;
            case 攻击特效Type.黑暗剑气:
                魔法弹 = QueueController.S.黑暗剑气Queue.Dequeue();
                break;
            case 攻击特效Type.物理箭:
                魔法弹 = QueueController.S.物理箭Queue.Dequeue();
                break;
            case 攻击特效Type.紫鬼弹:
                魔法弹 = QueueController.S.紫鬼弹Queue.Dequeue();
                break;
            case 攻击特效Type.黑暗花魔法弹:
                魔法弹 = QueueController.S.黑暗花魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.冰爆气魔法弹:
                魔法弹 = QueueController.S.冰爆气魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.电龙魔法弹:
                魔法弹 = QueueController.S.电龙魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.电爆气魔法弹:
                魔法弹 = QueueController.S.电爆气魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.冰大魔法弹:
                魔法弹 = QueueController.S.冰大魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.火虎魔法弹:
                魔法弹 = QueueController.S.火虎魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.黑暗魔法弹:
                魔法弹 = QueueController.S.黑暗魔法弹Queue.Dequeue();
                break;
            case 攻击特效Type.普通火魔法弹:
                魔法弹 = QueueController.S.普通火魔法弹Queue.Dequeue();
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
                return QueueController.S.电魔法弹PengQueue.Count > 0 ? QueueController.S.电魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.黑暗飞箭:
                return QueueController.S.黑暗飞箭PengQueue.Count > 0 ? QueueController.S.黑暗飞箭PengQueue.Dequeue() : null;
            case 攻击特效Type.黑暗剑气:
                return QueueController.S.黑暗剑气PengQueue.Count > 0 ? QueueController.S.黑暗剑气PengQueue.Dequeue() : null;
            case 攻击特效Type.物理箭:
                return QueueController.S.物理箭PengQueue.Count > 0 ? QueueController.S.物理箭PengQueue.Dequeue() : null;
            case 攻击特效Type.紫鬼弹:
                return QueueController.S.紫鬼弹PengQueue.Count > 0 ? QueueController.S.紫鬼弹PengQueue.Dequeue() : null;
            case 攻击特效Type.黑暗花魔法弹:
                return QueueController.S.黑暗花魔法弹PengQueue.Count > 0 ? QueueController.S.黑暗花魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.冰爆气魔法弹:
                return QueueController.S.冰爆气魔法弹PengQueue.Count > 0 ? QueueController.S.冰爆气魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.电龙魔法弹:
                return QueueController.S.电龙魔法弹PengQueue.Count > 0 ? QueueController.S.电龙魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.电爆气魔法弹:
                return QueueController.S.电爆气魔法弹PengQueue.Count > 0 ? QueueController.S.电爆气魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.冰大魔法弹:
                return QueueController.S.冰大魔法弹PengQueue.Count > 0 ? QueueController.S.冰大魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.火虎魔法弹:
                return QueueController.S.火虎魔法弹PengQueue.Count > 0 ? QueueController.S.火虎魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.黑暗魔法弹:
                return QueueController.S.黑暗魔法弹PengQueue.Count > 0 ? QueueController.S.黑暗魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.普通火魔法弹:
                return QueueController.S.火虎魔法弹PengQueue.Count > 0 ? QueueController.S.火虎魔法弹PengQueue.Dequeue() : null;
            default:
                return null;
        }
    }
    
    public void 普通魔法弹Hide(普通魔法弹带peng 普通魔法弹带peng, 攻击特效Type type, GameObject gameObject)
    {
        switch (type)
        {
            case 攻击特效Type.电魔法弹:
                QueueController.S.电魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.黑暗飞箭:
                QueueController.S.黑暗飞箭Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.黑暗剑气:
                QueueController.S.黑暗剑气Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.物理箭:
                QueueController.S.物理箭Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.紫鬼弹:
                QueueController.S.紫鬼弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.黑暗花魔法弹:
                QueueController.S.黑暗花魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.冰爆气魔法弹:
                QueueController.S.冰爆气魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.电龙魔法弹:
                QueueController.S.电龙魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.电爆气魔法弹:
                QueueController.S.电爆气魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.冰大魔法弹:
                QueueController.S.冰大魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.火虎魔法弹:
                QueueController.S.火虎魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.黑暗魔法弹:
                QueueController.S.黑暗魔法弹Queue.Enqueue(普通魔法弹带peng);
                break;
            case 攻击特效Type.普通火魔法弹:
                QueueController.S.火虎魔法弹Queue.Enqueue(普通魔法弹带peng);
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
                QueueController.S.电魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.黑暗飞箭Peng:
                QueueController.S.黑暗飞箭PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.黑暗剑气Peng:
                QueueController.S.黑暗剑气PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.物理箭Peng:
                QueueController.S.物理箭PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.紫鬼弹Peng:
                QueueController.S.紫鬼弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.黑暗花魔法弹Peng:
                QueueController.S.黑暗花魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.冰爆气魔法弹Peng:
                QueueController.S.冰爆气魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.电龙魔法弹Peng:
                QueueController.S.电龙魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.电爆气魔法弹Peng:
                QueueController.S.电爆气魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.冰大魔法弹Peng:
                QueueController.S.冰大魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.火虎魔法弹Peng:
                QueueController.S.火虎魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case 序列纯显示一次Type.黑暗魔法弹Peng:
                QueueController.S.黑暗魔法弹PengQueue.Enqueue(序列纯显示一次);
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
                QueueController.S.普通怪死亡Queue.Enqueue(Spine纯显示一次);
                break;
            case 特效Type.精英怪死亡:
                QueueController.S.精英怪死亡Queue.Enqueue(Spine纯显示一次);
                break;
            case 特效Type.首领怪死亡:
                QueueController.S.首领怪死亡Queue.Enqueue(Spine纯显示一次);
                break;
        }
        gameObject.SetActive(false);
    }

    public void CreateNormalMonster()
    {
        float x = 10f;
        float y = Random.Range(-4f, 4f);
        var monster=QueueController.S.普通怪Queue.Dequeue();
        monster.transform.position = new Vector3(x,y,0);
        List<MonsterTypeName> list = LevelConfig.LevelMonsterDic[LevelConfig.CurrentLevelSmallType];
        int random=Random.Range(0,2);
        monster.MonsterTypeName = list[random];
        monster.gameObject.SetActive(true);
        MonsterColliderDic[monster.Collider2D] = monster;
    }
    
    public void CreateEliteMonster()
    {
        float x = 10f;
        float y = Random.Range(-4f, 4f);
        var monster=QueueController.S.精英怪Queue.Dequeue();
        monster.transform.position = new Vector3(x,y,0);
        List<MonsterTypeName> list = LevelConfig.LevelMonsterDic[LevelConfig.CurrentLevelSmallType];
        monster.MonsterTypeName = list[2];
        monster.gameObject.SetActive(true);
        MonsterColliderDic[monster.Collider2D] = monster;
    }

    private void Update()
    {
        当前创建普通怪物时间+=Time.deltaTime;
        当前创建精英怪物时间+=Time.deltaTime;
        var 普通怪物Time = LevelConfig.LevelInfos[LevelConfig.CurrentLevelSmallType].CreateNormalMonsterTime;
        var 普通怪物最大数量=LevelConfig.LevelInfos[LevelConfig.CurrentLevelSmallType].NormalMonsterCount;
        var 精英怪物Time = LevelConfig.LevelInfos[LevelConfig.CurrentLevelSmallType].CreateEliteMonsterTime;
        var 精英怪物最大数量=LevelConfig.LevelInfos[LevelConfig.CurrentLevelSmallType].EliteMonsterCount;
        if (当前创建普通怪物时间 >= 普通怪物Time&&NormalMonsterCount<普通怪物最大数量)
        {
            NormalMonsterCount++;
            CreateNormalMonster();
            当前创建普通怪物时间 = 0;
        }
        if (当前创建精英怪物时间 >= 精英怪物Time&&EliteMonsterCount<精英怪物最大数量)
        {
            EliteMonsterCount++;
            CreateEliteMonster();
            当前创建精英怪物时间 = 0;
        }
    }

    public void Show伤害数字(float 最终伤害, YuanSuType yuanSuType,Vector2 pos)
    {
        var item=QueueController.S.伤害数字Queue.Dequeue();
        item.damage = 最终伤害;
        item.YuanSuType = yuanSuType;
        item.transform.position = pos;
        item.gameObject.SetActive(true);
    }
}
