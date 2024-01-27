using UnityEngine;

public class CatBehavior : MonoBehaviour
{
    public Sprite happySprite;
    public Sprite defaultSprite;
    private SpriteRenderer spriteRenderer;
    private bool isPlayerNear = false;
    private bool isHappy = false;
    private bool isAtSpot = false;
    private int timesFed = 0;
    private int requiredFeedings;
    private float unhappyTimer = 0f;
    private float happyTimer = 0f; // Timer for how long the cat stays happy
    private CatMovement catMovement;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        catMovement = GetComponent<CatMovement>();
        requiredFeedings = Random.Range(1, 4); // Randomly determine required feedings between 1 and 3
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.Space) && !isHappy && isAtSpot)
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
        else
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
            happyTimer = Random.Range(5f, 60f); // Set how long the cat stays happy

            if (timesFed >= requiredFeedings)
            {
                LeaveCafeHappy(); // Leave happily after enough feedings
            }
        }
        else
        {
            Debug.Log("No cookies available");
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
        catMovement.LeaveCafe();
    }

    void LeaveCafeUnhappy()
    {
        catMovement.LeaveCafe();
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
