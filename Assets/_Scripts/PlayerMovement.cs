using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    
    [SerializeField] private float movementSpeed = 5f;
    private Vector3 currentVelocity = Vector3.zero;
    private Vector3 moveDir;

    [Header("Mouse Look")] 
    [SerializeField] private Transform lookPivot;
    [SerializeField] private LayerMask mouseLookLayer;

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
        rb.velocity = (moveDir * movementSpeed);
    }

    public void HandleMoveInput(InputAction.CallbackContext context)
    { 
        if(context.performed)
        {
            Vector2 inputDir = context.ReadValue<Vector2>();
            moveDir = new Vector3(inputDir.x, 0f, inputDir.y);
        }
        else if (context.canceled)
        {
            moveDir = Vector2.zero;
        }
    }

    public void HandleLookInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(context.ReadValue<Vector2>()), out RaycastHit hitInfo,
                mouseLookLayer);

            lookPivot.transform.LookAt(hitInfo.point);
            lookPivot.SetEulerAngle(x: 0);
        }
    }
}
