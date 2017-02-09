using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void OnStartGameButtonPressed()
    {
        GameController.Instance.LauchGame();
    }

    public void OnQuitGameButtonPressed()
    {
        GameController.Instance.ExitGame();
    }
}
