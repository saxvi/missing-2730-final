using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject noLeave;
    [SerializeField] public AudioSource openSound;
    [SerializeField] public AudioSource closeSound;
    [SerializeField] private string prompt;
    [SerializeField] public int itemsCollected;
    [SerializeField] public Letter letter;
    [SerializeField] public Notebook notebook;
    [SerializeField] public Phone phone;
    [SerializeField] public bool yes = false;

    CharacterController playerController;

    public string InteractionPrompt => prompt;

    private void Start() {
        playerController = player.GetComponent<CharacterController>();
        noLeave.SetActive(false);
    }
    //yes = phone.phoneFound && letter.letterFound && notebook.notebookFound;
    public bool Interact(Interactor interactor)
    {
        if (yes) {
            prompt = "open";
            StartCoroutine("Teleport");            
        } else {
            noLeave.SetActive(true);
            StartCoroutine("NoLeave");            
        }
        return true;
    }

    IEnumerator Teleport()
    {
        openSound.Play();
        yield return new WaitForSeconds(1f);
        playerController.enabled = false;
        yield return new WaitForSeconds(0.5f);
        closeSound.Play();
        player.transform.position = new Vector3(-0.61f, 2.02f, 25.14f);
        yield return new WaitForSeconds(0.1f);
        playerController.enabled = true;
    } 

    IEnumerator NoLeave()
    {
        yield return new WaitForSeconds(2f);
        noLeave.SetActive(false);

    }
}