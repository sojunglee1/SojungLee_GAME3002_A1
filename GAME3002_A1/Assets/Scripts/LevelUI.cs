using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

//helps the UI for the level number
public class LevelUI : MonoBehaviour
{
    // starting level is 1
    public int level = 1;
    // creates the text variable
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
        //gets the current/active scene
        Scene scene = SceneManager.GetActiveScene();

        //changes the text based on the scene name
        if (scene.name == "Level1") level = 1; 
        else if (scene.name == "Level2") level = 2;
        else if (scene.name == "Level3") level = 3;
        
        //update the text
        m_MyText.text = "Level: " + level;
    }
}
