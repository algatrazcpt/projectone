using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPaper : Interactable
{

    public override void Interact()
    {
        CharacterInfoControl.Instance.NextDialog();
        Debug.Log("InfoPaper.Interact()");
    }

}
