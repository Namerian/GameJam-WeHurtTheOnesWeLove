using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameScript : MonoBehaviour
{
    protected bool GamePaused { get; private set; }

    // Use this for initialization
    void Awake()
    {
        Initialize();
    }

    protected void Initialize()
    {
        GamePaused = true;

        EventManager.Instance.OnGameStartedEvent += this.OnGameStarted;
        EventManager.Instance.OnGamePausedEvent += this.OnGamePaused;
        EventManager.Instance.OnGameUnpausedEvent += this.OnGameUnpaused;
        EventManager.Instance.OnGameEndedEvent += this.OnGameEnded;
    }

    protected virtual void OnGameStarted()
    {
        Debug.Log("game started");
        GamePaused = false;
    }

    protected virtual void OnGamePaused()
    {
        GamePaused = true;
    }

    protected virtual void OnGameUnpaused()
    {
        GamePaused = false;
    }

    protected virtual void OnGameEnded()
    {
        GamePaused = true;
    }
}
