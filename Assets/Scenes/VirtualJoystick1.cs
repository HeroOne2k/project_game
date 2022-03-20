using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour
{
    public Transform circle;
    public float radius;
    public Vector2 axes;

    private Vector2 originalPosition;

    private void Start() => originalPosition = circle.position;

    public void OnPointerDown(BaseEventData eventData) => UpdateJoystickPosition(eventData);

    public void OnDrag(BaseEventData eventData) => UpdateJoystickPosition(eventData);
    private void UpdateJoystickPosition(BaseEventData eventData)
    {
        var pointerEvent = eventData as PointerEventData;
        var offset = pointerEvent.position - originalPosition;
        offset = Vector2.ClampMagnitude(offset, radius);
        axes = offset / radius;
        circle.position = originalPosition + offset;
    }
    public void OnPointerUp(BaseEventData eventData)
    {
        var pointerEvent = eventData as PointerEventData;
        circle.position = originalPosition;
        axes = Vector2.zero;
    }
}