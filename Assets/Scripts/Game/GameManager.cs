using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    
    private int totalCatsAmounts;
    private int cookieAmount;
    private int score;

    public Transform exitPoint;
    public TextMeshProUGUI scoreText;
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

    public int Score
    {
        get { return score; }
        set 
        { 
            score = Mathf.Max(0, value); 
            UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
{
    if (scoreText != null)
    {
        scoreText.text = "Score: " + Score.ToString();
    }
}
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);


            // no cookies at start
            cookieAmount = 0;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }


    public void AddScoreForFeedingCat(int timesFed)
    {
        Score += 5 * timesFed; // 3 points times the number of times the cat has been fed
    }

    public void SubtractScoreForUnhappyLeave()
    {
        Score -= 5; // Subtract 10 points for unhappy leave
    }
}
