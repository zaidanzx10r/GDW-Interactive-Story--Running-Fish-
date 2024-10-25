using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement.isWalking())
        {
            FootStep();
        }
        else
        {
            StopFootStep();
        }
    }

    public void FootStep()
    {
        player.SetActive(true);
    }

    public void StopFootStep()
    {
        player.SetActive(false);
    }
   
}
