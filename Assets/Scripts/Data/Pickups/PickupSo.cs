using UnityEngine;

[CreateAssetMenu(fileName = "PickupSo", menuName = "Data/Pickups/Pickup Data")]
public class PickupDataSo : ScriptableObject
{
    [SerializeField] private int scoreValue = 5;

    public int GetScoreValue() => scoreValue;
}