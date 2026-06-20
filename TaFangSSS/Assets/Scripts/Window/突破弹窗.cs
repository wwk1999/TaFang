using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 突破弹窗 : MonoBehaviour
{
   public Button ExitButton;
   public GameObject Content;
   
   private void Start()
   {
      ExitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      ObserverModuleManager.S.RegisterEvent("Hide突破弹窗",Hide);
   }

   public void Hide(object[] obj)
   {
      gameObject.SetActive(false);
   }

   private void OnEnable()
   {
      foreach (Transform item in Content.transform)
      {
         Destroy(item.gameObject);
      }

      var 凡 = Instantiate(Resources.Load("Prefabs/Window/突破item"),Content.transform).GetComponent<突破item>();
      凡.突破Type = 突破Type.凡;
      凡.SetItem();

      var 灵 = Instantiate(Resources.Load("Prefabs/Window/突破item"),Content.transform).GetComponent<突破item>();
      灵.突破Type = 突破Type.灵;
      灵.SetItem();
      
      var 仙 = Instantiate(Resources.Load("Prefabs/Window/突破item"),Content.transform).GetComponent<突破item>();
      仙.突破Type = 突破Type.仙;
      仙.SetItem();
      
      var 圣 = Instantiate(Resources.Load("Prefabs/Window/突破item"),Content.transform).GetComponent<突破item>();
      圣.突破Type = 突破Type.圣;
      圣.SetItem();
      
      var 荒 = Instantiate(Resources.Load("Prefabs/Window/突破item"),Content.transform).GetComponent<突破item>();
      荒.突破Type = 突破Type.荒;
      荒.SetItem();
   }
}
