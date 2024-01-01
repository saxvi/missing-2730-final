using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Phone : MonoBehaviour, IInteractable
{
    private Camera mainCam;
    [SerializeField] private GameObject player;
    CharacterController playerController;


    [SerializeField] private AudioSource phoneUp;
    [SerializeField] private AudioSource phoneDown;
    [SerializeField] private GameObject phoneDetail;
    [SerializeField] private GameObject phoneDescription;
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public void Start() {
        playerController = player.GetComponent<CharacterController>();
        mainCam = Camera.main;
        phoneDetail.SetActive(false);
        phoneDescription.SetActive(false);
    }

    public bool isDisplayed = false;

    public bool Interact(Interactor interactor)
    {
        if (!isDisplayed) {
            prompt = "put down";

            playerController.enabled = false;
            StartCoroutine("Wait");

            Debug.Log("Inspecting phone");
            phoneUp.Play();
            phoneDetail.SetActive(true);
            phoneDescription.SetActive(true);
            isDisplayed = true;

            playerController.enabled = true;
        } else {
            prompt = "pick up";
            playerController.enabled = false;
            Debug.Log("Putting phone down");
            phoneDown.Play();
            phoneDetail.SetActive(false);
            phoneDescription.SetActive(false);
            isDisplayed = false;
            playerController.enabled = true;
        }
        Found.phone = true;
        return true;
    }

    IEnumerator Wait() {
    yield return new WaitForSeconds(0.01f);
    }
}
