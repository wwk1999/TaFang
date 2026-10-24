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
   public Image 提速;
   public Image 增产;
   public Image 异化;
   public Image 延时;
   [NonSerialized] public int index;

   private void Start()
   {
      土地Image.onClick.AddListener(() =>
      {
         土地 当前土地 = PlayerData.S.灵植土地列表[index];
         if (当前土地.土地Type == 土地Type.未解锁)
         {
            ObserverModuleManager.S.SendEvent("SendUIToast", "土地未解锁");
            return;
         }

         var 当前选择灵植 = HeroWindowController.S.当前选择灵植;
         if (当前选择灵植 != 灵植Type.None)
         {
            if (当前土地.灵植Type != 灵植Type.None)
            {
               ObserverModuleManager.S.SendEvent("SendUIToast", "这块土地已经种有灵植");
               return;
            }

            if (PlayerData.S.种子Dic[当前选择灵植] <= 0)
            {
               ObserverModuleManager.S.SendEvent("SendUIToast", "种子数量不足");
               HeroWindowController.S.重置选择状态();
               return;
            }

            PlayerData.S.种子Dic[当前选择灵植] -= 1;
            当前土地.灵植Type = 当前选择灵植;
            当前土地.植物成长阶段Type = 植物成长阶段Type.播种;
            当前土地.当前time = 0;
            当前土地.所需time = 灵植园Config.灵植成熟时间Dic[当前选择灵植];
            当前土地.变异 = false;
            ObserverModuleManager.S.SendEvent("SendUIToast", "播种成功");
            GetComponentInParent<灵植园界面>().刷新土地();
            return;
         }

         var 当前选择肥料 = HeroWindowController.S.当前选择肥料;
         if (当前选择肥料 != 肥料Type.None)
         {
            if (当前土地.灵植Type == 灵植Type.None)
            {
               ObserverModuleManager.S.SendEvent("SendUIToast", "这块土地还没有种植灵植");
               return;
            }

            bool 已施肥 = false;
            switch (当前选择肥料)
            {
               case 肥料Type.提速: 已施肥 = 当前土地.提速肥料 != QualityType.None; break;
               case 肥料Type.增产: 已施肥 = 当前土地.增产肥料 != QualityType.None; break;
               case 肥料Type.异化: 已施肥 = 当前土地.异化肥料 != QualityType.None; break;
               case 肥料Type.延时: 已施肥 = 当前土地.延时肥料 != QualityType.None; break;
            }

            if (已施肥)
            {
               ObserverModuleManager.S.SendEvent("SendUIToast", "这块土地已经施过" + 灵植园Config.肥料名[当前选择肥料] + "了");
               return;
            }

            var 品质 = HeroWindowController.S.当前选择肥料品质;
            if (PlayerData.S.Get肥料数量(当前选择肥料, 品质) <= 0)
            {
               ObserverModuleManager.S.SendEvent("SendUIToast", "肥料数量不足");
               HeroWindowController.S.重置选择状态();
               return;
            }

            PlayerData.S.Set肥料数量(当前选择肥料, 品质, PlayerData.S.Get肥料数量(当前选择肥料, 品质) - 1);
            switch (当前选择肥料)
            {
               case 肥料Type.提速: 当前土地.提速肥料 = 品质; break;
               case 肥料Type.增产: 当前土地.增产肥料 = 品质; break;
               case 肥料Type.异化: 当前土地.异化肥料 = 品质; break;
               case 肥料Type.延时: 当前土地.延时肥料 = 品质; break;
            }

            ObserverModuleManager.S.SendEvent("SendUIToast", "施肥成功");
            GetComponentInParent<灵植园界面>().刷新土地();
            return;
         }

         ObserverModuleManager.S.SendEvent("SendUIToast", "请先选择种子或肥料");
      });
   }

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
         提速.gameObject.SetActive(土地.提速肥料!=QualityType.None);
         增产.gameObject.SetActive(土地.增产肥料!=QualityType.None);
         异化.gameObject.SetActive(土地.异化肥料!=QualityType.None);
         延时.gameObject.SetActive(土地.延时肥料!=QualityType.None);

         提速.sprite = ResourcesConfig.Get肥料Icon(肥料Type.提速, 土地.提速肥料);
         延时.sprite = ResourcesConfig.Get肥料Icon(肥料Type.延时, 土地.延时肥料);
         增产.sprite = ResourcesConfig.Get肥料Icon(肥料Type.增产, 土地.增产肥料);
         异化.sprite = ResourcesConfig.Get肥料Icon(肥料Type.异化, 土地.异化肥料);

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
