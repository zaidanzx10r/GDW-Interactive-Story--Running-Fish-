using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door1 : MonoBehaviour
{
    public DoorManager Door;
    public string firstDoor = "Passed to the next level";
    
    public void FirstDoor()
    {
        Door.promptText.text = firstDoor;
        Door.promptText.gameObject.SetActive(true);
    }
}
