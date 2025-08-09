using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject playerShipPrefab;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public Camera arCamera;

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        // Raycast from the center of the screen to detect a plane
        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes))
        {
            // Get the position of the detected plane
            Pose hitPose = hits[0].pose;

            // Spawn the player ship at the center of the plane
            if (playerShipPrefab != null)
            {
                Instantiate(playerShipPrefab, hitPose.position, hitPose.rotation);
            }

            // Optionally spawn asteroids (randomly or on specific points)
            if (asteroidPrefab != null)
            {
                SpawnAsteroids(hitPose.position);
            }
        }
    }

    // Spawn a few asteroids at random positions on the detected plane
    void SpawnAsteroids(Vector3 position)
    {
        for (int i = 0; i < 5; i++) // Spawning 5 asteroids for example
        {
            Vector3 spawnPosition = new Vector3(position.x + Random.Range(-0.5f, 0.5f),
                                                position.y + Random.Range(-0.5f, 0.5f),
                                                position.z);
            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
