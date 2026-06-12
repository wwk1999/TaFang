using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZhaoMuWindow : MonoBehaviour
{
   public Button 普通招募按钮;
   public Button 高级招募按钮;
   public Button 退出按钮;
   public Toggle Toggle;
   [NonSerialized] public bool Is10=false;
   public TextMeshProUGUI NormalCount;
   public TextMeshProUGUI GaoJiCount;
   public 招募成功弹窗 招募成功弹窗;

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
   private void Start()
   {
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
      });
   }
}
