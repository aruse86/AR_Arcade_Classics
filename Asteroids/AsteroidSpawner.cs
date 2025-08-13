using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 2f, spawnInterval);
    }

    void SpawnAsteroid()
    {
        Vector3 spawnPos = transform.position + Random.onUnitSphere * spawnRadius;
        spawnPos.y = Mathf.Abs(spawnPos.y); // keep it above ground
        Quaternion rotation = Quaternion.LookRotation(-spawnPos.normalized); // face inward
        

        Instantiate(asteroidPrefab, spawnPos, rotation);
        Debug.Log("Spawning asteroid");
        
    }
}