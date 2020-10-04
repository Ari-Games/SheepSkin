using System;
using UnityEngine;
public class Sight : Sense
{
    public int fieldOfView = 90;
    public int viewDistance = 100;
    private int defaultField;
    public bool isDetected = false;
    public bool isLookAt = false;
    public Transform enemyTranform;

    private Transform playerTransform;
    private Vector2 rayDirection;

    protected override void Initialize()
    {
        defaultField = fieldOfView;
        if (GameObject.FindWithTag("Player") != null)
            playerTransform = GameObject.FindWithTag("Player").transform;
    }

    protected override void UpdateSense()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= detectionRate)
        {
            if (isLookAt)
            {
                fieldOfView = 360;
            }
            else
                fieldOfView = defaultField;
            DetectAspect();
            elapsedTime = 0f;
        }
    }

    private void DetectAspect()
    {
        RaycastHit2D hit;
        rayDirection = (Vector2)(playerTransform.position - transform.position);

        if (Vector2.Angle(rayDirection, transform.forward) <= fieldOfView)
        {
            // print(rayDirection);
            hit = Physics2D.Raycast((Vector2)transform.position, rayDirection, viewDistance);
            if(hit)
            {
                string collidedName = hit.collider.tag;
                if (collidedName == "Player")
                {
                    enemyTranform = hit.transform;
                    isDetected = true;
                    return;
                }
            }
        }
        enemyTranform = null;
        isDetected = false;
    }

    void OnDrawGizmos()
    {
        if (!Application.isEditor || playerTransform == null) return;
        Debug.DrawLine(transform.position, playerTransform.position, Color.red);
        Vector2 frontRayPoint = (Vector2)transform.position +
        (Vector2)(transform.forward * viewDistance);
        //Approximate perspective visualization
        Vector2 leftRayPoint = Quaternion.Euler(0, fieldOfView * 0.5f, 0) *
        frontRayPoint;
        Vector2 rightRayPoint = Quaternion.Euler(0, -fieldOfView * 0.5f, 0) *
        frontRayPoint;
        Debug.DrawLine((Vector2)transform.position + new Vector2(0, 1.5f), frontRayPoint, Color.green);
        Debug.DrawLine(transform.position, leftRayPoint, Color.blue);
        Debug.DrawLine(transform.position, rightRayPoint, Color.blue);
    }
}