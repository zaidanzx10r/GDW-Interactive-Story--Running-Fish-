using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            FollowPlayer stopFollowing = other.GetComponent<FollowPlayer>();

            if (stopFollowing != null)
            {
                stopFollowing.StopMovement();
                Debug.Log("Deer is stunned!");
            }

            AudioSource deerScreech = other.GetComponent<AudioSource>();

            if (deerScreech != null)
            {
                deerScreech.Play();
                Debug.Log("Audio played!");
            }
        }
    }
}
