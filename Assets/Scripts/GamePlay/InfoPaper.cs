using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPaper : Interactable
{
    public Patient patient;
    public override void Interact()
    {
        CharacterInfoControl.Instance.LookAtPatient(patient);
    }

}
