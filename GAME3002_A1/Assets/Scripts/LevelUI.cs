using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class LevelUI : MonoBehaviour
{
    public int level = 1;

    public TextMeshPro m_MyText;

    // Start is called before the first frame update
    void Start()
    {
        m_MyText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1") level = 1; 
        else if (scene.name == "Level2") level = 2;
        else if (scene.name == "Level3") level = 3;
        
        m_MyText.text = "Level: " + level;
    }
}
