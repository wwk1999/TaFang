using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 道宝界面 : MonoBehaviour
{
    public Button exitButton;
    public GameObject content;
    public Button 羁绊Button;
    public GameObject 羁绊弹窗;
    public TextMeshProUGUI 总修炼速度加成;

    private void OnEnable()
    {
        总修炼速度加成.text = 道宝Config.Get道宝总修炼速度() + "%";
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in 道宝Config.道宝QualityNameDic)
        {
            var 道宝种类item = Instantiate(Resources.Load("Prefabs/Window/道宝种类item"), content.transform)
                .GetComponent<道宝种类item>();
            道宝种类item.道宝Quality = item.Key;
            道宝种类item.SetItem();
        }
    }

    private void Start()
    {
        羁绊Button.onClick.AddListener(() =>
        {
            羁绊弹窗.gameObject.SetActive(true);
        });
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
