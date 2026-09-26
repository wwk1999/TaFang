using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;

public class 概率升级效果item : MonoBehaviour
{
   public GameObject content;
   [NonSerialized] public List<float> list = new List<float>();

   public void SetItem()
   {
      foreach (Transform child in content.transform)
      {
         Destroy(child.gameObject);
      }

      if (list.Count == 5)
      {
         int index =0;
         foreach (var item in list)
         {
            if (item > 0)
            {
               var 品质概率 = Instantiate(Resources.Load("Prefabs/Window/领主府/品质概率item"), content.transform)
                  .GetComponent<品质概率item>();
               品质概率.概率 = item;
               switch (index)
               {
                  case 0:
                     品质概率.品质 = "凡品";
                     break;
                  case 1:
                     品质概率.品质 = "灵品";
                     break;
                  case 2:
                     品质概率.品质 = "仙品";
                     break;
                  case 3:
                     品质概率.品质 = "圣品";
                     break;
                  case 4:
                     品质概率.品质 = "道品";
                     break;
               }
               品质概率.SetItem();
            } 
            index++;
         }
      }else if (list.Count == 8)
      {
         int index =0;
         foreach (var item in list)
         {
            if (item > 0)
            {
               var 品质概率 = Instantiate(Resources.Load("Prefabs/Window/领主府/品质概率item"), content.transform)
                  .GetComponent<品质概率item>();
               品质概率.概率 = item;
               品质概率.品质 = PropConfig.QualityNameDic[(QualityType)(index + 1)];
               品质概率.SetItem();
            }
            index++;
         }
      }
   }
}
