using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyHealth health;
    public int damage = 1;

    private void Awake()
    {
        health = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerHealth = collision.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            health.TakeDamage(1000);
        }
    }
}
