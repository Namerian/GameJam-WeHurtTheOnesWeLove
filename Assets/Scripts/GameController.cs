using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EventManager.Instance.SendOnGamePausedEvent();

            SceneManager.LoadScene("PauseMenuScene", LoadSceneMode.Additive);
        }
    }

    public void LauchGame()
    {
        SceneManager.UnloadSceneAsync("MenuScene");
        SceneManager.LoadScene("scene", LoadSceneMode.Additive);

        Invoke("SendGameStartedEvent", 2f);
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

    private void SendGameStartedEvent()
    {
        EventManager.Instance.SendOnGameStartedEvent();
    }
}
