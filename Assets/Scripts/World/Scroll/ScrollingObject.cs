using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    [SerializeField] private ScrollSettingsSo scrollSettings;
    private float speed;

    private void Awake()
    {
        speed = scrollSettings.GetSpeed();
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}