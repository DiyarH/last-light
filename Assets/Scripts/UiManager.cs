using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public EventManager eventManager;
    public EnergyStorageController energyStorage;
    public Text powerText;
    public Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        eventManager.OnGameLost.AddListener(GameOver);   
    }

    // Update is called once per frame
    void Update()
    {
        powerText.text = $"{String.Format("{0:0.0}", energyStorage.power)}%";
    }

    private void GameOver()
    {
        gameOverText.text = "You ran out of power.";
    }
}
