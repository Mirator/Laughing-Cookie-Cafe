using UnityEngine;

public class CatSpot : MonoBehaviour
{
    public bool isOccupied = false;

    public void SetOccupied(bool status)
    {
        isOccupied = status;
    }
    public void FreeSpot()
    {
        isOccupied = false;
    }
}
