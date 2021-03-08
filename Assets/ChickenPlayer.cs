using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ChickenPlayer : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float m_SidewaysSpeed;
    float m_UpwardsForce;
    float m_AirJumpForce;
    int m_MaxJumps;
    int jumpsAvailable;

    void Start()
    {
        // Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        // Set the speed of the GameObject
        m_SidewaysSpeed = 5.0f;
        m_UpwardsForce = 5.0f;
        m_AirJumpForce = 1.0f;
        m_MaxJumps = 2;
    }

    void OnCollisionStay()
    {
        jumpsAvailable = m_MaxJumps;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0, 0, Time.deltaTime * m_SidewaysSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(0, 0, -Time.deltaTime * m_SidewaysSpeed, Space.World);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (jumpsAvailable == m_MaxJumps)
            {
                m_Rigidbody.AddForce(transform.up * m_UpwardsForce, ForceMode.Impulse);
                jumpsAvailable--;
            }
            else if (jumpsAvailable > 0)
            {
                m_Rigidbody.AddForce(transform.up * m_AirJumpForce, ForceMode.Impulse);
                jumpsAvailable--;
            }
        }
    }
}