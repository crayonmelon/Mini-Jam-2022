using UnityEngine;

public class JoeVeal : MonoBehaviour
{
    private int bankCount;

    private float Health = 1;

    [SerializeField] private Transform HealthBar;
    [SerializeField] private Animator anim;
    [SerializeField] private Camera deathCam;

    private void Awake()
    {
        bankCount = GetComponentsInChildren<BloodBank>().Length;
    }

    public void TakeDamage()
    {
        Health -= 1f / bankCount;
        HealthBar.localScale = HealthBar.localScale.With(x: Health);

        if (Health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.GM.DestroyLevelEnemies();
        anim.SetTrigger("Die");
        deathCam.enabled = true;
    }
}
