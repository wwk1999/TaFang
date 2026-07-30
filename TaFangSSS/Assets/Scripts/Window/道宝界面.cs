using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 道宝界面 : MonoBehaviour
{
    public Button exitButton;
    public GameObject content;
    public Button 羁绊Button;
    public GameObject 羁绊弹窗;

    private void OnEnable()
    {
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
