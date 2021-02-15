using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour
{
    public Button yourButton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
    }

    public void goToNextScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
}
