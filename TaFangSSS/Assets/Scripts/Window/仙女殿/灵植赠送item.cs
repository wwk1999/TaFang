using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 灵植赠送item : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;

    [NonSerialized] public 灵植赠送窗口 窗口;
    [NonSerialized] public 灵植Type 灵植Tyep;
    [NonSerialized] public bool 是否变异;

    private const float 长按延迟 = 0.5f;
    private const float 连发间隔 = 0.06f;

    private bool 按住;
    private float 下次连发时间;

    public void SetItem()
    {
        if (灵植Tyep == 灵植Type.None) return;

        icon.sprite = 是否变异
            ? ResourcesConfig.Get灵植变异收获Sprite(灵植Tyep)
            : ResourcesConfig.Get灵植收获Sprite(灵植Tyep);
        name.text = (是否变异 ? "变异·" : "") + 灵植园Config.灵植名[灵植Tyep];
        count.text = PlayerData.S.格式化数字(Get数量());
    }

    public float Get数量()
    {
        return 是否变异
            ? PlayerData.S.变异收获Dic[灵植Tyep]
            : PlayerData.S.普通收获Dic[灵植Tyep];
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right || 窗口 == null) return;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            窗口.一键赠送(灵植Tyep, 是否变异);
            return;
        }

        窗口.单次赠送(灵植Tyep, 是否变异, this);
        按住 = true;
        下次连发时间 = Time.unscaledTime + 长按延迟;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        按住 = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        按住 = false;
    }

    private void Update()
    {
        if (!按住) return;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            按住 = false;
            return;
        }

        if (Time.unscaledTime < 下次连发时间) return;
        下次连发时间 = Time.unscaledTime + 连发间隔;
        窗口.单次赠送(灵植Tyep, 是否变异, this);
    }
}
