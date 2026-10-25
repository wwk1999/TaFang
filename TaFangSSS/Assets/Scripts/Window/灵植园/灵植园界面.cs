using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 灵植园界面 : MonoBehaviour
{
    public Button 退出按钮;
    public Button 返回领地按钮;
    public GameObject 土地;
    public TextMeshProUGUI 青石;
    public Button 种植Button;
    public Button 施肥Button;
    public Button 背包Button;
    public Button 铲除Button;
    public Button 商店Button;
    public Button 一键收获Button;

    public 种植窗口 种植窗口;
    public 肥料窗口 肥料窗口;
    public 灵植商店窗口 灵植商店窗口;
    public 灵植背包窗口 灵植背包窗口;
    public 土地窗口 土地窗口;


    public void Set青石(object[] obj)
    {
        青石.text=PlayerData.S.格式化数字(PlayerData.S.青石).ToString();
    }
    

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("Set青石", Set青石);
        ObserverModuleManager.S.RegisterEvent("刷新灵植园", 灵植生长刷新);
        种植Button.onClick.AddListener(() =>
        {
            HeroWindowController.S.重置选择状态();
            种植窗口.gameObject.SetActive(true);
        });
        施肥Button.onClick.AddListener(() =>
        {
            HeroWindowController.S.重置选择状态();
            肥料窗口.gameObject.SetActive(true);
        });
        商店Button.onClick.AddListener(() =>
        {
            HeroWindowController.S.重置选择状态();
            灵植商店窗口.gameObject.SetActive(true);
        });
        背包Button.onClick.AddListener(() =>
        {
            HeroWindowController.S.重置选择状态();
            灵植背包窗口.gameObject.SetActive(true);
        });
        铲除Button.onClick.AddListener(() =>
        {
            HeroWindowController.S.重置选择状态();
            HeroWindowController.S.是否铲除 = true;
            HeroWindowController.设置光标(ResourcesConfig.铲除);
        });
        一键收获Button.onClick.AddListener(() =>
        {
            HeroWindowController.S.重置选择状态();

            bool 有收获 = false;
            foreach (Transform item in 土地.transform)
            {
                var 土地item = item.GetComponent<土地item>();
                if (土地item == null) continue;

                var 数据 = PlayerData.S.灵植土地列表[土地item.index];
                if (数据.灵植Type == 灵植Type.None) continue;
                if (数据.植物成长阶段Type != 植物成长阶段Type.成熟) continue;

                土地item.收获();
                有收获 = true;
            }

            if (!有收获)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast", "没有可收获的灵植");
                return;
            }

            ObserverModuleManager.S.SendEvent("Set青石");
        });
        退出按钮.onClick.AddListener(() =>
        {
            HeroWindowController.S.重置选择状态();
            gameObject.SetActive(false);
        });
        返回领地按钮.onClick.AddListener(() =>
        {
            HeroWindowController.S.重置选择状态();
            gameObject.SetActive(false);
        });
    }

    private readonly Dictionary<int, 土地item> 土地itemDic = new Dictionary<int, 土地item>();

    public void 刷新土地()
    {
        if (土地itemDic.Count != PlayerData.S.灵植土地列表.Count)
        {
            初始化土地();
            return;
        }

        foreach (var item in 土地itemDic)
        {
            // 正在播放收获动画的土地不刷新，避免动画被隐藏
            if (item.Value.收获动画.gameObject.activeSelf) continue;
            item.Value.SetItem();
        }
    }

    private void 初始化土地()
    {
        foreach (Transform item in 土地.transform)
        {
            Destroy(item.gameObject);
        }
        土地itemDic.Clear();

        foreach (var item in PlayerData.S.灵植土地列表)
        {
            var 土地item = Instantiate(Resources.Load("Prefabs/Window/灵植园/土地item"),土地.transform).GetComponent<土地item>();
            土地item.index = item.Value.index;
            土地item.transform.localPosition = new Vector3(灵植园Config.植物位置Dic[item.Value.index].min,灵植园Config.植物位置Dic[item.Value.index].max,1);
            土地itemDic[item.Value.index] = 土地item;
            土地item.SetItem();
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("Set青石", Set青石);
        ObserverModuleManager.S.UnRegisterEvent("刷新灵植园", 灵植生长刷新);
    }

    public void 灵植生长刷新(object[] obj)
    {
        刷新土地();
    }

    private void OnEnable()
    {
        灵植园Config.同步土地解锁();
        if (土地窗口 != null) 土地窗口.gameObject.SetActive(false);
        Set青石(null);
        刷新土地();
    }
}
