using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfoControl : MonoBehaviour
{
    public static CharacterInfoControl Instance;
    public CanvasGroup hastaUi;
    public CanvasGroup dialogUi;
    public TMP_Text chracterName;
    public TMP_Text chracterHistory;
    public TMP_Text chracterHealth;
    public TMP_Text chracterExitDialog;
    public Button chracterDialog1;
    public Button chracterDialog2;
    public string chracterDialog1Exit;
    public string chracterDialog2Exit;
    public bool dialogSucces;
    public bool chracterDialog1Succes;
    public bool chracterDialog2Succes;
    public Image chracterIcon;
    public Sprite[] allImages;
    public float dialogShowTime = 5f;
    public Patient[] allCharacters;
    string name, history, health, dialog1, dialog2, dialog1Exit, dialog2Exit;
    bool dialog1Succes, dialog2Succes;
    int index;
    int currentDialog = 0;
    void Start()
    {
        Instance = this;
    }

    public void Dialog1Button()
    {
        Debug.Log("Buton tiklama");
        DialogSet(chracterDialog1Exit);
        dialogSucces = chracterDialog1Succes;
    }
    public void Dialog2Button()
    {
        Debug.Log("Buton tiklama");
        DialogSet(chracterDialog2Exit);
        dialogSucces = chracterDialog2Succes;

    }
    void DialogSet(string value)
    {

        hastaUi.alpha = 0;
        dialogUi.alpha = 1;
        chracterExitDialog.text = value;
        Invoke("DialogExit", dialogShowTime);
    }
    void DialogExit()
    {
        //hastaUi.alpha = 1;
        hastaUi.alpha = 0;
        dialogUi.alpha = 0;

        CursorShow(false);
        //
        // NextDialog();
    }
    public void NextDialog()
    {
        if (currentDialog < allCharacters.Length)
        {
            PatientGet(allCharacters[currentDialog]);
            currentDialog++;
        }
        else
        {
            Debug.Log("Hasta kalmadi");
         }
    }
    void PatientGet(Patient patient)
    {
        chracterName.text = patient.PatientName;
        chracterHistory.text = patient.PatientHistory;
        chracterHealth.text = patient.PatientHealth;
        chracterDialog1Exit = patient.PatientDialog1Exit;
        chracterDialog2Exit = patient.PatientDialog2Exit;
        chracterDialog1.GetComponentInChildren<TMP_Text>().text = patient.PatientDialog1;
        chracterDialog2.GetComponentInChildren<TMP_Text>().text = patient.PatientDialog2;
        chracterDialog1Succes = patient.PatientDialog1Succes;
        chracterDialog2Succes = patient.PatientDialog2Succes;
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
}
