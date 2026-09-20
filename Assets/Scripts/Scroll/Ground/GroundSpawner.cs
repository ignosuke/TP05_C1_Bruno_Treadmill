using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GroundSettingsSo groundSettings;
    [SerializeField] private ScrollSettingsSo scrollSettings;

    private readonly List<GameObject> activeChunks = new();

    private void Start()
    {
        SpawnChunk(groundSettings.GetFirstChunk());

        for (int i = 1; i < groundSettings.GetActiveChunkCount(); i++)
            SpawnChunk(PickRandomChunk());
    }

    // LateUpdate en vez de Update para evitar un bug donde se provoca un desfase visual y hay unos pixeles de separacion
    // Asi, el chunk nuevo nace despues de que los demas ya se movieron este frame, y arranca sincronizado con ellos en el siguiente
    private void LateUpdate()
    {
        GameObject oldestChunk = activeChunks[0];

        if (oldestChunk.transform.position.x > scrollSettings.GetDespawnXPosition()) return;

        activeChunks.RemoveAt(0);
        Destroy(oldestChunk);

        SpawnChunk(PickRandomChunk());
    }

    private void SpawnChunk(GroundChunkSo chunkData)
    {
        float spawnX = activeChunks.Count == 0
            ? transform.position.x
            : activeChunks[^1].transform.position.x + groundSettings.GetChunkWidth();

        Vector3 position = new Vector3(spawnX, transform.position.y, 0f);

        activeChunks.Add(Instantiate(chunkData.GetPrefab(), position, Quaternion.identity));
    }

    // Sorteo ponderad tirando un numero entre 0 y la suma de pesos, y se recorre restando hasta que el acumulado lo alcanza
    private GroundChunkSo PickRandomChunk()
    {
        GroundChunkSo[] variants = groundSettings.GetChunkVariants();

        float totalWeight = 0f;

        foreach (GroundChunkSo variant in variants)
            totalWeight += variant.GetWeight();

        float roll = Random.Range(0f, totalWeight);

        foreach (GroundChunkSo variant in variants)
        {
            roll -= variant.GetWeight();

            if (roll <= 0f) return variant;
        }

        return variants[0]; // Fallback por si el redondeo de floats se pasa de largo
    }
}