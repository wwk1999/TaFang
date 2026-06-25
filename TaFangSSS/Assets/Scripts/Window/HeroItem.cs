using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroItem : MonoBehaviour
{
   [NonSerialized]public bool IsSuo=false;
   [NonSerialized]public HeroType HeroType=HeroType.None;
   [NonSerialized] public int Index = 0;
   public GameObject 箭头;
   public GameObject 交换;
   public GameObject 锁;
   public Image image;
   public TextMeshProUGUI tip;

   private void Update()
   {
      if (HeroWindowController.S.IsJiaoHuan&&!IsSuo&&HeroWindowController.S.交换HeroItem==this)
      {
         交换.gameObject.SetActive(true);
         箭头.gameObject.SetActive(false);
      }else if (!IsSuo && HeroWindowController.S.IsDrag)
      {
         箭头.gameObject.SetActive(true);
         交换.gameObject.SetActive(false);
      }
      else
      {
         箭头.gameObject.SetActive(false);
         交换.gameObject.SetActive(false);
      }
   }

   public void SetItem()
   {
      箭头.gameObject.SetActive(false);
      交换.gameObject.SetActive(false);
      锁.SetActive(IsSuo);
      image.gameObject.SetActive(!IsSuo);
      if (HeroType == HeroType.None)
      {
         image.color=new Color32(255, 255, 255, 0);
      }
      else
      {
         image.color=new Color32(255, 255, 255, 255);
      }
      if (!IsSuo)
      {
         tip.gameObject.SetActive(false);
         image.sprite=ResourcesConfig.GetHeroSprite(HeroType);
      }
      else
      {
         tip.gameObject.SetActive(true);
         tip.text = HeroConfig.SuoTipDic[Index];
      }
   }

}
