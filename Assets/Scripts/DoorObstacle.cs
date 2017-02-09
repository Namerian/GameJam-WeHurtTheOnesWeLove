using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObstacle : Obstacle
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private EDoorPosition _position;

    private bool _moving = false;

    // Use this for initialization
    void Start()
    {
        Vector3 position = this.transform.position;

        if (_position == EDoorPosition.high)
        {
            position.y = Constants.DOOR_HIGH_Y_POS;
        }
        else if (_position == EDoorPosition.low)
        {
            position.y = Constants.DOOR_LOW_Y_POS;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_moving)
        {
            Vector3 position = this.transform.position;

            if (_position == EDoorPosition.high)
            {
                position.y -= _speed * Time.deltaTime;

                if(position.y <= Constants.DOOR_LOW_Y_POS)
                {
                    position.y = Constants.DOOR_LOW_Y_POS;
                    _moving = false;
                    _position = EDoorPosition.low;
                }
            }
            else if (_position == EDoorPosition.low)
            {
                position.y += _speed * Time.deltaTime;

                if(position.y >= Constants.DOOR_HIGH_Y_POS)
                {
                    position.y = Constants.DOOR_HIGH_Y_POS;
                    _moving = false;
                    _position = EDoorPosition.high;
                }
            }

            this.transform.position = position;
        }
    }

    public override void Activate()
    {
        if (!_moving)
        {
            _moving = true;
        }
    }
}
