using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalObstacle : Obstacle
{
    public float _lowPosition;
    public float _highPosition;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private EDoorPosition _position;

    private bool _moving = false;

    void Awake()
    {
        Initialize();
    }

    // Use this for initialization
    void Start()
    {
        Vector3 position = this.transform.position;

        if (_position == EDoorPosition.high)
        {
            position.y = _highPosition;
        }
        else if (_position == EDoorPosition.low)
        {
            position.y = _lowPosition;
        }
        this.transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GamePaused && _moving)
        {
            Vector3 position = this.transform.position;

            if (_position == EDoorPosition.high)
            {
                position.y -= _speed * Time.deltaTime;

                if (position.y <= _lowPosition)
                {
                    position.y = _lowPosition;
                    _moving = false;
                    _position = EDoorPosition.low;
                }
            }
            else if (_position == EDoorPosition.low)
            {
                position.y += _speed * Time.deltaTime;

                if (position.y >= _highPosition)
                {
                    position.y = _highPosition;
                    _moving = false;
                    _position = EDoorPosition.high;
                }
            }

            this.transform.position = position;
        }
    }

    public override void Activate(LeverController lever)
    {
        if (!_moving)
        {
            _moving = true;
        }
    }
}
