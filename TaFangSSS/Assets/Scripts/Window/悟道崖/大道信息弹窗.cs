using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class 大道信息弹窗 : MonoBehaviour
{
    public GameObject content;
    [NonSerialized] public 大道Type Type;

    public void SetItem()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        var 大道infoitem = Instantiate(Resources.Load("Prefabs/Window/悟道崖/大道infoItem"), content.transform)
            .GetComponent<大道infoItem>();
        大道infoitem.大道Type = Type;
        大道infoitem.SetItem();
        var list = 悟道崖Config.大道限制列表[Type];
        if (list == null || list.Count == 0)
        {
            var 前置大道 = Instantiate(Resources.Load("Prefabs/Window/悟道崖/前置大道item"), content.transform)
                .GetComponent<前置大道item>();
            前置大道.大道Type = 大道Type.None;
            前置大道.SetItem();
        }
        else
        {
            foreach (var item in list)
            {
                var 前置大道 = Instantiate(Resources.Load("Prefabs/Window/悟道崖/前置大道item"), content.transform)
                    .GetComponent<前置大道item>();
                前置大道.大道Type = item;
                前置大道.SetItem();
            }
        }

        var 大道等级加成 = Instantiate(Resources.Load("Prefabs/Window/悟道崖/大道等级加成"), content.transform).GetComponent<大道等级加成>();
        大道等级加成.type = Type;
        大道等级加成.SetItem();
    }
}
