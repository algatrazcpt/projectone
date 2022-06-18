using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPaper : Interactable
{
    int index = 0;
    public void Start()
    {
        index = CharacterInfoControl.Instance.currentDialog;
        CharacterInfoControl.Instance.NextDialog();
        
    }
    public override void Interact()
    {
        if (CharacterInfoControl.Instance.allCharacters[index].PatientFinish)
        {
            CharacterInfoControl.Instance.PatientGet(index);
            CharacterInfoControl.Instance.NextDialog();
            Debug.Log("InfoPaper.Interact()");
        }
        else
        {
            CharacterInfoControl.Instance.PatientGet(index);
            Debug.Log("InfoPaper.Interact()");
        }
    }

}
