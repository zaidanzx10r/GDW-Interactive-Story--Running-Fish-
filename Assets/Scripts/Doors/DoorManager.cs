using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorManager : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    private Door1 door1;
    private Door2 door2;
    private Door3 door3;

    // Start is called before the first frame update
    void Start()
    {
        promptText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door1"))
        {
            door1.FirstDoor();

        }
        if (other.CompareTag("Door2"))
        {
            door2.SecondDoor();
        }

        if (other.CompareTag("Door3"))
        {
            door3.ThirdDoor();
        }
    }
}
