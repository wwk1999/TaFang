using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 后羿神通动画脚本 : MonoBehaviour
{
    public GameObject obj;

    public void Hide()
    {
        obj.SetActive(false);
    }
    public void 发射后羿神通()
    {
        ObserverModuleManager.S.SendEvent("发射后羿神通");
    }
}
