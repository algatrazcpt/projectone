using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseControl : MonoBehaviour
{
    public static bool pauseMenuShow = true;
    public void GamePause()
    {
        if (pauseMenuShow)
        {
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync("PauseScene", LoadSceneMode.Additive);
            pauseMenuShow=false;
        }
        
    }
}
