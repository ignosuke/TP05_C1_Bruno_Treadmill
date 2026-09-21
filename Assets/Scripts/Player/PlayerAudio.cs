using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private PlayerSoundsSo sounds;

    private AudioSource audioSource;
    private Jumper jumper;
    private PlayerPickup playerPickup;
    private PlayerDeath playerDeath;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        jumper = GetComponent<Jumper>();
        playerPickup = GetComponent<PlayerPickup>();
        playerDeath = GetComponent<PlayerDeath>();
    }

    private void OnEnable()
    {
        jumper.OnJumped += PlayJump;
        playerPickup.OnPickedUp += PlayPickup;
        playerDeath.OnDied += PlayDeath;
    }

    private void OnDisable()
    {
        jumper.OnJumped -= PlayJump;
        playerPickup.OnPickedUp -= PlayPickup;
        playerDeath.OnDied -= PlayDeath;
    }

    private void PlayJump()
    {
        audioSource.PlayOneShot(sounds.GetJumpClip());
    }

    private void PlayPickup(int scoreValue)
    {
        audioSource.PlayOneShot(sounds.GetPickupClip());
    }

    private void PlayDeath()
    {
        audioSource.PlayOneShot(sounds.GetDeathClip());
    }
}