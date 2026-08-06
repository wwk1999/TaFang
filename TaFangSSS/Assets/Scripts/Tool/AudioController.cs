using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AudioController : MonoBehaviour
{
   public AudioSource BgAudioSource;
   public AudioSource 音效Source;
   public AudioSource 元始Source;

   [NonSerialized]public AudioClip UIClip;
   [NonSerialized]public AudioClip 战斗Clip;
   [NonSerialized]public List<AudioSource> 人物AudioSource = new List<AudioSource>();
   [NonSerialized] public int 人物池大小 = 30;
   
   [NonSerialized]public List<AudioSource> 怪物AudioSource = new List<AudioSource>();
   [NonSerialized] public int 怪物池大小 = 30;
   public void InitPool()
   {
      for (int i = 0; i < 人物池大小; i++)
      {
         AudioSource source = gameObject.AddComponent<AudioSource>();
         source.loop = false;
         source.playOnAwake = false;
         source.volume = 1f;
         source.pitch = 1f;
         人物AudioSource.Add(source);
      }
      
      for (int i = 0; i < 怪物池大小; i++)
      {
         AudioSource source = gameObject.AddComponent<AudioSource>();
         source.loop = false;
         source.playOnAwake = false;
         source.volume = 1f;
         source.pitch = 1f;
         怪物AudioSource.Add(source);
      }
   }

   public AudioSource Get人物空闲AudioSource()
   {
      foreach (var item in 人物AudioSource)
      {
         if (!item.isPlaying)
         {
            return item;
         }
      }
      return null;
   }
   
   public AudioSource Get怪物空闲AudioSource()
   {
      foreach (var item in 怪物AudioSource)
      {
         if (!item.isPlaying)
         {
            return item;
         }
      }
      return null;
   }
   public void 播放人物音效(object[] obj)
{
    战斗音效Type type = (战斗音效Type)obj[0];
    var audio = Get人物空闲AudioSource();
    if (audio == null) return;
    
    switch (type)
    {
        // ============ 通用战斗音效 ============
        case 战斗音效Type.丹童:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.丹童);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1.5f;
            audio.time = 0.25f;
            audio.Play();
            break;
            
        case 战斗音效Type.河伯1:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.河伯1);
            audio.volume = 0.8f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.河伯2:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.河伯2);
            audio.volume = 0.55f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.瑶池:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.瑶池);
            audio.volume = 1.4f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 1.5f;
            audio.Play();
            break;
            
        case 战斗音效Type.土地:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.土地);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0.1f;
            audio.Play();
            break;
            
        case 战斗音效Type.太白金星:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.太白金星);
            audio.volume = 0.4f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.玄女:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.玄女);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0.9f;
            audio.Play();
            break;
            
        case 战斗音效Type.石敢当:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.石敢当);
            audio.volume = 0.8f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.龟丞相:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.龟丞相);
            audio.volume = 0.9f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.怪物死亡:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.怪物死亡);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;

        // ============ 四大天王 ============
        case 战斗音效Type.多闻天王:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.多闻天王);
            audio.volume = 0.9f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.广目天王:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.广目天王);
            audio.volume = 0.9f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.雷震子:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.雷震子);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.月老:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.月老);
            audio.volume = 0.6f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;

        // ============ 大能 / 妖族 ============
        case 战斗音效Type.嫦娥:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.嫦娥);
            audio.volume = 0.8f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.杨戬:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.杨戬);
            audio.volume = 0.8f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.妲己:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.妲己);
            audio.volume = 0.8f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.牛魔王:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.牛魔王);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;

        // ============ 上古神明 ============
        case 战斗音效Type.羲和:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.羲和);
            audio.volume = 1.1f * PlayerData.S.音效音量;
            audio.pitch = 1.3f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.常羲:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.常羲);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1.3f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.后羿:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.后羿);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.云霄:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.云霄);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0.45f;
            audio.Play();
            break;

        // ============ 封神 / 斗士 ============
        case 战斗音效Type.哪吒:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.哪吒);
            audio.volume = 0.8f * PlayerData.S.音效音量;
            audio.pitch = 2f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.孙悟空:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.孙悟空);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0.06f;
            audio.Play();
            break;
            
        case 战斗音效Type.碧霄:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.碧霄);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.琼霄:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.琼霄);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;

        // ============ 创世 / 圣贤 ============
        case 战斗音效Type.女娲:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.女娲);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1.2f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.老子:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.老子);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1.2f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.元始:
            元始Source.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.元始);
            元始Source.volume = 1f * PlayerData.S.音效音量;
            元始Source.pitch = 1.2f;
            元始Source.time = 0f;
            元始Source.Play();
            break;
            
        case 战斗音效Type.通天:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.通天);
            audio.volume = 1.1f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0.6f;
            audio.Play();
            break;

        // ============ 天道 / 终极 ============
        case 战斗音效Type.鸿钧:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.鸿钧);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;
            
        case 战斗音效Type.盘古:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.盘古);
            audio.volume = 1f * PlayerData.S.音效音量;
            audio.pitch = 1f;
            audio.time = 0f;
            audio.Play();
            break;

        default:
            Debug.LogWarning($"未处理的战斗音效类型: {type}");
            break;
    }
}

