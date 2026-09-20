using UnityEngine;

[CreateAssetMenu(fileName = "ScrollSettings", menuName = "Data/Scroll/Scroll Settings")]
public class ScrollSettingsSo : ScriptableObject
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float despawnXPosition = -25f;

    public float GetSpeed() => speed;
    public float GetDespawnXPosition() => despawnXPosition;
}