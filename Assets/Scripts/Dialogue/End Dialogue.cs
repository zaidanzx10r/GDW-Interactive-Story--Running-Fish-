using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndDialogue : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    public string Escape = "Entering the last door, your mind broken, on the virge of death You Escaped......             or did you!?!?!";

    void Start()
    {
        promptText.text = Escape;
    }

}
