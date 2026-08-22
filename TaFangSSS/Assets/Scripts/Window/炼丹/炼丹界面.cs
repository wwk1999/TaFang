using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 炼丹界面 : MonoBehaviour
{
    public Button exitbutton;
    private void Start()
    {
        exitbutton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
