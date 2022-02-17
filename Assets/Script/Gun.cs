using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int magazine;
    public int ammoLeft;
    void Start()
    {
        ammoLeft = magazine;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            PlayerController pc;
            pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            Destroy(this.gameObject);
            pc.PickWeapon();
            AmmoManager.instance.ammoLeft = ammoLeft;
            AmmoManager.instance.magazine = magazine;
            AmmoManager.ShowAmmo();
            AmmoManager.UpdateText();

        }

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            PlayerController pc;
            pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            Destroy(this.gameObject);
            AmmoManager.instance.ammoLeft = ammoLeft;
            AmmoManager.instance.magazine = magazine;
            AmmoManager.UpdateText();
            AmmoManager.ShowAmmo();
            pc.PickWeapon();
        }
    }
}
