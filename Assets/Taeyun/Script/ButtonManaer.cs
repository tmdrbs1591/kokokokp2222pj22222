using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonManaer : MonoBehaviour
{
    

    public Image image;

    public void ChangeScenesBtn()
    {

        switch (this.gameObject.name)
        {
            case "StartBtn":
                SceneManager.LoadScene("CharacterSelect");
                break;
            case "OptionBtn":
                SceneManager.LoadScene("OptionScene");
                break;
            case "CreditBtn":
                SceneManager.LoadScene("CreditScene");
                break;
            case "BackBtn":
                SceneManager.LoadScene("TitleScene");
                break;
            case "ExitBtn":
                Application.Quit();
                break;
            case "BackBtn(select)":
                SceneManager.LoadScene("CharacterSelect");
                break;
            case "AssassinBtn":
                SceneManager.LoadScene("AsScene");
                break;



        }
    }
}
