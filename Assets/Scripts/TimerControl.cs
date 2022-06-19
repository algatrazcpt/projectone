using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimerControl : MonoBehaviour
{
    // Start is called before the first frame update
    int maxtime = 60;
    int currentTime = 60;
    public TMP_Text count;
    private void Start()
    {
        TimerStart();
    }
    public void TimerStart()
    {
        StartCoroutine(TimerClick());
    }
    IEnumerator TimerClick()
    {
        while (currentTime > 0)
        {
            count.text= "Time:" + currentTime.ToString();
            currentTime--;
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Time finished");
        GameFinish();
        yield return null;
    }
    void GameFinish()
    {
        currentTime = 60;
        TimerStart();
        GameManagerControl.Instance.LoadNextLevel();
    }
}
