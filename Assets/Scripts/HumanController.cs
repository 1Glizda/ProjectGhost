using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;


public class HumanController : MonoBehaviour
{
    public static HumanController instance;
    public float speed;
    Rigidbody2D playerRigidbody;
    BoxCollider2D playerCollider;
    public static int collectedAmount = 0;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    public RuntimeAnimatorController defaultController;
    public static int roomState = 1;
    private GameObject minimapCanvas;
    

    void Start()
    {
        instance = this;
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = defaultController;
        minimapCanvas = GameObject.Find("MiniMap Canvas");
    }

    void FixedUpdate()
    {
        float horizontal = 0;
        float vertical = 0;
        float smoothFactor = 10f;

        if (Input.GetKey(KeyCode.A)) horizontal = -1;
        if (Input.GetKey(KeyCode.D)) horizontal = 1;
        if (Input.GetKey(KeyCode.S)) vertical = -1;
        if (Input.GetKey(KeyCode.W)) vertical = 1;

        Vector2 targetVelocity = new Vector2(horizontal * speed, vertical * speed);
        playerRigidbody.velocity = Vector2.Lerp(playerRigidbody.velocity, targetVelocity, Time.deltaTime * smoothFactor);    
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        //  if(roomState == 1) {
        //     if (horizontal >= 0f)
        //     {
        //         transform.localScale = new Vector2(0.12f, 0.12f);
        //     }
        //     else if (horizontal < 0f)
        //     {
        //         transform.localScale = new Vector2(-0.12f, 0.12f);
        //     }
        // }

        if (playerRigidbody.velocity.magnitude > 0.1f)
        {
            animator.Play("Move");
        }
        else
        {
            animator.Play("Idle");
        }
    }
  

    private void OnTriggerStay2D(Collider2D other)
    {}

    private void OnTriggerEnter2D(Collider2D other)
    {}

    private void OnTriggerExit2D(Collider2D other)
    {}
}

    //fixed update 50 PFS (1/50 -> 0.02) 0.02 * 100 -> 2m
    //update 10 FPS (dt = 1 / 10 -> 0.1) 0.1 * 100 -> 10 m