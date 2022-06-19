using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoControl : MonoBehaviour
{
    public int succesCharacter = 0;
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void ChracterRest()
    {
        succesCharacter = 0;
    }
    public void ChracterSucces()
    {
        succesCharacter++;
    }
    void Update()
    {
        
    }
}
