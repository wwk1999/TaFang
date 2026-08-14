using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class MonsterItem : MonoBehaviour
{
    [NonSerialized] public MonsterTypeName MonsterTypeName;
    public Image image;

    public void SetItem()
    {
        image.sprite=ResourcesConfig.GetMonsterSprite(MonsterTypeName);
    }
}
