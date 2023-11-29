using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    // 
    [SerializeField] private string prompt;

    // fancy open door
    [SerializeField] private float openSpeed;
    private float rotationAmt = 90f;
    private float forwardDirection = 0;
    private Vector3 startRotation;
    private Vector3 Forward;
    private Coroutine animationCoroutine;

    public string InteractionPrompt => prompt;
    public bool Interact(Interactor interactor)
    {
        // do stuff
        Debug.Log("Opening door");
        return true;
    }
}