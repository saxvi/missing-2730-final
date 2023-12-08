using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget; //where the player will end up after teleporting
    public GameObject player1; //the player themselves

    void OnTriggerEnter(Collider other) //trigger for teleporting; can change this part to a button to fit with what ur doing
    {
    player1.transform.position = teleportTarget.transform.position;
    }
}
