using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum 音效Type
{
    None,
    按钮进入,
    按钮点击,
    错误,
    Toggle,
    招募,
    成功,
}
public class AudioConfig : MonoBehaviour
{
    public static AudioClip Get音效Clip(音效Type type)
    {
        switch (type)
        {
            case 音效Type.按钮点击:
                return ResourcesConfig.按钮点击;
            case 音效Type.按钮进入:
                return ResourcesConfig.按钮进入;
            case 音效Type.错误:
                return ResourcesConfig.错误;
            case 音效Type.Toggle:
                return ResourcesConfig.Toggle;
            case 音效Type.招募:
                return ResourcesConfig.招募;
            case 音效Type.成功:
                return ResourcesConfig.成功;
        }
        return null;
    }
}
