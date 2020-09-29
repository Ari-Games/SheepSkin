using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;

public class GoEat : GAction
{
    public override bool PrePerform()
    {

        return true;
    }

    public override bool PostPerform()
    {
        // print("PostPerform");
        beliefs.RemoveState("eat");
        return true;
    }
}
