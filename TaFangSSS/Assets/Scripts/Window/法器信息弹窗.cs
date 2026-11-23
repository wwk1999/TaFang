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
      info.品质 = 法器.品质;
      info.阶数 = 法器.阶数;
      info.SetItem();
      
      Instantiate(Resources.Load("Prefabs/Window/词条属性"), content.transform);

      foreach (var item in 法器.list)
      {
         var 附加属性item=Instantiate(Resources.Load("Prefabs/Window/法器附加属性item"),content.transform).GetComponent<法器附加属性item>();
         附加属性item.法器附加属性Type = item.法器附加属性Type;
         附加属性item.count=item.count;
         附加属性item.无暇=item.无暇;
         附加属性item.QualityType=法器.品质;
         附加属性item.SetItem();
      }

      if (法器.符文 != null&&法器.符文.type!=符文Type.None)
      {
         var item=Instantiate(Resources.Load("Prefabs/Window/法器符文信息"), content.transform).GetComponent<法器符文信息>();
         item.法器 = 法器;
         item.SetItem();
      }
      
      var 魂器 = Instantiate(Resources.Load("Prefabs/Window/法器魂器"), content.transform).GetComponent<法器魂器>();
      魂器.法器 = 法器;
      魂器.SetItem();
      
      var 法器仙石 = Instantiate(Resources.Load("Prefabs/Window/法器信息仙石"), content.transform).GetComponent<法器信息仙石>();
      法器仙石.法器 = 法器;
      法器仙石.SetItem();
      
      //var tip = Instantiate(Resources.Load("Prefabs/Window/tip"), content.transform);
   }
}
