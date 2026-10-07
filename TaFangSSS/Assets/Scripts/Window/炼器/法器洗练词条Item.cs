using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 法器洗练词条Item : MonoBehaviour
{
   public TextMeshProUGUI text;
   public Button 锁;
   [NonSerialized] public 法器附加属性值 法器附加属性值;
   [NonSerialized] public 仙石Type 仙石Type=仙石Type.None;
   [NonSerialized] public bool 是否有锁=false;
   public void SetItem()
   {
       锁.gameObject.SetActive(是否有锁);
       if (法器附加属性值 != null)
       {
            if (法器附加属性值.锁)
            { 
                锁.image.sprite = ResourcesConfig.锁;
            }
            else
            {
                锁.image.sprite = ResourcesConfig.解锁;
            }
       }
       if (仙石Type != 仙石Type.None)
       {
           text.text = "仙石类型：" + 仙石Config.仙石名Dic[仙石Type];
           return;
       }
      text.text = 法器Config.法器附加属性Desc[法器附加属性值.法器附加属性Type] + "+" +
                  $"<color=green>{法器附加属性值.count.ToString("F1")}%</color>";
   }

   private void Start()
   {
       锁.onClick.AddListener(() =>
       {
           法器附加属性值.锁 = !法器附加属性值.锁;
           if (法器附加属性值.锁)
           {
               锁.image.sprite = ResourcesConfig.锁;
           }
           else
           {
               锁.image.sprite = ResourcesConfig.解锁;
           }
           ObserverModuleManager.S.SendEvent("法器词条洗练锁");
       });
   }
}
