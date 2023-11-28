using UnityEngine;
using UnityEngine.UI;

public class CubeClick : MonoBehaviour{

    public Image image;

    void Start(){
        image.enabled = false;
    }

    void OnMouseDown(){
        image.enabled = !image.enabled;
    }
}
