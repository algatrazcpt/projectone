
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuUiControl : MonoBehaviour
{
    public CanvasGroup menuUi;
    public CanvasGroup soundUi;
    public string gameScenename = "";

    public void SettingsButtClick()
    {
        menuUi.alpha = 0;
        soundUi.alpha = 1;
    }
    public void ReturnButtClick()
    {
        soundUi.alpha = 0;
        menuUi.alpha = 1;
    }
    public void NewGameButtClick()    {
        SceneManager.LoadScene(gameScenename);
    }
}
