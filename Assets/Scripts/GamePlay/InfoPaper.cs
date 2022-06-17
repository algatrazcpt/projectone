using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPaper : Interactable
{

    public override string GetDescription()
    {
        return "Press [E] to interact.";
    }

    public override void Interact()
    {
        Debug.Log("InfoPaper.Interact()");
    }
}
