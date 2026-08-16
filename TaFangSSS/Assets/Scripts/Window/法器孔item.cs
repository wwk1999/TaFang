using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;

public class 法器孔item : MonoBehaviour
{
    [NonSerialized]public List<仙石>list=null;
    public GameObject content;
    public void SetItem()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in list)
        {
            var 孔item = Instantiate(Resources.Load("Prefabs/Window/孔item"), content.transform).GetComponent<孔item>();
            孔item.仙石 = item;
            孔item.SetItem();
        }
    }
}
