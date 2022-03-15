using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ExplosionController))]
public class Health : MonoBehaviour
{
    //public GameObject[] hearts;
    public int maxHealthPoint;
    public ExplosionController explosionController;
    public UnityEvent onDead;
    public UnityEvent<Health> onDeadWithHealth;
    public UnityEvent onHealthChanged;

    private bool shielded;
    [SerializeField]
    private GameObject shield;

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

    private void Start()
    {
         //HealthPoint = hearts.Length;
         HealthPoint = maxHealthPoint;
    }

    private void Update()
    {
       // CheckShield();
    }

    public virtual void TakeDamage(int damage)
    {
        /* HealthPoint -= damage;
         if (HealthPoint <= 0) Die();*/
        if (HealthPoint >= 1)
        {
            HealthPoint -= damage;
            //Destroy(hearts[life].gameObject);
            //hearts[HealthPoint].gameObject.SetActive(false);
        }
        if (HealthPoint <= 0)
        {
            Die();
        }


    }

    public void CheckShield()
    {
        
        shield.SetActive(true);
        shielded = true;
        Invoke("NoShield", 3f);

    }

    public void NoShield()
    {
        shield.SetActive(false);
        shielded = false;
    }

    public void AddLife()
    {
        if (HealthPoint < maxHealthPoint && HealthPoint >= 0)
        {
            //hearts[HealthPoint].gameObject.SetActive(true);
            HealthPoint += 5;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shield") )//&& HealthPoint < maxHealthPoint && HealthPoint >= 0)
        {
            
            CheckShield();
            Destroy(collision.gameObject);
            Debug.Log("on Shield");
        }

        /*if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if(shielded == true)
            {
                healthPointValue = 20;
            }else
            {
                healthPointValue -= 0;
            }
                    
            collision.gameObject.SetActive(false);
        }*/

        /*if(collision.gameObject.tag == "Bullet")
        {
            if (shielded == true)
            {
                healthPointValue = 20;
            }
            else
            {
                healthPointValue -= 5;
            }
            collision.gameObject.SetActive(false);
        }*/

        if (collision.CompareTag("Potion") && HealthPoint < maxHealthPoint && HealthPoint >= 0)
        {
            AddLife();
            Destroy(collision.gameObject);
            Debug.Log("healing + 5HP");
        }

        //Code Coin Gold Touch
        if(collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Coin + 1");
        }

    }



    public virtual void Die()
    {
        explosionController.Explode();
        Destroy(gameObject);
        onDead.Invoke();
        onDeadWithHealth.Invoke(this);
    }
}
