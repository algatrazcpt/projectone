using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Patient", menuName = "Patient")]
public class Patient : ScriptableObject
{
    public string PatientName;
    public string PatientHistory;
    public string PatientHealth;
    public string PatientDialog1;
    public string PatientDialog2;
    public string PatientDialog1Exit;
    public string PatientDialog2Exit;
    public bool PatientDialog1Succes;
    public bool PatientDialog2Succes;
    public Sprite PatientIcon;
    public int PatientIndex;
}
