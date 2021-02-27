using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ChickenPlayer : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float m_ForwardSpeed;
    float m_BackwardSpeed;
    float m_RotateSpeed;
    float m_UpwardsForce;
    bool isGrounded;

    void Start()
    {
        // Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        // Set the speed of the GameObject
        m_ForwardSpeed = 2.0f;
        m_BackwardSpeed = 2.0f;
        m_RotateSpeed = 120.0f;
        m_UpwardsForce = 3.0f;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
	    // Move the Rigidbody forwards constantly at speed you define (the
            // blue arrow axis in Scene view)
            // m_Rigidbody.velocity = transform.forward * m_Speed;
            m_Rigidbody.AddForce(transform.forward * m_ForwardSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
	    // Move the Rigidbody backwards constantly at the speed you define
            // (the blue arrow axis in Scene view)
            // m_Rigidbody.velocity = -transform.forward * m_Speed;
            m_Rigidbody.AddForce(-transform.forward * m_BackwardSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate the sprite about the Y axis in the positive direction
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * m_RotateSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate the sprite about the Y axis in the negative direction
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * m_RotateSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            m_Rigidbody.AddForce(transform.up * m_UpwardsForce, ForceMode.Impulse);
            isGrounded = false;
	}
    }
}
