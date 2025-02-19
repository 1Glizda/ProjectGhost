using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    public Door door2;
    void OnTriggerEnter2D() {
        if(Input.GetKey(KeyCode.RightShift)) {
            door2.PassDoor();
        }
    }

    void OnTriggerStay2D() {
        if(Input.GetKey(KeyCode.RightShift)) {
            door2.PassDoor();
        }
    }
}
