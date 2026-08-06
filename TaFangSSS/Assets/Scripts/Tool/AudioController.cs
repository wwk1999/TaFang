using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AudioController : MonoBehaviour
{
   public AudioSource BgAudioSource;
   public AudioSource 音效Source;
   [NonSerialized]public AudioClip UIClip;
   [NonSerialized]public AudioClip 战斗Clip;

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("播放音效",Play音效);
      ObserverModuleManager.S.UnRegisterEvent("播放BGM",播放BGM);
   }

   public void Play音效(object[] obj)
   {
      音效Type type = (音效Type)obj[0];
      AudioClip alip=AudioConfig.Get音效Clip(type);
      音效Source.PlayOneShot(alip,PlayerData.S.音效音量);
   }

   protected void Awake()
   {
      DontDestroyOnLoad(gameObject); 
      ObserverModuleManager.S.RegisterEvent("播放BGM",播放BGM);
      ObserverModuleManager.S.RegisterEvent("播放音效",Play音效);

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
