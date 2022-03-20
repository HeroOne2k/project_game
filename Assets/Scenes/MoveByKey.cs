using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class MoveByKey : MonoBehaviour
{
    // Start is called before the first frame update


    public Rigidbody2D rigid;
    public float runSpeed;
    public float jumpSpeed;
    public LayerMask groundLayers;
    public Transform body;
    public Animator anim;
    public VirtualJoystick2 joystick;



    private float xInput;
    private bool isOnGroundValue;

    // Update is called once per frame
    void Update()
    {
        UpdateXInput();
        isOnGroundValue = IsOnGround();
        anim.ResetTrigger("Jump");
        anim.SetBool("IsOnGround", isOnGroundValue);
        UpdateRunning();
        UpdateJumping();
        if (xInput != 0)
        {
            UpdateFacing();
        }
        UpdateAnimation();

        //// dung ki hieu len xuong

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.Translate(0.0f, 0f, 0.1f);
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.Translate(0.0f, 0f, -0.1f);
        //}

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(-0.1f, 0f, 0f);
        //}

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(0.1f, 0f, 0f);
        //}

        //// dung chu cai

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(0.1f, 0f, 0f);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(-0.1f, 0f, 0f);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(0.0f, 0f, -0.1f);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(0.0f, 0f, 0.1f);
        //}
    }

    private void UpdateXInput()
    {
        xInput = joystick.axes.x;
        if (xInput == 0)
        {
            xInput = Input.GetAxis("Horizontal");
        }
    }


    private void UpdateRunning()
    {
        if (xInput == 0) return;
        var newVelocity = rigid.velocity;
        newVelocity.x = xInput * runSpeed;
        rigid.velocity = newVelocity;
    }

    private void UpdateJumping()
    {
        if (JumpButtonPressed && isOnGroundValue)
        {
            anim.SetTrigger("Jump");
            var newVelocity = rigid.velocity;
            newVelocity.y = jumpSpeed;
            rigid.velocity = newVelocity;
        }
    }

    private bool IsOnGround()
    {
        var coll = Physics2D.OverlapCircle(transform.position, 0.2f, groundLayers);
        if (coll != null)
        {
            transform.SetParent(coll.transform);
            return true;
        }
        transform.SetParent(null);
        return false;
    }

    private bool JumpButtonPressed => Input.GetAxis("Jump") == 1 || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space);


    private void UpdateFacing()
    {
        var yAngle = (rigid.velocity.x < 0) ? 180 : 0; body.localRotation = Quaternion.Euler(0, yAngle, 0);
    }

    private void OnValidate()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void UpdateAnimation()
    {
        var isRunning = rigid.velocity.x != 0;
        anim.SetBool("IsRunning", isRunning && isOnGroundValue);
        anim.SetBool("IsOnGround", isOnGroundValue);
    }


}


