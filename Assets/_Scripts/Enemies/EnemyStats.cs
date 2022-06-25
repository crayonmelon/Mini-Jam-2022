using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int health = 100;

    public void takeDamage(int damage)
    {
        health -= damage;

        print($"ooo owie ouch  taken: {damage} left: {health}");
     
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        GameManager.GM.RemoveEnemy(this.gameObject);
        Destroy(gameObject);
    }
}