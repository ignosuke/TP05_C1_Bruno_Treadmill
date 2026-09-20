using UnityEngine;

[CreateAssetMenu(fileName = "GroundChunk", menuName = "Data/Ground/Ground Chunk")]
public class GroundChunkSo : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float weight = 1f; // Spawner por peso

    public GameObject GetPrefab() => prefab;
    public float GetWeight() => weight;
}