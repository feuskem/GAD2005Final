using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AvoidanceAI : MonoBehaviour
{
    // Reference to the goal object
    public Transform goal;

    // Reference to the NavMeshAgent component
    private NavMeshAgent agent;

    void Start()
    {
        // Get the NavMeshAgent component attached to this object
        agent = GetComponent<NavMeshAgent>();

        // Set the destination of the NavMeshAgent to the goal position
        if (goal != null)
        {
            agent.SetDestination(goal.position);
        }
    }

    void Update()
    {
        // Check if the goal is assigned and if the agent has reached the destination
        if (goal != null && !agent.pathPending && agent.remainingDistance < 0.1f)
        {
            // Set a new destination to the goal position
            agent.SetDestination(goal.position);
        }
    }
}
