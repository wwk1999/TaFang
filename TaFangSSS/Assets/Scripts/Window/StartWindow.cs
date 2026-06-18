using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartWindow : MonoBehaviour
{
   public Button StartBtn;

   private void Start()
   {
      StartBtn.onClick.AddListener(() =>
         {
            SceneManager.LoadScene("UIScene");
         }
      );
   }
}
