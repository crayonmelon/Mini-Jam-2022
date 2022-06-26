using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float lifeSpan = .5f;

    float timer = 0;
    
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * Speed;
        timer += Time.deltaTime;

        if (timer >= lifeSpan)
        {
            GameManager.GM.RemoveEnemy(gameObject);
            Destroy(gameObject);
        }
    }
}