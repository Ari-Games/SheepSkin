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
        // beliefs.RemoveState("canGiveOrder");
       // GWorld.Instance.GetWorld().RemoveState("CanGiveOrder");
        GWorld.Instance.GetWorld().ModifyState("TimeToBeBeast", (int)this.duration);
        return true;
    }

    public override bool PostPerform()
    {
        //  print("PostPerform");
        beliefs.RemoveState("rest");
        // beliefs.ModifyState("canGiveOrder", 1);
        //GWorld.Instance.GetWorld().ModifyState("CanGiveOrder", 1);
        GWorld.Instance.GetWorld().RemoveState("TimeToBeBeast");
        return true;
    }

}
