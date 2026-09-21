using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [Header("Panels")]
    [SerializeField] private UIPanel pausePanel;
    [SerializeField] private UIPanel settingsPanel;
    [SerializeField] private UIPanel creditsPanel;
    [SerializeField] private UIPanel gameOverPanel;

    [Header("Pause Buttons")]
    [SerializeField] private Button continueButton;
    [SerializeField] private Button pauseSettingsButton;
    [SerializeField] private Button pauseCreditsButton;
    [SerializeField] private Button pauseMainMenuButton;

    [Header("Game Over")]
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private Button gameOverRestartButton;
    [SerializeField] private Button gameOverBackButton;

    [Header("Back Buttons")]
    [SerializeField] private Button settingsBackButton;
    [SerializeField] private Button creditsBackButton;

    private void Awake()
    {
        continueButton.onClick.AddListener(gameManager.Resume);
        pauseSettingsButton.onClick.AddListener(() => ShowPanel(settingsPanel));
        pauseCreditsButton.onClick.AddListener(() => ShowPanel(creditsPanel));
        pauseMainMenuButton.onClick.AddListener(gameManager.GoToMainMenu);

        gameOverRestartButton.onClick.AddListener(gameManager.Restart);
        gameOverBackButton.onClick.AddListener(gameManager.GoToMainMenu);

        settingsBackButton.onClick.AddListener(() => ShowPanel(pausePanel));
        creditsBackButton.onClick.AddListener(() => ShowPanel(pausePanel));

        HideAll();
    }

    private void OnEnable()
    {
        gameManager.OnStateChanged += HandleStateChanged;
    }

    private void OnDisable()
    {
        gameManager.OnStateChanged -= HandleStateChanged;
    }

    private void HandleStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Playing:
                HideAll();
                break;

            case GameState.Paused:
                ShowPanel(pausePanel);
                break;

            case GameState.GameOver:
                gameOverScoreText.text = $"New Score:\n{gameManager.GetScore().ToString()}";
                ShowPanel(gameOverPanel);
                break;
        }
    }

    private void ShowPanel(UIPanel panel)
    {
        HideAll();
        panel.Open();
    }

    private void HideAll()
    {
        pausePanel.Close();
        settingsPanel.Close();
        creditsPanel.Close();
        gameOverPanel.Close();
    }
}