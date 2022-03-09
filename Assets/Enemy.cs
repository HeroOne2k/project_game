using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;

    public GameObject deathEffect;
    public GameObject reward;

    public void TakeDamage(int damage) 
    {
        health -= damage;

        if (health <= 0) 
        {
            Die();
        }

        void Die() 
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            if (reward != null)
            {
                Instantiate(reward, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
