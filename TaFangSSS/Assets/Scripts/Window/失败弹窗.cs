using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 失败弹窗 : MonoBehaviour
{
    public Button AgainButtn;
    public Button ExitButtn;

    public void 清空怪物()
    {
        foreach (var item in QueueController.S.MonsterColliderDic)
        {
            item.Value.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        ExitButtn.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            清空怪物();
            SceneManager.LoadScene("UIScene");
        });
        AgainButtn.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            清空怪物();
            SceneManager.LoadScene("LoadScene");
        });
    }
}
