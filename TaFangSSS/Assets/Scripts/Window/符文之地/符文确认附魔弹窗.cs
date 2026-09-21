using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 符文确认附魔弹窗 : MonoBehaviour
{
    public 仙石确认镶嵌弹窗 仙石确认镶嵌弹窗;
    public Button 法器Button;
    public Button 仙石Button;
    public TextMeshProUGUI 法器白;
    public TextMeshProUGUI 法器黑;
    public TextMeshProUGUI 仙石白;
    public TextMeshProUGUI 仙石黑;
    public GameObject content;
    public TextMeshProUGUI 页数;
    public Button 左箭头;
    public Button 右箭头;
    public Image 艺术字;
    public Image Icon;
    public GameObject nameObj;
    public TextMeshProUGUI name;
    [NonSerialized]public int 页数num = 1;
    [NonSerialized]public bool 显示法器 = true;

    
    
    public void Show切换按钮()
    {
        if (显示法器)
        {
            法器Button.image.sprite = ResourcesConfig.按钮黑;
            法器Button.transform.localScale = Vector3.one;
            法器白.gameObject.SetActive(true);
            法器黑.gameObject.SetActive(false);
            法器白.transform.localScale = Vector3.one;
            仙石Button.image.sprite = ResourcesConfig.按钮白;
            仙石Button.transform.localScale = Vector3.one;
            仙石白.gameObject.SetActive(false);
            仙石黑.gameObject.SetActive(true);
            仙石黑.transform.localScale = Vector3.one;
        }
        else
        {
            法器Button.image.sprite = ResourcesConfig.按钮白;
            法器Button.transform.localScale = new Vector3(-1, 1, 1);
            法器白.gameObject.SetActive(false);
            法器黑.gameObject.SetActive(true);
            法器黑.transform.localScale = new Vector3(-1, 1, 1);
            仙石Button.image.sprite = ResourcesConfig.按钮黑;
            仙石Button.transform.localScale = new Vector3(-1, 1, 1);
            仙石白.gameObject.SetActive(true);
            仙石黑.gameObject.SetActive(false);
            仙石白.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    
    public void Show背包()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }
        页数.text=页数num.ToString();
        if (显示法器)
        {
            for (int i = 40*(页数num-1); i < Math.Min(页数num*40,PlayerData.S.法器列表.Count); i++)
            {
                var 法器item = Instantiate(Resources.Load("Prefabs/Window/符文之地/符文附魔法器item"), content.transform)
                    .GetComponent<符文附魔法器item>();
                法器item.法器 = PlayerData.S.法器列表[i];
                法器item.SetItem();
                if (HeroWindowController.S.当前符文附魔法器 != null && 法器item.法器 == HeroWindowController.S.当前符文附魔法器)
                {
                    法器item.gou.SetActive(true);
                }
                else
                {
                    法器item.gou.SetActive(false);
                }
            }
        }
        else
        {
            
        }
    }
}
