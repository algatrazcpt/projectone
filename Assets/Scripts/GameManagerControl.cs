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
        Debug.Log(levelNumber);
        if (levelNumber <= levels.Count && levelNumber != 0)
        {
            LoadLevel(levelNumber);
            currentLevel = levelNumber;
            Debug.Log("level loaded number" + currentLevel);
        }
        else
        {
            LoadLevel(0);
            currentLevel = 0;
            Debug.Log("level loaded number" + currentLevel);
        }

    }

    private void SetUpLevel(Level lvl)
    {
        if (lvl.patient1 != null)
        {
            patient1Paper.GetComponent<InfoPaper>().patient = lvl.patient1;
        }
        if (lvl.patient2 != null)
        {
            patient2Paper.GetComponent<InfoPaper>().patient = lvl.patient2;
        }
        GameSceneUIControl.Instance.SetDialogue(lvl);
    }

    public void LoadLevel(int levelNumber)
    {
        if (levelNumber <= levels.Count)
        {
            Level nowLevel = levels[levelNumber];
            SetUpLevel(nowLevel);
        }
    }

    public void LoadNextLevel()
    {
        int currentLevel = PlayerPrefs.GetInt(levelString, 0);
        LoadLevel(currentLevel + 1);
    }

    public void CompleteLevel()
    {
        currentLevel++;
        if (currentLevel == 6)
        {
            SceneManager.LoadScene("MainFinishScene");
            return;
        }
        PlayerPrefs.SetInt(levelString, currentLevel);
        Debug.Log("level saved number" + currentLevel);
        SceneManager.LoadScene("MainGameScene");

    }

}
