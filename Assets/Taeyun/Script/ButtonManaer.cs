using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonManaer : MonoBehaviour
{
    public void ChangeScenesBtn()
    {
        StartCoroutine(SceneFade());
        IEnumerator SceneFade()
        {
            yield return StartCoroutine(LevelChange.Instance.FadeInCoroutine());
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
                    SceneManager.LoadScene("main");
                    break;
                case "WizardBtn":
                    SceneManager.LoadScene("WZD");
                    break;
                case "GuideBtn":
                    SceneManager.LoadScene("GuideScene");
                    break;
                case "NextBtn_1":
                    SceneManager.LoadScene("GuideScene2");
                    break;
                case "NextBtn_2":
                    SceneManager.LoadScene("GuideScene3");
                    break;
                case "BackBtn_1":
                    SceneManager.LoadScene("GuideScene");
                    break;
                case "BackBtn_2":
                    SceneManager.LoadScene("GuideScene2");
                    break;
            }
        }
    }
}
