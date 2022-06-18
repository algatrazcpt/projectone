using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    public string levelName;
    public string levelDescription;
    public int levelNumber;
    public List<Patient> patients;
    public int levelExperience;

}
