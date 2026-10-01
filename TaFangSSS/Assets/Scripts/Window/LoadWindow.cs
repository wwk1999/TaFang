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
        }

        // 6. 任务已完成：卸载 LoadScene 自身，避免多次进战斗后叠加出多份 LoadWindow。
        //    对象池都挂在 DontDestroyOnLoad 的 QueueController 下，不受场景卸载影响；
        //    卸载会销毁本组件并中断协程，因此必须是最后一步，不能再 yield 等待。
        Scene loadScene = gameObject.scene;
        if (loadScene.IsValid() && loadScene.isLoaded)
        {
            SceneManager.UnloadSceneAsync(loadScene);
        }

        yield return null;
    }
}
