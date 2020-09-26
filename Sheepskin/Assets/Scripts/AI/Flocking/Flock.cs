using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

namespace Flocking
{
    public class Flock : MonoBehaviour
    {
        internal FlockController controller = null;
        new Rigidbody2D rigidbody = null;
        NavMeshAgent agent;
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            if(agent)
            {
                agent.updateRotation = false;
                agent.updateUpAxis = false;
            }
            rigidbody = GetComponent<Rigidbody2D>();
            // transform.rotation = Quaternion.identity;
            rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        void Update()
        {
            if (controller)
            {
                Vector2 relativePos = Steer() * Time.deltaTime;
                
                if (relativePos != Vector2.zero)
                {
                    rigidbody.velocity = relativePos;
                    agent.isStopped = false;
                    agent.SetDestination(controller.target.position);
                }



                // // enforce minimum and maximum speeds for the boids
                // float speed = rigidbody.velocity.magnitude;
                // if (speed > controller.maxVelocity)
                // {
                //     rigidbody.velocity = rigidbody.velocity.normalized *
                //     controller.maxVelocity;
                // }
                // else if (speed < controller.minVelocity)
                // {
                //     rigidbody.velocity = rigidbody.velocity.normalized *
                //     controller.minVelocity;
                // }
            }
        }

        private float DistanceToTarget(Vector3 targetMovement)
        {
            return Vector2.Distance(targetMovement, controller.target.position);
        }

        private Vector2 Steer()
        {
            Vector2 center = controller.flockCenter -
            (Vector2)transform.localPosition; // cohesion
            Vector2 velocity = (Vector2)controller.flockVelocity -
            rigidbody.velocity; // alignment
            Vector2 follow = controller.target.localPosition -
            transform.localPosition; // follow leader
            Vector2 separation = Vector2.zero;
            foreach (Flock flock in controller.flockList)
            {
                if (flock != this)
                {
                    Vector2 relativePos = transform.localPosition -
                    flock.transform.localPosition;
                    separation += relativePos / (relativePos.sqrMagnitude);
                }
            }
            // randomize
            Vector2 randomize = new Vector2((Random.value * 2) - 1,
            (Random.value * 2) - 1);
            randomize.Normalize();
            var steer = (Vector2)(controller.centerWeight * center +
            controller.velocityWeight * velocity +
            controller.separationWeight * separation +
            controller.followWeight * follow +
            controller.randomizeWeight * randomize);
            // print(steer);
            return steer;
        }
    }
}

