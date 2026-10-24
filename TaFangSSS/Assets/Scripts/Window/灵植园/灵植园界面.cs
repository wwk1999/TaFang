using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 灵植园界面 : MonoBehaviour
{
    public Button 退出按钮;
    public Button 返回领地按钮;
    public GameObject 土地;
    public TextMeshProUGUI 青石;
    public Button 种植Button;
    public Button 施肥Button;
    public Button 背包Button;
    public Button 铲除Button;
    public Button 商店Button;
    


    public void Set青石()
    {
        青石.text=PlayerData.S.格式化数字(PlayerData.S.青石).ToString();
    }
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
