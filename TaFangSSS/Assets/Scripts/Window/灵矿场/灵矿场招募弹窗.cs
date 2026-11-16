using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵矿场招募弹窗 : MonoBehaviour
{
    public Button exitButton;
    public Button maskButton;
    public TextMeshProUGUI 灵魂Count;
    public TextMeshProUGUI 矿工人数;
    public Image 自动招募普通;
    public Image 自动招募稀有;
    public Image 自动招募罕见;
    public Image 自动招募神话;
    public Image 自动招募永恒;
    
    public TextMeshProUGUI 刷新灵魂;
    public Button 刷新Button;
    public GameObject 阶数列表;
    public GameObject 矿工列表;
    [NonSerialized] public int 当前阶数 = 灵矿场Config.矿工阶数上限配置[PlayerData.S.矿洞矿工阶数等级].阶数;
    
}
