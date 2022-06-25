using UnityEngine;
    public class EnemyStats : MonoBehaviour
    {
        private int health = 100;
        private int maxHealth = 100;

        public void takeDamage(int damage)
        {
            health -= damage;

            print($"ooo owie ouch  taken: {damage}   left: {health}");
            
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }