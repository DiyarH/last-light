using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent OnGameLost;
    public UnityEvent OnAsteroidDestroyed;
    public UnityEvent OnGameWon;
    void Awake()
    {
        OnGameLost = new UnityEvent();
        OnAsteroidDestroyed = new UnityEvent();
        OnGameWon = new UnityEvent();
    }
}
