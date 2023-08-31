using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider slider;
    public bool isBGM;
    void Start()
    {

        if (isBGM)
        {
            slider.value = SoundManager.Instance.bgm.volume;
            
        }
        else
        {
            slider.value = SoundManager.Instance.sfx.volume;
        }
        slider.onValueChanged.AddListener(volume =>
        {
            if (isBGM)
                SoundManager.Instance.SetBGMVolume(volume);
            else
                SoundManager.Instance.SetSFXVolume(volume);

        });
    }

    
}
