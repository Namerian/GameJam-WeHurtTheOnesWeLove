using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    [Header("Door Obstacle")]

    [SerializeField]
    private float _doorHighYPos;
    [SerializeField]
    private float _doorLowYPos;


    //=============================================
    //
    //=============================================

    private static Constants Instance { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static float DOOR_HIGH_Y_POS { get { return Instance._doorHighYPos; } }

    public static float DOOR_LOW_Y_POS { get { return Instance._doorLowYPos; } }
}
