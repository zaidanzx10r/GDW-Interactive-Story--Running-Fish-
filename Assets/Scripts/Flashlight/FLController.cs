using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FLController : MonoBehaviour
{
    public Light flashlight;
    public float batteryLife = 100f;
    public float batteryDrainSpeed = 0.5f;
    public float batteryDrain = 5f;

    private bool isOn = true;

    private Transform playerPosition;
    public GameObject flashRange;
    public float flashDistance = 5f;

    public float maxIntensity = 15f;
    public float defaultintensity = 6f;
    public float fadeDuration = 0.5f;
    public float durationTime = 0f;

    // Audio for clicking
    public AudioSource clickAudio;

    // UI-related
    public Transform BatterBar;
    private Vector3 OGScale;

    void Start()
    {
        flashlight.enabled = isOn;
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerPosition = player.transform;
        }

        OGScale = BatterBar.localScale;
    }

    void Update()
    {
        float scaleConversion = ((batteryLife / 100f) * 1.5f);
        BatterBar.localScale = new Vector3(scaleConversion, OGScale.y, OGScale.z);

        if (Input.GetKeyDown(KeyCode.F) && batteryLife > 0)
        {
            isOn = !isOn;
            flashlight.enabled = isOn;

            clickAudio.Play();
        }

        if (isOn)
        {
            batteryLife -= batteryDrainSpeed * Time.deltaTime;
            if (batteryLife <= 0)
            {
                batteryLife = 0;
                flashlight.enabled = false;
                isOn = false;
            }
        }
        else
        {
            batteryLife += 0.5f * Time.deltaTime;
        }

        if (playerPosition != null)
        {
            Vector3 playerPos = playerPosition.position;
        }

        Flash();
    }

    public void Flash()
    {
        if (Input.GetKeyDown(KeyCode.Q) && playerPosition != null && batteryLife >= batteryDrain)
        {
            batteryLife -= batteryDrain;

            Vector3 spawnPosition = playerPosition.position + playerPosition.forward * flashDistance;
            GameObject flashEffect = Instantiate(flashRange, spawnPosition, playerPosition.rotation);

            Destroy(flashEffect, 0.5f);

            StartCoroutine(FlashbangEffect());
        }
    }

    private IEnumerator FlashbangEffect()
    {
        flashlight.intensity = maxIntensity;

        yield return new WaitForSeconds(0.5f);

        flashlight.intensity = defaultintensity;
    }

    public void RechargeBattery(float amount)
    {
        batteryLife += amount;
        if (batteryLife > 100f)
        {
            batteryLife = 100f;
        }
    }
}
