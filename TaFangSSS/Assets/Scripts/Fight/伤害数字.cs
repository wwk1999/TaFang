using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;

public class 伤害数字 : MonoBehaviour
{
    public Animator Animator;
    public TextMeshProUGUI 物理;
    public TextMeshProUGUI 冰;
    public TextMeshProUGUI 火焰;
    public TextMeshProUGUI 雷电;
    public TextMeshProUGUI 黑暗;
    public TextMeshProUGUI 回血;
    [NonSerialized] public YuanSuType YuanSuType=YuanSuType.None;
    [NonSerialized] public string text;
    [NonSerialized] public bool is回血;

    public void Hide()
    {
        QueueController.S.伤害数字Queue.Enqueue(this);
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        CancelInvoke();
        if (is回血)
        {
            Animator.Play("回血");
            回血.text = text.ToString();
        }
        else
        {
            switch (YuanSuType)
            {
                case YuanSuType.火:
                    Animator.Play("火伤害");
                    火焰.text = text.ToString();
                    break;
                case YuanSuType.冰:
                    Animator.Play("冰伤害");
                    冰.text = text.ToString();
                    break;
                case YuanSuType.电:
                    Animator.Play("雷电伤害");
                    雷电.text = text.ToString();
                    break;
                case YuanSuType.黑暗:
                    Animator.Play("黑暗伤害");
                    黑暗.text = text.ToString();
                    break;
                case YuanSuType.物理:
                    Animator.Play("物理伤害");
                    物理.text = text.ToString();
                    break;
            }
        }
        Invoke(nameof(Hide),0.5f);

    }
}
