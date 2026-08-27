using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 首次进入界面 : MonoBehaviour
{
    public TextMeshProUGUI 介绍;
    public Button 继续Button;
    public GameObject 对话框;
    public Button 对话框mask;
    public TextMeshProUGUI 对话text;
    public GameObject 名称text;
    public TMP_InputField 输入;
    public Button 确认Button;
    private int count = 0;
    public Image bg;
    public bool 已经输入名称=false;
    private void Start()
    {
        介绍.DOFade(1f, 3f);
        bg.DOFade(1f, 3f);
        确认Button.onClick.AddListener(() =>
        {
            if (输入.text == "")
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","请输入昵称");
            }
            else
            {
                已经输入名称 = true;
                确认Button.gameObject.SetActive(false);
                名称text.gameObject.SetActive(false);
                输入.gameObject.SetActive(false);
                PlayerData.S.Name = 输入.text;
                对话text.text = $"{PlayerData.S.Name}道友,这就随我一起进入洪荒吧！";
            }
        });
        继续Button.onClick.AddListener(() =>
        {
            继续Button.gameObject.SetActive(false);
            介绍.DOFade(0f, 2f);
            bg.DOFade(0f, 2f);
            StartCoroutine(显示对话框());
        });
        对话框mask.onClick.AddListener(() =>
        {
            count++;
            if (count == 2)
            {
                 对话text.text = "接下来就让我来带道友来熟悉一下洪荒世界吧。";
            }
            if (count == 3)
            {
                对话text.text = "不知道友如何称呼?";
                确认Button.gameObject.SetActive(true);
                名称text.gameObject.SetActive(true);
                输入.gameObject.SetActive(true);
            }

            if (已经输入名称)
            {
                SceneManager.LoadScene("UIScene");
            }
        });
    }

    IEnumerator 显示对话框()
    {
        yield return new WaitForSeconds(2);
        count = 1;
        对话框.gameObject.SetActive(true);
        对话框mask.gameObject.SetActive(true);
        对话text.text = "道友你好，我是水灵儿，初入洪荒一定有很多困惑吧!";
    }
}
