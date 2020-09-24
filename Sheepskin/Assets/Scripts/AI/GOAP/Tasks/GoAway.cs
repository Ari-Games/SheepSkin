using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAway : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("awayPoints").RemoveResource();
       // GWorld.Instance.GetWorld().ModifyState("Away", -1);
        if (target == null)
            return false;

        if (GetComponent<Flocking.Flock>())
        {
           GetComponent<Flocking.Flock>().enabled = false;
        }
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Away", -1);
        GetComponent<Flocking.Flock>().enabled = true;
        return true;
    }
}
