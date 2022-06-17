
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuUiControl : MonoBehaviour
{
    public CanvasGroup menuUi;
    public CanvasGroup soundUi;
    public AudioSource audioSource;
    public AudioClip[] buttonClicksSounds;
    public string gameScenename = "";
    private void Start()
    {
        SoundControl.instance.DefaultSounds(7, 7);
    }
    public void SettingsButtClick()
    {
        menuUi.alpha = 0;
        soundUi.alpha = 1;
        GameSounControl.instance.VfxPlay(0);
    }
    public void ReturnButtClick()
    {
        soundUi.alpha = 0;
        menuUi.alpha = 1;
        GameSounControl.instance.VfxPlay(1);
    }
    public void NewGameButtClick()    {
        GameSounControl.instance.VfxPlay(2);
        Invoke("NewGame", 0.3f);
        
    }
   void NewGame()
    {
        SceneManager.LoadScene(gameScenename);
    }

}
