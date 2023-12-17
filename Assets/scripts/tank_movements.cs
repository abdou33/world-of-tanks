using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_movements : MonoBehaviour
{
    public float movespeed = 5.0f;
    public float rotationspeed = 120.0f;
    public GameObject[] leftwheels;
    public GameObject[] rightwheels;
    public float wheelsrotationspeed = 200.0f;
    private Rigidbody rb;
    private float moveInput;
    private float rotationInput;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        RotateWheels(moveInput, rotationInput);
    }
    void FixedUpdate()
    {
        moveTankobj(moveInput);
        rotateTankobj(rotationInput);
    }
    void moveTankobj(float input)
    {
        Vector3 moveDirection = transform.forward * input * movespeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);
    }
    void rotateTankobj(float input)
    {
        float rotation = input * rotationspeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
    void RotateWheels(float moveInput, float rotationInput)
    {
        float wheelRotation = moveInput * wheelsrotationspeed * Time.deltaTime;

        foreach (GameObject wheel in leftwheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation - rotationInput * wheelsrotationspeed * Time.deltaTime, 0.0f, 0.0f);
                // wheelRotation - rotationInput * wheelsrotationspeed * Time.deltaTime
            }
        }

        foreach (GameObject wheel in rightwheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation - rotationInput * wheelsrotationspeed * Time.deltaTime, 0.0f, 0.0f);
                // wheelRotation - rotationInput * wheelsrotationspeed * Time.deltaTime
            }
        }
    }
}
