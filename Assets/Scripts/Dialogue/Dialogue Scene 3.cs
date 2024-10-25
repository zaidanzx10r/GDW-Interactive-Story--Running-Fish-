using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScene3 : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    public string Dia3 = "After hours of walking in the forest. The Forest changing each door you enter, you find yourself going insane and incressingly more dehydrated.";
    public string secretDoor = "Upon entering a hidden door, your vision goes dark. Awakening in your room, you realise that it was just a nightmare. A nightmare so realistic you felt pain in it...";
    public string Death = "Upon entering the door, it shuts behind you and locks. Looking further into the room, you witness yourself murder another version of yourself. He slowly turns around and looks at you while smiling. Then your vision slowly fades.";


    void Start()
    {
        promptText.text = "Dia3";
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Dia1Exit"))
        {
            promptText.gameObject.SetActive(false);
        }
    
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("deathDoor"))
        {
            promptText.text = Death;
            promptText.gameObject.SetActive(true);

        }
        else if (collision.gameObject.CompareTag("secretDoor"))
        {
            promptText.text = secretDoor;
            promptText.gameObject.SetActive(true);
        }
    }
    
}
