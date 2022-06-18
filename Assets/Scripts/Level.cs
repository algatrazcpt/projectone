using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    public string levelName;
    public string levelDescription;
    public int levelNumber;
    public Patient patient1;
    public Patient patient2;
    public int levelExperience;

}
