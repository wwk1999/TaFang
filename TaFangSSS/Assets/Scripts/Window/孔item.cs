using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 孔item : MonoBehaviour
{
   [NonSerialized] public 仙石 仙石=null;
   public Image icon;
   public GameObject 白背景框;
   public GameObject 绿背景框;
   public GameObject 蓝背景框;
   public GameObject 紫背景框;
   public GameObject 橙背景框;
   public GameObject 粉背景框;
   public GameObject 红背景框;
   public GameObject 彩背景框;

   public void SetItem()
   {
      if (仙石.type == 仙石Type.None)
      {
         白背景框.gameObject.SetActive(true);
         绿背景框.gameObject.SetActive(false);
         蓝背景框.gameObject.SetActive(false);
         紫背景框.gameObject.SetActive(false);
         橙背景框.gameObject.SetActive(false);
         粉背景框.gameObject.SetActive(false);
         红背景框.gameObject.SetActive(false);
         彩背景框.gameObject.SetActive(false);
         icon.gameObject.SetActive(false);
      }
      else
      {
         icon.gameObject.SetActive(true);
         白背景框.gameObject.SetActive(仙石.quality==QualityType.黄品);
         绿背景框.gameObject.SetActive(仙石.quality==QualityType.玄品);
         蓝背景框.gameObject.SetActive(仙石.quality==QualityType.地品);
         紫背景框.gameObject.SetActive(仙石.quality==QualityType.天品);
         橙背景框.gameObject.SetActive(仙石.quality==QualityType.宇品);
         粉背景框.gameObject.SetActive(仙石.quality==QualityType.宙品);
         红背景框.gameObject.SetActive(仙石.quality==QualityType.洪品);
         彩背景框.gameObject.SetActive(仙石.quality==QualityType.荒品);
         icon.sprite = ResourcesConfig.Get仙石Sprite(仙石.type, 仙石.阶数);
      }
   }
}
