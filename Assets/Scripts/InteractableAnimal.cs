using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableAnimal : MonoBehaviour
{
    
    [SerializeField] GameObject dialogueGUI;
    [SerializeField] PlayerInput input;

    void Start()
    {   
        // Turn it off to start, I also did it in the scene view so this is kinda redundant
        dialogueGUI.SetActive(false);
        input.actions.FindAction("Look").Enable();
    }

    private void OnTriggerEnter(Collider other) {
        // Just in case
        if (other.tag == "Player")
        {   
            // Visible   
            dialogueGUI.SetActive(true);
        }

        // Without this whenever you try to move your mouse to the next button the screen would move
        // This line essentially disables OnLook in ThirdPersonControls.cs
        input.actions.FindAction("Look").Disable();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {   
            // Invisible
            dialogueGUI.SetActive(false);
        }

        // Renables
        input.actions.FindAction("Look").Enable();
    }
}
