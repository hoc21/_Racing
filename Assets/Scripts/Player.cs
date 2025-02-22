using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1500f;
    public float rotationSpeed = 15f;
    public float boostForce = 10f;
    public float boostCooldown = 1f;
    public float maxSpeed = 20f;
    public float friction = 0.98f;

    public WheelJoint2D leftWheel;
    public WheelJoint2D rightWheel;

    private Rigidbody2D rb;
    private bool canBoost = true;

    private float movement = 0f;
    private float rotation = 0f;
    private int selectedCar;
    public GameObject[] carModels;

    public GameObject fireEffect; // Tham chiếu đến hiệu ứng lửa

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fireEffect.SetActive(false); // Ẩn hiệu ứng lúc đầu 
    }

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal") * speed;
        rotation = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && canBoost)
        {
            Boost();
        }
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

            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
            leftWheel.motor = motor;
            rightWheel.motor = motor;
        }

        rb.AddTorque(rotation * rotationSpeed * Time.fixedDeltaTime);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        if (movement == 0 && rotation == 0)
        {
            rb.velocity *= friction;
            rb.angularVelocity *= friction;
        }
    }

    private void Boost()
    {
        rb.velocity += (Vector2)transform.right * boostForce;
        fireEffect.SetActive(true); // Bật hiệu ứng lửa khi boost
        canBoost = false;
        StartCoroutine(ResetBoost());
    }

    private IEnumerator ResetBoost()
    {
        yield return new WaitForSeconds(boostCooldown);
        fireEffect.SetActive(false); // Tắt hiệu ứng lửa khi cooldown xong
        canBoost = true;
    }
}
