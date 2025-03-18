using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathDoor : MonoBehaviour
{
    public DialogueScene3 dialogue;

    public DeathCon deathController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(deathController.DoorDeathDelay(other));
        }
    }
}
