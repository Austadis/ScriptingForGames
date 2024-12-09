using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex;
    private NavMeshAgent agent;

    public float waypointThreshold = 1f;
    public float waitTimeAtWaypoint = 2f;
    private bool isWaiting = false;
    private float waitTimer = 0f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[0].position);
            Debug.Log("moving to first waypoint: " + waypoints[0].name);
        }
    }

    private void Update()
    {
        if (!isWaiting &&
            Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < waypointThreshold &&
            !agent.pathPending)
        {
            isWaiting = true;
            waitTimer = 0f;
            Debug.Log("Arrived at Waypoint " + (currentWaypointIndex + 1) + ". Waiting for " + waitTimeAtWaypoint + " seconds.");
            
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }

        if (isWaiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTimeAtWaypoint)
            {
                isWaiting = false;
                Debug.Log("Finished waiting at waypoint " + (currentWaypointIndex + 1) + ". Proceeding to next waypoint.");
            }
        }
    }
}
