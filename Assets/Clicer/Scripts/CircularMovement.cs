using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    // Center of the circular movement
    public Vector3 centerPoint;

    // Radius of the circular movement
    public float radius = 2f;

    // Speed at which the object moves around the circle
    public float angularSpeed = 2f;

    // Angle offset to start the circular movement
    public float angleOffset = 0f;

    private float currentAngle = 0f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the position around the circle
        float x = centerPoint.x + radius * Mathf.Cos(currentAngle);
        float z = centerPoint.z + radius * Mathf.Sin(currentAngle);

        // Set the new position
        transform.position = new Vector3(x, centerPoint.y, z);

        // Increment the angle
        currentAngle += angularSpeed * Time.deltaTime;

        // Wrap the angle within the range [0, 2 * PI]
        currentAngle = Mathf.Repeat(currentAngle, 2 * Mathf.PI);
    }
}
