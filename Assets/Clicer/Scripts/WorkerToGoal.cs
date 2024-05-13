using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AvoidanceAI : MonoBehaviour
{
    // Reference to the NavMeshAgent component
    private NavMeshAgent agent;

    public string goalTag = "Enemy";

    void Start()
    {
        // Get the NavMeshAgent component attached to this object
        agent = GetComponent<NavMeshAgent>();

        // Find the closest goal and set it as the destination
        SetClosestGoalAsDestination();
    }

    void Update()
    {
        // Check if the agent has reached the destination
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            // Find a new closest goal and set it as the destination
            SetClosestGoalAsDestination();
        }
    }

    void SetClosestGoalAsDestination()
    {
        // Find all goals in the scene
        GameObject[] goals = GameObject.FindGameObjectsWithTag(goalTag);

        if (goals.Length > 0)
        {
            // Initialize variables to store information about the closest goal
            Transform closestGoal = null;
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