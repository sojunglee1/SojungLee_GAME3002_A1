using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//helps set the button's actions (works for any button)
public class ButtonScript : MonoBehaviour
{
    public Button yourButton;

    // Start is called before the first frame update
    void Start()
    {
        //get the current button
        Button btn = yourButton.GetComponent<Button>();
    }

    public void goToNextScene(string nextScene)
    {
        //changes the scene
        SceneManager.LoadScene(nextScene);
    }

    public void quitGame()
    {
        //quit the game (only for build)
        Application.Quit();
    }
}
