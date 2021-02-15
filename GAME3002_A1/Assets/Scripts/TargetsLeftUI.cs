using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class TargetsLeftUI : MonoBehaviour
{
    private int TargetsLeft = 6;

    public TextMeshPro m_MyText;

    // Start is called before the first frame update
    void Start()
    {
        m_MyText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        m_MyText.text = "Score: " + TargetsLeft;
    }

    public void setTargetsLeft(int value)
    {
        TargetsLeft -= value;
    }

    public void LevelChange(string gameSceneName)
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public int getTargetsLeft()
    {
        return TargetsLeft;
    }
}
