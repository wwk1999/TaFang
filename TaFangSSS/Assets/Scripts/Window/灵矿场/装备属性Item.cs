using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 装备信息弹窗中的单条属性行：名称 / 数值 / 无暇标记 / 进度条
public class 装备属性Item : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;
    public TextMeshProUGUI 无暇;
    public Image 进度条;
    public TextMeshProUGUI 进度百分比;


    public void SetItem(string 属性名, float 数值, bool 是否无暇, float 上限,QualityType  Quality)
    {
        name.text = 属性名;
        count.text = PlayerData.S.格式化数字(数值);
        无暇.gameObject.SetActive(是否无暇);
        无暇.colorGradientPreset = ResourcesConfig.Get品质TMP(Quality);
        进度条.fillAmount = 上限 <= 0f ? 0f : Mathf.Clamp01(数值 / 上限);
        float 比例 = 上限 <= 0f ? 0f : Mathf.Clamp01(数值 / 上限);
        进度百分比.text = (int)(比例 * 100f) + "%";
    }
}
