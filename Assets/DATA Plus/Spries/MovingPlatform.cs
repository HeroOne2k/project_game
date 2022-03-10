using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MovingPlatform : MonoBehaviour
{
    public Transform beginPoint;
    public Transform endPoint;
    public float speed;

    private bool isForwarding;
    private Vector2 cachedBeginPoint;
    private Vector2 cachedEndPoint;

    void Start()
    {
        cachedBeginPoint = beginPoint.position;
        cachedEndPoint = endPoint.position;
        transform.position = cachedBeginPoint;
    }

    void Update()
    {
        var destination = isForwarding ? cachedEndPoint : cachedBeginPoint;
        transform.position = Vector2.MoveTowards(transform.position, destination,
            speed * Time.deltaTime); ;
        if ((Vector2)transform.position == destination)
        {
            isForwarding = !isForwarding;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(beginPoint.position, endPoint.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
