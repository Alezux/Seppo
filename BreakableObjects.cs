using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will make an object destroy, aka breakable
public class BreakableObjects : MonoBehaviour
{

    public float lifetime;
    public Animator anim;

    AudioSource ice_break;

    //When calling this function, the object will get destroyed
    public void BreakIt()
    {
        //This will give a break noise
        ice_break = GetComponent<AudioSource>();
        ice_break.Play(0);

        //This will destroy the object
        Destroy(this.gameObject, lifetime);

        //This will give the object breaking animation
        anim.SetTrigger("icecube1_break");
    }
}
