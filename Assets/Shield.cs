using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    public float duration;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Shield")
        {
            SpawnShield();
            Destroy(GameObject.FindGameObjectWithTag("Shield"));
        }
    }

    private float lastTime;
    private bool shieldstatus;

    private void Start()
    {
        shieldstatus = false;
    }

   public void SpawnShield()
    {
        if (shieldstatus == false)
        {
            GameObject go = Instantiate(shield);
            go.transform.parent = GameObject.Find("Player").transform;
            shieldstatus = true;
        }

    }

    public void ShieldDown()
    {
        var elapsedTime = Time.time - lastTime;
        if (elapsedTime >= duration)
        shieldstatus = false;
        lastTime = Time.time;
    }

}
 
