using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public float batteryAmount = 25f;

    public void OnTriggerEnter(Collider other)
    {
        FLController flashlight = other.GetComponentInChildren<FLController>();
        if (flashlight)
        {
            flashlight.RechargeBattery(batteryAmount);
            Destroy(gameObject);
        }
    }

}
