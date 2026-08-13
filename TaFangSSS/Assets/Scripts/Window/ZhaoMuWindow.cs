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
   public TextMeshProUGUI NormalCount;
   public TextMeshProUGUI 当前NormalCount;
   public TextMeshProUGUI GaoJiCount;
   public TextMeshProUGUI 当前GaoJiCount;
   public 招募成功弹窗 招募成功弹窗;
   public GameObject 商店Content;
   public 招募商店兑换弹窗 招募商店兑换窗口;

   public TextMeshProUGUI 积分;
   public void ResetCount()
   {
      Toggle.isOn=PlayerData.S.是否招募十次;
      积分.text=PlayerData.S.招募积分.ToString();
      当前NormalCount.text = PlayerData.S.PropListDic[PropType.招募卷].ToString();
      当前GaoJiCount.text = PlayerData.S.PropListDic[PropType.高级招募卷].ToString();
      if (PlayerData.S.是否招募十次)
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

   private void OnEnable()
   {
      ResetCount();
   }

   public void 刷新招募界面(object[] obj)
   {
      ResetCount();
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("刷新招募界面",刷新招募界面);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("刷新招募界面",刷新招募界面);
      ShowShangDian();
      概率按钮.onClick.AddListener(() =>
      {
         概率弹窗.gameObject.SetActive(true);
      });
      Toggle.onValueChanged.AddListener(delegate
      {
         ObserverModuleManager.S.SendEvent("播放音效",音效Type.Toggle);
         PlayerData.S.是否招募十次 = Toggle.isOn;
         ResetCount();
      });
      退出按钮.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      高级招募按钮.onClick.AddListener(() =>
      {
         招募成功弹窗.IsGaoJi = true;
         if (!PlayerData.S.是否招募十次)
         {
            if (PlayerData.S.PropListDic[PropType.高级招募卷] < 1)
            {
               ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
               ObserverModuleManager.S.SendEvent("SendUIToast","招募卷数量不足");
               return;
            }
            PlayerData.S.PropListDic[PropType.高级招募卷]--;
            PlayerData.S.招募积分 += 5;

            招募成功弹窗.Is10 = false;
            PropType propType = ZhaoMuConfig.GaoJiZhaoMu();
            招募成功弹窗.Item1Type = propType;
            招募成功弹窗.gameObject.SetActive(true);
         }
         else
         {
            if (PlayerData.S.PropListDic[PropType.高级招募卷] < 10)
            {
               ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
               ObserverModuleManager.S.SendEvent("SendUIToast","招募卷数量不足");
               return;
            }
            PlayerData.S.PropListDic[PropType.高级招募卷]-=10;
            PlayerData.S.招募积分 += 50;
            招募成功弹窗.Is10 = true;
            招募成功弹窗.list.Clear();
            for (int i = 0; i < 10; i++)
            {
               招募成功弹窗.list[i]=ZhaoMuConfig.GaoJiZhaoMu();
            }
            招募成功弹窗.gameObject.SetActive(true);
         }

         ResetCount();
      });

      普通招募按钮.onClick.AddListener(() =>
      {
         if (PlayerData.S.PropListDic[PropType.招募卷] < 1)
         {
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
            ObserverModuleManager.S.SendEvent("SendUIToast","招募卷数量不足");
            return;
         }
         PlayerData.S.PropListDic[PropType.招募卷]--;
         招募成功弹窗.IsGaoJi = false;
         if (!PlayerData.S.是否招募十次)
         {
            招募成功弹窗.Is10 = false;
            PropType propType = ZhaoMuConfig.NormalZhaoMu();
            招募成功弹窗.Item1Type = propType;
            招募成功弹窗.gameObject.SetActive(true);
            PlayerData.S.招募积分++;
         }
         else
         {
            if (PlayerData.S.PropListDic[PropType.招募卷] < 10)
            {
               ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

               ObserverModuleManager.S.SendEvent("SendUIToast","招募卷数量不足");
               return;
            }
            PlayerData.S.PropListDic[PropType.招募卷]-=10;
            招募成功弹窗.Is10 = true;
            招募成功弹窗.list.Clear();
            for (int i = 0; i < 10; i++)
            {
               招募成功弹窗.list[i]=ZhaoMuConfig.NormalZhaoMu();
            }
            招募成功弹窗.gameObject.SetActive(true);
            PlayerData.S.招募积分+=10;
         }
         ResetCount();
      });
   }
}
