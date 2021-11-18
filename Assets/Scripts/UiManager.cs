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
    // Start is called before the first frame update
    void Start()
    {
        eventManager.OnGameLost.AddListener(GameOver);
        eventManager.OnAsteroidDestroyed.AddListener(UpdateScoreText);
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {player.score}";
    }

    // Update is called once per frame
    void Update()
    {
        powerText.text = $"{String.Format("{0:0.0}", player.power)}%";
    }

    private void GameOver()
    {
        gameOverText.text = "You ran out of power.";
    }
}
