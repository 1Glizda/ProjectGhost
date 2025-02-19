using UnityEngine;

public class PaintingTriggerGood : MonoBehaviour
{
    public Door door3;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Human")) {
            if(Input.GetKey(KeyCode.LeftShift)) {
                door3.PassDoor();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Human")) {
            if(Input.GetKey(KeyCode.LeftShift)) {
                door3.PassDoor();
            }
        }
    }
}
