using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;

public class GoDoWork : GAction
{
    public override bool PrePerform()
    {
        print("PrePerform");
        beliefs.RemoveState("canGiveOrder");
        return true;
    }

    public override bool PostPerform()
    {
        print("PostPerform");
        beliefs.ModifyState("canGiveOrder", 1);
        beliefs.RemoveState("work");
        return true;
    }

}
