using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : GameScript {
    [SerializeField]
    private float _speed;

	// Use this for initialization
	void Awake () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GamePaused)
        {
            this.transform.Translate(this.transform.right * _speed * Time.deltaTime);
        }
	}
}
