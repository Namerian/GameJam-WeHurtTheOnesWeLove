using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public void OnResumeGameButtonPressed()
    {
        GameController.Instance.UnpauseGame();
    }

    public void OnExitGameButtonPressed()
    {
        GameController.Instance.LoadMenu();
    }
}
