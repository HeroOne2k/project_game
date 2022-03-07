using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float interval;

    private float lastShotTime;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)
            && Time.time - lastShotTime >= interval)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            lastShotTime = Time.time;
        }
    }
}
