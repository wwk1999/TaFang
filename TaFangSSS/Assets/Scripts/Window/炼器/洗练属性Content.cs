using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class 洗练属性Content : MonoBehaviour
{
    [NonSerialized] public List<法器附加属性值> list;
    [NonSerialized] public 仙石Type 仙石Type = 仙石Type.None;
    public GameObject content;

    public void SetItem()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        if (list == null) return;

        if (仙石Type != 仙石Type.None)
        {
            var 词条item = Instantiate(Resources.Load("Prefabs/Window/炼器/法器洗练词条Item"), content.transform)
                .GetComponent<法器洗练词条Item>();
            词条item.仙石Type = 仙石Type;
            词条item.SetItem();
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
