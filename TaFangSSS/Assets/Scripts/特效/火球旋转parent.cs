using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 火球旋转parent : MonoBehaviour
{
    [NonSerialized] public float RotateSpeed = 6;
    public List<火球> 火球list;
    [NonSerialized] public bool 瑶池冰辅助;
    [NonSerialized] public bool 黑暗辅助;
    [NonSerialized] public bool 女娲电辅助;
    [NonSerialized] public bool 瑶池神通;
    [NonSerialized] public bool 妲己神通;

    [NonSerialized] public float damage = 属性config.总属性.总攻击力*英雄星级属性.元始攻击数值/100f;

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        CancelInvoke();
        transform.localScale = new Vector3(英雄星级属性.元始体积, 英雄星级属性.元始体积, 1);
        foreach (var item in 火球list)
        {
            item.黑暗辅助 = 黑暗辅助;
            item.瑶池冰辅助 = 瑶池冰辅助;
            item.女娲电辅助 = 女娲电辅助;
            item.瑶池神通 = 瑶池神通;
            item.妲己神通 = 妲己神通;
            item.damage=damage;
        }
        Invoke(nameof(Hide), 英雄星级属性.元始持续时间);
    }

    private void Update()
    {
        transform.Rotate(0, 0, RotateSpeed * Time.deltaTime*英雄星级属性.元始转速);
    }
}
