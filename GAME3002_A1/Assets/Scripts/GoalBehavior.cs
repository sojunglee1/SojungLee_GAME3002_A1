using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GoalBehavior : MonoBehaviour
{
    private GoalBehavior goal3, goal4, goal5;
    public BallPhysics ball;
    public TargetsLeftUI targetsLeft;

    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<BallPhysics>();
        targetsLeft = GameObject.FindGameObjectWithTag("Score").GetComponent<TargetsLeftUI>();

        scene = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        if (scene.name == "Level2")
        {
            if (transform.position.y < 1.0f && targetsLeft.getTargetsLeft() > 3)
            {
                this.GetComponent<Collider>().enabled = false;
            }
            else if (transform.position.y < 1.0f && targetsLeft.getTargetsLeft() <= 3)
            {
                this.GetComponent<Collider>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
        
    }
}