public void 停止元始音效(object[] obj)
{
    元始Source.Stop();
}
   public void 播放怪物音效(object[] obj)
   {
      战斗音效Type type = (战斗音效Type)obj[0];
      var audio = Get怪物空闲AudioSource();
      if (audio == null) return;
      switch (type)
      {
         case 战斗音效Type.怪物死亡:
            audio.clip = AudioConfig.Get战斗音效Clip(战斗音效Type.怪物死亡);
            audio.volume = 3 * PlayerData.S.音效音量;
            audio.pitch = 1 ;
            audio.time = 0f;
            audio.Play();
            break;
      }
   }
   
   private void OnDestroy()
   {
       ObserverModuleManager.S.UnRegisterEvent("停止元始音效",停止元始音效);
      ObserverModuleManager.S.UnRegisterEvent("播放BGM",播放BGM);
      ObserverModuleManager.S.UnRegisterEvent("播放音效",Play音效);
      ObserverModuleManager.S.UnRegisterEvent("播放人物音效",播放人物音效);
      ObserverModuleManager.S.UnRegisterEvent("播放怪物音效",播放怪物音效);
   }

   public void Play音效(object[] obj)
   {
      音效Type type = (音效Type)obj[0];
      AudioClip alip=AudioConfig.Get音效Clip(type);
      音效Source.PlayOneShot(alip,1);
   }
   
   

   protected void Awake()
   {
      DontDestroyOnLoad(gameObject); 
      ObserverModuleManager.S.RegisterEvent("播放BGM",播放BGM);
      ObserverModuleManager.S.RegisterEvent("播放音效",Play音效);
      ObserverModuleManager.S.RegisterEvent("播放人物音效",播放人物音效);
      ObserverModuleManager.S.RegisterEvent("播放怪物音效",播放怪物音效);
      ObserverModuleManager.S.RegisterEvent("停止元始音效",停止元始音效);

      InitPool();
      UIClip=Resources.Load<AudioClip>("音效/UIBGM");
      战斗Clip=Resources.Load<AudioClip>("音效/战斗BGM");
   }

   public void 播放BGM(object[] obj)
   {
      bool i = (bool)obj[0];
      if (i)
      {
         PlayUIBGM();
      }
      else
      {
         Play战斗BGM();
      }
   }

   public void PlayUIBGM()
   {
      if (BgAudioSource.isPlaying && BgAudioSource.clip != UIClip)
      {
         Sequence mySequence = DOTween.Sequence();
         mySequence.Append(DOTween.To(()=>BgAudioSource.volume, 
            x => BgAudioSource.volume = x, 
            0, 1f));
         mySequence.AppendCallback(() =>
         {
            BgAudioSource.clip = UIClip;
            BgAudioSource.Play();
         });
         mySequence.Append(DOTween.To(()=>BgAudioSource.volume, 
            x => BgAudioSource.volume = x, 
            PlayerData.S.BGM音量, 1f));
      }
   }
   
   public void Play战斗BGM()
   {
      if (BgAudioSource.isPlaying && BgAudioSource.clip != 战斗Clip)
      {
         Sequence mySequence = DOTween.Sequence();
         mySequence.Append(DOTween.To(()=>BgAudioSource.volume, 
            x => BgAudioSource.volume = x, 
            0, 1f));
         mySequence.AppendCallback(() =>
         {
            BgAudioSource.clip = 战斗Clip;
            BgAudioSource.Play();
         });
         mySequence.Append(DOTween.To(()=>BgAudioSource.volume, 
            x => BgAudioSource.volume = x, 
            PlayerData.S.BGM音量, 1f));
      }
   }
}
