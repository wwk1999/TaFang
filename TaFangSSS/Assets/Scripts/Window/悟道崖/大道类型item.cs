using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 大道类型item : MonoBehaviour
{
    public TextMeshProUGUI name;
    public GameObject content;
    public Image bg;

    [NonSerialized] public 大道等级Type 大道等级Type;
    public void SetItem()
    {
        switch (大道等级Type)
        {
            case 大道等级Type.基础大道:
                bg.sprite = ResourcesConfig.大道背景框蓝;
                name.text = "基础大道";
                break;
            case 大道等级Type.上等大道:
                bg.sprite = ResourcesConfig.大道背景框橙;
                name.text = "上等大道";

                break;
            case 大道等级Type.至尊大道:
                bg.sprite = ResourcesConfig.大道背景框红;
                name.text = "至尊大道";

                break;
            case 大道等级Type.本源大道:
                bg.sprite = ResourcesConfig.大道背景框彩;
                name.text = "本源大道";

                break;
        }

        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in 悟道崖Config.大道配置)
        {
            if (item.Value.大道等级Type == 大道等级Type)
            {
                var 大道item = Instantiate(Resources.Load("Prefabs/Window/悟道崖/大道item"), content.transform)
                    .GetComponent<大道item>();
                大道item.大道Type = item.Key;
                大道item.SetItem(item.Key);
            }
        }
    }
}
