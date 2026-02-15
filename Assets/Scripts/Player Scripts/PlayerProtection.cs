using UnityEngine;

public class PlayerProtection : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector3 startPosition;

    void Awake()
    {
        // Prevent this GameObject from being destroyed
        DontDestroyOnLoad(gameObject);
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        
        Debug.Log("PlayerProtection: Player is protected from destruction");
    }

    void Start()
    {
        // Ensure player is visible
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
            Color color = spriteRenderer.color;
            color.a = 1f; // Full opacity
            spriteRenderer.color = color;
        }
        
        gameObject.SetActive(true);
        Debug.Log("PlayerProtection: Player visibility ensured");
    }

    void Update()
    {
        // Keep checking if player is active
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            Debug.LogWarning("PlayerProtection: Player was deactivated, reactivating!");
        }

        // Check if player fell too far
        if (transform.position.y < -20)
        {
            transform.position = startPosition;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            Debug.LogWarning("PlayerProtection: Player fell too far, respawned at start");
        }
    }
}
