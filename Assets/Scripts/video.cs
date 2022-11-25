using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class video : MonoBehaviour
{
    public float countTime = 0f;

    // Update is called once per frame
    void Update()
    {
        CountTime();   
    }

    void CountTime()
    {
        countTime += Time.deltaTime;
        if (countTime > 24.0f)
        {
            SceneManager.LoadScene(1);
        }
    }

}
