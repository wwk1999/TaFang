using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 世界树主页收获弹窗 : MonoBehaviour
{
    public Button 收获Button;
    public GameObject content;

    public void 刷新主页世界树收获弹窗(object[] obj)
    {
        foreach (Transform item in content.transform)
        {
            var 秘境item = item.gameObject.GetComponent<主页秘境item>();
            if (秘境item == null) continue;
            item.gameObject.SetActive(false);
            QueueController.S.主页秘境itemQueue.Enqueue(秘境item);
        }

        var list = PlayerData.S.获取世界树所有道具();
        foreach (var item in list)
        {
            try
            {
                主页秘境item 秘境item = null;
                while (QueueController.S.主页秘境itemQueue.Count > 0)
                {
                    var dequeued = QueueController.S.主页秘境itemQueue.Dequeue();
                    if (dequeued != null)
                    {
                        秘境item = dequeued;
                        break;
                    }
                }
                if (秘境item == null)
                {
                    秘境item = Instantiate(Resources.Load("Prefabs/Window/主页秘境item")).GetComponent<主页秘境item>();
                }
                秘境item.transform.SetParent(content.transform);
                秘境item.quality = 道宝Config.道宝QualityToQuality[道宝Config.道宝品质Dic[item.Key]];
                秘境item.sprite = ResourcesConfig.Get道宝Sprite(item.Key);
                秘境item.count=item.Value;
                秘境item.name=道宝Config.道宝NameDic[item.Key];
                秘境item.SetItem();
                秘境item.gameObject.SetActive(true);
            }
            catch (Exception e)
            {
                Debug.LogError($"刷新主页世界树收获弹窗: 创建item失败, 道宝Type={item.Key}, Error={e.Message}");
            }
        }
    }

    private void OnDisable()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新主页世界树收获弹窗",刷新主页世界树收获弹窗);
    }

    private void OnEnable()
    {
        ObserverModuleManager.S.RegisterEvent("刷新主页世界树收获弹窗",刷新主页世界树收获弹窗);
        收获Button.onClick.RemoveAllListeners();
        收获Button.onClick.AddListener(() =>
        {
            HeroWindowController.S.StartCoroutine(PlayerData.S.收获世界树());
            gameObject.SetActive(false);
            刷新主页世界树收获弹窗(null);
        });
        刷新主页世界树收获弹窗(null);
    }
}
