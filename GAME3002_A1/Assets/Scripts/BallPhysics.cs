using UnityEngine.Assertions;
using UnityEngine;


public class BallPhysics : MonoBehaviour
{
    [SerializeField]
    public Vector3 m_vTargetOriginalPos = new Vector3 (0.0f, 1.5f, 0.0f);
    [SerializeField]
    private Vector3 m_vInitialVel;
    [SerializeField]

    public Rigidbody m_rb = null;
    public AimBehavior m_TargetDisplay;

    private bool m_bIsGrounded = true;

    private float m_fDistanceToTarget = 0f;

    public ScoreUI score;

    private Vector3 vDebugHeading;

    // Start is called before the first frame update
    void Start()
    {
        m_TargetDisplay = GameObject.FindGameObjectWithTag("Aim").GetComponent<AimBehavior>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreUI>();

        m_rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rb, "Houston, we've got a problem here! No Rigidbody attached");

        //CreateTargetDisplay();
        m_fDistanceToTarget = (m_TargetDisplay.getPosition() - transform.position).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (m_TargetDisplay != null && m_bIsGrounded)
        {
            vDebugHeading = m_TargetDisplay.getPosition() - transform.position;
        }

        if (transform.position.y <= 0.5f) 
        {
            m_rb.isKinematic = false;
            m_bIsGrounded = true;
        }
        else if (transform.position.y > 0.5f)
        {
            m_bIsGrounded = false;
        }

        if (transform.position.z == -5.0f)
        {
            m_TargetDisplay.moveTarget();

            if (Input.GetKeyDown(KeyCode.Space) && m_bIsGrounded == true)
            {
                OnKickBall();
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && m_bIsGrounded == true)
        {
            Reset();
        }
        
        transform.position = new Vector3 (m_TargetDisplay.getPosition().x, transform.position.y, transform.position.z);
    }

    private void Reset() 
    {
        m_rb.isKinematic = true;
        transform.position = new Vector3 (0.0f, 0.25f, -5.0f);
        m_TargetDisplay.setPosition(m_vTargetOriginalPos);
    }

    public void OnKickBall()
    {
        // H = Vi^2 * sin^2(theta) / 2g
        // R = 2Vi^2 * cos(theta) * sin(theta) / g

        // Vi = sqrt(2gh) / sin(tan^-1(4h/r))
        // theta = tan^-1(4h/r)

        // Vy = V * sin(theta)
        // Vz = V * cos(theta)

        float fMaxHeight = m_TargetDisplay.getPosition().y;
        float fRange = (m_fDistanceToTarget * 2);
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
        score.AddScore(1);

        if (score.getScore() == 3)
        {
            
            score.LevelChange("Level2");
        }
    }

    
}
