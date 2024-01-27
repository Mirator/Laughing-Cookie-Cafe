using UnityEngine;
using System.Collections;

public class CookiePile : MonoBehaviour
{
    public int cookiesToAdd = 1;
    public float deactivationDuration = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.CookieAmount += cookiesToAdd;
                // Call the manager to handle the deactivation
                CookiePileManager.Instance.DeactivateCookiePile(gameObject, deactivationDuration);
            }
        }
    }
}
