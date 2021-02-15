using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

// controls the targets behavior
public class GoalBehavior : MonoBehaviour
{
    //creates the ball object
    public BallPhysics ball;
    //creates the UI to get the number of targets left
    public TargetsLeftUI targetsLeft;
    //create the scene object
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        //instantiates the ball object to the proper game object
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<BallPhysics>();
        //instantiates the UI to the proper game object
        targetsLeft = GameObject.FindGameObjectWithTag("Score").GetComponent<TargetsLeftUI>();
        //instantiates the scene object to get the active/current scene
        scene = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        //if the scene is level 2...
        if (scene.name == "Level2")
        {
            //...if the target is on the bottom and all the targets on top aren't gone...
            if (transform.position.y < 1.0f && targetsLeft.getTargetsLeft() > 3)
            {
                //...then set the collider to false (ball can't collide with bottom targets)
                this.GetComponent<Collider>().enabled = false;
            }
            //...if the target is on the bottom and all the targets on top ARE gone...
            else if (transform.position.y < 1.0f && targetsLeft.getTargetsLeft() <= 3)
            {
                //...then set the collider to true (ball can collide with bottom targets)
                this.GetComponent<Collider>().enabled = true;
            }
        }
    }

    //if the ball hits the targets with the right conditions...
    private void OnTriggerEnter(Collider other) {
        //...destroy this object
        Destroy(this.gameObject);
        
    }
}
