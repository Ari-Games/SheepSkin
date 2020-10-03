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

    [SerializeField]
    Transform home;

    private void Start() {
        wolf = GameObject.FindWithTag("Player").transform;
        var agent = this.gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, wolf.position) < distanceFromWolf)
        {
            GetComponent<NavMeshAgent>().SetDestination(wolf.position);
            return;
        }

        if(GWorld.Instance.GetWorld().HasState("BewareDogs"))
        {
            GetComponent<NavMeshAgent>().SetDestination(GWorld.Instance.GetLastWolfPosition());
            if(Vector2.Distance(transform.position,GWorld.Instance.GetLastWolfPosition())< 0.5f)
                GWorld.Instance.GetWorld().RemoveState("BewareDogs");
        }
        else
        {
            GetComponent<NavMeshAgent>().SetDestination(home.position);
        }
        
    }
}
