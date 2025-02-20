using UnityEngine;

public class DoorTrigger : MonoBehaviour {
    public Vector3 newCamPos, newPlayerPos;
    CameraControllerBetter camControl;
    void Start() {
        camControl = Camera.main.GetComponent<CameraControllerBetter>(); 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.gameObject.tag == "Human") || (other.gameObject.tag == "Ghost"))
        camControl.minPos += newCamPos; camControl.maxPos += newCamPos;
        other. transform.position += newPlayerPos;
    }
}