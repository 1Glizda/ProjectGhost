using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ghost")) {
            //dialog
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Ghost")) {
            //dialog
        }
    }
}
