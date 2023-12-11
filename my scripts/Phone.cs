using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Phone : MonoBehaviour, IInteractable
{
    private Camera mainCam;
    [SerializeField] private AudioSource phoneUp;
    [SerializeField] private AudioSource phoneDown;
    [SerializeField] private GameObject phoneDetail;
    [SerializeField] private GameObject phoneDescription;
    public static bool phoneFound = false;
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public void Start() {
        mainCam = Camera.main;
        phoneDetail.SetActive(false);
        phoneDescription.SetActive(false);
    }

    public bool isDisplayed = false;

    public bool Interact(Interactor interactor)
    {
        if (!isDisplayed) {
            prompt = "put down";
            Debug.Log("Inspecting phone");
            phoneUp.Play();
            phoneDetail.SetActive(true);
            phoneDescription.SetActive(true);
            isDisplayed = true;
            phoneFound = true;
        } else {
            prompt = "pick up";
            Debug.Log("Putting phone down");
            phoneDown.Play();
            phoneDetail.SetActive(false);
            phoneDescription.SetActive(false);
            isDisplayed = false;
        }
        return true;
    }


}
