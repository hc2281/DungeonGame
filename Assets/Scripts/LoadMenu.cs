using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    private float countTime = 0f;

    // Update is called once per frame
    void Update()
    {
        CountTime();   
    }
    //if counttime passes, the scene will load into loadscene
    void CountTime()
    {
        countTime += Time.deltaTime;
        if (countTime > 15.0f)
        {
            SceneManager.LoadScene(0); //loads menu screen
        }
    }

}
