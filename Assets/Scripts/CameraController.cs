using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Room currRoom;
    public float moveSpeedWhenRoomChange;

    void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // UpdatePosition();
    }

    // void UpdatePosition() {
    //     if(instance == null) {
    //         return;
    //     }
    //     Vector3 targetPos = GetCameraTargetPosition();

    //     if (IsPlayerInCurrRoom()) {
    //         transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeedWhenRoomChange);
    //     }
    // }
    
    // Vector3 GetCameraTargetPosition() {
    //     if(currRoom == null) {
    //         return Vector3.zero;
    //     }

    //     Vector3 targetPos = currRoom.GetRoomCentre();
    //     targetPos.z = transform.position.z;

    //     return targetPos;
    // }

    bool IsPlayerInCurrRoom()
    {
        if (currRoom == null)
        {
            return false;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Collider2D roomCollider = currRoom.GetComponentInChildren<Collider2D>();
            if (roomCollider != null)
            {
                return roomCollider.bounds.Contains(player.transform.position);
            }
        }

        return false;
    }

    // public bool IsSwitchingScene() {
    //     return transform.position.Equals(GetCameraTargetPosition()) == false;
    // }
}