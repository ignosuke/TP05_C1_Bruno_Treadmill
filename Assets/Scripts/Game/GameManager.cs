using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Death playerDeath;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        playerDeath.OnDied += HandlePlayerDied;
    }

    private void OnDisable()
    {
        playerDeath.OnDied -= HandlePlayerDied;
    }

    private void HandlePlayerDied()
    {
        Time.timeScale = 0f; // Provisorio
        Debug.Log("Game over");
    }
}