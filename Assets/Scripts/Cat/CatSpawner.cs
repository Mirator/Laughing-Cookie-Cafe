using UnityEngine;
using System.Collections;

public class CatSpawner : MonoBehaviour
{
    public GameObject catPrefab;
    public Transform doorPosition;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 10f;

    void Start()
    {
        StartCoroutine(SpawnCatsRandomly());
    }

    IEnumerator SpawnCatsRandomly()
    {
        while (true) // Infinite loop to keep spawning cats
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            SpawnCat();
        }
    }

    void SpawnCat()
    {
        Instantiate(catPrefab, doorPosition.position, Quaternion.identity);
    }
}
