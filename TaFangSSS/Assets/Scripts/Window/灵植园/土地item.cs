using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 土地item : MonoBehaviour
{
   public Button 土地Image;
   public GameObject 植物;
   public Image 幼苗;
   public Image 成熟;
   public Image 变异;
   public GameObject 进度条;
   public Image 品质bg;
   public TextMeshProUGUI 品质;
   public Image 进度条imamg;
   public TextMeshProUGUI 进度Count;
   public Image 成熟icon;
   public GameObject 肥料List;

   [NonSerialized] public int index;
   public void SetItem()
   {
      土地Image.image.alphaHitTestMinimumThreshold = 0.3f;
      土地 土地 = PlayerData.S.灵植土地列表[index];
      if (土地.土地Type == 土地Type.未解锁)
      {
         土地Image.image.sprite = ResourcesConfig.土地禁用;
         植物.gameObject.SetActive(false);
         进度条.gameObject.SetActive(false);
         肥料List.SetActive(false);
      }
      else
      {
         成熟icon.gameObject.SetActive(土地.植物成长阶段Type==植物成长阶段Type.成熟);
         进度条imamg.fillAmount = 土地.当前time / 土地.所需time;
         进度Count.text = (土地.当前time / 土地.所需time * 100f).ToString("F1");
         肥料List.SetActive(true);
         土地Image.image.sprite = ResourcesConfig.Get土地Sprite(土地.土地Type);
         if (土地.灵植Type == 灵植Type.None)
         {
            植物.gameObject.SetActive(false);
            进度条.gameObject.SetActive(false);
         }
         else
         {
            品质.colorGradientPreset = ResourcesConfig.Get品质TMP(灵植园Config.灵植品质Dic[土地.灵植Type]);
            品质bg.sprite = ResourcesConfig.Get作物品质背景框(灵植园Config.灵植品质Dic[土地.灵植Type]);
            植物.gameObject.SetActive(true);
            进度条.gameObject.SetActive(true);
            switch (灵植园Config.灵植品质Dic[土地.灵植Type])
            {
               case QualityType.黄品:
                  品质.text = "黄";
                  break;
               case QualityType.玄品:
                  品质.text = "玄";
                  break;
               case QualityType.地品:
                  品质.text = "地";
                  break;
               case QualityType.天品:
                  品质.text = "天";
                  break;
               case QualityType.宇品:
                  品质.text = "宇";
                  break;
               case QualityType.宙品:
                  品质.text = "宙";
                  break;
               case QualityType.洪品:
                  品质.text = "洪";
                  break;
               case QualityType.荒品:
                  品质.text = "荒";
                  break;
            }
            switch (土地.植物成长阶段Type)
            {
               case 植物成长阶段Type.播种:
                  幼苗.gameObject.SetActive(true);
                  成熟.gameObject.SetActive(false);
                  变异.gameObject.SetActive(false);
                  幼苗.sprite = ResourcesConfig.播种;
                  break;
               case 植物成长阶段Type.幼苗:
                  幼苗.gameObject.SetActive(true);
                  成熟.gameObject.SetActive(false);
                  变异.gameObject.SetActive(false);
                  幼苗.sprite = ResourcesConfig.Get灵植幼苗Sprite(土地.灵植Type);
                  break;
               case 植物成长阶段Type.成长:
                  幼苗.gameObject.SetActive(false);
                  成熟.gameObject.SetActive(true);
                  变异.gameObject.SetActive(false);
                  成熟.sprite = ResourcesConfig.Get灵植成长Sprite(土地.灵植Type);
                  break;
               case 植物成长阶段Type.成熟:
                  幼苗.gameObject.SetActive(false);
                  if (土地.变异)
                  {
                     成熟.gameObject.SetActive(false);
                     变异.gameObject.SetActive(true);
                     变异.sprite = ResourcesConfig.Get灵植变异Sprite(土地.灵植Type);
                  }
                  else
                  {
                     成熟.gameObject.SetActive(true);
                     变异.gameObject.SetActive(false);
                     成熟.sprite = ResourcesConfig.Get灵植成熟Sprite(土地.灵植Type);
                  }
                  
                  break;
            }
         }
      }
   }
}
