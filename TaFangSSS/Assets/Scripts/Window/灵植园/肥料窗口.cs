using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 肥料窗口 : MonoBehaviour
{
    public Button mask;
    public GameObject 背包;

    private void OnEnable()
    {
        HeroWindowController.S.当前选择肥料 = 肥料Type.None;
        HeroWindowController.S.当前选择肥料品质 = QualityType.None;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Show背包();
    }

    private void Start()
    {
        mask.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void Show背包()
    {
        foreach (Transform item in 背包.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = (int)QualityType.荒品; i >= (int)QualityType.黄品; i--)
        {
            for (int j = 1; j <= 4; j++)
            {
                if (PlayerData.S.Get肥料数量((肥料Type)j, (QualityType)i) > 0)
                {
                    var item=Instantiate(Resources.Load("Prefabs/Window/灵植园/肥料item"), 背包.transform).GetComponent<肥料item>();
                    item.肥料Tyep = (肥料Type)j;
                    item.QualityType = (QualityType)i;
                    item.SetItem();
                }
            }
        }
    }
}
