using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(EnemyHealth))]
public class EnemySuicide : MonoBehaviour
{
    public int damage;
    public EnemyHealth health;
    public bool isBoss;

    private void OnValidate() => health = GetComponent<EnemyHealth>();

    private void OnTriggerEnter2D(Collider2D intruder)
    {
        if (intruder.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            playerHealth.TakeDamage(damage);
            if (!isBoss)
            {
                health.Die();
            }
        }
    }
}
