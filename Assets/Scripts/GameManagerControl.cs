using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerControl : MonoBehaviour
{
    public static GameManagerControl Instance { get; private set; }
    public List<Level> levels;
    private static string levelString = "PlayerLevel";




    [SerializeField]
    private GameObject patient1Paper;
    [SerializeField]
    private GameObject patient2Paper;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (PlayerPrefs.HasKey(levelString))
        {
            int levelNumber = PlayerPrefs.GetInt(levelString);
            if (levelNumber < levels.Count)
            {
                LoadLevel(levelNumber);
            }
            else
            {
                LoadLevel(0);
            }
        }
    }

    private void SetUpLevel()
    {
        if (levels[PlayerPrefs.GetInt(levelString)].patient1 != null)
        {
            patient1Paper.GetComponent<InfoPaper>().patient = levels[PlayerPrefs.GetInt(levelString)].patient1;
        }
        if (levels[PlayerPrefs.GetInt(levelString)].patient2 != null)
        {
            patient2Paper.GetComponent<InfoPaper>().patient = levels[PlayerPrefs.GetInt(levelString)].patient2;
        }
    }

    public void LoadLevel(int levelNumber)
    {
        if (levelNumber <= levels.Count)
        {
            PlayerPrefs.SetInt(levelString, levelNumber);
            SetUpLevel();
        }
    }

    public void LoadNextLevel()
    {
        int currentLevel = PlayerPrefs.GetInt(levelString);
        LoadLevel(currentLevel + 1);
    }

    public void CompleteLevel()
    {
        LoadNextLevel();
    }

    public void RestartLevel()
    {
        int currentLevel = PlayerPrefs.GetInt(levelString);
        LoadLevel(currentLevel);
    }

}
