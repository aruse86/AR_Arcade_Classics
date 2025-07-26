// needed namespaces for Unity to function
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Defines a SpawnScript class that spawns the different types of invaders (4 types, 4 waves, 26 invaders per wave)
public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPoints; // 26 spawn points in Inspector
    public GameObject[] invaders;  // [0] = Invader1, ..., [3] = Invader4

    private int totalSpawned = 0;  // keeps track of number of invaders spawned already
    private int maxInvaders = 104;  // max allowed number of invaders to spawn

    // calls SpawnInvaders() every 30 seconds
    void Start()
    {
        InvokeRepeating("SpawnInvaders", 0f, 30f); // Spawns every 30 seconds
    }

    // controls how invaders are spawned
    void SpawnInvaders()
    {
        // stop spawning invaders if max allowed is reached
        if (totalSpawned >= maxInvaders)
        {
            Debug.Log("Max invader count reached. No more spawns.");
            CancelInvoke("SpawnInvaders"); // Stop further spawning
            return;
        }

        // defines how many of each type of invader is spawned per wave
        Dictionary<int, int> invaderCounts = new Dictionary<int, int>()
        {
            { 0, 10 }, // invader1
            { 1, 10 }, // invader2
            { 2, 5  }, // invader3
            { 3, 1  }  // invader4
        };

        // tracks where each invader is spawned so there are no overlaps
        List<Vector3> usedPositions = new List<Vector3>();
        float minDistance = 3f;  // ensures a min of 3 units between invaders

        // loops over each invader type
        foreach (var pair in invaderCounts)
        {
            int invaderType = pair.Key;
            int count = pair.Value;
            float yPosition = 4 + invaderType * 2; // adjusts y spawn position for each invader type

            // spawn each invader of that type, randomizes (in x & z coord) each spawn posisition around the ARcamera
            for (int i = 0; i < count; i++)
            {
                if (totalSpawned >= maxInvaders)
                {
                    Debug.Log("Reached spawn limit mid-wave.");
                    CancelInvoke("SpawnInvaders");
                    return;
                }

                Vector3 spawnPos;
                int attempts = 0;
                bool positionOk;

                do
                {
                    spawnPos = spawnPoints[totalSpawned % spawnPoints.Length].position;
                    spawnPos.x = GetRandomOutsideRange(-10f, -1f, 1f, 10f);
                    spawnPos.z = GetRandomOutsideRange(-10f, -1f, 1f, 10f);
                    spawnPos.y = yPosition;

                    positionOk = true;

                    foreach (var used in usedPositions)
                    {
                        if (Vector3.Distance(spawnPos, used) < minDistance)
                        {
                            positionOk = false;
                            break;
                        }
                    }

                    attempts++;
                    if (attempts > 50)
                    {
                        Debug.LogWarning("Could not find a non-overlapping spawn position.");
                        break;
                    }

                } while (!positionOk);

                usedPositions.Add(spawnPos);
                Instantiate(invaders[invaderType], spawnPos, Quaternion.identity);
                totalSpawned++;
            }
        }
    }

    // method to keep the invaders from spawning in the players face (between -1 and 1) and too far away (<10 or >-10)
    float GetRandomOutsideRange(float min1, float max1, float min2, float max2)
    {
        return Random.value < 0.5f ? Random.Range(min1, max1) : Random.Range(min2, max2);
    }
}
