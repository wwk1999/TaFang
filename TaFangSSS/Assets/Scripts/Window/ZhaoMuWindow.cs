using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ZhaoMuWindow : MonoBehaviour
{
   public Button 概率按钮;
   public GameObject 概率弹窗;
   public Button 普通招募按钮;
   public Button 高级招募按钮;
   public Button 退出按钮;
   public Toggle Toggle;
   [NonSerialized] public bool Is10=false;
   public TextMeshProUGUI NormalCount;
   public TextMeshProUGUI GaoJiCount;
   public 招募成功弹窗 招募成功弹窗;
   public GameObject 商店Content;
   public 招募商店兑换弹窗 招募商店兑换窗口;

   public void ResetCount()
   {
      if (Is10)
      {
         NormalCount.text = "10";
         GaoJiCount.text = "10";
      }
      else
      {
         NormalCount.text = "1";
         GaoJiCount.text = "1";
      }
   }

   public void ShowShangDian()
   {
      foreach (Transform item in 商店Content.transform)
      {
         Destroy(item.gameObject);
      }

      foreach (var item in HeroConfig.HeroQualityDic)
      {
         if (item.Key == HeroType.None)
         {
            continue;
         }
         var ShangDianItem = Instantiate(Resources.Load("Prefabs/Window/招募商店item"),商店Content.transform).GetComponent<招募商店item>();
         ShangDianItem.type = HeroConfig.HeroToPropDic[item.Key];
         ShangDianItem.招募商店兑换窗口 = 招募商店兑换窗口;
         ShangDianItem.SetItem();
      }
   }
   private void Start()
   {
      ShowShangDian();
      概率按钮.onClick.AddListener(() =>
      {
         概率弹窗.gameObject.SetActive(true);
      });
      Toggle.onValueChanged.AddListener(delegate
      {
         Is10 = Toggle.isOn;
         ResetCount();
      });

      普通招募按钮.onClick.AddListener(() =>
      {
         if (!Is10)
         {
            招募成功弹窗.Is10 = false;
            PropType propType = ZhaoMuConfig.NormalZhaoMu();
            招募成功弹窗.Item1Type = propType;
            招募成功弹窗.gameObject.SetActive(true);
         }
         else
         {
            招募成功弹窗.Is10 = true;
            招募成功弹窗.list.Clear();
            for (int i = 0; i < 10; i++)
            {
               招募成功弹窗.list[i]=ZhaoMuConfig.NormalZhaoMu();
            }
            招募成功弹窗.gameObject.SetActive(true);
         }
      });
   }
}
