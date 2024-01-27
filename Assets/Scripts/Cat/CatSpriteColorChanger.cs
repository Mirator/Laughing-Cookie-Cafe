using UnityEngine;

public class CatSpriteColorChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color[] catColors = new Color[]
    {
        new Color(0.8f, 0.6f, 0.4f),  // Beige
        new Color(0.5f, 0.3f, 0.1f),  // Brown
        Color.black,                   // Black
        Color.white,                   // White
        Color.gray,                    // Gray
        new Color(1f, 0.8f, 0.6f),     // Cream
        new Color(0.1f, 0.1f, 0.1f),   // Charcoal
        new Color(0.6f, 0.5f, 0.4f),   // Chocolate
        new Color(0.8f, 0.8f, 0.8f),   // Light Gray
        new Color(0.9f, 0.6f, 0.2f)    // Ginger
    };

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeSpriteColorToRandom();
    }

    public void ChangeSpriteColorToRandom()
    {
        // Select a random color from the predefined set
        Color selectedColor = catColors[Random.Range(0, catColors.Length)];
        // Set the sprite to the selected color
        spriteRenderer.color = selectedColor;
    }
}
