using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Object prefabs to spawn
    public GameObject[] objectPrefabs;

    // Spawn area dimensions
    public Vector3 spawnAreaSize = new Vector3(10f, 10f, 10f);

    private float SpawnNumber;
    public int totalWaves = 3;
    private int currentWave = 0;

    private List<GameObject> enemies = new List<GameObject>();

    public GameObject NextLB;

    void Start()
    {
        StartNextWave();
    }

    void StartNextWave()
    {
        if (currentWave < totalWaves)
        {
            currentWave++;
            StartCoroutine(SpawnEnemies());
        }

        GameObject[] goals = GameObject.FindGameObjectsWithTag("Enemy");

        if (goals.Length == 0)
        {
            if (currentWave >= totalWaves)
            {
                NextLB.SetActive(true);
            }
        }

    }

    IEnumerator SpawnEnemies()
    {
        int numberOfEnemies = currentWave + 2;
       
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject objectToSpawn = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
            Vector3 spawnPosition = transform.position + new Vector3(
                Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f),
                Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
            );
            GameObject enemy = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            enemies.Add(enemy);
            yield return new WaitForSeconds(0.5f);  // Düþmanlar arasýnda bekleme süresi
        }
       

    }

    public void EnemyDied(GameObject enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
        {
            StartCoroutine(NextWaveAfterDelay());
        }
    }

    IEnumerator NextWaveAfterDelay()
    {
        yield return new WaitForSeconds(5); // Dalga tamamlandýktan sonra bekleme süresi
        StartNextWave();
    }
}