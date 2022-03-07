using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ExplosionController))]
public class BulletDroneFly : MonoBehaviour
{
    public float speed;
    public int damage;
    public ExplosionController explosionController;

    private void OnValidate()
    {
        explosionController = GetComponent<ExplosionController>();
    }

    // Update is called once per frame
    void Update() => transform.Translate(speed * Time.deltaTime,0 , 0);

    private void OnTriggerEnter2D(Collider2D intruder)
    {
        if (intruder.TryGetComponent<EnemyHealth>(out var enemyHealth))
        {
            enemyHealth.TakeDamage(damage);
        }
        Destroy(gameObject);
        explosionController.Explode();
    }

    private void OnBecameInvisible() => Destroy(gameObject);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
