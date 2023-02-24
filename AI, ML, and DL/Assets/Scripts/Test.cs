using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Rigidbody rb;


    [SerializeField]
    Vector3 velocity = Vector3.zero;
    [SerializeField]
    Vector3 position = Vector3.zero;
    [SerializeField]
    float speed = 0.0f;
    [SerializeField]
    float acceleration = 0.0f;
    [SerializeField]
    float rotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation_Input = Input.GetAxis("Rotate");
        if (rotation_Input != 0 ) 
        {
            float rotation_Amount = rotation * Time.deltaTime;
            
            if (rotation_Amount < 0)
            {
                rotation_Amount *= -1;
            }

            transform.Rotate(Vector3.forward, rotation_Amount);
            
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            velocity.x = Mathf.Cos(zRotation);
            velocity.y = Mathf.Sin(zRotation);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") != 0)
        {
            rb.AddForce(speed * velocity, ForceMode.Force);
        }
    }
}
