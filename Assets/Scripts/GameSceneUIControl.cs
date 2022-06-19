using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameSceneUIControl : MonoBehaviour
{
    public static GameSceneUIControl Instance { get; private set; }

    public GameObject infoPanel;
    public TMP_Text dayTxt;

    public TMP_Text InfoTxt;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDialogue(Level level)
    {
        PlayerInteraction.Instance.StartUIInteraction();
        infoPanel.SetActive(true);
        dayTxt.text = level.levelName;
        InfoTxt.text = level.levelDescription;
        CursorShow(true);
    }

    public void StartGame()
    {
        infoPanel.SetActive(false);
        PlayerInteraction.Instance.StopUIInteraction();
        CursorShow(false);
    }

    void CursorShow(bool value)
    {
        if (!value)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }



}