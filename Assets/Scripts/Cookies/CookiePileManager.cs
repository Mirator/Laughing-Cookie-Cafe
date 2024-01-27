using UnityEngine;
using System.Collections;

public class CookiePileManager : MonoBehaviour
{
    public static CookiePileManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void DeactivateCookiePile(GameObject cookiePile, float duration)
    {
        StartCoroutine(DeactivateForDuration(cookiePile, duration));
    }

    private IEnumerator DeactivateForDuration(GameObject cookiePile, float duration)
    {
        cookiePile.SetActive(false);
        yield return new WaitForSeconds(duration);
        cookiePile.SetActive(true);
    }
}
