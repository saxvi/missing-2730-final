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
    private void LateUpdate() {
        var rotation = mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward,
            rotation * Vector3.up);
    }

    public bool isDisplayed = false;

    public void SetUp(string thisText) {
        promptText = promptText;
        uiPanel.SetActive(true);
        isDisplayed = true; 
    }

    public void Close () {
        isDisplayed = false;
        uiPanel.SetActive(false);
    }
}
