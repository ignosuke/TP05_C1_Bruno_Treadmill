using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private PickupDataSo pickupData;

    public int GetScoreValue() => pickupData.GetScoreValue();

    public void Collect()
    {
        ParticleSystem effect = pickupData.GetCollectEffect();

        if (effect != null)
            Instantiate(effect, transform.position, Quaternion.identity, transform.parent);

        Destroy(gameObject);
    }
}