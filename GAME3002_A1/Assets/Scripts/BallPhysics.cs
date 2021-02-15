using System.Runtime.CompilerServices;
using UnityEngine.Assertions;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class BallPhysics : MonoBehaviour
{
    [SerializeField]
    public Vector3 m_vAimOriginalPos;
    public Vector3 m_vOriginalPos;
    [SerializeField]
    private Vector3 m_vInitialVel;
    [SerializeField]
    public Rigidbody m_rb = null;
    public AimBehavior m_AimDisplay;
    private bool m_bIsGrounded = true;
    public TargetsLeftUI score;
    private Vector3 vDebugHeading;



    Scene scene;


    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        
        m_AimDisplay = GameObject.FindGameObjectWithTag("Aim").GetComponent<AimBehavior>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<TargetsLeftUI>();

        m_rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rb, "Houston, we've got a problem here! No Rigidbody attached");

        m_vAimOriginalPos = m_AimDisplay.getPosition();
        m_vOriginalPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (m_AimDisplay != null && m_bIsGrounded)
        {
            vDebugHeading = m_AimDisplay.getPosition() - transform.position;
        }
        if (scene.name == "Level1" || scene.name == "Level2")
        {
            setGroundLevel(0.5f);
        }
        else if (scene.name == "Level3")
        {
            setGroundLevel(1.3f);
        }

        if (transform.position.z <-2.0f)
        {
            m_AimDisplay.moveTarget();

            if (Input.GetKeyDown(KeyCode.Space) && m_bIsGrounded == true)
            {
                OnKickBall();
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && (transform.position.z > 5.0f || m_bIsGrounded == true))
        {
            Reset();
        }
        
        transform.position = new Vector3 (m_AimDisplay.getPosition().x, transform.position.y, transform.position.z);
    }

    private void Reset() 
    {
        m_rb.isKinematic = true;

        m_AimDisplay.setPosition(m_vAimOriginalPos);
        
        transform.position = m_vOriginalPos;
    }

    public void OnKickBall()
    {
        // H = Vi^2 * sin^2(theta) / 2g
        // R = 2Vi^2 * cos(theta) * sin(theta) / g

        // Vi = sqrt(2gh) / sin(tan^-1(4h/r))
        // theta = tan^-1(4h/r)

        // Vy = V * sin(theta)
        // Vz = V * cos(theta)

        float fMaxHeight = m_AimDisplay.getPosition().y;
        float fRange = ((m_AimDisplay.getPosition().z - transform.position.z) * 2);
        float fTheta = Mathf.Atan((4 * fMaxHeight) / (fRange));
 
        float fInitVelMag = Mathf.Sqrt((2 * Mathf.Abs(Physics.gravity.y) * fMaxHeight)) / Mathf.Sin(fTheta);

        m_vInitialVel.y = fInitVelMag * Mathf.Sin(fTheta);
        m_vInitialVel.z = fInitVelMag * Mathf.Cos(fTheta);

        m_rb.velocity = m_vInitialVel;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + vDebugHeading, transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        score.setTargetsLeft(1);

        setLevel(0, "Level1", "Level2");
        setLevel(0, "Level2", "Level3");
        setLevel(0, "Level3", "GameWon");
    }

    private void setGroundLevel(float number)
    {
        if (transform.position.y <= number) 
        {
            m_rb.isKinematic = false;
            m_bIsGrounded = true;
        }
        else if (transform.position.y > number)
        {
            m_bIsGrounded = false;
        }
    }

    private void setLevel(int targets, string currentLevel, string nextLevel)
    {
        if (score.getTargetsLeft() == targets && scene.name == currentLevel)
        {
            score.LevelChange(nextLevel);
        }
    }
    
}
