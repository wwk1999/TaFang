using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 凌霄宝殿地图item : MonoBehaviour
{
    public Button image;
    public GameObject 标签;
    public TextMeshProUGUI name;

    private void Start()
    {
        image.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前显示关卡类型 = 当前显示关卡类型.凌霄宝殿;
            ObserverModuleManager.S.SendEvent("显示凌霄宝殿弹窗");
        });
    }

    private void OnEnable()
    {
        SetItem();
    }

    public void SetItem()
    {
        if (PlayerData.S.最大主线关卡 < 主线关卡Type.南天门)
        {
            标签.gameObject.SetActive(false);
            image.image.raycastTarget = false;
        }
        else
        {
            标签.gameObject.SetActive(true);
            image.image.raycastTarget = true;
            name.text = "凌霄宝殿";
        }
    }
}
