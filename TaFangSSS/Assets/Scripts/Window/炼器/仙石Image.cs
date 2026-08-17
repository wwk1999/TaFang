using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 仙石Image : MonoBehaviour
{
    public Image image;
    [NonSerialized] public 仙石 仙石;

    private void OnEnable()
    {
        image.sprite = ResourcesConfig.Get仙石Sprite(仙石.type, 仙石.quality);
    }

    
    
}
