using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script gives the player death
public class PlayerDeath : MonoBehaviour
{
    public GameObject deathMenu;

    AudioSource death;

    //When player enters on the death area, the player will die
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Seppo")
        {
            //This plays the sound when player dies
            death = GetComponent<AudioSource>();
            death.Play(0);

            //This will get you to the game over screen
            deathMenu.SetActive(true);

            //This will stop the game on the background
            Time.timeScale = 0;
        }
    }
}