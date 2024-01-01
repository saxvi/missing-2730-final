using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private int ipHeight = 1;
    private Vector3 ipEnd;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private InteractionPromptUI interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] public static int numFound;

    private IInteractable interactable;
    
    private void Update()
    {
        ipEnd = transform.position + new Vector3 (0, ipHeight, 0);

        numFound = Physics.OverlapCapsuleNonAlloc(interactionPoint.position, ipEnd,
            interactionPointRadius, _colliders, interactableMask);

         // if there is an interactable object in range
        if (numFound > 0)
        {
            interactionPromptUI.isDisplayed = true;
            
            interactable = _colliders[0].GetComponent<IInteractable>();

            if (interactable != null) {

                if (interactionPromptUI.isDisplayed)
                {
                    interactionPromptUI.SetUp(interactable.InteractionPrompt);
                }
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    interactable.Interact(this);
                }
            }
            // // if the interactable object is not null and interact key pressed
            // if (interactable != null && Keyboard.current.eKey.wasPressedThisFrame) {
            //     interactable.Interact(this);
            // } 
        }
        else
        {
            if (interactable != null) {interactable = null;}
            if (interactionPromptUI.isDisplayed) {interactionPromptUI.Close();}
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
