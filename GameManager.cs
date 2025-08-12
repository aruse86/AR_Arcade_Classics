using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject asteroidPrefab;
    public Transform player;
    public float spawnRadius = 3f;
    public int asteroidCount = 5;

    void Start() {
        for (int i = 0; i < asteroidCount; i++) SpawnAsteroid();
    }

    void SpawnAsteroid() {
        Vector3 randomPos = player.position + Random.onUnitSphere * spawnRadius;
        randomPos.y = player.position.y; // Keep same vertical level
        Instantiate(asteroidPrefab, randomPos, Quaternion.identity);
    }
}
