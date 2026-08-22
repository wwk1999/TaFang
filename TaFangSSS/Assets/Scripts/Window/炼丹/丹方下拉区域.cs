using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 丹方下拉区域 : MonoBehaviour
{
    public RectTransform trans1;
    public RectTransform trans2;
    public GameObject content; 
    [NonSerialized] public List<丹药> list = new List<丹药>();

    private void OnEnable()
    {
        StartCoroutine(初始化并刷新());
    }

    IEnumerator 初始化并刷新()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }
        yield return null;
        foreach (var item in list)
        {
            var 丹方品质item = Instantiate(Resources.Load("Prefabs/Window/炼丹界面/丹方品质item"), content.transform)
                .GetComponent<丹方品质item>();
            丹方品质item.丹药Type = item.丹药Type;
            丹方品质item.QualityType = item.QualityType;
            丹方品质item.SetItem();
        }

        yield return null; 
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(trans1);
        LayoutRebuilder.ForceRebuildLayoutImmediate(trans2);
        Canvas.ForceUpdateCanvases();
    }
}