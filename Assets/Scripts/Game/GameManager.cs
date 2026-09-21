using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerDeath playerDeath;
    private ScoreTracker scoreTracker;

    private void Awake()
    {
        scoreTracker = GetComponent<ScoreTracker>();

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
        scoreTracker.Stop();

        Debug.Log($"Game over. Score: {scoreTracker.GetScore()}");

        Time.timeScale = 0f; // Provisorio
    }
}