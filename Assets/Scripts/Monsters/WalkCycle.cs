using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator animator;  // Reference to the Animator
    public string animationTriggerName = "PlayAnimation"; // Name of the trigger in Animator

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the correct tag
        {
            animator.SetTrigger(animationTriggerName);
        }
    }
}

