using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 矿工背包弹窗 : MonoBehaviour
{
   public Button exitButton;
   public Button maskButton;
   public Image icon;
   public TextMeshProUGUI name;
   public TextMeshProUGUI 标签;
   public TextMeshProUGUI 描述;
   public TextMeshProUGUI 品质;
   public TextMeshProUGUI 数量;


   public Button 阶数筛选Button;
   public Button 品质筛选Button;
   public Button 排序Button;
   
   public Button 灵矿Button;
   public Button 装备Button;
   public Button 宝箱Button;
   public Button 宝物Button;

   public GameObject 背包;
   public Button 左箭头;
   public Button 右箭头;
   public TextMeshProUGUI num;
   
   public Button 分解Button;
   
   public Button 下拉区域mask;
   public GameObject 阶数下拉区域;
   public GameObject 品质下拉区域;
   public GameObject 排序下拉区域;
   public GameObject 阶数下拉区域Content;
   public GameObject 品质下拉区域Content;
   public Button 排序品质Button;
   public Button 排序阶数Button;
}
