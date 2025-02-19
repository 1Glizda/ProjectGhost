using UnityEngine;

public class HumanController : MonoBehaviour
{
    public static HumanController instance;
    public float speed;
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerCollider;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    public RuntimeAnimatorController defaultController;
    public static int collectedAmount = 0;
    public static int roomState = 1;
    private GameObject minimapCanvas;
    private Vector2 movement;
    private Vector2 lastDirection = new Vector2(0, -1); // Default facing front

    void Start()
    {
        instance = this;
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        // Get movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Prevent diagonal flipping issue
        if (movement != Vector2.zero)
        {
            // Prioritize horizontal movement first
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                lastDirection = new Vector2(movement.x, 0);
            }
            else
            {
                lastDirection = new Vector2(0, movement.y);
            }
        }

        // Pass values to Animator
        animator.SetFloat("MoveX", lastDirection.x);
        animator.SetFloat("MoveY", lastDirection.y);

        // Use Animator parameter instead of forcing animation
        animator.SetBool("isMoving", playerRigidbody.velocity.magnitude > 0.1f);
    }
}
