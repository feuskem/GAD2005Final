using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Object prefabs to spawn
    public GameObject[] objectPrefabs;

    // Spawn area dimensions
    public Vector3 spawnAreaSize = new Vector3(10f, 10f, 10f);

    // Timer for spawning
    public float spawnTimer;

    // Time interval between spawns
    private float ResetSpawnTimer;
    public float ReduceResetTimer;

    void Start()
    {
        // Start the spawn timer
        ResetSpawnTimer = spawnTimer;

        // Spawn the first object immediately upon starting
        SpawnObject();
    }

    void Update()
    {
        // Decrease the spawn timer
        spawnTimer -= Time.deltaTime;

        // Check if it's time to spawn a new object
        if (spawnTimer <= 0f)
        {
            // Spawn the object
            SpawnObject();

            // Reset the spawn timer
            spawnTimer = ResetSpawnTimer;
        }


        ReduceResetTimer -= Time.deltaTime;

        if (ReduceResetTimer <= 0f)
        {
            ResetSpawnTimer -= 1f;

            if (ResetSpawnTimer < 5f)
            {
                ResetSpawnTimer = 5f;
            }
        }
    }

    void SpawnObject()
    {
        // Randomly select one of the object prefabs
        GameObject objectToSpawn = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

        // Calculate random spawn position within spawn area
        Vector3 spawnPosition = transform.position + new Vector3(
            Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
            Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f),
            Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
        );

        // Instantiate the selected object at the calculated spawn position
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        // Draw wire cube representing the spawn area
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
