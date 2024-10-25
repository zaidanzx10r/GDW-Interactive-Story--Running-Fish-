using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource Audio;
    public PlayerMovement playerMovement;
    void Update()
    {
        float isWalking = playerMovement.IsWalking();
        if (isWalking >= 1 )
        {
            FootStep();
        }
        else if (isWalking == 0)
        {
            StopFootStep();
        }
    }

    public void FootStep()
    {
        if (!Audio.isPlaying)
        {
        Audio.Play();
        }
    }

    public void StopFootStep()
    {
        Audio.Stop();
    }
   
}
