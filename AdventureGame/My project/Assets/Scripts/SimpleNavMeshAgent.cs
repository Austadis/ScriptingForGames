using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
   [SerializeField] Transform target;
   private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (target != null)
        {
            Debug.Log("Target position: " + target.position);
            Debug.Log("Agent is on NavMesh: " + agent.isOnNavMesh);
            agent.SetDestination(target.position);
        }
    }
}
