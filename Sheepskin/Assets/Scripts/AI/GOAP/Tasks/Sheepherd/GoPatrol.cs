using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;
using UnityEngine.AI;

public class GoPatrol : GAction
{
   
    public override bool PrePerform()
    {
        // currentPoint = 1;
        beliefs.ModifyState("isPatrolTime",-1);
        return true;
    }

    public override bool PostPerform()
    {
        // print("PostPerform");
        GetComponent<ForPatrol>().enabled = true;
        GetComponent<ForPatrol>().currentPoint = 1;
        return true;
    }

}
