using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 新手攻略 : MonoBehaviour
{
   public Button 退出按钮;
   public Button maskButton;

   private void Start()
   {
      退出按钮.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      maskButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
   }
}
