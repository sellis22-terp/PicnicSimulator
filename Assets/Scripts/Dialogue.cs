using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogue : MonoBehaviour
{   
    // I used a Queue cause its annoying to keep track of an index to go thru the dialogue
    // I couldnt make it a SerializeField though cause Unity doesn't let you serialize Queues
    private Queue<string> dialogue;
    [SerializeField] string[] dialogueTemp;
    [SerializeField] TextMeshProUGUI dialogueText;

    void Start()
    {   
        // Convert the Array into a Queue
        dialogue = new Queue<string>(dialogueTemp);
        SetText();
    }

    public void SetText()
    {   
        // Makes sure theres still stuff in the queue before it tries to grab it
        if (dialogue.Count != 0) {
            dialogueText.SetText(dialogue.Dequeue());
        }
    }
}
