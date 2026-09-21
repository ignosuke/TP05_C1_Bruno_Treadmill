using UnityEngine;

[CreateAssetMenu(fileName = "SpawnSlot", menuName = "Data/Obstacles/Spawn Slot")]
public class SpawnSlotSo : ScriptableObject
{
    [SerializeField, Range(0f, 1f)] private float spawnChance = .35f; // Probabilidad de que el punto quede ocupado
    [SerializeField] private GameObject[] candidates;

    public float GetSpawnChance() => spawnChance;
    public GameObject[] GetCandidates() => candidates;
}