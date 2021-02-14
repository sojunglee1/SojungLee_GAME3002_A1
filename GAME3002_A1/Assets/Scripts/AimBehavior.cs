using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBehavior : MonoBehaviour
{
    public Vector3 m_vTargetPos;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3 (0.0f, 1.5f, 0.0f);
        //transform.localScale = new Vector3(1.0f, 0.01f, 1.0f);
        //transform.rotation = Quaternion.Euler(90f, 0.0f, 0.0f);
        //GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_vTargetPos = transform.position;
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }

    public void setPosition(Vector3 postion)
    {
        transform.position = postion;
    }

    public void moveTarget()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3 (m_vTargetPos.x, m_vTargetPos.y+=0.1f, m_vTargetPos.z);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3 (m_vTargetPos.x-=0.1f, m_vTargetPos.y, m_vTargetPos.z);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3 (m_vTargetPos.x, m_vTargetPos.y-=0.1f, m_vTargetPos.z);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3 (m_vTargetPos.x+=0.1f, m_vTargetPos.y, m_vTargetPos.z);
        }
    }
}
