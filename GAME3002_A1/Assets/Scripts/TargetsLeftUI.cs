using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

[System.Serializable]
public class TargetsLeftUI : MonoBehaviour
{
    // sets the number of targets left
    [SerializeField]
    private int TargetsLeft = 6;
    //creates the text object
    [SerializeField]
    public TextMeshPro m_MyText;

    // Start is called before the first frame update
    void Start()
    {
        //instantiates the text object
        m_MyText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        //sets the text object's text to the int (targets left)
        m_MyText.text = "Balls Left: " + TargetsLeft;
    }

    //setter/mutator method of # of targets left
    public void setTargetsLeft(int value)
    {
        //decreases the value of # of targets left
        TargetsLeft -= value;
    }

    //changes the level (for other game objects based on 'TargetsLeft' variable)
    public void LevelChange(string gameSceneName)
    {
        SceneManager.LoadScene(gameSceneName);
    }

    //getter/accessor method of the # of targets left
    public int getTargetsLeft()
    {
        return TargetsLeft;
    }
}
