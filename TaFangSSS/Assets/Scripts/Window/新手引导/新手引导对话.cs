using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum 新手对话Type
{
    None,
    主界面,
    储物袋,
    灵矿场,
    领主府,
    英雄界面,
}
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
    
    public GameObject 低阶对话框;
    public TextMeshProUGUI 低阶主角名;
    public TextMeshProUGUI 低阶主角文本;
    
    public GameObject 中阶对话框;
    public TextMeshProUGUI 中阶主角名;
    public TextMeshProUGUI 中阶主角文本;
    
    public GameObject 高阶对话框;
    public TextMeshProUGUI 高阶主角名;
    public TextMeshProUGUI 高阶主角文本;
    
    public GameObject 道祖对话框;
    public TextMeshProUGUI 道祖主角名;
    public TextMeshProUGUI 道祖主角文本;
    private int index;
    public 新手对话Type 新手对话Type;
    
    public void 剧情对话(object[] obj)
    {
        index = (int)obj[0];
        新手对话Type 新手对话Type1=(新手对话Type)obj[1];
        if (新手对话Type != 新手对话Type1) return;
        对话 对话 = 新手引导剧情Config.对话Dic[index];
        if (对话.index > 0)
        {
            mask.SetActive(true);
            点击Button.gameObject.SetActive(true);
            if (对话.人物Type == 人物Type.我)
            {
                仙子对话框.gameObject.SetActive(false);
                学生对话框.gameObject.SetActive(true);
                旁白对话框.gameObject.SetActive(false);
                低阶对话框.gameObject.SetActive(false);
                中阶对话框.gameObject.SetActive(false);
                高阶对话框.gameObject.SetActive(false);
                道祖对话框.gameObject.SetActive(false);
                主角名.text = PlayerData.S.Name;
                主角文本.text=对话.text;
            }
            else if(对话.人物Type == 人物Type.仙子)
            {
                仙子对话框.gameObject.SetActive(true);
                学生对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(false);
                低阶对话框.gameObject.SetActive(false);
                中阶对话框.gameObject.SetActive(false);
                高阶对话框.gameObject.SetActive(false);
                道祖对话框.gameObject.SetActive(false);
                仙子文本.text=对话.text;
            }
            else if(对话.人物Type == 人物Type.旁白)
            {
                仙子对话框.gameObject.SetActive(false);
                学生对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(true);
                低阶对话框.gameObject.SetActive(false);
                中阶对话框.gameObject.SetActive(false);
                高阶对话框.gameObject.SetActive(false);
                道祖对话框.gameObject.SetActive(false);
                旁白文本.text=对话.text;
            }else if (对话.人物Type == 人物Type.低阶)
            {
                仙子对话框.gameObject.SetActive(false);
                学生对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(false);
                低阶对话框.gameObject.SetActive(true);
                中阶对话框.gameObject.SetActive(false);
                高阶对话框.gameObject.SetActive(false);
                道祖对话框.gameObject.SetActive(false);
                低阶主角名.text = PlayerData.S.Name;
                低阶主角文本.text=对话.text;
            }
            else if (对话.人物Type == 人物Type.中阶)
            {
                仙子对话框.gameObject.SetActive(false);
                学生对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(false);
                低阶对话框.gameObject.SetActive(false);
                中阶对话框.gameObject.SetActive(true);
                高阶对话框.gameObject.SetActive(false);
                道祖对话框.gameObject.SetActive(false);
                中阶主角名.text = PlayerData.S.Name;
                中阶主角文本.text=对话.text;
            }
            else if (对话.人物Type == 人物Type.高阶)
            {
                仙子对话框.gameObject.SetActive(false);
                学生对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(false);
                低阶对话框.gameObject.SetActive(false);
                中阶对话框.gameObject.SetActive(false);
                高阶对话框.gameObject.SetActive(true);
                道祖对话框.gameObject.SetActive(false);
                高阶主角名.text = PlayerData.S.Name;
                高阶主角文本.text=对话.text;
            }
            else if (对话.人物Type == 人物Type.道祖)
            {
                仙子对话框.gameObject.SetActive(false);
                学生对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(false);
                低阶对话框.gameObject.SetActive(false);
                中阶对话框.gameObject.SetActive(false);
                高阶对话框.gameObject.SetActive(false);
                道祖对话框.gameObject.SetActive(true);
                道祖主角名.text = PlayerData.S.Name;
                道祖主角文本.text=对话.text;
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
                ObserverModuleManager.S.SendEvent("剧情对话",新手引导剧情Config.对话Dic[index].next,新手对话Type);
            }else if (index == 0)
            {
                点击Button.gameObject.SetActive(false);
                mask.SetActive(false);
                仙子对话框.SetActive(false);
                学生对话框.gameObject.SetActive(false);
                低阶对话框.gameObject.SetActive(false);
                中阶对话框.gameObject.SetActive(false);
                高阶对话框.gameObject.SetActive(false);
                道祖对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(false);
            }else if (index == -1)
            {
                点击Button.gameObject.SetActive(false);
                mask.SetActive(false);
                仙子对话框.SetActive(false);
                学生对话框.gameObject.SetActive(false);
                低阶对话框.gameObject.SetActive(false);
                中阶对话框.gameObject.SetActive(false);
                高阶对话框.gameObject.SetActive(false);
                道祖对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(false);
                ObserverModuleManager.S.SendEvent("引导mask",引导maskType.英雄按钮);
            }else if (index == -2)
            {
                点击Button.gameObject.SetActive(false);
                mask.SetActive(false);
                仙子对话框.SetActive(false);
                学生对话框.gameObject.SetActive(false);
                低阶对话框.gameObject.SetActive(false);
                中阶对话框.gameObject.SetActive(false);
                高阶对话框.gameObject.SetActive(false);
                道祖对话框.gameObject.SetActive(false);
                旁白对话框.gameObject.SetActive(false);
                ObserverModuleManager.S.SendEvent("引导mask",引导maskType.英雄上阵);
            }
        });
    }
}
