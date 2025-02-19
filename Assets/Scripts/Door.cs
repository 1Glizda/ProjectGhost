using UnityEngine;

public class Door : MonoBehaviour
{
    public enum DoorType { left, right, top, down }
    public DoorType doorType;
    
    [SerializeField] private Collider2D doorCollider;
    [SerializeField] private SpriteRenderer doorSpriteRenderer;
    private float widthOffset = 2f;
    private GameObject human, ghost;

    private void Start()
    {
        human = GameObject.FindGameObjectWithTag("Human");
        ghost = GameObject.FindGameObjectWithTag("Ghost");
        CacheDoorComponents();
    }

    private void CacheDoorComponents()
    {
        if (doorCollider == null)
            doorCollider = GetComponentInChildren<Collider2D>();
        
        if (doorSpriteRenderer == null)
            doorSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void PassDoor()
    {
        if (doorCollider != null && doorSpriteRenderer != null)
        {
            doorCollider.isTrigger = true;
            doorSpriteRenderer.color = Color.green;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Human") || other.CompareTag("Ghost"))
        {
            Vector2 newPosition = doorType switch
            {
                DoorType.down => new Vector2(transform.position.x, transform.position.y - widthOffset),
                DoorType.left => new Vector2(transform.position.x - widthOffset, transform.position.y),
                DoorType.right => new Vector2(transform.position.x + widthOffset, transform.position.y),
                DoorType.top => new Vector2(transform.position.x, transform.position.y + widthOffset),
                _ => other.transform.position
            };
            
            ghost.transform.position = newPosition;
            human.transform.position = newPosition;
        }
    }
}