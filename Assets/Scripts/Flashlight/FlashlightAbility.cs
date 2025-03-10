using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightAbility : MonoBehaviour
{
    private FLController batteryLife;

    private float _battery;

    private Transform playerPosition;

    public GameObject flashRange;

    public float flashDistance = 5f;

    void Start()
    {
        batteryLife = GetComponent<FLController>();  

        if (batteryLife != null)
        {
            _battery = batteryLife.batteryLife;
        }
        else
        {
            Debug.Log("FLController not found on this GameObject");
        }

        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerPosition = player.transform;
        }
        else
        {
            Debug.Log("Player not found");
        }
    }

    void Update()
    {
        if (playerPosition != null)
        {
            Vector3 playerPos = playerPosition.position;
        }

        Flash();
    }

    public void Flash()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 spawnPosition = playerPosition.position + playerPosition.forward * flashDistance;

            GameObject flashEffect = Instantiate(flashRange, spawnPosition, playerPosition.rotation);

            if (batteryLife != null)
            {
                _battery = batteryLife.batteryLife - batteryLife.batteryDrain;
                Debug.Log("Battery life after flash: " + _battery);
            }
            
            Destroy(flashEffect, 0.5f);

            Debug.Log("Pressed Q");
        }
    }
}
