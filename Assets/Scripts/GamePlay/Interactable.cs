using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    public enum InteractionType
    {
        Click,
        Hold
    }

    float holdTime;

    public InteractionType interactionType;

    public abstract void Interact();

    public string GetDescription()
    {
        return "Press [E] to interact.";
    }

    public void IncreaseHoldTime() => holdTime += Time.deltaTime;
    public void ResetHoldTime() => holdTime = 0f;
    public float GetHoldTime() => holdTime;

}
