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
        
    }

    public void HandleMoveInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Vector2 moveDir = context.ReadValue<Vector2>();
            
            rb.AddForce(moveDir * movementSpeed, ForceMode.VelocityChange);
        }
    }
}
