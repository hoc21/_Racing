using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1500f;
    public float rotationSpeed = 15f;

    public WheelJoint2D leftWheel;
    public WheelJoint2D rightWheel;

    private Rigidbody2D rb;

    private float movement = 0f;
    private float rotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal") * speed;
        rotation = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (movement == 0f)
        {
            leftWheel.useMotor = false;
            rightWheel.useMotor = false;
        }
        else
        {
            leftWheel.useMotor = true;
            rightWheel.useMotor = true;

            JointMotor2D motor = new JointMotor2D{motorSpeed = movement, maxMotorTorque = 10000};
            leftWheel.motor = motor;
            rightWheel.motor = motor;
        }
        rb.AddTorque(rotation * rotationSpeed * Time.fixedDeltaTime);
    }
}
