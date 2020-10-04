﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;
using UnityEngine.AI;

public enum DogState
{
    Rest, 
    FindingAfterAtack,
    Finding,
    LookAround,
    Atack
}
public class Dog : MonoBehaviour
{
    [SerializeField]
    Transform wolf = null;
    [SerializeField]
    float distanceFromWolf = 2f;
    private bool isLastPos = false;
    private bool isLookAround = false;

    float timer = 0f;
    float timerTwo = 0f;
    float timeToChangeState = 3f;

    [SerializeField]
    Transform home;
    Vector2 lastWolfPosAfterAttack = Vector2.zero;
    private DogState dogState = DogState.Rest;

    private void Start() {
        wolf = GameObject.FindWithTag("Player").transform;
        var agent = this.gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        
    }
    // Update is called once per frame
    void Update()
    {
        SetDogState();
        if(dogState == DogState.Atack)
        {
            GetComponent<NavMeshAgent>().SetDestination(wolf.position);
            RotateToTarget(wolf.position);
            lastWolfPosAfterAttack = wolf.position;

        }
        else if (dogState == DogState.FindingAfterAtack)
        {
            GetComponent<NavMeshAgent>().SetDestination(lastWolfPosAfterAttack);
            RotateToTarget(lastWolfPosAfterAttack);
        }
        else if(dogState == DogState.LookAround)
        {
            print("LookAround");
        }
        else if(dogState == DogState.Finding)
        {
            timerTwo += Time.deltaTime;
            GetComponent<NavMeshAgent>().SetDestination(GWorld.Instance.GetLastWolfPosition());
            RotateToTarget(GWorld.Instance.GetLastWolfPosition());

            if(Vector2.Distance(transform.position,GWorld.Instance.GetLastWolfPosition())< 0.5f && timerTwo >= timeToChangeState)
                GWorld.Instance.GetWorld().RemoveState("BewareDogs");
        }
        else if(dogState == DogState.Rest)
        {
            GetComponent<NavMeshAgent>().SetDestination(home.position);
            RotateToTarget(home.position);
        }


    }

    private void SetDogState()
    {
        if (GetComponent<Sight>().isDetected)
        {
            dogState = DogState.Atack;
            isLastPos = true;
        }
        else if (isLastPos)
        {
            dogState = DogState.FindingAfterAtack;
            // timer += Time.deltaTime;
            // if(timer >= timeToChangeState)
            // {
            //     isLastPos = false;
            //     timer = 0f;
            // }
            // print(isLastPos + " " + timer);
            if(Vector2.Distance(transform.position, lastWolfPosAfterAttack) < 1f)
                isLastPos = false;
            isLookAround = true;
        }
        else if(isLookAround)
        {
            dogState = DogState.LookAround;
            timer += Time.deltaTime;
            if(timer >= timeToChangeState)
            {
                isLookAround = false;
                timer = 0;
            }
            // print(isLookAround + " " + timer);
        }
        else if(GWorld.Instance.GetWorld().HasState("BewareDogs"))
        {
            dogState = DogState.Finding;
        }
        else
        {
            dogState = DogState.Rest;
        }
    }

    // if (Vector2.Distance(transform.position, wolf.position) < distanceFromWolf)
    // {
    //     GetComponent<NavMeshAgent>().SetDestination(wolf.position);
    //     RotateToTarget(wolf.position);
    //     return;
    // }

    // if(GWorld.Instance.GetWorld().HasState("BewareDogs"))
    // {
    //     GetComponent<NavMeshAgent>().SetDestination(GWorld.Instance.GetLastWolfPosition());
    //     RotateToTarget(GWorld.Instance.GetLastWolfPosition());
    //     if(Vector2.Distance(transform.position,GWorld.Instance.GetLastWolfPosition())< 0.5f)
    //         GWorld.Instance.GetWorld().RemoveState("BewareDogs");
    // }
    // else
    // {
    //     GetComponent<NavMeshAgent>().SetDestination(home.position);
    //     RotateToTarget(home.position);
    // }
    private void RotateToTarget(Vector3 objLookAt)
    {
        Vector3 dir = objLookAt - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, angle - 90), Time.deltaTime * 5);
    }
}
