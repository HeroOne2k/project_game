using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ExplosionController))]
public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public ExplosionController explosionController;
    public UnityEvent onDead;
    public UnityEvent<Health> onDeadWithHealth;
    public UnityEvent onHealthChanged;

    private int healthPointValue;
    public int HealthPoint {
        get => healthPointValue;
        set
        {
            healthPointValue = value;
            onHealthChanged.Invoke();
        }
    }

    protected virtual void OnValidate() => explosionController = GetComponent<ExplosionController>();

    private void Start() => HealthPoint = maxHealthPoint;

    public virtual void TakeDamage(int damage)
    {
        HealthPoint -= damage;
        if (HealthPoint <= 0) Die();
    }

    public virtual void Die()
    {
        explosionController.Explode();
        Destroy(gameObject);
        onDead.Invoke();
        onDeadWithHealth.Invoke(this);
    }
}
