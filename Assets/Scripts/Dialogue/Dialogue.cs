using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
        public TextMeshProUGUI promptText;
    public string intro = "Use 'WASD' on the keyboard to move around and 'Shift' to Run. turn on/off the flashlight by pressing 'F' ";
    public string Dia1 = "Beware for the Deer. Use 'Q' to stun. Watchout for you battery level.";

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
