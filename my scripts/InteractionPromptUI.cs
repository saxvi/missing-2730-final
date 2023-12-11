using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TMPro.TextMeshProUGUI promptText;

    public void Start() {
        mainCam = Camera.main;
        uiPanel.SetActive(false);
    }

    public bool isDisplayed = false;

    public void SetUp(string thisText) {
        promptText.text = thisText;
        uiPanel.SetActive(true);
        isDisplayed = true; 
    }

    public void Close () {
        isDisplayed = false;
        uiPanel.SetActive(false);
    }
}
