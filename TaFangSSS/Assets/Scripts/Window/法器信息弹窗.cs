using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class 法器信息弹窗 : MonoBehaviour
{
   [NonSerialized] public 法器 法器;
   public GameObject content;

   public void SetItem()
   {
      foreach (Transform child in content.transform)
      {
         Destroy(child.gameObject);
      }

      var info = Instantiate(Resources.Load("Prefabs/Window/法器infoItem"), content.transform).GetComponent<法器infoItem>();
      info.法器Type = 法器.法器Type;
      info.SetItem();

      foreach (var item in 法器.list)
      {
         var 附加属性item=Instantiate(Resources.Load("Prefabs/Window/法器附加属性item"),content.transform).GetComponent<法器附加属性item>();
         附加属性item.法器附加属性Type = item.法器附加属性Type;
         附加属性item.count=item.count;
         附加属性item.SetItem();
      }
      
      var 法器孔item = Instantiate(Resources.Load("Prefabs/Window/法器孔item"), content.transform).GetComponent<法器孔item>();
      法器孔item.list = 法器.仙石list;
      法器孔item.SetItem();
   }
}
