using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using SyunichTool;

public class AudioManager : SingletonMonovehavior<AudioManager>
{
    public AudioSource BGMSource;
    public AudioSource SESource;
    public AudioClip[] Voices;
    public AudioClip[] BGMs;
    public AudioClip[] SEs;


    protected override bool IsDestroyOnLoad
    {
        get => false;
    }

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayBGM(int index)
    {
        BGMSource.clip = BGMs[index];
        BGMSource.Play();
    }
    public void PlaySE(int index)
    {
        SESource.PlayOneShot(SEs[index]);
    }

    public void PlayVoice(int index)
    {
        SESource.PlayOneShot(Voices[index]);
    }

    public void FeedOutBGM()
    {
        float nowvolume = BGMSource.volume;
        BGMSource.DOFade(0, 1.0f)
            .OnComplete(() =>
                {
                    BGMSource.Stop();
                    BGMSource.volume = nowvolume;
                }
            ).Play();
    }
}