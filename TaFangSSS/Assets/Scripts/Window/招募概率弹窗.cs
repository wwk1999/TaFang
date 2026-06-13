using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 招募概率弹窗 : MonoBehaviour
{
   public Button LeftButton;
   public Button RightButton;
   public TextMeshProUGUI Title;
   public GameObject Content;
   public Button NormalZhaoMuButton;
   public Button GaoJiZhaoMuButton;
   [NonSerialized] public bool IsGaoJi = false;
   [NonSerialized]public JingJieType JingJieType=JingJieType.练气;

   public Button maskButton;

   private void OnEnable()
   {
      JingJieType = PlayerData.S.JingJieType;
      Show();
   }

   private void Start()
   {
      maskButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      LeftButton.onClick.AddListener(() =>
      {
         JingJieType = JingJieType == JingJieType.练气 ? JingJieType.练气 :(JingJieType - 1);
         Show();
      });
      RightButton.onClick.AddListener(() =>
      {
         JingJieType = JingJieType == JingJieType.鸿蒙 ? JingJieType.鸿蒙 :(JingJieType + 1);
         Show();
      });
      NormalZhaoMuButton.onClick.AddListener(() =>
      {
         IsGaoJi = false;
         Show();
      });
      GaoJiZhaoMuButton.onClick.AddListener(() =>
      {
         IsGaoJi = true;
         Show();
      });
   }

   public void Show()
   {
      foreach (Transform item in Content.transform)
      {
         Destroy(item.gameObject);
      }
      Title.text = JingJieConfig.JingJieNameDic[JingJieType];
      List<ZhaoMuItem>list = new List<ZhaoMuItem>();
      if (!IsGaoJi)
      {
         list=ZhaoMuConfig.ZhaoMuGaiLvNormalDic[JingJieType];
         NormalZhaoMuButton.image.sprite = ResourcesConfig.招募概率按钮亮;
         GaoJiZhaoMuButton.image.sprite = ResourcesConfig.招募概率按钮暗;
      }
      else
      {
         list=ZhaoMuConfig.ZhaoMuGaiLvGaoJiDic[JingJieType];
         NormalZhaoMuButton.image.sprite = ResourcesConfig.招募概率按钮暗;
         GaoJiZhaoMuButton.image.sprite = ResourcesConfig.招募概率按钮亮;
      }

      foreach (var item in list)
      {
         var gailvItem = Instantiate(Resources.Load("Prefabs/Window/概率Item"),Content.transform).GetComponent<招募概率item>();
         gailvItem.QualityType=item.type;
         gailvItem.IsGaoJi = IsGaoJi;
         gailvItem.jingJieType = JingJieType;
         gailvItem.SetItem();
      }
   }
}
