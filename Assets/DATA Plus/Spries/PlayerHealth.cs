using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public Animator anim;

    protected override void OnValidate()
    {
        base.OnValidate();
        anim = GetComponent<Animator>();
    }

    public override void TakeDamage(int damage)
    {
       // StartInvicible();
        base.TakeDamage(damage);
    }

    private void StartInvicible()
    {
        anim.SetBool("IsBlinking", true);
        gameObject.layer = LayerMask.NameToLayer("Neutral");
        Invoke(nameof(StopInvicible), 3f);
    }

    private void StopInvicible()
    {
        anim.SetBool("IsBlinking", false);
        gameObject.layer = LayerMask.NameToLayer("Ally");
    }
}
