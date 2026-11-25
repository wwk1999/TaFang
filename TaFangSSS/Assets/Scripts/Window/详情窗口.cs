using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 详情窗口 : MonoBehaviour
{
   public Button maskButton;
   public Button 退出按钮;
   public GameObject content;
   public 详情Type 详情Type;


   private void Start()
   {
      maskButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      退出按钮.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      foreach (Transform item in content.transform)
      {
         Destroy(item.gameObject);
      }
      foreach (var item in 详情Config.详情列表[详情Type])
      {
         var 详情item = Instantiate(Resources.Load("Prefabs/Window/详情item"), content.transform).GetComponent<详情item>();
         详情item.text = item;
         详情item.SetItem();
      }
   }
}
