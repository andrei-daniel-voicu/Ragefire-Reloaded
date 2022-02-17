using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{

    private GameObject player;
    private PlayerController pc;
    private Animator anim;
    public float Speed;
    private Vector2 dir;
    private float remainingDistance;
    public float attackRange;
    public bool armed;

    public float attackDuration;
    public Direction Dir;

    public int health;
    public int currentHealth;

    public bool enemy_melee = false;
    public bool choosed = false;

    public enum Direction
    {
        idle,
        left,
        right,
        attack
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        armed = false;
        currentHealth = health;

    }

    void FixedUpdate()
    {
        if (currentHealth <= 0) Destroy(this.gameObject);
        else
        {
            UpdateAnimation();
            remainingDistance = Vector2.Distance(transform.position, player.transform.position);
            if (pc.armed == true)
            {
                if (armed == false)
                {
                    if (remainingDistance > attackRange)
                        Movement();
                }
                else
                {

                }
            }
            else
            {
                if (choosed == true) MoveToGun();
                else Movement();


            }

        }
    }
    private void Movement()
    {
        if (transform.position.x < player.transform.position.x)
            Dir = Direction.right;
        else if (transform.position.x > player.transform.position.x)
            Dir = Direction.left;
        else Dir = Direction.idle;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed);
    }
    private void MoveToGun()
    {
        GameObject gun = GameObject.FindGameObjectWithTag("Gun");
        transform.position = Vector2.MoveTowards(transform.position, gun.transform.position, Speed);


    }
    private void UpdateAnimation()
    {
        anim.SetInteger("direction", (int)Dir);

    }
}
