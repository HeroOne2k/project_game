using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float jumpSpeed;

    public void Jumping()
    {
        rigid.velocity = Vector2.up * jumpSpeed;
    }

}