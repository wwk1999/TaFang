using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 装备对比信息弹窗 : MonoBehaviour
{
   [NonSerialized] public 矿工装备 选中矿工装备;
   [NonSerialized] public 矿工 当前矿工;
   public 装备信息弹窗 选中装备;
   public 装备信息弹窗 穿戴装备1111;

   public void SetItem()
   {
      if (当前矿工 == null)
      {
         穿戴装备1111.gameObject.SetActive(false);
         选中装备.gameObject.SetActive(true);
         选中装备.矿工装备 = 选中矿工装备;
         选中装备.SetItem();
      }
      else
      {
         选中装备.gameObject.SetActive(true);
         选中装备.矿工装备 = 选中矿工装备;
         选中装备.SetItem();
         矿工装备Type type = 选中矿工装备.矿工装备Type;
         矿工装备 穿戴装备 = null;
         switch (type)
         {
            case 矿工装备Type.护手:
               穿戴装备 = 当前矿工.护手;
               break;
            case 矿工装备Type.稿子:
               穿戴装备 = 当前矿工.稿子;
               break;
            case 矿工装备Type.衣服:
               穿戴装备 = 当前矿工.衣服;
               break;
            case 矿工装备Type.罗盘:
               穿戴装备 = 当前矿工.罗盘;
               break;
         }
         if (穿戴装备 != null)
         {
            穿戴装备1111.gameObject.SetActive(true);
            穿戴装备1111.矿工装备 = 穿戴装备;
            穿戴装备1111.SetItem();
         }
         else
         {
            穿戴装备1111.gameObject.SetActive(false);
         }
      }
   }
}
