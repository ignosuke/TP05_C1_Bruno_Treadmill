using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class ScrollingTrail : MonoBehaviour
{
    [SerializeField] private ScrollSettingsSo scrollSettings;

    private TrailRenderer trail;

    private void Awake()
    {
        trail = GetComponent<TrailRenderer>();
    }

    private void LateUpdate()
    {
        float offset = scrollSettings.GetSpeed() * Time.deltaTime;

        for (int i = 0; i < trail.positionCount; i++)
        {
            Vector3 position = trail.GetPosition(i);
            position.x -= offset;
            trail.SetPosition(i, position);
        }
    }
}