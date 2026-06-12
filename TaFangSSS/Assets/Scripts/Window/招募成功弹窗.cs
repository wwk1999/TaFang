using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 招募成功弹窗 : MonoBehaviour
{
    [NonSerialized]public bool Is10 = false;
    [NonSerialized]public PropType Item1Type;
    [NonSerialized]public HashSet<PropType>list = new HashSet<PropType>();
    public GameObject Content;
    public 招募成功item item;

    private void OnEnable()
    {
        if (!Is10)
        {
            Content.SetActive(false);
            item.propType=Item1Type;
            item.SetItem();
            item.gameObject.SetActive(true);
        }
    }
}
