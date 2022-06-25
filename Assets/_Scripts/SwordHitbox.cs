using UnityEngine;
    public class SwordHitbox : MonoBehaviour
    {
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("EnemyHitbox"))
            {
                other.GetComponent<EnemyStats>().takeDamage(10);
            }
        }    }