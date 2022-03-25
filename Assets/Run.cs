using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public float speedRatio = 4.0f;
    public Animator animator;
    public Playermovement playerMovement;

    private bool isRunning;
    private bool isRunButtonPressed;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || isRunButtonPressed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        UpdateRunning();
    }
    public void UpdateRunning()
    {
        playerMovement.runSpeed = isRunning ? runSpeed : walkSpeed;
        animator.SetBool("IsRunning", isRunning);
    }

    public void OnRunButtonDown() => isRunButtonPressed = true;

    public void OnRunButtonUp() => isRunButtonPressed = false;
}