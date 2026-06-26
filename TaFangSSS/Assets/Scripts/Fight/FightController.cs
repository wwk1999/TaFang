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
    [NonSerialized] public Dictionary<HeroType, 人物item> 人物items = new Dictionary<HeroType, 人物item>();

    [NonSerialized] public bool 战斗结束 = false;

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

    public void 人物攻击(HeroType hero,Vector2 shotpos,Vector2 dir,Vector2 targetPos,float 瑶池冰辅助)
    {
        switch (hero)
        {
            case HeroType.丹童:
                Shot普通魔法弹(攻击特效Type.普通火魔法弹,shotpos,dir,HeroConfig.HeroDamageDic[hero],HeroConfig.HeroZhiYeDic[hero].yuanSuType,8,瑶池冰辅助);
                break;
            case HeroType.土地:
                Shot普通魔法弹(攻击特效Type.黑暗魔法弹,shotpos,dir,HeroConfig.HeroDamageDic[hero],HeroConfig.HeroZhiYeDic[hero].yuanSuType,8,瑶池冰辅助);
                break;
            case HeroType.河伯:
                一次伤害技能(攻击特效Type.冰刺, targetPos,瑶池冰辅助>0);           
                break;
            case HeroType.瑶池仙女:
                瑶池冰辅助技能();
                break;
            case HeroType.石敢当:
                石敢当技能(dir,shotpos);
                break;
            case HeroType.玄女:
                一次伤害技能(攻击特效Type.玄女技能, targetPos,瑶池冰辅助>0);           
                break;
            case HeroType.龟丞相:
                一次伤害技能(攻击特效Type.龟丞相技能, targetPos,瑶池冰辅助>0);           
                break;
            case HeroType.太白金星:
                Shot普通魔法弹(攻击特效Type.电魔法弹,shotpos,dir,HeroConfig.HeroDamageDic[hero],HeroConfig.HeroZhiYeDic[hero].yuanSuType,8,瑶池冰辅助);
                break;
            case HeroType.多闻天王:
                Shot普通魔法弹(攻击特效Type.黑暗花魔法弹,shotpos,dir,HeroConfig.HeroDamageDic[hero],HeroConfig.HeroZhiYeDic[hero].yuanSuType,8,瑶池冰辅助);
                break;
            case HeroType.雷震子:
                一次伤害技能(攻击特效Type.落雷, targetPos,瑶池冰辅助>0);           
                break;
            case HeroType.月老:
                Shot普通魔法弹(攻击特效Type.火虎魔法弹,shotpos,dir,HeroConfig.HeroDamageDic[hero],HeroConfig.HeroZhiYeDic[hero].yuanSuType,8,瑶池冰辅助);
                break;
            case HeroType.嫦娥:
                一次伤害技能(攻击特效Type.嫦娥技能, targetPos,瑶池冰辅助>0);           
                break;
        }
    }

    public void 石敢当技能(Vector2 dir,Vector2 shotpos)
    {
        var item = QueueController.S.石敢当锤子Queue.Dequeue();
        item.dir = dir;
        item.speed = 10;
        item.transform.position = shotpos;
        item.gameObject.SetActive(true);
    }
    public void 瑶池冰辅助技能()
    {
        var random=Random.Range(0,人物items.Count);
        HeroType[] keysArray = 人物items.Keys.ToArray();
        HeroType randomKey = keysArray[random];
        人物item randomValue = 人物items[randomKey];
        while (randomValue.heroType==HeroType.瑶池仙女)
        {
            random=Random.Range(0,人物items.Count);
            randomKey = keysArray[random];
            randomValue = 人物items[randomKey];
        }

        randomValue.瑶池冰辅助 = 5f;
    }

    public void 一次伤害技能(攻击特效Type 攻击特效Type, Vector2 pos,bool 瑶池冰辅助)
    {
        switch (攻击特效Type)
        {
            case 攻击特效Type.嫦娥技能:
                var 嫦娥技能 = QueueController.S.嫦娥技能Queue.Dequeue();
                嫦娥技能.transform.position = pos;
                嫦娥技能.脚本.瑶池冰辅助 = 瑶池冰辅助;
                嫦娥技能.gameObject.SetActive(true);
                break;
            case 攻击特效Type.冰刺:
                var item = QueueController.S.冰刺Queue.Dequeue();
                item.transform.position = pos;
                item.脚本.瑶池冰辅助 = 瑶池冰辅助;
                item.gameObject.SetActive(true);
                break;
            case 攻击特效Type.玄女技能:
                var 玄女技能 = QueueController.S.玄女技能Queue.Dequeue();
                玄女技能.transform.position = pos;
                玄女技能.脚本.瑶池冰辅助 = 瑶池冰辅助;
                玄女技能.gameObject.SetActive(true);
                break;
            case 攻击特效Type.龟丞相技能:
                var 龟丞相技能 = QueueController.S.龟丞相技能Queue.Dequeue();
                龟丞相技能.transform.position = pos;
                龟丞相技能.脚本.瑶池冰辅助 = 瑶池冰辅助;
                龟丞相技能.gameObject.SetActive(true);
                break;
            case 攻击特效Type.落雷:
                var 落雷 = QueueController.S.落雷Queue.Dequeue();
                落雷.transform.position = pos;
                落雷.脚本.瑶池冰辅助 = 瑶池冰辅助;
                落雷.gameObject.SetActive(true);
                break;
        }
    }

    public void Shot普通魔法弹(攻击特效Type 攻击特效Type,Vector2 shotPos, Vector2 dir, float damage, YuanSuType yuanSuType,float speed,float 瑶池冰辅助)
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
        魔法弹.瑶池冰辅助 = 瑶池冰辅助>0;
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
    
    public void 序列纯显示一次Hide(序列纯显示一次 序列纯显示一次, PengType type, GameObject gameObject)
    {
        switch (type)
        {
            case PengType.电魔法弹Peng:
                QueueController.S.电魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case PengType.黑暗飞箭Peng:
                QueueController.S.黑暗飞箭PengQueue.Enqueue(序列纯显示一次);
                break;
            case PengType.黑暗剑气Peng:
                QueueController.S.黑暗剑气PengQueue.Enqueue(序列纯显示一次);
                break;
            case PengType.物理箭Peng:
                QueueController.S.物理箭PengQueue.Enqueue(序列纯显示一次);
                break;
            case PengType.紫鬼弹Peng:
                QueueController.S.紫鬼弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case PengType.黑暗花魔法弹Peng:
                QueueController.S.黑暗花魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case PengType.冰爆气魔法弹Peng:
                QueueController.S.冰爆气魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case PengType.电龙魔法弹Peng:
                QueueController.S.电龙魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case PengType.电爆气魔法弹Peng:
                QueueController.S.电爆气魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case PengType.冰大魔法弹Peng:
                QueueController.S.冰大魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case PengType.火虎魔法弹Peng:
                QueueController.S.火虎魔法弹PengQueue.Enqueue(序列纯显示一次);
                break;
            case PengType.黑暗魔法弹Peng:
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
