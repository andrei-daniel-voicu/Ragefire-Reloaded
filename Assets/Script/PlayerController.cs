using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //publics
    public int speed;
    public int health;
    [HideInInspector] public int currentHealth;

    //privates
    private Vector2 input;
    private Vector2 move;

    //references
    private Rigidbody2D rb;
    private Animator anim;
    private direction dir;

    public GameObject left_hand;
    public GameObject right_hand;

    public bool armed;
    [SerializeField] private GameObject Projectile_Left;
    [SerializeField] private GameObject Projectile_Right;
    [SerializeField] private GameObject Projectile_Emitter_Left;
    [SerializeField] private GameObject Projectile_Emitter_Right;
    [SerializeField] private int Projectile_Speed;

    public GameObject gunPrefab;
    private GameObject gun;

    enum direction
    {
        idle,
        left,
        right,
        up,
        down
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        right_hand.SetActive(false);
        currentHealth = health;
        armed = true;
    }


    void Update()
    {
        if (currentHealth == 0) SceneManager.LoadScene(3);
        GetInput();
        UpdateDirection();
        UpdateAnimation();
    }
    void FixedUpdate()
    {
        Movement();

    }
    private void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0) && AmmoManager.instance.ammoLeft != 0 && armed == true)
        {

            Fire();
            AmmoManager.UseAmmo();

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (armed == true) DropWeapon();
        }

    }
    private void DropWeapon()
    {
        left_hand.transform.GetChild(0).gameObject.SetActive(false);
        right_hand.transform.GetChild(0).gameObject.SetActive(false);
        gun = Instantiate(gunPrefab) as GameObject;
        gun.transform.position = transform.position;
        armed = false;
        AmmoManager.HideAmmo();
    }
    public void PickWeapon()
    {
        left_hand.transform.GetChild(0).gameObject.SetActive(true);
        right_hand.transform.GetChild(0).gameObject.SetActive(true);
        armed = true;
    }
    private void UpdateDirection()
    {

        if (input.x == 1)
        {
            dir = direction.right;
            left_hand.SetActive(false);
            right_hand.SetActive(true);
        }

        else if (input.x == -1)
        {
            left_hand.SetActive(true);
            right_hand.SetActive(false);
            dir = direction.left;
        }

        else
        {
            left_hand.SetActive(true);
            right_hand.SetActive(false);
            dir = direction.idle;
        }

    }
    private void Movement()
    {

        move = rb.velocity;
        move.x = input.x * speed;
        move.y = input.y * speed;
        rb.velocity = move;

    }

    private void UpdateAnimation()
    {
        anim.SetInteger("direction", (int)dir);

    }
    private void Fire()
    {
        GameObject Temporary_Projectile_Handler;
        if (dir == direction.left || dir == direction.idle)
            Temporary_Projectile_Handler = Instantiate(Projectile_Left, Projectile_Emitter_Left.transform.position, Projectile_Emitter_Left.transform.rotation) as GameObject;
        else
            Temporary_Projectile_Handler = Instantiate(Projectile_Right, Projectile_Emitter_Right.transform.position, Projectile_Emitter_Right.transform.rotation) as GameObject;

        Destroy(Temporary_Projectile_Handler, 2.0f);
    }
}
