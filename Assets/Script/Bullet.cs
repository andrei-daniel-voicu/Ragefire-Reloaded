using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Use this for initialization
    public int speed;
    private Rigidbody2D rb;
    public int rot;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = (Input.mousePosition - sp).normalized;
        rb.AddForce(dir * rot * speed, ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.tag=="Enemy")
       {
           EnemyAI enemy=col.gameObject.GetComponent<EnemyAI>();
           enemy.currentHealth--;
           Destroy(this.gameObject);
       }
       
    }


}
