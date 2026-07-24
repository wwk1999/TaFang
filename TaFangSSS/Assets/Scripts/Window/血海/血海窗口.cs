using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 血海窗口 : MonoBehaviour
{
     public GameObject 关卡列表GameObj;
   public TextMeshProUGUI 关卡名;
   public GameObject 掉落GameObject;
   public GameObject 英雄派遣GameObject;
   public TextMeshProUGUI 掉落数量;
   public TextMeshProUGUI 年数;
   public TextMeshProUGUI 职业;
   public TextMeshProUGUI 星级;
   public Button 当前收获Button;
   public Button 寻宝按钮;
   public TextMeshProUGUI 寻宝按钮Text;
   public Toggle 重复寻宝;
   public Button 概率Button;
   public Button ExitButton;
   public 血海英雄派遣弹窗 血海英雄派遣弹窗;
   public 血海当前收获弹窗 血海当前收获弹窗;
   public 血海概率弹窗 血海概率弹窗;
   public string get数字(int count)
   {
      switch (count)
      {
         case 1:
            return "一";
         case 2:
            return "二";
         case 3:
            return "三";
         case 4:
            return "四";
         case 5:
            return "五";
         case 6:
            return "六";
         case 7:
            return "七";
         case 8:
            return "八";
         case 9:
            return "九";
         case 10:
            return "十";
      }

      return null;
   }

   public void 刷新血海窗口(object[] obj)
   {
      ObserverModuleManager.S.SendEvent("血海按钮点击", HeroWindowController.S.当前血海层数);
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("血海按钮点击",血海按钮点击);
      ObserverModuleManager.S.UnRegisterEvent("刷新血海窗口",刷新血海窗口);
      ObserverModuleManager.S.UnRegisterEvent("显示血海英雄派遣弹窗",显示血海英雄派遣弹窗);
   }

   public void 显示血海英雄派遣弹窗(object[] obj)
   {
      血海英雄派遣弹窗.gameObject.SetActive(true);
   }
   private void On重复寻宝切换(bool isOn)
   {
      if (isOn)
      {
         PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].重复 = true;
      }
      else
      {
         PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].重复 = false;
      }
   }
   private void Awake()
   {
      ObserverModuleManager.S.RegisterEvent("血海按钮点击",血海按钮点击);
      ObserverModuleManager.S.RegisterEvent("刷新血海窗口",刷新血海窗口);
      ObserverModuleManager.S.RegisterEvent("显示血海英雄派遣弹窗",显示血海英雄派遣弹窗);
      ExitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      概率Button.onClick.AddListener(() =>
      {
         血海概率弹窗.gameObject.SetActive(true);
      });
      当前收获Button.onClick.AddListener(() =>
      {
         血海当前收获弹窗.gameObject.SetActive(true);
      });
      重复寻宝.onValueChanged.AddListener(On重复寻宝切换);      
      寻宝按钮.onClick.AddListener(() =>
      {
         bool flag = true;
         foreach (var item in PlayerData.S.血海英雄派遣Dic[HeroWindowController.S.当前血海层数])
         {
            if (item == HeroType.None)
            {
               flag = false;
            }
         }

         if (!flag)
         {
            ObserverModuleManager.S.SendEvent("SendUIToast","请选择英雄派遣");
            return;
         }

         PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].寻宝 = true;
         PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].time =
            血海Config.血海关卡Dic[HeroWindowController.S.当前血海层数].需要年数 * 属性config.每年秒数;
         寻宝按钮.interactable = false;
      });
   }

   public void Show关卡列表()
   {
      foreach (Transform item in 关卡列表GameObj.transform)
      {
         Destroy(item.gameObject);
      }

      for (int i = 1; i <= 9; i++)
      {
         var 关卡item = Instantiate(Resources.Load("Prefabs/Window/血海关卡item"), 关卡列表GameObj.transform)
            .GetComponent<血海关卡item>();
         关卡item.层数 = i;
         关卡item.SetItem();
      }
   }

   private void OnEnable()
   {
      Show关卡列表();
      HeroWindowController.S.当前血海层数 = 血海Config.Get血海最大层数();
      ObserverModuleManager.S.SendEvent("血海按钮点击", 血海Config.Get血海最大层数());
   }

   public void 血海按钮点击(object[] obj)
   {
      int 层数=(int)obj[0];
      HeroWindowController.S.当前血海层数 = 层数;
      关卡名.text = "第" + get数字(层数) + "层";
      foreach (Transform item in 掉落GameObject.transform)
      {
         Destroy(item.gameObject);
      }
      foreach (Transform item in 英雄派遣GameObject.transform)
      {
         Destroy(item.gameObject);
      }

      var list = 血海Config.血海关卡Dic[层数].list;
      foreach (var item in list)
      {
         var 掉落item = Instantiate(Resources.Load("Prefabs/Window/秘境掉落item"), 掉落GameObject.transform)
            .GetComponent<秘境掉落item>();
         掉落item.Quality = item.quality;
         掉落item.SetItem();
      }
      int count=0;
      foreach (var item in PlayerData.S.血海英雄派遣Dic[层数])
      {
         var 英雄派遣item = Instantiate(Resources.Load("Prefabs/Window/血海英雄派遣item"), 英雄派遣GameObject.transform)
                     .GetComponent<血海英雄派遣item>();
         英雄派遣item.HeroType=item;
         英雄派遣item.index = count;
         英雄派遣item.SetItem();
         count++;
      }

      掉落数量.text = 血海Config.血海关卡Dic[层数].掉落数量.ToString();
      年数.text = 血海Config.血海关卡Dic[层数].需要年数.ToString();
      职业.text = HeroConfig.Get职业Name(血海Config.血海关卡Dic[层数].需要英雄职业);
      星级.text=血海Config.血海关卡Dic[层数].需要英雄星级.ToString();
      bool 寻宝=PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].寻宝;
      寻宝按钮.interactable = !寻宝;
      if (寻宝)
      {
         寻宝按钮Text.text = "寻宝中(剩余" + PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].time+")";
      }
      else
      {
         寻宝按钮Text.text = "寻宝";
      }

      重复寻宝.isOn = PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].重复;
   }

   private void Update()
   {
      bool 寻宝=PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].寻宝;
      寻宝按钮.interactable = !寻宝;
      if (寻宝)
      {
         寻宝按钮Text.text = "寻宝中(剩余" + PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].time+"S)";
      }
      else
      {
         寻宝按钮Text.text = "寻宝";
      }
   }
}
