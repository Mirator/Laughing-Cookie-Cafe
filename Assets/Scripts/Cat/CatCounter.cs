using UnityEngine;
using TMPro;

public class CatCounter : MonoBehaviour
{
    public TextMeshProUGUI catCounterText; 

    void Update()
    {
        if (GameManager.Instance != null)
        {
            catCounterText.text = "Remaining Cats: " + GameManager.Instance.CatsRemaining;
        }
    }
}
