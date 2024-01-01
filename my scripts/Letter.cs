using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Letter : MonoBehaviour, IInteractable
{    
    private Camera mainCam;
    [SerializeField] private AudioSource letterUp;
    [SerializeField] private AudioSource letterDown;
    [SerializeField] private GameObject letterDetail;
    [SerializeField] private GameObject letterDescription;
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public void Start() {
        mainCam = Camera.main;
        letterDetail.SetActive(false);
        letterDescription.SetActive(false);
    }

    public bool isDisplayed = false;
    
    public bool Interact(Interactor interactor)
    {
        if (!isDisplayed) {
            prompt = "put down";
            Debug.Log("Inspecting letter");
            letterDetail.SetActive(true);
            letterDescription.SetActive(true);
            letterUp.Play();
            isDisplayed = true;
        } else {
            prompt = "pick up";
            Debug.Log("Putting letter down");
            letterDetail.SetActive(false);
            letterDescription.SetActive(false);
            letterDown.Play();
            isDisplayed = false;
        }
        Found.letter = true;
        return true;
    }    
}
