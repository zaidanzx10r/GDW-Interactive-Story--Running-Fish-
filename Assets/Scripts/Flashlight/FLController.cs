using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLController : MonoBehaviour
{
    public Light flashlight;
    public float batteryLife = 100f;
    public float batteryDrainSpeed = 1f;
    public float batteryDrain = 25f;

    private bool isOn = false;


    private Transform playerPosition;
    public GameObject flashRange;
    public float flashDistance = 5f;

    void Start()
    {
        flashlight.enabled = isOn;
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerPosition = player.transform;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && batteryLife > 0)
        {
            isOn = !isOn;
            flashlight.enabled = isOn;
        }
        
        if(isOn)
        {
            batteryLife -= batteryDrainSpeed * Time.deltaTime;
            if(batteryLife <= 0)
            {
                batteryLife = 0;
                flashlight.enabled=false;
                isOn = false;
            }
        }

        if(playerPosition != null)
        {
            Vector3 playerPos = playerPosition.position;
        }

        Flash();
    }

    public void Flash()
    {
        if(Input.GetKeyDown(KeyCode.Q) && playerPosition != null && batteryLife >= batteryDrain) 
        {
            Vector3 spawnPosition = playerPosition.position + playerPosition.forward * flashDistance;
            GameObject flashEffect = Instantiate(flashRange, spawnPosition, playerPosition.rotation);

            Destroy(flashEffect, 0.5f);


        }
    }
    public void RechargeBattery(float amount)
    {
        batteryLife += amount;
        if(batteryLife > 100f)
        {
            batteryLife = 100f;
        }
    }
}
