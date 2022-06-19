using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameFinishControl : MonoBehaviour
{
    int escapeCharacter = 0;
    public Image happyEnd;
    public Image stabilEnd;
    public Image sadEnd;
    public float showTime = 4f;
    private static string succesCount = "characterSucces";
    private static string levelString = "PlayerLevel";
    
    
    public void GameInfoSettings()
    {
        
        escapeCharacter = PlayerPrefs.GetInt(succesCount, 0);
        GameFinish();
    }
    public void Start()
    {
        GameInfoSettings();
    }
    public void GameFinish()
    {
        if(escapeCharacter>4)
        {
            happyEnd.enabled = true;
            Invoke("ReturnMenu",showTime);
        }
        else if(escapeCharacter>3)
        {
            stabilEnd.enabled = true;
            Invoke("ReturnMenu", showTime);
        }
        else
        {
            sadEnd.enabled = true;
            Invoke("ReturnMenu", showTime);
        }
    }
    public void ReturnMenu()
    {
        PlayerPrefs.SetInt(succesCount, 0);
        PlayerPrefs.SetInt(levelString, 0);
        SceneManager.LoadScene("MainScene");


    }
    public void characaterSucces()
    {
        escapeCharacter++;
    }
}
