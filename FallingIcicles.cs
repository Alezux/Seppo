using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will give the actions for the falling icicles
public class FallingIcicles : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject deathMenu;
    public Animator anim;
    public float lifetime;

    AudioSource ice_break;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //This will activate the icicles to fall when the player enters the area
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Seppo"))
            rb.isKinematic = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //This will activate when the icicles hit the player on the head, the player will die
        if (col.gameObject.name.Equals("Seppo"))
        {
            Debug.Log("Pelaajaan osui");
            deathMenu.SetActive(true);
        }

        //This will make the icicles destroy if they hit the ground and not the player
        else if (col.gameObject.name.Equals("GroundColliderit"))
        {
            ice_break = GetComponent<AudioSource>();
            ice_break.Play(0);
            anim.SetTrigger("icepick_impact");
            Destroy(gameObject, lifetime);
        }
    }
}
