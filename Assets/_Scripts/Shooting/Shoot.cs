using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] int healthTake = 5;
    [SerializeField] GameObject bullet;
 
    public void HandleShootInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            shooting();
        }
    }

    private void shooting()
    {
        if (GameManager.GM.Health > healthTake)
        {
            GameManager.GM.ChangeHeath(-1 * healthTake);
            Instantiate(bullet, transform.position, transform.rotation);
        }
        else
        {
            Debug.Log($"NOT ENOUGH HEALTH {GameManager.GM.Health}");
        }
    }
}