using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    
    void OnEnable()
    {
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        Vector3 dir = (transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized;

        while (true)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(bullet, transform.position, dir);
        }
    }
}
