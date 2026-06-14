using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 招募成功弹窗 : MonoBehaviour
{
    [NonSerialized]public bool Is10 = false;
    [NonSerialized]public bool IsGaoJi = false;
    [NonSerialized]public PropType Item1Type;
    [NonSerialized]public Dictionary<int,PropType>list = new Dictionary<int,PropType>();
    public GameObject Content;
    public 招募成功item item;
    public Button maskbutton;
    public Button ZhaoMu1Button;
    public Button ZhaoMu10Button;

    private void Start()
    {
        maskbutton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        ZhaoMu1Button.onClick.AddListener(() =>
        {
            if (IsGaoJi)
            {
                Item1Type = ZhaoMuConfig.GaoJiZhaoMu();
            }
            else
            {
                Item1Type = ZhaoMuConfig.NormalZhaoMu();
            }

            招募一次();
        });
        
        ZhaoMu10Button.onClick.AddListener(() =>
        {
            list.Clear();
            for (int i = 0; i < 10; i++)
            {
                if (IsGaoJi)
                {
                    list[i]=ZhaoMuConfig.GaoJiZhaoMu();
                }
                else
                {
                    list[i]=ZhaoMuConfig.NormalZhaoMu();
                }
            }
            StopAllCoroutines();
            StartCoroutine(招募十次());
        });
    }

    public void 招募一次()
    {
        ZhaoMu1Button.GetComponent<RectTransform>().localPosition = new Vector2(-158f, -283f);
        ZhaoMu10Button.GetComponent<RectTransform>().localPosition = new Vector2(166f, -283f);            
        Content.SetActive(false);
        item.propType=Item1Type;
        item.SetItem();
        item.gameObject.SetActive(true);
        PlayerData.S.HeroDataDic[PropConfig.PropToHeroDic[Item1Type]].元神++;
    }

    public IEnumerator 招募十次()
    {
        ZhaoMu1Button.GetComponent<RectTransform>().localPosition = new Vector2(-158f, -338f);
        ZhaoMu10Button.GetComponent<RectTransform>().localPosition = new Vector2(166f, -338f);

        Content.SetActive(true);
        item.gameObject.SetActive(false);
        foreach (Transform item  in Content.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 0; i < 10; i++)
        {
            PlayerData.S.HeroDataDic[PropConfig.PropToHeroDic[list[i]]].元神++;
        }

        for (int i=0;i<10;i++)
        {
            招募成功item ZhaoMuitem = Instantiate(Resources.Load("Prefabs/Window/招募成功item"), Content.transform).GetComponent<招募成功item>();
            ZhaoMuitem.propType = list[i];
            ZhaoMuitem.SetItem();
            yield return new  WaitForSeconds(0.1f);
        }
    }
    private void OnEnable()
    {
        if (!Is10)
        {
            招募一次();
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(招募十次());
        }
    }
}
