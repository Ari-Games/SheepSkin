using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace Flocking
{
    public class TargetMovement : MonoBehaviour
    {
        //Move target around circle with tangential speed
        public Vector2 bound;


        [SerializeField]
        Transform movementPath = null;
        public int currentPoint = 1;
        public int countOfPoints = 0;


        void Start()
        {
            GetComponent<NavMeshAgent>().SetDestination(bound);;
        }
        
    }

}