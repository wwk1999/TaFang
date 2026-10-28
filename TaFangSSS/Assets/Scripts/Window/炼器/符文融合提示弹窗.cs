using UnityEngine;
using UnityEngine.UI;

public class 符文融合提示弹窗 : MonoBehaviour
{
    public Button 返回Button;
    public Button 确定Button;

    private void Start()
    {
        返回Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        确定Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("符文融合确定融合");
            gameObject.SetActive(false);
        });
    }
}
