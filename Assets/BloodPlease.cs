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
            if (other.TryGetComponent<BloodBank>(out friendlyLocalCreditUnion))
            {
                if (!friendlyLocalCreditUnion.full)
                    friendlyLocalCreditUnion.prompt.SetActive(true);
                viableDonor = true;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BloodBank"))
        {
            viableDonor = false;
            if (other.TryGetComponent<BloodBank>(out friendlyLocalCreditUnion))
            {
                friendlyLocalCreditUnion.donating = false;
                friendlyLocalCreditUnion.prompt.SetActive(false);
            }
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
