using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{ 
    public float moveSpeed = 5f;
    public float boostMultiplier = 2f;
    public KeyCode boostKey = KeyCode.LeftShift; 
    public float rotationSpeed = 10f;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    { 

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;


        float currentSpeed = Input.GetKey(boostKey) ? moveSpeed * boostMultiplier : moveSpeed;

        rb.velocity = moveDirection.normalized * currentSpeed * 150 * Time.deltaTime;

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}