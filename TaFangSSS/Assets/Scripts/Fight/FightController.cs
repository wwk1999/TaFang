using System;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;

public class FightController : XSingleton<FightController>
{
    [NonSerialized] public Queue<伤害数字> 伤害数字Queue = new Queue<伤害数字>();
    [NonSerialized] public Queue<Spine纯显示一次> 普通怪死亡Queue = new Queue<Spine纯显示一次>();
    [NonSerialized] public Queue<Spine纯显示一次> 精英怪死亡Queue = new Queue<Spine纯显示一次>();
    [NonSerialized] public Queue<Spine纯显示一次> 首领怪死亡Queue = new Queue<Spine纯显示一次>();
    [NonSerialized] public Queue<普通怪> 普通怪Queue = new Queue<普通怪>();
    [NonSerialized] public Queue<精英怪> 精英怪Queue = new Queue<精英怪>();
    [NonSerialized] public Queue<首领怪> 首领怪Queue = new Queue<首领怪>();
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
    public void InitQueue()
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
