using System.Globalization;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMovement : MonoBehaviour
{
    private BallPhysics ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           //transform.position = new Vector3 (0.0f, 0.0f, 0.0f);

           //ball.m_TargetDisplay.transform.position = new Vector3(ball.m_vTargetPos.x++, ball.m_TargetDisplay.transform.position.y, ball.m_TargetDisplay.transform.position.z);
        }
        
    }
}
