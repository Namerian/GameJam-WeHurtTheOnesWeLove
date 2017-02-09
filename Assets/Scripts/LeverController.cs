using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    [SerializeField]
    private Sprite _closedSprite;
    [SerializeField]
    private Sprite _openSprite;
    [SerializeField]
    private ELeverPosition _position;
    [SerializeField]
    private Obstacle _obstacle;

    private SpriteRenderer _renderer;
    

    // Use this for initialization
    void Start()
    {
        _renderer = this.GetComponent<SpriteRenderer>();

        if(_position == ELeverPosition.closed)
        {
            _renderer.sprite = _closedSprite;
        }
        else if(_position == ELeverPosition.open)
        {
            _renderer.sprite = _openSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        if(_position == ELeverPosition.closed)
        {
            _position = ELeverPosition.open;
            _renderer.sprite = _openSprite;

            _obstacle.Activate(this);
        }
        else if(_position == ELeverPosition.open)
        {
            _position = ELeverPosition.closed;
            _renderer.sprite = _closedSprite;

            _obstacle.Activate(this);
        }
    }
}
