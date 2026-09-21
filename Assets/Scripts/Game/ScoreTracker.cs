using System;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private PlayerPickup playerPickup;
    [SerializeField] private ScrollSettingsSo scrollSettings;
    [SerializeField] private float pointsPerUnit = 1f;

    public event Action<int> OnScoreChanged;

    private float elapsedTime = 0f;
    private float rawScore; // Se acumula en float para no perder las fracciones de distancia
    private bool isRunning = true;

    private void OnEnable()
    {
        playerPickup.OnPickedUp += AddPoints;
    }

    private void OnDisable()
    {
        playerPickup.OnPickedUp -= AddPoints;
    }

    private void Update()
    {
        if (!isRunning) return;

        elapsedTime += Time.deltaTime;

        // El puntaje por distancia usa la velocidad de scroll, si acelera, suma mas rapido
        AddRaw(scrollSettings.GetSpeed() * pointsPerUnit * Time.deltaTime);
    }
    public void Stop()
    {
        isRunning = false;
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(rawScore);
    }

    private void AddPoints(int points)
    {
        AddRaw(points);
    }

    private void AddRaw(float amount)
    {
        int previousScore = GetScore();
        rawScore += amount;

        // Solo avisa cuando el entero visible cambia, no todos los frames
        if (GetScore() != previousScore)
            OnScoreChanged?.Invoke(GetScore());
    }

    public float GetElapsedTime() => elapsedTime;
}