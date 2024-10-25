using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
        public TextMeshProUGUI promptText;
    public string intro = "You awake from you slumber and find yourself in a forested ravine, with no memories of how you got there you panic. after a bit you settle down and notice in front of you a door...";
    public string Dia1 = "looking around further you notice more doors, hoping to exit the ravine, you pick a door and walk through it.";
    public string Dia2 = "";
    public string Dia3 = "";
    public string Dia4 = "";
    public string Dia5 = "";
    public string Dia6 = "";
    public string Dia7 = "";
    public string Dia8 = "";
    public string Dia9 = "";
    public string secretDoor = "Upon entering a hidden door, your vision goes dark. Awakening in your room, you realise that it was just a nightmare. A nightmare so realistic you felt pain in it...";
    public string Death = "Upon entering the door, it shuts behind you and locks. Looking further into the room, you witness yourself murder another version of yourself. He slowly turns around and looks at you while smiling. Then your vision slowly fades.";


    void Start()
    {
        promptText.text = intro;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("intro"))
        {
            promptText.text = Dia1;
        }
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
        if (collision.gameObject.CompareTag("secretDoor"))
        {
            promptText.text = secretDoor;
        }
    }
    
}
