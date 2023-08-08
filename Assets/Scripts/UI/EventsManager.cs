using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;

    private void Awake()
    {
        instance = this;
    }

    public delegate void EventHandler(int paramValue);
    public event EventHandler OnActionButtonClick;
    public event EventHandler OnGoldChange;
    public event EventHandler OnEnergyChange;


    public void StartChangeGoldEvent(int value)
    {
        OnGoldChange?.Invoke(value);
    }

    public void StartChangeEnergyEvent(int value)
    {
        OnEnergyChange?.Invoke(value);
    }
}
