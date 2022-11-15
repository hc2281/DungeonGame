using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    public void OnExitGame()
    {
#if UNITY_EDITOR //quit in editor mode
UnityEditor.EditorApplication.isPlaying = false;
#else  // quit after publication 
        Application.Quit();
#endif
    }
}
