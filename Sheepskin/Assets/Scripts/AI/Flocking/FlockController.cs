using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Flocking
{
    public class FlockController : MonoBehaviour
    {
        public float minVelocity = 1; //Min Velocity
        public float maxVelocity = 8; //Max Flock speed
        public int flockSize = 20; //Number of flocks in the group
                                //weight stick closer to the center)
        public float centerWeight = 1;
        public float velocityWeight = 1; //Alignment behavior
                                        //How far each boid should be separated within the flock
        public float separationWeight = 1;
        //How close each boid should follow to the leader (the more
        //weight make the closer follow)
        public float followWeight = 1;
        //Additional Random Noise
        public float randomizeWeight = 1;
        public Flock prefab;
        public Transform target;
        //Center position of the flock in the group
        internal Vector2 flockCenter;
        internal Vector2 flockVelocity; //Average Velocity
        public ArrayList flockList = new ArrayList();

        void Start()
        {
            for (int i = 0; i < flockSize; i++)
            {
                Flock flock = Instantiate(prefab, transform.position,
                Quaternion.identity) as Flock;
                flock.transform.parent = transform;
                flock.controller = this;
                flockList.Add(flock);
            }
        }

        void Update()
        {
            if(flockSize != GameObject.FindObjectsOfType<Flock>().Length)
            {
                flockList.Clear();
                foreach(var flock in GameObject.FindObjectsOfType<Flock>())
                {
                   
                    flock.transform.parent = transform;
                    flock.controller = this; 
                    flockList.Add(flock);
                    
                }
                flockSize = GameObject.FindObjectsOfType<Flock>().Length;
            }
            //Calculate the Center and Velocity of the whole flock group
            Vector2 center = Vector2.zero;
            Vector2 velocity = Vector2.zero;
            foreach (Flock flock in flockList)
            {
                center += (Vector2)flock.transform.localPosition;
                velocity += flock.GetComponent<Rigidbody2D>().velocity;
            }
            flockCenter = center / flockSize;
            flockVelocity = velocity / flockSize;
        }
    }
}