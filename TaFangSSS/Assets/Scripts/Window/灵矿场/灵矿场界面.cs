using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵矿场界面 : MonoBehaviour
{
    public Button exitButton;
    public Button 详情Button;
    public TextMeshProUGUI 灵石Count;

    public Image 背景;

    public Image 土层1;
    public Image 土层2;
    public Image 土层3;
    public Image 土层4;

    //开采信息
    public TextMeshProUGUI 当前层;
    public TextMeshProUGUI 当前米;
    public TextMeshProUGUI 下一层米数;
    public TextMeshProUGUI 当前灵矿;
    public TextMeshProUGUI 挖掘速度;
    public TextMeshProUGUI 灵石收益;

    //按钮
    public Button 招募Button;
    public Button 矿工Button;
    public Button 矿洞Button;
    public Button 背包Button;
    public Button 宝物Button;

    public Button 返回领地Button;
    
    //弹窗
    public GameObject 招募界面;
    public GameObject 矿工界面;
    public GameObject 矿洞界面;
    public GameObject 背包界面;
    public GameObject 宝物界面;

    
}
