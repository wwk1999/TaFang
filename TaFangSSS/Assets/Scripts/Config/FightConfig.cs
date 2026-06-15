using System.Collections.Generic;
using UnityEngine;

public class FightConfig
{
    public static Dictionary<int, Vector2> 人物位置Dic = new Dictionary<int, Vector2>()
    {
        { 1, new Vector2(0.53f, 0) },
        { 2, new Vector2(0.53f, 1.8f) },
        { 3, new Vector2(0.53f, -1.8f) },
        { 4, new Vector2(0.53f, 3.6f) },
        { 5, new Vector2(0.53f, -3.6f) },
    };
}
