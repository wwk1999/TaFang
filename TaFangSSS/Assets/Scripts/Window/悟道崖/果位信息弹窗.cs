using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class 果位信息弹窗 : MonoBehaviour
{
    public GameObject content;
    [NonSerialized] public 大道Type 大道Type;
    public void SetItem()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }
        var 果位info=Instantiate(Resources.Load("Prefabs/Window/悟道崖/果位infoItem"),content.transform).GetComponent<果位infoItem>();
        果位info.大道Type = 大道Type;
        果位info.SetItem();
        foreach (var item in 悟道崖Config.大道配置[大道Type].大道效果列表)
        {
            var 果位效果=Instantiate(Resources.Load("Prefabs/Window/悟道崖/果位效果item"),content.transform).GetComponent<果位效果item>();
            果位效果.大道效果item = item;
            果位效果.SetItem();
        }
    }
}
