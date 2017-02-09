using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBoxController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            PlayerController playerScript = coll.GetComponent<PlayerController>();
            playerScript.ApplyDamage(int.MaxValue);
        }
    }
}
