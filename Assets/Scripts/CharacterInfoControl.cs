using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfoControl : MonoBehaviour
{
    public Transform playerPosition;

    public Camera mainCam;
    public Camera cryCam;
    public Camera hapyCam;
    public static CharacterInfoControl Instance;
    public CanvasGroup hastaUi;
    public CanvasGroup dialogUi;
    public TMP_Text chracterName;
    public TMP_Text chracterHistory;
    public TMP_Text chracterHealth;
    public TMP_Text chracterExitDialog;
    public Button chracterDialog1;
    public string chracterDialog1Exit;
    public bool dialogSucces;
    public bool chracterDialog1Succes;
    public Image chracterIcon;
    public float dialogShowTime = 3f;

    void Start()
    {
        Instance = this;
    }

    public void Dialog1Button()
    {
        Debug.Log("Buton tiklama");
        DialogSet(chracterDialog1Exit);
        dialogSucces = chracterDialog1Succes;
        if (dialogSucces)
        {
            GameSounControl.instance.VfxPlay(2);
            hapyCam.enabled = true;
            mainCam.enabled = false;
        }
        else
        {
            GameSounControl.instance.VfxPlay(0);
            Invoke("SoundFix", 3);
            cryCam.enabled = true;
            mainCam.enabled = false;
        }
    }
    public void PlayerLocationReset()
    {
       // playerPosition.position=(new Vector3(4.93728447f, 1.31456006f, -10.2636957f));
    }
    public void SoundFix()
    {
        GameSounControl.instance.VfxPlay(1);
    }

    void DialogSet(string value)
    {

        hastaUi.alpha = 0;
        dialogUi.alpha = 1;
        chracterExitDialog.text = value;
        CursorShow(false);
        Invoke("DialogExit", dialogShowTime);
    }
    void CameraReturn()
    {
        
        mainCam.enabled = true;
        cryCam.enabled = false;
        hapyCam.enabled = false;
    }
    void DialogExit()
    {
        
        hastaUi.alpha = 0;
        dialogUi.alpha = 0;
        //
        PlayerLocationReset();
        CameraReturn();
        //
        CloseWithoutChoosing();
    }


    public void LookAtPatient(Patient patient)
    {
        chracterName.text = patient.PatientName;
        chracterHistory.text = patient.PatientHistory;
        chracterHealth.text = patient.PatientHealth;
        chracterDialog1Exit = patient.PatientDialog1Exit;
        chracterDialog1.GetComponentInChildren<TMP_Text>().text = patient.PatientDialog1;
        chracterDialog1Succes = patient.PatientDialog1Succes;
        chracterIcon.sprite = patient.PatientIcon;
        hastaUi.alpha = 1;
        dialogUi.alpha = 0;
        CursorShow(true);
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

    public void CloseWithoutChoosing()
    {
        hastaUi.alpha = 0;
        CursorShow(false);
        PlayerInteraction.Instance.StopUIInteraction();
    }
}
