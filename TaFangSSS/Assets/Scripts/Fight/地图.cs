using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum 地图Type
{
   None,
   火山,
   森林,
   海底,
   沙漠,
   平原,
   天庭,
   混沌,
   雪地,
}
public class 地图 : MonoBehaviour
{
   public GameObject 火山;
   public GameObject 森林;
   public GameObject 海底;
   public GameObject 沙漠;
   public GameObject 平原;
   public GameObject 天庭;
   public GameObject 混沌;
   public GameObject 雪地;

   public void 设置地图(object[] obj)
   {
      地图Type type = (地图Type)obj[0];
      火山.gameObject.SetActive(type==地图Type.火山);
      森林.gameObject.SetActive(type==地图Type.森林);
      海底.gameObject.SetActive(type==地图Type.海底);
      沙漠.gameObject.SetActive(type==地图Type.沙漠);
      平原.gameObject.SetActive(type==地图Type.平原);
      天庭.gameObject.SetActive(type==地图Type.天庭);
      混沌.gameObject.SetActive(type==地图Type.混沌);
      雪地.gameObject.SetActive(type==地图Type.雪地);
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("设置地图",设置地图);
   }

   private void Awake()
   {
      ObserverModuleManager.S.RegisterEvent("设置地图",设置地图);
   }
}
