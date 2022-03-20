using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill1 : StateMachineBehaviour
{
    public float speed;
    public float attackRange;

    Transform player;
    Rigidbody2D rb;
    BossJulian boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossJulian>();
        animator.GetComponent<BossHealth>().isInvulnerable = true;
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossHealth>().isInvulnerable = false;
    }


}
