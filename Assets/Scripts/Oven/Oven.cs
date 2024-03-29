using UnityEngine;

public class Oven : MonoBehaviour
{
    public Sprite bakingSprite;
    public Sprite readySprite;
    private SpriteRenderer spriteRenderer;

    private bool isBaking = false; // Start with oven not baking
    private bool playerInTrigger = false; // Flag to check if the player is in the trigger zone
    private float bakingTimer = 10f;
    private AudioSource audioSource; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = readySprite; // Set the sprite to ready at the beginning
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Count down the timer only if the oven is baking
        if (isBaking)
        {
            bakingTimer -= Time.deltaTime;
            if (bakingTimer <= 0)
            {
                // When the timer hits zero, cookies are ready
                isBaking = false;
                spriteRenderer.sprite = readySprite;
                // Play the sound
                if (audioSource && audioSource.clip)
                {
                    audioSource.Play();
                }
            }
        }

        // When the player is near the oven and the cookies are ready
        if (playerInTrigger && !isBaking && Input.GetKeyDown(KeyCode.Space))
        {
            // Player collects the cookies
            GameManager.Instance.CookieAmount += 5;
            isBaking = true; // Start baking next batch
            spriteRenderer.sprite = bakingSprite;
            bakingTimer = 10f; // Reset the timer when starting the next batch
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }
}
