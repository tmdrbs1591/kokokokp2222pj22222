using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource sfx;

    private float bgmVolume;
    private float sfxVolume;

    public static SoundManager Instance { get; private set; }
    public void Awake()
    {
        if (null == Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        bgm.Play();
    }

    public void PlayClickSFX()
    {
        sfx.Play();
    }

    public void SetBGMVolume(float volume)
    {
        bgm.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfx.volume = volume;
    }
}