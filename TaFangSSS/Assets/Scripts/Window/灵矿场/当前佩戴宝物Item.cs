using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 当前佩戴宝物Item : MonoBehaviour
{
   public TextMeshProUGUI 等级;
   public GameObject nameobj;
   public TextMeshProUGUI name;
   public Button bg;
   public Image icon;
   public GameObject 锁;
   public Button 强化button;
   public TextMeshProUGUI 强化count;

   [NonSerialized] public int index;

   public void SetItem()
   {
      if (index > 灵矿场Config.宝物佩戴上限配置[PlayerData.S.矿洞宝物佩戴上限].个数)
      {
         锁.gameObject.SetActive(true);
         强化button.gameObject.SetActive(false);
         nameobj.gameObject.SetActive(false);
         icon.gameObject.SetActive(false);
         等级.gameObject.SetActive(false);
         bg.image.sprite = ResourcesConfig.灵植背包格子空;
      }
      else
      {
         强化count.text = 灵矿场Config.Get宝物格子升级碎片(PlayerData.S.宝物佩戴格子等级[index]).ToString();
         锁.gameObject.SetActive(false);
         强化button.gameObject.SetActive(true);
         等级.gameObject.SetActive(true);
         if (PlayerData.S.当前宝物[index] == null)
         {
            nameobj.gameObject.SetActive(false);
            icon.gameObject.SetActive(false);
            bg.image.sprite = ResourcesConfig.灵植背包格子空;
         }
         else
         {
            nameobj.gameObject.SetActive(true);
            icon.gameObject.SetActive(true);
            宝物Type 宝物Type = PlayerData.S.当前宝物[index].宝物Type;
            QualityType qualityType = PlayerData.S.当前宝物[index].QualityType;
            name.text = 灵矿场Config.宝物名[宝物Type];
            bg.image.sprite=ResourcesConfig.Get灵植背包格子(qualityType);
            icon.sprite = ResourcesConfig.Get宝物Sprite(宝物Type);
         }
      }
   }

   private void Start()
   {
      强化button.onClick.AddListener(() =>
      {
         float value = 灵矿场Config.Get宝物格子升级碎片(PlayerData.S.宝物佩戴格子等级[index]);
         if (PlayerData.S.宝物碎片 < value)
         {
            ObserverModuleManager.S.SendEvent("SendUIToast","宝物碎片不足");
            return;
         }

         PlayerData.S.宝物碎片 -= value;
         PlayerData.S.宝物佩戴格子等级[index]++;
         ObserverModuleManager.S.SendEvent("SendUIToast","升级成功");
         SetItem();
      });
   }
}
