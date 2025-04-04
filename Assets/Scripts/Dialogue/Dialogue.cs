using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
        public TextMeshProUGUI promptText;
    public string intro = "HHhnng, ouch my head. I remember stumbling through a door into this forest. And I can't forget to use 'F' to turn on my flashlight and 'WASD' to move";
    public string Dia1 = "I should make my way back through the door. Maybe using 'Q' to flash my light will help ward any critters off.";

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
        else if (collision.gameObject.CompareTag("Dia1Exit") || collision.gameObject.CompareTag("Dia3Exit"))
        {
            promptText.gameObject.SetActive(false);
        }
    
    }
    
}
