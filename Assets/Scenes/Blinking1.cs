using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking1 : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer render;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        render.enabled = !render.enabled;
    }
}
