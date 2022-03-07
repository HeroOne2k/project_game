using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private float inputHorizontal;
    private float inputVertical;
    public float distance;
    public LayerMask whatIsLadder;
    bool isClimbing;
    public Animator animator;

    public Playermovement move;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
                move.jump = false;
                animator.SetBool("IsClimbing", isClimbing);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    isClimbing = false;
                    animator.SetBool("IsClimbing", isClimbing);
                    animator.SetBool("IsClimbMoving", false);
                }

            }
        }
        else 
        {
            animator.SetBool("IsClimbing", false);
            animator.SetBool("IsClimbMoving", false);
        }

        if (isClimbing == true && hitInfo.collider != null)
        {
            inputVertical = Input.GetAxisRaw("Vertical");

            if (inputVertical != 0.0f)
            {
                animator.SetBool("IsClimbMoving", true);
            }
            else
            {
                animator.SetBool("IsClimbMoving", false);
            }

            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 5;
            animator.SetBool("IsClimbing", false);
            animator.SetBool("IsClimbMoving", false);
        }
    }
}
