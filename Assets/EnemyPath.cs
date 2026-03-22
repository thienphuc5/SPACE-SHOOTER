using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;

    private int waypointIndex = 0;

    void Update()
    {
        if (waypointIndex >= waypoints.Length) return;

        Transform target = waypoints[waypointIndex];

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            waypointIndex++;
        }
    }
}