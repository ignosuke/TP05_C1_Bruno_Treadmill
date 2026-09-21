using UnityEngine;

[CreateAssetMenu(fileName = "PickupSo", menuName = "Data/Pickups/Pickup Data")]
public class PickupDataSo : ScriptableObject
{
    [SerializeField] private int scoreValue = 5;
    [SerializeField] private ParticleSystem collectEffect;

    public int GetScoreValue() => scoreValue;
    public ParticleSystem GetCollectEffect() => collectEffect;
}