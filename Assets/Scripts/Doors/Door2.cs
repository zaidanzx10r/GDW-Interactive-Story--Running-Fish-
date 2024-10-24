using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public DoorManager Door;
    public string secondDoor = "You Died";

    public void SecondDoor()
    {
        Door.promptText.text = secondDoor;
        Door.promptText.gameObject.SetActive(true);
    }
}
