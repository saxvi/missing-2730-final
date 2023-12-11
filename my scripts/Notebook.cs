using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour, IInteractable
{
    private Camera mainCam;
    [SerializeField] private GameObject notebookDetail;
    [SerializeField] private GameObject notebookDescription;
    public static bool notebookFound = false;
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
            isDisplayed = true;
        } else {
            prompt = "read";
            Debug.Log("Putting notebook down");
            notebookDetail.SetActive(false);
            notebookDescription.SetActive(false);
            isDisplayed = false;
        }
        return true;
    }
}
