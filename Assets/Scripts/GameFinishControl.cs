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
    public void GameFinish()
    {
        if(escapeCharacter>4)
        {
            happyEnd.enabled = true;
            Invoke("ReturnMenu",showTime);
        }
        else if(escapeCharacter>2)
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
        SceneManager.LoadScene("MainMenuScene");
    }
    public void characaterSucces()
    {
        escapeCharacter++;
    }
}
