using UnityEngine;

public class SpawnSlot : MonoBehaviour
{
    [SerializeField] private SpawnSlotSo slotData;

    private void Start()
    {
        if (Random.value > slotData.GetSpawnChance()) return;

        GameObject[] candidates = slotData.GetCandidates();
        GameObject prefab = candidates[Random.Range(0, candidates.Length)];

        // Como hijo del slot: viaja con el chunk y se destruye con el
        Instantiate(prefab, transform);
    }
}