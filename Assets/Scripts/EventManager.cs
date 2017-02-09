using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnGameStartedDelegate();
public delegate void OnGamePausedDelegate();
public delegate void OnGameUnpausedDelegate();
public delegate void OnGameEndedDelegate();

public class EventManager
{
    private static EventManager _instance;

    public static EventManager Instance { get
        {
            if(_instance == null)
            {
                _instance = new EventManager();
            }

            return _instance;
        }
    }

    public event OnGameStartedDelegate OnGameStartedEvent;
    public event OnGamePausedDelegate OnGamePausedEvent;
    public event OnGameUnpausedDelegate OnGameUnpausedEvent;
    public event OnGameEndedDelegate OnGameEndedEvent;

    public void SendOnGameStartedEvent()
    {
        OnGameStartedDelegate tmp = OnGameStartedEvent;

        if (tmp != null)
        {
            Debug.Log("EventManager: game started");
            this.OnGameStartedEvent();
        }
    }

    public void SendOnGamePausedEvent()
    {
        OnGamePausedDelegate tmp = OnGamePausedEvent;

        if (tmp != null)
        {
            this.OnGamePausedEvent();
        }
    }

    public void SendOnGameUnpausedEvent()
    {
        OnGameUnpausedDelegate tmp = OnGameUnpausedEvent;

        if (tmp != null)
        {
            this.OnGameUnpausedEvent();
        }
    }

    public void SendOnGameEndedEvent()
    {
        OnGameEndedDelegate tmp = OnGameEndedEvent;

        if (tmp != null)
        {
            this.OnGameEndedEvent();
        }
    }
}
