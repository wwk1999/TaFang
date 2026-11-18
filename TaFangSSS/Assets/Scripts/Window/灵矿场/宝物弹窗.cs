using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 宝物弹窗 : MonoBehaviour
{
    public Button 详情Button;
    public Button exitbutton;
    public Button maskButton;
    public GameObject 当前佩戴obj;
    public GameObject 宝物背包obj;
    public GameObject 全局效果obj;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI 效果;

    public void Show当前佩戴宝物()
    {
        foreach (Transform item in 当前佩戴obj.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 1; i <= 10; i++)
        {
            var 宝物 = Instantiate(Resources.Load("Prefabs/Window/灵矿场/当前佩戴宝物Item"), 当前佩戴obj.transform)
                .GetComponent<当前佩戴宝物Item>();
            宝物.index = i;
            宝物.SetItem();
        }
    }

    public void Show宝物背包()
    {
        foreach (Transform item in 宝物背包obj.transform)
        {
            Destroy(item.gameObject);
        }
        
    }
}
