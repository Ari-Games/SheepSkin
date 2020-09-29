using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;
using UnityEngine.AI;

public class GoPatrol : GAction
{

    [SerializeField]
    Transform movementPath = null;
    public int currentPoint = 1;
    public int countOfPoints = 0;
   
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("patrolPaths").RemoveResource();
        if (target == null)
            return false;
        GetComponent<ForPatrol>().currentPoint = 1;
        GWorld.Instance.GetWorld().ModifyState("FreePath", -1);
        return true;
    }

    public override bool PostPerform()
    {
        // print("PostPerform")
        InvokeRepeating("PatrolWalking", 0, 0.5f);
        GWorld.Instance.GetQueue("patrolPaths").AddResource(target);
        // GWorld.Instance.GetWorld().ModifyState("FreePath", 1);
        return true;
    }

    private void PatrolWalking()
    {
        if(GetComponent<Shepherd>().currentAction.actionName != "Patrol")
        {
            CancelInvoke("PatrolWalking");
            GWorld.Instance.GetWorld().ModifyState("FreePath", 1);
        }
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
