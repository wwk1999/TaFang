using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 火球旋转parent : MonoBehaviour
{
    [NonSerialized] public float RotateSpeed = 6;
    public List<火球> 火球list;
    [NonSerialized] public bool 瑶池冰辅助;
    [NonSerialized] public bool 黑暗辅助;
    [NonSerialized] public float HideTime = 3;
    [NonSerialized] public float damage = 50;

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        CancelInvoke();
        foreach (var item in 火球list)
        {
            item.黑暗辅助 = 黑暗辅助;
            item.瑶池冰辅助 = 瑶池冰辅助;
            item.damage=damage;
        }
        Invoke(nameof(Hide), HideTime);
    }

    private void Update()
    {
        transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
    }
}
