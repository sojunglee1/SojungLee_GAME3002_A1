using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsUI : MonoBehaviour
{
    //creates the game object variables
    public GameObject instructions;
    private bool isShowing = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if the user press 'ESC' key...
        if (Input.GetKeyDown(KeyCode.Escape)) {

            //...if the instructions isn't showing, then show instructions OR vice versa
            isShowing = !isShowing;
            instructions.SetActive(isShowing);
        }

        //if the user press 'BACKSPACE' key...
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //...loads the main menu scene
            SceneManager.LoadScene("MainMenu");
        }
    }
}
