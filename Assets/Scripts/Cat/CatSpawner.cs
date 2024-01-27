using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public GameObject catPrefab; // Assign your cat prefab in the Inspector
    public int numberOfCats = 20;
    public float mapWidth = 50f; // Adjust as per your map size
    public float mapHeight = 50f; // Adjust as per your map size

    void Start()
    {
        SpawnCats();
    }

    void SpawnCats()
    {
        int numberOfCats = GameManager.Instance.TotalCatsAmounts;
        if (GameManager.Instance != null)
        {
            for (int i = 0; i < numberOfCats; i++)
            {
                float xPosition = Random.Range(-mapWidth / 2, mapWidth / 2);
                float yPosition = Random.Range(-mapHeight / 2, mapHeight / 2);
                Vector2 spawnPosition = new Vector2(xPosition, yPosition);

                Instantiate(catPrefab, spawnPosition, Quaternion.identity);
            }
        }

    }
}
