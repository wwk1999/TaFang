using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 显示攻击范围 : MonoBehaviour
{
    public GameObject 攻击范围;

    public void Show()
    {
        攻击范围.gameObject.SetActive(true);
    }

    public void Hide()
    {
        攻击范围.gameObject.SetActive(false);
    }
}
