using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class ScoreUI : MonoBehaviour
{
    public int score = 0;

    public TextMeshPro m_MyText;

    // Start is called before the first frame update
    void Start()
    {
        m_MyText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        m_MyText.text = "Score: " + score;
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void LevelChange(string gameSceneName)
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public int getScore()
    {
        return score;
    }
}
