using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3 : MonoBehaviour
{
    public DoorManager Door;
    public string thirdDoor = "Retreat";

    public void ThirdDoor()
    {
        Door.promptText.text = thirdDoor;
        Door.promptText.gameObject.SetActive(true);
    }
}
