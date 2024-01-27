using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    
    private int totalCatsAmounts;
    private int catsRemaining;

    private int cookieAmount;

    public Transform exitPoint;
    public TextMeshProUGUI winningMessageText; 
    private static GameManager _instance;

    public static GameManager Instance
    { 
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    public int TotalCatsAmounts
    {
        get { return totalCatsAmounts; }
        set
        {
            if (value >= 0)
            {
                totalCatsAmounts = value;
            }
            else
            {
                Debug.LogError("TotalCatsAmounts cannot be negative.");
            }
        }
    }

    public int CatsRemaining
    {
        get { return catsRemaining; }
        set
        {
            if (value >= 0)
            {
                catsRemaining= value;
            }
            else
            {
                Debug.LogError("catsRemaining cannot be negative.");
            }
        }
    }

    public int CookieAmount
    {
        get { return cookieAmount; }
        set
        {
            if (value >= 0)
            {
                cookieAmount = value;
            }
            else
            {
                Debug.LogError("cookieAmount cannot be negative.");
            }
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);

            // Set initial cats amount to 20
            totalCatsAmounts = 20;
            catsRemaining = 20;

            // no cookies at start
            cookieAmount = 0;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        if (winningMessageText != null)
            winningMessageText.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (catsRemaining == 0)
        {

            ShowWinningMessage();
        }
    }

    private void ShowWinningMessage()
    {
        if (winningMessageText != null)
        {
            winningMessageText.gameObject.SetActive(true);
            winningMessageText.text = "You Won!";
            Debug.Log("Vyhra!");
        }
        else
        {
            Debug.LogError("Winning message text is not assigned in the inspector.");
        }
    }
}
