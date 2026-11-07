using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 反馈窗口 : MonoBehaviour
{
    private const int 最大字数 = 1000;

    public Button maskButton;
    public Button 关闭Button;
    public Button 发送Button;
    public TMP_InputField 输入框;
    public TextMeshProUGUI 字数Text;

    private bool 发送中;

    private void Start()
    {
        if (maskButton != null)
        {
            maskButton.onClick.AddListener(关闭);
        }
        if (关闭Button != null)
        {
            关闭Button.onClick.AddListener(关闭);
        }
        if (发送Button != null)
        {
            发送Button.onClick.AddListener(发送);
        }
        if (输入框 != null)
        {
            输入框.characterLimit = 最大字数;
            输入框.onValueChanged.AddListener(delegate { 刷新字数(); });
        }
        刷新字数();
    }

    private void 关闭()
    {
        Destroy(gameObject);
    }

    private void 刷新字数()
    {
        if (字数Text != null && 输入框 != null)
        {
            字数Text.text = 输入框.text.Length + "/" + 最大字数;
        }
    }

    private void 发送()
    {
        if (发送中)
        {
            return;
        }

        if (!反馈发送器.已配置)
        {
            Toast("反馈通道暂未开放");
            return;
        }

        string 内容 = 输入框 == null ? "" : 输入框.text.Trim();
        if (string.IsNullOrEmpty(内容))
        {
            Toast("请输入反馈内容");
            return;
        }

        内容 = "道龄：" + PlayerData.S.道龄年 + "年\n" + 内容;

        发送中 = true;
        if (发送Button != null)
        {
            发送Button.interactable = false;
        }

        反馈发送器.S.发送(内容, 成功 =>
        {
            发送中 = false;
            if (成功)
            {
                Toast("反馈已发送，感谢你的反馈");
                关闭();
                return;
            }

            if (发送Button != null)
            {
                发送Button.interactable = true;
            }
            Toast("发送失败，请检查网络后重试");
        });
    }

    private void Toast(string 内容)
    {
        ObserverModuleManager.S.SendEvent("SendUIToast", 内容);
    }
}
