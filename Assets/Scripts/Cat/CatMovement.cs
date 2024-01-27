using UnityEngine;
using System.Linq;

public class CatMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform targetSpot;
    private bool shouldMove = false;
    private Transform exitPoint;

    void Start()
    {
        exitPoint = GameManager.Instance.exitPoint;
        ChooseNextSpot();
    }

    void ChooseNextSpot()
    {
        CatSpot[] spots = FindObjectsOfType<CatSpot>();
        CatSpot availableSpot = null;

        if (Random.value > 0.5f)
        {
            // Linear sequence selection
            for (int i = 0; i < spots.Length; i++)
            {
                if (!spots[i].isOccupied)
                {
                    availableSpot = spots[i];
                    break;
                }
            }
        }
        else
        {
            // Random selection
            var shuffledSpots = spots.OrderBy(x => Random.value).ToList();
            availableSpot = shuffledSpots.FirstOrDefault(spot => !spot.isOccupied);
        }

        if (availableSpot != null)
        {
            SetTarget(availableSpot.transform);
            availableSpot.SetOccupied(true);
            shouldMove = true;
        }
        else
        {
            // No available spots, leave the cafe
            LeaveCafe();
        }
    }

    public void SetTarget(Transform target)
    {
        targetSpot = target;
    }

    public void LeaveCafe()
    {
        if (targetSpot != null)
        {
            CatSpot currentSpot = targetSpot.GetComponent<CatSpot>();
            if (currentSpot != null)
            {
                currentSpot.FreeSpot();
            }
        }
        SetTarget(exitPoint);
        shouldMove = true;
    }

    void Update()
    {
        if (shouldMove && targetSpot != null)
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetSpot.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetSpot.position) < 0.1f)
        {
            OnReachedTarget();
        }
    }

void OnReachedTarget()
{
    if (targetSpot == exitPoint)
    {
        Destroy(gameObject); // Destroy the cat once it reaches the exit
    }
    else //catSpot
    {
        CatBehavior catBehavior = GetComponent<CatBehavior>();
        if (catBehavior != null)
        {
            catBehavior.SetAtSpot(true); // Cat has reached the spot
        }
        shouldMove = false; // Stop moving until the next target is set
    }
}

}
