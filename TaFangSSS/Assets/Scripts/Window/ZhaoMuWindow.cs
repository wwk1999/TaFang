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
   public Toggle 招募所有Toggle;

   public Button 概率按钮;
   public GameObject 概率弹窗;
   public Button 普通招募按钮;
   public Button 高级招募按钮;
   public Button 退出按钮;
   public Toggle 招募十次Toggle;
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
      招募十次Toggle.isOn=PlayerData.S.是否招募十次;
      招募所有Toggle.isOn=PlayerData.S.是否招募所有;
      积分.text=PlayerData.S.招募积分.ToString();
      当前NormalCount.text = PlayerData.S.PropListDic[PropType.招募卷].ToString();
      当前GaoJiCount.text = PlayerData.S.PropListDic[PropType.高级招募卷].ToString();
      if (PlayerData.S.是否招募所有)
      {
         NormalCount.text = PlayerData.S.PropListDic[PropType.招募卷].ToString();
         GaoJiCount.text = PlayerData.S.PropListDic[PropType.高级招募卷].ToString();
      }
      else
      {
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

   /// <summary>
   /// 弹窗不能裸 SetActive：后台战斗场景 additive 加载后 Overlay Canvas 全局排序缓存可能不重建，
   /// 弹窗会被压在战斗 UI 底下（逻辑照跑但看不见），必须走排序刷新
   /// </summary>
   private void 显示弹窗(GameObject window)
   {
      window.SetActive(true);
      WindowController.强制刷新画布排序(window);
   }

   public void 刷新招募界面(object[] obj)
   {
      ResetCount();
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("刷新招募界面",刷新招募界面);
   }
   public IEnumerator 招募所有Toast(Dictionary<PropType, int> list)
   {
      foreach (var item in list)
      {
         ObserverModuleManager.S.SendEvent("SendUIToast",PropConfig.PropNameDic[item.Key],PropConfig.PropQualityDic[item.Key],item.Value);
         yield return new WaitForSeconds(0.1f);
      }
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         if (招募成功弹窗.gameObject.activeSelf)
         {
            招募成功弹窗.gameObject.SetActive(false);
         }
         else if (招募商店兑换窗口.gameObject.activeSelf)
         {
            招募商店兑换窗口.gameObject.SetActive(false);
         }
         else if (概率弹窗.gameObject.activeSelf)
         {
            概率弹窗.gameObject.SetActive(false);
         }
         else
         {
            gameObject.SetActive(false);
         }
      }
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("刷新招募界面",刷新招募界面);
      ShowShangDian();
      概率按钮.onClick.AddListener(() =>
      {
         显示弹窗(概率弹窗);
      });
      招募十次Toggle.onValueChanged.AddListener(delegate
      {
         ObserverModuleManager.S.SendEvent("播放音效",音效Type.Toggle);
         PlayerData.S.是否招募十次 = 招募十次Toggle.isOn;
         if (PlayerData.S.是否招募十次)
         {
            PlayerData.S.是否招募所有 = false;
         }
         ResetCount();
      });
      招募所有Toggle.onValueChanged.AddListener(delegate
      {
         ObserverModuleManager.S.SendEvent("播放音效",音效Type.Toggle);
         PlayerData.S.是否招募所有 = 招募所有Toggle.isOn;
         if (PlayerData.S.是否招募所有)
         {
            PlayerData.S.是否招募十次 = false;
         }
         ResetCount();
      });
      退出按钮.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      高级招募按钮.onClick.AddListener(() =>
      {
         if (PlayerData.S.是否招募所有)
         {
            Dictionary<PropType,int> 招募列表 = new Dictionary<PropType,int>();
            for (int i = 0; i < PlayerData.S.PropListDic[PropType.高级招募卷]; i++)
            {
               PropType heroType=ZhaoMuConfig.GaoJiZhaoMu();
               if (招募列表.ContainsKey(heroType))
               {
                  招募列表[heroType]++;
               }
               else
               {
                  招募列表[heroType] = 1;
               }
            }
            StartCoroutine(招募所有Toast(招募列表));
            foreach (var item in 招募列表)
            {
               PlayerData.S.HeroDataDic[PropConfig.PropToHeroDic[item.Key]].元神 += item.Value;   
            }
            PlayerData.S.招募积分 += 5*(int)PlayerData.S.PropListDic[PropType.高级招募卷];
            PlayerData.S.PropListDic[PropType.高级招募卷] = 0;
            ResetCount();
            return;
         }
         
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
            显示弹窗(招募成功弹窗.gameObject);
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
            显示弹窗(招募成功弹窗.gameObject);
         }

         ResetCount();
      });
      
      
      普通招募按钮.onClick.AddListener(() =>
      {
         if (PlayerData.S.是否招募所有)
         {
            Dictionary<PropType,int> 招募列表 = new Dictionary<PropType,int>();
            for (int i = 0; i < PlayerData.S.PropListDic[PropType.招募卷]; i++)
            {
               PropType heroType=ZhaoMuConfig.NormalZhaoMu();
               if (招募列表.ContainsKey(heroType))
               {
                  招募列表[heroType]++;
               }
               else
               {
                  招募列表[heroType] = 1;
               }
            }
            StartCoroutine(招募所有Toast(招募列表));
            foreach (var item in 招募列表)
            {
               PlayerData.S.HeroDataDic[PropConfig.PropToHeroDic[item.Key]].元神 += item.Value;   
            }
            PlayerData.S.招募积分 += (int)PlayerData.S.PropListDic[PropType.招募卷];
            PlayerData.S.PropListDic[PropType.招募卷] = 0;
            ResetCount();
            return;
         }
         if (PlayerData.S.PropListDic[PropType.招募卷] < 1)
         {
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
            ObserverModuleManager.S.SendEvent("SendUIToast","招募卷数量不足");
            return;
         }
         招募成功弹窗.IsGaoJi = false;
         if (!PlayerData.S.是否招募十次)
         {
            招募成功弹窗.Is10 = false;
            PropType propType = ZhaoMuConfig.NormalZhaoMu();
            招募成功弹窗.Item1Type = propType;
            显示弹窗(招募成功弹窗.gameObject);
            PlayerData.S.招募积分++;
            PlayerData.S.PropListDic[PropType.招募卷]--;
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
            显示弹窗(招募成功弹窗.gameObject);
            PlayerData.S.招募积分+=10;
         }
         ResetCount();
      });
   }
}
