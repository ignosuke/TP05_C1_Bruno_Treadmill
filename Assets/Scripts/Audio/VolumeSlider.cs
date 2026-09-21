using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string parameter; // Nombre del parametro expuesto en el mixer

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(HandleValueChanged);
    }

    private void OnEnable()
    {
        slider.SetValueWithoutNotify(AudioVolume.GetSaved(parameter));
    }

    private void OnDisable()
    {
        PlayerPrefs.Save();
    }

    private void HandleValueChanged(float value)
    {
        AudioVolume.Apply(mixer, parameter, value);
        AudioVolume.Save(parameter, value);
    }
}