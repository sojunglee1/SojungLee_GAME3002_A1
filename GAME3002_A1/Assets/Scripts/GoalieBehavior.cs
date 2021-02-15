using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GoalieBehavior : MonoBehaviour
{
    //private float m_fXPosition = 0.0f;
    
    //private float step = 0.01f;

    public Scene scene;

    public TargetsLeftUI score;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<TargetsLeftUI>();
    }

    // Update is called once per frame
    void Update()
    {

        //m_fXPosition += step;

        //if (m_fXPosition > 2.5f || m_fXPosition < -2.5f) step *= -1;

        //transform.position = new Vector3 (m_fXPosition,  transform.position.y,  transform.position.z);

        if (scene.name == "Level2" && score.getTargetsLeft() == 3)
        {
            transform.position = new Vector3 (transform.position.x, 1.75f, transform.position.z);
        }

    }
}
