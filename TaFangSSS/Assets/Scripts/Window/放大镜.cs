using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 放大镜 : MonoBehaviour
{
    public float 半径 = 1;
    public float 速度 = 1f;
    public Vector3 圆心偏移 = Vector3.zero;
    
    private Vector3 圆心位置;
    private float 起始时间;

    void Start()
    {
        圆心位置 = transform.position + 圆心偏移;
        起始时间 = Time.time;
    }

    void Update()
    {
        // 使用经过的时间计算角度，永远不会累积误差
        float 经过时间 = Time.time - 起始时间;
        float 角度 = 经过时间 * 速度;
        
        // 使用 Mathf.Sin 和 Mathf.Cos 会自动处理周期性
        float x = 圆心位置.x + 半径 * Mathf.Cos(角度);
        float y = 圆心位置.y + 半径 * Mathf.Sin(角度);
        
        transform.position = new Vector3(x, y, transform.position.z);
    }
}