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
    [NonSerialized] public YuanSuType YuanSuType=YuanSuType.None;
    [NonSerialized] public float damage;

    public void Hide()
    {
        FightController.S.伤害数字Queue.Enqueue(this);
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        CancelInvoke();
        switch (YuanSuType)
        {
            case YuanSuType.火:
                Animator.Play("火伤害");
                火焰.text = damage.ToString();
                break;
            case YuanSuType.冰:
                Animator.Play("冰伤害");
                冰.text = damage.ToString();
                break;
            case YuanSuType.电:
                Animator.Play("雷电伤害");
                雷电.text = damage.ToString();
                break;
            case YuanSuType.黑暗:
                Animator.Play("黑暗伤害");
                黑暗.text = damage.ToString();
                break;
            case YuanSuType.物理:
                Animator.Play("物理伤害");
                物理.text = damage.ToString();
                break;
        }
        Invoke(nameof(Hide),0.3f);

    }
}
