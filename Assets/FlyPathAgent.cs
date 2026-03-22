using UnityEngine;

public class FlyPathAgent : MonoBehaviour
{
    public FlyPath flyPath;
    public float flySpeed = 2f;

    public Vector3 offset; // 👈 thêm dòng này

    private int nextIndex = 1;
   
    void Start()
    {
        if (flyPath != null)
            transform.position = flyPath[0] + offset; // 👈 FIX
    }

    void Update()
    {
        if (flyPath == null) return;

        if (nextIndex >= flyPath.waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 target = flyPath[nextIndex] + offset; // 👈 FIX

        if (Vector2.Distance(transform.position, target) > 0.1f)
        {
            FlyToNextWaypoint(target);
            LookAt(target);
        }
        else
        {
            nextIndex++;
        }
    }

    void FlyToNextWaypoint(Vector3 target)
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target,
            flySpeed * Time.deltaTime
        );
    }

    void LookAt(Vector2 target)
    {
        Vector2 direction = target - (Vector2)transform.position;

        if (direction.magnitude < 0.01f) return;

        float angle = Vector2.SignedAngle(Vector2.down, direction);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}