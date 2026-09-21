using TMPro;
using UnityEngine;

public class GameHUDManager : MonoBehaviour
{
    [SerializeField] private ScoreTracker scoreTracker;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text scoreText;

    private void OnEnable()
    {
        scoreTracker.OnScoreChanged += RefreshScore;
    }

    private void OnDisable()
    {
        scoreTracker.OnScoreChanged -= RefreshScore;
    }

    private void Start()
    {
        RefreshScore(scoreTracker.GetScore());
    }

    private void Update()
    {
        timeText.text = FormatTime(scoreTracker.GetElapsedTime());
    }

    private string FormatTime(float seconds)
    {
        int total = Mathf.FloorToInt(seconds);

        return $"Time: {total / 60:00}:{total % 60:00}";
    }

    private void RefreshScore(int score)
    {
        scoreText.text = $"Score: {score.ToString()}";
    }
}