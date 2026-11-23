using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class 法器符文信息 : MonoBehaviour
{
   public GameObject content;
   [NonSerialized] public 法器 法器;

   public void SetItem()
   {
      foreach (Transform child in content.transform)
      {
         Destroy(child.gameObject);
      }

      Instantiate(Resources.Load("Prefabs/Window/符文标题"), content.transform);
      var item=Instantiate(Resources.Load("Prefabs/Window/法器信息符文item"), content.transform).GetComponent<法器信息符文item>();
      item.count = 法器.符文.count;
      item.符文Type = 法器.符文.type;
      item.QualityType=法器.符文.quality;
      item.无暇 = 法器.符文.无暇;
      item.SetItem();
      
      if (法器.符文.融合)
      {
         var item1=Instantiate(Resources.Load("Prefabs/Window/法器信息符文item"), content.transform).GetComponent<法器信息符文item>();
         item1.count = 法器.符文.融合count;
         item1.符文Type = 法器.符文.融合type;
         item1.QualityType=法器.符文.融合quality;
         item1.无暇 = 法器.符文.融合无暇;
         item1.SetItem();
      }
   }
}
