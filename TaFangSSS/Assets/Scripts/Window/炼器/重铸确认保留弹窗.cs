using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 重铸确认保留弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Button 返回Button;
    public Button 确认Button;

    private void Start()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        返回Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        确认Button.onClick.AddListener(() =>
            {
                HeroWindowController.S.重铸panel当前仙石.list.Clear();
                HeroWindowController.S.重铸panel当前仙石.list = HeroWindowController.S.仙石重铸后词条;
                HeroWindowController.S.仙石重铸后词条 = null;
                HeroWindowController.S.重铸panel当前仙石.type = HeroWindowController.S.重铸后仙石Type;
                HeroWindowController.S.重铸后仙石Type = 仙石Type.None;
                ObserverModuleManager.S.SendEvent("刷新重铸Panel");
                gameObject.SetActive(false);
            }
        );
    }
}
