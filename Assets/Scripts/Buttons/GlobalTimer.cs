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
        scoreValue.text = ((int)currentTime).ToString();
        finalScoreValue.text = ((int)currentTime).ToString();
        currentTime -= removeTime * Time.deltaTime;

        if (currentTime <= 0)
        {
            // make the player die
        }
    }
}
