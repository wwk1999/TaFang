using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 传道概率弹窗 : MonoBehaviour
{
    public Button LeftButton;
    public Button RightButton;
    public TextMeshProUGUI Title;
    public GameObject Content;
    [NonSerialized]public QualityType QualityType=QualityType.黄品;
    public Button maskButton;
    public Button exitButton;

    private void OnEnable()
    {
        Show();
    }

    private void Start()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        LeftButton.onClick.AddListener(() =>
        {
            if (QualityType > QualityType.黄品)
            {
                QualityType--;
            }
            Show();
        });
        RightButton.onClick.AddListener(() =>
        {
            if (QualityType < QualityType.荒品)
            {
                QualityType++;
            }
            Show();
        });
    }

    public void Show()
    {
        foreach (Transform item in Content.transform)
        {
            Destroy(item.gameObject);
        }
        Title.text = PropConfig.QualityNameDic[QualityType]+"传道";
        List<float> list = 功法Config.传道概率Dic[QualityType];
        
        for (int i=0;i<list.Count;i++)
        {
            if (list[i] == 0)
            {
                return;
            }
            var gailvItem = Instantiate(Resources.Load("Prefabs/Window/概率Item"),Content.transform).GetComponent<招募概率item>();
            gailvItem.QualityType=(QualityType)(i+1);
            gailvItem.Count = list[i];
            gailvItem.StringType = "功法";
            gailvItem.SetItem();
        }
    }
}
