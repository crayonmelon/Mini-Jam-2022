using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BloodPlease : MonoBehaviour
{
    private bool viableDonor = false;
    private BloodBank friendlyLocalCreditUnion;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BloodBank"))
        {
            viableDonor = true;
            friendlyLocalCreditUnion = other.GetComponent<BloodBank>();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BloodBank"))
        {
            viableDonor = false;
            friendlyLocalCreditUnion.donating = false;
        }
    }

    public void HandleDonationInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (viableDonor)
            {
                friendlyLocalCreditUnion.donating = true;
            }
        }
        else if (context.canceled)
        {
            if (viableDonor)
            {
                friendlyLocalCreditUnion.donating = false;
            }
        }
    }
}