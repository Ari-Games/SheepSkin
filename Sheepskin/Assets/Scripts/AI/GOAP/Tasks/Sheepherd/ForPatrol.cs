using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Goap;
public class ForPatrol : MonoBehaviour
{

    [SerializeField]
    Transform movementPath = null;
    public int currentPoint = 1;
    public int countOfPoints = 0;
    
    float standartSeparation = 14f;

    [SerializeField]
    float rageSeparation = 80f;

    float timer = 0f;
    float timeToChange = 0.5f;

    [SerializeField]
    float speedForChangeOnRage = 2f;
    [SerializeField]
    float speedForChangeOnCalm = 1f;

    [SerializeField]
    Flocking.FlockController flockController = null;

    private void Awake() 
    {
        countOfPoints = movementPath.childCount;
    }
    private void Start() {
        GetComponent<NavMeshAgent>().SetDestination((Vector2)movementPath.GetChild(currentPoint - 1).position);
        InvokeRepeating("PatrolWalking",0f,2f);
    }

    private void Update()
    {
        if(GWorld.Instance.GetWorld().HasState("TimeToBeBeast"))
        {
            timer += Time.deltaTime;

            GetComponent<NavMeshAgent>().speed = speedForChangeOnRage + 1f;
            foreach(var sheep in GameObject.FindObjectsOfType<Sheep>())
            {
                sheep.ChangeSpeed(speedForChangeOnRage);
            }

            if(flockController.separationWeight < rageSeparation && (timer > timeToChange)) 
            {
                flockController.separationWeight += 2.5f;
                timer = 0;
            }
        }
        else
        {
            timer = 0;
            GetComponent<NavMeshAgent>().speed = speedForChangeOnCalm + 0.5f;
            foreach (var sheep in GameObject.FindObjectsOfType<Sheep>())
            {
                sheep.ChangeSpeed(speedForChangeOnCalm);
            }
            flockController.separationWeight = standartSeparation;
        }
    }

    private void PatrolWalking()
    {
        if (Vector2.Distance(transform.position, movementPath.GetChild(currentPoint - 1).position) <= 0.5f)
        {
            currentPoint++;
            if(currentPoint > countOfPoints)
                currentPoint = 1;
            GetComponent<NavMeshAgent>().SetDestination((Vector2)movementPath.GetChild(currentPoint-1).position); 
        }
    }
   
}
