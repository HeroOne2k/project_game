using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShield : MonoBehaviour
{
    public float speed;

    public Transform target;


    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
