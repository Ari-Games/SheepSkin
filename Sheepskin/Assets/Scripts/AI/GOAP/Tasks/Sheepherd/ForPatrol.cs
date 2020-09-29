using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForPatrol : MonoBehaviour
{

    [SerializeField]
    Transform movementPath = null;
    public int currentPoint = 1;
    public int countOfPoints = 0;
  
    
    private void Awake() 
    {
        countOfPoints = movementPath.childCount;
    }
    
    // Start is called before the first frame update
    private void Update() 
    {
       
        if (GetComponent<Shepherd>().currentAction.actionName != "Patrol")
            this.enabled = false;
        PatrolWalking();
    }


    private void PatrolWalking()
    {
        if (currentPoint == 1)
        {
            GetComponent<NavMeshAgent>().SetDestination((Vector2)movementPath.GetChild(currentPoint - 1).position);
        }
        if (Vector2.Distance(transform.position, movementPath.GetChild(currentPoint - 1).position) <= 0.5f)
        {
            GetComponent<NavMeshAgent>().SetDestination((Vector2)movementPath.GetChild(currentPoint).position);
            currentPoint++;

            if (currentPoint == countOfPoints)
                currentPoint = 1;
        }
    }
   
}
