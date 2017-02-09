using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryZoneController : MonoBehaviour {

    private List<PlayerController> _players = new List<PlayerController>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            PlayerController script = coll.GetComponent<PlayerController>();

            if (!_players.Contains(script))
            {
                _players.Add(script);
            }

            if(_players.Count == 2)
            {
                GameController.Instance.OnPlayersInVictoryZone();
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            PlayerController script = coll.GetComponent<PlayerController>();

            _players.Remove(script);
        }
    }
}
