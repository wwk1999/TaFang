using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 新手引导对话 : MonoBehaviour
{
    public GameObject mask;
    public GameObject 仙子对话框;
    public GameObject 学生对话框;
    public GameObject 旁白对话框;
    public Button 点击Button;
    public TextMeshProUGUI 主角名;
    public TextMeshProUGUI 主角文本;
    public TextMeshProUGUI 仙子文本;
    public TextMeshProUGUI 旁白文本;
    private int index;
    public bool 主页;
    
    public void 剧情对话(object[] obj)
    {
        index = (int)obj[0];
        bool 在主页=(bool)obj[1];
        if (主页 != 在主页) return;
        对话 对话 = 新手引导剧情Config.对话[index-1];
        if (对话.index > 0)
        {
            mask.SetActive(true);
            点击Button.gameObject.SetActive(true);
            if (对话.人物Type == 人物Type.我)
            {
                仙子对话框.gameObject.SetActive(false);
                学生对话框.gameObject.SetActive(true);
                旁白对话框.gameObject.SetActive(false);

                主角名.text = PlayerData.S.Name;
                主角文本.text=新手引导剧情Config.对话[index-1].text;
            }
            else if(对话.人物Type == 人物Type.仙子)
            {
                仙子对话框.gameObject.SetActive(true);
                学生对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(false);
                仙子文本.text=新手引导剧情Config.对话[index-1].text;
            }
            else
            {
                仙子对话框.gameObject.SetActive(false);
                学生对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(true);
                旁白文本.text=新手引导剧情Config.对话[index-1].text;
            }
        }
    }

    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("剧情对话",剧情对话);
    }

    private void Start()
    {
        点击Button.onClick.AddListener(() =>
        {
            if (index > 0)
            {
                ObserverModuleManager.S.SendEvent("剧情对话",新手引导剧情Config.对话[index-1].next,主页);
            }else if (index == 0)
            {
                点击Button.gameObject.SetActive(false);
                mask.SetActive(false);
                仙子对话框.SetActive(false);
                学生对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(false);
            }else if (index == -1)
            {
                点击Button.gameObject.SetActive(false);
                mask.SetActive(false);
                仙子对话框.SetActive(false);
                学生对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(false);
                ObserverModuleManager.S.SendEvent("引导mask",引导maskType.英雄按钮);
            }else if (index == -2)
            {
                点击Button.gameObject.SetActive(false);
                mask.SetActive(false);
                仙子对话框.SetActive(false);
                学生对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(false);
                ObserverModuleManager.S.SendEvent("引导mask",引导maskType.英雄上阵);
            }
        });
    }
}
