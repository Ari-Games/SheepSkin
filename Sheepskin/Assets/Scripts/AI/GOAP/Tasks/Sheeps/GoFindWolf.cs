using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;

public class GoFindWolf : GAction
{
    public override bool PrePerform()
    {
        // print("PrePerform");
        this.duration = GWorld.Instance.GetWorld().states["TimeToBeBeast"];
        GWorld.Instance.GetWorld().RemoveState("TimeToBeBeast");
        if (GetComponent<Flocking.Flock>())
        {
            GetComponent<Flocking.Flock>().enabled = false;
        }
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        
        target = this.gameObject;
        return true;
    }

    public override bool PostPerform()
    {
        // print("PostPerform");
        GetComponent<Flocking.Flock>().enabled = true;
        return true;
    }
}
