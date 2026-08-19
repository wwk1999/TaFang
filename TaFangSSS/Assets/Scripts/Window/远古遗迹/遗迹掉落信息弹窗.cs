using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 遗迹掉落信息弹窗 : MonoBehaviour
{
    public Image bg;
   public Image icon;
   public TextMeshProUGUI name;
   public TextMeshProUGUI desc;
   public TextMeshProUGUI 数量;
   [NonSerialized]public 道具信息Type type;
   [NonSerialized]public 神物Type  神物Type=神物Type.None;

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
      bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType.宇品);
      if (神物Type == 神物Type.None)
      {
         icon.sprite = PropConfig.Get道具信息Sprite(type);
         name.text = PropConfig.道具信息NameDic[type];
         desc.text = PropConfig.道具信息InfoDic[type];
         HashSet<LevelDiaoLuo> list=神物Config.遗迹掉落Dic[HeroWindowController.S.当前遗迹关卡Type];
         foreach (var item in list)
         {
            if (item.PropType == PropConfig.道具信息ToPropType[type])
            {
               数量.text = "掉落数量:" + item.minCount + "-" + item.maxCount;
            }
         }

      }
      else
      {
         数量.text = "远古神物";
         icon.sprite = ResourcesConfig.Get神物Icon(神物Type);
         name.text = 神物Config.神物名Dic[神物Type];
         desc.text = 神物Config.神物descDic[神物Type];
      }
   }
}
