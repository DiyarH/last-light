using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public EnergyStorageController energyStorage;
    public Text powerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        powerText.text = $"{String.Format("{0:0.0}", energyStorage.power)}%";
    }
}
