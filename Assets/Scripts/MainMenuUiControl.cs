
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuUiControl : MonoBehaviour
{
    public Button continueButton;
    public CanvasGroup menuUi;
    public CanvasGroup soundUi;
    public AudioSource audioSource;
    public AudioClip[] buttonClicksSounds;
    public string gameScenename = "";
    private void Start()
    {
        SoundControl.instance.DefaultSounds(7, 7);
        soundUi.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("PlayerLevel", 0) == 0)
        {
            continueButton.interactable = false;
        }

    }
    public void SettingsButtClick()
    {
        menuUi.gameObject.SetActive(false);
        menuUi.alpha = 0;
        soundUi.gameObject.SetActive(true);
        soundUi.alpha = 1;
        GameSounControl.instance.VfxPlay(0);
    }
    public void ReturnButtClick()
    {
        Debug.Log("Return click");
        soundUi.alpha = 0;
        soundUi.gameObject.SetActive(false);
        menuUi.alpha = 1;
        menuUi.gameObject.SetActive(true);
        GameSounControl.instance.VfxPlay(0);
    }
    public void NewGameButtClick()
    {
        GameSounControl.instance.VfxPlay(0);
        Invoke("NewGame", 0.3f);

    }
    void NewGame()
    {
        PlayerPrefs.SetInt("PlayerLevel", 0);

        SceneManager.LoadScene(gameScenename);
    }
    public void Continue()
    {
        GameSounControl.instance.VfxPlay(0);
        Debug.Log("Continue");
        SceneManager.LoadScene(gameScenename);
    }

}
