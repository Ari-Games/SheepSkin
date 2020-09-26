using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace Flocking
{
    public class TargetMovement : MonoBehaviour
    {
        //Move target around circle with tangential speed
        public Vector2 bound;
        // public float speed = 10.0f;
        // private Vector2 initialPosition;
        // private Vector2 nextMovementPoint;
        void Start()
        {
            GetComponent<NavMeshAgent>().SetDestination(bound);;
        }
        // void CalculateNextMovementPoint()
        // {
        //     float posX = Random.Range(initialPosition.x = bound.x,
        //     initialPosition.x + bound.x);
        //     float posY = Random.Range(initialPosition.y = bound.y,
        //     initialPosition.y + bound.y);
        //     // float posZ = Random.Range(initialPosition.z = bound.z,
        //     // initialPosition.z + bound.z);
        //     nextMovementPoint = initialPosition +
        //     new Vector2(posX, posY);
        // }
        // void Update()
        // {
        //     transform.Translate((Vector2)(nextMovementPoint - (Vector2) transform.position) * speed * Time.deltaTime);
        //     // transform.rotation = Quaternion.Slerp(transform.rotation,
        //     // Quaternion.LookRotation(nextMovementPoint -
        //     // transform.position), 0);
        //      if (Vector2.Distance(nextMovementPoint, transform.position)
        //     <= 10.0f) CalculateNextMovementPoint();
        // }
    }

}