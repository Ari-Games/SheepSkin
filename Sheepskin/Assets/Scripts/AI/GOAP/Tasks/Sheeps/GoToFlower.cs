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

        InvokeRepeating("RotateTo",0,0.01f);
        
        if (GetComponent<Flocking.Flock>())
        {
            GetComponent<Flocking.Flock>().enabled = false;
        }
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().isKinematic = true;
        return true;
    }

    public override bool PostPerform()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        GWorld.Instance.GetWorld().ModifyState("FreeFlower", -1);
        target.SetActive(false);
        beliefs.RemoveState("isHungry");
        GetComponent<Flocking.Flock>().enabled = true;
        CancelInvoke("RotateTo");
        return true;
    }
}
