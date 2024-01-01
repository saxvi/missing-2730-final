using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    bool isDisplayed;
    [SerializeField] private GameObject player;
    CharacterController playerController;


    public void Start() {
        playerController = player.GetComponent<CharacterController>();
        playerController.enabled = false;
        dialogueBox.SetActive(true);
        isDisplayed = true;
        
    }

    private void Update() {
        if (Input.GetKeyDown("e") && isDisplayed)
        {
            StartCoroutine("Wait");
            playerController.enabled = true;
            dialogueBox.SetActive(false);
            isDisplayed = false;
        }
    }
    IEnumerator Wait() {
        yield return new WaitForSeconds(3f);
    }
    
} // end