using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalieBehavior : MonoBehaviour
{
    private float m_fXPosition = 0.0f;
    
    private float step = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        m_fXPosition += step;

        if (m_fXPosition > 3.5f || m_fXPosition < -3.5f) step *= -1;

        transform.position = new Vector3 (m_fXPosition,  transform.position.y,  transform.position.z);
    }
}
