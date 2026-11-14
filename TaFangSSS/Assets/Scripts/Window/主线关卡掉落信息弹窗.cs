using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 主线关卡掉落信息弹窗 : MonoBehaviour
{
    public Image bg;
   public Image icon;
   public TextMeshProUGUI name;
   public TextMeshProUGUI desc;
   public TextMeshProUGUI 数量;

   [NonSerialized]public 道具信息Type  type;
   [NonSerialized] public float count;

   private void FollowMouse()
   {
      Vector2 mousePos = Input.mousePosition;
      Vector2 targetPos = mousePos ;
      transform.position = targetPos;
   }

   private void Update()
   {
      FollowMouse();
   }

   public void SetItem()
   {
//      分解tip.gameObject.SetActive(PropConfig.Prop是否为法器材料(PropConfig.道具信息ToPropType[type]));
      bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(PropConfig.Get道具信息品质(type));
      icon.sprite = PropConfig.Get道具信息Sprite(type);
      name.text = PropConfig.Get道具信息Name(type);
      desc.text = PropConfig.Get道具信息Info(type);
      int min = (int)(count * 0.8f);
      int max = (int)(count * 1.2f);
      if (type == 道具信息Type.轮回石)
      {
         数量.text=PlayerData.S.格式化数字(count)+"-"+PlayerData.S.格式化数字(count);
      }
      else
      {
         数量.text=PlayerData.S.格式化数字(min)+"-"+PlayerData.S.格式化数字(max);
      }
   }
}
