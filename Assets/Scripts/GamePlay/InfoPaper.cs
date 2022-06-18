using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPaper : Interactable
{
    public Patient patient;
    public override void Interact()
    {
        //Debug.Log(CharacterInfoControl.Instance.currentDialog);
        CharacterInfoControl.Instance.LookAtPatient(patient);
        Debug.Log("InfoPaper.Interact()");
    }

}
