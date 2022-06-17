using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseControl : MonoBehaviour
{

    public void GamePause()
    {
        Time.timeScale = 0;
        SceneManager.LoadSceneAsync("PauseScene",LoadSceneMode.Additive);
    }
}
