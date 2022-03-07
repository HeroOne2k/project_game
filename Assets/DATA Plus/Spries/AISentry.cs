using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISentry : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;
    private bool canShoot;

    public Rigidbody2D rb;
    public float range;
    public float walkSpeed;
    public float timeBTWShots;
    public float shootSpeed;

    public Transform player;
    public Transform groundCheckPos;
    public Transform shootPos;
    public Transform body;

    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public GameObject bullet;




    private float distToPlayer;

    void Start()
    {
        mustPatrol = true;
        canShoot = true;
    }

   
    void Update()
    {
        
        if (mustPatrol)
        {
            Patrol();
            
        }

        distToPlayer = Vector2.Distance(transform.position, player.position);
        

        if (distToPlayer <= range)
        {
            /*if(player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }*/
            if(player.position.x > transform.position.x && transform.localScale.x < 0)
            {
                UpdateBack();
                
                Flip();
            }
            else if(player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                UpdateFacing();
                Flip();
            }
            
            mustPatrol = false;
            rb.velocity = Vector2.zero;
            
            if (canShoot) 
            {
                  
                StartCoroutine(Shoot());
            }
            

        }
        else
        {
            mustPatrol = true;
            
        }

        
    }

    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
            
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
        
    }

      IEnumerator Shoot()
     {
         
         canShoot = false;
        
        yield return new WaitForSeconds(timeBTWShots);
         GameObject newBullet = Instantiate(bullet, shootPos.position, shootPos.rotation);

         newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);

         canShoot = true;
     }

    private void UpdateFacing()
    {
        
        //var yAngle = (rb.velocity.x < 0) ? -180 : 0;
        body.localRotation = Quaternion.Euler(0, -180, 0);
    }

    private void UpdateBack()
    {
        body.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
