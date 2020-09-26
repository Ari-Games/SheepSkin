using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;
using UnityEngine.AI;

public class Finding : GAction
{
 
    
    public override bool PrePerform()
    {
        GetComponent<ForPatrol>().enabled = false;
        return true;
    }

    public override bool PostPerform()
    {
        //  print("PostPerform");
        beliefs.ModifyState("isPatrolTime", 1);
        return true;
    }

}
