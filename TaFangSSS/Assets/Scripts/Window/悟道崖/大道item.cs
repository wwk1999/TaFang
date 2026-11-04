using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class 大道item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("背景")]
    public GameObject bg暗;
    public GameObject bg亮;

    [Header("内容")]
    public Image icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI 等级Text;
    public Image 进度条;
    public TextMeshProUGUI 当前经验Text;
    public TextMeshProUGUI 最大经验Text;

    [Header("数据")]
    public 大道Type 大道Type = 大道Type.None;

    private void Start()
    {
        // 默认显示暗背景
        SetBgState(false);
    }

    /// <summary>
    /// 设置背景状态 true=亮 false=暗
    /// </summary>
    private void SetBgState(bool isHover)
    {
        if (bg暗 != null) bg暗.SetActive(!isHover);
        if (bg亮 != null) bg亮.SetActive(isHover);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetBgState(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetBgState(false);
    }

    /// <summary>
    /// 填充大道数据
    /// </summary>
    public void SetItem(大道Type type)
    {
        大道Type = type;
        if (type == 大道Type.None)
        {
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(true);

        大道配置 config = 悟道崖Config.大道配置[type];
        大道 data = PlayerData.S.大道配置[type];

        if (nameText != null) nameText.text = config.name;
        if (等级Text != null) 等级Text.text = "LV." + data.等级.ToString("F0");

        // 经验与进度条
        大道等级Type levelType = config.大道等级Type;
        if (悟道崖Config.大道经验.TryGetValue(levelType, out float 单级经验))
        {
            if (最大经验Text != null) 最大经验Text.text = 单级经验.ToString("F0");
            if (当前经验Text != null) 当前经验Text.text = Mathf.Min(data.经验, 单级经验).ToString("F0");
            if (进度条 != null) 进度条.fillAmount = Mathf.Clamp01(data.经验 / 单级经验);
        }
    }
}
