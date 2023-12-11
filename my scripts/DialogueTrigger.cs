using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    bool isDisplayed;


    public void Start() {
        dialogueBox.SetActive(true);
        isDisplayed = true;
    }

    private void Update() {
        if (Input.GetKeyDown("e") && isDisplayed)
        {
            dialogueBox.SetActive(false);
            isDisplayed = false;
        }
    }
    
} // end