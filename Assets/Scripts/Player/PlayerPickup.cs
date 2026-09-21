using System;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private LayerMask pickupLayers;

    public event Action<int> OnPickedUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar por layer descarta computando menos, el componente trae el dato
        if (!IsInLayerMask(other.gameObject.layer, pickupLayers)) return;
        if (!other.TryGetComponent<Pickup>(out Pickup pickup)) return;

        OnPickedUp?.Invoke(pickup.GetScoreValue());
        Destroy(other.gameObject);
    }

    private bool IsInLayerMask(int layer, LayerMask mask)
    {
        return (mask.value & (1 << layer)) != 0;
    }
}