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
   public GameObject Content;
   public Button NormalZhaoMuButton;
   public Button GaoJiZhaoMuButton;
   [NonSerialized] public bool IsGaoJi = false;

   public Button maskButton;

   private void OnEnable()
   {
      Show();
   }

   private void Start()
   {
      maskButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
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
      List<float>list = new List<float>();
      if (!IsGaoJi)
      {
         list = 道场Config.聚贤阁配置[PlayerData.S.建筑等级Dic[建筑Type.聚贤阁]].普通招募概率;
      }
      else
      {
         list=道场Config.聚贤阁配置[PlayerData.S.建筑等级Dic[建筑Type.聚贤阁]].高级招募概率;
      }

      int index = 0;
      foreach (var item in list)
      {
         index++;
         if (item == 0) continue;
         var gailvItem = Instantiate(Resources.Load("Prefabs/Window/概率Item"),Content.transform).GetComponent<招募概率item>();
         gailvItem.QualityType=(QualityType)index;
         gailvItem.Count = item;
         gailvItem.StringType = "元神";
         gailvItem.SetItem();
         index++;
      }
   }
}
