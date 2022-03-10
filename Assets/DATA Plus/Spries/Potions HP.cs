using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionsHP : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;// health
    private int maxLife;// maxHealthPotion
    private bool dead;//Die
    public Text myLife;

    void Start()
    {
        life = hearts.Length;
        maxLife = life;
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == true)
        {
            Debug.Log("We are dead !!!");
        }
        else
        {
            myLife.text = life.ToString();
        }
        
    }

    public void TagkeDamage(int damage)
    {
        if(life >= 1 )
        {
            life -= damage;
            //Destroy(hearts[life].gameObject);
            hearts[life].gameObject.SetActive(false);
        }
        if(life < 1)
        {
            dead = true;
        }

    }

    public void AddLife()
    {
        if(life < maxLife && dead == false)
        {
            hearts[life].gameObject.SetActive(true);
            life += 1;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Potion") && life < maxLife && dead == false)
        {
            AddLife();
            Destroy(collision.gameObject);

        }
    }
}
