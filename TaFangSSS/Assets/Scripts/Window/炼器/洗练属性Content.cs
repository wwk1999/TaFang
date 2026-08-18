using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class 洗练属性Content : MonoBehaviour
{
    [NonSerialized] public List<法器附加属性值> list;
    public GameObject content;

    public void SetItem()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in list)
        {
            var 词条item = Instantiate(Resources.Load("Prefabs/Window/炼器/法器洗练词条Item"), content.transform)
                .GetComponent<法器洗练词条Item>();
            词条item.法器附加属性值 = item;
            词条item.SetItem();
        }
    }
}
