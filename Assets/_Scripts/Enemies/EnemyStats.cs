using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int healthBack = 1;
    public enum AttackType { Bullet, Sword }
    [SerializeField] AudioClip damageTakenSound;
    public void takeDamage(int damage, AttackType attackType)
    {
        health -= damage;
        GetComponent<AudioSource>().PlayOneShot(damageTakenSound);
        print($"ooo owie ouch  taken: {damage} left: {health}");

        if (attackType == AttackType.Sword)
            GameManager.GM.ChangeHealth(healthBack);

        else if (attackType == AttackType.Bullet)
            GameManager.GM.ChangeHealth(healthBack / 4);

        if (health <= 0)
            Death(attackType);
    }

    private void Death(AttackType attackType)
    {
        GameManager.GM.RemoveEnemy(this.gameObject);
        Destroy(gameObject);
    }
}