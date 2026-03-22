using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint = 3;

    public System.Action onDead;
    public System.Action onHealthChanged;   // thêm dòng này

    public int healthPoint;

    private void Start()
    {
        healthPoint = defaultHealthPoint;
        onHealthChanged?.Invoke(); // cập nhật thanh máu lúc bắt đầu
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;

        onHealthChanged?.Invoke(); // cập nhật thanh máu

        if (healthPoint <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 1);

        Destroy(gameObject);

        onDead?.Invoke();   // báo cho game biết player chết
    }

}