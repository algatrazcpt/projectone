using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerControl : MonoBehaviour
{
    public static GameManagerControl Instance;
    public Patient[] patients;
    public InfoPaper patientInfo1;
    public InfoPaper patientInfo2;
    int index1 = 0;
    int index2 = 1;
    private void Start()
    {
        Instance = this;
    }
    void GetPatient()
    {
        patientInfo1.patient = patients[index1];
        patientInfo2.patient = patients[index2];

    }
    public bool NextPatient()
    {
        if (index2+2 <= patients.Length)
        {
            Debug.Log(index1 + "-" + index2);
            index1 += 2;
            index2 += 2;
            GetPatient();
            return true;
        }
        else
        {
            GameOver();
            return false;
        }
    }
    public void GameOver()
    {
        Debug.Log("Hasta Bitti");
    }
}
