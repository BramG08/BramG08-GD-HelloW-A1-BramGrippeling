using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float boostMultiplier = 2f;
    public KeyCode boostKey = KeyCode.LeftShift; 

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;

    private void Update()
    {
      
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

     
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

      
        float currentSpeed = Input.GetKey(boostKey) ? moveSpeed * boostMultiplier : moveSpeed;


        transform.position += moveDirection.normalized * currentSpeed * Time.deltaTime;
    }
}
