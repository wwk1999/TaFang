using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;

public class 仙石信息弹窗 : MonoBehaviour
{
    [NonSerialized] public 仙石 仙石;
    public GameObject content;

    public void SetItem()
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        var info = Instantiate(Resources.Load("Prefabs/Window/仙石infoItem"), content.transform).GetComponent<仙石infoItem>();
        info.仙石Type = 仙石.type;
        info.QualityType = 仙石.quality;
        info.SetItem();

        foreach (var item in 仙石.list)
        {
            var 附加属性item=Instantiate(Resources.Load("Prefabs/Window/法器附加属性item"),content.transform).GetComponent<法器附加属性item>();
            附加属性item.法器附加属性Type = item.法器附加属性Type;
            附加属性item.count=item.count;
            附加属性item.SetItem();
        }
    }
}
