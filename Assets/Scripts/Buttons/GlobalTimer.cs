using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{
    public float currentTime = 420f;
    public float removeTime = 1f;
    public static float finalTime;

    public TextMeshProUGUI finalTimeValue;

    [SerializeField]
    private DeathCon deathController;
    private bool isDead = false;

    private void Start()
    {
        currentTime = 420f;
        finalTime = 0f;
    }

    private void Update()
    {
        Timer();
    }

    public void Timer()
    {
        if (currentTime > 0)
        {
            currentTime -= removeTime * Time.deltaTime;
            finalTime += removeTime * Time.deltaTime;

            float minutes = Mathf.FloorToInt(finalTime / 60);
            float seconds = Mathf.FloorToInt(finalTime % 60);

            string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

            finalTimeValue.text = formattedTime;
        }
        else
        {
            isDead = true;
            ActivateDeathScreen();
        }
    }

    void ActivateDeathScreen()
    {
        StartCoroutine(deathController.DeathDelay(null));
    }
}
