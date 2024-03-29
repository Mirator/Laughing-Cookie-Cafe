using UnityEngine;

public class CatBehavior : MonoBehaviour
{
    public Sprite happySprite;
    public Sprite defaultSprite;
    private SpriteRenderer spriteRenderer;
    private bool isPlayerNear = false;
    private bool isHappy = false;
    private bool isAtSpot = false;
    private bool isLeaving = false;
    private int timesFed = 0;
    private int requiredFeedings;
    private float unhappyTimer = 0f;
    private float happyTimer = 0f; // Timer for how long the cat stays happy
    private AudioSource audioSource; // Reference to the AudioSource component
    private CatMovement catMovement;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        catMovement = GetComponent<CatMovement>();
        requiredFeedings = Random.Range(1, 4); // Randomly determine required feedings between 1 and 3
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.Space) && !isHappy && isAtSpot && !isLeaving)
        {
            FeedCat();
        }

        if (isHappy)
        {
            happyTimer -= Time.deltaTime;
            if (happyTimer <= 0)
            {
                MakeCatUnhappy();
            }
        }
        else if (!isLeaving) // Check if the cat is not already leaving
        {
            unhappyTimer += Time.deltaTime;
            if (unhappyTimer >= Random.Range(5f, 60f)) // Unhappy leave timer
            {
                LeaveCafeUnhappy();
            }
        }
    }
    public void SetAtSpot(bool status)
    {
        isAtSpot = status;
        if (isAtSpot) 
        {
            unhappyTimer = 0; // Reset unhappy timer when cat reaches the spot
        }
    }

    void FeedCat()
    {
        if (GameManager.Instance != null && GameManager.Instance.CookieAmount > 0)
        {
            timesFed++;
            isHappy = true;
            spriteRenderer.sprite = happySprite;
            GameManager.Instance.CookieAmount--;
            // Play the sound
            if (audioSource && audioSource.clip)
            {
                audioSource.Play();
            }
            happyTimer = Random.Range(5f, 60f); // Set how long the cat stays happy
            GameManager.Instance.AddScoreForFeedingCat(timesFed);
            if (timesFed >= requiredFeedings)
            {
                LeaveCafeHappy(); // Leave happily after enough feedings
            }
        }


    }

    void MakeCatUnhappy()
    {
        isHappy = false;
        spriteRenderer.sprite = defaultSprite;
        unhappyTimer = 0; // Reset the unhappy timer
    }

    void LeaveCafeHappy()
    {
        isLeaving = true;
        catMovement.LeaveCafe();
    }

    void LeaveCafeUnhappy()
    {
        if (!isLeaving) // Ensure this method runs only once
        {
            isLeaving = true;
            GameManager.Instance.SubtractScoreForUnhappyLeave();
            catMovement.LeaveCafe();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
