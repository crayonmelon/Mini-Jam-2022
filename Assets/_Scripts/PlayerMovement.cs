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
    private Vector3 moveDir;

    [Header("Ground Checks")] 
    [SerializeField] private LayerMask groundLayer;
    private bool rightCheck, leftCheck, upCheck, downCheck;

    [SerializeField] private Transform up, down, left, right;
    
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

    private void Update()
    {
        GroundChecks();
    }

    void FixedUpdate()
    {
        if (moveDir.x > 0 && !rightCheck) moveDir = moveDir.With(x: 0);
        else if (moveDir.x < 0 && !leftCheck) moveDir = moveDir.With(x: 0);
        if (moveDir.z > 0 && !upCheck) moveDir = moveDir.With(z: 0);
        else if (moveDir.z < 0 && !downCheck) moveDir = moveDir.With(z: 0);
        if(this.GetComponent<playerSwapSprites>() != null)
        {
            this.GetComponent<playerSwapSprites>().whichDirectionShouldBeFacing(moveDir);

        }

        rb.velocity = (moveDir * movementSpeed);
    }

    private void GroundChecks()
    {
        rightCheck = Physics.Raycast(right.position, Vector3.down, 3f, groundLayer);
        leftCheck = Physics.Raycast(left.position, Vector3.down, 3f, groundLayer);
        upCheck = Physics.Raycast(up.position, Vector3.down, 3f, groundLayer);
        downCheck = Physics.Raycast(down.position, Vector3.down, 3f, groundLayer);
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
                Mathf.Infinity, mouseLookLayer);

            lookPivot.transform.LookAt(hitInfo.point);
            lookPivot.SetEulerAngle(x: 0);
        }
    }
}
