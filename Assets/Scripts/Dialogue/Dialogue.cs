using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
        public TextMeshProUGUI promptText;
    public string intro = "You awake from you slumber and find yourself in a forested ravine, with no memories of how you got there you panic. after a bit you settle down and notice in front of you a door...";
    public string Dia1 = "looking around further you notice more doors, hoping to exit the ravine, you pick a door and walk through it.";

    void Start()
    {
        promptText.text = "intro";
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("intro"))
        {
            promptText.text = Dia1;
        }
        else if (collision.gameObject.CompareTag("Dia1Exit") || collision.gameObject.CompareTag("Dia3Exit"))
        {
            promptText.gameObject.SetActive(false);
        }
    
    }
    
}
