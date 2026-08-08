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

public enum 战斗音效Type
{
    首领出现,
    // ============ 通用战斗音效 ============
    丹童,
    瑶池,
    河伯1,
    河伯2,
    土地,
    怪物死亡,
    玄女,
    龟丞相,
    石敢当,
    太白金星,
    
    // ============ 四大天王 ============
    多闻天王,
    广目天王,
    雷震子,
    月老,
    
    // ============ 大能 / 妖族 ============
    嫦娥,
    杨戬,
    妲己,
    牛魔王,
    
    // ============ 上古神明 ============
    羲和,
    常羲,
    后羿,
    云霄,
    
    // ============ 封神 / 斗士 ============
    哪吒,
    孙悟空,
    碧霄,
    琼霄,
    
    // ============ 创世 / 圣贤 ============
    女娲,
    老子,
    元始,
    通天,
    
    // ============ 天道 / 终极 ============
    鸿钧,
    盘古
}
public class AudioConfig : MonoBehaviour
{
    public static AudioClip Get战斗音效Clip(战斗音效Type type)
{
    switch (type)
    {
        case 战斗音效Type.首领出现:
            return ResourcesConfig.首领出现;
        // ============ 通用战斗音效 ============
        case 战斗音效Type.丹童:
            return ResourcesConfig.丹童;
        case 战斗音效Type.瑶池:
            return ResourcesConfig.瑶池;
        case 战斗音效Type.河伯1:
            return ResourcesConfig.河伯1;
        case 战斗音效Type.河伯2:
            return ResourcesConfig.河伯2;
        case 战斗音效Type.土地:
            return ResourcesConfig.土地;
        case 战斗音效Type.怪物死亡:
            return ResourcesConfig.怪物死亡;
        case 战斗音效Type.玄女:
            return ResourcesConfig.玄女;
        case 战斗音效Type.龟丞相:
            return ResourcesConfig.龟丞相audio;
        case 战斗音效Type.石敢当:
            return ResourcesConfig.石敢当;
        case 战斗音效Type.太白金星:
            return ResourcesConfig.太白金星;

        // ============ 四大天王 ============
        case 战斗音效Type.多闻天王:
            return ResourcesConfig.多闻天王;
        case 战斗音效Type.广目天王:
            return ResourcesConfig.广目天王;
        case 战斗音效Type.雷震子:
            return ResourcesConfig.雷震子;
        case 战斗音效Type.月老:
            return ResourcesConfig.月老;

        // ============ 大能 / 妖族 ============
        case 战斗音效Type.嫦娥:
            return ResourcesConfig.嫦娥;
        case 战斗音效Type.杨戬:
            return ResourcesConfig.杨戬;
        case 战斗音效Type.妲己:
            return ResourcesConfig.妲己;
        case 战斗音效Type.牛魔王:
            return ResourcesConfig.牛魔王audio;

        // ============ 上古神明 ============
        case 战斗音效Type.羲和:
            return ResourcesConfig.羲和;
        case 战斗音效Type.常羲:
            return ResourcesConfig.常羲;
        case 战斗音效Type.后羿:
            return ResourcesConfig.后羿;
        case 战斗音效Type.云霄:
            return ResourcesConfig.云霄;

        // ============ 封神 / 斗士 ============
        case 战斗音效Type.哪吒:
            return ResourcesConfig.哪吒;
        case 战斗音效Type.孙悟空:
            return ResourcesConfig.孙悟空;
        case 战斗音效Type.碧霄:
            return ResourcesConfig.碧霄;
        case 战斗音效Type.琼霄:
            return ResourcesConfig.琼霄;

        // ============ 创世 / 圣贤 ============
        case 战斗音效Type.女娲:
            return ResourcesConfig.女娲;
        case 战斗音效Type.老子:
            return ResourcesConfig.老子;
        case 战斗音效Type.元始:
            return ResourcesConfig.元始;
        case 战斗音效Type.通天:
            return ResourcesConfig.通天;

        // ============ 天道 / 终极 ============
        case 战斗音效Type.鸿钧:
            return ResourcesConfig.鸿钧audio;
        case 战斗音效Type.盘古:
            return ResourcesConfig.盘古audio;

        default:
            Debug.LogWarning($"未找到战斗音效类型: {type}");
            return null;
    }
}
    
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
