using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;

public class GoDoWork : GAction
{
    public override bool PrePerform()
    {
        // print("PrePerform");
        // beliefs.RemoveState("canGiveOrder");
        //GWorld.Instance.GetWorld().RemoveState("CanGiveOrder");
        GWorld.Instance.GetWorld().ModifyState("TimeToBeBeast",(int)this.duration);
        InvokeRepeating("SetSpriteDisactive",0f,0.1f);
        return true;
    }

    public override bool PostPerform()
    {
        // print("PostPerform");
        // beliefs.ModifyState("canGiveOrder", 1);
       // GWorld.Instance.GetWorld().ModifyState("CanGiveOrder",1);
        GWorld.Instance.GetWorld().RemoveState("TimeToBeBeast");
        beliefs.RemoveState("work");
        CancelInvoke("SetSpriteDisactive");
        GetComponent<SpriteRenderer>().enabled = true;
        return true;
    }
}
