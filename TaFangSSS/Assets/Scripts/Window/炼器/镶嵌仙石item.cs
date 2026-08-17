using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 镶嵌仙石item : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler,IPointerDownHandler
{
   [NonSerialized] public 仙石 仙石;
   public Image bg;
   public Image icon;
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
         ObserverModuleManager.S.SendEvent("Show仙石image",仙石);
      }

      if (Input.GetMouseButtonUp(0))
      {
         IsSend = false;
      }
   }
   
   
   public void SetItem()
   {
      bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(仙石.quality);
      icon.sprite=ResourcesConfig.Get仙石Sprite(仙石.type,仙石.quality);
      name.text=仙石Config.仙石名Dic[仙石.type];
   }
}
