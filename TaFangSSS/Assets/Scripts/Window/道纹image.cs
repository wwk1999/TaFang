using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class 道纹image : MonoBehaviour
{
   public RectTransform canvasRectTransform;
   public RectTransform _transform = null;
   public ScrollRect  ScrollView;
   private void Update()
   {
      HeroWindowController.S.道纹IsDrag = true;
      ScrollView.vertical=false;
      Vector2 localPoint;
      bool isInside = RectTransformUtility.ScreenPointToLocalPointInRectangle(
         canvasRectTransform, 
         Input.mousePosition, 
         null,
         out localPoint
      );
      _transform.localPosition=localPoint;
      if (Input.GetMouseButtonUp(0))
      {
         StartCoroutine(Delay松开());
      }
   }

   IEnumerator Delay松开()
   {
      yield return null;
      HeroWindowController.S.道纹IsDrag = false;
      ScrollView.vertical=true;
      gameObject.SetActive(false);
   }
}
