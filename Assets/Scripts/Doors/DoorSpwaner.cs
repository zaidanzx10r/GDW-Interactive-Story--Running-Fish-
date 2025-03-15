using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpwaner : MonoBehaviour
{
    public GameObject doorPrefab;
    public Transform[] spawnPoints;
    void Start()
    {
        spawnDoor();
    }

    void spawnDoor()
    {
        if (doorPrefab != null || spawnPoints.Length < 4)
        {
            Debug.LogError("no door prefab or not enought spawnpoints(4 needed)");
            return;
        }
        int rdmIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(doorPrefab, spawnPoints[rdmIndex].position, spawnPoints[rdmIndex].rotation);

        Debug.Log("Door is at location" + rdmIndex);
    }
}
