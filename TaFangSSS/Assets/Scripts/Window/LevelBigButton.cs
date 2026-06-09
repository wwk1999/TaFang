using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelBigButton : MonoBehaviour
{
   public List<GameObject>LevelSmallButtons = new List<GameObject>();
   public LevelBigType LevelBigType;
   public TextMeshProUGUI Name;
   public Button Button;
   public RectTransform RectTransform;
   private void OnEnable()
   {
      Name.text=LevelConfig.LevelBigNameDic[LevelBigType];
      RefreshList();
   }

   private void Start()
   {
      Button.onClick.AddListener(() =>
      {
         PlayerData.S.LevelZhanKaiDic[LevelBigType]=!PlayerData.S.LevelZhanKaiDic[LevelBigType];
         RefreshList();
      });
   }

   public void RefreshList()
   {
      switch (PlayerData.S.LevelZhanKaiDic[LevelBigType])
      {
         case false:
            foreach (var item in LevelSmallButtons)
            {
               item.gameObject.SetActive(false);
            }
            RectTransform.localScale=new Vector3 (1, -1, 1);
            break;
         case true:
            foreach (var item in LevelSmallButtons)
            {
               item.gameObject.SetActive(true);
            }
            RectTransform.localScale=new Vector3 (1, 1, 1);
            break;
      }
   }
}
