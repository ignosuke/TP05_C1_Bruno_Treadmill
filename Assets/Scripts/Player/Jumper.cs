using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private PlayerSo playerData;
    private KeyCode jumpKey;
    private float jumpForce;
    private float remainingForceOnTapJump; // Cuanto de la velocidad sobrevive al soltar

    private float riseGravity;          // Mientras sube
    private float fallGravity;          // Apenas empieza a caer
    private float heavyFallGravity;     // Caida acelerada
    private float heavyFallThreshold;   // Velocidad de caida a la que se activa

    private Rigidbody2D rb;
    private bool jumpRequested;
    private bool jumpCutRequested;

    void Awake()
    {
        jumpKey = playerData.GetJumpKey();
        jumpForce = playerData.GetJumpForce();
        remainingForceOnTapJump = playerData.GetRemainingForceOnTapJump();

        riseGravity = playerData.GetRiseGravity();
        fallGravity = playerData.GetFallGravity();
        heavyFallGravity = playerData.GetHeavyFallGravity();
        heavyFallThreshold = playerData.GetHeavyFallThreshold();

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // GetKeyDown y GetKeyUp se resetean por frame de render: hay que leerlos aca, no en FixedUpdate
        if (Input.GetKeyDown(jumpKey))
            jumpRequested = true;

        if (Input.GetKeyUp(jumpKey))
            jumpCutRequested = true;
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        HandleTapJump();
        HandleJump();
    }

    private void HandleJump()
    {
        if (!jumpRequested) return;

        jumpRequested = false;

        if (CanJump())
            Jump();
    }

    private bool CanJump()
    {
        return rb.linearVelocity.y == 0f;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Al soltar la tecla durante la subida se corta parte de la velocidad: tap = salto bajo, hold = salto completo
    private void HandleTapJump()
    {
        if (!jumpCutRequested) return;

        jumpCutRequested = false;

        if (rb.linearVelocity.y > 0f)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * remainingForceOnTapJump);
    }

    // Gravedad personalizada, primero sube liviano, acelera al bajar y cuando la caida pasa cierta velocidad acelera de golpe
    private void ApplyGravity()
    {
        float verticalSpeed = rb.linearVelocity.y;

        if (verticalSpeed > 0f)
            rb.gravityScale = riseGravity;
        else if (verticalSpeed > -heavyFallThreshold)
            rb.gravityScale = fallGravity;
        else
            rb.gravityScale = heavyFallGravity;
    }
}