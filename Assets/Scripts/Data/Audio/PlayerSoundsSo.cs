using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSounds", menuName = "Data/Player/Player Sounds")]
public class PlayerSoundsSo : ScriptableObject
{
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip pickupClip;
    [SerializeField] private AudioClip deathClip;

    public AudioClip GetJumpClip() => jumpClip;
    public AudioClip GetPickupClip() => pickupClip;
    public AudioClip GetDeathClip() => deathClip;
}