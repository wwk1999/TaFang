using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 矿洞弹窗 : MonoBehaviour
{
    public TextMeshProUGUI 矿工人数上限等级;
    public TextMeshProUGUI 矿工人数上限当前;
    public TextMeshProUGUI 矿工人数上限升级后;
    public TextMeshProUGUI 矿工人数上限灵魂;
    public Button 矿工人数上限升级Button;

    public TextMeshProUGUI 矿工阶数上限等级;
    public TextMeshProUGUI 矿工阶数上限当前;
    public TextMeshProUGUI 矿工阶数上限升级后;
    public TextMeshProUGUI 矿工阶数上限灵魂;
    public Button 矿工阶数上限升级Button;
    
    public TextMeshProUGUI 宝物佩戴上限等级;
    public TextMeshProUGUI 宝物佩戴上限当前;
    public TextMeshProUGUI 宝物佩戴上限升级后;
    public TextMeshProUGUI 宝物佩戴上限灵魂;
    public Button 宝物佩戴上限升级Button;
    
    public TextMeshProUGUI 招募刷新概率等级;
    public TextMeshProUGUI 招募刷新概率当前普通概率;
    public TextMeshProUGUI 招募刷新概率当前稀有概率;
    public TextMeshProUGUI 招募刷新概率当前罕见概率;
    public TextMeshProUGUI 招募刷新概率当前神话概率;
    public TextMeshProUGUI 招募刷新概率当前永恒概率;
    public TextMeshProUGUI 招募刷新概率升级后普通概率;
    public TextMeshProUGUI 招募刷新概率升级后稀有概率;
    public TextMeshProUGUI 招募刷新概率升级后罕见概率;
    public TextMeshProUGUI 招募刷新概率升级后神话概率;
    public TextMeshProUGUI 招募刷新概率升级后永恒概率;
    public TextMeshProUGUI 招募刷新概率灵魂;
    public Button 招募刷新概率升级Button;
    
    
    public TextMeshProUGUI 宝箱品质概率等级;
    public TextMeshProUGUI 宝箱品质概率当前普通概率;
    public TextMeshProUGUI 宝箱品质概率当前卓越概率;
    public TextMeshProUGUI 宝箱品质概率当前至尊概率;
    public TextMeshProUGUI 宝箱品质概率升级后普通概率;
    public TextMeshProUGUI 宝箱品质概率升级后卓越概率;
    public TextMeshProUGUI 宝箱品质概率升级后至尊概率;
    public TextMeshProUGUI 宝箱品质概率灵魂;
    public Button 宝箱品质概率升级Button;
    
    public Button ExitButton;
    public Button maskButton;
    public TextMeshProUGUI 灵魂;

    private void OnEnable()
    {
        刷新界面();
    }

    private void Start()
    {
        矿工人数上限升级Button.onClick.AddListener(升级矿工人数上限);
        矿工阶数上限升级Button.onClick.AddListener(升级矿工阶数上限);
        宝物佩戴上限升级Button.onClick.AddListener(升级宝物佩戴上限);
        招募刷新概率升级Button.onClick.AddListener(升级招募刷新概率);
        宝箱品质概率升级Button.onClick.AddListener(升级宝箱品质概率);
        ExitButton.onClick.AddListener(关闭);
        maskButton.onClick.AddListener(关闭);
    }

    private void 关闭()
    {
        gameObject.SetActive(false);
    }

    public void 刷新界面()
    {
        刷新灵魂();
        刷新矿工人数上限();
        刷新矿工阶数上限();
        刷新宝物佩戴上限();
        刷新招募刷新概率();
        刷新宝箱品质概率();
    }

    private void 刷新灵魂()
    {
        灵魂.text = PlayerData.S.格式化数字(PlayerData.S.PropListDic[PropType.灵魂]);
    }

    private void 刷新矿工人数上限()
    {
        int 等级 = PlayerData.S.矿洞矿工人数等级;
        var 配置 = 灵矿场Config.矿工人数上限配置;
        bool 有下一级 = 配置.ContainsKey(等级 + 1);

        矿工人数上限等级.text = "等级 " + 等级;
        矿工人数上限当前.text = 配置[等级].人数 + "人";
        矿工人数上限升级后.text = 配置[有下一级 ? 等级 + 1 : 等级].人数 + "人";
        矿工人数上限灵魂.text = 有下一级 ? "灵魂" + PlayerData.S.格式化数字(配置[等级].升级灵魂) : "已满级";
        矿工人数上限升级Button.interactable = 有下一级;
    }

    private void 升级矿工人数上限()
    {
        int 等级 = PlayerData.S.矿洞矿工人数等级;
        var 配置 = 灵矿场Config.矿工人数上限配置;
        if (!配置.ContainsKey(等级 + 1))
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "已达到最高等级");
            return;
        }

        float 消耗 = 配置[等级].升级灵魂;
        if (!消耗灵魂(消耗)) return;

        PlayerData.S.矿洞矿工人数等级 = 等级 + 1;
        刷新界面();
    }

    private void 刷新矿工阶数上限()
    {
        int 等级 = PlayerData.S.矿洞矿工阶数等级;
        var 配置 = 灵矿场Config.矿工阶数上限配置;
        bool 有下一级 = 配置.ContainsKey(等级 + 1);

        矿工阶数上限等级.text = "等级 " + 等级;
        矿工阶数上限当前.text = 配置[等级].阶数 + "阶";
        矿工阶数上限升级后.text = 配置[有下一级 ? 等级 + 1 : 等级].阶数 + "阶";
        矿工阶数上限灵魂.text = 有下一级 ? "灵魂" + PlayerData.S.格式化数字(配置[等级].升级灵魂) : "已满级";
        矿工阶数上限升级Button.interactable = 有下一级;
    }

    private void 升级矿工阶数上限()
    {
        int 等级 = PlayerData.S.矿洞矿工阶数等级;
        var 配置 = 灵矿场Config.矿工阶数上限配置;
        if (!配置.ContainsKey(等级 + 1))
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "已达到最高等级");
            return;
        }

        float 消耗 = 配置[等级].升级灵魂;
        if (!消耗灵魂(消耗)) return;

        PlayerData.S.矿洞矿工阶数等级 = 等级 + 1;
        刷新界面();
    }

    private void 刷新宝物佩戴上限()
    {
        int 等级 = PlayerData.S.矿洞宝物佩戴上限;
        var 配置 = 灵矿场Config.宝物佩戴上限配置;
        bool 有下一级 = 配置.ContainsKey(等级 + 1);

        宝物佩戴上限等级.text = "等级 " + 等级;
        宝物佩戴上限当前.text = 配置[等级].个数 + "个";
        宝物佩戴上限升级后.text = 配置[有下一级 ? 等级 + 1 : 等级].个数 + "个";
        宝物佩戴上限灵魂.text = 有下一级 ? "灵魂" + PlayerData.S.格式化数字(配置[等级].升级灵魂) : "已满级";
        宝物佩戴上限升级Button.interactable = 有下一级;
    }

    private void 升级宝物佩戴上限()
    {
        int 等级 = PlayerData.S.矿洞宝物佩戴上限;
        var 配置 = 灵矿场Config.宝物佩戴上限配置;
        if (!配置.ContainsKey(等级 + 1))
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "已达到最高等级");
            return;
        }

        float 消耗 = 配置[等级].升级灵魂;
        if (!消耗灵魂(消耗)) return;

        PlayerData.S.矿洞宝物佩戴上限 = 等级 + 1;
        刷新界面();
    }

    private void 刷新招募刷新概率()
    {
        int 等级 = PlayerData.S.矿洞矿工招募概率等级;
        var 配置 = 灵矿场Config.矿工招募概率配置;
        bool 有下一级 = 配置.ContainsKey(等级 + 1);
        List<float> 当前概率 = 配置[等级].招募概率;
        List<float> 升级后概率 = 配置[有下一级 ? 等级 + 1 : 等级].招募概率;

        招募刷新概率等级.text = "等级 " + 等级;
        招募刷新概率当前普通概率.text = 概率文本(当前概率, 0);
        招募刷新概率当前稀有概率.text = 概率文本(当前概率, 1);
        招募刷新概率当前罕见概率.text = 概率文本(当前概率, 2);
        招募刷新概率当前神话概率.text = 概率文本(当前概率, 3);
        招募刷新概率当前永恒概率.text = 概率文本(当前概率, 4);
        招募刷新概率升级后普通概率.text = 概率文本(升级后概率, 0);
        招募刷新概率升级后稀有概率.text = 概率文本(升级后概率, 1);
        招募刷新概率升级后罕见概率.text = 概率文本(升级后概率, 2);
        招募刷新概率升级后神话概率.text = 概率文本(升级后概率, 3);
        招募刷新概率升级后永恒概率.text = 概率文本(升级后概率, 4);
        招募刷新概率灵魂.text = 有下一级 ? "灵魂" + PlayerData.S.格式化数字(配置[等级].升级灵魂) : "已满级";
        招募刷新概率升级Button.interactable = 有下一级;
    }

    private void 升级招募刷新概率()
    {
        int 等级 = PlayerData.S.矿洞矿工招募概率等级;
        var 配置 = 灵矿场Config.矿工招募概率配置;
        if (!配置.ContainsKey(等级 + 1))
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "已达到最高等级");
            return;
        }

        float 消耗 = 配置[等级].升级灵魂;
        if (!消耗灵魂(消耗)) return;

        PlayerData.S.矿洞矿工招募概率等级 = 等级 + 1;
        刷新界面();
    }

    private void 刷新宝箱品质概率()
    {
        int 等级 = PlayerData.S.矿洞宝箱品质概率等级;
        var 配置 = 灵矿场Config.宝箱品质概率配置;
        bool 有下一级 = 配置.ContainsKey(等级 + 1);
        List<float> 当前概率 = 配置[等级].宝箱概率;
        List<float> 升级后概率 = 配置[有下一级 ? 等级 + 1 : 等级].宝箱概率;

        宝箱品质概率等级.text = "等级 " + 等级;
        宝箱品质概率当前普通概率.text = 概率文本(当前概率, 0);
        宝箱品质概率当前卓越概率.text = 概率文本(当前概率, 1);
        宝箱品质概率当前至尊概率.text = 概率文本(当前概率, 2);
        宝箱品质概率升级后普通概率.text = 概率文本(升级后概率, 0);
        宝箱品质概率升级后卓越概率.text = 概率文本(升级后概率, 1);
        宝箱品质概率升级后至尊概率.text = 概率文本(升级后概率, 2);
        宝箱品质概率灵魂.text = 有下一级 ? "灵魂" + PlayerData.S.格式化数字(配置[等级].升级灵魂) : "已满级";
        宝箱品质概率升级Button.interactable = 有下一级;
    }

    private void 升级宝箱品质概率()
    {
        int 等级 = PlayerData.S.矿洞宝箱品质概率等级;
        var 配置 = 灵矿场Config.宝箱品质概率配置;
        if (!配置.ContainsKey(等级 + 1))
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "已达到最高等级");
            return;
        }

        float 消耗 = 配置[等级].升级灵魂;
        if (!消耗灵魂(消耗)) return;

        PlayerData.S.矿洞宝箱品质概率等级 = 等级 + 1;
        刷新界面();
    }

    private static string 概率文本(List<float> 概率列表, int index)
    {
        if (概率列表 == null || index >= 概率列表.Count) return "0%";
        return 概率列表[index].ToString("F0") + "%";
    }

    private static bool 消耗灵魂(float 消耗)
    {
        if (PlayerData.S.PropListDic[PropType.灵魂] < 消耗)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "灵魂不足");
            return false;
        }

        PlayerData.S.PropListDic[PropType.灵魂] -= 消耗;
        return true;
    }
}
