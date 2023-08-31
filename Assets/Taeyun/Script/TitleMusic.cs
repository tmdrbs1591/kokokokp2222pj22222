using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMusic : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.ChangeBGM(0);
    }
}
