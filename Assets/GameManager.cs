using TMPro;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;
    private int coin = 0;



     void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void IncreaseCoin()
    {
        coin += 1;
        text.SetText(coin.ToString());

    }
}