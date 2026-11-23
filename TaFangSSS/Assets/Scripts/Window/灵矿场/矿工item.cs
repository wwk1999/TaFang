using System;
using System.Collections;
using System.Collections.Generic;
using Config;
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
  public GameObject 星级Content;

  private bool 已随机动画相位;

  public void SetItem()
  {
    矿工类型 矿工类型 = 矿工.矿工类型;
    int 阶数 = 矿工.阶数;

    name.text = "LV."+ 矿工.等级+" "+矿工.name;
    name.colorGradientPreset = ResourcesConfig.Get品质TMP(矿工.QualityType);

    float 最大经验 = 灵矿场Config.矿工经验表[矿工.等级];
    进度条.fillAmount = 最大经验 <= 0 ? 0 : Mathf.Clamp01(矿工.经验 / 最大经验);

    Set矿工动画(矿工类型, 阶数, 矿工.QualityType);
    Set功法星级();
  }

  private void Update()
  {
    进度条.fillAmount=
  }

  private void Set矿工动画(矿工类型 类型, int 阶数, QualityType 品质)
  {
    bool 六阶以上 = 阶数 > 5;
    SkeletonGraphic 当前 = null;
    switch (类型)
    {
      case 矿工类型.疾行矿工: 当前 = 六阶以上 ? 疾行610 : 疾行15; break;
      case 矿工类型.多宝矿工: 当前 = 六阶以上 ? 多宝610 : 多宝15; break;
      case 矿工类型.守脉矿工: 当前 = 六阶以上 ? 守脉610 : 守脉15; break;
      case 矿工类型.全脉矿工: 当前 = 六阶以上 ? 全脉610 : 全脉15; break;
      case 矿工类型.秀灵矿工: 当前 = 六阶以上 ? 秀灵610 : 秀灵15; break;
    }

    SkeletonGraphic[] 全部 = { 疾行15, 疾行610, 多宝15, 多宝610, 守脉15, 守脉610, 全脉15, 全脉610, 秀灵15, 秀灵610 };
    foreach (var item in 全部)
    {
      if (item != null) item.gameObject.SetActive(item == 当前);
    }

    if (当前 == null) return;

    // 皮肤命名：一阶_白 / 一阶_蓝 / 一阶_橙 / 一阶_红 / 一阶_彩；6-10 阶没有白色皮肤，默认皮肤即为白色。
    string 阶数名 = PlayerData.S.Get阶数string(阶数);
    string 后缀 = Get品质后缀(品质);
    string 皮肤名 = 后缀 == "白" && 六阶以上 ? 阶数名 : 阶数名 + "_" + 后缀;

    var skeletonData = 当前.SkeletonData;
    if (skeletonData == null) return;
    if (skeletonData.FindSkin(皮肤名) == null) 皮肤名 = 阶数名;
    if (skeletonData.FindSkin(皮肤名) != null)
    {
      当前.InitialSkinName = 皮肤名;
      当前.Skeleton.SetSkin(皮肤名);
      当前.Skeleton.SetupPoseSlots();
    }

    SkeletonAnimation 动画 = 当前.GetComponent<SkeletonAnimation>();
    if (动画 != null && !已随机动画相位)
    {
      已随机动画相位 = true;
      var entry = 动画.AnimationState.SetAnimation(0, "锄地循环", true);
      // 随机动画起始相位，避免所有矿工动作完全同步
      entry.TrackTime = UnityEngine.Random.Range(0f, entry.Animation.Duration);
    }
  }

  private static string Get品质后缀(QualityType 品质)
  {
    switch (品质)
    {
      case QualityType.地品: return "蓝";
      case QualityType.宇品: return "橙";
      case QualityType.洪品: return "红";
      case QualityType.荒品: return "彩";
      default: return "白";
    }
  }

  private void Set功法星级()
  {
    foreach (Transform item in 星级Content.transform)
    {
      Destroy(item.gameObject);
    }

    功法星级 功法星级 = 功法Config.Get功法星级(矿工.星级);
    Add功法星级(功法星级Type.钻石, 功法星级.钻石);
    Add功法星级(功法星级Type.太阳, 功法星级.太阳);
    Add功法星级(功法星级Type.月亮, 功法星级.月亮);
    Add功法星级(功法星级Type.星星, 功法星级.星星);
  }

  private void Add功法星级(功法星级Type type, int count)
  {
    for (int i = 0; i < count; i++)
    {
      var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/技能树/功法星级item"), 星级Content.transform)
          .GetComponent<功法星级item>();
      item.功法星级Type = type;
      item.SetItem();
    }
  }
}
