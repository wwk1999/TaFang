using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 道场建筑交互 : MonoBehaviour
{
    public Button button;
    public GameObject 标签;
    public 建筑Type 建筑Type;

    public void 刷新建筑交互(object[] obj)
    {
        button.image.raycastTarget = PlayerData.S.历史最高境界 >= 道场Config.建筑解锁字典[建筑Type];
        标签.gameObject.SetActive(PlayerData.S.历史最高境界 >= 道场Config.建筑解锁字典[建筑Type]);
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新建筑交互",刷新建筑交互);
        button.image.raycastTarget = PlayerData.S.历史最高境界 >= 道场Config.建筑解锁字典[建筑Type];
        标签.gameObject.SetActive(PlayerData.S.历史最高境界 >= 道场Config.建筑解锁字典[建筑Type]);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新建筑交互",刷新建筑交互);
    }
}
