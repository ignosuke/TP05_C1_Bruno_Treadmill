using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private PickupDataSo pickupData;

    public int GetScoreValue() => pickupData.GetScoreValue();
}