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
    //伤害面板
    [NonSerialized]public Dictionary<HeroType,float>当前英雄伤害Dic = new Dictionary<HeroType, float>();
    [NonSerialized]public float 伤害面板刷新间隔 = 0.5f;
    [NonSerialized]public float 当前伤害面板刷新时间 = 0f;


    //法则
    [NonSerialized]public int 孙悟空每秒增加伤害Time = 0;
    [NonSerialized]public int 通天暴击次数 = 0;
    [NonSerialized]public int 元始数量 = 英雄星级属性.元始攻击数量;
    [NonSerialized]public int 鸿钧陨石次数 = 0;
    [NonSerialized]public int 盘古击杀次数 = 0;

    
    
    [NonSerialized]public float 免疫护盾间隔时间 = 0;
    [NonSerialized]public int 免疫护盾次数 = (int)属性config.总属性.城墙免疫伤害;
    [NonSerialized]public float 每段时间护盾间隔时间 = 0;
    [NonSerialized]public float 城墙护盾值 = 城墙Config.开局护盾值/100f*城墙Config.Get城墙最大生命值();
    [NonSerialized] public float 当前冰冻间隔 = 0;
    [NonSerialized] public int 涅槃次数 = 城墙Config.涅槃次数;
    [NonSerialized] public float 城墙无敌Time = 0;
    [NonSerialized] public float 每秒回血Time = 0;
    [NonSerialized] public float 无敌间隔Time = 0;
    [NonSerialized] public float 城墙当前生命值 =城墙Config.Get城墙最大生命值();
    [NonSerialized] public HashSet<MonsterBase>当前怪物Set = new HashSet<MonsterBase>();
    [NonSerialized] public float CreateMonsterTime = 1f;
    [NonSerialized] public float 当前创建普通怪物时间 = 0;
    [NonSerialized] public float 总杀怪增伤 = 0;

    private int NormalMonsterCount = 0;
    public int EliteMonsterCount = 0;
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

    public void 刷新伤害面板()
    {
        List<伤害item> value = new List<伤害item>();
        float 总伤害 = 0;
        foreach (var item in 当前英雄伤害Dic)
        {
            总伤害+=item.Value;
        }

        if (总伤害 != 0)
        {
            foreach (var item in 当前英雄伤害Dic)
            {
                float 比例 = item.Value / 总伤害;
                value.Add(new 伤害item(){heroType = item.Key,damage = item.Value,比例 = 比例});
            }
        }
        else
        {
            foreach (var item in 当前英雄伤害Dic)
            {
                value.Add(new 伤害item(){heroType = item.Key,damage = 0,比例 = 0});
            }
        }
        
        ObserverModuleManager.S.SendEvent("刷新伤害面板",value);
    }

    public float Get护盾Left()
    {
        float 血量value = 城墙当前生命值 / 城墙Config.Get城墙最大生命值();
        float 护盾比例=城墙护盾值/城墙Config.Get城墙最大生命值();
        if (护盾比例 >= 1)
        {
            return 0;
        }
        else if(血量value+护盾比例<=1)
        {
            return 144.6f * 血量value;
        }
        else
        {
            return 144.6f *(1f-护盾比例);
        }
    }
    
    public float Get护盾Right()
    {
        float 血量value = 城墙当前生命值 / 城墙Config.Get城墙最大生命值();
        float 护盾比例=城墙护盾值/城墙Config.Get城墙最大生命值();
        if (护盾比例 >= 1)
        {
            return 0;
        }
        else if(血量value+护盾比例<=1)
        {
            return 144.6f * (1-血量value-护盾比例);
        }
        else
        {
            return 0;
        }
    }

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

    public IEnumerator 后羿连射(HeroType hero,Vector2 shotpos,Vector2 dir,float damage,float 瑶池冰辅助,float 黑暗辅助,bool 女娲电辅助)
    {
        float 概率 = 英雄星级属性.后羿连射概率;
        float random = Random.Range(0, 100);
        if (random > 概率)
        {
            后羿基础射击(hero,shotpos,dir,damage,瑶池冰辅助,黑暗辅助,女娲电辅助);
        }
        else
        {
            后羿基础射击(hero,shotpos,dir,damage,瑶池冰辅助,黑暗辅助,女娲电辅助);
            yield return new WaitForSeconds(0.1f);
            后羿基础射击(hero,shotpos,dir,damage,瑶池冰辅助,黑暗辅助,女娲电辅助);
        }
    }

    public void 后羿基础射击(HeroType hero,Vector2 shotpos,Vector2 dir,float damage,float 瑶池冰辅助,float 黑暗辅助,bool 女娲电辅助)
    {
        if (英雄星级属性.后羿攻击数量 == 2)
        {
            Shot普通魔法弹(攻击特效Type.物理箭,shotpos,GetDirectionOffset(dir,3,true),damage,10,瑶池冰辅助,黑暗辅助,true,女娲电辅助,HeroType.后羿);
            Shot普通魔法弹(攻击特效Type.物理箭,shotpos,GetDirectionOffset(dir,3,false),damage,10,瑶池冰辅助,黑暗辅助,true,女娲电辅助,HeroType.后羿);
        }

        if (英雄星级属性.后羿攻击数量 == 3)
        {
            Shot普通魔法弹(攻击特效Type.物理箭, shotpos, GetDirectionOffset(dir, 3, true), damage, 10,瑶池冰辅助,黑暗辅助,true,女娲电辅助,HeroType.后羿);
            Shot普通魔法弹(攻击特效Type.物理箭, shotpos, GetDirectionOffset(dir, 3, false), damage, 10,瑶池冰辅助,黑暗辅助,true,女娲电辅助,HeroType.后羿);
            Shot普通魔法弹(攻击特效Type.物理箭, shotpos, dir, damage, 10,瑶池冰辅助,黑暗辅助,true,女娲电辅助,HeroType.后羿);
        }
                
        if (英雄星级属性.后羿攻击数量 == 4)
        {
            Shot普通魔法弹(攻击特效Type.物理箭,shotpos,GetDirectionOffset(dir,4,true),damage,10,瑶池冰辅助,黑暗辅助,true,女娲电辅助,HeroType.后羿);
            Shot普通魔法弹(攻击特效Type.物理箭,shotpos,GetDirectionOffset(dir,4,false),damage,10,瑶池冰辅助,黑暗辅助,true,女娲电辅助,HeroType.后羿);
            Shot普通魔法弹(攻击特效Type.物理箭,shotpos,GetDirectionOffset(dir,2,true),damage,10,瑶池冰辅助,黑暗辅助,true,女娲电辅助,HeroType.后羿);
            Shot普通魔法弹(攻击特效Type.物理箭,shotpos,GetDirectionOffset(dir,2,false),damage,10,瑶池冰辅助,黑暗辅助,true,女娲电辅助,HeroType.后羿);
        }
    }

    IEnumerator 碧霄再次释放(float 瑶池冰辅助,float 黑暗辅助,float 女娲电辅助)
    {
        while (true)
        {
            float random=Random.Range(0, 100);
            if (random < 属性config.总属性.碧霄冰龙再次释放概率 * 100)
            {
                yield return new WaitForSeconds(0.1f);
                MonsterBase monsterBase = GetAttackMonster();
                一次伤害技能(攻击特效Type.冰龙, monsterBase.transform.position,瑶池冰辅助>0,黑暗辅助>0,女娲电辅助>0);           
            }
            else
            {
                break;
            }
        }
    }

    public void 人物攻击(HeroType hero,Vector2 shotpos,Vector2 dir,Vector2 targetPos,float 瑶池冰辅助,float 黑暗辅助,float 女娲电辅助,int count=0)
    {
        float damage = 英雄星级属性.Get英雄攻击数值(hero)/100f * 属性config.领主攻击力;
        switch (hero)
        {
            case HeroType.丹童:
                Shot普通魔法弹(攻击特效Type.普通火魔法弹,shotpos,dir,damage,8,瑶池冰辅助,黑暗辅助,false,女娲电辅助>0,HeroType.丹童);
                break;
            case HeroType.土地:
                Shot普通魔法弹(攻击特效Type.黑暗魔法弹,shotpos,dir,damage,8,瑶池冰辅助,黑暗辅助,false,女娲电辅助>0,HeroType.土地);
                break;
            case HeroType.河伯:
                一次伤害技能(攻击特效Type.冰刺, targetPos,瑶池冰辅助>0,黑暗辅助>0,女娲电辅助>0);           
                break;
            case HeroType.瑶池仙女:
                瑶池冰辅助技能();
                break;
            case HeroType.石敢当:
                石敢当技能(dir,shotpos,瑶池冰辅助>0,黑暗辅助>0,女娲电辅助>0);
                break;
            case HeroType.玄女:
                一次伤害技能(攻击特效Type.玄女技能, targetPos,瑶池冰辅助>0,黑暗辅助>0,女娲电辅助>0);           
                break;
            case HeroType.龟丞相:
                一次伤害技能(攻击特效Type.龟丞相技能, targetPos,瑶池冰辅助>0,黑暗辅助>0,女娲电辅助>0);           
                break;
            case HeroType.太白金星:
                Shot普通魔法弹(攻击特效Type.电魔法弹,shotpos,dir,damage,8,瑶池冰辅助,黑暗辅助,false,女娲电辅助>0,HeroType.太白金星);
                break;
            case HeroType.多闻天王:
                Shot普通魔法弹(攻击特效Type.黑暗花魔法弹,shotpos,dir,damage,8,瑶池冰辅助,黑暗辅助,false,女娲电辅助>0,HeroType.多闻天王);
                break;
            case HeroType.雷震子:
                一次伤害技能(攻击特效Type.落雷, targetPos,瑶池冰辅助>0,黑暗辅助>0,女娲电辅助>0);           
                break;
            case HeroType.月老:
                Shot普通魔法弹(攻击特效Type.火虎魔法弹,shotpos,dir,damage,8,瑶池冰辅助,黑暗辅助,false,女娲电辅助>0,HeroType.月老);
                break;
            case HeroType.嫦娥:
                一次伤害技能(攻击特效Type.嫦娥技能, targetPos,瑶池冰辅助>0,黑暗辅助>0,女娲电辅助>0);           
                break;
            case HeroType.杨戬:
                if (英雄星级属性.杨戬攻击数量 == 1)
                {
                    Shot普通魔法弹(攻击特效Type.电龙魔法弹,shotpos,dir,damage,8,瑶池冰辅助,黑暗辅助,true,女娲电辅助>0,HeroType.杨戬);
                }

                if (英雄星级属性.杨戬攻击数量 == 2)
                {
                    Shot普通魔法弹(攻击特效Type.电龙魔法弹,shotpos,GetDirectionOffset(dir,3,false),damage,8,瑶池冰辅助,黑暗辅助,true,女娲电辅助>0,HeroType.杨戬);
                    Shot普通魔法弹(攻击特效Type.电龙魔法弹,shotpos,GetDirectionOffset(dir,3,true),damage,8,瑶池冰辅助,黑暗辅助,true,女娲电辅助>0,HeroType.杨戬);
                }
                break;
            case HeroType.妲己:
                妲己黑暗辅助技能();
                break;
            case HeroType.碧霄:
                一次伤害技能(攻击特效Type.冰龙, targetPos,瑶池冰辅助>0,黑暗辅助>0,女娲电辅助>0);
                StartCoroutine(碧霄再次释放(瑶池冰辅助, 黑暗辅助, 女娲电辅助));
                break;
            case HeroType.琼霄:
                一次伤害技能(攻击特效Type.黑暗符, targetPos,瑶池冰辅助>0,黑暗辅助>0,女娲电辅助>0);           
                break;
            case HeroType.后羿:
                StartCoroutine(后羿连射(hero, shotpos, dir, damage, 瑶池冰辅助, 黑暗辅助,女娲电辅助>0));
                break;
            case HeroType.常羲:
                一次伤害技能(攻击特效Type.冰符, targetPos,瑶池冰辅助>0,黑暗辅助>0,女娲电辅助>0);           
                break;
            case HeroType.羲和:
                一次伤害技能(攻击特效Type.火符, targetPos,瑶池冰辅助>0,黑暗辅助>0,女娲电辅助>0);           
                break;
            case HeroType.云霄:
                Shot普通魔法弹(攻击特效Type.冰剑气,shotpos,dir,damage,8,瑶池冰辅助,黑暗辅助,true,女娲电辅助>0,HeroType.云霄);
                break;
            case HeroType.女娲:
                女娲电辅助技能();
                break;
            case HeroType.老子:
                循环伤害技能(攻击特效Type.冰旋风,shotpos,dir,damage,HeroConfig.HeroZhiYeDic[hero].yuanSuType,1.5f,瑶池冰辅助,黑暗辅助,女娲电辅助>0);
                break;
            case HeroType.通天:
                if (英雄星级属性.通天攻击数量 == 2)
                {
                    Shot普通魔法弹(攻击特效Type.黑暗剑气,shotpos,GetDirectionOffset(dir,3,true),damage,10,瑶池冰辅助,黑暗辅助,true,女娲电辅助>0,HeroType.通天);
                    Shot普通魔法弹(攻击特效Type.黑暗剑气,shotpos,GetDirectionOffset(dir,3,false),damage,10,瑶池冰辅助,黑暗辅助,true,女娲电辅助>0,HeroType.通天);
                }

                if (英雄星级属性.通天攻击数量 == 3)
                {
                    Shot普通魔法弹(攻击特效Type.黑暗剑气, shotpos, GetDirectionOffset(dir, 3, true), damage,
                         10, 瑶池冰辅助, 黑暗辅助, true,女娲电辅助>0,HeroType.通天);
                    Shot普通魔法弹(攻击特效Type.黑暗剑气, shotpos, GetDirectionOffset(dir, 3, false), damage,
                         10, 瑶池冰辅助, 黑暗辅助, true,女娲电辅助>0,HeroType.通天);
                    Shot普通魔法弹(攻击特效Type.黑暗剑气, shotpos, dir, damage, 10, 瑶池冰辅助,
                        黑暗辅助, true,女娲电辅助>0,HeroType.通天);
                }
                
                if (英雄星级属性.通天攻击数量 == 4)
                {
                    Shot普通魔法弹(攻击特效Type.黑暗剑气,shotpos,GetDirectionOffset(dir,4,true),damage,10,瑶池冰辅助,黑暗辅助,true,女娲电辅助>0,HeroType.通天);
                    Shot普通魔法弹(攻击特效Type.黑暗剑气,shotpos,GetDirectionOffset(dir,4,false),damage,10,瑶池冰辅助,黑暗辅助,true,女娲电辅助>0,HeroType.通天);
                    Shot普通魔法弹(攻击特效Type.黑暗剑气,shotpos,GetDirectionOffset(dir,2,true),damage,10,瑶池冰辅助,黑暗辅助,true,女娲电辅助>0,HeroType.通天);
                    Shot普通魔法弹(攻击特效Type.黑暗剑气,shotpos,GetDirectionOffset(dir,2,false),damage,10,瑶池冰辅助,黑暗辅助,true,女娲电辅助>0,HeroType.通天);
                }
                break;
            case HeroType.鸿钧:
                int count1 =  英雄星级属性.鸿钧攻击数量;
                StartCoroutine(Spine一次伤害技能(攻击特效Type.陨石, targetPos,瑶池冰辅助>0,黑暗辅助>0,女娲电辅助>0,count1));           
                break;
        }
    }
    public Vector3 GetDirectionOffset(Vector3 dir, float angleDegrees, bool isUp)
    {
        // 计算旋转轴：垂直于 dir 和 world up 的方向 => 局部右向量
        Vector3 axis = Vector3.Cross(dir, Vector3.up);
    
        // 如果 dir 与世界 up 对齐，叉积为零，则回退到 world right
        if (axis.magnitude < 0.001f)
        {
            axis = Vector3.right; 
        }
        else
        {
            axis.Normalize();
        }

        float sign = isUp ? 1f : -1f;
        Quaternion rotation = Quaternion.AngleAxis(sign * angleDegrees, axis);
        return rotation * dir;
    }

    public void 石敢当技能(Vector2 dir,Vector2 shotpos,bool 瑶池冰辅助,bool 黑暗辅助,bool 女娲电辅助)
    {
        var item = QueueController.S.石敢当锤子Queue.Dequeue();
        item.dir = dir;
        item.speed = 10;
        item.transform.position = shotpos;
        item.瑶池冰辅助 = 瑶池冰辅助;
        item.黑暗辅助 = 黑暗辅助;
        item.女娲电辅助 = 女娲电辅助;
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

        randomValue.瑶池冰辅助 = 英雄星级属性.瑶池仙女持续时间;
    }
    public void 女娲电辅助技能()
    {
        foreach (var item in 人物items)
        {
            if (item.Key != HeroType.女娲)
            {
                item.Value.女娲电辅助 = 英雄星级属性.女娲持续时间;
            }
        }
    }
    public void 妲己黑暗辅助技能()
    {
        var random=Random.Range(0,人物items.Count);
        HeroType[] keysArray = 人物items.Keys.ToArray();
        HeroType randomKey = keysArray[random];
        人物item randomValue = 人物items[randomKey];
        while (randomValue.heroType==HeroType.妲己)
        {
            random=Random.Range(0,人物items.Count);
            randomKey = keysArray[random];
            randomValue = 人物items[randomKey];
        }

        randomValue.妲己黑暗辅助 = 英雄星级属性.妲己持续时间;
    }

    public IEnumerator Spine一次伤害技能(攻击特效Type 攻击特效Type, Vector2 pos, bool 瑶池冰辅助, bool 黑暗辅助,bool 女娲电辅助,int count=0)
    {
        float damage = 属性config.领主攻击力;
        switch (攻击特效Type)
        {
            case 攻击特效Type.陨石:
                while (count>0)
                {
                     count--;
                     鸿钧陨石次数++;
                     float randomx=Random.Range(-1.0f, 1.0f);
                     float randomy=Random.Range(-1.0f, 1.0f);
                     Vector2 randomdir=new Vector2(randomx,randomy).normalized;
                     Vector2 randompos=pos+randomdir*1.5f;
                     var 陨石 = QueueController.S.陨石Queue.Dequeue();
                     陨石.transform.position = randompos;
                     陨石.瑶池冰辅助 = 瑶池冰辅助;
                     陨石.黑暗辅助 = 黑暗辅助;
                     陨石.女娲电辅助 = 女娲电辅助;
                     陨石.damage = damage * 英雄星级属性.鸿钧攻击数值 / 100f;
                     陨石.HeroType = HeroType.鸿钧;
                     陨石.gameObject.SetActive(true);
                     yield return  new WaitForSeconds(0.1f/(count/5f));
                }
                break;
        }
    }


    public void 一次伤害技能(攻击特效Type 攻击特效Type, Vector2 pos,bool 瑶池冰辅助,bool 黑暗辅助,bool 女娲电辅助)
    {
        float damage = 属性config.领主攻击力;
        
        switch (攻击特效Type)
        {
            case 攻击特效Type.嫦娥技能:
                var 嫦娥技能 = QueueController.S.嫦娥技能Queue.Dequeue();
                嫦娥技能.transform.position = pos;
                嫦娥技能.脚本.瑶池冰辅助 = 瑶池冰辅助;
                嫦娥技能.脚本.黑暗辅助 = 黑暗辅助;
                嫦娥技能.脚本.女娲电辅助 = 女娲电辅助;
                嫦娥技能.脚本.damage = damage * 英雄星级属性.Get英雄攻击数值(HeroType.嫦娥)/100f;
                嫦娥技能.脚本.HeroType = HeroType.嫦娥;
                嫦娥技能.gameObject.SetActive(true);
                break;
            case 攻击特效Type.冰刺:
                var item = QueueController.S.冰刺Queue.Dequeue();
                item.transform.position = pos;
                item.脚本.瑶池冰辅助 = 瑶池冰辅助;
                item.脚本.黑暗辅助 = 黑暗辅助;
                item.脚本.女娲电辅助 = 女娲电辅助;
                item.脚本.damage = damage * 英雄星级属性.Get英雄攻击数值(HeroType.河伯)/100f;
                item.脚本.HeroType = HeroType.河伯;
                item.gameObject.SetActive(true);
                break;
            case 攻击特效Type.玄女技能:
                var 玄女技能 = QueueController.S.玄女技能Queue.Dequeue();
                玄女技能.transform.position = pos;
                玄女技能.脚本.瑶池冰辅助 = 瑶池冰辅助;
                玄女技能.脚本.黑暗辅助 = 黑暗辅助;
                玄女技能.脚本.女娲电辅助 = 女娲电辅助;
                玄女技能.脚本.damage = damage * 英雄星级属性.Get英雄攻击数值(HeroType.玄女)/100f;
                玄女技能.脚本.HeroType = HeroType.玄女;
                玄女技能.gameObject.SetActive(true);
                break;
            case 攻击特效Type.龟丞相技能:
                var 龟丞相技能 = QueueController.S.龟丞相技能Queue.Dequeue();
                龟丞相技能.transform.position = pos;
                龟丞相技能.脚本.瑶池冰辅助 = 瑶池冰辅助;
                龟丞相技能.脚本.黑暗辅助 = 黑暗辅助;
                龟丞相技能.脚本.女娲电辅助 = 女娲电辅助;
                龟丞相技能.脚本.damage = damage * 英雄星级属性.Get英雄攻击数值(HeroType.龟丞相)/100f;
                龟丞相技能.脚本.HeroType = HeroType.龟丞相;
                龟丞相技能.gameObject.SetActive(true);
                break;
            case 攻击特效Type.落雷:
                var 落雷 = QueueController.S.落雷Queue.Dequeue();
                落雷.transform.position = pos;
                落雷.脚本.瑶池冰辅助 = 瑶池冰辅助;
                落雷.脚本.黑暗辅助 = 黑暗辅助;
                落雷.脚本.女娲电辅助 = 女娲电辅助;
                落雷.脚本.damage = damage * 英雄星级属性.Get英雄攻击数值(HeroType.雷震子)/100f;
                落雷.脚本.HeroType = HeroType.雷震子;
                落雷.gameObject.SetActive(true);
                break;
            case 攻击特效Type.冰龙:
                var 冰龙 = QueueController.S.冰龙Queue.Dequeue();
                冰龙.transform.position = pos;
                冰龙.脚本.瑶池冰辅助 = 瑶池冰辅助;
                冰龙.脚本.黑暗辅助 = 黑暗辅助;
                冰龙.脚本.女娲电辅助 = 女娲电辅助;
                冰龙.脚本.damage = damage * 英雄星级属性.Get英雄攻击数值(HeroType.碧霄)/100f;
                冰龙.脚本.HeroType = HeroType.碧霄;
                冰龙.gameObject.SetActive(true);
                break;
            case 攻击特效Type.黑暗符:
                var 黑暗符 = QueueController.S.黑暗符Queue.Dequeue();
                黑暗符.transform.position = pos;
                黑暗符.脚本.瑶池冰辅助 = 瑶池冰辅助;
                黑暗符.脚本.黑暗辅助 = 黑暗辅助;
                黑暗符.脚本.女娲电辅助 = 女娲电辅助;
                黑暗符.脚本.damage = damage * 英雄星级属性.Get英雄攻击数值(HeroType.琼霄)/100f;
                黑暗符.脚本.HeroType = HeroType.琼霄;
                黑暗符.gameObject.SetActive(true);
                break;
            case 攻击特效Type.冰符:
                var 冰符 = QueueController.S.冰符Queue.Dequeue();
                冰符.transform.position = pos;
                冰符.脚本.瑶池冰辅助 = 瑶池冰辅助;
                冰符.脚本.黑暗辅助 = 黑暗辅助;
                冰符.脚本.女娲电辅助 = 女娲电辅助;
                冰符.脚本.HeroType = HeroType.常羲;
                冰符.脚本.damage = damage * 英雄星级属性.Get英雄攻击数值(HeroType.常羲)/100f;
                冰符.gameObject.SetActive(true);
                break;
            case 攻击特效Type.火符:
                var 火符 = QueueController.S.火符Queue.Dequeue();
                火符.transform.position = pos;
                火符.脚本.瑶池冰辅助 = 瑶池冰辅助;
                火符.脚本.黑暗辅助 = 黑暗辅助;
                火符.脚本.女娲电辅助 = 女娲电辅助;

                火符.脚本.damage = damage * 英雄星级属性.Get英雄攻击数值(HeroType.羲和)/100f;
                火符.脚本.HeroType = HeroType.羲和;
                火符.gameObject.SetActive(true);
                break;
        }
    }

    public void 循环伤害技能(攻击特效Type 攻击特效Type, Vector2 shotPos, Vector2 dir, float damage, YuanSuType yuanSuType,
        float speed, float 瑶池冰辅助, float 黑暗辅助,bool 女娲电辅助)
    {
        循环伤害技能 魔法弹 = null;
        switch (攻击特效Type) // 请将“攻击特效类型变量”替换为实际的变量名
        {
            case 攻击特效Type.冰旋风:
                魔法弹.HeroType=HeroType.老子;
                魔法弹 = QueueController.S.冰旋风Queue.Dequeue();
                break;
        }
       
        魔法弹.transform.position = shotPos;
        魔法弹.damage = damage;
        魔法弹.MoveDirection = dir;
        魔法弹.MoveSpeed = speed;
        魔法弹.HeroType = HeroType.老子;
        魔法弹.瑶池冰辅助 = 瑶池冰辅助>0;
        魔法弹.黑暗辅助 = 黑暗辅助>0;
        魔法弹.女娲电辅助 = 女娲电辅助;
        魔法弹.gameObject.SetActive(true);
    }


    public void Shot普通魔法弹(攻击特效Type 攻击特效Type,Vector2 shotPos, Vector2 dir, float damage, float speed,float 瑶池冰辅助,float 黑暗辅助,bool 穿透,bool 女娲电辅助,HeroType heroType)
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
            case 攻击特效Type.冰剑气:
                魔法弹 = QueueController.S.冰剑气Queue.Dequeue();
                break;
        }

       
        魔法弹.transform.position = shotPos;
        魔法弹.damage = damage;
        魔法弹.MoveDirection = dir;
        魔法弹.MoveSpeed = speed;
        魔法弹.HeroType = heroType;
        魔法弹.瑶池冰辅助 = 瑶池冰辅助>0;
        魔法弹.黑暗辅助 = 黑暗辅助>0;
        魔法弹.女娲电辅助 = 女娲电辅助;
        魔法弹.穿透 = 穿透;
        魔法弹.gameObject.SetActive(true);
    }
    public 序列纯显示一次 GetPeng(攻击特效Type type)
    {
        switch (type)
        {
            case 攻击特效Type.冰旋风:
            case 攻击特效Type.冰剑气:
                return QueueController.S.冰大魔法弹PengQueue.Count > 0 ? QueueController.S.冰大魔法弹PengQueue.Dequeue() : null;
            case 攻击特效Type.孙悟空棒子:
            case 攻击特效Type.火球:
                return QueueController.S.火虎魔法弹PengQueue.Count > 0 ? QueueController.S.火虎魔法弹PengQueue.Dequeue() : null;
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
        switch (type) {
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
                QueueController.S.普通火魔法弹Queue.Enqueue(普通魔法弹带peng);
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
        当前怪物Set.Add(monster);
        monster.transform.position = new Vector3(x,y,0);
        List<MonsterTypeName> list = LevelConfig.LevelMonsterDic[LevelConfig.当前主线关卡Type];
        int random=Random.Range(0,2);
        monster.MonsterTypeName = list[random];
        monster.gameObject.SetActive(true);
    }
    
    public void CreateEliteMonster()
    {
        if (LevelConfig.当前主线关卡Type <= 主线关卡Type.水帘洞)
        {
            return;
        }
        EliteMonsterCount++;
        float x = 10f;
        float y = Random.Range(-4f, 4f);
        var monster=QueueController.S.精英怪Queue.Dequeue();
        当前怪物Set.Add(monster);
        monster.transform.position = new Vector3(x,y,0);
        List<MonsterTypeName> list = LevelConfig.LevelMonsterDic[LevelConfig.当前主线关卡Type];
        monster.MonsterTypeName = list[2];
        monster.gameObject.SetActive(true);
    }
    
    public void CreateBossMonster()
    {
        if (LevelConfig.当前主线关卡Type <= 主线关卡Type.五行山)
        {
            return;
        }
        float x = 10f;
        float y = Random.Range(-4f, 4f);
        var monster=QueueController.S.首领怪Queue.Dequeue();
        当前怪物Set.Add(monster);
        monster.transform.position = new Vector3(x,y,0);
        List<MonsterTypeName> list = LevelConfig.LevelMonsterDic[LevelConfig.当前主线关卡Type];
        monster.MonsterTypeName = list[3];
        monster.gameObject.SetActive(true);
    }

    public void 冰冻所有怪物()
    {
        foreach (var item in 当前怪物Set)
        {
            item.冰冻time = 城墙Config.冰冻时间;
        }
    }
    private void Update()
    {
        当前伤害面板刷新时间+=Time.deltaTime;
        免疫护盾间隔时间 += Time.deltaTime;
        每段时间护盾间隔时间 += Time.deltaTime;
        无敌间隔Time+=Time.deltaTime;
        每秒回血Time+=Time.deltaTime;
        城墙无敌Time-=Time.deltaTime;
        当前创建普通怪物时间+=Time.deltaTime;
        当前冰冻间隔+=Time.deltaTime;
        if (当前伤害面板刷新时间 > 伤害面板刷新间隔)
        {
            当前伤害面板刷新时间 = 0;
            刷新伤害面板();
        }
        if (免疫护盾间隔时间 > 城墙Config.免疫护盾间隔时间)
        {
            免疫护盾间隔时间 = 0;
            免疫护盾次数++;
        }
        if (每秒回血Time > 1)
        {
            孙悟空每秒增加伤害Time++;
            每秒回血Time = 0;
            int 回血值 = (int)(城墙Config.每秒回血值/ 100f * 城墙Config.Get城墙最大生命值()) ;
            int value = (int)(城墙Config.Get城墙最大生命值() - 城墙当前生命值);
            if (value == 0)
            {
                return;
            }
            int 真实回血值 = 0;
            if (value > 回血值)
            {
                真实回血值 = 回血值;
            }
            else
            {
                真实回血值 = value;
            }
            Show伤害数字(真实回血值,YuanSuType.None,new Vector2(-5,0),true);
            城墙当前生命值 += 真实回血值;
            城墙当前生命值 = Math.Min(城墙Config.Get城墙最大生命值(), 城墙当前生命值);
            ObserverModuleManager.S.SendEvent("设置护盾");
        }
        if (每段时间护盾间隔时间 > 城墙Config.护盾间隔时间)
        {
            每段时间护盾间隔时间 = 0;
            城墙护盾值 += (int)(城墙Config.Get城墙最大生命值() * 城墙Config.每段时间护盾值 / 100f);
            ObserverModuleManager.S.SendEvent("设置护盾");
        }
        if (无敌间隔Time > 城墙Config.无敌间隔时间)
        {
            无敌间隔Time = 0;
            if (城墙无敌Time > 0)
            {
                城墙无敌Time += 城墙Config.无敌时间;
            }
            else
            {
                城墙无敌Time = 城墙Config.无敌时间;
            }
        }
        if (当前冰冻间隔 >= 城墙Config.冰冻间隔)
        {
            当前冰冻间隔 = 0;
            冰冻所有怪物();
        }
        var 普通怪物Time = LevelConfig.LevelInfos[LevelConfig.当前主线关卡Type].CreateNormalMonsterTime;
        var 普通怪物最大数量=LevelConfig.LevelInfos[LevelConfig.当前主线关卡Type].NormalMonsterCount;
        var 精英怪物最大数量=LevelConfig.LevelInfos[LevelConfig.当前主线关卡Type].EliteMonsterCount;
        if (当前创建普通怪物时间 >= 普通怪物Time&&NormalMonsterCount<普通怪物最大数量)
        {
            NormalMonsterCount++;
            CreateNormalMonster();
            当前创建普通怪物时间 = 0;
        }
    }

    public void Show伤害数字(float 最终伤害, YuanSuType yuanSuType,Vector2 pos,bool is回血=false)
    {
        var item=QueueController.S.伤害数字Queue.Dequeue();
        item.damage = (int)最终伤害;
        item.is回血 = is回血;
        item.YuanSuType = yuanSuType;
        item.transform.position = pos;
        item.gameObject.SetActive(true);
    }
    
    private static readonly (double value, string symbol)[] Units = new (double, string)[]
    {
        (1e28, "穰"),  // 10^28
        (1e24, "秭"),  // 10^24
        (1e20, "垓"),  // 10^20
        (1e16, "京"),  // 10^16
        (1e12, "兆"),  // 10^12
        (1e8,  "亿"),  // 10^8
        (1e4,  "万")   // 10^4
    };
    
    
    public string 格式化数字(double num)
    {
        // 处理负数
        if (num < 0)
        {
            return "-" + 格式化数字(Math.Abs(num));
        }

        // 小于1万直接显示整数
        if (num < 10000)
        {
            return Math.Floor(num).ToString();
        }

        // 从大到小遍历单位
        foreach (var unit in Units)
        {
            // 达到当前单位的1000倍才转换（即 1000万、1000亿、1000兆...）
            if (num >= unit.value * 1000)
            {
                double value = num / unit.value;
                double rounded = Math.Round(value, 1, MidpointRounding.AwayFromZero);

                // 如果四舍五入后达到10000，进位到下一个单位
                if (rounded >= 10000)
                {
                    continue;
                }

                // 如果结果是整数，去掉 .0
                if (Math.Abs(rounded - Math.Round(rounded)) < 0.01)
                {
                    return Math.Round(rounded).ToString() + unit.symbol;
                }

                return rounded.ToString("F1") + unit.symbol;
            }
        }

        // 超大数值降级为科学计数法
        return num.ToString("E1");
    }
}
