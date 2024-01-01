using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour, IInteractable
{
    private Camera mainCam;
    [SerializeField] private AudioSource bookUp;
    [SerializeField] private  AudioSource bookDown;
    [SerializeField] private GameObject notebookDetail;
    [SerializeField] private GameObject notebookDescription;
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public void Start() {
        mainCam = Camera.main;
        notebookDetail.SetActive(false);
        notebookDescription.SetActive(false);
    }

    public bool isDisplayed = false;

    public bool Interact(Interactor interactor)
    {
        if (!isDisplayed) {
            prompt = "put down";
            Debug.Log("Inspecting notebook");
            notebookDetail.SetActive(true);
            notebookDescription.SetActive(true);
            bookUp.Play();
            isDisplayed = true;
        } else {
            prompt = "read";
            Debug.Log("Putting notebook down");
            notebookDetail.SetActive(false);
            notebookDescription.SetActive(false);
            bookDown.Play();
            isDisplayed = false;
        }
        Found.book = true;
        Debug.Log(Found.book);
        return true;
    }
}
