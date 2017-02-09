using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenuController : MonoBehaviour
{
    public void OnExitToMenuButtonPressed()
    {
        GameController.Instance.LoadMenu();
    }
}
