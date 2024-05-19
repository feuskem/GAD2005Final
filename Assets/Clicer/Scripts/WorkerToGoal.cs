using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AvoidanceAI : MonoBehaviour
{
    // Reference to the NavMeshAgent component
    private NavMeshAgent agent;

    public string primaryGoalTag = "Enemy"; // Tag for primary goal objects
    public string secondaryGoalTag = "Castle"; // Tag for secondary goal objects
    public float stopDistance = 5f; // Distance to stop from the goal

    private Transform closestGoal;

    void Start()
    {
        // Get the NavMeshAgent component attached to this object
        agent = GetComponent<NavMeshAgent>();

        // Initially find the closest goal and set it as the destination
        SetClosestGoalAsDestination();
    }

    void Update()
    {
        // Continuously update the closest goal and set the destination
        SetClosestGoalAsDestination();

        // If a goal is set, check the distance to it
        if (closestGoal != null)
        {
            float distanceToGoal = Vector3.Distance(transform.position, closestGoal.position);

            // Stop the agent if within the stop distance
            if (distanceToGoal <= stopDistance)
            {
                agent.isStopped = true;
            }
            else
            {
                // Move towards the goal if not within the stop distance
                agent.isStopped = false;
                agent.SetDestination(closestGoal.position);
            }
        }
    }

    void SetClosestGoalAsDestination()
    {
        // Try finding primary goals first
        GameObject[] goals = GameObject.FindGameObjectsWithTag(primaryGoalTag);

        if (goals.Length == 0)
        {
            // If no primary goals are found, try finding secondary goals
            goals = GameObject.FindGameObjectsWithTag(secondaryGoalTag);
        }

        if (goals.Length > 0)
        {
            // Initialize variables to store information about the closest goal
            closestGoal = null;
            float closestDistance = Mathf.Infinity;

            // Iterate through each goal to find the closest one
            foreach (GameObject goal in goals)
            {
                float distanceToGoal = Vector3.Distance(transform.position, goal.transform.position);

                // Update the closest goal if the current goal is closer
                if (distanceToGoal < closestDistance)
                {
                    closestGoal = goal.transform;
                    closestDistance = distanceToGoal;
                }
            }

            // Set the closest goal as the destination of the NavMeshAgent
            if (closestGoal != null)
            {
                agent.SetDestination(closestGoal.position);
            }
        }
    }
}
