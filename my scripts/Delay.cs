using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Delay : MonoBehaviour
{
    void Start()
    {
        DOVirtual.DelayedCall(46, GoNextScene);
    }

    void GoNextScene()
    {
        SceneManager.LoadScene("SampleScene 1");
    }
}
