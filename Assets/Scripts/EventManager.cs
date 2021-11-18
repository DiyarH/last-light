using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent OnGameLost;
    void Awake()
    {
        OnGameLost = new UnityEvent();
    }
}
