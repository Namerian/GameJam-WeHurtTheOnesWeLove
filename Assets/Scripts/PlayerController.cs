using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string _inputPrefix;
    [SerializeField]
    private float _horizontalThrust;
    [SerializeField]
    private float _verticalThrust;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private int _healthPoints;

    private Rigidbody2D _rigidbody;
    private LeverController _lever;
    private bool _actionButtonDown;
    private bool _canJump;

    // Use this for initialization
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputPrefix != "")
        {
            //**********************************************
            // MOVEMENT
            bool rightButtonDown = false;
            bool leftButtonDown = false;
            bool jumpButtonDown = false;

            if (Input.GetAxis(_inputPrefix + "Right") == 1)
            {
                _rigidbody.AddForce(this.transform.right * _horizontalThrust);
                rightButtonDown = true;
            }
            else if (Input.GetAxis(_inputPrefix + "Left") == 1)
            {
                _rigidbody.AddForce(-1 * this.transform.right * _horizontalThrust);
                leftButtonDown = true;
            }


            if (Input.GetButtonDown(_inputPrefix + "Up") && _canJump)
            {
                _rigidbody.AddForce(this.transform.up * _verticalThrust);
                jumpButtonDown = true;
                _canJump = false;
            }

            Vector2 velocity = _rigidbody.velocity;
            if (rightButtonDown)
            {
                velocity.x = _maxSpeed;
                _rigidbody.velocity = velocity;
            }
            else if (leftButtonDown)
            {
                velocity.x = -1 * _maxSpeed;
                _rigidbody.velocity = velocity;
            }
            else
            {
                velocity.x = 0;
                _rigidbody.velocity = velocity;
            }
            if (jumpButtonDown)
            {
                    velocity.y = _maxSpeed;
                    _rigidbody.velocity = velocity;
            }

            //**********************************************
            // ACTION

            bool actionButton = Input.GetAxis(_inputPrefix + "Down") == 1;

            if(!_actionButtonDown && actionButton)
            {
                if(_lever != null)
                {
                    _lever.Activate();
                    _actionButtonDown = true;
                }
            }
            else if(_actionButtonDown && !actionButton)
            {
                _actionButtonDown = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Lever"))
        {
            _lever = coll.GetComponent<LeverController>();
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Lever") && _lever == coll.GetComponent<LeverController>())
        {
            _lever = null;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        _canJump = true;
    }

    public void ApplyDamage(int dmg)
    {
        _healthPoints -= dmg;

        if(_healthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

    }

    void OnDestroy()
    {
        GameController.Instance.PlayerDied();
    }
