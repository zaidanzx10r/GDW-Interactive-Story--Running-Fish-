using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class secretDialogue : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    public string secretDoor = "Upon entering a hidden door, your vision goes dark. Awakening in your room, you realise that it was just a nightmare. A nightmare so realistic you felt pain in it...";

    void Start()
    {
        promptText.text = secretDoor;
    }

}
