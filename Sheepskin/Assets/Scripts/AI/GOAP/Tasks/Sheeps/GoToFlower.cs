using System.Collections;
using System.Collections.Generic;
using Goap;
using UnityEngine;

public class GoToFlower : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("flowers").RemoveResource();
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
        GWorld.Instance.GetWorld().ModifyState("FreeFlower", -1);
        target.SetActive(false);
        beliefs.RemoveState("isHungry");
        GetComponent<Flocking.Flock>().enabled = true;
        return true;
    }
}
