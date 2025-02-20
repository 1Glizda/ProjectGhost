using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerChanger : MonoBehaviour
{
    public Transform playerNew;
    public CameraController controller;

    void OnTriggerEnter2D(Collider2D other) {
        controller.player = playerNew;
    }
}