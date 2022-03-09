using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking1 : MonoBehaviour
{
    public float interval;

    private SpriteRenderer render;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(SwitchState), 0, interval);
    }

    private void SwitchState() => render.enabled = !render.enabled;

}
