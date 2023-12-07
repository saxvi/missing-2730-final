using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour, IInteractable
{
    public Image letterDetail;

    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    void Start{
        letterDetail.isDisplayed = false;
    }
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Inspecting letter");
        letterDetail.isDisplayed = true;

        // display detailed image for x seconds 
        showFor(5);
        return true;
    }

    IEnumerator showFor(int seconds) {
        int counter = seconds;
        while (counter > 0) {
            yield return new WaitForSeconds (1);
            counter--;
        }
        putDown();
    }
    void putDown() {
        letterDetail.enabled = false;
    }
}