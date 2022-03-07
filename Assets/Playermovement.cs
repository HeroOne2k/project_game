using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;
    private float runRatio = 1.0f;

    float horizontalMove = 0.0f;
    public bool jump = false;
    public bool crouch = false;
    public bool run = false;

    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * runRatio;
        //Debug.Log(Input.GetAxisRaw("Horizontal"));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch")) 
        {
            crouch = true;
            animator.SetBool("IsCrouch", crouch);

        } else if (Input.GetButtonUp("Crouch")) 
        {
            crouch = false;
            animator.SetBool("IsCrouch", crouch);
        }

        animator.SetBool("IsWalk", horizontalMove != 0);
        
        if (crouch == false && jump == false) 
        {
            if (Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift))
            {
                run = true;
                runRatio = 4f;
                animator.SetBool("IsRunning", run);
            }
            else
            {
                run = false;
                runRatio = 1.0f;
                animator.SetBool("IsRunning", run);
            }
        } else 
        {
            runRatio = 1.0f;
        }

        if (crouch == true && run == true) 
        {
            run = false;
            animator.SetBool("IsRunning", run);
            animator.SetBool("IsCrouch", crouch);
        } else 
        {
            animator.SetBool("IsRunning", run);
        }

        if (jump == true && run == true)
        {
            run = false;
            animator.SetBool("IsJump", jump);
            animator.SetBool("IsCrouch", crouch);
        }
        else
        {
            animator.SetBool("IsRunning", run);
        }
    }

    private void FixedUpdate()
    {
        //Move character 
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        animator.SetBool("IsJump", controller.IsGround() == false);
    }
}
