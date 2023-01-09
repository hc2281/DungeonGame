using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject DialogUI; //Dialogue Panel
    public Text DialogText; //Text in panel
    public TextAsset textfile; //text file
    public int currentIndex;//Dialogue index
    public float textSpeed = 0.05f;
    public float waitSecond = 2.5f;

    List<string> DialogTextList = new List<string>();

    bool isNotTyping = true;

    void Awake()
    {
        GetTextFromFile(textfile);
    }

    void GetTextFromFile(TextAsset file)
    {
        DialogTextList.Clear();
        currentIndex = 0;
        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            DialogTextList.Add(line);
        }
    }

    IEnumerator SetTextUI() 
    {
        DialogText.text = "";

        isNotTyping = false;

        for (int i = 0; i < DialogTextList[currentIndex].Length; i++)
        {
            DialogText.text += DialogTextList[currentIndex][i];
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(waitSecond);
        currentIndex++;
        isNotTyping = true;
    }

    void Update()
    {
        textSpeed = 0.05f;
        if(isNotTyping && currentIndex < DialogTextList.Count)
        {
            StartCoroutine(SetTextUI());
        }
        if(isNotTyping && currentIndex == DialogTextList.Count)
        {
            SkipDialogue();
        }

    }

    public void SkipDialogue()
    {
        SceneManager.LoadScene(1);
        currentIndex = 0;
        return;
    }
}
