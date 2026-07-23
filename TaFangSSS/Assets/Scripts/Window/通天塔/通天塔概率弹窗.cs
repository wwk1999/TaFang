using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 通天塔概率弹窗 : MonoBehaviour
{
  public Button maskButton;
  public GameObject content;

  public void ShowList()
  {
    var list = 通天塔Config.通天塔关卡Dic[HeroWindowController.S.当前通天塔层数].list;
    foreach (Transform item in content.transform)
    {
      Destroy(item.gameObject);
    }
    foreach (var item in list)
    {
      var 概率Item = Instantiate(Resources.Load("Prefabs/Window/概率Item"), content.transform).GetComponent<招募概率item>();
      概率Item.Count = item.概率;
      概率Item.QualityType=item.quality;
      概率Item.SetItem();
    }
  }

  private void Awake()
  {
    maskButton.onClick.AddListener(() =>
    {
      gameObject.SetActive(false);
    });
  }

  private void OnEnable()
  {
    ShowList();
  }
}
