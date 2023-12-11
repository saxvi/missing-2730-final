using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] public AudioSource openSound;
    [SerializeField] public AudioSource closeSound;
    [SerializeField] bool open = false;
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;
    public bool Interact(Interactor interactor)
    {
        if (!open) {
            prompt = "close";
            closeSound.Play();
            transform.Rotate(0, -90, 0);
            transform.position = new Vector3 ((float) -19, (float)2.9, (float) 6.2);
            open = true;
        } else {
            prompt = "open";
            openSound.Play();
            transform.Rotate(0, 90, 0);
            transform.position = new Vector3 ((float) -17.8, (float) 3.1, (float) 5.2);
            open = false;
        }
        return true;
    }
    
}