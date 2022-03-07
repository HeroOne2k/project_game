using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveByMouse : MonoBehaviour
{
    public Animator anim;
    public Vector2 offset;

    private Camera mainCamera;
    private Vector2 desiredPosition;

    private void OnValidate() => anim = GetComponent<Animator>();

    private void Start() => mainCamera = Camera.main;

    void Update()
    {
        var lastX = transform.position.x;
        desiredPosition = MouseToWorldPoint() + offset;
        UpdatePosition();

        var currentX = transform.position.x;
        UpdateAnimation(lastX, currentX);
    }

    private Vector2 MouseToWorldPoint()
    {
        var mousePosition = Input.mousePosition;
        var worldPoint = mainCamera.ScreenToWorldPoint(mousePosition);
        return worldPoint;
    }

    private Vector2 velocity;
    private void UpdatePosition() 
        => transform.position = Vector2.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.2f);

    private void UpdateAnimation(float lastX, float currentX)
    {
        anim.SetBool("IsMovingLeft", currentX < lastX);
        anim.SetBool("IsMovingRight", currentX > lastX);
    }
}
