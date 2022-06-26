using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] AudioClip bulletSound;
    void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
    }
    IEnumerator Shoot()
    {

        while (true)
        {
            yield return new WaitForSeconds(1f);
            this.GetComponent<AudioSource>().PlayOneShot(bulletSound);
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
