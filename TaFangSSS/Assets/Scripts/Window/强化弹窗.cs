using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 强化弹窗 : MonoBehaviour
{
   public Button 概率Button;
   public 洗练概率弹窗 概率弹窗;
   public Button ExitButton;
   public TextMeshProUGUI EquipName;
   public Image image;
   public Button 强化Button;
   public Button 洗练Button;
   public TextMeshProUGUI 强化TextMeshProUGUI;
   public TextMeshProUGUI 洗练TextMeshProUGUI;
   public TextMeshProUGUI levelText;
   public TextMeshProUGUI 当前等级;
   public TextMeshProUGUI 强化后等级;
   public TextMeshProUGUI 当前攻击力;
   public TextMeshProUGUI 强化后攻击力;
   public TextMeshProUGUI 当前数量;
   public TextMeshProUGUI 强化需要数量;
   public Image 材料bg;
   public Image 材料image;
   public TextMeshProUGUI 材料Name;
   public TextMeshProUGUI 需要灵魂Count;
   public TextMeshProUGUI 所有灵魂Count;
   public Button 材料强化Button;
   public Button 材料洗练Button;
  
   public 附加属性item 绿附加属性;
   public 附加属性item 蓝附加属性;
   public 附加属性item 紫附加属性;
   public 附加属性item 橙附加属性;
   public 附加属性item 粉附加属性;
   public 附加属性item 红附加属性;
   public 附加属性item 彩附加属性;

   public 强化装备item 衣服;
   public 强化装备item 头盔;
   public 强化装备item 护手;
   public 强化装备item 鞋子;
   public 强化装备item 戒指;
   public 强化装备item 项链;
   
   [NonSerialized] public bool IsQiangHua=true;
   [NonSerialized] public EquipType equipType=EquipType.衣服;
   public void 洗练()
   {
      int level=PlayerData.S.EquipLevelDic[equipType];
      var item = EquipConfig.洗练材料Dic[EquipConfig.GetEquipQuality(level)];
      int cailiao = item.材料数量;
      int lingqi = item.灵气数量;
      if (PlayerData.S.PropListDic[PropType.灵魂] < lingqi)
      {
         ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

         ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
         return;
      }
      if (PlayerData.S.PropListDic[PropType.洗练石] < cailiao)
      {
         ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

         ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
         return;
      }

      PlayerData.S.PropListDic[PropType.灵魂] -= lingqi;
      PlayerData.S.PropListDic[PropType.洗练石] -= cailiao;
      foreach (var item1 in PlayerData.S.装备附加属性Dic[equipType])
      {
         if (!item1.IsSuo)
         {
            词条Item citiao = EquipConfig.Get词条(EquipConfig.GetEquipQuality(equipType));
            {
               item1.QualityType = citiao.QualityType;
               item1.附加属性Type = citiao.附加属性Type;
            }
         }
      }
      ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);

      ObserverModuleManager.S.SendEvent("SendUIToast","洗练成功");
      Set属性Panel();
      Set材料();
   }
   public void 强化()
   {
      int level=PlayerData.S.EquipLevelDic[equipType];
      var item = EquipConfig.强化材料Dic[EquipConfig.GetEquipQuality(level)];
      int cailiao = item.材料数量;
      int lingqi = item.灵气数量;
      if (PlayerData.S.PropListDic[PropType.灵魂] < lingqi)
      {
         ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

         ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
         return;
      }

      switch (equipType)
      {
         case EquipType.头盔:
            if (PlayerData.S.PropListDic[PropType.头盔锻造石] < cailiao)
            {
               ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

               ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
               return;
            }
            break;
         case EquipType.鞋子:
            if (PlayerData.S.PropListDic[PropType.鞋子锻造石] < cailiao)
            {
               ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

               ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
               return;
            }
            break;
         case EquipType.护手:
            if (PlayerData.S.PropListDic[PropType.护手锻造石] < cailiao)
            {
               ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

               ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
               return;
            }
            break;
         case EquipType.衣服:
            if (PlayerData.S.PropListDic[PropType.衣服锻造石] < cailiao)
            {
               ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

               ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
               return;
            }
            break;
         case EquipType.项链:
            if (PlayerData.S.PropListDic[PropType.项链锻造石] < cailiao)
            {
               ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

               ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
               return;
            }
            break;
         case EquipType.戒指:
            if (PlayerData.S.PropListDic[PropType.戒指锻造石] < cailiao)
            {
               ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

               ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
               return;
            }
            break;
      }

      PlayerData.S.PropListDic[PropType.灵魂] -= lingqi;
      switch (equipType)
      {
         case EquipType.头盔:
            PlayerData.S.PropListDic[PropType.头盔锻造石] -= cailiao;
            break;
         case EquipType.戒指:
            PlayerData.S.PropListDic[PropType.戒指锻造石] -= cailiao;
            break;
         case EquipType.项链:
            PlayerData.S.PropListDic[PropType.项链锻造石] -= cailiao;
            break;
         case EquipType.护手:
            PlayerData.S.PropListDic[PropType.护手锻造石] -= cailiao;
            break;
         case EquipType.衣服:
            PlayerData.S.PropListDic[PropType.衣服锻造石] -= cailiao;
            break;
         case EquipType.鞋子:
            PlayerData.S.PropListDic[PropType.鞋子锻造石] -= cailiao;
            break;
      }

      PlayerData.S.EquipLevelDic[equipType]++;
      ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);

      ObserverModuleManager.S.SendEvent("SendUIToast","强化成功");

      if (PlayerData.S.EquipLevelDic[equipType] == 11)
      {
         词条Item item1 = EquipConfig.Get词条(QualityType.玄品);
         PlayerData.S.装备附加属性Dic[equipType][0].QualityType = item1.QualityType;
         PlayerData.S.装备附加属性Dic[equipType][0].附加属性Type = item1.附加属性Type;
         ObserverModuleManager.S.SendEvent("刷新装备");
      }
      if (PlayerData.S.EquipLevelDic[equipType] == 21)
      {
         词条Item item1 = EquipConfig.Get词条(QualityType.地品);
         PlayerData.S.装备附加属性Dic[equipType][1].QualityType = item1.QualityType;
         PlayerData.S.装备附加属性Dic[equipType][1].附加属性Type = item1.附加属性Type;
         ObserverModuleManager.S.SendEvent("刷新装备");

      }
      if (PlayerData.S.EquipLevelDic[equipType] == 31)
      {
         词条Item item1 = EquipConfig.Get词条(QualityType.天品);
         PlayerData.S.装备附加属性Dic[equipType][2].QualityType = item1.QualityType;
         PlayerData.S.装备附加属性Dic[equipType][2].附加属性Type = item1.附加属性Type;
         ObserverModuleManager.S.SendEvent("刷新装备");

      }
      if (PlayerData.S.EquipLevelDic[equipType] == 41)
      {
         词条Item item1 = EquipConfig.Get词条(QualityType.宇品);
         PlayerData.S.装备附加属性Dic[equipType][3].QualityType = item1.QualityType;
         PlayerData.S.装备附加属性Dic[equipType][3].附加属性Type = item1.附加属性Type;
         ObserverModuleManager.S.SendEvent("刷新装备");

      }
      if (PlayerData.S.EquipLevelDic[equipType] == 51)
      {
         词条Item item1 = EquipConfig.Get词条(QualityType.宙品);
         PlayerData.S.装备附加属性Dic[equipType][4].QualityType = item1.QualityType;
         PlayerData.S.装备附加属性Dic[equipType][4].附加属性Type = item1.附加属性Type;
         ObserverModuleManager.S.SendEvent("刷新装备");

      }
      if (PlayerData.S.EquipLevelDic[equipType] == 61)
      {
         词条Item item1 = EquipConfig.Get词条(QualityType.洪品);
         PlayerData.S.装备附加属性Dic[equipType][5].QualityType = item1.QualityType;
         PlayerData.S.装备附加属性Dic[equipType][5].附加属性Type = item1.附加属性Type;
         ObserverModuleManager.S.SendEvent("刷新装备");

      }
      if (PlayerData.S.EquipLevelDic[equipType] == 71)
      {
         词条Item item1 = EquipConfig.Get词条(QualityType.荒品);
         PlayerData.S.装备附加属性Dic[equipType][6].QualityType = item1.QualityType;
         PlayerData.S.装备附加属性Dic[equipType][6].附加属性Type = item1.附加属性Type;
         ObserverModuleManager.S.SendEvent("刷新装备");

      }
      
      Set装备();
      Set强化Info();
      Set属性Panel();
      Set材料();
   }
   public void 强化装备Item点击(object[] obj)
   {
      EquipType type=(EquipType)obj[0];
      equipType = type;
      Set装备();
      Set强化Info();
      Set属性Panel();
      Set材料();
   }
   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("强化装备Item点击",强化装备Item点击);
      ObserverModuleManager.S.SendEvent("强化弹窗装备点击",equipType);
      概率Button.onClick.AddListener(() =>
      {
         概率弹窗.EquipQualityType = EquipConfig.GetEquipQuality(PlayerData.S.EquipLevelDic[equipType]);
         if (概率弹窗.EquipQualityType < QualityType.玄品)
         {
            概率弹窗.EquipQualityType = QualityType.玄品;
         }
         概率弹窗.gameObject.SetActive(true);
      });
      强化Button.onClick.AddListener(() =>
      {
         IsQiangHua=true;
         Set强化Info();
         Set属性Panel();
         Set材料();
      });
      洗练Button.onClick.AddListener(() =>
      {
         IsQiangHua=false;
         Set强化Info();
         Set属性Panel();
         Set材料();
      });
      ExitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      材料强化Button.onClick.AddListener(() =>
         {
            强化();
         });
      材料洗练Button.onClick.AddListener(() =>
      {
         洗练();
      });
   }

   public void Set材料()
   {
      if (IsQiangHua)
      {
         概率Button.gameObject.SetActive(false);
         材料强化Button.gameObject.SetActive(true);
         材料洗练Button.gameObject.SetActive(false);
         材料bg.sprite = ResourcesConfig.道具背景框蓝;
         所有灵魂Count.text=PlayerData.S.PropListDic[PropType.灵魂].ToString();
         switch (equipType)
         {
            case EquipType.头盔:
               材料image.sprite = ResourcesConfig.头盔锻造石;
               材料Name.text = PropConfig.PropNameDic[PropType.头盔锻造石];
               当前数量.text = PlayerData.S.PropListDic[PropType.头盔锻造石].ToString();
               强化需要数量.text = EquipConfig.强化材料Dic[EquipConfig.GetEquipQuality(EquipType.头盔)].材料数量.ToString();
               需要灵魂Count.text=EquipConfig.强化材料Dic[EquipConfig.GetEquipQuality(EquipType.头盔)].灵气数量.ToString();
               break;
            case EquipType.鞋子:
               材料image.sprite = ResourcesConfig.鞋子锻造石;
               材料Name.text = PropConfig.PropNameDic[PropType.鞋子锻造石];
               当前数量.text = PlayerData.S.PropListDic[PropType.鞋子锻造石].ToString();
               强化需要数量.text = EquipConfig.强化材料Dic[EquipConfig.GetEquipQuality(EquipType.鞋子)].材料数量.ToString();
               需要灵魂Count.text=EquipConfig.强化材料Dic[EquipConfig.GetEquipQuality(EquipType.鞋子)].灵气数量.ToString();
               break;
            case EquipType.护手:
               材料image.sprite = ResourcesConfig.护手锻造石;
               材料Name.text = PropConfig.PropNameDic[PropType.护手锻造石];
               当前数量.text = PlayerData.S.PropListDic[PropType.护手锻造石].ToString();
               强化需要数量.text = EquipConfig.强化材料Dic[EquipConfig.GetEquipQuality(EquipType.护手)].材料数量.ToString();
               需要灵魂Count.text=EquipConfig.强化材料Dic[EquipConfig.GetEquipQuality(EquipType.护手)].灵气数量.ToString();
               break;
            case EquipType.衣服:
               材料image.sprite = ResourcesConfig.衣服锻造石;
               材料Name.text = PropConfig.PropNameDic[PropType.衣服锻造石];
               当前数量.text = PlayerData.S.PropListDic[PropType.衣服锻造石].ToString();
               强化需要数量.text = EquipConfig.强化材料Dic[EquipConfig.GetEquipQuality(EquipType.衣服)].材料数量.ToString();
               需要灵魂Count.text=EquipConfig.强化材料Dic[EquipConfig.GetEquipQuality(EquipType.衣服)].灵气数量.ToString();
               break;
            case EquipType.戒指:
               材料image.sprite = ResourcesConfig.戒指锻造石;
               材料Name.text = PropConfig.PropNameDic[PropType.戒指锻造石];
               当前数量.text = PlayerData.S.PropListDic[PropType.戒指锻造石].ToString();
               强化需要数量.text = EquipConfig.强化材料Dic[EquipConfig.GetEquipQuality(EquipType.戒指)].材料数量.ToString();
               需要灵魂Count.text=EquipConfig.强化材料Dic[EquipConfig.GetEquipQuality(EquipType.戒指)].灵气数量.ToString();
               break;
            case EquipType.项链:
               材料image.sprite = ResourcesConfig.项链锻造石;
               材料Name.text = PropConfig.PropNameDic[PropType.项链锻造石];
               当前数量.text = PlayerData.S.PropListDic[PropType.项链锻造石].ToString();
               强化需要数量.text = EquipConfig.强化材料Dic[EquipConfig.GetEquipQuality(EquipType.项链)].材料数量.ToString();
               需要灵魂Count.text=EquipConfig.强化材料Dic[EquipConfig.GetEquipQuality(EquipType.项链)].灵气数量.ToString();
               break;
         }
      }
      else
      {
         概率Button.gameObject.SetActive(true);
         材料Name.text = PropConfig.PropNameDic[PropType.洗练石];
         材料强化Button.gameObject.SetActive(false);
         材料洗练Button.gameObject.SetActive(true);
         材料bg.sprite = ResourcesConfig.道具背景框橙;
         材料image.sprite = ResourcesConfig.洗练石;
         当前数量.text = PlayerData.S.PropListDic[PropType.洗练石].ToString();
         强化需要数量.text = EquipConfig.洗练材料Dic[EquipConfig.GetEquipQuality(equipType)].材料数量.ToString();
         需要灵魂Count.text=EquipConfig.洗练材料Dic[EquipConfig.GetEquipQuality(equipType)].灵气数量.ToString();
      }
   }

   public void Set装备()
   {
      衣服.equipType = EquipType.衣服;
      衣服.clickType = equipType;
      衣服.SetItem();
      头盔.clickType = equipType;
      头盔.equipType = EquipType.头盔;
      头盔.SetItem();
      护手.clickType = equipType;
      护手.equipType = EquipType.护手;
      护手.SetItem();
      鞋子.clickType = equipType;
      鞋子.equipType = EquipType.鞋子;
      鞋子.SetItem();
      项链.clickType = equipType;
      项链.equipType = EquipType.项链;
      项链.SetItem();
      戒指.clickType = equipType;
      戒指.equipType = EquipType.戒指;
      戒指.SetItem();
   }
   public void Set属性Panel()
   {
      当前等级.text = "+" + PlayerData.S.EquipLevelDic[equipType];
      强化后等级.text = "+" + (PlayerData.S.EquipLevelDic[equipType]+1);
      当前攻击力.text = "攻击力+" + EquipConfig.装备基础攻击Dic[PlayerData.S.EquipLevelDic[equipType]];
      强化后攻击力.text = "攻击力+" + EquipConfig.装备基础攻击Dic[PlayerData.S.EquipLevelDic[equipType]+1];
      绿附加属性.JieSuoQualityType = QualityType.玄品;
      绿附加属性.EquipType = equipType;
      绿附加属性.IsQiangHua = IsQiangHua;
      绿附加属性.SetItem();
      蓝附加属性.JieSuoQualityType = QualityType.地品;
      蓝附加属性.EquipType = equipType;
      蓝附加属性.IsQiangHua = IsQiangHua;
      蓝附加属性.SetItem();
      紫附加属性.JieSuoQualityType = QualityType.天品;
      紫附加属性.EquipType = equipType;
      紫附加属性.IsQiangHua = IsQiangHua;
      紫附加属性.SetItem();
      橙附加属性.JieSuoQualityType = QualityType.宇品;
      橙附加属性.EquipType = equipType;
      橙附加属性.IsQiangHua = IsQiangHua;
      橙附加属性.SetItem();
      粉附加属性.JieSuoQualityType = QualityType.宙品;
      粉附加属性.EquipType = equipType;
      粉附加属性.IsQiangHua = IsQiangHua;
      粉附加属性.SetItem();
      红附加属性.JieSuoQualityType = QualityType.洪品;
      红附加属性.EquipType = equipType;
      红附加属性.IsQiangHua = IsQiangHua;
      红附加属性.SetItem();
      彩附加属性.JieSuoQualityType = QualityType.荒品;
      彩附加属性.EquipType = equipType;
      彩附加属性.IsQiangHua = IsQiangHua;
      彩附加属性.SetItem();
   }
   public void Set强化Info()
   {
      EquipName.text=EquipConfig.EquipNameDic[equipType][(int)(EquipConfig.GetEquipQuality(equipType)-1)];
      image.sprite=ResourcesConfig.GetEquipSprite(equipType, EquipConfig.GetEquipQuality(equipType));
      levelText.text=PlayerData.S.EquipLevelDic[equipType].ToString();
      if (IsQiangHua)
      {
         强化Button.image.sprite = ResourcesConfig.强化窗口按钮亮;
         强化TextMeshProUGUI.colorGradientPreset = ResourcesConfig.高级招募TMP;
         洗练Button.image.sprite = ResourcesConfig.强化窗口按钮暗;
         洗练TextMeshProUGUI.colorGradientPreset = ResourcesConfig.灰色TMP;
      }
      else
      {
         强化Button.image.sprite = ResourcesConfig.强化窗口按钮暗;
         强化TextMeshProUGUI.colorGradientPreset = ResourcesConfig.灰色TMP;
         洗练Button.image.sprite = ResourcesConfig.强化窗口按钮亮;
         洗练TextMeshProUGUI.colorGradientPreset = ResourcesConfig.高级招募TMP;
      }
   }
   private void OnEnable()
   {
      Set装备();
      Set强化Info();
      Set属性Panel();
      Set材料();
   }
}
