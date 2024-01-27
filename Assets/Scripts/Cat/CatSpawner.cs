using UnityEngine;
using System.Collections;

public class CatSpawner : MonoBehaviour
{
    public GameObject catPrefab;
    public Transform doorPosition;
    private AudioSource audioSource;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        PlaySpawnSound();
    }

    void PlaySpawnSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
