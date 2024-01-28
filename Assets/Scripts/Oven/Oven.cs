using UnityEngine;

public class Oven : MonoBehaviour
{
    public Sprite bakingSprite;
    public Sprite readySprite;
    private SpriteRenderer spriteRenderer;

    private bool isBaking = false; // Start with oven ready
    private float bakingTimer = 10f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Set the sprite to ready at the beginning
        spriteRenderer.sprite = isBaking ? bakingSprite : readySprite;
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
                // Do not reset the timer here since it will be reset when cookies are collected
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // When the player is near the oven and the cookies are ready
        if (other.CompareTag("Player") && !isBaking && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Bere to mezernik!");
            // Player collects the cookies
            GameManager.Instance.CookieAmount += 10;
            isBaking = true; // Start baking next batch
            spriteRenderer.sprite = bakingSprite;
            bakingTimer = 10f; // Reset the timer when starting the next batch
        }
    }
}
