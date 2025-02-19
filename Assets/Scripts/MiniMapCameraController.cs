using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraController : MonoBehaviour
{
    private Camera minimapCamera;

    void Start()
    {
        minimapCamera = GetComponent<Camera>();
    }

    void Update()
    {
        UpdateCameraProperties();
        if(PlayerController.roomState == 3) {
            Destroy(gameObject);
        }
    }

    void SetCameraProperties(float newSize, Vector3 newPosition)
    {
        minimapCamera.orthographicSize = newSize;
        minimapCamera.transform.position = new Vector3(newPosition.x, newPosition.y, -0.3956077f);
    }

    void UpdateCameraProperties()
    {
        if (PlayerController.roomState == 1)
        {
            SetCameraProperties(14f, new Vector3(0f, 5.5f));
        }
        else if (PlayerController.roomState == 2)
        {
            SetCameraProperties(12.07649f, new Vector3(9.9f, -5.5f));
        }
    }
}
