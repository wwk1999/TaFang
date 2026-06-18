using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadWindow : MonoBehaviour
{
    public Slider loadSlider;

    public IEnumerator PreloadAllPools()
    {
        yield return FightController.S.Init怪物Queue();
        yield return FightController.S.InitHeroSkill();
    }

    private void Start()
    {
        StartCoroutine(LoadAndPreload());
    }

    private IEnumerator LoadAndPreload()
    {
        // 1. 开始异步加载战斗场景
        AsyncOperation async = SceneManager.LoadSceneAsync("FightScene");
        async.allowSceneActivation = false; // 先不激活

        // 2. 等待加载进度达到 0.9（此时场景所有资源已加载完成，但还未实例化）
        while (async.progress < 0.9f)
        {
            loadSlider.value = async.progress / 0.9f;
            yield return null;
        }

        loadSlider.value = 1f;

        // 3. 【关键】在激活场景之前，执行所有对象池预热（利用 Loading 场景的这段时间）
        //    注意：需要把原来放在 Entrance.Awake 里的预热代码移到这里来调用
        yield return StartCoroutine(PreloadAllPools());

        // 4. 预热完成，激活战斗场景
        async.allowSceneActivation = true;

        // 5. 可选：隐藏 Loading 界面（战斗场景激活后会自动显示）
        // 等待一帧让场景切换
        yield return null;
    }
}
