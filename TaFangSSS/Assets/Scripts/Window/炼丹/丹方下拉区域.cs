using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 丹方下拉区域 : MonoBehaviour
{
    public RectTransform trans1;
    public RectTransform trans2;
    public GameObject content;
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public List<int> 已解锁阶数list = new List<int>();

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
        foreach (var 阶数 in 已解锁阶数list)
        {
            var 丹方品质item = Instantiate(Resources.Load("Prefabs/Window/炼丹界面/丹方品质item"), content.transform) as GameObject;
            var comp = 丹方品质item.GetComponent<丹方品质item>();
            comp.丹药Type = 丹药Type;
            comp.阶数 = 阶数;
            comp.SetItem();
        }

        yield return null;

        LayoutRebuilder.ForceRebuildLayoutImmediate(trans1);
        LayoutRebuilder.ForceRebuildLayoutImmediate(trans2);
        Canvas.ForceUpdateCanvases();
    }
}
