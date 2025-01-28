using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 4;

    //Het animator component wordt hier gedefinieerd. 
    //Hierdoor kunnen we deze in verschillende functies in de class gebruiken.
    private Animator _animator;
    private Rigidbody _rigidbody;
    private bool isGrounded;
    void Start()
    {
        //Het animator component wordt uit het object opgehaald.
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }


    void Update()
    {
        Vector3 movement = new Vector3(0, 0, 0);
        float msIncrease = 1;
        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward * movementSpeed * Time.deltaTime;
            _animator.SetFloat("speed", 1);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                msIncrease = 2;
                _animator.SetFloat("speed", 2);
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _animator.SetFloat("speed", 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }
        transform.position += movement.normalized * movementSpeed * Time.deltaTime * msIncrease;
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * 125);
            isGrounded = false;
            _animator.SetTrigger("Jump");

        }
        else if (isGrounded)
        {
            _animator.ResetTrigger("Jump");
        }

        
    }
}
