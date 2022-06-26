using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField] int HealthLost = 1;
    [Tooltip("In Seconds")]
    [SerializeField] float dotDamage = .5f;
    [SerializeField] AudioClip hitSound;
    AudioSource audioSource;

    private bool inRange = false;
    private float timer = 0;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (inRange)
        {
            timer += Time.deltaTime;
            if (timer >= dotDamage)
            {
                Attack();
                timer = 0;
            }
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
            inRange = true;
            timer = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            timer = 0;
        }
    }

    private void Attack()
    {
        GameManager.GM.ChangeHealth(-1 * HealthLost);
        audioSource.PlayOneShot(hitSound);
    }

}
