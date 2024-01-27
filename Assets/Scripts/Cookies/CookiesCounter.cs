using UnityEngine;
using TMPro;

public class CookiesCounter : MonoBehaviour
{
    public TextMeshProUGUI cookiesCounterText; 

    void Update()
    {
        if (GameManager.Instance != null)
        {
            cookiesCounterText.text = "Cookies: " + GameManager.Instance.CookieAmount;
        }
    }
}
