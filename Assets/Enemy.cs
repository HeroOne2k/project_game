using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;

    public GameObject deathEffect;
    public GameObject reward;
    public bool isBoss;

    public bool isInvulnerable = false;

    public void TakeDamage(int damage) 
    {
        health -= damage;

        if(isInvulnerable)
        {
            return;
        }

        if(isBoss == true)
        {
            if (health <= 100)
            {
                GetComponent<Animator>().SetBool("IsSkill1", true);
            }
            if(health <= 0)
            {
                Die();
            }
        }else if(isBoss == false)
        {
            if (health <= 0)
            {
                Die();
            }
        }

        

    }

    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        if (reward != null)
        {
            Instantiate(reward, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
