using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 人物属性弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Button ExitButton;
    public TextMeshProUGUI 攻击力;
    public TextMeshProUGUI 暴击率;
    public TextMeshProUGUI 暴击伤害;
    public TextMeshProUGUI 冷却缩减;
    public TextMeshProUGUI 战士;
    public TextMeshProUGUI 射手;
    public TextMeshProUGUI 法师;
    public TextMeshProUGUI 控制;
    public TextMeshProUGUI 物理;
    public TextMeshProUGUI 火焰;
    public TextMeshProUGUI 冰霜;
    public TextMeshProUGUI 雷电;
    public TextMeshProUGUI 黑暗;
    public TextMeshProUGUI 普通怪;
    public TextMeshProUGUI 精英怪;
    public TextMeshProUGUI 首领怪;
    public TextMeshProUGUI 无视抗性;
    public TextMeshProUGUI 最终伤害;
    public TextMeshProUGUI 伤害减免;
    public TextMeshProUGUI 灵气;
    public TextMeshProUGUI 功德;
    public TextMeshProUGUI 寻宝;

    private void OnEnable()
    {
        Show属性();
    }

    private void Awake()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        ExitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void Show属性()
    {
        var 属性 = 属性config.总属性;
        攻击力.text = PlayerData.S.格式化数字(属性.总攻击力);
        暴击率.text = Mathf.RoundToInt(属性.暴击率 * 100f) + "%";
        暴击伤害.text = Mathf.RoundToInt(属性config.Get英雄暴击伤害增幅() * 100f) + "%";
        冷却缩减.text = Mathf.RoundToInt(属性.英雄冷却缩减 * 100f) + "%";
        战士.text = Mathf.RoundToInt(属性.战士增幅 * 100f - 100) + "%";
        射手.text = Mathf.RoundToInt(属性.射手增幅 * 100f - 100) + "%";
        法师.text = Mathf.RoundToInt(属性.法师增幅 * 100f - 100) + "%";
        控制.text = Mathf.RoundToInt(属性.控制增幅 * 100f - 100) + "%";
        物理.text = Mathf.RoundToInt(属性.物理伤害增幅 * 100f - 100) + "%";
        火焰.text = Mathf.RoundToInt(属性.火焰伤害增幅 * 100f - 100) + "%";
        冰霜.text = Mathf.RoundToInt(属性.冰霜伤害增幅 * 100f - 100) + "%";
        雷电.text = Mathf.RoundToInt(属性.雷电伤害增幅 * 100f - 100) + "%";
        黑暗.text = Mathf.RoundToInt(属性.黑暗伤害增幅 * 100f - 100) + "%";
        普通怪.text = Mathf.RoundToInt(属性.普通怪伤害增幅 * 100f - 100) + "%";
        精英怪.text = Mathf.RoundToInt(属性.精英怪伤害增幅 * 100f - 100) + "%";
        首领怪.text = Mathf.RoundToInt(属性.首领伤害增幅 * 100f - 100) + "%";
        无视抗性.text = Mathf.RoundToInt(属性.无视抗性 * 100f) + "%";
        伤害减免.text = Mathf.RoundToInt(属性.伤害减免 * 100f) + "%";
        最终伤害.text = Mathf.RoundToInt(属性.最终伤害增幅 * 100f - 100) + "%";
        灵气.text=道宝Config.羁绊灵气+"%";
        功德.text=道宝Config.羁绊功德+"%";
        寻宝.text=道宝Config.羁绊寻宝速度+"%";
    }
}
