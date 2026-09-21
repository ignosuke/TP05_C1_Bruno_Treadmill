using UnityEngine;

[CreateAssetMenu(fileName = "GroundSettings", menuName = "Data/Ground/Ground Settings")]
public class GroundSettingsSo : ScriptableObject
{
    [SerializeField] private float chunkWidth = 20f; // Tamaño de los chunks, necesario para calcular la posicion en que spawnearan los nuevos
    [SerializeField] private int activeChunkCount = 3; // La cantidad de chunks que estaran activos a la vez, con el ancho default de 20f se cubre toda la pantalla
                                                       // por lo que 3 es suficiente para que siempre haya: 1 saliendo, 1 en pantalla, 1 entrando

    [SerializeField] private GroundChunkSo firstChunk; // Para asegurar que el jugador empiece sobre un chunk llano
    [SerializeField] private GroundChunkSo[] chunkVariants; // Guarda los distintos chunks que pueden aparecer

    public float GetChunkWidth() => chunkWidth;
    public int GetActiveChunkCount() => activeChunkCount;
    public GroundChunkSo GetFirstChunk() => firstChunk;
    public GroundChunkSo[] GetChunkVariants() => chunkVariants;
}