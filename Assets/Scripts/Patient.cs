using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Patient", menuName = "Patient")]
public class Patient : ScriptableObject
{
    public string PatientName;
    public string PatientAge;
    public string PatientBloodType;
    public string PatientJob;
    public string PatientProblem;
    public string PatientHealth;
    public string PatientDialog1Exit;
    public bool PatientDialog1Succes;
    public Sprite PatientIcon;
}
