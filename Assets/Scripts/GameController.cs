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
        if(_gameOver && Input.anyKeyDown)
        {
            ExitGame();
        }

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
        EventManager.Instance.SendOnGamePausedEvent();

        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Additive);

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

    //====================================================================
    //
    //====================================================================

    private void SendGameStartedEvent()
    {
        EventManager.Instance.SendOnGameStartedEvent();
    }
}
