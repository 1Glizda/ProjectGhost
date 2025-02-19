using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{
    public static Room instance;
    
    void Start()
    {
    }


    // public void PassDoor(Door.DoorType doorType)
    // {
    //     GameObject doorObject = null;

    //     switch (doorType)
    //     {
    //         case Door.DoorType.right:
    //             doorObject = transform.Find("RightDoor").gameObject;
    //             break;
    //         case Door.DoorType.left:
    //             doorObject = transform.Find("LeftDoor").gameObject;
    //             break;
    //         case Door.DoorType.top:
    //             doorObject = transform.Find("TopDoor").gameObject;
    //             break;
    //         case Door.DoorType.down:
    //             doorObject = transform.Find("DownDoor").gameObject;
    //             break;
    //     }

    //     if (doorObject != null)
    //     {
    //         Collider2D doorCollider = doorObject.GetComponentInChildren<Collider2D>();
    //         SpriteRenderer doorSpriteRenderer = doorObject.GetComponentInChildren<SpriteRenderer>();

    //         if (doorCollider != null && doorSpriteRenderer != null)
    //         {
    //             // Set the properties of the door based on the specified direction
    //             doorCollider.isTrigger = true;
    //             doorSpriteRenderer.color = Color.green;
    //         }
    //     }
    // }
}