using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 神物掉宝概率弹窗 : MonoBehaviour
{
    public TextMeshProUGUI 体质Count;
    public TextMeshProUGUI 丹药Count;
    public TextMeshProUGUI 三十三重天Count;
    public GameObject Content;
    public Button maskButton;

    private void Start()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    private void OnEnable()
    {
        Show();
    }

    public void Show()
    {
        体质Count.text = 体质Config.当前体质总属性.掉宝率 + "%";
        丹药Count.text = 属性config.Get丹药掉宝率() + "%";
        三十三重天Count.text = PlayerData.S.混沌虚空最大层数 + "%";
        foreach (Transform child in Content.transform)
        {
            Destroy(child.gameObject);
        }
        var 概率item = Instantiate(Resources.Load("Prefabs/Window/概率Item"), Content.transform)
            .GetComponent<招募概率item>();
        概率item.QualityType=QualityType.宇品;
        概率item.Count = 神物Config.神物掉落概率Dic[HeroWindowController.S.当前遗迹关卡Type] * 属性config.总掉宝率;
        概率item.SetItem();
        
    }
}
