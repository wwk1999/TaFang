using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 洗练概率弹窗 : MonoBehaviour
{
    public Button LeftBtn;
    public Button RightBtn;
    public TextMeshProUGUI QualityText;
    public Button maskBtn;
    public GameObject Content;
    [NonSerialized]public QualityType EquipQualityType;

    private void Start()
    {
        maskBtn.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        LeftBtn.onClick.AddListener(() =>
        {
            EquipQualityType--;
            if (EquipQualityType < QualityType.玄品)
            {
                EquipQualityType = QualityType.玄品;
            }
            Show();
        });
        RightBtn.onClick.AddListener(() =>
        {
            EquipQualityType++;
            if (EquipQualityType > QualityType.荒品)
            {
                EquipQualityType = QualityType.荒品;
            }
            Show();
        });
    }

    private void OnEnable()
    {
        Show();
    }

    public void Show()
    {
        QualityText.text=PropConfig.QualityNameDic[EquipQualityType];
        foreach (Transform item in Content.transform)
        {
            Destroy(item.gameObject);
        }
        var list=EquipConfig.强化词条概率Dic[EquipQualityType];
        QualityType qualityType = QualityType.玄品;
        foreach (var item in list)
        {
            var gailvitem = Instantiate(Resources.Load("Prefabs/Window/概率Item"), Content.transform)
                .GetComponent<招募概率item>();
            gailvitem.QualityType = qualityType;
            gailvitem.Count = item;
            gailvitem.StringType = "词条";
            gailvitem.SetItem();
            qualityType++;
        }
    }
}
