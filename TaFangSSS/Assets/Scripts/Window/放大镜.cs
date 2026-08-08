using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 放大镜 : MonoBehaviour
{
    public float 半径 = 0.7f;
    public float 速度 = 1f;
    public Vector3 圆心偏移 = Vector3.zero;
    // 跟随的锚点（不填就以自身为圆心）。拖入父级/英雄即可让放大镜绕着它转并跟着它移动。
    public Transform 锚点;

    private float 起始时间;

    void OnEnable()
    {
        起始时间 = Time.time;
    }

    void LateUpdate()
    {
        // 每帧重新取圆心：有锚点跟锚点，没有就以自身当前父级位置为准
        Vector3 圆心位置 = (锚点 != null ? 锚点.position : transform.parent != null ? transform.parent.position : transform.position) + 圆心偏移;

        float 经过时间 = Time.time - 起始时间;
        float 角度 = 经过时间 * 速度;

        float x = 圆心位置.x + 半径 * Mathf.Cos(角度);
        float y = 圆心位置.y + 半径 * Mathf.Sin(角度);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
