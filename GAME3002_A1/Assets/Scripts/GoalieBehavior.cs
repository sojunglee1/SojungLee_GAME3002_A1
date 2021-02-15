using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GoalieBehavior : MonoBehaviour
{
    //MIGHT NEED - Let's the goalie to move back and forth
        //private float m_fXPosition = 0.0f;
        //private float step = 0.01f;

    //creates the scene object
    public Scene scene;
    //creates the UI object
    public TargetsLeftUI score;

    // Start is called before the first frame update
    void Start()
    {
        //instantiates the scene (get the current scene) & UI objects (for the # of targets left)
        scene = SceneManager.GetActiveScene();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<TargetsLeftUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the scene is on Level 2 & there are at least three targets left...
        if (scene.name == "Level2" && score.getTargetsLeft() == 3)
        {
            //move the goalie up to reveal the bottom targets
            transform.position = new Vector3 (transform.position.x, 1.75f, transform.position.z);
        }

        //MIGHT NEED - Let's the goalie to move back and forth
            //m_fXPosition += step;
            //if (m_fXPosition > 2.5f || m_fXPosition < -2.5f) step *= -1;
            //transform.position = new Vector3 (m_fXPosition,  transform.position.y,  transform.position.z);

    }
}
