using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class AimBehavior : MonoBehaviour
{
    //create private and public variables
    public Vector3 m_vTargetPos;
    private BallPhysics ball;
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        //created ball object
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<BallPhysics>();

        //created scene object to get current/active scene
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        //setting the target's original position to the starting position
        //this is so that when I change the target position in the editor, the game will start on that new position
        m_vTargetPos = transform.position;
    }

    //getter/accessor method for the target position
    public Vector3 getPosition()
    {
        return transform.position;
    }

    //setter/mutator method for the target position
    public void setPosition(Vector3 postion)
    {
        transform.position = postion;
    }

    //takes in the user input to move the aim (contains constrictions to how far user can move the aim)
    public void moveTarget()
    {   
        //unlocks special ability in Level 3 to move the aim in the z axis (needed to control the ball's range)
        if (scene.name == "Level3")
        {
            //Key 'Q'
            if (Input.GetKeyDown(KeyCode.Q))
            {  
                //moves the aim closer to the ball (+Z Axis)
                transform.position = new Vector3 (m_vTargetPos.x, m_vTargetPos.y, m_vTargetPos.z-=0.1f);
            }
            //Key 'E'
            if (Input.GetKeyDown(KeyCode.E))
            {  
                //moves the aim further away from the ball (-Z Axis)
                transform.position = new Vector3 (m_vTargetPos.x, m_vTargetPos.y, m_vTargetPos.z+=0.1f);
            }
        }
        //Key 'W'
        if (Input.GetKeyDown(KeyCode.W))
        {  
            //....as long as the aim is less than 3.0f in the Y Axis...
            if (transform.position.y < 3)
            {
                //...the user can move the aim up (+Y Axis)
                transform.position = new Vector3 (m_vTargetPos.x, m_vTargetPos.y+=0.1f, m_vTargetPos.z);
            }    
        }

        //Key 'A'
        if (Input.GetKeyDown(KeyCode.A))
        {
            //...as long as the aim is greater than -2.0f in the X axis...
            if (transform.position.x >= -2)
            {
                //...the user can move the aim to the left (-X Axis)
                transform.position = new Vector3 (m_vTargetPos.x-=0.1f, m_vTargetPos.y, m_vTargetPos.z);
            }
        }

        //Key 'S'
        if (Input.GetKeyDown(KeyCode.S))
        {
            //...as long as the aim is a little (0.25f units) higher than the ball...
            if (transform.position.y > ball.transform.position.y + 0.25f)
            {
                //... the user can move the aim down (-Y Axis)
                transform.position = new Vector3 (m_vTargetPos.x, m_vTargetPos.y-=0.1f, m_vTargetPos.z);
            }
        }

        //Key 'D'
        if (Input.GetKeyDown(KeyCode.D))
        {
            //...as long as the aim is less than 2.0f units in the X Axis...
            if (transform.position.x <= 2)
            {
                //... the user can move the aim to the right (+X Axis)
                transform.position = new Vector3 (m_vTargetPos.x+=0.1f, m_vTargetPos.y, m_vTargetPos.z);
            }
            
        }
    }
}
