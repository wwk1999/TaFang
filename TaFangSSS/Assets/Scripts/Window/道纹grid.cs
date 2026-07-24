using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 道纹grid : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler,IPointerDownHandler
{
   [NonSerialized] public 道纹Type 道纹Type;
   [NonSerialized] public QualityType QualityType;

   public GameObject Hero;
   public Image HeroImage;
   public Image bg;
   public Image image;
   public TextMeshProUGUI count;
   public TextMeshProUGUI name;
   private Vector3 MousePos;
   private float 按压需要时间 = 0.1f;
   private float 按压当前时间 = 0;
   private bool Is进入=false;
   private bool IsSend=false;

   public void OnPointerDown(PointerEventData eventData)
   {
      MousePos=Input.mousePosition;
   }
   public void OnPointerExit(PointerEventData eventData)
   {
      Is进入 = false;
   }
   public void OnPointerEnter(PointerEventData eventData)
   {
      Is进入 = true;
   }

   private void Update()
   {
      if (Input.GetMouseButton(0)&&Input.mousePosition==MousePos)
      {
         按压当前时间+=Time.deltaTime;
      }
      else
      {
         按压当前时间 = 0;
      }

      if (按压当前时间 > 按压需要时间&&!IsSend)
      {
         IsSend = true;
         ObserverModuleManager.S.SendEvent("Show道纹image",道纹Type,QualityType);
      }

      if (Input.GetMouseButtonUp(0))
      {
         IsSend = false;
      }
   }

   public void SetItem()
   {
      if (道纹config.是否专属道纹(道纹Type))
      {
         Hero.SetActive(true);
         HeroImage.sprite = ResourcesConfig.GetHeroSprite(道纹config.道纹ToHeroDic[道纹Type]);
      }
      else
      {
         Hero.SetActive(false);
      }
      name.text = 道纹config.道纹名Dic[道纹Type];
      image.sprite = ResourcesConfig.Get道纹Sprite(道纹Type, QualityType);
      count.text = PlayerData.S.Get道纹数量(道纹Type, QualityType).ToString();
      switch (QualityType)
      {
         case QualityType.天品:
            bg.sprite = ResourcesConfig.道具背景框紫;
            break;
         case QualityType.宇品:
            bg.sprite = ResourcesConfig.道具背景框橙;
            break;
         case QualityType.宙品:
            bg.sprite = ResourcesConfig.道具背景框粉;
            break;
         case QualityType.洪品:
            bg.sprite = ResourcesConfig.道具背景框红;
            break;
         case QualityType.荒品:
            bg.sprite = ResourcesConfig.道具背景框彩;
            break;
      }
   }
   
}
