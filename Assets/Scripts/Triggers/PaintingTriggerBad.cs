using UnityEngine;

public class PaintingTriggerBad : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Human")) {
            if(Input.GetKey(KeyCode.LeftShift)) {
                //dialog
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Human")) {
            if(Input.GetKey(KeyCode.LeftShift)) {
                //dialog
            }
        }
    }
}
