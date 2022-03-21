using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSkeletalLeft : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;

    
    //public GameObject impactExplosion; //add prefabs explosion vào



    void Start()
    {

        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health player = collision.GetComponent<Health>();
        if(player != null)
        {
            player.TakeDamage(damage);

        }

        //Instantiate(impactExplosion, transform.position, transform.rotation);

        Destroy(gameObject);
    }

     private void OnBecameInvisible() => Destroy(gameObject);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
