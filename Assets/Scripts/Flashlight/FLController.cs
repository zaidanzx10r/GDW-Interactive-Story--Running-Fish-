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

    void Start()
    {
        flashlight.enabled = isOn;
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
