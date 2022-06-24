using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    
    [SerializeField] private float movementSpeed = 5f;
    private Vector3 currentVelocity = Vector3.zero;
    private Vector2 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(moveDir * movementSpeed, ForceMode.VelocityChange);
    }

    public void HandleMoveInput(InputAction.CallbackContext context)
    { 
        if(context.started)
        {
            moveDir = context.ReadValue<Vector2>();    
         //   moveDir 
        }
        else if (context.canceled)
        {
            moveDir = Vector2.zero;
        }
    }
}
