using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ChickenPlayer : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float m_SidewaysSpeed;
    float m_UpwardsForce;
    bool isGrounded;

    void Start()
    {
        // Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        // Set the speed of the GameObject
        m_SidewaysSpeed = 5.0f;
        m_UpwardsForce = 2.5f;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
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

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && isGrounded)
        {
            m_Rigidbody.AddForce(transform.up * m_UpwardsForce, ForceMode.Impulse);
            isGrounded = false;
	}
    }
}
