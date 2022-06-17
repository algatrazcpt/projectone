using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Carriable : MonoBehaviour
{
    public enum State
    {
        Carried,
        Dropped
    }

    public State currentState = State.Dropped;

    public abstract void Carry();

    public abstract void Drop();

}
