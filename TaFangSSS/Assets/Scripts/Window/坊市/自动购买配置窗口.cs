using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 自动购买配置窗口 : MonoBehaviour
{
  private int 显示类型 = 1;//1法器,2丹药,3丹方,4仙石
  public Button 法器Button;
  public Button 丹药Button;
  public Button 丹方Button;
  public Button 仙石Button;
  public Button maskButton;

  public GameObject content;

  public void SetButton()
  {
    switch (显示类型)
    {
      case 1:
        法器Button.image.sprite = ResourcesConfig.标签亮;
        仙石Button.image.sprite = ResourcesConfig.标签暗;
        丹药Button.image.sprite = ResourcesConfig.标签暗;
        丹方Button.image.sprite = ResourcesConfig.标签暗;
        break;
      case 2:
        法器Button.image.sprite = ResourcesConfig.标签暗;
        仙石Button.image.sprite = ResourcesConfig.标签暗;
        丹药Button.image.sprite = ResourcesConfig.标签亮;
        丹方Button.image.sprite = ResourcesConfig.标签暗;
        break;
      case 3:
        法器Button.image.sprite = ResourcesConfig.标签暗;
        仙石Button.image.sprite = ResourcesConfig.标签暗;
        丹药Button.image.sprite = ResourcesConfig.标签暗;
        丹方Button.image.sprite = ResourcesConfig.标签亮;
        break;
      case 4:
        法器Button.image.sprite = ResourcesConfig.标签暗;
        仙石Button.image.sprite = ResourcesConfig.标签亮;
        丹药Button.image.sprite = ResourcesConfig.标签暗;
        丹方Button.image.sprite = ResourcesConfig.标签暗;
        break;
    }
  }
  public void Show法器()
  {
    foreach (Transform item in content.transform)
    {
      Destroy(item.gameObject);
    }

    foreach (var item in 法器Config.法器品质Dic)
    {
      var 配置Item = Instantiate(Resources.Load("Prefabs/Window/坊市/坊市自动购买Item"), content.transform)
        .GetComponent<坊市自动购买Item>();
      配置Item.法器Type = item.Key;
      配置Item.SetItem();
    }
  }
  
  
  public void Show仙石()
  {
    foreach (Transform item in content.transform)
    {
      Destroy(item.gameObject);
    }

    foreach (var quality in PropConfig.QualityNameDic)
    {
      foreach (var 仙石 in 仙石Config.仙石名Dic)
      {
        if(仙石.Key==仙石Type.None)continue;
        var 配置Item = Instantiate(Resources.Load("Prefabs/Window/坊市/坊市自动购买Item"), content.transform)
          .GetComponent<坊市自动购买Item>();
        配置Item.仙石Type = 仙石.Key;
        配置Item.QualityType = quality.Key;
        配置Item.SetItem();
      }
    }
  }
  
  
  
  public void Show丹药()
  {
    foreach (Transform item in content.transform)
    {
      Destroy(item.gameObject);
    }

    foreach (var quality in PropConfig.QualityNameDic)
    {
      foreach (var 丹药 in 丹药Config.丹药名Dic)
      {
        if(丹药.Key==丹药Type.None)continue;
        var 配置Item = Instantiate(Resources.Load("Prefabs/Window/坊市/坊市自动购买Item"), content.transform)
          .GetComponent<坊市自动购买Item>();
        配置Item.丹药Type = 丹药.Key;
        配置Item.QualityType = quality.Key;
        配置Item.SetItem();
      }
    }
  }
  
  
  public void Show丹方()
  {
    foreach (Transform item in content.transform)
    {
      Destroy(item.gameObject);
    }

    foreach (var quality in PropConfig.QualityNameDic)
    {
      foreach (var 丹方 in 丹药Config.丹方名Dic)
      {
        if(丹方.Key==丹药Type.None)continue;
        var 配置Item = Instantiate(Resources.Load("Prefabs/Window/坊市/坊市自动购买Item"), content.transform)
          .GetComponent<坊市自动购买Item>();
        配置Item.丹方Type = 丹方.Key;
        配置Item.QualityType = quality.Key;
        配置Item.SetItem();
      }
    }
  }

  public void Show()
  {
    switch (显示类型)
    {
      case 1:
        Show法器();
        break;
      case 2:
        Show丹药();
        break;
      case 3:
        Show丹方();
        break;
      case 4:
        Show仙石();
        break;
    }
  }

  private void OnEnable()
  {
    Show();
  }

  private void Start()
  {
    法器Button.onClick.AddListener(() =>
    {
      显示类型 = 1;
      Show();
      SetButton();
    });
    
    丹药Button.onClick.AddListener(() =>
    {
      显示类型 = 2;
      Show();
      SetButton();
    });
    
    丹方Button.onClick.AddListener(() =>
    {
      显示类型 = 3;
      Show();
      SetButton();
    });
    
    仙石Button.onClick.AddListener(() =>
    {
      显示类型 = 4;
      Show();
      SetButton();
    });
    
    maskButton.onClick.AddListener(() =>
    {
      gameObject.SetActive(false);
    });
  }
}
