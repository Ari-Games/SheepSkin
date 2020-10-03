using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;
using UnityEngine.AI;

public class Dog : MonoBehaviour
{
    [SerializeField]
    Transform wolf = null;
    [SerializeField]
    float distanceFromWolf = 2f;
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, wolf.position) < distanceFromWolf)
        {
            GetComponent<NavMeshAgent>().SetDestination(wolf.position);
            return;
        }

        if(GWorld.Instance.GetWorld().HasState("BewareDog"))
        {
            GetComponent<NavMeshAgent>().SetDestination(GWorld.Instance.GetLastWolfPosition());
            GWorld.Instance.GetWorld().RemoveState("BewareDog");
        }
        // else
        // {
        //     //Animation
        // }
        
    }
}
