using System;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private LayerMask lethalLayer;

    public event Action OnDied;
    private bool isDead;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return; // En caso de tocar dos obstaculos a la vez, solo triggerea una muerte
        if (!IsInLayerMask(other.gameObject.layer, lethalLayer)) return;

        isDead = true;
        OnDied?.Invoke();
    }

    private bool IsInLayerMask(int layer, LayerMask mask)
    {
        return (mask.value & (1 << layer)) != 0;
    }
}