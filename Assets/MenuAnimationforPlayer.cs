using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TravelMethod
{
    MoveToward,
    SmoothDamp
}
public class MenuAnimationforPlayer : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;
    public TravelMethod travelMethod;

    private int currentIndex;
    void Update()
    {
        var destination = waypoints[currentIndex].position;

        if (IsReached(destination))
        {
            currentIndex = (currentIndex + 1) % waypoints.Length;
        }
        else
        {
            UpdateMoving(destination);
        }
    }
    private bool IsReached(Vector3 destination)
    {
        return transform.position == destination;
    }

    private void UpdateMoving(Vector3 destination)
    {
        switch (travelMethod)
        {
            case TravelMethod.MoveToward:
                MoveToward(destination);
                break;
            case TravelMethod.SmoothDamp:
                MoveWithSmoothDamp(destination);
                break;
        }
    }
    private void MoveToward(Vector2 destination)
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    private Vector2 velocity;
    private void MoveWithSmoothDamp(Vector2 destination)
    {
        transform.position = Vector2.SmoothDamp(transform.position, destination, ref velocity, 0.4f, speed);
    }
}

