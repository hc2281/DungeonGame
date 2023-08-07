using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fail : MonoBehaviour
{
    public int TotalTime = 180;
    public Text TimeText;
    private int mumite;
    private int second;


    public IEnumerator startTime()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (TotalTime >= 0)
        {
            yield return waitForSeconds;
            TotalTime--;
            TimeText.text = "Time:" + TotalTime;

            if (TotalTime <= 0)
            {
                SceneManager.LoadScene(5);
                Debug.Log("Time is up!");
            }
            mumite = TotalTime / 60; 
            second = TotalTime % 60;
            string length = mumite.ToString();

            if (second >= 10)
            {
                TimeText.text = "0" + mumite + ":" + second;
            }

            else
                TimeText.text = "0" + mumite + ":0" + second;
        }
    }    
    
    void Start()
    {
        StartCoroutine(startTime());
    }

}
