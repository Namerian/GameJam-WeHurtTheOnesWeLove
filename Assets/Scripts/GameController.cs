using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : GameScript
{
    public static GameController Instance { get; private set; }

    private bool _gameOver = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Initialize();
        }
        else
        {
            Destroy(this);
            return;
        }
        //DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GamePaused && Input.GetKeyDown(KeyCode.Escape))
        {
            EventManager.Instance.SendOnGamePausedEvent();

            SceneManager.LoadScene("PauseMenuScene", LoadSceneMode.Additive);
        }
    }

    //====================================================================
    //
    //====================================================================

    public void PlayerDied()
    {
        if (_gameOver)
        {
            return;
        }

        EventManager.Instance.SendOnGamePausedEvent();

        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Additive);

        _gameOver = true;
    }

    public void OnPlayersInVictoryZone()
    {
        if (_gameOver)
        {
            return;
        }

        EventManager.Instance.SendOnGamePausedEvent();

        SceneManager.LoadScene("VictoryScene", LoadSceneMode.Additive);

        _gameOver = true;
    }

    //====================================================================
    //
    //====================================================================

    public void LauchGame()
    {
        SceneManager.UnloadSceneAsync("MenuScene");
        SceneManager.LoadScene("scene", LoadSceneMode.Additive);

        Invoke("SendGameStartedEvent", 0.3f);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit ();
#endif
    }

    public void UnpauseGame()
    {
        SceneManager.UnloadSceneAsync("PauseMenuScene");

        EventManager.Instance.SendOnGameUnpausedEvent();
    }

    public void LoadMenu()
    {
        _gameOver = true;

        try
        {
            SceneManager.UnloadSceneAsync("scene");
        }
        catch(Exception e)
        {
            Debug.Log("Could not unload mainScene: " + e);
        }

        try
        {
            SceneManager.UnloadSceneAsync("PauseMenuScene");
        }
        catch (Exception e)
        {
            Debug.Log("Could not unload GameOverScene: " + e);
        }

        try
        {
            SceneManager.UnloadSceneAsync("GameOverScene");
        }
        catch (Exception e)
        {
            Debug.Log("Could not unload GameOverScene: " + e);
        }

        try
        {
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Additive);
        }
        catch(Exception e)
        {

        }
    }

    //====================================================================
    //
    //====================================================================

    private void SendGameStartedEvent()
    {
        EventManager.Instance.SendOnGameStartedEvent();
    }
}
