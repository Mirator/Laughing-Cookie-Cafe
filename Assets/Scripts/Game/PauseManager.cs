using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Image screenOverlay;
    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        //screenOverlay.color = new Color(screenOverlay.color.r, screenOverlay.color.g, screenOverlay.color.b, 0f);
        TogglePause(); // Start the game in a paused state
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
        else if (isPaused && Input.GetKeyDown(KeyCode.Space))
        {
            Unpause(); // Unpause the game when Spacebar is pressed
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuUI.SetActive(isPaused);
        screenOverlay.color = new Color(screenOverlay.color.r, screenOverlay.color.g, screenOverlay.color.b, isPaused ? 0.5f : 0f);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void Unpause()
    {
        if (isPaused)
        {
            TogglePause();
        }
    }
}
