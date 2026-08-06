using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    public Button TiaoZhanButton;
    public Button ExitButton;
    public GameObject MonsterContent;
    public GameObject DiaoLuoContent;
    public GameObject RightPanel;

    private void Start()
    {
        TiaoZhanButton.onClick.AddListener(() =>
        {
            
            SceneManager.LoadScene("LoadScene");
        });
        RightPanel.SetActive(false);
        ObserverModuleManager.S.RegisterEvent("LevelSamllButton",ShowLevel);
    }
    

    public void ShowLevel(object[] obj)
    {
        RightPanel.SetActive(true);
        主线关卡Type type = (主线关卡Type)obj[0];
        foreach (Transform item in MonsterContent.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in DiaoLuoContent.transform)
        {
            Destroy(item.gameObject);
        }
        var Monsters=LevelConfig.LevelMonsterDic[type];
        foreach (var item in Monsters)
        {
            var Monster=Instantiate(Resources.Load<GameObject>("Prefabs/Window/MonsterItem")).GetComponent<MonsterItem>();
            Monster.transform.SetParent(MonsterContent.transform);
            Monster.MonsterTypeName = item;
            Monster.SetItem();
        }
        var DiaoLuoList = LevelConfig.LevelDiaoLuoDic[type];
        foreach (var item in DiaoLuoList)
        {
            var Prop=Instantiate(Resources.Load<GameObject>("Prefabs/Window/DiaoLuoItem")).GetComponent<DiaoLuoItem>();
            Prop.transform.SetParent(DiaoLuoContent.transform);
            Prop.propType = item.PropType;
            Prop.SetItem();
        }
    }
}
