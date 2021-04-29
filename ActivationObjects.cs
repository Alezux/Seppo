using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will activate the rest of the background objects
public class ActivationObjects : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject deathMenu;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name.Equals("Seppo"))
            rb.isKinematic = false;
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        //When the object hits the player, the player will die. For example, when a big snow pile falls on the player.
        if (col.gameObject.name.Equals("Seppo"))
        {
            deathMenu.SetActive(true);
        }

        //This will destroy the object, if the player was not hit
        else if (col.gameObject.name.Equals("GroundColliderit"))
        {
            
            Debug.Log("Esine tippui maahan");
            Destroy(gameObject);
        }
    }
}
