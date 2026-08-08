using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;

public class ToastItem : MonoBehaviour
{
   public TextMeshProUGUI Text;
   public GameObject 奖励obj;
   public TextMeshProUGUI 奖励;
   public TextMeshProUGUI countText;
   [NonSerialized] public string Content;
   [NonSerialized] public string name=null;
   [NonSerialized] public QualityType quality;
   [NonSerialized] public int count=1;


   public void Destroy1()
   {
      Destroy(gameObject);
   }

   private void Start()
   {
      CancelInvoke();
      Invoke(nameof(Destroy1), 5f);
   }

   public void SetItem()
   {
      if (name == null)
      {
        Text.text = Content; 
        奖励obj.gameObject.SetActive(false);
        Text.gameObject.SetActive(true);
      }
      else
      {
         奖励obj.gameObject.SetActive(true);
         Text.gameObject.SetActive(false);
         countText.text = "X"+count;
         奖励.text=name;
         奖励.colorGradientPreset=ResourcesConfig.Get品质TMP(quality);
      }
   }
}
