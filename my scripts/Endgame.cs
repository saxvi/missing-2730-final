using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] private AudioSource bgMusic;
    [SerializeField] private AudioSource last;
    [SerializeField] private GameObject endgameTrigger;
    CharacterController playerController;

    private void Start() {
        playerController = player.GetComponent<CharacterController>();
    }
    void GoNextScene()
    {
        bgMusic.Stop();
        SceneManager.LoadScene("End Credits");
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("credits triggered");
        DOVirtual.DelayedCall(3, GoNextScene);
        last.Play();
    }
}

