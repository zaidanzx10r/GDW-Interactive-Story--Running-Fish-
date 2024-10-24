using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Creates queue for lines, similar to an array
    public Queue<string> lines;

    void Start()
    {
        lines = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        lines.Clear();

        foreach (string line in dialogue.lines)
        {
            lines.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        string line = lines.Dequeue();
    }

    public void EndDialogue()
    {

    }
}
