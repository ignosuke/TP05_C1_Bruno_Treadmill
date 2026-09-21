using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ScoreTracker))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerDeath playerDeath;
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;

    public event Action<GameState> OnStateChanged;

    private ScoreTracker scoreTracker;
    private GameState state = GameState.Playing;

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

    private void Update()
    {
        if (!Input.GetKeyDown(pauseKey)) return;

        if (state == GameState.Playing)
            Pause();
        else if (state == GameState.Paused)
            Resume();
    }

    public void Pause()
    {
        if (state != GameState.Playing) return;

        Time.timeScale = 0f;
        SetState(GameState.Paused);
    }

    public void Resume()
    {
        if (state != GameState.Paused) return; // Muerto no se puede reanudar

        Time.timeScale = 1f;
        SetState(GameState.Playing);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }

    public GameState GetState() => state;
    public int GetScore() => scoreTracker.GetScore();

    private void HandlePlayerDied()
    {
        scoreTracker.Stop();

        Time.timeScale = 0f;
        SetState(GameState.GameOver);
    }

    private void SetState(GameState newState)
    {
        state = newState;
        OnStateChanged?.Invoke(state);
    }
}