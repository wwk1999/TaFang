using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 矿工item : MonoBehaviour
{
  [NonSerialized] public 矿工 矿工;
  public SkeletonGraphic 疾行15;
  public SkeletonGraphic 疾行610;
  public SkeletonGraphic 多宝15;
  public SkeletonGraphic 多宝610;
  public SkeletonGraphic 守脉15;
  public SkeletonGraphic 守脉610;
  public SkeletonGraphic 全脉15;
  public SkeletonGraphic 全脉610;
  public SkeletonGraphic 秀灵15;
  public SkeletonGraphic 秀灵610;

  public Image 进度条;
  public TextMeshProUGUI name;
  public TextMeshProUGUI 等级;
  public GameObject 星级Content;

  public void SetItem()
  {
    矿工类型 矿工类型 = 矿工.矿工类型;
    int 阶数 = 矿工.阶数;
    
  }
}
