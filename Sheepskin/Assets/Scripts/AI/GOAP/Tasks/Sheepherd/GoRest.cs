using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;
using UnityEngine.AI;

public class GoRest : GAction
{
    public override bool PrePerform()
    {
        //  print("PrePerform");
        beliefs.RemoveState("canGiveOrder");
        return true;
    }

    public override bool PostPerform()
    {
        //  print("PostPerform");
        beliefs.RemoveState("rest");
        beliefs.ModifyState("canGiveOrder", 1);
        return true;
    }

}
