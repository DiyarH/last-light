using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public EventManager eventManager;
    public PlayerController player;
    public Text powerText;
    public Text gameOverText;
    public Text scoreText;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        eventManager.OnGameLost.AddListener(GameOver);
        eventManager.OnAsteroidDestroyed.AddListener(UpdateScoreText);
        eventManager.OnGameWon.AddListener(Win);
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {player.score}";
    }

    // Update is called once per frame
    void Update()
    {
        powerText.text = $"{String.Format("{0:0.0}", player.power)}%";
        timeText.text = $"Time remaining: {String.Format("{0:00}", (int)(player.remainingTime) / 60)}:{String.Format("{0:00}", (int)(player.remainingTime) % 60)}";
    }

    private void GameOver()
    {
        gameOverText.text = "You ran out of power.";
    }

    private void Win()
    {
        gameOverText.text = "You survived until the rescue ship found you.";
    }
}
