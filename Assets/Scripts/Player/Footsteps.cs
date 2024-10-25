using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject Audio;
    void Update()
    {
        PlayerMovement playerMovement = Audio.GetComponent<PlayerMovement>();
        if (playerMovement.isWalking() => )
        {
            FootStep();
        }
        else if (!playerMovement.isWalking())
        {
            StopFootStep();
        }
    }

    public void FootStep()
    {
        Audio.SetActive(true);
    }

    public void StopFootStep()
    {
        Audio.SetActive(false);
    }
   
}
