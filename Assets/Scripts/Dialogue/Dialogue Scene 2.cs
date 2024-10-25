using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScene2 : MonoBehaviour
{
        public TextMeshProUGUI promptText;

    public string Dia2 = "Walking through the door you find your self in the same revine. You notice keen differences, the Door and trees are moved. hoping that you don't have to go through more doors you march on.";


    void Start()
    {
        promptText.text = Dia2;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Dia1Exit"))
        {
            promptText.gameObject.SetActive(false);
        }
    
    }
}
