using UnityEngine;

public class CatInteraction : MonoBehaviour
{
    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    private bool isPlayerNear = false;
    private bool isHappy = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.Space))
        {
            if (isHappy == false )
            {
                if (GameManager.Instance != null)
                {                  
                    if (GameManager.Instance.CookieAmount > 0)
                    {
                        isHappy = true;
                        spriteRenderer.sprite = newSprite;
                        GameManager.Instance.CatsRemaining--;
                        GameManager.Instance.CookieAmount--;
                    }
                    else
                    {
                        Debug.Log("Nejsou cookies");
                    }
                    
                }
            }
            
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
