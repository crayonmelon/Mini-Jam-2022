using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] int healthTake = 5;
    [SerializeField] GameObject bullet;
    [SerializeField] AudioClip bulletSound;

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
            this.GetComponent<AudioSource>().PlayOneShot(bulletSound);
            GameManager.GM.ChangeHeath(-1 * healthTake);
            Instantiate(bullet, transform.position, transform.rotation);
        }
        else
        {
            Debug.Log($"NOT ENOUGH HEALTH {GameManager.GM.Health}");
        }
    }
}