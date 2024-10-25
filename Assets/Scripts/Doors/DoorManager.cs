using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorManager : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    private SafeDoor1 safeDoor1;
    private SafeDoor2 safeDoor2;
    private SecretDoor secretDoor;
    private DeathDoor deathDoor;

    // Start is called before the first frame update
    void Start()
    {
        promptText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("safeDoor1"))
        {
            safeDoor1.safeDoor1();

        }
        if (other.CompareTag("safeDoor2"))
        {
            safeDoor2.safeDoor2();

        }
        if (other.CompareTag("secretDoor"))
        {
            secretDoor.secretDoor();
        }

        if (other.CompareTag("deathDoor"))
        {
            deathDoor.deathDoor();
        }
    }
}
