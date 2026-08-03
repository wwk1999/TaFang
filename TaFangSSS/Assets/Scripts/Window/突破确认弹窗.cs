using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 突破确认弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Button 取消Button;
    public Button 确认Button;
    public TextMeshProUGUI text;
    [NonSerialized] public 突破Type 突破Type;

    private void OnEnable()
    {
        switch (突破Type)
        {
            case 突破Type.凡:
                text.text = "是否以凡品突破境界,突破后跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
                break;
            case 突破Type.灵:
                text.text = "是否以灵品突破境界,突破后跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
                break;
            case 突破Type.仙:
                text.text = "是否以仙品突破境界,突破后跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
                break;
            case 突破Type.圣:
                text.text = "是否以圣品突破境界,突破后跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
                break;
            case 突破Type.荒:
                text.text = "是否以荒品突破境界,突破后跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
                break;
        }
    }

    private void Awake()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        取消Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        确认Button.onClick.AddListener(() =>
        {
            int need = JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][(int)(突破Type-1)];
            PlayerData.S.PropListDic[PropType.功德] -= need;
            PlayerData.S.突破Dic[PlayerData.S.JingJieType] = 突破Type;
            PlayerData.S.JingJieType++;
            PlayerData.S.Exp = 0;
            ObserverModuleManager.S.SendEvent("突破成功");
            ObserverModuleManager.S.SendEvent("SendUIToast","突破成功");
            ObserverModuleManager.S.SendEvent("Hide突破弹窗");
        });
    }
}
