using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float flySpeed = 10f;
    public int damage = 1;

    [Header("Destroy Settings")]
    public float lifeTime = 5f;   // Tự hủy sau 5 giây nếu không trúng gì

    void Start()
    {
        // Tự hủy sau một khoảng thời gian để tránh rác trong scene
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Di chuyển viên đạn theo trục Y (game top-down)
        transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Nếu va chạm Player thì bỏ qua
        if (collision.GetComponent<PlayerHealth>() != null)
            return;

        // Kiểm tra có phải Enemy không
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        // Hủy đạn khi chạm bất kỳ thứ gì (trừ Player)
        Destroy(gameObject);
    }
}