using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 藏品仓库 : MonoBehaviour
{
    public Button exitButton;
    public GameObject content;
    public TextMeshProUGUI 总时间流速;
    public TextMeshProUGUI 总最终伤害;
    public TextMeshProUGUI 总跟脚倍数;

    private void OnEnable()
    {
        Show();
    }

    private void Start()
    {
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void Show()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        总时间流速.text = PlayerData.S.格式化数字(赌坊Config.Get藏品总时间流速加成());
        总最终伤害.text = PlayerData.S.格式化数字(赌坊Config.Get藏品总最终伤害加成());
        总跟脚倍数.text = PlayerData.S.格式化数字(赌坊Config.Get藏品总跟脚倍数加成());

        var 荒藏品 = Instantiate(Resources.Load("Prefabs/Window/赌坊/藏品仓库种类item"), content.transform)
            .GetComponent<藏品仓库种类item>();
        荒藏品.QualityType = QualityType.荒品;
        荒藏品.SetItem();
        
        var 洪藏品 = Instantiate(Resources.Load("Prefabs/Window/赌坊/藏品仓库种类item"), content.transform)
            .GetComponent<藏品仓库种类item>();
        洪藏品.QualityType = QualityType.洪品;
        洪藏品.SetItem();
        
        var 宙藏品 = Instantiate(Resources.Load("Prefabs/Window/赌坊/藏品仓库种类item"), content.transform)
            .GetComponent<藏品仓库种类item>();
        宙藏品.QualityType = QualityType.宙品;
        宙藏品.SetItem();
    }
}
