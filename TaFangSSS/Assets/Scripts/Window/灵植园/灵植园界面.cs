using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 灵植园界面 : MonoBehaviour
{
    public Button 退出按钮;
    public Button 返回领地按钮;
    public GameObject 土地;


    private void Start()
    {
        退出按钮.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        返回领地按钮.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void 刷新土地()
    {
        foreach (Transform item in 土地.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in PlayerData.S.灵植土地列表)
        {
            var 土地item = Instantiate(Resources.Load("Prefabs/Window/灵植园/土地item"),土地.transform).GetComponent<土地item>();
            土地item.index = item.Value.index;
            土地item.transform.localPosition = new Vector3(灵植园Config.植物位置Dic[item.Value.index].min,灵植园Config.植物位置Dic[item.Value.index].max,1);
            土地item.SetItem();
        }
    }

    private void OnEnable()
    {
        刷新土地();
    }
}
