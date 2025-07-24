using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPoints; // Should have 5 points
    public GameObject[] invaders;   // invaders[0] = invader1, invaders[1] = invader2, invaders[2] = invader3

    void Start()
    {
        SpawnInvaders();
    }

    void SpawnInvaders()
    {
        Dictionary<int, int> invaderCounts = new Dictionary<int, int>()
        {
            { 0, 2 }, // invader1
            { 1, 2 }, // invader2
            { 2, 1 }  // invader3
        };

        List<Vector3> usedPositions = new List<Vector3>();
        float minDistance = 3f;

        int totalSpawned = 0;

        foreach (var pair in invaderCounts)
        {
            int invaderType = pair.Key;
            int count = pair.Value;
            float yPosition = 18 + invaderType * 2;

            for (int i = 0; i < count; i++)
            {
                Vector3 spawnPos;
                int attempts = 0;
                bool positionOk;

                do
                {
                    spawnPos = spawnPoints[totalSpawned % spawnPoints.Length].position;
                    spawnPos.x = GetRandomOutsideRange(-20f, -2f, 2f, 20f);
                    spawnPos.z = GetRandomOutsideRange(-20f, -2f, 2f, 20f);
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


    float GetRandomOutsideRange(float min1, float max1, float min2, float max2)
    {
        return Random.value < 0.5f ? Random.Range(min1, max1) : Random.Range(min2, max2);
    }
}
