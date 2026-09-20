using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Data/Player/Player Data")]
public class PlayerSo : ScriptableObject
{
    [Header("Jump")]
    [SerializeField] private KeyCode jumpKey = KeyCode.Mouse0;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float remainingForceOnTapJump = .4f; // Cuanto de la velocidad sobrevive al soltar
    public KeyCode GetJumpKey() => jumpKey;
    public float GetJumpForce() => jumpForce;
    public float GetRemainingForceOnTapJump() => remainingForceOnTapJump;

    [Header("Gravity")] // Gravedad custom para logica de salto personalizada
    [SerializeField] private float riseGravity = 3f;      // Mientras sube
    [SerializeField] private float fallGravity = 5f;      // Apenas empieza a caer
    [SerializeField] private float heavyFallGravity = 8f; // Caida acelerada
    [SerializeField] private float heavyFallThreshold = 8f; // Velocidad de caida a la que se activa
    public float GetRiseGravity() => riseGravity;
    public float GetFallGravity() => fallGravity;
    public float GetHeavyFallGravity() => heavyFallGravity;
    public float GetHeavyFallThreshold() => heavyFallThreshold;
}
