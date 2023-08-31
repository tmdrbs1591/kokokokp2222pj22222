using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMusic : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.ChangeBGM(1);
    }
}
