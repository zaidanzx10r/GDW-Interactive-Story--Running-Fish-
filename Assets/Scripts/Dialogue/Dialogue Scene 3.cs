using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScene3 : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    public string Dia3 = "After hours of walking in the forest. The Forest changing each door you enter, you find yourself going insane and incressingly more dehydrated.";
    public string Death = "Upon entering the door, it shuts behind you and locks. Looking further into the room, you witness yourself murder another version of yourself. He slowly turns around and looks at you while smiling. Then your vision slowly fades.";

    public string Escape = "Entering the last door, your mind broken, on the virge of death You Escaped......             or did you!?!?!";


    void Start()
    {
        promptText.text = Dia3;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Dia1Exit"))
        {
            promptText.gameObject.SetActive(false);
        }
    
    }
    
}
