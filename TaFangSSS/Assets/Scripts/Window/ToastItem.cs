using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToastItem : MonoBehaviour
{
   public TextMeshProUGUI Text;
   [NonSerialized] public string Content;

   public void Destroy1()
   {
      Destroy(gameObject);
   }

   private void Start()
   {
      CancelInvoke();
      Invoke(nameof(Destroy1), 5f);
   }

   public void SetItem()
   {
      Text.text = Content;
   }
}
