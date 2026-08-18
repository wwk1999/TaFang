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

      for (int i = 1; i < Enum.GetValues(typeof(仙石Type)).Length; i++)
      {
         int 数量 = 仙石Config.Get法器仙石数量(法器, (仙石Type)i);
         if (数量 >= 4)
         {
            var item=Instantiate(Resources.Load("Prefabs/Window/仙石羁绊item"), content.transform).GetComponent<仙石羁绊item>();
            item.仙石Type = (仙石Type)i;
            item.数量 = 4;
            item.SetItem();
         }
         if (数量 >= 6)
         {
            var item=Instantiate(Resources.Load("Prefabs/Window/仙石羁绊item"), content.transform).GetComponent<仙石羁绊item>();
            item.仙石Type = (仙石Type)i;
            item.数量 = 6;
            item.SetItem();
         }
         if (数量 >= 8)
         {
            var item=Instantiate(Resources.Load("Prefabs/Window/仙石羁绊item"), content.transform).GetComponent<仙石羁绊item>();
            item.仙石Type = (仙石Type)i;
            item.数量 = 8;
            item.SetItem();
         }
      }
      
      var 法器孔item = Instantiate(Resources.Load("Prefabs/Window/法器孔item"), content.transform).GetComponent<法器孔item>();
      法器孔item.list = 法器.仙石list;
      法器孔item.SetItem();
   }
}
