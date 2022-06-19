using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerControl : MonoBehaviour
{
    public static GameManagerControl Instance { get; private set; }
    public List<Level> levels;
    private int currentLevel;
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

        int levelNumber = PlayerPrefs.GetInt(levelString, 0);
        if (levelNumber <= levels.Count && levelNumber != 0)
        {
            LoadLevel(levelNumber);
            currentLevel = levelNumber;
            Debug.Log("level loaded" + currentLevel);
        }
        else
        {
            LoadLevel(0);
            currentLevel = 0;
        }

    }

    private void SetUpLevel()
    {
        if (levels[currentLevel].patient1 != null)
        {
            patient1Paper.GetComponent<InfoPaper>().patient = levels[currentLevel].patient1;
        }
        if (levels[currentLevel].patient2 != null)
        {
            patient2Paper.GetComponent<InfoPaper>().patient = levels[currentLevel].patient2;
        }
        GameSceneUIControl.Instance.SetDialogue(levels[currentLevel]);
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
        int currentLevel = PlayerPrefs.GetInt(levelString, 0);
        LoadLevel(currentLevel + 1);
    }

    public void CompleteLevel()
    {
        LoadNextLevel();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("MainGameScene");

    }


}
