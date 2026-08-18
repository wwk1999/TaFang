using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 炼器界面 : MonoBehaviour
{
    public Button exitButton;
    public Button 仙石镶嵌Button;
    public Button 法器洗练Button;
    public Button 仙石重铸Button;
    public GameObject 仙石镶嵌Panel;
    public GameObject 法器洗练Panel;
    public GameObject 仙石重铸Panel;
    private int 显示类型 = 1;

    public void Set按钮()
    {
        switch (显示类型)
        {
            case 1:
                仙石镶嵌Button.image.sprite = ResourcesConfig.古朴按钮亮;
                法器洗练Button.image.sprite = ResourcesConfig.古朴按钮暗;
                仙石重铸Button.image.sprite = ResourcesConfig.古朴按钮暗;
                break;
            case 2:
                仙石镶嵌Button.image.sprite = ResourcesConfig.古朴按钮暗;
                法器洗练Button.image.sprite = ResourcesConfig.古朴按钮亮;
                仙石重铸Button.image.sprite = ResourcesConfig.古朴按钮暗;
                break;
            case 3:
                仙石镶嵌Button.image.sprite = ResourcesConfig.古朴按钮暗;
                法器洗练Button.image.sprite = ResourcesConfig.古朴按钮暗;
                仙石重铸Button.image.sprite = ResourcesConfig.古朴按钮亮;
                break;
        }
    }
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
        仙石镶嵌Button.onClick.AddListener(() =>
        {
            显示类型 = 1;
            Show();
        });
        法器洗练Button.onClick.AddListener(() =>
        {
            显示类型 = 2;
            Show();
        });
        仙石重铸Button.onClick.AddListener(() =>
        {
            显示类型 = 3;
            Show();
        });
    }

    public void Show()
    {
        Set按钮();
        switch (显示类型)
        {
            case 1:
                仙石镶嵌Panel.SetActive(true);
                法器洗练Panel.SetActive(false);
                仙石重铸Panel.SetActive(false);
                break;
            case 2:
                仙石镶嵌Panel.SetActive(false);
                法器洗练Panel.SetActive(true);
                仙石重铸Panel.SetActive(false);
                break;
            case 3:
                仙石镶嵌Panel.SetActive(false);
                法器洗练Panel.SetActive(false);
                仙石重铸Panel.SetActive(true);
                break;
        }
    }
}
