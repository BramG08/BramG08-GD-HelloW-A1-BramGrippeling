using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    private void Update()
    {
        if (waypoints.Length == 0) return;


        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        
        if (transform.position == targetWaypoint.position)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
