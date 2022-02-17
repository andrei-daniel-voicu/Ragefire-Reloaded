using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeHitbox : MonoBehaviour
{

    // Use this for initialization

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
        
            PlayerController pc;
            pc = col.gameObject.GetComponent<PlayerController>();
            pc.currentHealth--;
        }
    }

}
