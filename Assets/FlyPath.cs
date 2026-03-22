using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public Transform[] waypoints;

    // indexer để lấy vị trí waypoint
    public Vector3 this[int index] => waypoints[index].position;

    // vẽ đường trong Scene (debug)
    private void OnDrawGizmos()
    {
        if (waypoints == null) return;

        Gizmos.color = Color.green;

        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(
                waypoints[i].position,
                waypoints[i + 1].position
            );
        }
    }
}