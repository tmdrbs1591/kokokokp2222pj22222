using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image image;
    public GameObject[] buttonlist;
    
    public static FadeInOut instance;

    public void Awake()
    {
        
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void Fadebutton()
    {
        Debug.Log("asda");
        foreach (var button in buttonlist)
        {
            button.gameObject.SetActive(false);
        }
        StartCoroutine(FadeOutCoroutine());
    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }

    IEnumerable FadeOutCoroutine()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color( 0, 0, 0, fadeCount );
        }
    }
}
