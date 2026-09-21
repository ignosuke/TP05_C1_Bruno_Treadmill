using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class UiSounds : MonoBehaviour
{
    [SerializeField] private AudioClip clickClip;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        foreach (Button button in GetComponentsInChildren<Button>(true))
            button.onClick.AddListener(PlayClick);
    }

    private void PlayClick()
    {
        audioSource.PlayOneShot(clickClip);
    }
}