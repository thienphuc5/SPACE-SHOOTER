using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }
}
