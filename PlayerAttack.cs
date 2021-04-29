using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script works for the player attack
public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    AudioSource melee_Hit;
    public Animator anim;

    void Update()
    {
        if (timeBtwAttack <= 1)
        {
            //Player can attack with a button
            if (Input.GetButtonDown("Attack"))
            {
                //This will give the player attack animation when the player is attacking
                anim.SetTrigger("attack");

                //This will choose all the attackable targets and will give the range for the attack
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                

                for(int i = 0; i < enemiesToDamage.Length; i++)
                {

                    //This will make the enemies take damage for the damages that were caused by player
                    if (enemiesToDamage[i].CompareTag("Enemy"))
                    {
                        melee_Hit = GetComponent<AudioSource>();
                        melee_Hit.Play(0);
                        enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    }

                    //This will make the icecubes take damage for the damages that were caused by player
                    if (enemiesToDamage[i].CompareTag("Icecube"))
                    {
                        enemiesToDamage[i].GetComponent<BreakableObject>().BreakIt();
                    }

                }

                timeBtwAttack = startTimeBtwAttack;
            }

            else
            {
                timeBtwAttack -= Time.deltaTime; 
            }
        }
    }
}
