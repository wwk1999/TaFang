using System;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 灵兽分解弹窗 : MonoBehaviour
{
    public Toggle 性别所有Toggle;
    public Toggle 性别公Toggle;
    public Toggle 性别母Toggle;

    public Toggle 元素所有Toggle;
    public Toggle 元素火Toggle;
    public Toggle 元素冰Toggle;
    public Toggle 元素电Toggle;
    public Toggle 元素物Toggle;
    public Toggle 元素暗Toggle;

    public Toggle 阶段所有Toggle;
    public Toggle 阶段1Toggle;
    public Toggle 阶段2Toggle;
    public Toggle 阶段3Toggle;
    public Toggle 阶段4Toggle;
    public Toggle 阶段5Toggle;
    public Toggle 阶段6Toggle;
    public Toggle 阶段7Toggle;
    public Toggle 阶段8Toggle;

    public Toggle 品级所有Toggle;
    public Toggle 品级1Toggle;
    public Toggle 品级2Toggle;
    public Toggle 品级3Toggle;
    public Toggle 品级4Toggle;
    public Toggle 品级5Toggle;
    public Toggle 品级6Toggle;
    public Toggle 品级7Toggle;
    public Toggle 品级8Toggle;

    public Toggle 血脉所有Toggle;
    public Toggle 血脉1Toggle;
    public Toggle 血脉2Toggle;
    public Toggle 血脉3Toggle;
    public Toggle 血脉4Toggle;
    public Toggle 血脉5Toggle;
    public Toggle 血脉6Toggle;
    public Toggle 血脉7Toggle;
    public Toggle 血脉8Toggle;

    public Button 分解Button;
    public Button maskButton;

    private void OnEnable()
    {
        同步Toggle();
    }

    private void Start()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        绑定(性别所有Toggle, value => PlayerData.S.灵兽分解性别所有 = value);
        绑定(性别公Toggle, value => PlayerData.S.灵兽分解性别公 = value);
        绑定(性别母Toggle, value => PlayerData.S.灵兽分解性别母 = value);

        绑定(元素所有Toggle, value => PlayerData.S.灵兽分解元素所有 = value);
        绑定(元素火Toggle, value => PlayerData.S.灵兽分解元素火 = value);
        绑定(元素冰Toggle, value => PlayerData.S.灵兽分解元素冰 = value);
        绑定(元素电Toggle, value => PlayerData.S.灵兽分解元素电 = value);
        绑定(元素物Toggle, value => PlayerData.S.灵兽分解元素物 = value);
        绑定(元素暗Toggle, value => PlayerData.S.灵兽分解元素暗 = value);

        绑定(阶段所有Toggle, value => PlayerData.S.灵兽分解阶段所有 = value);
        绑定(阶段1Toggle, value => PlayerData.S.灵兽分解阶段1 = value);
        绑定(阶段2Toggle, value => PlayerData.S.灵兽分解阶段2 = value);
        绑定(阶段3Toggle, value => PlayerData.S.灵兽分解阶段3 = value);
        绑定(阶段4Toggle, value => PlayerData.S.灵兽分解阶段4 = value);
        绑定(阶段5Toggle, value => PlayerData.S.灵兽分解阶段5 = value);
        绑定(阶段6Toggle, value => PlayerData.S.灵兽分解阶段6 = value);
        绑定(阶段7Toggle, value => PlayerData.S.灵兽分解阶段7 = value);
        绑定(阶段8Toggle, value => PlayerData.S.灵兽分解阶段8 = value);

        绑定(品级所有Toggle, value => PlayerData.S.灵兽分解品级所有 = value);
        绑定(品级1Toggle, value => PlayerData.S.灵兽分解品级1 = value);
        绑定(品级2Toggle, value => PlayerData.S.灵兽分解品级2 = value);
        绑定(品级3Toggle, value => PlayerData.S.灵兽分解品级3 = value);
        绑定(品级4Toggle, value => PlayerData.S.灵兽分解品级4 = value);
        绑定(品级5Toggle, value => PlayerData.S.灵兽分解品级5 = value);
        绑定(品级6Toggle, value => PlayerData.S.灵兽分解品级6 = value);
        绑定(品级7Toggle, value => PlayerData.S.灵兽分解品级7 = value);
        绑定(品级8Toggle, value => PlayerData.S.灵兽分解品级8 = value);

        绑定(血脉所有Toggle, value => PlayerData.S.灵兽分解血脉所有 = value);
        绑定(血脉1Toggle, value => PlayerData.S.灵兽分解血脉1 = value);
        绑定(血脉2Toggle, value => PlayerData.S.灵兽分解血脉2 = value);
        绑定(血脉3Toggle, value => PlayerData.S.灵兽分解血脉3 = value);
        绑定(血脉4Toggle, value => PlayerData.S.灵兽分解血脉4 = value);
        绑定(血脉5Toggle, value => PlayerData.S.灵兽分解血脉5 = value);
        绑定(血脉6Toggle, value => PlayerData.S.灵兽分解血脉6 = value);
        绑定(血脉7Toggle, value => PlayerData.S.灵兽分解血脉7 = value);
        绑定(血脉8Toggle, value => PlayerData.S.灵兽分解血脉8 = value);

        分解Button.onClick.AddListener(分解);
    }

    private void 绑定(Toggle toggle, Action<bool> 写入)
    {
        toggle.onValueChanged.AddListener(value => 写入(value));
    }

    // 打开时把存档里的勾选状态刷到界面
    private void 同步Toggle()
    {
        性别所有Toggle.isOn = PlayerData.S.灵兽分解性别所有;
        性别公Toggle.isOn = PlayerData.S.灵兽分解性别公;
        性别母Toggle.isOn = PlayerData.S.灵兽分解性别母;

        元素所有Toggle.isOn = PlayerData.S.灵兽分解元素所有;
        元素火Toggle.isOn = PlayerData.S.灵兽分解元素火;
        元素冰Toggle.isOn = PlayerData.S.灵兽分解元素冰;
        元素电Toggle.isOn = PlayerData.S.灵兽分解元素电;
        元素物Toggle.isOn = PlayerData.S.灵兽分解元素物;
        元素暗Toggle.isOn = PlayerData.S.灵兽分解元素暗;

        阶段所有Toggle.isOn = PlayerData.S.灵兽分解阶段所有;
        阶段1Toggle.isOn = PlayerData.S.灵兽分解阶段1;
        阶段2Toggle.isOn = PlayerData.S.灵兽分解阶段2;
        阶段3Toggle.isOn = PlayerData.S.灵兽分解阶段3;
        阶段4Toggle.isOn = PlayerData.S.灵兽分解阶段4;
        阶段5Toggle.isOn = PlayerData.S.灵兽分解阶段5;
        阶段6Toggle.isOn = PlayerData.S.灵兽分解阶段6;
        阶段7Toggle.isOn = PlayerData.S.灵兽分解阶段7;
        阶段8Toggle.isOn = PlayerData.S.灵兽分解阶段8;

        品级所有Toggle.isOn = PlayerData.S.灵兽分解品级所有;
        品级1Toggle.isOn = PlayerData.S.灵兽分解品级1;
        品级2Toggle.isOn = PlayerData.S.灵兽分解品级2;
        品级3Toggle.isOn = PlayerData.S.灵兽分解品级3;
        品级4Toggle.isOn = PlayerData.S.灵兽分解品级4;
        品级5Toggle.isOn = PlayerData.S.灵兽分解品级5;
        品级6Toggle.isOn = PlayerData.S.灵兽分解品级6;
        品级7Toggle.isOn = PlayerData.S.灵兽分解品级7;
        品级8Toggle.isOn = PlayerData.S.灵兽分解品级8;

        血脉所有Toggle.isOn = PlayerData.S.灵兽分解血脉所有;
        血脉1Toggle.isOn = PlayerData.S.灵兽分解血脉1;
        血脉2Toggle.isOn = PlayerData.S.灵兽分解血脉2;
        血脉3Toggle.isOn = PlayerData.S.灵兽分解血脉3;
        血脉4Toggle.isOn = PlayerData.S.灵兽分解血脉4;
        血脉5Toggle.isOn = PlayerData.S.灵兽分解血脉5;
        血脉6Toggle.isOn = PlayerData.S.灵兽分解血脉6;
        血脉7Toggle.isOn = PlayerData.S.灵兽分解血脉7;
        血脉8Toggle.isOn = PlayerData.S.灵兽分解血脉8;
    }

    private void 分解()
    {
        // 五个类别必须都勾选过：任一类别一个都没勾，就整体不分解
        if (!有勾选(性别所有Toggle, 性别公Toggle, 性别母Toggle)
            || !有勾选(元素所有Toggle, 元素火Toggle, 元素冰Toggle, 元素电Toggle, 元素物Toggle, 元素暗Toggle)
            || !有勾选(阶段所有Toggle, 阶段1Toggle, 阶段2Toggle, 阶段3Toggle, 阶段4Toggle, 阶段5Toggle, 阶段6Toggle, 阶段7Toggle, 阶段8Toggle)
            || !有勾选(品级所有Toggle, 品级1Toggle, 品级2Toggle, 品级3Toggle, 品级4Toggle, 品级5Toggle, 品级6Toggle, 品级7Toggle, 品级8Toggle)
            || !有勾选(血脉所有Toggle, 血脉1Toggle, 血脉2Toggle, 血脉3Toggle, 血脉4Toggle, 血脉5Toggle, 血脉6Toggle, 血脉7Toggle, 血脉8Toggle))
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "每个类别都需勾选才能分解");
            return;
        }

        // RemoveAll 单次遍历 O(n)，边判定边移除，避免逐个 RemoveAt 造成的 O(n²)
        PlayerData.S.灵兽列表.RemoveAll(灵兽 =>
        {
            if (!匹配(灵兽))
            {
                return false;
            }
            PlayerData.S.PropListDic[PropType.血晶] += 灵兽坊Config.灵兽分解[灵兽.QualityType];
            return true;
        });

        ObserverModuleManager.S.SendEvent("刷新灵兽背包");
        gameObject.SetActive(false);
    }

    private bool 有勾选(params Toggle[] toggles)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                return true;
            }
        }
        return false;
    }

    // 五个类别同时满足才算命中；某类别勾了「所有」则该类别全通过，否则只看细分类别
    private bool 匹配(灵兽 灵兽)
    {
        return 匹配性别(灵兽.性别)
            && 匹配元素(灵兽.元素Type)
            && 匹配阶段(灵兽.阶段Type)
            && 匹配品级(灵兽.QualityType)
            && 匹配血脉(灵兽.血脉Type);
    }

    private bool 匹配性别(性别 性别)
    {
        if (PlayerData.S.灵兽分解性别所有)
        {
            return true;
        }
        if (性别 == global::性别.公)
        {
            return PlayerData.S.灵兽分解性别公;
        }
        if (性别 == global::性别.母)
        {
            return PlayerData.S.灵兽分解性别母;
        }
        return false;
    }

    private bool 匹配元素(YuanSuType 元素)
    {
        if (PlayerData.S.灵兽分解元素所有)
        {
            return true;
        }
        switch (元素)
        {
            case YuanSuType.火: return PlayerData.S.灵兽分解元素火;
            case YuanSuType.冰: return PlayerData.S.灵兽分解元素冰;
            case YuanSuType.电: return PlayerData.S.灵兽分解元素电;
            case YuanSuType.物理: return PlayerData.S.灵兽分解元素物;
            case YuanSuType.黑暗: return PlayerData.S.灵兽分解元素暗;
        }
        return false;
    }

    private bool 匹配阶段(阶段Type 阶段)
    {
        if (PlayerData.S.灵兽分解阶段所有)
        {
            return true;
        }
        switch (阶段)
        {
            case 阶段Type.幼生期: return PlayerData.S.灵兽分解阶段1;
            case 阶段Type.成长期: return PlayerData.S.灵兽分解阶段2;
            case 阶段Type.完全体: return PlayerData.S.灵兽分解阶段3;
            case 阶段Type.脱变期: return PlayerData.S.灵兽分解阶段4;
            case 阶段Type.灵化期: return PlayerData.S.灵兽分解阶段5;
            case 阶段Type.归元体: return PlayerData.S.灵兽分解阶段6;
            case 阶段Type.通神体: return PlayerData.S.灵兽分解阶段7;
            case 阶段Type.本源体: return PlayerData.S.灵兽分解阶段8;
        }
        return false;
    }

    private bool 匹配品级(QualityType 品级)
    {
        if (PlayerData.S.灵兽分解品级所有)
        {
            return true;
        }
        switch (品级)
        {
            case QualityType.黄品: return PlayerData.S.灵兽分解品级1;
            case QualityType.玄品: return PlayerData.S.灵兽分解品级2;
            case QualityType.地品: return PlayerData.S.灵兽分解品级3;
            case QualityType.天品: return PlayerData.S.灵兽分解品级4;
            case QualityType.宇品: return PlayerData.S.灵兽分解品级5;
            case QualityType.宙品: return PlayerData.S.灵兽分解品级6;
            case QualityType.洪品: return PlayerData.S.灵兽分解品级7;
            case QualityType.荒品: return PlayerData.S.灵兽分解品级8;
        }
        return false;
    }

    private bool 匹配血脉(血脉Type 血脉)
    {
        if (PlayerData.S.灵兽分解血脉所有)
        {
            return true;
        }
        switch (血脉)
        {
            case 血脉Type.凡品: return PlayerData.S.灵兽分解血脉1;
            case 血脉Type.良品: return PlayerData.S.灵兽分解血脉2;
            case 血脉Type.上品: return PlayerData.S.灵兽分解血脉3;
            case 血脉Type.变异: return PlayerData.S.灵兽分解血脉4;
            case 血脉Type.卓越: return PlayerData.S.灵兽分解血脉5;
            case 血脉Type.完美: return PlayerData.S.灵兽分解血脉6;
            case 血脉Type.绝品: return PlayerData.S.灵兽分解血脉7;
            case 血脉Type.至尊: return PlayerData.S.灵兽分解血脉8;
        }
        return false;
    }
}
