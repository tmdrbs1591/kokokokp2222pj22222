using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Ass,War,Mage
}
public class DataMgr : MonoBehaviour
{
    public static DataMgr Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != null) return;
        DontDestroyOnLoad(gameObject); 
    }
    public Character currentCharater;
}
