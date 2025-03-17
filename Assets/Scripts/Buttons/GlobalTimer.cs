using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{
    public float currentTime = 420f;
    public float removeTime = 1f;

    public TextMeshProUGUI scoreValue;
    public TextMeshProUGUI finalScoreValue;

    private void Update()
    {
        Timer();
    }

    public void Timer()
    {
        if (currentTime > 0)
        {
            currentTime -= removeTime * Time.deltaTime;

            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

            scoreValue.text = formattedTime;
            finalScoreValue.text = formattedTime;
        }
        else
        {
            // make the player die
        }
    }
}
