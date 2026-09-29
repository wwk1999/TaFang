using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadWindow : MonoBehaviour
{
    public Slider loadSlider;
    public TextMeshProUGUI count;

    public IEnumerator PreloadAllPools()
    {
        yield return QueueController.S.Init怪物Queue();
        yield return QueueController.S.InitHeroSkill();
    }

    private void Start()
    {
        
        StartCoroutine(LoadAndPreload());
        loadSlider.onValueChanged.AddListener((value) =>
        {
            count.text = (int)(value * 100)+"%";
        });
    }

    private void OnEnable()
    {
        ObserverModuleManager.S.SendEvent("播放BGM",false);
    }

    private IEnumerator LoadAndPreload()
    {
        // 1. 开始异步加载战斗场景
        AsyncOperation async = SceneManager.LoadSceneAsync("FightScene", LoadSceneMode.Additive);
        async.allowSceneActivation = false;

        // 2. 等待加载进度达到 0.9
        while (async.progress < 0.9f)
        {
            loadSlider.value = async.progress / 0.9f;
            yield return null;
        }

        loadSlider.value = 1f;

        // 3. 预热对象池
        yield return StartCoroutine(PreloadAllPools());

        // 4. 允许激活，并等待场景真正加载完成
        async.allowSceneActivation = true;

        while (!async.isDone)
        {
            yield return null;
        }

        // 5. 此时场景已加载完成，可以安全设置激活场景
        Scene fightScene = SceneManager.GetSceneByName("FightScene");
        if (fightScene.IsValid() && fightScene.isLoaded)
        {
            SceneManager.SetActiveScene(fightScene);
            gameObject.SetActive(false);
        }

        yield return null;
    }
}
