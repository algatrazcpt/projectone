using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfoControl : MonoBehaviour
{
    public Transform playerPosition;
    public static CharacterInfoControl Instance;
    public CanvasGroup hastaUi;
    public CanvasGroup dialogUi;
    public TMP_Text chracterName;
    public TMP_Text chracterAge;
    public TMP_Text chracterBlodType;
    public TMP_Text chracterJob;
    public TMP_Text chracterHistory;
    public TMP_Text chracterHealth;
    public TMP_Text chracterExitDialog;
    private string chracterDialog1Exit;
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
            //
            AnimationScript.instance.MovePlayer();
            AnimationScript.instance.CameraChange(true);
        }
        else
        {
            GameSounControl.instance.VfxPlay(0);
            Invoke("SoundFix", 3);
        }
    }
    public void SoundFix()
    {
        GameSounControl.instance.VfxPlay(1);
        //
        AnimationScript.instance.MovePlayer();
        AnimationScript.instance.CameraChange(false);
    }

    void DialogSet(string value)
    {

        hastaUi.alpha = 0;
        dialogUi.alpha = 1;
        chracterExitDialog.text = value;
        CursorShow(false);
        Invoke("DialogExit", dialogShowTime);
    }

    void DialogExit()
    {

        hastaUi.alpha = 0;
        dialogUi.alpha = 0;
        //
        CloseWithoutChoosing();
    }


    public void LookAtPatient(Patient patient)
    {
        chracterName.text = patient.PatientName;
        chracterAge.text = patient.PatientAge;
        chracterBlodType.text = patient.PatientBloodType;
        chracterJob.text = patient.PatientJob;
        chracterHistory.text = patient.PatientProblem;
        chracterHealth.text = patient.PatientHealth;
        chracterDialog1Exit = patient.PatientDialog1Exit;
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
