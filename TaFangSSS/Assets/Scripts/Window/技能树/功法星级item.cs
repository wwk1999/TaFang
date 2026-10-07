using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum 功法星级Type
{
    None,
    星星,
    月亮,
    太阳,
}
public class 功法星级item : MonoBehaviour
{
    [NonSerialized] public 功法星级Type 功法星级Type;
    public Image image;

    public void SetItem()
    {
        switch (功法星级Type)
        {
            case 功法星级Type.星星:
                image.sprite = ResourcesConfig.星星;
                break;
            case 功法星级Type.月亮:
                image.sprite = ResourcesConfig.月亮;
                break;
            case 功法星级Type.太阳:
                image.sprite = ResourcesConfig.太阳;
                break;
        }
    }
}
