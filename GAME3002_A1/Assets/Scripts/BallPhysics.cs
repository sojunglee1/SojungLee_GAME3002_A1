using System.Runtime.CompilerServices;
using UnityEngine.Assertions;
using UnityEngine;
using UnityEngine.SceneManagement; 

[System.Serializable]
public class BallPhysics : MonoBehaviour
{
    //create private and public variables
    [SerializeField]
    public Vector3 m_vAimOriginalPos;
    public Vector3 m_vOriginalPos;
    [SerializeField]
    private Vector3 m_vInitialVel;
    [SerializeField]
    public Rigidbody m_rb = null;
    [SerializeField]
    public AimBehavior m_AimDisplay;
    private bool m_bIsGrounded = true;
    [SerializeField]
    private TargetsLeftUI targetsLeft;
    private Vector3 vDebugHeading;
    Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        //create the game object for the UI (to get the score / # of targets left)
        targetsLeft = GameObject.FindGameObjectWithTag("Score").GetComponent<TargetsLeftUI>();
        //create the scene object to get the active/current scene
        scene = SceneManager.GetActiveScene();
        
        //creates the game object for the aim
        m_AimDisplay = GameObject.FindGameObjectWithTag("Aim").GetComponent<AimBehavior>();
        
        //sets the variable for the ball's rigidbody
        m_rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rb, "Houston, we've got a problem here! No Rigidbody attached");

        //sets the aim original position to whatever position the aim is currently in (from the editor)
        m_vAimOriginalPos = m_AimDisplay.getPosition();

        //sets the ball original position to whatever position the ball is currently in (from the editor)
        m_vOriginalPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //as long as the aim isn't null & the ball is grounded....
        if (m_AimDisplay != null && m_bIsGrounded)
        {   
            //...set the red line from the ball's position to the target's position
            vDebugHeading = m_AimDisplay.getPosition() - transform.position;
        }

        //if the scene is on Level 1 or 2, set the ground level on 0.5f unit (on the grass)
        if (scene.name == "Level1" || scene.name == "Level2")
        {
            setGroundLevel(0.5f);
        }
        //if the scene is on Level 3, set the ground level on 1.3f unit (on a pedastal)
        else if (scene.name == "Level3")
        {
            setGroundLevel(1.3f);
        }

        //if the ball is in the net (close the user POV)....
        if (transform.position.z <-2.0f)
        {
            //.. the player can move the target...
            m_AimDisplay.moveTarget();
            //.. and shoot the ball with Key 'SPACEBAR' as long as the ball is on the ground
            if (Input.GetKeyDown(KeyCode.Space) && m_bIsGrounded == true)
            {
                OnKickBall();
            }
        }

        //if the ball is not close to the net & the ball is grounded.... 
        if (Input.GetKeyDown(KeyCode.R) && (transform.position.z > 5.0f || m_bIsGrounded == true))
        {
            //...player is able to reset the ball's position (using Reset method)
            Reset();
        }
        
        //always update the ball's x position (X Axis) based on the aim's x position
        transform.position = new Vector3 (m_AimDisplay.getPosition().x, transform.position.y, transform.position.z);
    }

    //Reset method - reset the ball's position back to the original position
    private void Reset() 
    {
        //restricts the ball's movement / can't move the ball
        m_rb.isKinematic = true;
        //sets the aim's current position to the aim's original position
        m_AimDisplay.setPosition(m_vAimOriginalPos);
        //sets the ball's position to the ball's original position
        transform.position = m_vOriginalPos;
    }

    public void OnKickBall()
    {
        /// <summary>
        /// H = Vi^2 * sin^2(theta) / 2g
        /// R = 2Vi^2 * cos(theta) * sin(theta) / g

        /// Vi = sqrt(2gh) / sin(tan^-1(4h/r))
        /// theta = tan^-1(4h/r)

        /// Vy = V * sin(theta)
        /// Vz = V * cos(theta)
        /// </summary>

        // set the Max Height to the aim's height (Y Axis)
        float fMaxHeight = m_AimDisplay.getPosition().y;
        // set the Range from the ball's Z position to the aim's Z position (half distance) and then multiply by 2 (to get full distance)
        float fRange = ((m_AimDisplay.getPosition().z - transform.position.z) * 2);

        // Angle/Theta = tan^-1(4h/r)
        // Use the formula and plug in the varibles
        float fTheta = Mathf.Atan((4 * fMaxHeight) / (fRange));
 
        // Initial Velocity (Vi) = sqrt(2gh) / sin(tan^-1(4h/r))
        // Use the formula and plug in the varibles
        float fInitVelMag = Mathf.Sqrt((2 * Mathf.Abs(Physics.gravity.y) * fMaxHeight)) / Mathf.Sin(fTheta);

        // Initial Velocity (Y Axis) = V * sin(theta)
        m_vInitialVel.y = fInitVelMag * Mathf.Sin(fTheta);
        // Initial Velocity (Z Axis) =  V * cos(theta)
        m_vInitialVel.z = fInitVelMag * Mathf.Cos(fTheta);

        //set the ball's rigidbody velocity to the calculated initial velocity 
        m_rb.velocity = m_vInitialVel;
    }

    //Draws the gizmo
    private void OnDrawGizmos()
    {
        //sets the gizmo's color to red
        Gizmos.color = Color.red;
        //draws the line from the ball's position all the way to the aim's position
        Gizmos.DrawLine(transform.position + vDebugHeading, transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        //counts down the targets
        targetsLeft.setTargetsLeft(1);

        //if the targets go down to 0, change to the next level based on the previous level
            //e.g.) If there aren't any targets left, change Level 1 to Level 2
        setLevel(0, "Level1", "Level2");
            //e.g.) If there aren't any targets left, change Level 2 to Level 3
        setLevel(0, "Level2", "Level3");
            //e.g.) If there aren't any targets left, change Level 3 to Level Game Won
        setLevel(0, "Level3", "GameWon");
    }

    //helps set the ball's ground level
    private void setGroundLevel(float number)
    {
        // if the ball's position height is less or equal to the ground level (number)
        if (transform.position.y <= number) 
        {
            // ball is able to move
            m_rb.isKinematic = false;
            // ball is grounded
            m_bIsGrounded = true;
        }
        // if the ball is higher than the ground level (number)...
        else if (transform.position.y > number)
        {
            // ... ball is no longer grounded
            m_bIsGrounded = false;
        }
    }

    //helps change to the next level based on the number of targets left & current level
    private void setLevel(int targets, string currentLevel, string nextLevel)
    {
        if (targetsLeft.getTargetsLeft() == targets && scene.name == currentLevel)
        {
            targetsLeft.LevelChange(nextLevel);
        }
    }
    
}
